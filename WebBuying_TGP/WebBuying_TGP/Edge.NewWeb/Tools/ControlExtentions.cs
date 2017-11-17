using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edge.Web.Tools
{
    public static class ControlExtentions
    {
        public static string uploadPath = "~/UploadFiles/";
        public static string SaveToServer(this FineUI.FileUpload fileUpload, string subPath)
        {
            string UploadFilePath =string.Empty;
            if (!fileUpload.HasFile || string.IsNullOrEmpty(fileUpload.ShortFileName)) return fileUpload.FileName;//(modify by Len) //return fileUpload.Text; 

            if (subPath.StartsWith("/")) subPath = subPath.Substring(1);
            if (!subPath.EndsWith("/")) subPath = subPath + "/";

            UploadFilePath = System.Web.HttpContext.Current.Server.MapPath(uploadPath + subPath);

            string fileName = fileUpload.ShortFileName;
            string fileExt = fileName.Substring(fileName.LastIndexOf("."));
            fileName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") +  fileExt;


            if (!System.IO.Directory.Exists(UploadFilePath))
            {
                System.IO.Directory.CreateDirectory(UploadFilePath);
            }

            fileUpload.SaveAs(UploadFilePath + fileName);

            return (uploadPath+subPath + fileName).Substring(1);
        }
        /// <summary>
        /// 用于广告界面上传附件到服务器
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <param name="subPath"></param>
        /// <returns></returns>
        /// <author>Len</author>
        public static string SaveAttachFileToServer(this FineUI.FileUpload fileUpload, string subPath)
        {
            string UploadFilePath = string.Empty;
            if (!fileUpload.HasFile || string.IsNullOrEmpty(fileUpload.ShortFileName)) return fileUpload.FileName;//(modify by Len) //return fileUpload.Text;

            if (subPath.StartsWith("/")) subPath = subPath.Substring(1);
            if (!subPath.EndsWith("/")) subPath = subPath + "/";

            UploadFilePath = System.Web.HttpContext.Current.Server.MapPath(uploadPath + subPath);

            string fileName = fileUpload.ShortFileName;

            if (!System.IO.Directory.Exists(UploadFilePath))
            {
                System.IO.Directory.CreateDirectory(UploadFilePath);
            }

            if (System.IO.File.Exists(UploadFilePath + fileName))
            {
                fileName = DateTime.Now.Second.ToString() + fileName;
            }

            fileUpload.SaveAs(UploadFilePath + fileName);

            return (uploadPath + subPath + fileName).Substring(1);
        }
      
    }
}