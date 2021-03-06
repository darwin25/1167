﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.StoreOrderManagement.PickingStoreOrder
{
    /// <summary>
    /// 总部拣货单打印
    /// 创建人：Lisa
    /// 创建时间：2016-02-29
    /// </summary>
    public partial class Print : PageBase
    {
        #region 全局变量
        //订单类型
        protected int orderType = 0;
        protected string ids = "";
        //英文Url
        protected string enusUrl = "\\StoreOrderManagement\\PickingStoreOrder\\rptPickingStoreOrderByEnglish.rpx";
        //中文简体Url
        protected string zhcnUrl = "\\StoreOrderManagement\\PickingStoreOrder\\rptPickingStoreOrder.rpx";
        //中文繁体Url
        protected string zhhkUrl = "\\StoreOrderManagement\\PickingStoreOrder\\rptPickingStoreOrderByTraditional.rpx";
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
                    string ids = Request.Params["ids"];
                    int orderType = Convert.ToInt32(Request.Params["orderType"]);
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    LoadReport(ids, orderType);

                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Print " + ex);
                    Response.Write(ex.Message);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }

        }
        /// <summary>
        /// 加载报表
        /// 创建人：王丽
        /// 创建时间：2016-02-29
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
            reportTool.LoadReport(ids, WebViewerPickingStoreOrder, url, webset.WebName, "PickingStoreOrder");
        }
    }
}