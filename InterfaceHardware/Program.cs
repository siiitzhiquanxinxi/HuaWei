using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace InterfaceHardware
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new frmMain());
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                InitialLicense();
                CheckingRunning();

                //界面汉化
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (args.Length >= 1)
                {
                    //LoginByArgs(args);
                }
                else
                {
                    LoginNormal(args);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
                MessageBox.Show("系统出现未知异常，请重启系统！", "错误信息");
            }
        }
        private static void LoginNormal(string[] args)
        {
            //主界面
            frmMain dlg = new frmMain();
            Application.Run(dlg);
            dlg.Dispose();
        }

        private static System.Threading.Mutex mutex = null;
        private static void CheckingRunning()
        {
            // 是否第一次创建mutex
            bool newMutexCreated = false;
            string mutexName = "InterfaceHardware";
            try
            {
                mutex = new Mutex(false, mutexName, out newMutexCreated);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);
            }

            // 第一次创建mutex
            if (newMutexCreated)
            {
                Console.WriteLine("程序已启动");
                //todo:此处为要执行的任务
            }
            else
            {
                //MessageUtil.ShowTips("另一个窗口已在运行，不能重复运行。");
                MessageBox.Show("另一个窗口已在运行，不能重复运行。", "提示信息");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(1);//退出程序
            }
        }
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            LogHelper.Error(ex.Exception.ToString());

            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            DialogResult result = MessageBox.Show(message, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == result)
            {
                Application.Exit();
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            LogHelper.Error(ex.ToString());

            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Message);
            DialogResult result = MessageBox.Show(message, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DialogResult.Yes == result)
            {
                Application.Exit();
            }
        }

        private static void InitialLicense()
        {
            //代码设置授权码
            //BIZGO.SecurityDx.MyConstants.License = "B30FAEC6-0852-4E11-8D2E-888AB0DF36E4WNjuiBqnzlua-lt57niLHlkK-o_6rmioDmnK-mnInpmZDlhbzlj7h8RmFsc2Uv";
        }
    }

    public class LogHelper
    {
        public static void Error(string log)
        {
            string path = @"log/" + DateTime.Now.ToString("yyyy-MM-dd");
            if (Directory.Exists(path) == false)//如果不存在就创建文件夹 
            {
                Directory.CreateDirectory(path);

            }
            FileStream fs = new FileStream(path + "/ErrLog.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + log + ",系统级错误");
            sw.Close();
        }
    }
}
