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
                                MessageBox.Show("道具状态错误！（非待入库状态）");
                                return;
                            }
                            else
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
                                    }
                                });
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
    }
}
