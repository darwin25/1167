using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;
using Edge.DBUtility;

namespace Edge.Web.Operation.StoreOrderManagement.SalesPickOrder
{
    public partial class Export : PageBase
    {
        #region 全局变量
        protected int orderType = 0;
        string url = "";
        string language = "";
        protected string ids = "";
        protected string cardnumbers = "";
        //英文Url
        protected string enusUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrderByEnglish.rdlx";
        //中文简体Url
        protected string zhcnUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder.rdlx";
        //中文繁体Url
        protected string zhhkUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrderByTraditional.rdlx";

        #endregion

        #region 公用业务逻辑类
        ActiveReportsTool reportTool = new ActiveReportsTool();
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
                    ids = Request.Params["ids"];
                    cardnumbers = Request.Params["cardnumbers"];
                    hidIds.Value = ids;
                    orderType = Convert.ToInt32(Request.Params["orderType"]);
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    LoadReprots(ids, orderType);

                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "ExPort " + ex);
                    Response.Write(ex.Message);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }

        }
        protected void ddlShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            //订单
            if (ddlShow.SelectedValue == "1")
            {
                enusUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrderByEnglish.rdlx";
                zhcnUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder.rdlx";
                zhhkUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrderByTraditional.rdlx";
            }
            //会员
            else if (ddlShow.SelectedValue == "2")
            {
                enusUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_MemberByEnglish.rdlx";
                zhcnUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_Member.rdlx";
                zhhkUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_MemberByTraditional.rdlx";
            }
            //产品编号
            else
            {
                enusUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_ProdCodeByEnglish.rdlx";
                zhcnUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_ProdCode.rdlx";
                zhhkUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_ProdCodeByTraditional.rdlx";
            }
            LoadReprots(Request.Form["hidIds"], orderType);
        }
        /// <summary>
        /// 加载报表
        /// 创建人：王丽
        /// 创建时间：2016-09-06
        /// </summary>
        /// <param name="ids"></param>
        public void LoadReprots(string ids, int orderType)
        {

            if (orderType == 0)
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
            }
            else
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
            }
            hidUrl.Value = url;
            hidlanguage.Value = language;
            GrapeCity.ActiveReports.PageReport report = new GrapeCity.ActiveReports.PageReport();
            //加载报表布局
            report.Load(new System.IO.FileInfo(Server.MapPath(url)));
            foreach (string id in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                report.Report.ReportParameters[0].DefaultValue.Values.Add(id);
            }
            WebViewerShipmentSalesPickOrderList.ViewerType = GrapeCity.ActiveReports.Web.ViewerType.FlashViewer;
            WebViewerShipmentSalesPickOrderList.Report = report;
            WebViewerShipmentSalesPickOrderList.FlashViewerOptions.PrintOptions.StartPrint = false;
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
            //订单
            if (ddlShow.SelectedValue == "1")
            {
                enusUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrderByEnglish.rdlx";
                zhcnUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder.rdlx";
                zhhkUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrderByTraditional.rdlx";
            }
            //会员
            else if (ddlShow.SelectedValue == "2")
            {
                enusUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_MemberByEnglish.rdlx";
                zhcnUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_Member.rdlx";
                zhhkUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_MemberByTraditional.rdlx";
            }
            //产品编号
            else
            {
                enusUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_ProdCodeByEnglish.rdlx";
                zhcnUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_ProdCode.rdlx";
                zhhkUrl = @"~\Reports\StoreOrderManagement\SalesPickOrder\SalesPickOrder_ProdCodeByTraditional.rdlx";
            }
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
            ids = Request.Form["hidIds"];
            foreach (string id in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                report.Report.ReportParameters[0].DefaultValue.Values.Add(id);
            }
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
                exportlanguage = "SalesPickOrder";
            }
            else if (Request.Form["hidlanguage"] == "zh-cn")
            {
                exportlanguage = "拣货单";
            }
            else
            {
                exportlanguage = "揀貨單";
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