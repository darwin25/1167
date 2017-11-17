using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrapeCity.ActiveReports;
using Edge.Web.Tools;
using GrapeCity.ActiveReports.Export.Word.Section;
using Asp.Net.WebFormLib;
using GrapeCity.ActiveReports.SectionReportModel;
using System.Data;
using System.Text;
using Edge.Web.Controllers.Operation.SupplierOrder;
using GrapeCity.ActiveReports.Expressions.Remote.GlobalDataTypes;
using Edge.Web.Controllers.Operation.StoreOrderManagement.StoreOrder;
using Edge.Web.Controllers.Operation.SupplierOrderReceive;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ReceiveStoreOrder;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ShipmentStoreOrder;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ReturnStoreOrder;
using Edge.Web.Controllers.Operation.StockTakeController;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.Operation.StoreOrderManagement.PickingStoreOrder;
using Edge.Web.Controllers.Operation.StoreOrderManagement.StockAdjust;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Controllers.Operation.StoreOrderManagement.TransOutStoreOrder;
using Edge.Web.Controllers.Operation.StoreOrderManagement.TransInStoreOrder;
using Edge.Web.Controllers.Operation.DeliveryOrderManagement;
namespace Edge.Web.Tools
{
    /// <summary>
    /// ActiveReports 公用方法
    /// 创建人：王丽
    /// 创建时间：2015-11-30
    /// </summary>
    public class ActiveReportsTool : WebPageBase
    {
        #region 全局变量
        // 当前预览的报表
        SectionReport rpt;
        // 报表运行的总高度
        public float TotalOfHeight = 0;
        #endregion

        #region 公用业务逻辑类
        //供应商订单
        SupplierOrderController supplierOrderController = new SupplierOrderController();
        //店铺订单
        StoreOrderController storeOrderController = new StoreOrderController();
        //总部收货单
        SupplierOrderReceiveController supplierOrderReceiveController = new SupplierOrderReceiveController();
        //店铺收货单
        ReceiveStoreOrderController receiveStoreOrderController = new ReceiveStoreOrderController();
        //总部收货单
        ShipmentStoreOrderController shipmentStoreOrderController = new ShipmentStoreOrderController();
        //店铺退货单
        ReturnStoreOrderController returnStoreOrderController = new ReturnStoreOrderController();
        //盘点差异
        StockTakeController stockTakeController = new StockTakeController();
        //总部拣货单品牌
        PickingStoreOrderController pickingStoreOrderController = new PickingStoreOrderController();
        //店铺库存调整单
        StockAdjustController stockAdjustController = new StockAdjustController();
        //库存查询
        BuyingProductController productController = new BuyingProductController();
        //出库单
        TransOutStoreOrderController tranOutController = new TransOutStoreOrderController();
        //入库单
        TransInStoreOrderController tranInController = new TransInStoreOrderController();
        //销售单
        DeliveryOrderController deliveryController = new DeliveryOrderController();
        #endregion


        #region 导出
        /// <summary>
        /// 导出功能
        /// 创建人：王丽
        /// 创建时间：2015-11-30
        /// </summary>
        /// <param name="exporttype"></param>
        /// <param name="url"></param>
        /// <param name="name"></param>
        public void Report(string exporttype, string url, string name, string ids, GrapeCity.ActiveReports.Web.WebViewer WebViewerOrderList, string webSiteName, string ControlName)
        {
            LoadReport(ids, WebViewerOrderList, url, webSiteName, ControlName);
            var key = exporttype;
            switch (key)
            {
                case "Word":
                    ExportWord(rpt, name);
                    break;
            }
        }
        #endregion

