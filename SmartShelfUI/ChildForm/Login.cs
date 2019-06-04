using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class Login : Form
    {
        string comName = ConfigurationManager.AppSettings["rfidcom"].Trim();
        public Login()
        {
            InitializeComponent();
        }

        public delegate void FormHandle();
        public event FormHandle nextForm;
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comName;
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }
            }
            catch (Exception ex)
            {
                Utils.WriteError("打开rfid的COM口", ex.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (true)
            {
                nextForm();
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] result = new byte[16];
            int rLength = serialPort1.Read(result, 0, result.Length);
            if (rLength >= 1)
            {
                if (true)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        nextForm();
                    });
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("登录失败！");
                    });
                }
            }
        }
    }
}
