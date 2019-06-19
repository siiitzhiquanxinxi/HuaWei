using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
namespace DTcms.Web.admin.Warehouse
{
    public partial class approve_view : Web.UI.ManagePage
    {
        string ApproveNum = "";
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.ApproveNum = DTRequest.GetQueryString("ApproveNum");
                if (!bll.Exists(ApproveNum))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("approve_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.ApproveNum);
                }
            }
        }
        BLL.w_approvelist bll = new BLL.w_approvelist();
        private void ShowInfo(string _id)
        {
            Model.w_approvelist model = bll.GetModel(_id);
            txtApproveNum.Text = model.ApproveNum;
            txtCreateDate.Text = model.CreateDate.ToString();
            txtCreateByName.Text = model.CreateByName;
            hfdCreateById.Value = model.CreateById.ToString();
            txtApplyPartNum.Text = model.ApplyPartNum;
            txtTexture.Text = model.Texture;
            txtApplyToolName.Text = model.ApplyToolName;
            txtApplyWorkTime.Text = model.ApplyWorkTime.ToString();
            txtApplyToolLevel.Text = model.ApplyToolLevel;
            txtApplyOldToolBarCode.Text = model.ApplyOldToolBarCode;
            txtApplyRemark.Text = model.ApplyRemark;
            txtTexture.Text = model.Texture;
            txtApproveByName.Text = model.ApproveByName;
            txtApproveDate.Text = model.ApproveDate.ToString();
            txtApproveNewToolBarCode.Text = model.ApproveNewToolBarCode;
        }
    }
}