        #region word 文档导出
        /// <summary>
        /// word导出
        /// 创建人：王丽
        /// 创建时间：2015-11-30
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pr"></param>
        /// <param name="name"></param>
        private void ExportWord(SectionReport pr, string name)
        {
            //context.Response.ContentType = "application/msword";
            //context.Response.Clear();
            //context.Response.HeaderEncoding = System.Text.Encoding.Default;
            //context.Response.AddHeader("content-disposition", Server.UrlPathEncode("attachment;filename=" + name + ".doc"));
            //var word = new RtfExport();
            //var memStream = new System.IO.MemoryStream();
            //word.Export(pr.Document, memStream);

            //context.Response.BinaryWrite(memStream.ToArray());
            //context.Response.End();
            GrapeCity.ActiveReports.Export.Word.Section.RtfExport rtfExport1 = new
GrapeCity.ActiveReports.Export.Word.Section.RtfExport();
            rtfExport1.Export(pr.Document, Request.ServerVariables["APPL_PHYSICAL_PATH"] + "\\" + name + ".rtf");

        }
        #endregion

        #region 公用绑定报表方法
        /// <summary>
        /// 公用绑定报表方法
        /// 创建人：王丽
        /// 创建时间：2015-12-01
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="WebViewerOrderList"></param>
        /// <param name="Path"></param>
        public void LoadReport(string ids, GrapeCity.ActiveReports.Web.WebViewer WebViewerOrderList, string Path, string webSiteName, string ControlName)
        {

            rpt = new SectionReport();
            TotalOfHeight = 0;

            // 针对不同模板，只需修改报表名称即可
            System.Xml.XmlTextReader xtr = new System.Xml.XmlTextReader(Server.MapPath("\\Reports") + Path);
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
            rpt.DataSource = GetDataBind(ids, webSiteName, ControlName);
            rpt.DataMember = "";
            rpt.Run();
            WebViewerOrderList.Report = rpt;

        }

        public void LoadReport(string ids, GrapeCity.ActiveReports.Web.WebViewer WebViewerOrderList, string Path, string webSiteName, string ControlName, int StoreID)
        {

            rpt = new SectionReport();
            TotalOfHeight = 0;

            // 针对不同模板，只需修改报表名称即可
            System.Xml.XmlTextReader xtr = new System.Xml.XmlTextReader(Server.MapPath("\\Reports") + Path);
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
            rpt.DataSource = GetDataBind(ids, webSiteName, ControlName, StoreID);
            rpt.DataMember = "";
            rpt.Run();
            WebViewerOrderList.Report = rpt;

        }
        #endregion

