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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class Warehousing : Form
    {
        public Warehousing()
        {
            InitializeComponent();
        }

        private void Warehousing_Load(object sender, EventArgs e)
        {
            spCom.PortName = ConfigurationManager.AppSettings["rfidcom"].Trim();
        }

        private void spCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] result = new byte[16];
            int rLength = spCom.Read(result, 0, result.Length);
            if (rLength >= 1)
            {
                if (true)
                {
                    //开门并显示9宫格
                    string barcode = result.ToString();
                    List<DTcms.Model.w_barcode> lstmodel = new DTcms.BLL.w_barcode().GetModelList("BarCode = '" + barcode + "' and State = 0");
                    {
                        if (lstmodel != null && lstmodel.Count > 0)
                        {
                            string IP = "";
                            string Port = "";
                            if (connect(IP, Port))
                            {
                                byte[] rec_byte = null;
                                byte[] code_byte = new byte[6];
                                code_byte[0] = 0xFF;
                                code_byte[1] = 0x01;
                                code_byte[2] = 0x21;
                                code_byte[3] = 0x01;
                                code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
                                code_byte[5] = 0xFE;
                                rec_byte = sendtcpip(code_byte, IP, Port);
                                if (VerifyReceive(rec_byte))
                                {
                                    ChildForm.CellsLocationForWarehousing frm = new CellsLocationForWarehousing();
                                    if (frm.ShowDialog() == DialogResult.OK)//入库成功
                                    {

                                    }
                                    else//取消入库
                                    {

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
                            else
                            {
                                this.BeginInvoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("网络通信失败！");
                                });
                            }
                        }
                        else
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("该道具编码不在待入库清单中！");
                            });
                        }
                    }
                }
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

    }
}
