using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DTcms.Common;
using DTcms.BLL;
using DTcms.DBUtility;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using Aspose.Cells;

namespace DataUpdateInterface
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private int MoveUpMinute = 0;
        private void frmMain_Load(object sender, EventArgs e)
        {
            string tim = ConfigurationManager.AppSettings["Time"].Trim();
            if (tim != "")
            {
                this.timer1.Interval = int.Parse(tim);
                this.timer1.Enabled = true;
                MoveUpMinute = int.Parse(ConfigurationManager.AppSettings["MoveUpMinute"].Trim());
            }
            this.Visible = false;
        }
        private StreamReader getStream(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            return sr;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    string email = "select * from temp_planorderlist where EmailState=0 or EmailState is null";
                    System.Data.DataTable emaildt = DbHelperMySql.Query(email).Tables[0];
                    for (int j = 0; j < emaildt.Rows.Count; j++)
                    {
                        StreamReader sr = getStream(ConfigurationManager.AppSettings["MailTo"].Trim());
                        DTcms.Common.SendMail.Send("Cam导入提醒（" + emaildt.Rows[j]["PartName"].ToString() + "）", "零件号：" + emaildt.Rows[j]["PartNum"].ToString() + ",计划号：" + emaildt.Rows[j]["PlanNo"].ToString() + ",计划开工时间：" + emaildt.Rows[j]["PlanWorkTime"].ToString(), sr.ReadToEnd(), ConfigurationManager.AppSettings["Psd"].Trim(), ConfigurationManager.AppSettings["Host"].Trim(), ConfigurationManager.AppSettings["SendName"].Trim(), ConfigurationManager.AppSettings["Sendaddr"].Trim());
                        string update = "update temp_planorderlist set EmailState=1 where id='" + emaildt.Rows[j]["id"].ToString() + "'";
                        DbHelperMySql.ExecuteSql(update);
                    }
                }
                catch (Exception ex)
                {
                    Writelog(ex.ToString(), "Sendmail", "ErrLog.txt");
                }
                string where = "SELECT b.id as poid,b.MaterialTexture,a.* from temp_camlist a join temp_planorderlist b on a.FK_Id=b.Id where  ToolReadyState=0 and ((PlanWorkTime<date_add(now(), interval 30 MINUTE) and DelayWorkTime is NULL) or (DelayWorkTime<now() and DelayWorkTime is not NULL)) order by a.PartNum";
                System.Data.DataTable podt = DbHelperMySql.Query(where).Tables[0];
                
                DTcms.BLL.temp_planorderlist bll = new temp_planorderlist();
                System.Data.DataTable dtpo = bll.GetList("OrderReadyState=0 and ((PlanWorkTime<date_add(now(), interval 30 MINUTE) and DelayWorkTime is NULL) or (DelayWorkTime<now() and DelayWorkTime is not NULL))").Tables[0];

                for (int j = 0; j < podt.Rows.Count; j++)
                {
                    string sql = "";
                    if (podt.Rows[j]["ToolLevel"].ToString().Trim() == "")
                    {
                        sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and a.MaterialName='" + podt.Rows[j]["ToolName"].ToString() + "' and b.Texture='" + podt.Rows[j]["MaterialTexture"].ToString() + "' and  a.ToolLevel='F' and a.RemainTime*b.Coefficient>=" + podt.Rows[j]["WorkTime"].ToString() + " order by a.RemainTime";
                        System.Data.DataTable dttemp = DbHelperMySql.Query(sql).Tables[0];
                        if (dttemp.Rows.Count == 0)
                        {
                            sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and a.MaterialName='" + podt.Rows[j]["ToolName"].ToString() + "' and b.Texture='" + podt.Rows[j]["MaterialTexture"].ToString() + "' and a.ToolLevel='R' and a.RemainTime*b.Coefficient>=" + podt.Rows[j]["WorkTime"].ToString() + " order by a.RemainTime";
                            System.Data.DataTable dttemp1 = DbHelperMySql.Query(sql).Tables[0];
                            if (dttemp1.Rows.Count == 0)
                                sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and a.MaterialName='" + podt.Rows[j]["ToolName"].ToString() + "' and b.Texture='" + podt.Rows[j]["MaterialTexture"].ToString() + "' and a.ToolLevel='X' and a.RemainTime*b.Coefficient>=" + podt.Rows[j]["WorkTime"].ToString() + " order by a.RemainTime";
                        }
                    }
                    else if (podt.Rows[j]["ToolLevel"].ToString() == "X")
                    {
                        sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and a.MaterialName='" + podt.Rows[j]["ToolName"].ToString() + "' and b.Texture='" + podt.Rows[j]["MaterialTexture"].ToString() + "' and a.ToolLevel='" + podt.Rows[j]["ToolLevel"].ToString() + "' and a.RemainTime*b.Coefficient>=" + podt.Rows[j]["WorkTime"].ToString();
                    }
                    else if (podt.Rows[j]["ToolLevel"].ToString() == "F")
                    {
                        sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and a.MaterialName='" + podt.Rows[j]["ToolName"].ToString() + "' and b.Texture='" + podt.Rows[j]["MaterialTexture"].ToString() + "' and a.ToolLevel='" + podt.Rows[j]["ToolLevel"].ToString() + "' and a.RemainTime*b.Coefficient>=" + podt.Rows[j]["WorkTime"].ToString() + " order by a.RemainTime";
                        System.Data.DataTable dttemp = DbHelperMySql.Query(sql).Tables[0];
                        if (dttemp.Rows.Count == 0)
                            sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and a.MaterialName='" + podt.Rows[j]["ToolName"].ToString() + "' and b.Texture='" + podt.Rows[j]["MaterialTexture"].ToString() + "' and a.ToolLevel='X' and a.RemainTime*b.Coefficient>=" + podt.Rows[j]["WorkTime"].ToString() + " order by a.RemainTime";
                    }
                    System.Data.DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        string updatewbacode = "update w_barcode set State=4 where BarCode='" + dt.Rows[0]["BarCode"].ToString() + "'";
                        string updatecam = "update temp_camlist set ToolReadyState=1,ToolBarCode='" + dt.Rows[0]["BarCode"].ToString() + "' where id='" + podt.Rows[j]["id"].ToString() + "'";
                        DbHelperMySql.ExecuteSql(updatewbacode);
                        DbHelperMySql.ExecuteSql(updatecam);
                    }
                    else
                    {
                        string updatecam = "update temp_camlist set ToolReadyState=-1 where id='" + podt.Rows[j]["id"].ToString() + "'";
                        DbHelperMySql.ExecuteSql(updatecam);
                        string updatetemppo = "update temp_planorderlist set OrderReadyState=-1 where ID='" + podt.Rows[j]["poid"].ToString() + "'";
                        DbHelperMySql.ExecuteSql(updatetemppo);
                    }
                    string sqlcam = "select * from temp_camlist where ToolReadyState=0 and id='" + podt.Rows[j]["id"].ToString() + "'";
                    System.Data.DataTable dtcam = DbHelperMySql.Query(sqlcam).Tables[0];
                    if (dtcam.Rows.Count == 0)
                    {
                        string updatetemppo = "update temp_planorderlist set OrderReadyState=1 where ID='" + podt.Rows[j]["poid"].ToString() + "' and OrderReadyState=0";
                        DbHelperMySql.ExecuteSql(updatetemppo);
                    }
                }
                for(int k=0;k< dtpo.Rows.Count;k++)
                {
                    if (podt.Select("poid='" + dtpo.Rows[k]["ID"].ToString() + "'").Length > 0)
                    {
                        string filename = ExcelExport(dtpo.Rows[k]["ID"].ToString(), dtpo.Rows[k]["MachineLathe"].ToString(), dtpo.Rows[k]["ComponentNo"].ToString());
                        PrintExcel(filename);
                    }
                }
            }
            catch (Exception ex)
            {
                Writelog(ex.ToString(), "timer1", "ErrLog.txt");
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log">日志说明</param>
        /// <param name="tag">标注位置</param>
        /// <param name="flie">所写文件</param>
        private void Writelog(string log, string tag, string flie)
        {
            string path = @"log/" + DateTime.Now.ToString("yyyy-MM-dd");
            if (Directory.Exists(path) == false)//如果不存在就创建文件夹 
            {
                Directory.CreateDirectory(path);

            }
            FileStream fs = new FileStream(path + "/" + flie, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + log + "," + tag);
            sw.Close();
        }
        private string FilePath()
        {
            string path = @"Excel/";
            if (Directory.Exists(path) == false)//如果不存在就创建文件夹 
            {
                Directory.CreateDirectory(path);

            }
            path = AppDomain.CurrentDomain.BaseDirectory + path;
            foreach (FileInfo file in (new DirectoryInfo(path)).GetFiles())
            {
                file.Attributes = FileAttributes.Normal;
                file.Delete();
            }
            return path;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        public class PrintCode
        {
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);


            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);


            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);


            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);


            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);


            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);


            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);


            /// <summary>
            /// 该方法把非托管内存中的字节数组发送到打印机的打印队列
            /// </summary>
            /// <param name="szPrinterName">打印机名称</param>
            /// <param name="pBytes">非托管内存指针</param>
            /// <param name="dwCount">字节数</param>
            /// <returns>成功返回true，失败时为false</returns>
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount, string szFileName)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false;

                di.pDocName = szFileName;
                di.pDataType = "RAW";

                try
                {
                    // 打开打印机
                    if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                    {
                        // 启动文档打印
                        if (StartDocPrinter(hPrinter, 1, di))
                        {
                            // 开始打印
                            if (StartPagePrinter(hPrinter))
                            {
                                // 向打印机输出字节  
                                bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                                EndPagePrinter(hPrinter);
                            }
                            EndDocPrinter(hPrinter);
                        }
                        ClosePrinter(hPrinter);
                    }
                    if (bSuccess == false)
                    {
                        dwError = Marshal.GetLastWin32Error();
                    }
                }
                catch (Win32Exception ex)
                {
                    //WriteLog(ex.Message);
                    bSuccess = false;
                }
                return bSuccess;
            }


            /// <summary>
            /// 发送文件到打印机方法
            /// </summary>
            /// <param name="szPrinterName">打印机名称</param>
            /// <param name="szFileName">打印文件的路径</param>
            /// <returns></returns>
            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                bool bSuccess = false;
                try
                {
                    // 打开文件  
                    FileStream fs = new FileStream(szFileName, FileMode.Open);

                    // 将文件内容读作二进制
                    BinaryReader br = new BinaryReader(fs);

                    // 定义字节数组
                    Byte[] bytes = new Byte[fs.Length];

                    // 非托管指针  
                    IntPtr pUnmanagedBytes = new IntPtr(0);

                    int nLength;

                    nLength = Convert.ToInt32(fs.Length);

                    // 读取文件内容到字节数组
                    bytes = br.ReadBytes(nLength);

                    // 为这些字节分配一些非托管内存
                    pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);

                    // 将托管字节数组复制到非托管内存指针
                    Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);

                    // 将非托管字节发送到打印机
                    bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength, szFileName);

                    // 释放先前分配的非托管内存
                    Marshal.FreeCoTaskMem(pUnmanagedBytes);

                    fs.Close();
                    fs.Dispose();
                }
                catch (Win32Exception ex)
                {
                    //WriteLog(ex.Message);
                    bSuccess = false;
                }
                return bSuccess;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FilePath();
            string wordFile = AppDomain.CurrentDomain.BaseDirectory+ @"module.xlsx";
            PrintExcel(wordFile);

            //CommonCompute
        }

        private void PrintExcel(string FileName)
        {
            object oMissing = Missing.Value;
            Microsoft.Office.Interop.Excel.Application appxls = new Microsoft.Office.Interop.Excel.Application();
            appxls.Visible = false;
            appxls.DisplayAlerts = false;
            //object oTrue = true;
            //object oFalse = false;
            _Workbook book = appxls.Workbooks.Open(FileName);
            _Worksheet sheet = book.Worksheets[1];
            sheet.Activate();
            sheet.PageSetup.PrintGridlines = true;
            sheet.PrintOutEx();
            sheet = null;
            book.Saved = false;
            object saved = false;
            book.Close(saved);
            appxls.Quit();
            ExcelInstances.Kill(appxls);
            book = null;
            appxls = null;
            GC.Collect();
        }
        private string ExcelExport(string ID,string MachineLathe, string ComponentNo)
        {
            string excel = "select PartNum,ToolNum,ToolName,ToolDiam,ToolRadius,ToolBladeLength,ToolHandle,ToolLong,ToolLevel,Remark,ToolReadyState from temp_camlist where FK_Id='" + ID + "' order by  CONVERT(ToolNum,signed)";
            System.Data.DataTable dtexcel = DbHelperMySql.Query(excel).Tables[0];
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
            workbook.Open(AppDomain.CurrentDomain.BaseDirectory + "module.xlsx");
            Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
            //worksheet.Name = podt.Rows[j]["PartNum"].ToString();
            Aspose.Cells.Cell cell;
            int rowIndex = 0;   //行的起始下标为 0
            int colIndex = 0;   //列的起始下标为 0
                                //设置列名
            #region #######
            //for (int i = 0; i < dtexcel.Columns.Count; i++)
            //{
            //    //获取第一行的每个单元格
            //    cell = worksheet.Cells[rowIndex, colIndex + i];
            //    //设置列名
            //    string name = "";
            //    switch(dtexcel.Columns[i].ColumnName)
            //    {
            //        case "PartNum":
            //            name= "零件号";
            //            break;
            //        case "ToolName":
            //            name = "刀具名称";
            //            break;
            //        case "WorkTime":
            //            name = "加工时间";
            //            break;
            //        case "ToolBarCode":
            //            name = "刀具号";
            //            break;
            //        case "ToolLevel":
            //            name = "刀具等级";
            //            break;
            //    }
            //    cell.PutValue(name);
            //    //设置字体
            //    cell.Style.Font.Name = "宋体";
            //    //设置字体加粗
            //    cell.Style.Font.IsBold = true;
            //    //设置字体大小
            //    cell.Style.Font.Size = 12;
            //    //设置字体颜色
            //    cell.Style.Font.Color = System.Drawing.Color.Black;
            //    ////单元格内容自动换行
            //    cell.Style.IsTextWrapped = true;

            //    //文本对齐方式
            //    cell.Style.VerticalAlignment = Aspose.Cells.TextAlignmentType.Center;
            //    ////设置背景色
            //    //cell.Style.BackgroundColor = System.Drawing.Color.LightGreen;
            //}
            #endregion
            //跳过第一行，第一行写入了列名
            rowIndex = rowIndex + 4;
            if(dtexcel.Rows.Count>0)
            {
                cell = worksheet.Cells[1, 0];
                cell.PutValue("零件号:"+dtexcel.Rows[0]["PartNum"].ToString());
                cell = worksheet.Cells[1, 5];
                cell.PutValue("机台号:" + MachineLathe);
                cell = worksheet.Cells[1, 7];
                cell.PutValue("工装号:" + ComponentNo);
            }
                
            //写入数据
            for (int i = 0; i < dtexcel.Rows.Count; i++)
            {
                for (int k = 1; k < dtexcel.Columns.Count; k++)
                {
                    cell = worksheet.Cells[rowIndex + i, colIndex + k-1];
                    if (k == dtexcel.Columns.Count - 1)
                    {
                        if (dtexcel.Rows[i][k].ToString() == "1")
                        {
                            cell.PutValue("已备刀");
                        }
                        else
                        {
                            cell.PutValue("异常");
                        }
                    }
                    else
                    {
                        cell.PutValue(dtexcel.Rows[i][k]);
                    }
                    cell.Style.IsTextWrapped = true;//单元格内容自动换行
                    Aspose.Cells.Style style = cell.GetStyle();
                    //加框
                    style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                    style.Borders[BorderType.TopBorder].Color = Color.Black;
                    style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                    style.Borders[BorderType.BottomBorder].Color = Color.Black;
                    style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                    style.Borders[BorderType.LeftBorder].Color = Color.Black;
                    style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                    style.Borders[BorderType.RightBorder].Color = Color.Black;
                    cell.SetStyle(style);
                   
                }
            }

            //自动列宽
            //worksheet.AutoFitColumns();
            worksheet.AutoFitRows();
            //设置导出文件路径
            //string path = Application.StartupPath;
            string path = FilePath();
            //设置新建文件路径及名称
            string savePath = path + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";

            //创建文件
            FileStream file = new FileStream(savePath, FileMode.CreateNew);

            //关闭释放流，不然没办法写入数据
            file.Close();
            file.Dispose();

            //保存至指定路径
            workbook.Save(savePath);
            worksheet = null;
            workbook = null;
            return savePath;
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.Visible = false;
            }
            else
            {
                notifyIcon1.Visible = true;
            }
        }


    }
}
