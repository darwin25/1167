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

namespace Edge.Web.Operation.SupplierOrderReceive
{
    public partial class Export : PageBase
    {
        #region 全局变量
        //订单类型
        // 当前预览的报表
        SectionReport rpt;
        // 报表运行的总高度
        public float TotalOfHeight = 0;
        string language = "";
        string url = "";
        protected int orderType = 0;
        protected string ids = "";
        //英文Url
        protected string enusUrl = "\\SupplierOrderReceive\\rptSupplierOrderReceiveByEnglish.rpx";
        //中文简体Url
        protected string zhcnUrl = "\\SupplierOrderReceive\\rptSupplierOrderReceive.rpx";
        //中文繁体Url
        protected string zhhkUrl = "\\SupplierOrderReceive\\rptSupplierOrderReceiveByTraditional.rpx";
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
                    hidIds.Value = ids;
                    orderType = Convert.ToInt32(Request.Params["orderType"]);
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    LoadReport(ids, orderType);

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
        private void LoadReport(string ids, int orderType)
        {
            string url = "";
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
            reportTool.LoadReport(ids, WebViewerSupplierOrderReceive, url, webset.WebName, "SupplierOrderReceive");
        }

        #region 导出
        /// <summary>
        /// word文档导出
        /// 创建人：王丽
        /// 创建时间：2015-12-02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnWord_Click(object sender, EventArgs e)
        {
           
            this.WebViewerSupplierOrderReceive.FlashViewerOptions.ResourceLocale = Request.Form["hidlanguage"];
            rpt = new SectionReport();
            TotalOfHeight = 0;

            // 针对不同模板，只需修改报表名称即可
            System.Xml.XmlTextReader xtr = new System.Xml.XmlTextReader(Server.MapPath("\\Reports") + Request.Form["hidUrl"]);
            rpt.LoadLayout(xtr);
            xtr.Close();
            rpt.Document.Printer.PrinterName = "";

            // 计算所有区域的总高度
            foreach (Section item in rpt.Sections)
            {
                // 先计算只显示一次的区域
                if (item is ReportHeader || item is ReportFooter || item is PageHeader || item is PageFooter)
                {
                    TotalOfHeight += item.Height;
                }

                if (item is GroupHeader || item is GroupFooter || item is Detail)
                {
                    item.Format += new EventHandler(item_AfterPrint);
                }

            }


            rpt.ReportEnd += new EventHandler(rpt_ReportEnd);
            rpt.DataSource = reportTool.GetDataBind(Request.Form["hidIds"], webset.WebName, "SupplierOrderReceive");
            rpt.DataMember = "";
            rpt.Run();
            WebViewerSupplierOrderReceive.Report = rpt;
            GrapeCity.ActiveReports.Export.Word.Section.RtfExport rtfExport1 = new
GrapeCity.ActiveReports.Export.Word.Section.RtfExport();
            string exportlanguage = "";
            if (Request.Form["hidlanguage"] == "en-us")
            {
                exportlanguage = "SupplierOrderReceive";
            }
            else if (Request.Form["hidlanguage"] == "zh-cn")
            {
                exportlanguage = "总部收货单";
            }
            else
            {
                exportlanguage = "總部收貨單";
            }
            string strfilepath = Request.ServerVariables["APPL_PHYSICAL_PATH"] + "/Export/" + "\\" + exportlanguage + ".rtf";
            int count = VerifyFileIsOpen(strfilepath);
            if (count != 1)
            {
                rtfExport1.Export(rpt.Document, strfilepath);
            }
            else
            {
                ShowWarning("文件已经被打开,请Close后再重新导出。");
            }
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