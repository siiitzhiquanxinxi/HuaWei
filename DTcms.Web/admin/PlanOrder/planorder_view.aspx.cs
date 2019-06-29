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
            txtPartNum.Text = model.PartNum;
            txtCreateDate.Text = model.CreateDate.ToString();
            txtPartName.Text = model.PartName;
            txtMaterialTexture.Text = model.MaterialTexture;
            txtPlanWorkTime.Text = model.PlanWorkTime.ToString();
            txtDelayWorkTime.Text = model.DelayWorkTime.ToString();
            txtMachineLathe.Text = model.MachineLathe;
            txtWorkProcedure.Text = model.WorkProcedure;
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
            }
            DataTable dt = cambll.GetList("PartNum='"+ model.PartNum + "'").Tables[0];
            this.rptList.DataSource = dt;
            this.rptList.DataBind();



        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (fulImport.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(fulImport.FileName);//获取文件名的后缀
                if ( fileExt.ToLower() == ".html")//判断文件后缀名是否是xls
                {
                    string path = Server.MapPath("../../upload/" + DateTime.Now.ToString("yyyyMMddHHmms"));
                    fulImport.SaveAs(path);
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.Load(path);
                    HtmlNodeCollection trlist = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@style,'word-wrap')]");
                    foreach (HtmlNode itemtr in trlist)
                    {
                        string b = itemtr.InnerText;
                        HtmlNodeCollection tdlist = itemtr.SelectNodes("//td[contains(@class,'xl77')]");
                        foreach (HtmlNode item in tdlist)
                        {
                            string a = item.InnerText;
                        }
                    }
                }
            }
        }
    }
}