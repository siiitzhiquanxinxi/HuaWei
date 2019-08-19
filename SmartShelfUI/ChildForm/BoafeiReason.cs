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
    public partial class BoafeiReason : Form
    {
        public BoafeiReason()
        {
            InitializeComponent();
        }
        public BoafeiReason(ref string reason)
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbxReason.Text == "--请选择--" || cbxReason.Text.Trim() == "")
            {
                MessageBox.Show("请选择报废原因！");
                return;
            }
            else
            {
                Return frmReturn = (Return)this.Owner;
                frmReturn.baofeiReason = cbxReason.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BoafeiReason_Load(object sender, EventArgs e)
        {
            string sql = "select ScrapReason from sy_scrapreason where 1=1";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            cbxReason.DataSource = dt;
            cbxReason.DisplayMember = "ScrapReason";
            //cbxReason.Items.Insert(-1, "--请选择--");
        }
    }
}
