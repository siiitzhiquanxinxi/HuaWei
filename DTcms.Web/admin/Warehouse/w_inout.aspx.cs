using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
namespace DTcms.Web.admin.Warehouse
{
    public partial class w_inout : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChkAdminLevel("w_inout", DTEnums.ActionEnum.View.ToString()); //检查权限
                BindData();

            }
        }
        private void BindData()
        {
            string sql = "SELECT a.BarCode,a.MaterialName,a.MaterialType,a.Spec,a.WorkTime*a.IOFlag as WorkTime,a.OperatorTime,a.InOutType,a.IOFlag,b.FK_CabinetNo,b.BoxNo,b.x+(b.y-1)*8 as XY from w_inout_detail a join sy_shelf b ON a.FK_ShelfID=b.ID ";
            if (txtBarCode.Text.Trim() != "")
            {
                sql += " and a.BarCode like '%" + txtBarCode.Text.Trim() + "%'";
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
            if (ddlInOutType.SelectedValue != "")
            {
                sql += " and a.InOutType = '" + ddlInOutType.SelectedValue + "'";
            }
            if (ddlIOFlag.SelectedValue != "")
            {
                sql += " and a.IOFlag = '" + ddlIOFlag.SelectedValue + "'";
            }
            if (txtSDate.Text.Trim() != ""&& txtEDate.Text.Trim() != "")
            {
                sql += " and a.OperatorTime BETWEEN '" + txtSDate.Text.Trim() + "' and '" + txtEDate.Text.Trim() + "'";
            }
            sql += " order by a.OperatorTime desc";
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