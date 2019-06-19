using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.IO;
namespace DTcms.Web.admin.Material
{
    public partial class material_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryString("id");
                if (!bll.Exists(id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("material_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                ManagerBind();
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                if (action == DTEnums.ActionEnum.Add.ToString()) //新增
                {
                    //string sql = "select * from sy_material order by MaterialID desc";
                    DataTable dt = bll.GetList("1=1 order by MaterialID desc").Tables[0];
                    if(dt.Rows.Count==0)
                    {
                        this.txtMaterialID.Text = "000001";
                    }
                    else
                    {
                        int i = dt.Rows.Count;
                        if (i <= 999999)
                        {
                            if (i < 10)
                            {
                                this.txtMaterialID.Text ="00000" + Convert.ToString(i);
                            }
                            else if (i >= 10 && i < 100)
                            {
                                this.txtMaterialID.Text = "0000" + Convert.ToString(i);
                            }
                            else if (i >= 100 && i < 1000)
                            {
                                this.txtMaterialID.Text = "000" + Convert.ToString(i);
                            }
                            else if (i >= 1000 && i < 10000)
                            {
                                this.txtMaterialID.Text = "00" + Convert.ToString(i);
                            }
                            else if (i >= 10000 && i < 100000)
                            {
                                this.txtMaterialID.Text = "0" + Convert.ToString(i);
                            }
                            else
                            {
                                this.txtMaterialID.Text =  Convert.ToString(i);
                            }
                        }
                    }
                }
            }
        }

        private void ManagerBind()
        {
            BLL.sy_materialtype mtype = new BLL.sy_materialtype();
            DataTable dt = mtype.GetList("1=1").Tables[0];
            dt.Rows.InsertAt(dt.NewRow(), 0);
            this.ddlMaterialType.DataSource = dt;
            this.ddlMaterialType.DataTextField = "MaterialTypeName";
            this.ddlMaterialType.DataValueField = "MaterialTypeID";
            this.ddlMaterialType.DataBind();
        }
        BLL.sy_material bll = new BLL.sy_material();
        byte[] pic = null;
        private void ShowInfo(string _id)
        {
            Model.sy_material model = bll.GetModel(_id);
            txtMaterialID.Text = model.MaterialID;
            txtCode.Text = model.Code;
            txtMaterialName.Text = model.MaterialName;
            ddlMaterialType.SelectedValue = model.MaterialTypeID;
            txtBrand.Text = model.Brand;
            txtSpec.Text = model.Spec;
            txtDeep.Text = model.Deep.ToString();
            txtHigh.Text = model.High.ToString();
            txtUnit.Text = model.Unit;
            txtSupplier.Text = model.Supplier;
            txtRemark.Text = model.Remark;
            txtMinimum.Text = model.Minimum.ToString();
            txtTotalTime.Text = model.TotalTime.ToString();
            if (model.State == 0)
                RadioButton1.Checked = true;
            else
                RadioButton2.Checked = true;
            if (model.IsCanRepair == 0)
                RadioButton4.Checked = true;
            else
                RadioButton3.Checked = true;
            pic = model.Pic;
            if(pic!=null)
            imgbeginPic.ImageUrl="photo.ashx?ID="+ model.MaterialID;
            ddlAppearance.SelectedValue = model.Appearance.ToString();
        }
        //参数是图片的路径
        public byte[] GetPictureData(string imagePath)
        {
            FileStream fs = new FileStream(Server.MapPath("../../")+imagePath, FileMode.Open);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }
        private bool IsCheck()
        {
            if (txtMaterialID.Text.Trim() == "")
            {
                MessageBox.Show(this, "刀具号不能为空！");
                return false;
            }
            if (action == DTEnums.ActionEnum.Add.ToString())
            {
                if (bll.Exists(this.txtMaterialID.Text.Trim()))
                {
                    MessageBox.Show(this, "刀具号已存在！");
                    return false;
                }
            }
            if (txtMaterialName.Text.Trim() == "")
            {
                MessageBox.Show(this, "刀具名称不能为空！");
                return false;
            }
            if (this.txtDeep.Text.Trim() == "")
            {
                MessageBox.Show(this, "长度不能为空！");
                return false;
            }
            else
            {
                try
                {
                    decimal.Parse(this.txtDeep.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "长不是数值型！");
                    return false;
                }
            }
            if (this.txtHigh.Text.Trim() == "")
            {
                MessageBox.Show(this, "直径不能为空！");
                return false;
            }
            else
            {
                try
                {
                    decimal.Parse(this.txtHigh.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "直径不是数值型！");
                    return false;
                }
            }
            if (this.txtTotalTime.Text.Trim() == "")
            {
                MessageBox.Show(this, "新刀初始加工寿命不能为空！");
                return false;
            }
            else
            {
                try
                {
                    decimal.Parse(this.txtTotalTime.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "新刀初始加工寿命不是数值型！");
                    return false;
                }
            }
            if (this.txtMinimum.Text.Trim() == "")
            {
                this.txtMinimum.Text = "0";
            }
            else
            {
                try
                {
                    decimal.Parse(this.txtMinimum.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "最低库存量不是数值型！");
                    return false;
                }
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.sy_material model = new DTcms.Model.sy_material();
            model.MaterialID = txtMaterialID.Text.Trim();
            model.Code = txtCode.Text.Trim();
            model.MaterialName = txtMaterialName.Text.Trim();
            model.MaterialTypeID = ddlMaterialType.SelectedValue;
            model.MaterialType = ddlMaterialType.SelectedItem.Text;
            model.Brand = txtBrand.Text.Trim();
            model.Spec = txtSpec.Text.Trim();
            model.Deep = Convert.ToDecimal(txtDeep.Text.Trim());
            model.High = Convert.ToDecimal(txtHigh.Text.Trim());
            model.Unit = txtUnit.Text.Trim();
            model.Supplier = txtSupplier.Text.Trim();
            model.Remark = txtRemark.Text.Trim();
            model.Minimum = Convert.ToDecimal(txtMinimum.Text.Trim());
            model.TotalTime = Convert.ToInt32(txtTotalTime.Text.Trim());
            model.Appearance = Convert.ToInt32(ddlAppearance.SelectedValue);
            if (RadioButton1.Checked)
                model.State = 0;
            else
                model.State = 1;
            if (RadioButton4.Checked)
                model.IsCanRepair = 0;
            else
                model.IsCanRepair = 1;
            model.Supplier = txtSupplier.Text.Trim();
            if (this.txtImgUrl.Text.Trim() != "")
                model.Pic = GetPictureData(this.txtImgUrl.Text.Trim());
            else
                model.Pic = pic;
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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (txtImgUrl.Text.Trim() != "")
            {
                this.imgbeginPic.ImageUrl = txtImgUrl.Text.Trim();
            }
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            if(txtMaterialID.Text.Trim()!="")
            Response.Redirect("materialtexture_edit.aspx?MaterialID=" + this.txtMaterialID.Text.Trim());
        }
    }
}