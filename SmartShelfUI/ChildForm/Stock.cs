using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            try
            {
                spCom.PortName = ConfigurationManager.AppSettings["qrcom"].Trim();
                if (!spCom.IsOpen)
                {
                    spCom.Open();
                }
                spCom.Write("LON\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口打开失败：" + ex.ToString());
            }
            GetCabinetList();
        }

        private void GetCabinetList()
        {
            string sql = "select CabinetNo from sy_cabinet where 1=1 order by CabinetNo";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            dgvCabinet.DataSource = dt;
        }

        private void dgvShelf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShelf.SelectedRows != null && dgvShelf.SelectedRows.Count > 0)
            {
                panel_Cells.Controls.Clear();
                string shelfId = dgvShelf.SelectedRows[0].Cells[0].Value.ToString();
                shelf = new DTcms.BLL.sy_shelf().GetModel(int.Parse(shelfId));
                if (shelf != null)
                {
                    int x = Convert.ToInt16(shelf.X);
                    int y = Convert.ToInt16(shelf.Y);
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            Button b = new Button();
                            b.FlatAppearance.BorderSize = 0;
                            b.FlatStyle = FlatStyle.Flat;
                            b.Location = new Point(20 + 65 * i, 20 + 55 * j);
                            b.Size = new Size(55, 45);
                            b.Tag = (i + 1).ToString() + "-" + (j + 1).ToString();
                            //b.Text = (i + 1).ToString() + "-" + (j + 1).ToString();
                            b.Text = (j * x + i + 1).ToString();
                            b.Font = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("FK_ShelfID = " + shelf.ID + " and X = " + i + " and Y = " + j + "");
                            if (lstmodel != null && lstmodel.Count > 0)
                            {
                                if (lstmodel[0].State == 2 || lstmodel[0].State == 4)
                                {
                                    b.BackColor = SystemColors.ControlDark;
                                    b.Click += btnCell_Click;
                                }
                                else
                                {
                                    b.BackColor = Color.WhiteSmoke;
                                }
                            }
                            else
                            {
                                b.BackColor = Color.WhiteSmoke;
                            }


                            b.UseVisualStyleBackColor = true;
                            panel_Cells.Controls.Add(b);
                        }
                    }
                }
            }
        }

        private void dgvCabinet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCabinet.SelectedRows != null && dgvCabinet.SelectedRows.Count > 0)
            {
                string CabinetNo = dgvCabinet.SelectedRows[0].Cells[0].Value.ToString();
                string sql = "select ID,BoxNo from sy_shelf where FK_CabinetNo = '" + CabinetNo + "' order by BoxNo";
                DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                dgvShelf.DataSource = dt;
                cabinet = new DTcms.BLL.sy_cabinet().GetModel(CabinetNo);
            }
        }

        DTcms.Model.w_barcode tool = null;
        DTcms.Model.sy_cabinet cabinet = null;
        DTcms.Model.sy_shelf shelf = null;
        string BarCode = "";
        private void spCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(300);
            try
            {
                string receive_str = "";
                byte[] result = new byte[128];
                int rLength = spCom.Read(result, 0, result.Length);
                if (rLength >= 8)
                {
                    //string barcode = result[0].ToString("x2") + result[1].ToString("x2") + result[2].ToString("x2") + result[3].ToString("x2") + result[4].ToString("x2") + result[5].ToString("x2") + result[6].ToString("x2") + result[7].ToString("x2");
                    foreach (byte item in result)
                    {
                        receive_str += Convert.ToChar(item);
                    }
                    string barcode = receive_str.Trim();
                    if (barcode == BarCode)
                    {
                        return;
                    }
                    else
                    {
                        BarCode = barcode;
                    }
                    List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("BarCode = '" + barcode.ToUpper() + "'");
                    if (lstmodel != null && lstmodel.Count > 0)
                    {
                        tool = lstmodel[0];
                        if (tool.State == -2)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (MessageBox.Show("该物料为盘亏状态，是否重新分配单元格？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                {
                                    //分配新的物理位置
                                }
                            });
                        }
                        else if (tool.State == -1)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("物料已报废！");
                            });
                        }
                        else
                        {
                            if (shelf != null)
                            {
                                if (tool.FK_ShelfID != shelf.ID)
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("物料不应在该抽屉内！");
                                    });
                                }
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    lblToolName.Text = tool.MaterialName;
                                    lblToolLevel.Text = tool.ToolLevel;
                                    lblRestWorkTime.Text = tool.RemainTime.ToString() + " min";
                                    lblCabinetNo.Text = cabinet.CabinetNo + "号";
                                    lblShelfNo.Text = shelf.BoxNo + "号";
                                    lblToolState.Text = tool.State == 0 ? "待入库" : tool.State == 1 ? "在库" : tool.State == 2 ? "出库中" : tool.State == 3 ? "修磨中" : tool.State == -1 ? "报废" : tool.State == 4 ? "工单锁定" : tool.State == -2 ? "盘亏" : "其他异常";
                                });
                                foreach (Control item in panel_Cells.Controls)
                                {
                                    if (item is Button)
                                    {
                                        Button b = item as Button;
                                        if (b.Tag.ToString() == tool.X + "-" + tool.Y)
                                        {
                                            this.BeginInvoke((MethodInvoker)delegate
                                            {
                                                b.BackColor = Color.Green;
                                                b.ForeColor = Color.White;
                                            });
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.WriteError("盘点扫码", ex.ToString());
            }
        }

        private void Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spCom.IsOpen)
            {
                spCom.Write("LOFF\r\n");
                spCom.Close();
            }
        }

        private void btnCell_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认将该物料盘亏？") == DialogResult.OK)
            {
                Button btn = sender as Button;
                List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("FK_ShelfID = " + shelf.ID + " and X = " + btn.Tag.ToString().Split('-')[0] + " and Y = " + btn.Tag.ToString().Split('-')[1] + "");
                if (lstmodel != null && lstmodel.Count > 0)
                {
                    lstmodel[0].State = -2;
                    new DTcms.BLL.w_barcode().Update(lstmodel[0]);
                }
            }
        }
    }
}
