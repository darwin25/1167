using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrapeCity.ActiveReports;
using System.Data;
using GrapeCity.ActiveReports.SectionReportModel;
using Edge.Web.Tools;
using FineUI;
using Edge.Web.Controllers.Operation.SupplierOrder;
using System.Text;
using GrapeCity.ActiveReports.Web.Controls;
using GrapeCity.ActiveReports.Export.Word.Section;
using System.IO;
using System.Runtime.InteropServices;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.Web.Operation.DeliveryOrderManagement
{
    public partial class Export : PageBase
    {
        #region 全局变量
        // 当前预览的报表
        SectionReport rpt;
        // 报表运行的总高度
        public float TotalOfHeight = 0;
        string url = "";
        string language = "";
        protected string ids = "";
        ////英文Url
        //protected string enusUrl = "\\DeliveryOrderManagement\\rptDeliveryOrderManagementByEnglish.rpx";
        ////中文简体Url
        //protected string zhcnUrl = "\\DeliveryOrderManagement\\rptDeliveryOrderManagement.rpx";
        ////中文繁体Url
        //protected string zhhkUrl = "\\DeliveryOrderManagement\\rptDeliveryOrderManagementByTraditional.rpx";

        //英文Url
        protected string enusUrl = @"~\Reports\DeliveryOrderManagement\DeliveryOrderManagementByEnglish.rdlx";
        //中文简体Url
        protected string zhcnUrl = @"~\Reports\DeliveryOrderManagement\DeliveryOrderManagement.rdlx";
        //中文繁体Url
        protected string zhhkUrl = @"~\Reports\DeliveryOrderManagement\DeliveryOrderManagementByTraditional.rdlx";
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
                    string ids = Request.Params["ids"];
                    hidIds.Value = ids;
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
            foreach (string id in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                report.Report.ReportParameters[0].DefaultValue.Values.Add(id);
                Edge.SVA.Model.BUY_CURRENCY currency = currencyBll.GetCurrencyByType(1);
                if (currency != null)
                {
                    report.Report.ReportParameters[1].DefaultValue.Values.Add(currency.CurrencyCode);
                }
                List<GetMemberTxn> MemberTxnList = ControlTool.GetMemberTxnList(id);
                if (MemberTxnList != null && MemberTxnList.Count > 0)
                {
                    foreach (var item in MemberTxnList)
                    {
                        report.Report.ReportParameters[2].DefaultValue.Values.Add(item.BillContact);
                        report.Report.ReportParameters[3].DefaultValue.Values.Add(item.MemberEmail);
                        report.Report.ReportParameters[4].DefaultValue.Values.Add(item.BillAddress);
                        report.Report.ReportParameters[5].DefaultValue.Values.Add(item.BillContactPhone);
                        if (!string.IsNullOrEmpty(item.Freight))
                        {
                            report.Report.ReportParameters[6].DefaultValue.Values.Add(item.Freight);
                        }
                        else
                        {
                            report.Report.ReportParameters[6].DefaultValue.Values.Add("0.00");
                        }
                        if (!string.IsNullOrEmpty(item.RewardPoints))
                        {
                            report.Report.ReportParameters[7].DefaultValue.Values.Add(item.RewardPoints);
                        }
                        else
                        {
                            report.Report.ReportParameters[7].DefaultValue.Values.Add("0.00");
                        }
                    }
                }
                List<GetSalesTByTxnNo> SalesTByTxnNoList = ControlTool.GetSalesTByTxnNo(id);
                if (SalesTByTxnNoList != null && SalesTByTxnNoList.Count > 0)
                {
                    foreach (var item2 in SalesTByTxnNoList)
                    {
                        if (item2.TenderCode == "VC")
                        {
                            report.Report.ReportParameters[8].DefaultValue.Values.Add(item2.Additional);
                            string LocalAmount = String.Format("{0:F}", item2.LocalAmount);//默认为保留两位item.LocalAmount;
                            report.Report.ReportParameters[9].DefaultValue.Values.Add(LocalAmount.ToString());
                        }
                        if (item2.TenderCode != "VC")
                        {
                            report.Report.ReportParameters[10].DefaultValue.Values.Add(item2.TenderName);
                        }
                       
                    }
                }

            }

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

            ids = Request.Form["hidIds"];
            foreach (string id in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                report.Report.ReportParameters[0].DefaultValue.Values.Add(id);
                Edge.SVA.Model.BUY_CURRENCY currency = currencyBll.GetCurrencyByType(1);
                if (currency != null)
                {
                    report.Report.ReportParameters[1].DefaultValue.Values.Add(currency.CurrencyCode);
                }
                List<GetMemberTxn> MemberTxnList = ControlTool.GetMemberTxnList(id);
                if (MemberTxnList != null && MemberTxnList.Count > 0)
                {
                    foreach (var item in MemberTxnList)
                    {
                        report.Report.ReportParameters[2].DefaultValue.Values.Add(item.BillContact);
                        report.Report.ReportParameters[3].DefaultValue.Values.Add(item.MemberEmail);
                        report.Report.ReportParameters[4].DefaultValue.Values.Add(item.BillAddress);
                        report.Report.ReportParameters[5].DefaultValue.Values.Add(item.BillContactPhone);
                        if (!string.IsNullOrEmpty(item.Freight))
                        {
                            report.Report.ReportParameters[6].DefaultValue.Values.Add(item.Freight);
                        }
                        else
                        {
                            report.Report.ReportParameters[6].DefaultValue.Values.Add("0.00");
                        }
                        if (!string.IsNullOrEmpty(item.RewardPoints))
                        {
                            report.Report.ReportParameters[7].DefaultValue.Values.Add(item.RewardPoints);
                        }
                        else
                        {
                            report.Report.ReportParameters[7].DefaultValue.Values.Add("0.00");
                        }
                    }
                }
                List<GetSalesTByTxnNo> SalesTByTxnNoList = ControlTool.GetSalesTByTxnNo(id);
                if (SalesTByTxnNoList != null && SalesTByTxnNoList.Count > 0)
                {
                    foreach (var item2 in SalesTByTxnNoList)
                    {
                        if (item2.TenderCode == "VC")
                        {
                            report.Report.ReportParameters[8].DefaultValue.Values.Add(item2.Additional);
                            string LocalAmount = String.Format("{0:F}", item2.LocalAmount);//默认为保留两位item.LocalAmount;
                            report.Report.ReportParameters[9].DefaultValue.Values.Add(LocalAmount.ToString());
                        }
                        if (item2.TenderCode != "VC")
                        {
                            report.Report.ReportParameters[10].DefaultValue.Values.Add(item2.TenderName);
                        }

                    }
                }
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
                exportlanguage = "SalesOrder";
            }
            else if (Request.Form["hidlanguage"] == "zh-cn")
            {
                exportlanguage = "销售单";
            }
            else
            {
                exportlanguage = "銷售單";
            }
            Response.ContentType = "application/msword";
            Response.AddHeader("content-disposition", Server.UrlPathEncode("attachment;filename=" + exportlanguage + ".doc"));
            outputProvider.GetPrimaryStream().OpenStream().CopyTo(ms);
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
        #endregion

        #region 事件
        // 累加当前区域的高度
        void item_AfterPrint(object sender, EventArgs e)
        {
            float height = (sender as Section).Height;

            TotalOfHeight += height;
        }

        // 为当前页设置正确的高度值
        void rpt_ReportEnd(object sender, EventArgs e)
        {
            // 在报表运行结束之后调整最后一页的高度
            SectionReport rpt = (sender as SectionReport);
            rpt.Document.Pages[rpt.Document.Pages.Count - 1].Height = TotalOfHeight - (rpt.Document.Pages.Count - 1) * rpt.PageSettings.PaperWidth;
        }
        #endregion

        #region 检查文件是否已经打开
        [DllImport("kernel32.dll")]
        private static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);
        private const int OF_READWRITE = 2;
        private const int OF_SHARE_DENY_NONE = 0x40;
        private readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        /// <summary>   
        /// 检查文件是否已经打开   
        /// </summary>   
        /// <param name="strfilepath">要检查的文件路径</param>          
        /// <returns>-1文件不存在,1文件已经打开,0文件可用未打开</returns>   
        private int VerifyFileIsOpen(string strfilepath)
        {
            string vFileName = strfilepath;

            // 先检查文件是否存在,如果不存在那就不检查了   
            if (!System.IO.File.Exists(vFileName))
            {
                return -1;
            }

            // 打开指定文件看看情况   
            IntPtr vHandle = _lopen(vFileName, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            { // 文件已经被打开                   
                return 1;
            }
            CloseHandle(vHandle);

            // 说明文件没被打开，并且可用  

            return 0;
        }
        #endregion
    }
}