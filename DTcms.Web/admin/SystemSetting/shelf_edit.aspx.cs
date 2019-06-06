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
    public partial class shelf_edit : Web.UI.ManagePage
    {
        private string CabinetNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CabinetNo = DTRequest.GetQueryString("CabinetNo");
            if (!Page.IsPostBack)
            {
                ShowInfo(this.CabinetNo);
            }
        }
        BLL.sy_shelf bll = new BLL.sy_shelf();
        private void ShowInfo(string _id)
        {
            this.txtFK_CabinetNo.Text = _id;
            this.rptList.DataSource = bll.GetList("FK_CabinetNo='" + _id + "'").Tables[0];
            this.rptList.DataBind();

        }
        private bool IsCheck()
        {
            if (txtFK_CabinetNo.Text.Trim() == "")
            {
                MessageBox.Show(this, "柜号不能为空！");
                return false;
            }

            if (txtBoxNo.Text.Trim() == "")
            {
                MessageBox.Show(this, "柜门编号不能为空！");
                return false;
            }

            if (this.txtBoxAddr.Text.Trim() == "")
            {
                MessageBox.Show(this, "对应锁地址不能为空！");
                return false;
            }
            if(this.txtDeep.Text.Trim()=="")
            {
                this.txtDeep.Text = "0";
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
                this.txtHigh.Text = "0";
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
            if (this.txtX.Text.Trim() == "")
            {
                this.txtX.Text = "0";
            }
            else
            {
                try
                {
                    int.Parse(this.txtX.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "横向九宫格数量不是数值型！");
                    return false;
                }
            }
            if (this.txtY.Text.Trim() == "")
            {
                this.txtY.Text = "0";
            }
            else
            {
                try
                {
                    int.Parse(this.txtY.Text.Trim());
                }
                catch
                {
                    MessageBox.Show(this, "纵向九宫格数量不是数值型！");
                    return false;
                }
            }
            return true;
        }
    
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsCheck()) return;
            DTcms.Model.sy_shelf model = new DTcms.Model.sy_shelf();
            model.FK_CabinetNo = this.txtFK_CabinetNo.Text;
            model.BoxNo = this.txtBoxNo.Text.Trim();
            model.BoxAddr = this.txtBoxAddr.Text.Trim();
            model.Deep = decimal.Parse(this.txtDeep.Text.Trim());
            model.High = decimal.Parse(this.txtHigh.Text.Trim()); ;
            model.X = int.Parse(this.txtX.Text.Trim());
            model.Y = int.Parse(this.txtY.Text.Trim());
            model.Type = int.Parse(ddlType.SelectedValue);
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
            ShowInfo(this.txtFK_CabinetNo.Text);
        }
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            bll.Delete(Convert.ToInt32(id));
            ShowInfo(this.txtFK_CabinetNo.Text);
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            Model.sy_shelf model= bll.GetModel(int.Parse(id));
            this.hidId.Value = model.ID.ToString();
            this.txtFK_CabinetNo.Text = model.FK_CabinetNo;
            this.txtBoxNo.Text = model.BoxNo;
            this.txtBoxAddr.Text = model.BoxAddr;
            this.txtDeep.Text = model.Deep.ToString();
            this.txtHigh.Text = model.High.ToString();
            this.txtX.Text = model.X.ToString();
            this.txtY.Text = model.Y.ToString();
            this.ddlType.SelectedValue = model.Type.ToString();
        }
        ///// <summary>
        ///// 批量删除
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    int sucCount = 0;
        //    int errorCount = 0;

        //    for (int i = 0; i < rptList.Items.Count; i++)
        //    {
        //        string ID = ((HiddenField)rptList.Items[i].FindControl("hidId")).Value;
        //        CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
        //        if (cb.Checked)
        //        {
        //            if (bll.Delete(Convert.ToInt32(ID)))
        //            {
        //                sucCount += 1;
        //            }
        //            else
        //            {
        //                errorCount += 1;
        //            }
        //        }
        //    }
        //    Response.Redirect("shelf_edit.aspx");

        //}
    }
}