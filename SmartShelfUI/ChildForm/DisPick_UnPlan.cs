using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class DisPick_UnPlan : Form
    {
        public DisPick_UnPlan()
        {
            InitializeComponent();
        }

        private void DisPick_UnPlan_Load(object sender, EventArgs e)
        {
            GetApproveList();
        }
        private void GetApproveList()
        {
            dgv_ApproveList.DataSource = null;
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (txtToolName.Text.Trim() == "")
            {
                MessageBox.Show("请输入刀具名称！");
                return;
            }
            if (txtWorkTime.Text.Trim() == "")
            {
                MessageBox.Show("请输入加工时间！");
                return;
            }
            if (!IsNumber(txtWorkTime.Text))
            {
                MessageBox.Show("加工时间请输入数字！");
                return;
            }
            string toolLevel = "F";
            if (cbxToolLevel.Text == "")
            {
                MessageBox.Show("请选择刀具等级！");
                return;
            }
            else
            {
                if (cbxToolLevel.Text == "旧刀（F）")
                {
                    toolLevel = "F";
                }
                else if (cbxToolLevel.Text == "新刀（X）")
                {
                    toolLevel = "X";
                }
                else if (cbxToolLevel.Text == "返磨（R）")
                {
                    toolLevel = "R";
                }
            }
            DTcms.Model.w_approvelist approve = new DTcms.Model.w_approvelist();
            approve.ApproveNum = DateTime.Now.ToString("yyyyMMddHHmmss" + globalField.Manager.id.ToString());
            approve.CreateDate = DateTime.Now;
            approve.CreateById = globalField.Manager.id;
            approve.CreateByName = globalField.Manager.real_name;
            approve.ApplyRemark = txtApplyRemark.Text;
            approve.IsPlanApprove = 0;
            approve.ApproveState = 0;
            approve.ApplyPartNum = "";
            approve.ApplyToolName = txtToolName.Text;
            approve.ApplyWorkTime = int.Parse(txtWorkTime.Text);
            approve.ApplyToolLevel = toolLevel;
            approve.ApplyOldToolBarCode = "";
            approve.ApproveById = null;
            approve.ApproveByName = null;
            approve.ApproveDate = null;
            approve.ApproveNewToolBarCode = null;
            approve.ApproveRemark = null;
            if (new DTcms.BLL.w_approvelist().Add(approve))
            {
                MessageBox.Show("申请成功！");
                txtApplyRemark.Text = txtToolName.Text = txtWorkTime.Text = cbxToolLevel.Text = "";
            }
            else
            {
                MessageBox.Show("申请失败！");
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetApproveList();
        }


        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }
    }
}
