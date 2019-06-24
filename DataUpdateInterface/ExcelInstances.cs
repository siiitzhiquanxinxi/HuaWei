using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataUpdateInterface
{
    public class ExcelInstances
    {
        private static Microsoft.Office.Interop.Excel.Application m_excelApp = null;
        private static Microsoft.Office.Interop.Excel.Workbooks m_excelWorkBooks = null;

        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int Processid);

        private ExcelInstances()
        {
        }



        // 初始化ExcelInstances后，生成相应的COM实例

        private static void Init()
        {
            if (m_excelApp == null)
            {
                m_excelApp = new Microsoft.Office.Interop.Excel.Application();
                m_excelApp.DisplayAlerts = false;
                m_excelApp.AlertBeforeOverwriting = false;
            }

            if (m_excelWorkBooks == null)
            {
                if (m_excelApp != null)
                {
                    m_excelWorkBooks = m_excelApp.Workbooks;
                }
            }
        }



        // 辅助功能-获取当前系统中Excel的进程数

        public static int GetExcelProcessCount()
        {
            int iReturn = 0;
            System.Diagnostics.Process[] pProcesses = null;

            try
            {
                pProcesses = System.Diagnostics.Process.GetProcesses();

                foreach (System.Diagnostics.Process p in pProcesses)
                {
                    if (string.Equals(p.ProcessName.ToString(), "EXCEL"))
                    {
                        iReturn++;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return iReturn;
        }



        // 强行关闭指定的Excel进程

        public static void Kill(Microsoft.Office.Interop.Excel.Application theApp)
        {
            int iId = 0;
            IntPtr intptr = new IntPtr(theApp.Hwnd);
            System.Diagnostics.Process p = null;

            try
            {
                GetWindowThreadProcessId(intptr, out iId);
                p = System.Diagnostics.Process.GetProcessById(iId);

                if (p != null)
                {
                    p.Kill();
                    p.Dispose();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static ExcelInstances _objInstances = null;



        // 获得一个ExcelInstances 的实例

        public static ExcelInstances GetInstances()
        {
            if (_objInstances == null)
            {
                _objInstances = new ExcelInstances();
            }

            Init();

            return _objInstances;
        }

        // 按照文件名获得指定的workbook
        public Microsoft.Office.Interop.Excel.Workbook GetWorkBook(string strFileName)
        {
            return m_excelWorkBooks.Add(strFileName);
        }

        // 关闭workbook
        public void Close()
        {
            try
            {
                if (m_excelWorkBooks != null)
                {
                    m_excelWorkBooks.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_excelWorkBooks);
                    m_excelWorkBooks = null;
                }

                if (m_excelApp != null)
                {
                    m_excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_excelApp);
                    m_excelApp = null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
