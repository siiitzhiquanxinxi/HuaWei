using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShelfUI
{
    public class Utils
    {
        /// <summary>
        /// 写入Log.txt日志文件
        /// </summary>
        /// <param name="content">日志内容</param>
        /// <param name="type">日志类别</param>
        /// <param name="remark">备注</param>
        public static void Writelog(string content, string type, string remark = "")
        {
            string machineid = ConfigurationManager.AppSettings["machineid"].Trim();
            string area = ConfigurationManager.AppSettings["area"].Trim();
            try
            {
                string path = @"log/" + DateTime.Now.ToString("yyyy-MM-dd");
                if (Directory.Exists(path) == false)//如果不存在就创建文件夹 
                {
                    Directory.CreateDirectory(path);
                }
                FileStream fs = new FileStream(path + "/Log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                string mes = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-" + type + "--" + content;
                if (!string.IsNullOrEmpty(remark))
                {
                    mes += "---Remark:" + remark;
                }
                sw.WriteLine(mes);
                sw.Close();
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 写入LogError.txt错误日志文件
        /// </summary>
        /// <param name="errType">错误类型</param>
        /// <param name="errContent">错误内容</param>
        public static void WriteError(string errType, string errContent)
        {
            string machineid = ConfigurationManager.AppSettings["machineid"].Trim();
            try
            {
                string path = @"log/" + DateTime.Now.ToString("yyyy-MM-dd");
                if (Directory.Exists(path) == false)//如果不存在就创建文件夹 
                {
                    Directory.CreateDirectory(path);
                }
                FileStream fs = new FileStream(path + "/LogError.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                string mes = DateTime.Now + "-" + "错误类型：" + errType + ";" + "错误内容：" + errContent;
                sw.WriteLine(mes);
                sw.Close();
            }
            catch (Exception)
            { }

        }
    }
}
