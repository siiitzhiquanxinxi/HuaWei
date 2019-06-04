using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.manager
{
    public partial class papermanager_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                BindData();
            }
        }

        private void BindData()
        {
            string sql = "select * from p_papermanager where 1=1";
            string where = "";
            if (ddlCounty.SelectedItem != null)
            {
                where += " and County = '" + ddlCounty.SelectedItem.Value + "'";
            }
            if (ddlArea.SelectedItem != null && ddlArea.SelectedItem.Value != "0")
            {
                where += " and Area = '" + ddlArea.SelectedItem.Text + "'";
            }
            sql += where;
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {

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
    }
}