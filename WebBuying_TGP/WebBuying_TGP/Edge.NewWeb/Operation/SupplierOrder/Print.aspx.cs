using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;
using GrapeCity.ActiveReports;
using Edge.Web.Controllers.Operation.SupplierOrder;
using System.Drawing;
using GrapeCity.ActiveReports.Web.Controls;
namespace Edge.Web.Operation.SupplierOrder
{
    public partial class Print : PageBase
    {
        #region 全局公用变量
        // 报表运行的总高度
        public float TotalOfHeight = 0;
        /// <summary>
        /// 交易编号
        /// </summary>
        protected string ids = "";
        /// <summary>
        /// 页面地址
        /// </summary>
        //英文Url
        protected string enusUrl = "\\SupplierOrder\\rptSupplierOrderByEnglish.rpx";
        //中文简体Url
        protected string zhcnUrl = "\\SupplierOrder\\rptSupplierOrder.rpx";
        //中文繁体Url
        protected string zhhkUrl = "\\SupplierOrder\\rptSupplierOrderByTraditional.rpx";
        #endregion

        #region 公用业务逻辑类
        SupplierOrderController controller = new SupplierOrderController();
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
                    hidID.Value = ids;
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
        /// 创建时间：2015-11-30
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
            reportTool.LoadReport(ids, WebViewerSupplierOrderList, url, webset.WebName, "SupplierOrder");
        }
    }
}