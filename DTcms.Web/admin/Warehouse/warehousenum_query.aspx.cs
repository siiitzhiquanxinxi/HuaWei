using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace DTcms.Web.admin.Warehouse
{
    public partial class warehousenum_query : System.Web.UI.Page
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
            BLL.w_barcode bll = new BLL.w_barcode();
            string sql = "SELECT a.*,a.x+(a.y-1)*8 as XY,b.FK_CabinetNo,b.BoxNo from w_barcode a,sy_shelf b where a.FK_ShelfID=b.ID";
            if (txtMaterialID.Text.Trim() != "")
            {
                sql += " and a.MaterialID like '%" + txtMaterialID.Text.Trim() + "%'";
            }
            if (txtMaterialName.Text.Trim() != "")
            {
                sql += " and a.MaterialName like '%" + txtMaterialName.Text.Trim() + "%'";
            }
            if (txtCabinetNo.Text.Trim() != "")
            {
                sql += " and b.FK_CabinetNo like '%" + txtCabinetNo.Text.Trim() + "%'";
            }
            if (txtBoxNo.Text.Trim() != "")
            {
                sql += " and b.BoxNo like '%" + txtBoxNo.Text.Trim() + "%'";
            }
            if (ddlToolLevel.SelectedValue != "")
            {
                sql += " and a.ToolLevel like '%" + ddlToolLevel.SelectedValue + "%'";
            }
            if (ddlState.SelectedValue != "")
            {
                sql += " and a.State like '%" + ddlState.SelectedValue + "%'";
            }
            sql += " order by b.FK_CabinetNo,b.BoxNo,XY";
            DataTable dt = DbHelperMySql.Query(sql).Tables[0];
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;

            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.DataSource = dt.DefaultView;

            rptList1.DataSource = pds;
            rptList1.DataBind();

            AspNetPager1.RecordCount = dt.Rows.Count;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }


    }
}