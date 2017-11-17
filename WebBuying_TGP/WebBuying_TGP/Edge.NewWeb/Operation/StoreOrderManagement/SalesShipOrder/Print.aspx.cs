using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.StoreOrderManagement.SalesShipOrder
{
    public partial class Print : PageBase
    {
        #region 全局变量
        //订单类型
        protected int orderType = 0;
        protected string ids = "";
        string url = "";
        string language = "";
        ////英文Url
        //protected string enusUrl = "\\StoreOrderManagement\\SalesShipOrder\\rptSalesShipOrderByEnglish.rpx";
        ////中文简体Url
        //protected string zhcnUrl = "\\StoreOrderManagement\\SalesShipOrder\\rptSalesShipOrder.rpx";
        ////中文繁体Url
        //protected string zhhkUrl = "\\StoreOrderManagement\\SalesShipOrder\\rptSalesShipOrderByTraditional.rpx";
        //英文Url
        protected string enusUrl = @"~\Reports\StoreOrderManagement\SalesShipOrder\SalesShipOrder.rdlx";
        //中文简体Url
        protected string zhcnUrl = @"~\Reports\StoreOrderManagement\SalesShipOrder\SalesShipOrder.rdlx";
        //中文繁体Url
        protected string zhhkUrl = @"~\Reports\StoreOrderManagement\SalesShipOrder\SalesShipOrder.rdlx";
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
                    int orderType = Convert.ToInt32(Request.Params["orderType"]);
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    //LoadReport(ids, orderType);
                    LoadReprots(ids);
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Pirnt " + ex);
                    Response.Write(ex.Message);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }

        }
        /// <summary>
        /// 加载报表
        /// 创建人：王丽
        /// 创建时间：2016-09-06
        /// </summary>
        /// <param name="ids"></param>
        private void LoadReport(string ids, int orderType)
        {
            string url = "";
            if (orderType == 0)
            {
                switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                {
                    case "en-us": url = enusUrl; break;
                    case "zh-cn": url = zhcnUrl; break;
                    case "zh-hk": url = zhhkUrl; break;
                }
            }
            else
            {
                switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                {
                    case "en-us": url = enusUrl; break;
                    case "zh-cn": url = zhcnUrl; break;
                    case "zh-hk": url = zhhkUrl; break;
                }
            }
            reportTool.LoadReport(ids, WebViewerShipmentSalesShipOrderList, url, webset.WebName, "SalesShipOrder");
        }
        public void LoadReprots(string ids)
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
            GrapeCity.ActiveReports.PageReport report = new GrapeCity.ActiveReports.PageReport();
            // 加载报表布局
            report.Load(new System.IO.FileInfo(Server.MapPath(url)));
            report.Report.ReportParameters[0].DefaultValue.Values.Add(ids);
            WebViewerShipmentSalesShipOrderList.ViewerType = GrapeCity.ActiveReports.Web.ViewerType.FlashViewer;
            WebViewerShipmentSalesShipOrderList.Report = report;
            WebViewerShipmentSalesShipOrderList.FlashViewerOptions.PrintOptions.StartPrint = true;

        }
    }
}