using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.IO;
namespace DTcms.Web.admin.Warehouse
{
    public partial class approve_check : Web.UI.ManagePage
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
                ChkAdminLevel("approve_chek_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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

        }
        private bool IsCheck()
        {
            if (txtApproveNewToolBarCode.Text.Trim() == "")
            {
                MessageBox.Show(this, "新条码不能为空！");
                return false;
            }
            return true;
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            if (Session[DTKeys.SESSION_ADMIN_INFO] != null)
            {
                Model.manager manager = (Model.manager)Session[DTKeys.SESSION_ADMIN_INFO];
                Model.w_approvelist model = bll.GetModel(ApproveNum);
                model.ApproveState = 1;
                model.ApproveById = manager.id;
                model.ApproveByName = manager.real_name;
                model.ApproveDate = DateTime.Now;
                model.ApproveNewToolBarCode = txtApproveNewToolBarCode.Text.Trim();
                model.ApproveRemark = txtApproveRemark.Text;
                bll.Update(model);
                MessageBox.Show(this, "保存成功！");
                Response.Redirect("approve_chek_list.aspx");
            }
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            if (Session[DTKeys.SESSION_ADMIN_INFO] != null)
            {
                Model.manager manager = (Model.manager)Session[DTKeys.SESSION_ADMIN_INFO];
                Model.w_approvelist model = bll.GetModel(ApproveNum);
                model.ApproveState = -1;
                model.ApproveById = manager.id;
                model.ApproveByName = manager.real_name;
                model.ApproveDate = DateTime.Now;
                model.ApproveRemark = txtApproveRemark.Text;
                bll.Update(model);
                MessageBox.Show(this, "保存成功！");
                Response.Redirect("approve_chek_list.aspx");
            }
        }
    }
}