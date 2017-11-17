using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.StockTake
{
    public partial class Print : PageBase
    {
        #region 全局变量
        //订单类型
        protected int orderType = 0;
        protected string ids = "";
        protected string ControlName = "";
        protected string types = "";
        //英文Url
        protected string enusUrl = "";
        //中文简体Url
        protected string zhcnUrl = "";
        //中文繁体Url
        protected string zhhkUrl = "";
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
                    orderType = Convert.ToInt32(Request.Params["orderType"]);
                    types = Request.Params["types"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    if (!string.IsNullOrEmpty(types))
                    {
                        //盘点一
                        if (types == "StockTake01")
                        {
                            enusUrl = "\\StockTake\\rptStockTake01ByEnglish.rpx";
                            zhcnUrl = "\\StockTake\\rptStockTake01.rpx";
                            zhhkUrl = "\\StockTake\\rptStockTake01ByTraditional.rpx";
                        }
                        //盘点二
                        else if (types == "StockTake02")
                        {
                            enusUrl = "\\StockTake\\rptStockTake02ByEnglish.rpx";
                            zhcnUrl = "\\StockTake\\rptStockTake02.rpx";
                            zhhkUrl = "\\StockTake\\rptStockTake02ByTraditional.rpx";
                        }
                        // 差异
                        else
                        {
                            enusUrl = "\\StockTake\\rptStockTakeVARByEnglish.rpx";
                            zhcnUrl = "\\StockTake\\rptStockTakeVAR.rpx";
                            zhhkUrl = "\\StockTake\\rptStockTakeVARByTraditional.rpx";
                        }
                    }
                    LoadReport(ids, orderType, types);

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
        /// 创建时间：2015-12-02
        /// </summary>
        /// <param name="ids"></param>
        private void LoadReport(string ids, int orderType, string types)
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
            if (types == "StockTake01")
            {
                ControlName = "StockTake01";
                reportTool.LoadReport(ids, WebViewerStockTake, url, webset.WebName, ControlName);
            }
            else if (types == "StockTake02")
            {
                ControlName = "StockTake02";
                reportTool.LoadReport(ids, WebViewerStockTake, url, webset.WebName, ControlName);
            }
            else
            {
                ControlName = "StockTakeVAR";
                reportTool.LoadReport(ids, WebViewerStockTake, url, webset.WebName, ControlName);
            }
        }
    }
}