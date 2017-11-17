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
using System.Drawing;
using System.Drawing.Printing;

namespace Edge.Web.Operation.StoreOrderManagement.SalesShipOrder
{
    public partial class Export : PageBase
    {
        #region 全局变量
        protected string orderTypes = "";
        string url = "";
        string language = "";
        protected string ids = "";
        protected string txnNos = "";
        ////英文Url
        //protected string enusUrl = "\\StoreOrderManagement\\SalesShipOrder\\rptSalesShipOrderByEnglish.rpx";
        ////中文简体Url
        //protected string zhcnUrl = "\\StoreOrderManagement\\SalesShipOrder\\rptSalesShipOrder.rpx";
        ////中文繁体Url
        //protected string zhhkUrl = "\\StoreOrderManagement\\SalesShipOrder\\rptSalesShipOrderByTraditional.rpx";
        //英文Url
        protected string enusUrl = @"~\Reports\StoreOrderManagement\SalesShipOrder\SalesShipOrderByEnglish.rdlx";
        //中文简体Url
        protected string zhcnUrl = @"~\Reports\StoreOrderManagement\SalesShipOrder\SalesShipOrder.rdlx";
        //中文繁体Url
        protected string zhhkUrl = @"~\Reports\StoreOrderManagement\SalesShipOrder\SalesShipOrderByTraditional.rdlx";
        #endregion

        #region 公用业务逻辑类
        ActiveReportsTool reportTool = new ActiveReportsTool();
        #endregion
        string inputString = "";
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
                    hidIds.Value = ids;
                    txnNos=ids;
                    hidTxnNos.Value=txnNos;
                    orderTypes = Request.Params["orderType"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    //CustomizeToolBar();
                    LoadReprots(ids, orderTypes, txnNos);

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
        /// 创建时间：2016-09-06
        /// </summary>
        /// <param name="ids"></param>
        public void LoadReprots(string ids, string orderTypes, string txnNos)
        {
            foreach (string orderType in orderTypes.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                if (orderType =="0")
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
            WebViewerShipmentSalesShipOrderList.ViewerType = GrapeCity.ActiveReports.Web.ViewerType.FlashViewer;
            WebViewerShipmentSalesShipOrderList.Report = report;
            WebViewerShipmentSalesShipOrderList.FlashViewerOptions.PrintOptions.StartPrint = false;
        }
        private void CustomizeToolBar()
        {
            //设置显示语言版本为中文
            this.WebViewerShipmentSalesShipOrderList.FlashViewerOptions.ResourceLocale = "zh_CN";

            //创建自定义工具条按钮
            ToolButton btnPDF = Tool.CreateButton("PDF");
            btnPDF.ToolTip = "导出到 PDF";
            btnPDF.Caption = "导出到 PDF";

            //设置点击按钮执行的服务
            btnPDF.ClickNavigateTo = "ARExport.ashx?exporttype=PDF&id=" + ids;
            //添加按钮到 FlashViewer 中
            this.WebViewerShipmentSalesShipOrderList.FlashViewerToolBar.Tools.Add(btnPDF);

            ToolButton btnExcel = Tool.CreateButton("Excel");
            btnExcel.ToolTip = "导出到 Excel";
            btnExcel.Caption = "导出到 Excel";
            btnExcel.ClickNavigateTo = "ARExport.ashx?exporttype=Excel&id=" + ids;
            this.WebViewerShipmentSalesShipOrderList.FlashViewerToolBar.Tools.Add(btnExcel);

            ToolButton btnWord = Tool.CreateButton("Word");
            btnWord.ToolTip = "导出到 Word";
            btnWord.Caption = "导出到 Word";
            btnWord.ClickNavigateTo = "ARExport.ashx?exporttype=Word&id=" + ids;
            this.WebViewerShipmentSalesShipOrderList.FlashViewerToolBar.Tools.Add(btnWord);
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
                exportlanguage = "SalesShipOrder";
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

        public string GetCode128B(string inputData)
        {
            string result = "";
            int checksum = 104;
            int j = 1;
            for (int ii = 0; ii < inputData.Length; ii++)
            {
                if (inputData[ii] >= 32)
                {
                    checksum += (inputData[ii] - 32) * (ii + 1);
                }
                else
                {
                    checksum += (inputData[ii] + 64) * (ii + 1);
                }
            }
            checksum = checksum % 103;
            if (checksum < 95)
            {
                checksum += 32;
            }
            else
            {
                checksum += 100;
            }
            result = Convert.ToChar(204) + inputData.ToString() + Convert.ToChar(checksum) + Convert.ToChar(206);
            return result;
        }
        //public void PrintLable()
        //{
        //    PrintDocument pd = new PrintDocument();
        //    StandardPrintController controler = new StandardPrintController();

        //    try
        //    {
        //        pd.PrintPage += new PrintPageEventHandler(this.PrintCustomLable);
        //        pd.PrintController = controler;
        //        pd.Print();
        //        return;
        //    }
        //    catch (Exception err)
        //    {
        //        Console.WriteLine(err.Message);
        //        return;
        //    }
        //    finally
        //    {
        //        pd.Dispose();
        //    }

        //}
        //public void PrintCustomLable(Object Sender, PrintPageEventArgs av)
        //{
        //    Font ft1 = new System.Drawing.Font("Times New Roman", 18, FontStyle.Regular, GraphicsUnit.World);
        //    Font ft2 = new System.Drawing.Font("Code 128", 64, FontStyle.Regular, GraphicsUnit.World);
        //    Brush br = new SolidBrush(Color.Black);
        //    Margins margins = new Margins(50, 50, 50, 145);
        //    av.PageSettings.Margins = margins;

        //    av.Graphics.DrawString(GetCode128B(inputString), ft2, br, 50, -3);
        //    av.Graphics.DrawString(inputString, ft1, br, 110, 60);
        //    av.HasMorePages = false;
        //} 


    }
}