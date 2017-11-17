using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.DeliveryOrderManagement
{
    public partial class Print : PageBase
    {
        #region 全局变量0;
        protected string ids = "";
        //英文Url
        protected string enusUrl = "\\DeliveryOrderManagement\\rptDeliveryOrderManagementByEnglish.rpx";
        //中文简体Url
        protected string zhcnUrl = "\\DeliveryOrderManagement\\rptDeliveryOrderManagement.rpx";
        //中文繁体Url
        protected string zhhkUrl = "\\DeliveryOrderManagement\\rptDeliveryOrderManagementByTraditional.rpx";
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
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    LoadReport(ids);

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
        private void LoadReport(string ids)
        {
            string url = "";

            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us": url = enusUrl; break;
                case "zh-cn": url = zhcnUrl; break;
                case "zh-hk": url = zhhkUrl; break;
            }

            reportTool.LoadReport(ids, WebViewerDeliveryOrderList, url, webset.WebName, "DeliveryOrderManagement");
        }
    }
}