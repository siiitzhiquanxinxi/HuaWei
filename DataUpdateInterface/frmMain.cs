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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string where = "SELECT b.id as poid,b.MaterialTexture,a.* from temp_camlist a join temp_planorderlist b on a.PartNum=b.PartNum where  ToolReadyState=0 and (PlanWorkTime<date_add(now(), interval 30 MINUTE) and DelayWorkTime is NULL) or (DelayWorkTime<now() and DelayWorkTime is not NULL) order by a.PartNum";
                DataTable podt = DbHelperMySql.Query(where).Tables[0];
                string PartNum = "";
                for (int j = 0; j < podt.Rows.Count; j++)
                {
                    string sql = "SELECT a.*,b.Texture,b.Coefficient from w_barcode a,sy_material_texture b where a.MaterialID=b.MaterialID and a.state=1 and a.MaterialName='" + podt.Rows[j]["ToolName"].ToString() + "' and b.Texture='" + podt.Rows[j]["MaterialTexture"].ToString() + "' and a.ToolLevel='" + podt.Rows[j]["ToolLevel"].ToString() + "' and a.RemainTime*b.Coefficient>=" + podt.Rows[j]["WorkTime"].ToString();
                    DataTable dt = DbHelperMySql.Query(sql).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        string updatewbacode = "update w_barcode set State=4 where BarCode='" + dt.Rows[0]["BarCode"].ToString() + "'";
                        string updatecam = "update temp_camlist set ToolReadyState=1,ToolBarCode='" + dt.Rows[0]["BarCode"].ToString() + "' where id='" + podt.Rows[j]["id"].ToString() + "'";
                        DbHelperMySql.ExecuteSql(updatewbacode);
                        DbHelperMySql.ExecuteSql(updatecam);
                    }
                    string sqlcam = "select * from temp_camlist where ToolReadyState=0 and PartNum='" + podt.Rows[j]["PartNum"].ToString() + "'";
                    DataTable dtcam = DbHelperMySql.Query(sqlcam).Tables[0];
                    if (dtcam.Rows.Count == 0)
                    {
                        string updatetemppo = "update temp_planorderlist set OrderReadyState=1 where PartNum='" + podt.Rows[j]["PartNum"].ToString() + "'";
                        DbHelperMySql.ExecuteSql(updatetemppo);

                    }
                    if (podt.Rows[j]["PartNum"].ToString() != PartNum && PartNum != "")
                    {
                        string excel = "select PartNum,ToolName,WorkTime,ToolBarCode ,ToolLevel from temp_camlist where PartNum='" + podt.Rows[j]["PartNum"].ToString() + "'";
                        DataTable dtexcel = DbHelperMySql.Query(excel).Tables[0];
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
                        rowIndex = rowIndex + 2;
                        //写入数据
                        for (int i = 0; i < dtexcel.Rows.Count; i++)
                        {
                            for (int k = 0; k < dtexcel.Columns.Count; k++)
                            {
                                cell = worksheet.Cells[rowIndex + i, colIndex + k];
                                cell.PutValue(dtexcel.Rows[i][k]);
                                //cell.Style.IsTextWrapped = true;
                            }
                        }

                        //自动列宽
                        //worksheet.AutoFitColumns();

                        //设置导出文件路径
                        //string path = Application.StartupPath;
                        string path = AppDomain.CurrentDomain.BaseDirectory;
                        //设置新建文件路径及名称
                        string savePath = path + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";

                        //创建文件
                        FileStream file = new FileStream(savePath, FileMode.CreateNew);

                        //关闭释放流，不然没办法写入数据
                        file.Close();
                        file.Dispose();

                        //保存至指定路径
                        workbook.Save(savePath);
                        //if (PrintCode.SendFileToPrinter("doPDF v7", savePath))
                        //{
                        //    System.Windows.Forms.MessageBox.Show("文件已成功发送至打印队列！", "提示信息");
                        //}
                        //调用打印机
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        //不现实调用程序窗口,但是对于某些应用无效
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        //采用操作系统自动识别的模式
                        p.StartInfo.UseShellExecute = true;
                        //指定执行的动作，是打印，即print，打开是 open
                        p.StartInfo.Verb = "print";

                        p.StartInfo.FileName = savePath;
                        p.Start();
                        if (File.Exists(savePath))
                        {
                            File.Delete(savePath);
                        }
                        worksheet = null;
                        workbook = null;
                    }
                    PartNum = podt.Rows[j]["PartNum"].ToString();
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
            //调用打印机
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //不现实调用程序窗口,但是对于某些应用无效
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //采用操作系统自动识别的模式
            p.StartInfo.UseShellExecute = true;
            //指定执行的动作，是打印，即print，打开是 open
            p.StartInfo.Verb = "print";

            p.StartInfo.FileName = @"D:\huawei\DataUpdateInterface\bin\Debug\module.xlsx";
            p.Start();
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
