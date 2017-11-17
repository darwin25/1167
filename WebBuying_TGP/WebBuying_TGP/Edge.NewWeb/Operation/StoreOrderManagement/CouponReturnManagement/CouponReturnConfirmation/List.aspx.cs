using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Messages.Manager;
using System.Data;
using System.Text;
using Edge.Web.Controllers.Operation.CouponManagement.BatchCreationOfCoupons.CouponDeliveryConfirmation;
using Edge.Web.Tools;

namespace Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnConfirmation
{
    public partial class List : PageBase
    {
        private const string fields = "CouponReceiveNumber,ReferenceNo,StoreID,SupplierID,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,CreatedOn,CreatedBy,ApproveOn,ApproveBy,OrderType";

        CouponDeliveryConfirmationController controller = new CouponDeliveryConfirmationController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind("", "CouponReceiveNumber");
                btnConfirm.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnVoid.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);

                ControlTool.BindStore(this.SupplierID,"2");
                ControlTool.BindStore(this.StoreID);
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
                    this.btnConfirm.Enabled = true;
                    this.btnVoid.Enabled = true;
                }
                else
                {
                    this.btnConfirm.Enabled = false;
                    this.btnVoid.Enabled = false;
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

                    string couponReceiveNumber = this.CouponReceiveNumber.Text.Trim();
                    string approveStatus = this.ApproveStatus.SelectedValue;
                    string referenceNo = this.ReferenceNo.Text.Trim();
                    int supplierID = Tools.ConvertTool.ToInt(this.SupplierID.SelectedValue);
                    int storeid = Tools.ConvertTool.ToInt(this.StoreID.SelectedValue);
                    string CStatrtDate = this.CreateStartDate.Text;
                    string CEndDate = this.CreateEndDate.Text;
                    string AStatrtDate = this.ApproveStartDate.Text;
                    string AEndDate = this.ApproveEndDate.Text;

                    if (sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }
                    sb.Append(" ReceiveType = 2 ");
                    if (!string.IsNullOrEmpty(couponReceiveNumber))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" CouponReceiveNumber like '%");
                        sb.Append(couponReceiveNumber);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(approveStatus))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ApproveStatus";
                        sb.Append(descLan);
                        sb.Append(" ='");
                        sb.Append(approveStatus);
                        sb.Append("'");
                    }
                    if (!string.IsNullOrEmpty(referenceNo))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ReferenceNo";
                        sb.Append(descLan);
                        sb.Append(" ='");
                        sb.Append(referenceNo);
                        sb.Append("'");
                    }
                    if (supplierID > 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" supplierID = ");
                        sb.Append(supplierID);
                        sb.Append(")");
                    }
                    if (storeid > 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" StoreID = ");
                        sb.Append(storeid);

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
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                int count = 0;
                DataSet ds = controller.GetTransactionList(strWhere, Grid1.PageSize, Grid1.PageIndex, out count);
                ds.Tables[0].Columns.Add(new DataColumn("FullSupplierID", typeof(string)));
                ds.Tables[0].Columns.Add(new DataColumn("FullStoreID", typeof(string)));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int supplierID = dr["SupplierID"] == null ? 0 : Convert.ToInt32(dr["SupplierID"]);
                    int storeID = dr["StoreID"] == null ? 0 : Convert.ToInt32(dr["StoreID"]);
                    Edge.SVA.Model.Store store = new Edge.SVA.BLL.Store().GetModel(storeID);
                    dr["FullStoreID"] = store == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3), store.StoreCode);
                    store = new Edge.SVA.BLL.Store().GetModel(supplierID);
                    dr["FullSupplierID"] = store == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3), store.StoreCode);
                }
                this.RecordCount = count;
                this.Grid1.DataSource = ds.Tables[0].DefaultView;
                this.Grid1.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("CouponReceiveNumber", "Load Faild", ex);
            }
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            int count = 0;
            DataSet ds = controller.GetTransactionList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count);
            ds.Tables[0].Columns.Add(new DataColumn("FullSupplierID", typeof(string)));
            ds.Tables[0].Columns.Add(new DataColumn("FullStoreID", typeof(string)));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int supplierID = dr["SupplierID"] == null ? 0 : Convert.ToInt32(dr["SupplierID"]);
                int storeID = dr["StoreID"] == null ? 0 : Convert.ToInt32(dr["StoreID"]);
                Edge.SVA.Model.Store store = new Edge.SVA.BLL.Store().GetModel(storeID);
                dr["FullStoreID"] = store == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3), store.StoreCode);
                store = new Edge.SVA.BLL.Store().GetModel(supplierID);
                dr["FullSupplierID"] = store == null ? "" : ControlTool.GetDropdownListText(DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3), store.StoreCode);
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
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            NewApproveTxns(Grid1, Window2);
        }

        protected void btnVoid_Click(object sender, EventArgs e)
        {
            NewVoidTxns(Grid1, HiddenWindowForm);
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "CouponReceiveNumber");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "CouponReceiveNumber");
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
            RptBind("", "CouponReceiveNumber");
        }
    }
}