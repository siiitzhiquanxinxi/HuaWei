using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI.ChildForm
{
    public partial class DisPick_Plan : Form
    {
        public DisPick_Plan()
        {
            InitializeComponent();
        }

        private void DisPick_Plan_Load(object sender, EventArgs e)
        {
            GetApproveList();
        }

        private void GetApproveList()
        {
            dgv_ApproveList.DataSource = null;
            string sql = "select * from w_approvelist where (ApproveState = 0 or ApproveState = 1) and IsPlanApprove = 1 order by ApproveState desc,CreateDate desc";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgv_ApproveList.SelectedRows != null && dgv_ApproveList.SelectedRows.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("请选择在申请列表中选择申请刀具！");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvCamList.SelectedRows != null && dgvCamList.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确认申请：%%%？", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                }
            }
            else
            {
                MessageBox.Show("请在CAM清单中选择您需要的刀具！");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetApproveList();
        }
    }
}
