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

namespace SmartShelfUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int n = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            lst.Remove(n.ToString());
            n++;
        }

        List<string> lst = new List<string>();
        private void Form2_Load(object sender, EventArgs e)
        {
            MySocket = new SocketWrapper(ConfigurationManager.AppSettings["serverip"], int.Parse(ConfigurationManager.AppSettings["serverport"]));
            MySocket.CommandArrival += new SocketWrapper.CommandArrivalEventHandler(client_PlaintextReceived);
            if (MySocket.Socket_Create_Connect())
            {
                MySocket.Run();
            }
            else
            {
                thStartSocket = new Thread(StartSocket);
                thStartSocket.Start();
                MessageBox.Show("连接失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            for (int i = 0; i < lst.Count; i++)
            {
                textBox1.Text += lst[i] + "\r\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DTcms.Model.sy_shelf shelf = new DTcms.BLL.sy_shelf().GetModel(3);
            DTcms.Model.sy_cabinet cabinet = new DTcms.BLL.sy_cabinet().GetModel(shelf.FK_CabinetNo);

            byte[] code_byte = new byte[6];
            code_byte[0] = 0xFF;
            code_byte[1] = (byte)Convert.ToInt32(cabinet.CardAddr, 16);
            code_byte[2] = (byte)Convert.ToInt32(shelf.BoxAddr, 16);
            code_byte[3] = 0x01;
            code_byte[4] = Convert.ToByte(code_byte[1] ^ code_byte[2] ^ code_byte[3]);
            code_byte[5] = 0xFE;
            MySocket.SyncSend(code_byte);
        }

        SocketWrapper MySocket;
        Thread thStartSocket;
        void StartSocket()
        {
            while (!MySocket.IsConnect)
            {
                try
                {
                    MySocket.Socket_Create_Connect();
                    Thread.Sleep(2000);
                }
                catch (Exception)
                { }
            }
            if (MySocket.IsConnect)
            {
                MySocket.Run();
            }
        }
        void client_PlaintextReceived(object sender, SocketWrapper.MyEventArgs e)
        {
            if (e.CommandBuf != null)
            {
                int inLen = e.CommandBuf.Length;
                byte[] receiveByte = new byte[inLen];
                Array.Copy(e.CommandBuf, 0, receiveByte, 0, inLen);
                this.BeginInvoke((MethodInvoker)delegate
                {

                    textBox1.Text = getStr(receiveByte[0].ToString("x6")) + "\r\n" + getStr(receiveByte[1].ToString("x6")) + "\r\n" + getStr(receiveByte[2].ToString("x6")) + "\r\n" + getStr(receiveByte[3].ToString("x6")) + "\r\n" + getStr(receiveByte[4].ToString("x6")) + "\r\n" + getStr(receiveByte[5].ToString("x6"));
                });

            }
        }

        private string getStr(string ss)
        {
            string return_str = "";
            return_str = ss.Substring(ss.Length - 2, 2);
            return_str = "0x" + return_str.ToUpper();
            return return_str;
        }
    }
}
