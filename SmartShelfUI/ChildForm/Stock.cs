using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        /// <summary>
        /// 显示9宫格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("FK_ShelfID = " + shelf.ID + " and X = " + (i + 1).ToString() + " and Y = " + (j + 1).ToString() + "");
                            if (lstmodel != null && lstmodel.Count > 0)
                            {
                                if (lstmodel[0].State == 1 || lstmodel[0].State == 4)
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

        /// <summary>
        /// 显示抽屉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCabinet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCabinet.SelectedRows != null && dgvCabinet.SelectedRows.Count > 0)
            {
                string CabinetNo = dgvCabinet.SelectedRows[0].Cells[0].Value.ToString();
                string sql = "select ID,BoxNo from sy_shelf where FK_CabinetNo = '" + CabinetNo + "' order by CONVERT(BoxNo,SIGNED)";
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
                                    DTcms.Model.sy_material mmodel = new DTcms.BLL.sy_material().GetModel(tool.MaterialID);
                                    string sqlshelf = "select * from sy_shelf where Deep>='" + mmodel.Deep + "' and High>='" + mmodel.High + "' order by High,Deep";
                                    DataTable dtshelf = DbHelperMySql.Query(sqlshelf).Tables[0];
                                    if (dtshelf.Rows.Count == 0)
                                    {
                                        MessageBox.Show("没有大小相匹配的单元格！");
                                        return;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < dtshelf.Rows.Count; i++)
                                        {
                                            int x = Convert.ToInt32(dtshelf.Rows[i]["X"]);
                                            int y = Convert.ToInt32(dtshelf.Rows[i]["Y"]);
                                            for (int b = 1; b <= y; b++)
                                            {
                                                for (int a = 1; a <= x; a++)
                                                {
                                                    string sqlbox = "select * from w_barcode where FK_ShelfID='" + dtshelf.Rows[i]["ID"].ToString() + "' and X='" + a.ToString() + "' and Y='" + b.ToString() + "' and state<>-1";
                                                    DataTable dtbox = DbHelperMySql.Query(sqlbox).Tables[0];
                                                    if (dtbox.Rows.Count == 0)
                                                    {
                                                        tool.X = a;
                                                        tool.Y = b;
                                                        tool.State = 1;
                                                        new DTcms.BLL.w_barcode().Update(tool);
                                                        DTcms.Model.sy_cabinet cabinet = new DTcms.BLL.sy_cabinet().GetModel(dtshelf.Rows[i]["FK_CabinetNo"].ToString());
                                                        string shelfNo = dtshelf.Rows[i]["BoxNo"].ToString();
                                                        string unitNo = ((b - 1) * x + a).ToString();
                                                        MessageBox.Show("分配成功，新的物理位置为：" + cabinet.CabinetNo + "号柜，" + shelfNo + "号抽屉，" + unitNo + "号格；物料已默认入库，请放入指定的单元格中！");
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                    }
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
            if (MessageBox.Show("是否确认将该物料盘亏？", "确认盘亏", MessageBoxButtons.OKCancel) == DialogResult.OK)
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

        private void btnOpenDoor_Click(object sender, EventArgs e)
        {
            if (this.shelf == null)
            {
                MessageBox.Show("请选择抽屉！");
                return;
            }
            string IP = "";
            string Port = "";
            if (shelf != null)
            {
                cabinet = new DTcms.BLL.sy_cabinet().GetModelList("CabinetNo = '" + shelf.FK_CabinetNo + "'")[0];
                IP = cabinet.IP;
                Port = cabinet.Port;
            }
            if (connect(IP, Port))
            {
                byte[] rec_byte = null;
                byte[] code_byte = new byte[6];
                code_byte[0] = 0xFF;
                code_byte[1] = (byte)Convert.ToInt32(cabinet.CardAddr, 16);
                code_byte[2] = (byte)Convert.ToInt32(shelf.BoxAddr, 16);
                code_byte[3] = 0x01;
                code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
                code_byte[5] = 0xFE;
                rec_byte = sendtcpip(code_byte, IP, Port);
                if (VerifyReceive(rec_byte))
                {
                    if (rec_byte[3] == 0x01)//门正常打开
                    {

                    }
                    else if (rec_byte[3] == 0x00)//门开着，不能打开
                    {
                        MessageBox.Show("检测到抽屉门已打开，请确认是否有他人正在操作，否则请关闭抽屉门后重新操作，谢谢！");
                    }
                    else
                    {
                        MessageBox.Show("开门指令执行失败！请联系管理员检查硬件！");
                    }
                }
                else
                {
                    MessageBox.Show("网络通讯返回错误！");
                }
            }
            else
            {
                MessageBox.Show("网络通信失败！");
            }
        }


        private IPEndPoint serverFullAddr;
        private Socket sock;
        private bool connect(string IP, string Port)
        {
            IPAddress serverIP;
            int port;
            serverIP = IPAddress.Parse(IP);
            port = int.Parse(Port);
            try
            {
                serverFullAddr = new IPEndPoint(serverIP, port);//设置IP，端口  
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //指定本地主机地址和端口号  
                sock.Connect(serverFullAddr);
                sock.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private byte[] sendtcpip(byte[] byteCode, string IP, string Port)
        {
            try
            {
                IPAddress serverIP;
                int port;
                serverIP = IPAddress.Parse(IP);
                port = int.Parse(Port);
                serverFullAddr = new IPEndPoint(serverIP, port);//设置IP，端口  
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //指定本地主机地址和端口号  
                sock.Connect(serverFullAddr);
                byte[] message = new byte[1024 * 64];
                int bytes = 0;
                //发送数据
                sock.Send(byteCode);
                bytes = sock.Receive(message);//接收数据 
                byte[] returnreceive = new byte[bytes];
                Array.Copy(message, 0, returnreceive, 0, bytes);
                sock.Close();
                return returnreceive;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sock.Close();
            }
        }
        private bool VerifyReceive(byte[] receive)
        {
            if (receive.Length != 6)
            {
                return false;
            }
            if (receive[0] != 0xFE)
            {
                return false;
            }
            if (receive[5] != 0xFF)
            {
                return false;
            }
            if (receive[4] != Convert.ToByte(receive[1] ^ receive[2] ^ receive[3]))
            {
                return false;
            }
            return true;
        }

        private void btnReScan_Click(object sender, EventArgs e)
        {
            this.BarCode = "";
        }

        private void btnRepairOpen_Click(object sender, EventArgs e)
        {
            if (this.cabinet == null)
            {
                MessageBox.Show("请选择柜子！");
                return;
            }
            else if (MessageBox.Show("确认打开号" + cabinet.CabinetNo + "柜的所有抽屉？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string IP = "";
                string Port = "";
                if (cabinet != null)
                {
                    //cabinet = new DTcms.BLL.sy_cabinet().GetModelList("CabinetNo = '" + shelf.FK_CabinetNo + "'")[0];
                    IP = cabinet.IP;
                    Port = cabinet.Port;
                }
                if (connect(IP, Port))
                {
                    byte[] rec_byte = null;
                    byte[] code_byte = new byte[6];
                    code_byte[0] = 0xFF;
                    code_byte[1] = (byte)Convert.ToInt32(cabinet.CardAddr, 16);
                    code_byte[2] = 0x00;
                    code_byte[3] = 0x02;
                    code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
                    code_byte[5] = 0xFE;
                    rec_byte = sendtcpip(code_byte, IP, Port);
                    if (VerifyReceive(rec_byte))
                    {
                        if (rec_byte[3] == 0x02)//返回成功
                        {

                        }
                        else if (rec_byte[3] == 0xFF)//门开着，不能打开
                        {
                            MessageBox.Show("指令失败！");
                        }
                        else
                        {
                            MessageBox.Show("指令失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("网络通讯返回错误！");
                    }
                }
                else
                {
                    MessageBox.Show("网络通信失败！");
                }
            }
        }
    }
}
