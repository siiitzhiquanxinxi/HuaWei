using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
namespace DTcms.Web.admin.Warehouse
{
    public partial class approve_chek_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("approve_chek_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }
        BLL.w_approvelist bll = new BLL.w_approvelist();
        private void RptBind()
        {
            string where = "ApproveState=0";
            if(this.txtKeywords.Text.Trim()!="")
            {
                where += " and (ApproveNum like  '%" + this.txtKeywords.Text.Trim() + "%' or CreateByName like '%" + this.txtKeywords.Text.Trim() + "%' or ApplyRemark like '%" + this.txtKeywords.Text.Trim() + "%')";
            }
            this.rptList.DataSource = bll.GetList(where).Tables[0];
            this.rptList.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RptBind();
        }
        
    }
}