using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using System.Data;
using System.IO;
namespace DTcms.Web.admin.Warehouse
{
    public partial class barcode_edit : Web.UI.ManagePage
    {
        private string BatchNumber = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BatchNumber = DTRequest.GetQueryString("BatchNumber");
            if (!Page.IsPostBack)
            {
                ShowInfo(this.BatchNumber);
            }
        }
        BLL.w_barcode bll = new BLL.w_barcode();
        BLL.sy_material materialbll = new BLL.sy_material();
        private static DataTable dt = null;
        private void ShowInfo(string _id)
        {
            dt= bll.GetListWithCabinetNo("BatchNumber='" + _id + "'").Tables[0];
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
            if(dt.Rows.Count>0)
            {
                Model.sy_material mmodel = materialbll.GetModel(dt.Rows[0]["MaterialID"].ToString());
                txtMaterialID.Text = mmodel.MaterialID;
                txtMaterialName.Text = mmodel.MaterialName;
                txtMaterialType.Text = mmodel.MaterialType;
                hdfMaterialTypeID.Value = mmodel.MaterialTypeID;
                txtBrand.Text = mmodel.Brand;
                txtSpec.Text = mmodel.Spec;
                txtDeep.Text = mmodel.Deep.ToString();
                txtHigh.Text = mmodel.High.ToString();
                txtUnit.Text = mmodel.Unit;
                txtTotalTime.Text = mmodel.TotalTime.ToString();
                txtBatchNumber.Text = _id;
                txtMinimum.Text = dt.Rows[0]["Num"].ToString();
                txtNum.Text = dt.Rows.Count.ToString();
            }

        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            if(dt==null)dt= bll.GetListWithCabinetNo("1=2").Tables[0];
            this.txtBatchNumber.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            Model.sy_material mmodel = materialbll.GetModel(this.txtMaterialID.Text.Trim());
            string sqlshelf = "select * from sy_shelf where Deep>='" + mmodel.Deep + "' and High>='"+ mmodel.High+ "' order by High,Deep";
            DataTable dtshelf = DbHelperMySql.Query(sqlshelf).Tables[0];
            if (dtshelf.Rows.Count == 0)
            {
                MessageBox.Show(this, "没有大小相匹配的格子");
                return;
            }
            else
            {
                decimal TotalNum = Convert.ToDecimal(this.txtNum.Text.Trim());
                decimal BagNum = Convert.ToDecimal(this.txtMinimum.Text.Trim());
                int bnum = Convert.ToInt32(TotalNum / BagNum);
                if (TotalNum > BagNum * bnum) bnum++;
                string sqlcode = "select * from w_barcode where BarCode like '"+txtCode.Text.Trim()+ "%' order by BarCode desc";
                DataTable dtcode= DbHelperMySql.Query(sqlcode).Tables[0];
                int codenum = dtcode.Rows.Count;
                for (int i=0;i<dtshelf.Rows.Count;i++)
                {
                    int x = Convert.ToInt32(dtshelf.Rows[i]["X"]);
                    int y = Convert.ToInt32(dtshelf.Rows[i]["Y"]);
                    for (int b = 1; b <= y; b++)
                    {
                        for (int a = 1; a <= x; a++)
                        {
                            string sqlbox = "select * from w_barcode where FK_ShelfID='" + dtshelf.Rows[i]["ID"].ToString() + "' and X='" + a.ToString() + "' and Y='" + b.ToString() + "' and state<>-1";
                            DataTable dtbox = DbHelperMySql.Query(sqlbox).Tables[0];
                            if (dtbox.Rows.Count == 0)
                            {
                                DataRow dr = dt.NewRow();
                                codenum++;
                                if (codenum <= 9999)
                                {
                                    if (codenum < 10)
                                    {
                                        dr["BarCode"] = txtCode.Text.Trim()+"000" + Convert.ToString(codenum);
                                    }
                                    else if (codenum >= 10 && codenum < 100)
                                    {
                                        dr["BarCode"] = txtCode.Text.Trim() + "00" + Convert.ToString(codenum);
                                    }
                                    else if (codenum >= 100 && codenum < 1000)
                                    {
                                        dr["BarCode"] = txtCode.Text.Trim() + "0" + Convert.ToString(codenum);
                                    }
                                    else
                                    {
                                        dr["BarCode"] = txtCode.Text.Trim() + Convert.ToString(codenum);
                                    }
                                    
                                }
                                //dr["BarCode"] = this.txtMaterialID.Text.Trim()  + "-" + bnum.ToString();
                                dr["BatchNumber"] = this.txtBatchNumber.Text.Trim();
                                dr["MaterialID"] = this.txtMaterialID.Text.Trim();
                                dr["MaterialName"] = this.txtMaterialName.Text.Trim();
                                dr["Num"] = this.txtMinimum.Text.Trim();
                                dr["FK_ShelfID"] = dtshelf.Rows[i]["ID"].ToString();
                                dr["FK_CabinetNo"] = dtshelf.Rows[i]["FK_CabinetNo"].ToString();
                                dr["BoxNo"] = dtshelf.Rows[i]["BoxNo"].ToString();
                                dr["X"] = a;
                                dr["Y"] = b;
                                dt.Rows.InsertAt(dr, 0);
                                bnum--;
                                if (bnum == 0)
                                {
                                    this.rptList.DataSource = dt;
                                    this.rptList.DataBind();
                                    return;
                                }
                            }
                        }
                    }
                        
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //dt = (DataTable)this.rptList.DataSource;
                if (dt.Rows.Count==0) return;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Model.w_barcode model = new Model.w_barcode();
                    model.BarCode = dt.Rows[i]["BarCode"].ToString();
                    model.BatchNumber = dt.Rows[i]["BatchNumber"].ToString();
                    model.MaterialID = this.txtMaterialID.Text.Trim();
                    model.MaterialName = this.txtMaterialName.Text.Trim();
                    model.MaterialTypeID = this.hdfMaterialTypeID.Value;
                    model.MaterialType = this.txtMaterialType.Text.Trim();
                    model.Brand = this.txtBrand.Text.Trim();
                    model.Spec = this.txtSpec.Text.Trim();
                    model.Unit = this.txtUnit.Text.Trim();
                    model.Num = Convert.ToInt32(dt.Rows[i]["Num"]);
                    model.FK_ShelfID = Convert.ToInt32(dt.Rows[i]["FK_ShelfID"]);
                    model.X = Convert.ToInt32(dt.Rows[i]["X"]);
                    model.Y = Convert.ToInt32(dt.Rows[i]["Y"]);
                    model.RemainTime = Convert.ToInt32(this.txtTotalTime.Text.Trim());
                    model.ToolLevel = "X";
                    model.State = 0;
                    bll.Add(model);
                }
                DataTable dtexcel = bll.GetList("BatchNumber='"+this.txtBatchNumber.Text.Trim()+"'").Tables[0];
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
                worksheet.Name = this.txtBatchNumber.Text.Trim();
                Aspose.Cells.Cell cell;
                int rowIndex = 0;   //行的起始下标为 0
                int colIndex = 0;   //列的起始下标为 0
                //设置列名
                for (int i = 0; i < dtexcel.Columns.Count-6; i++)
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
                    for (int j = 0; j < dtexcel.Columns.Count-6; j++)
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
        public void OutputClient(byte[] bytes)
        {
            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();

            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", DateTime.Now.ToString("yyyy-MM-dd-HH-mm")));

            HttpContext.Current.Response.Charset = "GB2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();

            HttpContext.Current.Response.Close();
        }
    }
}