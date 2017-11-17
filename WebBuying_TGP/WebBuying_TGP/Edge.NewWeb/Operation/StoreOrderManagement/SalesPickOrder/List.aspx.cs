using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Controllers.Operation.StoreOrderManagement;
using Edge.Web.Tools;
using System.Text;
using Edge.SVA.Model.Domain.WebService.Response;

namespace Edge.Web.Operation.StoreOrderManagement.SalesPickOrder
{
    public partial class List : PageBase
    {
      
        SalesPickOrderController controller = new SalesPickOrderController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind("", "SalesPickOrderNumber");
               
                btnApprove.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
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
                }
                else
                {
                    this.btnApprove.Enabled = false;
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


                    string code = this.Code.Text.Trim();
                    string ordertype = this.OrderType.SelectedValue;
                    string CStatrtDate = this.CreateStartDate.Text;
                    string CEndDate = this.CreateEndDate.Text;
                    string AStatrtDate = this.ApproveStartDate.Text;
                    string AEndDate = this.ApproveEndDate.Text;
                    string prodcode = this.ProductCode.Text;
                    string proddesc = this.ProductDesc.Text;
                    string referenceNo = this.ReferenceNo.Text;
                    string cardnum = this.CardNumber.Text;
                    string status = this.ApproveStatus.SelectedValue;
                    string memberEmail = this.MemberEmail.Text;
                    string memberMobilePhone = this.MemberMobilePhone.Text;
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" SalesPickOrderNumber like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(memberEmail))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberEmail, 1, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    if (!string.IsNullOrEmpty(memberMobilePhone))
                    {
                        MemberInfoResponse member = ControlTool.BindMember(memberMobilePhone, 2, 1, "", 0, 0, "");
                        if (member != null)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(" and ");
                            }
                            sb.AppendFormat(" MemberID={0} ", member.MemberID);
                        }

                    }
                    if (!string.IsNullOrEmpty(referenceNo))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ReferenceNo like '%");
                        sb.Append(referenceNo);
                        sb.Append("%'");
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
                    if (!string.IsNullOrEmpty(cardnum))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" CardNumber like '%");
                        sb.Append(cardnum);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.AppendFormat(" ApproveStatus ='{0}'",status);
                    }
                    if (!string.IsNullOrEmpty(prodcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" exists(select d.prodcode from Ord_SalesPickOrder_D d where d.SalesPickOrderNumber=Ord_SalesPickOrder_H.SalesPickOrderNumber and prodcode='");
                        sb.Append(prodcode);
                        sb.Append("')");
                    }
                    if (!string.IsNullOrEmpty(proddesc))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" exists(select d.prodcode from Ord_SalesPickOrder_D d left join buy_product p on d.prodcode=p.prodcode where d.SalesPickOrderNumber=Ord_SalesPickOrder_H.SalesPickOrderNumber and proddesc1+proddesc2+proddesc3 like '%");
                        sb.Append(proddesc);
                        sb.Append("%')");
                    }
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                int count = 0;
                DataSet ds = controller.GetTransactionList(strWhere, Grid1.PageSize, Grid1.PageIndex, out count, orderby);
                ds.Tables[0].Columns.Add(new DataColumn("OrderTypeName", typeof(string)));
                int totalorderqty = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int orderType = dr["OrderType"] == null ? 0 : Convert.ToInt32(dr["OrderType"]);
                    if (orderType == 1)
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Direct delivery orders"; break;
                            case "zh-cn": dr["OrderTypeName"] = "直接产生快递单，拣货单完成"; break;
                            case "zh-hk": dr["OrderTypeName"] = "直接產生快遞單，揀貨單完成"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Need third party transfer"; break;
                            case "zh-cn": dr["OrderTypeName"] = "需要第三方中转"; break;
                            case "zh-hk": dr["OrderTypeName"] = "需要協力廠商中轉"; break;
                        }
                    }
                    if (!string.IsNullOrEmpty(this.ProductCode.Text))
                    {
                        totalorderqty = totalorderqty + DALTool.GetPickingOrderQTYByNumberProdCode(dr["SalesPickOrderNumber"].ToString(), this.ProductCode.Text);
                    }
                }

                this.RecordCount = count;
                this.Grid1.DataSource = ds.Tables[0].DefaultView;
                this.Grid1.DataBind();
                if (totalorderqty != 0)
                {
                    this.OrderQty.Text = totalorderqty.ToString();
                }
                else
                {
                    this.OrderQty.Text = "";
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("SalesPickOrder", "Load Faild", ex);
            }
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            int count = 0;
            DataSet ds = controller.GetTransactionList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count, sortField);
            ds.Tables[0].Columns.Add(new DataColumn("OrderTypeName", typeof(string)));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                int orderType = dr["OrderType"] == null ? 0 : Convert.ToInt32(dr["OrderType"]);
                if (orderType == 1)
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": dr["OrderTypeName"] = "Direct delivery orders"; break;
                        case "zh-cn": dr["OrderTypeName"] = "直接产生快递单，拣货单完成"; break;
                        case "zh-hk": dr["OrderTypeName"] = "直接產生快遞單，揀貨單完成"; break;
                    }
                }
                else
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": dr["OrderTypeName"] = "Need third party transfer"; break;
                        case "zh-cn": dr["OrderTypeName"] = "需要第三方中转"; break;
                        case "zh-hk": dr["OrderTypeName"] = "需要協力廠商中轉"; break;
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
        //批核
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            NewApproveTxns(Grid1, Window2);
        }

        //作废
        protected void btnVoid_Click(object sender, EventArgs e)
        {
            NewVoidTxns(Grid1, Window2);
        }
        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {
            //NewExportTxns(Grid1, Window2);
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "SalesPickOrderNumber");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "SalesPickOrderNumber");
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
            RptBind("", "SalesPickOrderNumber");
        }

    }
}