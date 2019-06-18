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
    public partial class approve_list : Web.UI.ManagePage
    {
        BLL.w_approvelist bll = new BLL.w_approvelist();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("approve_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }
        private void RptBind()
        {
            string where = "1=1";
            if (this.txtKeywords.Text.Trim() != "")
            {
                where += " and (ApproveNum like  '%" + this.txtKeywords.Text.Trim() + "%' or CreateByName like '%" + this.txtKeywords.Text.Trim() + "%' or ApplyRemark like '%" + this.txtKeywords.Text.Trim() + "%')";
            }
            DataTable dt = bll.GetList(where).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;

            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList.DataSource = pds;
            rptList.DataBind();

            AspNetPager1.RecordCount = dt.Rows.Count;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RptBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            RptBind();
        }
    }
}