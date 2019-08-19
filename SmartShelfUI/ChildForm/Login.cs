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

namespace SmartShelfUI.ChildForm
{
    public partial class Login : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams paras = base.CreateParams;
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }
        string comName = ConfigurationManager.AppSettings["rfidcom"].Trim();
        public Login()
        {
            InitializeComponent();
        }

        public delegate void FormHandle();
        public event FormHandle nextForm;
        public event FormHandle sendRefresh;

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
                MessageBox.Show("串口打开失败：" + ex.ToString());
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                MessageBox.Show("请输入用户名或密码");
                return;
            }
            string salt = new DTcms.DAL.manager("dt_").GetSalt(userName);
            if (string.IsNullOrEmpty(salt))
            {
                MessageBox.Show("用户名错误");
                return;
            }
            userPwd = DTcms.Common.DESEncrypt.Encrypt(userPwd, salt);
            DTcms.Model.manager model = new DTcms.DAL.manager("dt_").GetModel(userName, userPwd);
            if (model == null)
            {
                MessageBox.Show("用户名或密码有误，请重试！");
                return;
            }
            globalField.Manager = model;
            globalField.BillID = DateTime.Now.ToString("yyyyMMddHHmmssfff" + model.id.ToString());
            DTcms.Model.w_inout_operate operate = new DTcms.Model.w_inout_operate();
            operate.BillID = globalField.BillID;
            operate.BillDate = DateTime.Now;
            operate.FK_Operator = model.id;
            operate.OperatorName = model.real_name;
            operate.Remark = "";
            new DTcms.BLL.w_inout_operate().Add(operate);


            nextForm();

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(300);
            byte[] result = new byte[8];
            int rLength = serialPort1.Read(result, 0, result.Length);
            if (rLength == 8)
            {
                string re = result[0].ToString("x2") + result[1].ToString("x2") + result[2].ToString("x2") + result[3].ToString("x2") + result[4].ToString("x2") + result[5].ToString("x2") + result[6].ToString("x2") + result[7].ToString("x2");
                DataTable dt = new DTcms.DAL.manager("dt_").GetList(1, "email='" + re + "'", "id").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    int id = Convert.ToInt16(dt.Rows[0]["id"]);
                    globalField.Manager = new DTcms.DAL.manager("dt_").GetModel(id);
                    globalField.BillID = DateTime.Now.ToString("yyyyMMddHHmmssfff" + id.ToString());
                    DTcms.Model.w_inout_operate operate = new DTcms.Model.w_inout_operate();
                    operate.BillID = globalField.BillID;
                    operate.BillDate = DateTime.Now;
                    operate.FK_Operator = id;
                    operate.OperatorName = globalField.Manager.real_name;
                    operate.Remark = "";
                    new DTcms.BLL.w_inout_operate().Add(operate);
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

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void btnRefreshLock_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认重置锁控板？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                sendRefresh();
            }
        }
    }
}
