using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web
{
    public partial class Test : PageBase
    {
        #region 全局变量
        string url = "";
        string language = "";
        protected string ids = "";

        //英文Url
        protected string enusUrl = @"~\Reports\test\rptBarcodeDisplay.rdlx";
        //中文简体Url
        protected string zhcnUrl = @"~\Reports\test\rptInvoice2.rdlx";
        //中文繁体Url
        protected string zhhkUrl = @"~\Reports\test\rptMasterDetails.rdlx";
        #endregion

        #region 公用业务逻辑类
        //ActiveReportsTool reportTool = new ActiveReportsTool();
        Edge.SVA.BLL.BUY_CURRENCY currencyBll = new SVA.BLL.BUY_CURRENCY();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (!hasRight)
                    {
                        return;
                    }
                    LoadReport();

                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "ExPort " + ex);
                    Response.Write(ex.Message);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }

        }
        /// <summary>
        /// 加载报表
        /// 创建人：王丽
        /// 创建时间：2015-11-30
        /// </summary>
        /// <param name="ids"></param>
        private void LoadReport()
        {

            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    url = enusUrl;
                    language = "en-us";
                    break;
                case "zh-cn":
                    url = zhcnUrl;
                    language = "zh-cn";
                    break;
                case "zh-hk":
                    url = zhhkUrl;
                    language = "zh-hk";
                    break;
            }

            hidUrl.Value = url;
            hidlanguage.Value = language;
            GrapeCity.ActiveReports.PageReport report = new GrapeCity.ActiveReports.PageReport();
            //加载报表布局
            report.Load(new System.IO.FileInfo(Server.MapPath(url)));
            WebViewerDeliveryOrderList.ViewerType = GrapeCity.ActiveReports.Web.ViewerType.FlashViewer;
            WebViewerDeliveryOrderList.Report = report;
            WebViewerDeliveryOrderList.FlashViewerOptions.PrintOptions.StartPrint = false;
        }
        #region 导出
        /// <summary>
        /// word文档导出
        /// 创建人：王丽
        /// 创建时间：2015-11-30
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnWord_Click(object sender, EventArgs e)
        {
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    url = enusUrl;
                    language = "en-us";
                    break;
                case "zh-cn":
                    url = zhcnUrl;
                    language = "zh-cn";
                    break;
                case "zh-hk":
                    url = zhhkUrl;
                    language = "zh-hk";
                    break;
            }
            hidUrl.Value = url;
            hidlanguage.Value = language;
            GrapeCity.ActiveReports.PageReport report = new GrapeCity.ActiveReports.PageReport();
            report.Load(new System.IO.FileInfo(Server.MapPath(url)));

            GrapeCity.ActiveReports.Document.PageDocument _reportRuntime = new GrapeCity.ActiveReports.Document.PageDocument(report);

            // Create an output directory
            System.IO.MemoryStream ms = new System.IO.MemoryStream();


            // Provide settings for your rendering output.
            GrapeCity.ActiveReports.Export.Word.Page.Settings wordSetting = new
            GrapeCity.ActiveReports.Export.Word.Page.Settings();
            wordSetting.UseMhtOutput = true;
            GrapeCity.ActiveReports.Extensibility.Rendering.ISettings setting = wordSetting;

            //Set the rendering extension and render the report.
            GrapeCity.ActiveReports.Export.Word.Page.WordRenderingExtension wordRenderingExtension =
            new GrapeCity.ActiveReports.Export.Word.Page.WordRenderingExtension();
            GrapeCity.ActiveReports.Rendering.IO.MemoryStreamProvider outputProvider = new GrapeCity.ActiveReports.Rendering.IO.MemoryStreamProvider();
            _reportRuntime.Render(wordRenderingExtension, outputProvider, wordSetting);
            string exportlanguage = "";
            if (Request.Form["hidlanguage"] == "en-us")
            {
                exportlanguage = "Test";
            }
            else if (Request.Form["hidlanguage"] == "zh-cn")
            {
                exportlanguage = "测试";
            }
            else
            {
                exportlanguage = "測試";
            }
            Response.ContentType = "application/msword";
            Response.AddHeader("content-disposition", Server.UrlPathEncode("attachment;filename=" + exportlanguage + ".doc"));
            outputProvider.GetPrimaryStream().OpenStream().CopyTo(ms);
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
        #endregion


    }
}