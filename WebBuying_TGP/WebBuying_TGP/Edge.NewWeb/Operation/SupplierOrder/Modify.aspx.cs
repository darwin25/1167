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

namespace Edge.Web.Operation.SupplierOrder
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PO_H, Edge.SVA.Model.BUY_PO_H>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }

                ControlTool.BindAllSupplier(VendorID);
                ControlTool.BindStoreWithType(StoreID,1); //9 Wharehouse
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
                this.POCode.Text = Model.POCode;
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
                if (!string.IsNullOrEmpty(Model.ApproveOn.ToString()))
                {
                    this.ApproveOn.Text = ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ApproveBy.ToString()))
                {
                    this.lblApproveBy.Text = Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());
                }
                if (!string.IsNullOrEmpty(Model.ExpectDate.ToString()))
                {
                    ExpectDate.Text = Convert.ToDateTime(Model.ExpectDate).ToString("yyyy-MM-dd ");
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
                if (!string.IsNullOrEmpty(Model.VendorID.ToString()))
                {
                    this.VendorID.SelectedValue = Model.VendorID.ToString();
                }
                if (!string.IsNullOrEmpty(Model.StoreID.ToString()))
                {
                    this.StoreID.SelectedValue = Model.StoreID.ToString();
                }
                Edge.SVA.Model.BUY_VENDOR model = new Edge.SVA.BLL.BUY_VENDOR().GetModel(Tools.ConvertTool.ConverType<int>(Model.VendorID.ToString()));
                if (model != null)
                {
                    SupplierAddress.Text = model.VendorAddress1;
                    SupplierContactName.Text = model.Contact;
                    SupplierPhone.Text = model.ContactMobile;
                }
                else
                {
                    SupplierAddress.Text = "";
                    SupplierContactName.Text = "";
                    SupplierPhone.Text = "";
                }
                Edge.SVA.Model.BUY_STORE model1 = new Edge.SVA.BLL.BUY_STORE().GetModel(Tools.ConvertTool.ConverType<int>(Model.StoreID.ToString()));
                if (model1 != null)
                {
                    StoreAddress.Text = model1.StoreAddressDetail1;
                    StoreContactName.Text = model1.Contact;
                    StorePhone.Text = model.ContactTel;
                }
                else
                {
                    StoreAddress.Text = "";
                    StoreContactName.Text = "";
                    StorePhone.Text = "";
                }
                this.BindDetail();
                OutputSummaryData();
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {

            if (this.VendorID.SelectedValue == "-1")
            {
                this.VendorID.MarkInvalid(String.Format("'{0}' Can't Empty！", VendorID.Text));
                return;
            }
            if (this.StoreID.SelectedValue == "-1")
            {
                this.StoreID.MarkInvalid(String.Format("'{0}' Can't Empty！", StoreID.Text));
                return;
            }

            Edge.SVA.Model.BUY_PO_H item = null;
            Edge.SVA.Model.BUY_PO_H dataItem = this.GetDataObject();

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
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Supplier Order Form  {0} Detail No Data", item.POCode));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            if (item == null)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Supplier Order Form  {0} No Data", item.POCode));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            item.UpdatedBy = DALTool.GetCurrentUser().UserID;
            item.UpdatedOn = DateTime.Now;

            if (Tools.DALTool.Update<Edge.SVA.BLL.BUY_PO_H>(item))
            {
                Edge.SVA.BLL.BUY_PO_D bll = new SVA.BLL.BUY_PO_D();
                bll.Delete(this.POCode.Text.Trim());
                try
                {
                    DatabaseUtil.Factory.SetConnecctionString(DBUtility.PubConstant.ConnectionString);
                    DatabaseUtil.Interface.IDatabase database = DatabaseUtil.Factory.CreateIDatabase();
                    database.SetExecuteTimeout(6000);
                    System.Data.DataTable sourceTable = database.GetTableSchema("BUY_PO_D");
                    DatabaseUtil.Interface.IExecStatus es = null;
                    foreach (System.Data.DataRow detail in this.Detail.Rows)
                    {
                        System.Data.DataRow row = sourceTable.NewRow();
                        row["POCode"] = item.POCode;
                        row["ProdCode"] = detail["ProdCode"];
                        row["Qty"] = detail["Qty"];
                        row["Cost"] = detail["Cost"];
                        row["AverageCost"] = detail["AverageCost"];
                        row["UnitCost"] = detail["UnitCost"];
                        row["FreeQty"] = detail["FreeQty"];
                        row["GRNQty"] = detail["GRNQty"];
                        sourceTable.Rows.Add(row);
                    }
                    es = database.InsertBigData(sourceTable, "BUY_PO_D");
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
                    Logger.Instance.WriteErrorLog(this.PageName, string.Format("Order to Supplier {0} Update Success But Detail Failed", item.POCode), ex);
                    ShowAddFailed();
                    return;
                }
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Order to Supplier {0} Update Success", item.POCode));
                CloseAndRefresh();
            }
        }

        protected void SupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.BUY_VENDOR model = new Edge.SVA.BLL.BUY_VENDOR().GetModel(Tools.ConvertTool.ConverType<int>(VendorID.SelectedValue.ToString()));
            if (model != null)
            {
                SupplierAddress.Text = model.VendorAddress1;
                SupplierContactName.Text = model.Contact;
                SupplierPhone.Text = model.ContactMobile;
            }
            else
            {
                SupplierAddress.Text = "";
                SupplierContactName.Text = "";
                SupplierPhone.Text = "";
            }
        }


        protected void StoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.BUY_STORE model = new Edge.SVA.BLL.BUY_STORE().GetModel(Tools.ConvertTool.ConverType<int>(StoreID.SelectedValue.ToString()));
            if (model != null)
            {
                StoreAddress.Text = model.StoreAddressDetail1;
                StoreContactName.Text = model.Contact;
                StorePhone.Text = model.ContactPhone;
            }
            else
            {
                StoreAddress.Text = "";
                StoreContactName.Text = "";
                StorePhone.Text = "";
            }
        }

        protected override SVA.Model.BUY_PO_H GetPageObject(SVA.Model.BUY_PO_H obj)
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
                    System.Data.DataSet ds = new Edge.SVA.BLL.BUY_PO_D().GetList(string.Format("POCode = '{0}'", Request.Params["id"]));
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
            DataTable source = GetDataTable();
            JObject summary = new JObject();
            Decimal OnhandQtyTotal = 0;
            if (this.Grid2.RecordCount > 0)
            {
                foreach (DataRow row in source.Rows)
                {
                    OnhandQtyTotal += Convert.ToDecimal(row["onhandQty"]);
                }
                summary.Add("onhandQty", OnhandQtyTotal.ToString("F2"));
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
            Edge.SVA.BLL.BUY_PO_D podOrderBll = new SVA.BLL.BUY_PO_D();
            table.Columns.Add(new DataColumn("onhandQty", typeof(int)));
            DataRow row = null;
            row = table.NewRow();
            DataSet ds = podOrderBll.GetSummary(string.Format("POCode = '{0}'", Request.Params["id"]));
            row[0] = ds.Tables[0].Rows[0]["QTY"];
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
            if (string.IsNullOrEmpty(this.OrderQty.Text))
            {
                this.OrderQty.MarkInvalid(String.Format("'{0}' Can't Empty！", OrderQty.Text));
                return;
            }

            foreach (int row1 in this.Grid1.SelectedRowIndexArray)
            {
                System.Data.DataRow detail1 = this.Detail1.Rows[row1+this.Grid1.PageIndex*this.Grid1.PageSize];
                foreach (System.Data.DataRow detail in this.Detail.Rows)
                {
                    if (detail["ProdCode"].ToString().Equals(detail1["ProdCode"].ToString()))
                    {
                        detail["Qty"] = int.Parse(this.OrderQty.Text);
                        FindinDetail = true;
                        break;
                    }
                }
                if (!FindinDetail)
                {
                    System.Data.DataRow row = this.Detail.NewRow();
                    row["ProdCode"] = detail1["ProdCode"];
                    row["ProdDesc"] = detail1["ProdDesc"];
                    row["Qty"] = int.Parse(this.OrderQty.Text);
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