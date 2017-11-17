using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Edge.Web.Tools
{
    public class ExportTool
    {
        public static bool ExportStream(Stream stream, string filename)
        {
            try
            {
                if (stream == null) return false;

                if (stream.Position > 0)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                }

                long fileSize = stream.Length;
                byte[] buffer = new byte[fileSize];
                stream.Read(buffer, 0, buffer.Length);

                HttpContext.Current.Response.ClearContent();

                HttpContext.Current.Response.ContentType = "application/octet-stream";

                //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8));
                HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filename, Encoding.UTF8).ToString());
                HttpContext.Current.Response.AddHeader("Content-Length", fileSize.ToString());

                HttpContext.Current.Response.BinaryWrite(buffer);

                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.Close();

                return true;
            }
            catch (Exception ex)
            {
                Edge.Web.Tools.Logger.Instance.WriteErrorLog(" Export ","",ex);
                return false;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

        public static bool ExportFile(string fileName)
        {
            System.IO.FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //ExportStream(fs, fileName.Substring(fileName.LastIndexOf("\\") + 1));
            ExportStream(fs, Path.GetFileName(fileName));
            return true;
        }
        public static bool ExportFile(string fileName,string exportFileName)
        {
            System.IO.FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            
            ExportStream(fs, exportFileName);
            return true;
        }

        public static string GetFullName(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath) + "Export\\";

            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

            string fullName = path + fileName;

            return fullName;
        }

    }
}