using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
namespace DTcms.Web.admin.Material
{
    public partial class materialType_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = Convert.ToInt32(DTRequest.GetQueryString("id"));
                if (!bll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("materialType_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
        BLL.sy_materialtype bll = new BLL.sy_materialtype();
        private void ShowInfo(int _id)
        {
            Model.sy_materialtype model = bll.GetModel(_id);
            hfdID.Value = model.MaterialTypeID.ToString();
            txtMaterialTypeName.Text = model.MaterialTypeName;
            txtCode.Text = model.Code;

        }
        private bool IsCheck()
        {
            if (txtMaterialTypeName.Text.Trim() == "")
            {
                MessageBox.Show(this, "刀具分类不能为空！");
                return false;
            }
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show(this, "分类编码不能为空！");
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.sy_materialtype model = new DTcms.Model.sy_materialtype();

            model.MaterialTypeName = txtMaterialTypeName.Text.Trim();
            model.Code = txtCode.Text.Trim();

            if (action == DTEnums.ActionEnum.Add.ToString())
            {
                bll.Add(model);
                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                model.MaterialTypeID = Convert.ToInt32(hfdID.Value);
                bll.Update(model);
                MessageBox.Show(this, "修改成功！");
            }
        }
    }
}