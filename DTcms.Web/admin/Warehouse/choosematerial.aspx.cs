﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace DTcms.Web.admin.Warehouse
{
    public partial class choosematerial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            string sql = "state=0";
            if (txtKeywords.Text.Trim() != "")
            {
                 sql += " and MaterialName like '%" + txtKeywords.Text.Trim() + "%'";
            }
            DTcms.BLL.sy_material bll = new DTcms.BLL.sy_material();
            DataTable dt = bll.GetList(sql).Tables[0];

            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;

            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList.DataSource = pds;
            rptList.DataBind();

            AspNetPager1.RecordCount = dt.Rows.Count;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string txt = "";
            foreach (RepeaterItem item in rptList.Items)
            {
                //CheckBox ckbid = item.FindControl("chkId") as CheckBox;
                HtmlInputRadioButton ckbid = item.FindControl("Radio1") as HtmlInputRadioButton;
                if (ckbid.Checked)
                {
                    HiddenField hfdname = item.FindControl("hfdMaterialID") as HiddenField;
                    txt = hfdname.Value;

                }
            }
            string sql = "MaterialID='" + txt + "'";
            DTcms.BLL.sy_material bll = new DTcms.BLL.sy_material();
            DataTable dt = bll.GetList(sql).Tables[0];
            if (dt.Rows.Count > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "ok('" + dt.Rows[0]["MaterialName"].ToString() + "','" + dt.Rows[0]["MaterialType"].ToString() + "','" + dt.Rows[0]["MaterialTypeID"].ToString() + "','" + dt.Rows[0]["Brand"].ToString() + "','" + dt.Rows[0]["Spec"].ToString() + "','" + dt.Rows[0]["Deep"].ToString() + "','" + dt.Rows[0]["High"].ToString() + "','" + dt.Rows[0]["Unit"].ToString() + "','" + dt.Rows[0]["TotalTime"].ToString() + "','" + dt.Rows[0]["Code"].ToString() + "','" + dt.Rows[0]["MaterialID"].ToString() + "')", true);
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}