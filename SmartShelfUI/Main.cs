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
        ChildForm.ManageWeb frmManageWeb = null;
        ChildForm.DisPick_Plan frmDisPick_Plan = null;
        ChildForm.DisPick_UnPlan frmDisPick_UnPlan = null;
        ChildForm.Warehousing frmWarehousing = null;
        ChildForm.Userscard frmUserscard = null;
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
            frmPick.nextForm_dispick_plan += new ChildForm.Pick.FormHandle(showFormDisPick_Plan);
            frmPick.nextForm_dispick_unplan += new ChildForm.Pick.FormHandle(showFormDisPick_UnPlan);

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
            if (frmManageWeb != null)
            {
                frmManageWeb.Close();
                frmManageWeb = null;
            }
            if (frmDisPick_Plan != null)
            {
                frmDisPick_Plan.Close();
                frmDisPick_Plan = null;
            }
            if (frmDisPick_UnPlan != null)
            {
                frmDisPick_UnPlan.Close();
                frmDisPick_UnPlan = null;
            }
            if (frmWarehousing != null)
            {
                frmWarehousing.Close();
                frmWarehousing = null;
            }
            if (frmUserscard != null)
            {
                frmUserscard.Close();
                frmUserscard = null;
            }
            frmMenu = new ChildForm.Menu();
            frmMenu.nextForm_return += new ChildForm.Menu.FormHandle(showFormReturn);
            frmMenu.nextForm_repair += new ChildForm.Menu.FormHandle(showFormRepair);
            frmMenu.nextForm_users += new ChildForm.Menu.FormHandle(showFormUsers);
            frmMenu.nextForm_warehouse += new ChildForm.Menu.FormHandle(showFormWarehouse);
            frmMenu.nextForm_stock += new ChildForm.Menu.FormHandle(showFormStock);
            frmMenu.nextForm_pick += new ChildForm.Menu.FormHandle(showFormPick);
            frmMenu.nextForm_exit += new ChildForm.Menu.FormHandle(showFormLogin);
            frmMenu.nextForm_web += new ChildForm.Menu.FormHandle(showFormWeb);
            frmMenu.TopLevel = false;
            panel_content.Controls.Add(frmMenu);
            frmMenu.Show();
        }

        void showFormDisPick_Plan()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            frmDisPick_Plan = new ChildForm.DisPick_Plan();
            frmDisPick_Plan.TopLevel = false;
            panel_content.Controls.Add(frmDisPick_Plan);
            frmDisPick_Plan.Show();
            btnBack.Visible = true;
        }
        void showFormDisPick_UnPlan()
        {
            if (frmPick != null)
            {
                frmPick.Close();
                frmPick = null;
            }
            frmDisPick_UnPlan = new ChildForm.DisPick_UnPlan();
            frmDisPick_UnPlan.TopLevel = false;
            panel_content.Controls.Add(frmDisPick_UnPlan);
            frmDisPick_UnPlan.Show();
            btnBack.Visible = true;
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
            btnBack.Visible = true;
        }
        void showFormRepair()
        {
            MessageBox.Show("1");
            btnBack.Visible = true;
        }
        void showFormUsers()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmUserscard = new ChildForm.Userscard();
            frmUserscard.TopLevel = false;
            panel_content.Controls.Add(frmUserscard);
            frmUserscard.Show();
            btnBack.Visible = true;
        }
        void showFormWarehouse()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmWarehousing = new ChildForm.Warehousing();
            //frmWarehousing.nextForm_exit += new ChildForm.Return.FormHandle(showFormMenu);
            frmWarehousing.TopLevel = false;
            panel_content.Controls.Add(frmWarehousing);
            frmWarehousing.Show();
            btnBack.Visible = true;
        }
        void showFormStock()
        {
            MessageBox.Show("4");
            btnBack.Visible = true;
        }
        void showFormWeb()
        {
            if (frmMenu != null)
            {
                frmMenu.Close();
                frmMenu = null;
            }
            frmManageWeb = new ChildForm.ManageWeb();
            //frmManageWeb.nextForm_exit += new ChildForm.Return.FormHandle(frmManageWeb);
            frmManageWeb.TopLevel = false;
            panel_content.Controls.Add(frmManageWeb);
            frmManageWeb.Show();
            btnBack.Visible = true;
        }
        /// <summary>
        /// 回到主菜单界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            showFormMenu();
            btnBack.Visible = false;
        }
    }
}
