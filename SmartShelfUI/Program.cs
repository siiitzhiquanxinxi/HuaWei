using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartShelfUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                Utils.Writelog(ex.ToString() + "\r\n" + ex.StackTrace, "程序入口");
                throw;
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            Utils.Writelog(ex.ToString() + "\r\n" + ex.Exception.StackTrace, "程序入口2");
            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (DialogResult.Yes == MessageBox.Show(message, "错误", MessageBoxButtons.OKCancel))
            {
                Application.Exit();
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            Utils.Writelog(ex.ToString() + "\r\n" + ex.StackTrace, "程序入口3");
            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Message);
            if (DialogResult.Yes == MessageBox.Show(message, "错误", MessageBoxButtons.OKCancel))
            {
                Application.Exit();
            }
        }
    }
}
