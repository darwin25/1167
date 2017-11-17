using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using System.Data;
using Newtonsoft.Json.Linq;

namespace Edge.Web.Operation.StoreOrderManagement.ShipmentStoreOrder
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_ShipmentOrder_H, Edge.SVA.Model.Ord_ShipmentOrder_H>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }

                ControlTool.BindStoreWithType(FromStoreID, 1); //9 Wharehouse
                ControlTool.BindStoreWithType(StoreID, 1); //1 Retail
                //绑定物流供应商
                ControlTool.BindLogisticsProvider(LogisticsProviderID, "");
                RegisterCloseEvent(btnClose);
                this.Grid1.PageSize = webset.ContentPageNum;
                this.Grid2.PageSize = webset.ContentPageNum;
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.ShipmentOrderNumber.Text = Model.ShipmentOrderNumber;
                if (!string.IsNullOrEmpty(Model.CreatedBusDate.ToString()))
                {
                    this.CreatedBusDate.Text = ConvertTool.ToStringDate(Model.CreatedBusDate.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ApproveStatus.ToString()))
                {
                    this.lblApproveStatus.Text = DALTool.GetApproveStatusString(Model.ApproveStatus);
                }
                if (!string.IsNullOrEmpty(Model.CreatedOn.ToString()))
                {
                    this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.CreatedBy.ToString()))
                {
                    this.lblCreatedBy.Text = Tools.DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ApproveBy.ToString()))
                {
                    this.lblApproveBy.Text = Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.OrderType.ToString()))
                {
                    if (Model.OrderType == 0)
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": lblOrderType.Text = "Manually"; break;
                            case "zh-cn": lblOrderType.Text = "Manual"; break;
                            case "zh-hk": lblOrderType.Text = "手動"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": lblOrderType.Text = "Auto"; break;
                            case "zh-cn": lblOrderType.Text = "自动"; break;
                            case "zh-hk": lblOrderType.Text = "自動"; break;
                        }
                    }

                }
                if (!string.IsNullOrEmpty(Model.FromStoreID.ToString()))
                {
                    this.FromStoreID.SelectedValue = Model.FromStoreID.ToString();
                }
                if (!string.IsNullOrEmpty(Model.StoreID.ToString()))
                {
                    this.StoreID.SelectedValue = Model.StoreID.ToString();
                }
                this.BindDetail();
                OutputSummaryData();

            }
        }


        protected void btnSaveClose_Click(object sender, EventArgs e)
        {

            if (this.FromStoreID.SelectedValue == "-1")
            {
                this.FromStoreID.MarkInvalid(String.Format("'{0}' Can't Empty！", FromStoreID.Text));
                return;
            }

            if (this.StoreID.SelectedValue == "-1")
            {
                this.StoreID.MarkInvalid(String.Format("'{0}' Can't Empty！", StoreID.Text));
                return;
            }

            Edge.SVA.Model.Ord_ShipmentOrder_H item = null;
            Edge.SVA.Model.Ord_ShipmentOrder_H dataItem = this.GetDataObject();

            if (dataItem == null)
            {
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            //Check the transaction whether pending
            if (dataItem.ApproveStatus.ToUpper().Trim() != "P")
            {
                ShowWarningAndClose(Resources.MessageTips.TheTransactionStatusNotPending);
                return;
            }

            item = this.GetPageObject(dataItem);


            if (this.Detail.Rows.Count <= 0)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShipOrder Store Order {0} Detail No Data", item.ShipmentOrderNumber));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            if (item == null)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShipOrder Store Order {0} No Data", item.ShipmentOrderNumber));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            item.UpdatedBy = DALTool.GetCurrentUser().UserID;
            item.UpdatedOn = DateTime.Now;

            if (Tools.DALTool.Update<Edge.SVA.BLL.Ord_ShipmentOrder_H>(item))
            {
                Edge.SVA.BLL.Ord_ShipmentOrder_D bll = new SVA.BLL.Ord_ShipmentOrder_D();
                bll.Delete(this.ShipmentOrderNumber.Text.Trim());
                try
                {
                    DatabaseUtil.Factory.SetConnecctionString(DBUtility.PubConstant.ConnectionString);
                    DatabaseUtil.Interface.IDatabase database = DatabaseUtil.Factory.CreateIDatabase();
                    database.SetExecuteTimeout(6000);
                    System.Data.DataTable sourceTable = database.GetTableSchema("Ord_ShipmentOrder_D");
                    DatabaseUtil.Interface.IExecStatus es = null;
                    foreach (System.Data.DataRow detail in this.Detail.Rows)
                    {
                        System.Data.DataRow row = sourceTable.NewRow();
                        row["ShipmentOrderNumber"] = item.ShipmentOrderNumber;
                        row["ProdCode"] = detail["ProdCode"];
                        row["OrderQty"] = detail["OrderQty"];
                        row["ActualQty"] = detail["ActualQty"];
                        row["Remark"] = detail["Remark"];
                        sourceTable.Rows.Add(row);
                    }
                    es = database.InsertBigData(sourceTable, "Ord_ShipmentOrder_D");
                    if (es.Success)
                    {
                        sourceTable.Rows.Clear();
                    }
                    else
                    {
                        throw es.Ex;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteErrorLog(this.PageName, string.Format("Shipment Store Order {0} Update Success But Detail Failed", item.ShipmentOrderNumber), ex);
                    ShowAddFailed();
                    return;
                }
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Shipment Store Order {0} Update Success", item.ShipmentOrderNumber));
                CloseAndRefresh();
            }
        }

        protected void FromStoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.BUY_STORE model = new Edge.SVA.BLL.BUY_STORE().GetModel(Tools.ConvertTool.ConverType<int>(FromStoreID.SelectedValue.ToString()));
            if (model != null)
            {
                FromAddress.Text = model.StoreAddressDetail1;
                FromContactName.Text = model.Contact;
                FromContactPhone.Text = model.ContactPhone;
            }
            else
            {
                FromAddress.Text = "";
                FromContactName.Text = "";
                FromContactPhone.Text = "";
            }

        }

        protected void StoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.BUY_STORE model = new Edge.SVA.BLL.BUY_STORE().GetModel(Tools.ConvertTool.ConverType<int>(StoreID.SelectedValue.ToString()));
            if (model != null)
            {
                StoreAddress.Text = model.StoreAddressDetail1;
                StoreContactName.Text = model.Contact;
                StoreContactPhone.Text = model.ContactPhone;
            }
            else
            {
                StoreAddress.Text = "";
                StoreContactName.Text = "";
                StoreContactPhone.Text = "";
            }

        }


        protected override SVA.Model.Ord_ShipmentOrder_H GetPageObject(SVA.Model.Ord_ShipmentOrder_H obj)
        {
            List<System.Web.UI.Control> list = new List<System.Web.UI.Control>();

            foreach (System.Web.UI.Control con in this.Panel1.Controls)
            {
                if (con is FineUI.GroupPanel)
                {
                    foreach (System.Web.UI.Control c in con.Controls) list.Add(c);
                }
            }
            return base.GetPageObject(obj, list.GetEnumerator());
        }


        private System.Data.DataTable Detail
        {
            get
            {
                if (ViewState["DetailResult"] == null)
                {
                    System.Data.DataSet ds = new Edge.SVA.BLL.Ord_ShipmentOrder_D().GetList(string.Format("ShipmentOrderNumber = '{0}'", Request.Params["id"]));
                    if (ds == null || ds.Tables.Count <= 0) return null;
                    ds.Tables[0].Columns.Add("ID", typeof(int));
                    Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");
                    ViewState["DetailResult"] = ds.Tables[0];
                }
                return ViewState["DetailResult"] as System.Data.DataTable;
            }
        }

        private void BindDetail()
        {
            this.Grid2.RecordCount = this.Detail.Rows.Count;
            this.Grid2.DataSource = DataTool.GetPaggingTable(this.Grid2.PageIndex, this.Grid2.PageSize, this.Detail);
            this.Grid2.DataBind();
        }

        private void OutputSummaryData()
        {
            DataTable dt = GetDataTable();
            JObject summary = new JObject();
            int onOrderQtyTotal = 0;
            int onActualQtyTotal = 0;
            if (this.Grid2.RecordCount > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    onOrderQtyTotal += Convert.ToInt32(row["onOrderQty"]);
                    onActualQtyTotal += Convert.ToInt32(row["onActualQty"]);
                }
                summary.Add("onOrderQty", onOrderQtyTotal);
                summary.Add("onActualQty", onActualQtyTotal);
            }
            Grid2.SummaryData = summary;


        }

        #region GetDataTable

        /// <summary>
        /// 获取模拟表格
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            Edge.SVA.BLL.Ord_ShipmentOrder_D shipmentOrderBll = new SVA.BLL.Ord_ShipmentOrder_D();
            table.Columns.Add(new DataColumn("onOrderQty", typeof(int)));
            table.Columns.Add(new DataColumn("onActualQty", typeof(int)));
            DataRow row = null;
            row = table.NewRow();
            DataSet ds = shipmentOrderBll.GetSummary(string.Format("ShipmentOrderNumber = '{0}'", Request.Params["id"]));
            row[0] = ds.Tables[0].Rows[0]["OrderQty"];
            row[1] = ds.Tables[0].Rows[0]["ActualQty"];
            table.Rows.Add(row);
            return table;
        }
        #endregion

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            this.BindDetail();
        }

        protected void Grid2_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                object[] keys = Grid2.DataKeys[e.RowIndex];
                string prodCode = keys[0].ToString();
                DeleteDetail(prodCode);
                BindDetail();
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            this.BindDetail1();
        }

        private void DeleteDetail(string prodCode)
        {
            foreach (System.Data.DataRow row in this.Detail.Rows)
            {
                if (row["ProdCode"].ToString().Equals(prodCode))
                {
                    row.Delete();
                    break;
                }
            }
            this.Detail.AcceptChanges();
            this.BindDetail();
        }

        private System.Data.DataTable Detail1
        {
            get
            {
                if (ViewState["Detail1Result"] == null)
                {
                    int RecordCount = 0;
                    string strWhere = "";


                    if (!string.IsNullOrEmpty(ProductCode.Text))
                    {
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strWhere = " prodcode like '%" + ProductCode.Text.Trim() + "%'";
                        }
                        else
                        {
                            strWhere = strWhere + " and prodcode like '%" + ProductCode.Text.Trim() + "%'";
                        }
                    }
                    if (!string.IsNullOrEmpty(ProductDesc.Text))
                    {
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strWhere = " (proddesc1 like '%" + ProductDesc.Text.Trim() + "%' or proddesc2 like '%" + ProductDesc.Text.Trim() + "%' or proddesc3 like '%" + ProductDesc.Text.Trim() + "%') ";
                        }
                        else
                        {
                            strWhere = strWhere + " and (proddesc1 like '%" + ProductDesc.Text.Trim() + "%' or proddesc2 like '%" + ProductDesc.Text.Trim() + "%' or proddesc3 like '%" + ProductDesc.Text.Trim() + "%') "; ;
                        }
                    }
                    if (!string.IsNullOrEmpty(DepartmentCode.Text))
                    {
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strWhere = " departcode like '%" + DepartmentCode.Text.Trim() + "%'";
                        }
                        else
                        {
                            strWhere = strWhere + " and departcode like '%" + DepartmentCode.Text.Trim() + "%'";
                        }
                    }
                    if (!string.IsNullOrEmpty(DepartmentDesc.Text))
                    {
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strWhere = " departcode in (select departcode from buy_department where (departname1 like '%" + DepartmentDesc.Text.Trim() + "%' or departname2 like '%" + DepartmentDesc.Text.Trim() + "%' or departname3 like '%" + DepartmentDesc.Text.Trim() + "%')) ";
                        }
                        else
                        {
                            strWhere = strWhere + " and departcode in (select departcode from buy_department where (departname1 like '%" + DepartmentDesc.Text.Trim() + "%' or departname2 like '%" + DepartmentDesc.Text.Trim() + "%' or departname3 like '%" + DepartmentDesc.Text.Trim() + "%')) ";
                        }
                    }

                    BuyingProductController controller = new BuyingProductController();
                    //System.Data.DataSet ds = controller.GetTransactionList(strWhere, this.Grid1.PageSize, 0, out RecordCount, "prodcode");
                    System.Data.DataSet ds = controller.GetTransactionList(strWhere, 1000, 0, out RecordCount, "prodcode"); //Modified By Robin 2015-05-13 for Temporary solution
                    if (ds == null || ds.Tables.Count <= 0) return null;

                    //Tools.DataTool.AddID(ds, "ID", 0, 0);
                    //Tools.DataTool.AddBuyingDepartName(ds.Tables[0], "DepartName", "DepartCode");
                    //Tools.DataTool.AddBuyingProdName(ds.Tables[0], "ProdDesc", "ProdCode");
                    ViewState["Detail1Result"] = ds.Tables[0];
                }
                return ViewState["Detail1Result"] as System.Data.DataTable;
            }
        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ViewState["Detail1Result"] = null;
            this.BindDetail1();
        }

        private void BindDetail1()
        {
            //this.Grid1.RecordCount = this.Detail1.Rows.Count;
            //this.Grid1.DataSource = DataTool.GetPaggingTable(this.Grid1.PageIndex, this.Grid1.PageSize, this.Detail1);
            this.Grid1.DataSource = this.Detail1.DefaultView;
            this.Grid1.DataBind();
        }

        protected void btnSelectAll_OnClick(object sender, EventArgs e)
        {
            Grid1.SelectAllRows();
        }

        protected void btnAddDetail_OnClick(object sender, EventArgs e)
        {
            Boolean FindinDetail = false;
            if (string.IsNullOrEmpty(this.ActualQty.Text))
            {
                this.ActualQty.MarkInvalid(String.Format("'{0}' Can't Empty！", ActualQty.Text));
                return;
            }

            foreach (int row1 in this.Grid1.SelectedRowIndexArray)
            {
                System.Data.DataRow detail1 = this.Detail1.Rows[row1 + this.Grid1.PageIndex * this.Grid1.PageSize];
                foreach (System.Data.DataRow detail in this.Detail.Rows)
                {
                    if (detail["ProdCode"].ToString().Equals(detail1["ProdCode"].ToString()))
                    {
                        detail["ActualQty"] = int.Parse(this.ActualQty.Text);
                        FindinDetail = true;
                        break;
                    }
                }
                if (!FindinDetail)
                {
                    System.Data.DataRow row = this.Detail.NewRow();
                    row["ProdCode"] = detail1["ProdCode"];
                    row["ProdDesc"] = detail1["ProdDesc"];
                    row["ActualQty"] = int.Parse(this.ActualQty.Text);
                    this.Detail.Rows.Add(row);
                }
                FindinDetail = false;
            }

            this.BindDetail();
        }

        protected void btnDeleteAll_OnClick(object sender, EventArgs e)
        {
            Detail.Clear();
            this.BindDetail();
        }

    }
}