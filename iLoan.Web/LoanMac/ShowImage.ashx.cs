using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using LoanMac.Core;
using LoanMac.Core.Model;
using LoanMac.Core.Service;

namespace LoanMac.Web
{
    /// <summary>
    /// Summary description for ShowImage
    /// </summary>
    public class ShowImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            Int32 userId;
            if (context.Request.QueryString["id"] != null)
                userId = Convert.ToInt32(context.Request.QueryString["id"]);
            else
                throw new ArgumentException("No parameter specified");

            context.Response.ContentType = "image/jpeg";
            Stream strm = ShowEmpImage(userId);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            } 
        }

        public Stream ShowEmpImage(int userId)
        {

            try
            {

                UserEntity newEntity = new UserEntity();
                UserService newService = new UserService();

                newEntity = newService.GetOne(userId);

                return new MemoryStream(newEntity.Picture);
            }
            catch
            {
                return null;
            }
            finally
            {

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