using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using HtmlAgilityPack;
namespace DTcms.Web.admin.PlanOrder
{
    public partial class planorder_view : Web.UI.ManagePage
    {
        string id = "";
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryString("id");
                if (!bll.Exists(int.Parse(id)))
                {
                    JscriptMsg("记录不存在或已被删除！", "back");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("planorder_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(int.Parse(id));
                }
            }
        }
        BLL.temp_planorderlist bll = new BLL.temp_planorderlist();
        BLL.temp_camlist cambll = new BLL.temp_camlist();
        private void ShowInfo(int _id)
        {
            Model.temp_planorderlist model = bll.GetModel(_id);
            hidID.Value = model.Id.ToString();
            txtPartNum.Text = model.PartNum;
            txtCreateDate.Text = model.CreateDate.ToString();
            txtPartName.Text = model.PartName;
            txtMaterialTexture.Text = model.MaterialTexture;
            txtPlanWorkTime.Text = model.PlanWorkTime.ToString();
            txtDelayWorkTime.Text = model.DelayWorkTime.ToString();
            txtMachineLathe.Text = model.MachineLathe;
            txtWorkProcedure.Text = model.WorkProcedure;
            txtPlanNo.Text = model.PlanNo;
            txtComponentNo.Text = model.ComponentNo;
            switch (model.OrderReadyState)
            {
                case 0:
                    txtOrderReadyState.Text = "待备刀";
                    break;
                case 1:
                    txtOrderReadyState.Text = "备刀中";
                    break;
                case 2:
                    txtOrderReadyState.Text = "已完成";
                    break;
                case -1:
                    txtOrderReadyState.Text = "异常";
                    break;
                case -2:
                    txtOrderReadyState.Text = "已取消";
                    break;
            }
            DataTable dt = cambll.GetList("FK_Id='" + model.Id + "'").Tables[0];
            this.rptList.DataSource = dt;
            this.rptList.DataBind();



        }
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string id = btn.CommandArgument.ToString();
            cambll.Delete(Convert.ToInt32(id));
            DataTable dt = cambll.GetList("FK_Id='" + hidID.Value + "'").Tables[0];
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (fulImport.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(fulImport.FileName);//获取文件名的后缀
                if (fileExt.ToLower() == ".html")//判断文件后缀名是否是xls
                {
                    string path = Server.MapPath("../../upload/" + DateTime.Now.ToString("yyyyMMddHHmms"));
                    fulImport.SaveAs(path);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.Load(path);
                    HtmlNode table = htmlDoc.DocumentNode.SelectSingleNode("//table");
                    if (table != null)
                    {
                        if (!table.InnerHtml.Contains(this.txtPartNum.Text.Trim()))
                        {
                            MessageBox.Show(this, "导入的文件不属于该零件号");
                            return;
                        }
                        if (!table.InnerHtml.Contains(this.txtPlanNo.Text.Trim()))
                        {
                            MessageBox.Show(this, "导入的文件不属于该计划号");
                            return;
                        }
                    }
                    HtmlNodeCollection trlist = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@style,'word-wrap')]");
                    if(trlist==null)
                    {
                        MessageBox.Show(this, "格式不正确");
                        return;
                    }
                    Model.temp_camlist model = new Model.temp_camlist();
                    foreach (HtmlNode itemtr in trlist)
                    {
                        string c = itemtr.InnerHtml;
                        string newc = c.Replace("</td>", "|");
                        string[] str = newc.Split('|');
                        DataTable dtold= cambll.GetList("FK_Id='"+ hidID.Value + "' and ToolName='"+ str[2].Split('>')[1] + "' and ToolNum='"+ str[1].Split('>')[1] + "'").Tables[0];
                        if (dtold.Rows.Count > 0)
                        {
                            model = cambll.GetModel(Convert.ToInt32(dtold.Rows[0]["Id"]));
                            model.WorkTime= Convert.ToDecimal(dtold.Rows[0]["WorkTime"])+ Convert.ToDecimal(str[10].Split('>')[1]);
                            cambll.Update(model);
                        }
                        else
                        {
                            model.FK_Id = Convert.ToInt32(hidID.Value);
                            model.PartNum = this.txtPartNum.Text.Trim();
                            model.ToolNum = str[1].Split('>')[1].Trim();
                            model.ToolName = str[2].Split('>')[1].Trim();
                            model.ToolDiam = str[3].Split('>')[1].Trim();
                            model.ToolRadius = str[4].Split('>')[1].Trim();
                            model.ToolBladeLength = str[6].Split('>')[1].Trim();
                            model.ToolHandle = str[8].Split('>')[1].Trim();
                            model.ToolLong = str[9].Split('>')[1].Trim();
                            model.WorkTime = Convert.ToDecimal(str[10].Split('>')[1].Trim());
                            model.ToolLevel = str[11].Split('>')[1].Trim();
                            model.Remark = str[12].Split('>')[1];
                            model.ToolReadyState = 0;
                            cambll.Add(model);
                        }
                    }
                }
            }
            DataTable dt = cambll.GetList("FK_Id='" + hidID.Value + "'").Tables[0];
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }
    }
}