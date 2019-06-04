using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Drawing;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.SessionState;
using System.Security.Cryptography;

namespace DoNet.Utilities
{
    public class Utilities
    {
        #region 弹出消息

        #region 显示消息提示对话框

        /// <summary>
        /// 显示消息提示对话框

        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            // page.RegisterStartupScript("message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// 显示消息提示对话框

        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string title, string msg)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), title, "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>", true);
        }

        #endregion

        #region 控件点击 消息确认提示框


        /// <summary>
        /// 控件点击 消息确认提示框

        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }
        #endregion

        #region 显示消息提示对话框，并进行页面跳转

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转

        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("location.href='{0}'", url);
            Builder.Append("</script>");
            //page.RegisterStartupScript("message", Builder.ToString());
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url, bool top)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            if (top == true)
            {
                Builder.AppendFormat("top.location.href='{0}'", url);
            }
            else
            {
                Builder.AppendFormat("location.href='{0}'", url);
            }
            Builder.Append("</script>");
            // page.RegisterStartupScript("message", Builder.ToString());
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

        #endregion

        #region 输出自定义脚本信息

        /// <summary>
        /// 输出自定义脚本信息

        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            //page.RegisterStartupScript("message", "<script language='javascript' defer>" + script + "</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        #endregion

        #endregion

        /// <summar

        /// <summary>
        /// 生成缩略图

        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static byte[] MakeThumbnail(Stream originalImagePath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromStream(originalImagePath);

            int towidth = width;
            int toheight = height;
            
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充

            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            System.IO.MemoryStream m = new System.IO.MemoryStream();
            try
            {
                //以jpg格式保存缩略图

                bitmap.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                return m.GetBuffer();
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="Response"></param>
        public static void down(string url, HttpResponse Response)
        {
            System.IO.FileInfo DownloadFile = new FileInfo(url);
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(DownloadFile.Name, System.Text.Encoding.UTF8));
            Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(DownloadFile.FullName);
            Response.Flush();
            Response.Clear();
            Response.Close();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }


        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="strParams"></param>
        /// <returns></returns>
        public static string MD5_32(string strParams)
        {
            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(strParams));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            StringBuilder EnText = new StringBuilder();
            foreach (byte Byte in s)
            {
                EnText.AppendFormat("{0:x2}", Byte);
            }
            return EnText.ToString();
        }
        public static string UserNameEncrypt()
        {
            return MD5_32("admin");
        }
        public static string PwdEncrypt()
        {
            return MD5_32("hangch");
        }

    }

    public class ModuleRight
    {
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
    }
}