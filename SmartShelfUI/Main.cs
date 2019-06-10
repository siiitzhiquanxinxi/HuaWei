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

        private void Main_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version:" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //初始化tcpip连接

            showFormLogin();
        }

        ChildForm.Login frmLogin = null;
        ChildForm.Pick frmPick = null;
        ChildForm.Menu frmMenu = null;
        ChildForm.Return frmReturn = null;

        void showFormLogin()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            globalField.Manager = null;
            globalField.BillID = "";
            lblUserName.Visible = false;
            pxb_loginface.Visible = false;
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
            frmPick.nextForm_exit += new ChildForm.Pick.FormHandle(showFormLogin);
            frmPick.TopLevel = false;
            panel_content.Controls.Add(frmPick);
            frmPick.Show();
            if (globalField.Manager != null)
            {
                pxb_loginface.Visible = true;
                lblUserName.Visible = true;
                lblUserName.Text = "欢迎使用，\r\n" + globalField.Manager.real_name;
            }
        }

        void showFormMenu()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            if (frmReturn != null)
            {
                frmReturn.Close();
                frmReturn = null;
            }
            frmMenu = new ChildForm.Menu();
            frmMenu.nextForm_return += new ChildForm.Menu.FormHandle(showFormReturn);
            frmMenu.nextForm_repair += new ChildForm.Menu.FormHandle(showFormRepair);
            frmMenu.nextForm_users += new ChildForm.Menu.FormHandle(showFormUsers);
            frmMenu.nextForm_warehouse += new ChildForm.Menu.FormHandle(showFormWarehouse);
            frmMenu.nextForm_stock += new ChildForm.Menu.FormHandle(showFormStock);
            frmMenu.nextForm_pick += new ChildForm.Menu.FormHandle(showFormPick);
            frmMenu.nextForm_exit += new ChildForm.Menu.FormHandle(showFormLogin);
            frmMenu.TopLevel = false;
            panel_content.Controls.Add(frmMenu);
            frmMenu.Show();
        }

        void showFormReturn()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmReturn = new ChildForm.Return();
            frmReturn.nextForm_exit += new ChildForm.Return.FormHandle(showFormMenu);
            frmReturn.TopLevel = false;
            panel_content.Controls.Add(frmReturn);
            frmReturn.Show();
        }
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
