using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrapeCity.ActiveReports.Export.Word.Section;
using GrapeCity.ActiveReports;
using Edge.Web.Tools;

namespace Edge.Web
{
    /// <summary>
    /// ARExport 的摘要说明
    /// </summary>
    public class ARExport : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            SectionReport rpt = new SectionReport();
            var key = context.Request["exporttype"];
            switch (key)
            {
                case "Word":
                    ExportWord(context, rpt);
                    break;
               
            }
        }


        private void ExportWord(HttpContext context, SectionReport rpt)
        {
            context.Response.ContentType = "application/msword";
            context.Response.Clear();
            context.Response.HeaderEncoding = System.Text.Encoding.Default;
            context.Response.AddHeader("content-disposition", "attachment;test.doc");
            var word = new RtfExport();
            var memStream = new System.IO.MemoryStream();
            word.Export(rpt.Document, memStream);
            context.Response.BinaryWrite(memStream.ToArray());
            context.Response.End();
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