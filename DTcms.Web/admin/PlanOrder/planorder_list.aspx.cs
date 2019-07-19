using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
namespace DTcms.Web.admin.PlanOrder
{
    public partial class planorder_list : Web.UI.ManagePage
    {
        BLL.temp_planorderlist bll = new BLL.temp_planorderlist();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("planorder_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }
        private void RptBind()
        {
            string where = "1=1";
            //if (this.txtKeywords.Text.Trim() != "")
            //{
            //    where += " and (PartNum like  '%" + this.txtKeywords.Text.Trim() + "%' or PartName like '%" + this.txtKeywords.Text.Trim() + "%' or MaterialTexture like '%" + this.txtKeywords.Text.Trim() + "%' or MachineLathe like '%" + this.txtKeywords.Text.Trim() + "%')";
            //}
            if (this.txtPartNum.Text.Trim() != "")
            {
                where += " and PartNum like '"+ this.txtPartNum.Text.Trim() + "%'";
            }
            if (txtSDate.Text.Trim() != "" && txtEDate.Text.Trim() != "")
            {
                where += " and PlanWorkTime BETWEEN '" + txtSDate.Text.Trim() + "' and '" + txtEDate.Text.Trim() + "'";
            }
            if (ddlState.SelectedValue != "")
            {
                where += " and OrderReadyState = '" + ddlState.SelectedValue + "'";
            }
            if (ddlCAM.SelectedValue == "0")
            {
                where += " and id not in (SELECT fk_id from temp_camlist)";
            }
            else if (ddlCAM.SelectedValue == "1")
            {
                where += " and id in (SELECT fk_id from temp_camlist)";
            }
            else
            {

            }
            where += " order by PlanWorkTime desc";
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