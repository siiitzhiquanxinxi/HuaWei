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
    public partial class CellsLocationForGeneral : Form
    {
        public CellsLocationForGeneral()
        {
            InitializeComponent();
        }

        public CellsLocationForGeneral(bool isCOM)
        {
            InitializeComponent();
            if (isCOM)
            {
                IsCom = true;
            }
        }
        private bool IsCom = false;
        public DTcms.Model.w_barcode tool = null;
        public DTcms.Model.sy_shelf shelf = null;
        public DTcms.Model.sy_cabinet cabinet = null;
        private void CellsLocationForGeneral_Load(object sender, EventArgs e)
        {
            if (IsCom)
            {
                try
                {
                    this.spCom.PortName = ConfigurationManager.AppSettings["qrcom"].Trim();
                    spCom.Open();
                    spCom.Write("LON\r\n");
                }
                catch
                {
                    MessageBox.Show("串口打开失败！");
                }
            }
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
                        b.BackColor = SystemColors.ControlDark;
                        if (tool.X == i + 1 && tool.Y == j + 1)
                        {
                            b.BackColor = Color.Orange;
                        }
                        b.UseVisualStyleBackColor = true;
                        panel_Cells.Controls.Add(b);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CellsLocationForGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsCom)
            {
                if (this.spCom.IsOpen)
                {
                    try
                    {
                        spCom.Write("LOFF\r\n");
                        spCom.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("关闭串口失败：" + ex.ToString());
                    }
                }
            }
        }

        string BarCode = "";
        private void spCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(300);
            string receive_str = "";
            byte[] result = new byte[16];
            int rLength = spCom.Read(result, 0, result.Length);
            if (rLength >= 8)
            {
                foreach (byte item in result)
                {
                    char c = Convert.ToChar(item);
                    if (c == '\r')
                    {
                        break;
                    }
                    else
                    {
                        receive_str += Convert.ToChar(item);
                    }
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
                List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("BarCode = '" + barcode.ToUpper() + "' and FK_ShelfID = " + shelf.ID);
                if (lstmodel != null && lstmodel.Count > 0)
                {
                    //变颜色
                    foreach (Control item in panel_Cells.Controls)
                    {
                        if (item is Button)
                        {
                            Button b = item as Button;
                            if (b.Tag.ToString() == lstmodel[0].X + "-" + lstmodel[0].Y)
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
    }
}
