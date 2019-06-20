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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class Repair : Form
    {
        public Repair()
        {
            InitializeComponent();
        }

        DTcms.Model.w_barcode tool = null;
        DTcms.Model.sy_shelf shelf = null;
        DTcms.Model.sy_cabinet cabinet = null;
        string BarCode = "";
        private void Repair_Load(object sender, EventArgs e)
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
        }

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
                        shelf = new DTcms.BLL.sy_shelf().GetModel(Convert.ToInt32(lstmodel[0].FK_ShelfID));
                        cabinet = new DTcms.BLL.sy_cabinet().GetModel(shelf.FK_CabinetNo);
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            lblToolName.Text = lstmodel[0].MaterialName;
                            lblToolLevel.Text = lstmodel[0].ToolLevel;
                            lblRestWorkTime.Text = lstmodel[0].RemainTime.ToString() + " min";
                            lblCabinetNo.Text = cabinet.CabinetNo + "号";
                            lblShelfNo.Text = shelf.BoxNo + "号";
                            lblToolState.Text = lstmodel[0].State == 0 ? "待入库" : lstmodel[0].State == 1 ? "在库" : lstmodel[0].State == 2 ? "出库中" : lstmodel[0].State == 3 ? "修磨中" : lstmodel[0].State == -1 ? "报废" : lstmodel[0].State == 4 ? "工单锁定" : "其他异常";
                        });
                        if (shelf != null)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                panel_Cells.Controls.Clear();
                            });
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
                            if (tool.State != 0)
                            {
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("刀具状态错误！（非修磨状态）");
                                });
                                return;
                            }
                            else
                            {
                                if (txtWorkTime.Text == "")
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("请输入加工寿命！");
                                    });
                                    return;
                                }
                                else if (!IsNumber(txtWorkTime.Text))
                                {
                                    this.BeginInvoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("请输入正确的加工寿命！");
                                    });
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
                                            this.BeginInvoke((MethodInvoker)delegate
                                            {
                                                CellsLocationForGeneral frmCells = new CellsLocationForGeneral();
                                                frmCells.tool = this.tool;
                                                frmCells.cabinet = this.cabinet;
                                                frmCells.shelf = this.shelf;
                                                if (frmCells.ShowDialog() == DialogResult.OK)
                                                {
                                                    //修改刀具状态
                                                    tool.State = 1;
                                                    tool.ToolLevel = "R";
                                                    tool.RemainTime = decimal.Parse(txtWorkTime.Text);
                                                    new DTcms.BLL.w_barcode().Update(tool);
                                                    //生成修磨入库记录
                                                    DTcms.Model.w_inout_detail inout = new DTcms.Model.w_inout_detail();
                                                    inout.FK_BillID = globalField.BillID;
                                                    inout.BarCode = tool.BarCode;
                                                    inout.BatchNumber = tool.BatchNumber;
                                                    inout.MaterialID = tool.MaterialID;
                                                    inout.MaterialName = tool.MaterialName;
                                                    inout.MaterialTypeID = tool.MaterialTypeID;
                                                    inout.MaterialType = tool.MaterialType;
                                                    inout.SystemNo = tool.SystemNo;
                                                    inout.Brand = tool.Brand;
                                                    inout.Spec = tool.Spec;
                                                    inout.Unit = tool.Unit;
                                                    inout.Num = tool.Num;
                                                    inout.IOFlag = 1;
                                                    inout.FK_SendBillNum = null;
                                                    inout.FK_ApproveNum = null;
                                                    inout.InOutType = "修磨入库";
                                                    inout.FK_ShelfID = shelf.ID;
                                                    inout.X = shelf.X;
                                                    inout.Y = shelf.Y;
                                                    inout.WorkTime = 0;
                                                    inout.OperatorName = globalField.Manager.real_name;
                                                    inout.OperatorTime = DateTime.Now;
                                                    inout.InOutRemark = "";
                                                    new DTcms.BLL.w_inout_detail().Add(inout);
                                                    txtWorkTime.Text = "";
                                                }
                                            });
                                        }
                                        else if (rec_byte[3] == 0x00)//门开着，不能打开
                                        {
                                            this.BeginInvoke((MethodInvoker)delegate
                                            {
                                                MessageBox.Show("检测到抽屉门已打开，请确认是否有他人正在操作，否则请关闭抽屉门后重新操作，谢谢！");
                                            });
                                        }
                                        else
                                        {
                                            this.BeginInvoke((MethodInvoker)delegate
                                            {
                                                MessageBox.Show("开门指令执行失败！请联系管理员检查硬件！");
                                            });
                                        }
                                    }
                                    else
                                    {
                                        this.BeginInvoke((MethodInvoker)delegate
                                        {
                                            MessageBox.Show("网络通讯返回错误！");
                                        });
                                    }
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
            catch (Exception ex)
            {
                Utils.WriteError("入库扫码", ex.ToString());
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
            if (receive[0] != 0xFF)
            {
                return false;
            }
            if (receive[4] != Convert.ToByte(receive[1] ^ receive[2] ^ receive[3]))
            {
                return false;
            }
            return true;
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

        private void Repair_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (spCom.IsOpen)
            {
                spCom.Write("LOFF\r\n");
                spCom.Close();
            }
        }
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

        private void btnReScan_Click(object sender, EventArgs e)
        {
            this.BarCode = "";
        }
    }
}
