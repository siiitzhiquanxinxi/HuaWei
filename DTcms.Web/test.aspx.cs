using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using HtmlAgilityPack;
using DTcms.Common;
using System.Data;
namespace DTcms.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string html = File.ReadAllText(@"D:\华为\刀具总表\sheet001.html", Encoding.UTF8);
            BLL.temp_camlist cambll = new BLL.temp_camlist();
            //DataTable dt = cambll.GetList("1=2").Tables[0];
            Model.temp_camlist model = new Model.temp_camlist();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(Server.MapPath("~/upload/sheet001.html"));
            HtmlNodeCollection trlist = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@style,'word-wrap')]");
            foreach (HtmlNode itemtr in trlist)
            {
                //string b = itemtr.InnerText;
                //string newb=b.Replace("\r\n", "|");
                string c = itemtr.InnerHtml;
                string newc =c.Replace("</td>", "|");
                string[] str = newc.Split('|');
                for(int i=1;i<str.Length-2;i++)
                {
                    string[] strnew= str[i].Split('>');
                }
                model.ToolNum = str[1].Split('>')[1];
                model.ToolName = str[2].Split('>')[1];
                model.ToolDiam = str[3].Split('>')[1];
                model.ToolRadius = str[4].Split('>')[1];
                model.ToolBladeLength = str[6].Split('>')[1];
                model.ToolHandle = str[8].Split('>')[1];
                model.ToolLong = str[9].Split('>')[1];
                model.WorkTime =Convert.ToDecimal(str[10].Split('>')[1]);
                model.ToolLevel= str[11].Split('>')[1];
                model.Remark = str[12].Split('>')[1];
                model.ToolReadyState = 0;
                cambll.Add(model);
                //HtmlNodeCollection tdlist = itemtr.SelectNodes("//td[contains(@class,'xl78')]");
                //foreach (HtmlNode item in tdlist)
                //{
                //    string a = item.InnerText;
                //}
            }
            //HtmlNodeCollection tdlist = htmlDoc.DocumentNode.SelectNodes("//td[contains(@class,'xl78')]");
            //foreach (HtmlNode item in tdlist)
            //{
            //    string a = item.InnerText;
            //}
        }
    }
}