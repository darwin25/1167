using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Utils.Tools
{
    public class ConstUtil
    {
        /// <summary>
        /// /UpLoadFiles/
        /// </summary>
        static readonly string UpLoadFileRoot = "/UpLoadFiles/Images/CardGrade/";
        /// <summary>
        /// /UpLoadFiles/Template/
        /// </summary>
        static readonly string UpLoadFileTemplate = "/UpLoadFiles/Template/";
        /// <summary>
        /// 
        /// </summary>
        static readonly string UpLoadFileImage = "/UpLoadFiles/Images/CardGrade/";

        public static string CreateServerTemplatePath(string uploadFile)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(UpLoadFileTemplate);
            sb.Append(DateTime.Now.Ticks);
            sb.Append("_");
            sb.Append(uploadFile);
            return sb.ToString();
        }
    }
}
