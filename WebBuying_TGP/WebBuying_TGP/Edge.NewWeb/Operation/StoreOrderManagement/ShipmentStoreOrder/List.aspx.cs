﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Messages.Manager;
using System.Data;
using System.Text;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ShipmentStoreOrder;
using Edge.Web.Tools;
using System.IO;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ReceiveStoreOrder;

namespace Edge.Web.Operation.StoreOrderManagement.ShipmentStoreOrder
{
    public partial class List : PageBase
    {
        //private const string fields = "OrderSupplierNumber,ApproveStatus,OrderType,ApprovalCode,SupplierID,StoreID,CreatedBusDate,ApproveBusDate,CreatedOn,CreatedBy,ApproveOn,ApproveBy";
        private const string fields = "[ShipmentOrderNumber],[OrderType],[ReferenceNo],[FromStoreID],[FromContactName],[FromContactPhone],[FromMobile],[FromEmail],[FromAddress],[StoreID],[StoreContactName],[StoreContactPhone],[StoreContactEmail],[StoreMobile],[StoreAddress],[Remark],[CreatedBusDate],[ApproveBusDate],[ApprovalCode],[ApproveStatus],[ApproveOn],[ApproveBy],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy]";

        ShipmentStoreOrderController controller = new ShipmentStoreOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind("", "ShipmentOrderNumber");
                btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "Add");
                btnApprove.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnVoid.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                //导出
                //btnExport.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                //打印
                //btnPrint.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                ControlTool.BindAllSupplier(FromStoreID);
                ControlTool.BindStore(StoreID);
            }
            string url = this.Request.Url.AbsolutePath.Substring(0, this.Request.Url.AbsolutePath.LastIndexOf("/") + 1);
        }

        #region 数据列表绑定

        private int RecordCount
        {
            get
            {
                if (ViewState["RecordCount"] == null || string.IsNullOrEmpty(ViewState["RecordCount"].ToString())) return -1;
                int count = 0;
                return int.TryParse(ViewState["RecordCount"].ToString(), out count) ? count : -1;
            }
            set
            {
                if (value < 0) return;
                if (value > 0)
                {
                    this.btnApprove.Enabled = true;
                    this.btnVoid.Enabled = true;
                    //this.btnExport.Enabled = true;
                   // //this.btnPrint.Enabled = true;
                }
                else
                {
                    this.btnApprove.Enabled = false;
                    this.btnVoid.Enabled = false;
                    //this.btnExport.Enabled = false;
                  //  //this.btnPrint.Enabled = false;
                }
                this.Grid1.RecordCount = value;
                ViewState["RecordCount"] = value;
            }
        }

        private void RptBind(string strWhere, string orderby)
        {
            try
            {
                #region for search
                if (SearchFlag.Text == "1")
                {
                    StringBuilder sb = new StringBuilder(strWhere);

                    int fromstoreid = Tools.ConvertTool.ToInt(this.FromStoreID.SelectedValue);
                    int storeid = Tools.ConvertTool.ToInt(this.StoreID.SelectedValue);
                    string code = this.Code.Text.Trim();
                    string status = this.Status.SelectedValue.Trim();
                    string ordertype = this.OrderType.SelectedValue;
                    string CStatrtDate = this.CreateStartDate.Text;
                    string CEndDate = this.CreateEndDate.Text;
                    string AStatrtDate = this.ApproveStartDate.Text;
                    string AEndDate = this.ApproveEndDate.Text;
                    string prodcode = this.ProductCode.Text;
                    string proddesc = this.ProductDesc.Text;
                    if (fromstoreid > 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" FromStoreID =");
                        sb.Append(storeid);

                    }
                    if (storeid > 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" StoreID =");
                        sb.Append(storeid);

                    }
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ShipmentOrderNumber like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ApproveStatus";
                        sb.Append(descLan);
                        sb.Append(" ='");
                        sb.Append(status);
                        sb.Append("'");
                    }
                    if (!string.IsNullOrEmpty(ordertype))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" OrderType =");
                        sb.Append(ordertype);

                    }
                    if (!string.IsNullOrEmpty(CStatrtDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "CreatedOn";
                        sb.Append(descLan);
                        sb.Append(" >= Cast('");
                        sb.Append(CStatrtDate);
                        sb.Append("' as DateTime)");
                    }
                    if (!string.IsNullOrEmpty(CEndDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "CreatedOn";
                        sb.Append(descLan);
                        sb.Append(" < Cast('");
                        sb.Append(CEndDate);
                        sb.Append("' as DateTime) + 1");
                    }
                    if (!string.IsNullOrEmpty(AStatrtDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ApproveOn";
                        sb.Append(descLan);
                        sb.Append(" >= Cast('");
                        sb.Append(AStatrtDate);
                        sb.Append("' as DateTime)");
                    }
                    if (!string.IsNullOrEmpty(AEndDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ApproveOn";
                        sb.Append(descLan);
                        sb.Append(" < Cast('");
                        sb.Append(AEndDate);
                        sb.Append("' as DateTime) + 1");
                    }
                    if (!string.IsNullOrEmpty(prodcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" exists(select d.prodcode from ord_shipmentorder_d d where d.shipmentordernumber=ord_shipmentorder_h.shipmentordernumber and prodcode='");
                        sb.Append(prodcode);
                        sb.Append("')");
                    }
                    if (!string.IsNullOrEmpty(proddesc))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" exists(select d.prodcode from ord_shipmentorder_d d left join buy_product p on d.prodcode=p.prodcode where d.shipmentordernumber=ord_shipmentorder_h.shipmentordernumber and proddesc1+proddesc2+proddesc3 like '%");
                        sb.Append(proddesc);
                        sb.Append("%')");
                    }
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                int count = 0;
                DataSet ds = controller.GetTransactionList(strWhere, Grid1.PageSize, Grid1.PageIndex, out count,orderby);
                ds.Tables[0].Columns.Add(new DataColumn("OrderTypeName", typeof(string)));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //int storeID = dr["StoreID"] == null ? 0 : Convert.ToInt32(dr["StoreID"]);
                    //int supplierID = dr["VendorID"] == null ? 0 : Convert.ToInt32(dr["VendorID"]);
                    int orderType = dr["OrderType"] == null ? 0 : Convert.ToInt32(dr["OrderType"]);
                    //Edge.SVA.Model.Store store = new Edge.SVA.BLL.Store().GetModel(storeID);
                    //dr["FullStoreID"] = store == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3), store.StoreCode);
                    //Edge.SVA.Model.BUY_VENDOR supplier = new Edge.SVA.BLL.BUY_VENDOR().GetModel(supplierID);
                    //dr["FullSupplierID"] = supplier == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(supplier.VendorName1, supplier.VendorName2, supplier.VendorName3), supplier.VendorCode);
                    if (orderType == 0)
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Manually"; break;
                            case "zh-cn": dr["OrderTypeName"] = "Manual"; break;
                            case "zh-hk": dr["OrderTypeName"] = "手動"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Auto"; break;
                            case "zh-cn": dr["OrderTypeName"] = "自动"; break;
                            case "zh-hk": dr["OrderTypeName"] = "自動"; break;
                        }
                    }
                }
                this.RecordCount = count;
                this.Grid1.DataSource = ds.Tables[0].DefaultView;
                this.Grid1.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("Store Order", "Load Faild", ex);
            }
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            int count = 0;
            DataSet ds = controller.GetTransactionList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count, sortField);
            ds.Tables[0].Columns.Add(new DataColumn("FullStoreID", typeof(string)));
            ds.Tables[0].Columns.Add(new DataColumn("FullFromStoreID", typeof(string)));
            ds.Tables[0].Columns.Add(new DataColumn("OrderTypeName", typeof(string)));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //int storeID = dr["StoreID"] == null ? 0 : Convert.ToInt32(dr["StoreID"]);
                //int fromstoreID = dr["FromStoreID"] == null ? 0 : Convert.ToInt32(dr["FromStoreID"]);
                int orderType = dr["OrderType"] == null ? 0 : Convert.ToInt32(dr["OrderType"]);
                //Edge.SVA.Model.Store store = new Edge.SVA.BLL.Store().GetModel(storeID);
                //dr["FullStoreID"] = store == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3), store.StoreCode);
                //Edge.SVA.Model.Store fromstore = new Edge.SVA.BLL.Store().GetModel(fromstoreID);
                //dr["FullFromStoreID"] = store == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3), fromstore.StoreCode);
                if (orderType == 0)
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": dr["OrderTypeName"] = "Manually"; break;
                        case "zh-cn": dr["OrderTypeName"] = "Manual"; break;
                        case "zh-hk": dr["OrderTypeName"] = "手動"; break;
                    }
                }
                else
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": dr["OrderTypeName"] = "Auto"; break;
                        case "zh-cn": dr["OrderTypeName"] = "自动"; break;
                        case "zh-hk": dr["OrderTypeName"] = "自動"; break;
                    }
                }
            }
            this.RecordCount = count;

            DataTable table = ds.Tables[0];

            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            Grid1.DataSource = view1;
            Grid1.DataBind();
        }
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            BindGridWithSort(e.SortField, e.SortDirection);
        }
        #endregion

        #region Event
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            NewApproveTxns(Grid1, Window2);            
        }

        protected void btnVoid_Click(object sender, EventArgs e)
        {
            NewVoidTxns(Grid1, Window2);
        }
        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {
            //ExportStoreReceiveData
            //NewExportTxns(Grid1, Window2);
        }
        //打印
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //NewPrintTxns(Grid1, Window2);
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "ShipmentOrderNumber");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "ShipmentOrderNumber");
        }
        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.DataItem is DataRowView)
            {
                DataRowView drv = e.DataItem as DataRowView;
                string approveStatus = drv["ApproveStatus"].ToString().Trim();
                if (approveStatus != "")
                {
                    approveStatus = approveStatus.Substring(0, 1).ToUpper().Trim();
                    switch (approveStatus)
                    {
                        case "A":
                            break;
                        case "P":
                            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            break;
                        case "V":
                            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            break;
                    }
                }
            }
        }

        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            if (e.DataItem is DataRowView)
            {
                DataRowView drv = e.DataItem as DataRowView;
                string approveStatus = drv["ApproveStatus"].ToString().Trim();
                FineUI.WindowField editWF = Grid1.FindColumn("EditWindowField") as FineUI.WindowField;

                if (approveStatus != "")
                {
                    approveStatus = approveStatus.Substring(0, 1).ToUpper().Trim();
                    switch (approveStatus)
                    {
                        case "A":
                            editWF.Enabled = false;
                            break;
                        case "P":
                            editWF.Enabled = true;
                            break;
                        case "V":
                            editWF.Enabled = false;
                            break;
                    }
                }
            }
        }
        #endregion

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("", "ShipmentOrderNumber");
        }

        public void ExportStoreReceiveData(FineUI.Grid Grid, int OrderType)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid.SelectedRowIndexArray)
            {

                ReceiveStoreOrderController controller1 = new ReceiveStoreOrderController();
                DataSet ds = new DataSet();
                ds = controller1.ExportStoreReceiveData(Grid.DataKeys[row][0].ToString(), OrderType);

                //string pathToFiles = System.Web.HttpContext.Current.Server.MapPath("/UploadedFiles");
                string pathToFiles = "C:\\TestPaths\\1167\\HQExportFiles\\"; //"C:\\WebBuying\\Exported Files\\";
                string filename = pathToFiles + Grid.DataKeys[row][0].ToString() + ".428";
                SaveCSV(ds, filename);
            }

        }

       
    }
}