using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DTcms.Web.admin.printlog
{
    public partial class errorloglist : System.Web.UI.Page
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
        private void BindData()
        {
            string sql = "select * from log_errlog where 1 = 1";
            string where = "";
            if (txtDate1.Text != "")
            {
                where += " and ErrTime >= '" + txtDate1.Text + " 00:00:00" + "'";
            }
            if (txtDate2.Text != "")
            {
                where += " and ErrTime <= '" + txtDate2.Text + " 23:59:59" + "'";
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
            if (txtMachineId.Text.Trim() != "")
            {
                where += " and MachineID = '" + txtMachineId.Text + "'";
            }
            if (txtSessionId.Text.Trim() != "")
            {
                where += " and SessionID = '" + txtSessionId.Text + "'";
            }
            sql += where;
            sql += " order by ErrTime desc";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];

            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;
            AspNetPager1.RecordCount = dt.Rows.Count;

            rptList.DataSource = pds;
            rptList.DataBind();

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