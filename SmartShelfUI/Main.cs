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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

        SocketWrapper MySocket;
        private void Main_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //初始化tcpip连接
            try
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
            catch (Exception ex)
            {
                Utils.WriteError("初始化tcpip连接", ex.ToString());
            }

            showFormLogin();
        }

        /// <summary>
        /// 接受TCP/IP反馈信息
        /// </summary>
        void client_PlaintextReceived(object sender, SocketWrapper.MyEventArgs e)
        {
            if (e.CommandBuf != null)
            {
                int inLen = e.CommandBuf.Length;
                byte[] NewByte = new byte[inLen];
                Array.Copy(e.CommandBuf, 0, NewByte, 0, inLen);
                string receive_str = Encoding.Unicode.GetString(NewByte).Trim().Replace("\0", "");
                if (receive_str == "")
                { }
            }
        }

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

        ChildForm.Login frmLogin;
        ChildForm.Pick frmPick;
        ChildForm.Menu frmMenu;
        void showFormLogin()
        {
            frmLogin = new ChildForm.Login();
            frmLogin.nextForm += new ChildForm.Login.FormHandle(showFormPick);
            frmLogin.TopLevel = false;
            panel_content.Controls.Add(frmLogin);
            frmLogin.Show();
        }

        void showFormPick()
        {
            if (frmLogin != null)
            {
                frmLogin.Close();
                frmLogin = null;
            }
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmPick = new ChildForm.Pick();
            frmPick.nextForm_menu += new ChildForm.Pick.FormHandle(showFormMenu);
            frmPick.TopLevel = false;
            panel_content.Controls.Add(frmPick);
            frmPick.Show();
        }

        void showFormMenu()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            frmMenu = new ChildForm.Menu();
            frmMenu.nextForm_return += new ChildForm.Menu.FormHandle(showFormReturn);
            frmMenu.nextForm_repair += new ChildForm.Menu.FormHandle(showFormRepair);
            frmMenu.nextForm_users += new ChildForm.Menu.FormHandle(showFormUsers);
            frmMenu.nextForm_warehouse += new ChildForm.Menu.FormHandle(showFormWarehouse);
            frmMenu.nextForm_stock += new ChildForm.Menu.FormHandle(showFormStock);
            frmMenu.nextForm_pick += new ChildForm.Menu.FormHandle(showFormPick);
            frmMenu.TopLevel = false;
            panel_content.Controls.Add(frmMenu);
            frmMenu.Show();
        }

        void showFormReturn()
        { MessageBox.Show("1"); }
        void showFormRepair()
        { MessageBox.Show("1"); }
        void showFormUsers()
        { MessageBox.Show("1"); }
        void showFormWarehouse()
        { MessageBox.Show("1"); }
        void showFormStock()
        { MessageBox.Show("1"); }
    }
}
