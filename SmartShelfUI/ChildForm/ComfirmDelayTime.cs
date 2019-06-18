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
    public partial class ComfirmDelayTime : Form
    {
        public ComfirmDelayTime()
        {
            InitializeComponent();
        }
        public int PlanID;
        DTcms.Model.temp_planorderlist plan = new DTcms.Model.temp_planorderlist();
        private void ComfirmDelayTime_Load(object sender, EventArgs e)
        {
            plan = new DTcms.BLL.temp_planorderlist().GetModel(PlanID);
            if (plan != null)
            {
                lblPalnWorkPlan.Text = Convert.ToDateTime(plan.PlanWorkTime).ToString("yyyy年MM月dd日 HH:mm");
                lblNowTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm");
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDelayTime.Text.Trim() == "")
            {
                MessageBox.Show("请输入时间！");
                return;
            }
            else if (!IsNumber(txtDelayTime.Text.Trim()))
            {
                MessageBox.Show("请输入正确的时间！");
                return;
            }
            else
            {
                DateTime plantime = Convert.ToDateTime(plan.PlanWorkTime);
                DateTime delaytime = plantime.AddMinutes(int.Parse(txtDelayTime.Text.Trim()) * -1);
                plan.DelayWorkTime = delaytime;
                plan.OrderReadyState = 0;
                new DTcms.BLL.temp_planorderlist().Update(plan);
                List<DTcms.Model.temp_camlist> lstcam = new DTcms.BLL.temp_camlist().GetModelList("PartNum = '" + plan.PartNum + "'");
                foreach (DTcms.Model.temp_camlist item in lstcam)
                {
                    item.ToolReadyState = 0;
                    item.ToolBarCode = "";
                    new DTcms.BLL.temp_camlist().Update(item);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }
    }
}
