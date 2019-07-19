using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.Text;
using System.IO;

namespace DTcms.Web.admin.Warehouse
{
    public partial class barcode_list : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("barcode_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        private void RptBind()
        {

            string sql = "SELECT DISTINCT BatchNumber,MaterialID,MaterialName,MaterialType,Brand,Spec,Unit,Num from w_barcode where state=0";
            this.rptList.DataSource = DbHelperMySql.Query(sql).Tables[0];
            this.rptList.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT DISTINCT BatchNumber,MaterialID,MaterialName,MaterialType,Brand,Spec,Unit,Num from w_barcode where ";
            sql += " state=0 and (MaterialID like  '%" + this.txtKeywords.Text.Trim() + "%' or MaterialName like '%" + this.txtKeywords.Text.Trim() + "%' or Brand like '%" + this.txtKeywords.Text.Trim() + "%' or Spec like '%" + this.txtKeywords.Text.Trim() + "%' or BatchNumber like '%" + this.txtKeywords.Text.Trim() + "%')";
            this.rptList.DataSource = DbHelperMySql.Query(sql).Tables[0];
            this.rptList.DataBind();
        }
        BLL.w_barcode bll = new BLL.w_barcode();
        protected void lbtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                string BatchNumber = btn.CommandArgument.ToString();
                DataTable dtexcel = bll.GetList("BatchNumber='" + BatchNumber + "'").Tables[0];
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                worksheet.Name = BatchNumber;
                Aspose.Cells.Cell cell;
                int rowIndex = 0;   //行的起始下标为 0
                int colIndex = 0;   //列的起始下标为 0
                //设置列名
                for (int i = 0; i < dtexcel.Columns.Count - 6; i++)
                {
                    //获取第一行的每个单元格
                    cell = worksheet.Cells[rowIndex, colIndex + i];
                    //设置列名
                    cell.PutValue(dtexcel.Columns[i].ColumnName);
                    //设置字体
                    cell.Style.Font.Name = "宋体";
                    //设置字体加粗
                    cell.Style.Font.IsBold = true;
                    //设置字体大小
                    cell.Style.Font.Size = 12;
                    //设置字体颜色
                    cell.Style.Font.Color = System.Drawing.Color.Black;
                    ////单元格内容自动换行
                    //cell.Style.IsTextWrapped = true;
                    //文本对齐方式
                    cell.Style.VerticalAlignment = Aspose.Cells.TextAlignmentType.Center;
                    ////设置背景色
                    //cell.Style.BackgroundColor = System.Drawing.Color.LightGreen;
                }

                //跳过第一行，第一行写入了列名
                rowIndex++;

                //写入数据
                for (int i = 0; i < dtexcel.Rows.Count; i++)
                {
                    for (int j = 0; j < dtexcel.Columns.Count - 6; j++)
                    {
                        cell = worksheet.Cells[rowIndex + i, colIndex + j];

                        cell.PutValue(dtexcel.Rows[i][j]);
                    }
                }

                //自动列宽
                worksheet.AutoFitColumns();

                //设置导出文件路径
                string path = HttpContext.Current.Server.MapPath("Export/");

                //设置新建文件路径及名称
                string savePath = path + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";

                //创建文件
                FileStream file = new FileStream(savePath, FileMode.CreateNew);

                //关闭释放流，不然没办法写入数据
                file.Close();
                file.Dispose();

                //保存至指定路径
                workbook.Save(savePath);
                DTcms.Common.Utils.down(savePath, Response);
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                ////或者使用下面的方法，输出到浏览器下载。
                //byte[] bytes = workbook.SaveToStream().ToArray();
                //OutputClient(bytes);

                worksheet = null;
                workbook = null;
            }
            catch (Exception ex)
            {

            }
        }
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            string BatchNumber = btn.CommandArgument.ToString();
            bll.DeleteWhere("BatchNumber='" + BatchNumber + "'");
            RptBind();
        }
    }
}