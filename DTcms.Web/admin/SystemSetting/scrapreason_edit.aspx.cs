using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.IO;
namespace DTcms.Web.admin.SystemSetting
{
    public partial class scrapreason_edit : Web.UI.ManagePage
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
                ChkAdminLevel("scrapreason_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
        BLL.sy_scrapreason bll = new BLL.sy_scrapreason();
        private void ShowInfo(int _id)
        {
            Model.sy_scrapreason model = bll.GetModel(_id);
            hfdID.Value = model.ID.ToString();
            txtScrapReason.Text = model.ScrapReason;

        }
        private bool IsCheck()
        {
            if (txtScrapReason.Text.Trim() == "")
            {
                MessageBox.Show(this, "报废原因不能为空！");
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.sy_scrapreason model = new DTcms.Model.sy_scrapreason();

            model.ScrapReason = txtScrapReason.Text.Trim();

            if (action == DTEnums.ActionEnum.Add.ToString())
            {
                bll.Add(model);
                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                model.ID = Convert.ToInt32(hfdID.Value);
                bll.Update(model);
                MessageBox.Show(this, "修改成功！");
            }
        }
    }
}