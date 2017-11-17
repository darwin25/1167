using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing.Imaging;
using System.Web.SessionState;
using Edge.Web.Tools;

namespace Edge.Web.Ashx
{
    /// <summary>
    /// Summary description for ValidateCode
    /// </summary>
    public class ValidateCode : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            int width = 200;
            int height = 30;

            try
            {
                width = Convert.ToInt32(context.Request.QueryString["w"]);
                height = Convert.ToInt32(context.Request.QueryString["h"]);
            }
            catch (Exception)
            {
                // Nothing
            }

            // 从 Session 中读取验证码，并创建图片
            CaptchaImage.CaptchaImage ci = new CaptchaImage.CaptchaImage(SVASessionInfo.CheckCode, width, height, "Consolas");

            // 输出图片
            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";

            ci.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);

            ci.Dispose();
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