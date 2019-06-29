using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using HtmlAgilityPack;
namespace DTcms.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string html = File.ReadAllText(@"D:\华为\刀具总表\sheet001.html", Encoding.UTF8);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(Server.MapPath("~/upload/sheet001.html"));
            HtmlNodeCollection trlist = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@style,'word-wrap')]");
            foreach (HtmlNode itemtr in trlist)
            {
                string b = itemtr.InnerText;
                //HtmlNodeCollection tdlist = itemtr.SelectNodes("//td[contains(@class,'xl77')]");
                //foreach (HtmlNode item in tdlist)
                //{
                //    string a = item.InnerText;
                //}
            }
            HtmlNodeCollection tdlist = htmlDoc.DocumentNode.SelectNodes("//td[contains(@class,'xl77')]");
            foreach (HtmlNode item in tdlist)
            {
                string a = item.InnerText;
            }
        }
    }
}