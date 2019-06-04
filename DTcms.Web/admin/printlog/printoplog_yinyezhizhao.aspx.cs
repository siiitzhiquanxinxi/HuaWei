using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.printlog
{
    public partial class printoplog_yinyezhizhao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
            }
        }

        private void BindDDL()
        {
            string sql = "select * from s_county where 1=1";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            ddlCounty.DataSource = dt;
            ddlCounty.DataTextField = "CountyName";
            ddlCounty.DataValueField = "CountyNum";
            ddlCounty.DataBind();

            sql = "select * from s_area where ParentId = '" + ddlCounty.SelectedItem.Value + "'";
            dt = DbHelperMySql.Query(sql).Tables[0];
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaNum";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("--全部--", "0"));
        }
        int pageSize;
        int preNum;
        private void BindData()
        {
            //string sql = "SELECT TOP " + pageSize + " * FROM u_printlog WHERE id NOT IN (SELECT TOP " + preNum + " id FROM u_printlog ORDER BY ID DESC) ORDER BY ID DESC";
            string sql = "select ID,agentName,agentIdCardNum,PrinterType,companyName,legalpersonName,CreateSessionDate,BussinessType,IsZhengbenSuccessed,IsFubenSuccessed from u_printlog where 1=1";
            string where = "";
            if (txtDate1.Text != "")
            {
                where += " and CreateSessionDate >= '" + txtDate1.Text + " 00:00:00" + "'";
            }
            if (txtDate2.Text != "")
            {
                where += " and CreateSessionDate <= '" + txtDate2.Text + " 23:59:59" + "'";
            }
            if (txtCompanyName.Text.Trim() != "")
            {
                where += " and companyName like '%" + txtCompanyName.Text + "%'";
            }
            if (txtPrinterName.Text != "")
            {
                where += " and agentName like '%" + txtPrinterName.Text + "%'";
            }
            if (ddlCounty.SelectedItem != null)
            {
                where += " and County = '" + ddlCounty.SelectedItem.Value + "'";
            }
            if (ddlArea.SelectedItem != null && ddlArea.SelectedItem.Value != "0")
            {
                where += " and Area = '" + ddlArea.SelectedItem.Text + "'";
            }
            if (ddlPoint.SelectedItem != null && ddlPoint.SelectedItem.Text != "全部点位")
            {
                where += " and Point = '" + ddlPoint.SelectedItem.Text + "'";
            }
            if (ddlBussinessType.SelectedItem != null && ddlBussinessType.SelectedItem.Text != "全部业务")
            {
                where += " and ddlBussinessType = " + ddlBussinessType.SelectedItem.Value;
            }
            sql += where;
            sql += " order by CreateSessionDate desc";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];

            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;
            AspNetPager1.RecordCount = dt.Rows.Count;

            rptList.DataSource = pds;
            rptList.DataBind();

            lblTotalCount.Visible = true;
            lblTotalCount.Text = "总数：" + dt.Rows.Count.ToString() + "条";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }


        protected void ddlCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from s_area where ParentId = '" + ddlCounty.SelectedItem.Value + "'";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            ddlArea.DataSource = dt;
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "AreaNum";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("--全部--", "0"));
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}