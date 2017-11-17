using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Edge.Common;
using System.IO;
using Edge.Web.Tools;

namespace Edge.Web.Ashx
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    public class SingleUpload : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //检查是否登录后上传操作
            //if (!new ManagePage().IsAdminLogin())
            //{
            //    context.Response.Write("{\"msg\": 0, \"msbox\": \"请登录后再进行上传文件！\"}");
            //    return;
            //}
            string _refilepath = context.Request.QueryString["ReFilePath"]; //取得返回的对象名称
            string _upfilepath = context.Request.QueryString["UpFilePath"]; //取得上传的对象名称
            string _savefilesubpath = context.Request.QueryString["SaveFileSubPath"];////取得保存文件的子目录
            HttpPostedFile _upfile = context.Request.Files[_upfilepath];
            string _delfile = context.Request.Params[_refilepath];

            if (_upfile == null)
            {
                
                context.Response.Write(string.Format("{\"msg\": 0, \"msbox\": \"{0}\"}",Resources.MessageTips.SelectUploadFile));
                return;
            }
            UpLoad upFiles = new UpLoad();
            string msg = upFiles.fileSaveAs(_upfile, _savefilesubpath);
            //删除已存在的旧文件
            if (!string.IsNullOrEmpty(_delfile))
            {
                string _filename = Edge.Common.Utils.GetMapPath(_delfile);
                if (System.IO.File.Exists(_filename))
                {
                    System.IO.File.Delete(_filename);
                }
            }
            //返回成功信息
            context.Response.Write(msg);
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
