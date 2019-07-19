using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using DTcms.Common;
namespace DTcms.Web.admin.Warehouse
{
    public partial class choosebarcode : System.Web.UI.Page
    {
        string MaterialName = "";
        string ApplyWorkTime = "";
        string ApplyToolLevel = "";
        string Texture = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //MaterialName = DTRequest.GetQueryString("MaterialName");
            ApplyWorkTime = DTRequest.GetQueryString("ApplyWorkTime");
            ApplyToolLevel = DTRequest.GetQueryString("ApplyToolLevel");
            Texture = DTRequest.GetQueryString("Texture");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            //DTcms.BLL.w_barcode bll = new DTcms.BLL.w_barcode();
            //DTcms.BLL.sy_material_texture tbll = new BLL.sy_material_texture();
            string sql = "";
            if(ApplyToolLevel.Trim()=="")
                sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and b.Texture='" + Texture + "' and a.RemainTime*b.Coefficient>=" + ApplyWorkTime;
            //sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1  and a.RemainTime*b.Coefficient>=" + ApplyWorkTime;
            else if(ApplyToolLevel.Trim()=="F")
                sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and b.Texture='" + Texture + "' and (a.ToolLevel='F' or a.ToolLevel='X') and a.RemainTime*b.Coefficient>=" + ApplyWorkTime;
            else
            {
                sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and b.Texture='" + Texture + "' and a.ToolLevel='" + ApplyToolLevel + "' and a.RemainTime*b.Coefficient>=" + ApplyWorkTime;
            }
            //sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1  and a.ToolLevel='" + ApplyToolLevel + "' and a.RemainTime*b.Coefficient>=" + ApplyWorkTime;
            if (txtKeywords.Text.Trim() != "")
            {
                 sql += " and MaterialName like '%" + txtKeywords.Text.Trim() + "%'";
            }
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
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
                HtmlInputRadioButton ckbid = item.FindControl("Radio1") as HtmlInputRadioButton;
                if (ckbid.Checked)
                {
                    HiddenField hfdname = item.FindControl("hfdMaterialID") as HiddenField;
                    txt = hfdname.Value;

                }
            }
            string sql = "BarCode='" + txt + "'";
            DTcms.BLL.w_barcode bll = new DTcms.BLL.w_barcode();
            DataTable dt = bll.GetList(sql).Tables[0];
            if (dt.Rows.Count > 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "1", "ok('" + dt.Rows[0]["BarCode"].ToString() + "')", true);
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            //if (txtKeywords.Text.Trim() != "")
            //{
            //    DTcms.BLL.w_barcode bll = new DTcms.BLL.w_barcode();
            //    string sql = " MaterialName like '%" + txtKeywords.Text.Trim() + "%'";
            //    DataTable dt = bll.GetList(sql).Tables[0];
            //    rptList.DataSource = dt;
            //    rptList.DataBind();
            //}
            BindData();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}