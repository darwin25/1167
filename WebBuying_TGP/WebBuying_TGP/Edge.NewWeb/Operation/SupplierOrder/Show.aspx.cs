﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using System.Data;
using Edge.Web.Controllers.Operation.SupplierOrder;
using Newtonsoft.Json.Linq;

namespace Edge.Web.Operation.SupplierOrder
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PO_H, Edge.SVA.Model.BUY_PO_H>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.Grid1.PageSize = webset.ContentPageNum;

                RegisterCloseEvent(btnClose);
                
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
                    ExpectDate.Text = ConvertTool.ToStringDateTime(Model.ExpectDate.GetValueOrDefault());
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
                    this.lblSupplierID.Text = DALTool.GetBuyingVendorNameByID(Model.VendorID.ToString(), null);
                }
                if (!string.IsNullOrEmpty(Model.StoreID.ToString()))
                {
                    this.lblStoreID.Text = DALTool.GetBuyingStoreNameByID(Model.StoreID.ToString(), null);
                }
                
                Edge.SVA.Model.BUY_VENDOR model = new Edge.SVA.BLL.BUY_VENDOR().GetModel(Tools.ConvertTool.ConverType<int>(Model.VendorID.ToString()));
                if (model != null)
                {
                    lblSupplierAddress.Text = model.VendorAddress1;
                    lblSupplierContactName.Text = model.Contact;
                    lblSupplierPhone.Text = model.ContactMobile;
                }
                else
                {
                    lblSupplierAddress.Text = "";
                    lblSupplierContactName.Text = "";
                    lblSupplierPhone.Text = "";
                }
                Edge.SVA.Model.BUY_STORE model1 = new Edge.SVA.BLL.BUY_STORE().GetModel(Tools.ConvertTool.ConverType<int>(Model.StoreID.ToString()));
                if (model1 != null)
                {
                    lblStoreAddress.Text = model1.StoreAddressDetail1;
                    lblStoreContactName.Text = model1.Contact;
                    lblStorePhone.Text = model.ContactTel;
                }
                else
                {
                    lblStoreAddress.Text = "";
                    lblStoreContactName.Text = "";
                    lblStorePhone.Text = "";
                }

                this.BindDetail();
                OutputSummaryData();
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            this.BindDetail();
        }

        private System.Data.DataTable Detail
        {
            get
            {
                if (ViewState["DetailResult"] == null)
                {
                    //string strWhere="";
                    int pagesize = this.Grid1.PageSize;
                    int pageindex = this.Grid1.PageIndex;
                    //System.Data.DataSet ds = new Edge.SVA.BLL.BUY_PO_D().GetListByPage(string.Format("POCode = '{0}'", Request.Params["id"]) + strWhere, "", pagesize * pageindex + 1, pagesize * (pageindex + 1));
                    System.Data.DataSet ds = new Edge.SVA.BLL.BUY_PO_D().GetList(string.Format("POCode = '{0}'", Request.Params["id"]));
                    if (ds == null || ds.Tables.Count <= 0) return null;

                    Tools.DataTool.AddID(ds, "ID", 0, 0);
                    Tools.DataTool.AddBuyingProdDesc(ds, "ProdDesc", "ProdCode");

                    ViewState["DetailResult"] = ds.Tables[0];
                }
                return ViewState["DetailResult"] as System.Data.DataTable;
            }
        }

        private void BindDetail()
        {
            this.Grid1.RecordCount = this.Detail.Rows.Count;
            this.Grid1.DataSource = DataTool.GetPaggingTable(this.Grid1.PageIndex, this.Grid1.PageSize, this.Detail);
            this.Grid1.DataBind();
        }

        private void OutputSummaryData()
        {
            DataTable source = GetDataTable();
            JObject summary = new JObject();
            Decimal OnhandQtyTotal = 0;
            if (this.Grid1.RecordCount > 0)
            {
                foreach (DataRow row in source.Rows)
                {
                    OnhandQtyTotal += Convert.ToDecimal(row["onhandQty"]);
                }
                summary.Add("onhandQty", OnhandQtyTotal.ToString("F2"));
            }
            Grid1.SummaryData = summary;


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

        protected override void SetObject()
        {
            foreach (System.Web.UI.Control con in this.Panel1.Controls)
            {
                if (con is FineUI.GroupPanel)
                {
                    base.SetObject(Model, con.Controls.GetEnumerator());
                }
            }
        }

        //Add by Robin 20140622
        //protected void btnExport_Click(object sender, EventArgs e)
        //{
        //    CouponCreationAutomaticController controller = new CouponCreationAutomaticController();


        //    DataTable dt = controller.GetExportList(OrderSupplierNumber.Text);
        //    string fileName = controller.UpLoadFileToServer(dt);

        //    try
        //    {
        //        string exportname = "GC Delivery List.xls";
        //        Tools.ExportTool.ExportFile(fileName, exportname);
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowWarning(ex.Message);
        //    }
        //}

        //protected void btnPrintPR_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(string.Format("PrintPR.aspx?id={0}", Request.Params["id"]));
        //}

        //protected void SearchButton_Click(object sender, EventArgs e)
        //{
        //    this.Grid1.PageIndex = 0;
        //    this.SearchFlag.Text = "1";
        //    this.BindDetail();
        //}

    }
}