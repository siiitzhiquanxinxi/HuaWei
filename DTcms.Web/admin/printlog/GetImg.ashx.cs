using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
namespace DTcms.Web.admin.printlog
{
    /// <summary>
    /// GetImg 的摘要说明
    /// </summary>
    public class GetImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request["id"];
            DTcms.Model.u_printlog printlog = new BLL.u_printlog().GetModel(int.Parse(id));
            if (printlog != null)
            {
                MemoryStream stream;
                if (context.Request["type"].ToString() == "face")
                {
                    stream = new MemoryStream(printlog.PicIDcardFace);
                    context.Response.ContentType = "image/bmp";
                    context.Response.ClearContent();
                    context.Response.BinaryWrite(stream.ToArray());
                }
                else if (context.Request["type"].ToString() == "finger")
                {
                    stream = new MemoryStream(printlog.PicFinger);
                    context.Response.ContentType = "image/bmp";
                    context.Response.ClearContent();
                    context.Response.BinaryWrite(stream.ToArray());
                }
                else if (context.Request["type"].ToString() == "rgb")
                {
                    stream = new MemoryStream(printlog.PicFaceRGB);
                    context.Response.ContentType = "image/jpeg";
                    context.Response.ClearContent();
                    context.Response.BinaryWrite(stream.ToArray());
                }
                else if (context.Request["type"].ToString() == "ir")
                {
                    stream = new MemoryStream(printlog.PicFaceIR);
                    context.Response.ContentType = "image/jpeg";
                    context.Response.ClearContent();
                    context.Response.BinaryWrite(stream.ToArray());
                }
            }
        }

        /// <summary>
        /// 字节数组转换为图片
        /// </summary>
        /// <param name="buffer">字节数组</param>
        /// <returns>图片</returns>
        private System.Drawing.Image BytesToImage(Byte[] buffer)
        {
            try
            {
                var ms = new MemoryStream(buffer, 0, buffer.Length);
                var bf = new BinaryFormatter();
                object obj = bf.Deserialize(ms);
                ms.Close();
                return (System.Drawing.Image)obj;
            }
            catch (Exception ex)
            {
                string exx = ex.ToString();
                throw;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}