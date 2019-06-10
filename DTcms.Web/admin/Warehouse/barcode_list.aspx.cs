using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.Text;

namespace DTcms.Web.admin.Warehouse
{
    public partial class barcode_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("barcode_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        private void RptBind()
        {
            BLL.w_barcode bll = new BLL.w_barcode();
            this.rptList.DataSource = bll.GetList("state=0");
            this.rptList.DataBind();
        }
    }
}