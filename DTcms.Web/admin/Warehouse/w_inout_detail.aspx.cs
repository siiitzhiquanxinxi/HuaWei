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
    public partial class w_inout_detail : Web.UI.ManagePage
    {
        BLL.w_inout_detail bll = new BLL.w_inout_detail();
        string BillID = "";
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.BillID = DTRequest.GetQueryString("BillID");
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("w_inout_operate", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }
        private void RptBind()
        {
            string where = "SELECT a.*,b.FK_CabinetNo,b.BoxNo,a.x+(a.y-1)*b.x as XY from w_inout_detail a join sy_shelf b ON a.FK_ShelfID=b.ID where a.FK_BillID='" + BillID + "'";
            DataTable dt = DbHelperMySql.Query(where).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }
    }
}