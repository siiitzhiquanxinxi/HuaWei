using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace DTcms.Web.admin.Material
{
    /// <summary>
    /// photo 的摘要说明
    /// </summary>
    public class photo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // Set up the response settings
            context.Response.ContentType = "image/jpg";
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.BufferOutput = false;
            string photoId ="";
            Stream stream = null;
            if (context.Request.QueryString["ID"] != null && context.Request.QueryString["ID"] != "")
            {
                photoId = context.Request.QueryString["ID"];
                stream = GetPhoto(photoId);
            }
            const int buffersize = 1024 * 16;
            byte[] buffer = new byte[buffersize];
            int count = stream.Read(buffer, 0, buffersize);
            while (count > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, count);
                count = stream.Read(buffer, 0, buffersize);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public Stream GetPhoto(string Id)
        {
            BLL.sy_material bll = new BLL.sy_material();
            Model.sy_material model = bll.GetModel(Id);
            return new MemoryStream(model.Pic);
        }

    }
}