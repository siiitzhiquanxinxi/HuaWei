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
    public partial class w_inout_operate : Web.UI.ManagePage
    {
        BLL.w_inout_operate bll = new BLL.w_inout_operate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("w_inout_operate", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }
        private void RptBind()
        {
            string where = "1=1";
            if (this.txtKeywords.Text.Trim() != "")
            {
                where += " and (BillID like  '%" + this.txtKeywords.Text.Trim() + "%' or OperatorName like '%" + this.txtKeywords.Text.Trim() + "%' or Remark like '%" + this.txtKeywords.Text.Trim() + "%')";
            }
            where += " order by BillDate desc";
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