        #region 页面绑定报表数据
        /// <summary>
        /// 页面绑定报表数据
        /// 创建人：王丽
        /// 创建时间：2015-12-01
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public DataTable GetDataBind(string ids, string webSiteName, string ControlName)
        {
            DataTable ds = null;
            string strwhere = "";
            //选中多个
            if (ids.Contains(','))
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    sb.Append("'");
                    sb.Append(item);
                    sb.Append("'");
                    sb.Append(",");
                    strwhere = sb.ToString().Substring(0, sb.ToString().Length - 1);
                }
            }
            //选中单个
            else
            {
                strwhere = "'" + ids + "'";

            }
            //供应商订单
            if (ControlName == "SupplierOrder")
                ds = supplierOrderController.GetTransactionListByParm(" BUY_PO_H.POCode in (" + strwhere + ")", "POCode", webSiteName).Tables[0];
            //店铺订单
            else if (ControlName == "StoreOrder")
                ds = storeOrderController.GetTransactionListByParm(" Ord_StoreOrder_H.StoreOrderNumber in (" + strwhere + ")", "StoreOrderNumber", webSiteName).Tables[0];
            //总部收货单
            else if (ControlName == "SupplierOrderReceive")
                ds = supplierOrderReceiveController.GetTransactionListByParm(" Ord_HQReceiveOrder_H.HQReceiveOrderNumber in (" + strwhere + ")", "HQReceiveOrderNumber", webSiteName).Tables[0];
            //店铺收货单
            else if (ControlName == "ReceiveStoreOrder")
                ds = receiveStoreOrderController.GetTransactionListByParm(" Ord_ReceiveOrder_H.ReceiveOrderNumber in (" + strwhere + ")", "ReceiveOrderNumber desc", webSiteName).Tables[0];
            //总部送货单
            else if (ControlName == "ShipmentStoreOrder")
                ds = shipmentStoreOrderController.GetTransactionListByParm(" Ord_ShipmentOrder_H.ShipmentOrderNumber in (" + strwhere + ")", "ShipmentOrderNumber", webSiteName).Tables[0];
            //店铺退货单
            else if (ControlName == "ReturnStoreOrder")
                ds = returnStoreOrderController.GetTransactionListByParm(" Ord_ReturnOrder_H.ReturnOrderNumber in (" + strwhere + ")", "ReturnOrderNumber", webSiteName).Tables[0];
            //库存盘点一
            else if (ControlName == "StockTake01")
                ds = stockTakeController.GetTransactionListByParm(" STK_STake_H.StockTakeNumber in (" + strwhere + ")", "StockTakeNumber", webSiteName, "StockTake01").Tables[0];
            //库存盘点二
            else if (ControlName == "StockTake02")
                ds = stockTakeController.GetTransactionListByParm(" STK_STake_H.StockTakeNumber in (" + strwhere + ")", "StockTakeNumber", webSiteName, "StockTake02").Tables[0];
            //库存差异
            else if (ControlName == "StockTakeVAR")
                ds = stockTakeController.GetTransactionListByParm(" STK_STake_H.StockTakeNumber in (" + strwhere + ")", "StockTakeNumber", webSiteName, "StockTakeVAR").Tables[0];
            //总部拣货单
            else if (ControlName == "PickingStoreOrder")
                ds = pickingStoreOrderController.GetTransactionListByParm(" Ord_PickingOrder_H.PickingOrderNumber in (" + strwhere + ")", "PickingOrderNumber", webSiteName).Tables[0];
            //店铺库存调整单
            else if (ControlName == "StockAdjustOrder")
                ds = stockAdjustController.GetTransactionListByParm(" Ord_StockAdjust_H.StockAdjustNumber in (" + strwhere + ")", "StockAdjustNumber", webSiteName).Tables[0];
            //出库单
            else if (ControlName == "TransOutOrder")
                ds = tranOutController.GetTransactionListByParm(" Ord_TransOutOrder_H.TransOutOrderNumber in (" + strwhere + ")", "TransOutOrderNumber", webSiteName).Tables[0];
            //入库单
            else if (ControlName == "TransInOrder")
                ds = tranInController.GetTransactionListByParm(" Ord_TransInOrder_H.TransInOrderNumber in (" + strwhere + ")", "TransInOrderNumber", webSiteName).Tables[0];
            //销售单
            else if (ControlName == "DeliveryOrderManagement")
                ds = deliveryController.GetTransactionListByParm(" Sales_H.TransNum in (" + strwhere + ")", "TransNum", webSiteName).Tables[0];
            return ds;
        }
        public DataTable GetDataBind(string ids, string webSiteName, string ControlName, int StoreID)
        {
            DataTable ds = null;
            string strwhere = "";
            //选中多个
            if (ids.Contains(','))
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in ids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    sb.Append("'");
                    sb.Append(item);
                    sb.Append("'");
                    sb.Append(",");
                    strwhere = sb.ToString().Substring(0, sb.ToString().Length - 1);
                }
            }
            //选中单个
            else
            {
                strwhere = "'" + ids + "'";

            }
            //库存查询
            if (ControlName == "StockQuery")
                ds = productController.GetTransactionListByParm(" BUY_PRODUCT.ProdCode in (" + strwhere + ") and  BUY_STORE.StoreID =" + StoreID, "ProdCode", webSiteName).Tables[0];
            return ds;
        }
        #endregion

        #region 事件
        // 累加当前区域的高度
        void item_AfterPrint(object sender, EventArgs e)
        {
            float height = (sender as Section).Height + 1;

            TotalOfHeight += height;
        }

        public float ActualPageHeight = 0;
        // 为当前页设置正确的高度值
        void rpt_ReportEnd(object sender, EventArgs e)
        {
            // 在报表运行结束之后调整最后一页的高度
            //SectionReport rpt = (sender as SectionReport);
            rpt.Document.Pages[rpt.Document.Pages.Count - 1].Height = TotalOfHeight - (rpt.Document.Pages.Count - 1) * rpt.PageSettings.PaperWidth;

        }
        #endregion
    }
}