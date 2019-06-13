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
    public partial class Userscard : Form
    {
        public Userscard()
        {
            InitializeComponent();
        }

        private void spCom_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(300);
            byte[] result = new byte[8];
            int rLength = spCom.Read(result, 0, result.Length);
            if (rLength == 8)
            {
                string re = result[0].ToString("x2") + result[1].ToString("x2") + result[2].ToString("x2") + result[3].ToString("x2") + result[4].ToString("x2") + result[5].ToString("x2") + result[6].ToString("x2") + result[7].ToString("x2");

                if (dgvUserList.SelectedRows != null && dgvUserList.SelectedRows.Count > 0)
                {
                    string sql = "update dt_manager set email = '" + re + "' where id = " + dgvUserList.SelectedRows[0].Cells[0].Value.ToString();
                    if (DbHelperMySql.ExecuteSql(sql) > 0)
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("绑卡成功！");
                        });
                    }
                    else
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("绑卡失败！");
                        });
                    }
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("请选择要绑卡的用户！");
                    });
                }
            }
        }

        private void Userscard_Load(object sender, EventArgs e)
        {
            try
            {
                string comName = ConfigurationManager.AppSettings["rfidcom"].Trim();
                spCom.PortName = comName;
                if (!spCom.IsOpen)
                {
                    spCom.Open();
                }
            }
            catch (Exception ex)
            {
                Utils.WriteError("打开rfid的COM口", ex.ToString());
                MessageBox.Show("串口打开失败：" + ex.ToString());
            }
            GetUserList();
        }

        private void GetUserList()
        {
            string sql = "select id,user_name,real_name from dt_manager where is_lock = 0";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            dgvUserList.DataSource = dt;
        }
    }
}
