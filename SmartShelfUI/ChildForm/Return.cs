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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            try
            {
                spCom.PortName = ConfigurationManager.AppSettings["qrcom"].Trim();
                if (!spCom.IsOpen)
                {
                    spCom.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口打开失败：" + ex.ToString());
            }
        }

        public delegate void FormHandle();
        public event FormHandle nextForm_exit;
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (tool == null)
            {
                MessageBox.Show("请扫描刀具编码！");
                return;
            }
            else if (tool.State != 2)
            {
                switch (tool.State)
                {
                    case 0:
                        MessageBox.Show("该物料尚未初始化入库！");
                        break;
                    case 1:
                        MessageBox.Show("该物料已在库，请核实！");
                        break;
                    case 3:
                        MessageBox.Show("该物料修磨中，请选择修磨刀入库！");
                        break;
                    case -1:
                        MessageBox.Show("该物料已报废！");
                        break;
                    default:
                        MessageBox.Show("该物料状态异常！");
                        break;
                }
                return;
            }
            //开门TCPIP
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
                    CellsLocationForGeneral frmCells = new CellsLocationForGeneral();
                    frmCells.tool = this.tool;
                    frmCells.cabinet = this.cabinet;
                    frmCells.shelf = this.shelf;
                    if (frmCells.DialogResult == DialogResult.OK)
                    {
                        ///生成记录
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


        private void btnBaofei_Click(object sender, EventArgs e)
        {

        }

        private void btnXiumo_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            nextForm_exit();
        }
        DTcms.Model.w_barcode tool = null;
        DTcms.Model.sy_shelf shelf = null;
        DTcms.Model.sy_cabinet cabinet = null;
        private void spCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(300);

            byte[] result = new byte[8];
            int rLength = spCom.Read(result, 0, result.Length);
            if (rLength >= 8)
            {
                string barcode = result[0].ToString("x2") + result[1].ToString("x2") + result[2].ToString("x2") + result[3].ToString("x2") + result[4].ToString("x2") + result[5].ToString("x2") + result[6].ToString("x2") + result[7].ToString("x2");
                List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("BarCode = '" + barcode.ToUpper() + "'");
                if (lstmodel != null && lstmodel.Count > 0)
                {
                    tool = lstmodel[0];
                    shelf = new DTcms.BLL.sy_shelf().GetModel(Convert.ToInt32(lstmodel[0].FK_ShelfID));
                    cabinet = new DTcms.BLL.sy_cabinet().GetModel(shelf.FK_CabinetNo);
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        lblToolName.Text = lstmodel[0].MaterialName;
                        lblToolLevel.Text = lstmodel[0].ToolLevel;
                        lblRestWorkTime.Text = lstmodel[0].RemainTime.ToString() + " min";
                        lblCabinetNo.Text = cabinet.CabinetNo + "号";
                        lblShelfNo.Text = shelf.BoxNo + "号";
                        lblToolState.Text = lstmodel[0].State == 0 ? "待入库" : lstmodel[0].State == 1 ? "在库" : lstmodel[0].State == 2 ? "出库中" : lstmodel[0].State == 3 ? "修磨中" : lstmodel[0].State == -1 ? "报废" : "其他异常";
                        if (lstmodel[0].State == 2)
                        {
                            List<DTcms.Model.w_inout_detail> lstdetail = new DTcms.BLL.w_inout_detail().GetModelList("BarCode = '" + lstmodel[0].BarCode + "' and IOFlag = -1 order by OperatorTime desc");
                            if (lstdetail != null && lstdetail.Count > 0)
                            {
                                lblLastPickMan.Text = lstdetail[0].OperatorName;
                                lblLastPickTime.Text = Convert.ToDateTime(lstdetail[0].OperatorTime).ToString("yyyy年MM月dd日 HH时mm分");
                                lblLastPickType.Text = lstdetail[0].InOutType;
                                lblLastPickPartNum.Text = !string.IsNullOrEmpty(lstdetail[0].FK_SendBillNum) ? lstdetail[0].FK_SendBillNum : (lstdetail[0].FK_ApproveNum + "（申请单号）");
                            }

                        }

                    });
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
                                b.Text = (i + 1).ToString() + "-" + (j + 1).ToString();
                                b.Font = new Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                                b.BackColor = SystemColors.ControlDark;
                                if (lstmodel[0].X == i + 1 && lstmodel[0].Y == j + 1)
                                {
                                    b.BackColor = Color.Orange;
                                }
                                b.UseVisualStyleBackColor = true;
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    panel_Cells.Controls.Add(b);
                                });

                            }
                        }
                    }
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("没有查询到该物料！");
                    });
                }
            }
        }

        private void Return_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spCom.IsOpen)
            {
                spCom.Close();
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
    }
}
