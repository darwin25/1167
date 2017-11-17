using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Messages.Manager;
using System.Data;
using System.Text;
using Edge.Web.Controllers.Operation.StoreOrderManagement.TransInStoreOrder;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_STOREGROUP;

namespace Edge.Web.Operation.StoreOrderManagement.TransInOrder
{
    public partial class List : PageBase
    {
        //private const string fields = "OrderSupplierNumber,ApproveStatus,OrderType,ApprovalCode,SupplierID,StoreID,CreatedBusDate,ApproveBusDate,CreatedOn,CreatedBy,ApproveOn,ApproveBy";
        private const string fields = "[TransInOrderNumber],[ReferenceNo],[FromStoreID],[FromContactName],[FromContactPhone],[FromMobile],[FromEmail],[FromAddress],[StoreID],[StoreContactName],[StoreContactPhone],[StoreContactEmail],[StoreMobile],[StoreAddress],[Remark],[CreatedBusDate],[ApproveBusDate],[ApprovalCode],[ApproveStatus],[ApproveOn],[ApproveBy],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy]";

        TransInStoreOrderController controller = new TransInStoreOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind("", "TransInOrderNumber");
                btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "Add");
                btnApprove.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnVoid.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);

                ControlTool.BindStoreWithType(FromStoreID, 1); //1 Retail
                ControlTool.BindStoreWithType(StoreID, 1); //1 Retail
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
                }
                else
                {
                    this.btnApprove.Enabled = false;
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
                StringBuilder sb = new StringBuilder(strWhere);
                #region for search
                if (SearchFlag.Text == "1")
                {
                   

                    int fromstoreid = Tools.ConvertTool.ToInt(this.FromStoreID.SelectedValue);
                    int storeid = Tools.ConvertTool.ToInt(this.StoreID.SelectedValue);
                    string code = this.Code.Text.Trim();
                    string status = this.Status.SelectedValue.Trim();
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
                        sb.Append(" TransInOrderNumber like '%");
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
                        sb.Append(" exists(select d.prodcode from ord_TransInorder_d d where d.TransInordernumber=ord_TransInorder_h.TransInordernumber and prodcode='");
                        sb.Append(prodcode);
                        sb.Append("')");
                    }
                    if (!string.IsNullOrEmpty(proddesc))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" exists(select d.prodcode from ord_TransInorder_d d left join buy_product p on d.prodcode=p.prodcode where d.TransInordernumber=ord_TransInorder_h.TransInordernumber and proddesc1+proddesc2+proddesc3 like '%");
                        sb.Append(proddesc);
                        sb.Append("%')");
                    }
                    strWhere = sb.ToString();
                }
                else
                {
                    BuyingStoreGroupController c = new BuyingStoreGroupController();

                    string username = Tools.DALTool.GetCurrentUser().UserName;
                    int storeid = c.GetStoreIDByUser(username);
                    if (storeid > 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" StoreID =");
                        sb.Append(storeid);

                    }

                   strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                int count = 0;
                DataSet ds = controller.GetTransactionList(strWhere, Grid1.PageSize, Grid1.PageIndex, out count,orderby);
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

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "TransInOrderNumber");
        }
        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {

            NewExportTxns2(Grid1, Window2);
        }
        //打印
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //NewPrintTxns2(Grid1, Window2);
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "TransInOrderNumber");
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
            RptBind("", "TransInOrderNumber");
        }
    }
}