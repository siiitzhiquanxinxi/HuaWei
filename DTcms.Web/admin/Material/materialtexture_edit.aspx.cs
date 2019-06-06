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
    public partial class materialtexture_edit : Web.UI.ManagePage
    {
        private string MaterialID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MaterialID = DTRequest.GetQueryString("MaterialID");
            if (!Page.IsPostBack)
            {
                ManagerBind();
                ShowInfo(this.MaterialID);
            }
        }
        private void ManagerBind()
        {
            BLL.sy_texture mtype = new BLL.sy_texture();
            DataTable dt = mtype.GetList("1=1").Tables[0];
            dt.Rows.InsertAt(dt.NewRow(), 0);
            this.ddlTexture.DataSource = dt;
            this.ddlTexture.DataTextField = "Texture";
            this.ddlTexture.DataValueField = "ID";
            this.ddlTexture.DataBind();
        }
        BLL.sy_material_texture bll = new BLL.sy_material_texture();
        BLL.sy_material materialbll = new BLL.sy_material();
        private void ShowInfo(string _id)
        {
            this.txtMaterialID.Text = _id;
            Model.sy_material mmodel = materialbll.GetModel(_id);
            this.txtMaterialName.Text = mmodel.MaterialName;
            this.txtSpec.Text = mmodel.Spec;
            this.rptList.DataSource = bll.GetList("MaterialID='" + _id + "'").Tables[0];
            this.rptList.DataBind();

        }
        private bool IsCheck()
        {
            if (txtMaterialID.Text.Trim() == "")
            {
                MessageBox.Show(this, "刀具号不能为空！");
            }
            if (ddlTexture.SelectedItem.Text == "")
            {
                MessageBox.Show(this, "材质不能为空！");
            }
            if (this.txtCoefficient.Text.Trim() == "")
            {
                MessageBox.Show(this, "系数不能为空！");
            }
            else
            {
                try
                {
                    decimal.Parse(this.txtCoefficient.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "长不是数值型！");
                    return false;
                }
            }
            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.sy_material_texture model = new DTcms.Model.sy_material_texture();
            model.MaterialID = this.txtMaterialID.Text;
            model.Texture = ddlTexture.SelectedItem.Text;
            model.Coefficient = decimal.Parse(this.txtCoefficient.Text.Trim());
            if (hidId.Value == "")
            {
                bll.Add(model);
                MessageBox.Show(this, "添加成功！");
            }
            else
            {
                model.ID = int.Parse(hidId.Value);
                bll.Update(model);
                MessageBox.Show(this, "修改成功！");
            }
            ShowInfo(this.txtMaterialID.Text);
        }
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            bll.Delete(Convert.ToInt32(id));
            ShowInfo(this.txtMaterialID.Text);
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            Model.sy_material_texture model = bll.GetModel(int.Parse(id));
            this.hidId.Value = model.ID.ToString();
            this.txtMaterialID.Text = model.MaterialID;
            Model.sy_material mmodel = materialbll.GetModel(model.MaterialID);
            this.txtMaterialName.Text = mmodel.MaterialName;
            this.txtSpec.Text = mmodel.Spec;
            this.txtCoefficient.Text = model.Coefficient.ToString();
            this.ddlTexture.SelectedItem.Text = model.Texture;
        }
    }
}