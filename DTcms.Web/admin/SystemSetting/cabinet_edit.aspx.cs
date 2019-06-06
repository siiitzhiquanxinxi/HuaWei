using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
namespace DTcms.Web.admin.SystemSetting
{
    public partial class cabinet_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id= DTRequest.GetQueryString("id");
                if (!bll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("cabinet_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                ManagerBind();
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }
        private void ManagerBind()
        {
            BLL.manager manager = new BLL.manager();
            DataTable dt = manager.GetList(0, "1=1", "id").Tables[0];
            dt.Rows.InsertAt(dt.NewRow(), 0);
            this.ddlManager.DataSource = dt;
            this.ddlManager.DataTextField = "user_name";
            this.ddlManager.DataValueField = "telephone";
            this.ddlManager.DataBind();
        }
        BLL.sy_cabinet bll = new BLL.sy_cabinet();
        private void ShowInfo(string _id)
        {
            Model.sy_cabinet model = bll.GetModel(_id);
            txtCabinetNo.Text = model.CabinetNo;
            txtIP.Text = model.IP;
            txtPort.Text = model.Port;
            txtCardAddr.Text = model.CardAddr;
            txtLocation.Text = model.Location;
            ddlManager.SelectedItem.Text = model.Manager;
            ddlManager.SelectedValue = model.Phone;
            txtPhone.Text = model.Phone;

        }
        private bool IsCheck()
        {
            if (txtCabinetNo.Text.Trim() == "")
            {
                MessageBox.Show(this, "柜号不能为空！");
                return false;
            }
            if (action == DTEnums.ActionEnum.Add.ToString())
            {
                if (bll.Exists(this.txtCabinetNo.Text.Trim()))
                {

                    //JscriptMsg("柜号已存在", "back", "Error");
                    //txtDeliverGoodsNo.Text = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    MessageBox.Show(this, "柜号已存在！");
                    return false;
                }
            }
            if (txtIP.Text.Trim() == "")
            {
                MessageBox.Show(this, "IP不能为空！");
                return false;
            }

            if (this.txtPort.Text.Trim() == "")
            {
                MessageBox.Show(this, "端口不能为空！");
                return false;
            }

            if (this.txtCardAddr.Text.Trim() == "")
            {
                MessageBox.Show(this, "卡地址不能为空！");
                return false;
            }

            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.sy_cabinet model = new DTcms.Model.sy_cabinet();
            model.CabinetNo = txtCabinetNo.Text.Trim();
            model.IP = txtIP.Text.Trim();
            model.Port = txtPort.Text.Trim();
            model.CardAddr = txtCardAddr.Text.Trim();
            model.Location = txtLocation.Text.Trim();
            model.Manager = ddlManager.SelectedItem.Text;
            model.Phone = txtPhone.Text.Trim();
            if (action == DTEnums.ActionEnum.Add.ToString())
            {
                bll.Add(model);
                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                bll.Update(model);
                MessageBox.Show(this, "修改成功！");
            }
        }

        protected void ddlManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPhone.Text = ddlManager.SelectedValue;
        }

        protected void btnShelf_Click(object sender, EventArgs e)
        {
            Response.Redirect("shelf_edit.aspx?CabinetNo="+this.txtCabinetNo.Text.Trim());
        }
    }
}