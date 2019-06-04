using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DTcms.Web.admin.manager
{
    public partial class papermanager_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDDL();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    GetData();
                }
            }
        }

        private void GetData()
        {
            string sql = "select * from p_papermanager where Id = " + Request.QueryString["id"];
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlCounty.SelectedValue = dt.Rows[0]["County"].ToString();
                ddlArea.SelectedValue = dt.Rows[0]["Area"].ToString();
                txtName.Text = dt.Rows[0]["ManagerName"].ToString();
                txtIDCatd.Text = dt.Rows[0]["ManagerIDCard"].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string sql = "update p_papermanager set ManagerName = '" + txtName.Text + "',ManagerIDCard = '" + txtIDCatd.Text + "',County = '" + ddlCounty.SelectedValue + "',Area = '" + ddlArea.SelectedValue + "' where Id = " + Request.QueryString["id"];
                DbHelperMySql.ExecuteSql(sql);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('修改成功！');window.location.href='papermanager_list.aspx';", true);
            }
            else
            {
                string sql = "insert into p_papermanager (ManagerName,ManagerIDCard,County,Area) values('" + txtName.Text + "','" + txtIDCatd.Text + "','" + ddlCounty.SelectedValue + "','" + ddlArea.SelectedValue + "')";
                DbHelperMySql.ExecuteSql(sql);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "alert('添加成功！');window.location.href='papermanager_list.aspx';", true);
            }
        }
    }
}