using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.Operation.StoreOrderManagement;
using System.Data;
using Edge.Web.Tools;
using System.Text;

namespace Edge.Web.Operation.StoreOrderManagement.SalesShipOrder
{
    public partial class List : PageBase
    {

        SalesShipOrderController controller = new SalesShipOrderController();
        Edge.SVA.Model.Ord_SalesShipOrder_H model = new SVA.Model.Ord_SalesShipOrder_H();
        Edge.SVA.BLL.Ord_SalesShipOrder_H bll = new SVA.BLL.Ord_SalesShipOrder_H();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind("", "SalesShipOrderNumber");
                //btnStatus1.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);

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
                btnStatus2.Enabled = false;
                btnStatus3.Enabled = false;
                btnStatus4.Enabled = false;
                btnStatus5.Enabled = false;
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
                    string prodcode = this.ProductCode.Text.Trim();
                    string proddesc = this.ProductDesc.Text.Trim();
                    string status = this.Status.SelectedValue;
                    string referenceNo = this.ReferenceNo.Text.Trim();
                    string txnNo = this.TxnNo.Text.Trim();
                    string deliveryDate = this.DeliveryDate.Text.Trim();
                    string contact = this.Contact.Text.Trim();
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" SalesShipOrderNumber like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(txnNo))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" TxnNo like '%");
                        sb.Append(txnNo);
                        sb.Append("%'");
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
                    if (!string.IsNullOrEmpty(status))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" Status =");
                        sb.Append(status);

                    }
                    if (!string.IsNullOrEmpty(deliveryDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "DeliveryDate";
                        sb.Append(descLan);
                        sb.Append(" >= Cast('");
                        sb.Append(deliveryDate);
                        sb.Append("' as DateTime)");
                    }
                    if (!string.IsNullOrEmpty(contact))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" contact like '%");
                        sb.Append(contact);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(prodcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" exists(select d.prodcode from Ord_SalesShipOrder_D d where d.SalesShipOrderNumber=Ord_SalesShipOrder_H.SalesShipOrderNumber and prodcode='");
                        sb.Append(prodcode);
                        sb.Append("')");
                    }
                    if (!string.IsNullOrEmpty(proddesc))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" exists(select d.prodcode from Ord_SalesShipOrder_D d left join buy_product p on d.prodcode=p.prodcode where d.SalesShipOrderNumber=Ord_SalesShipOrder_H.SalesShipOrderNumber and proddesc1+proddesc2+proddesc3 like '%");
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
                            case "en-us": dr["OrderTypeName"] = "Need third party transfer"; break;
                            case "zh-cn": dr["OrderTypeName"] = "需要第三方中转"; break;
                            case "zh-hk": dr["OrderTypeName"] = "需要協力廠商中轉"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["OrderTypeName"] = "Direct delivery, express delivery completed"; break;
                            case "zh-cn": dr["OrderTypeName"] = "直接产生送货单，交付快递就算完成"; break;
                            case "zh-hk": dr["OrderTypeName"] = "直接產生送貨單，交付快遞就算完成"; break;
                        }
                    }
                    if (!string.IsNullOrEmpty(this.ProductCode.Text))
                    {
                        totalorderqty = totalorderqty + DALTool.GetPickingOrderQTYByNumberProdCode(dr["SalesShipOrderNumber"].ToString(), this.ProductCode.Text);
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
                Logger.Instance.WriteErrorLog("Store Order", "Load Faild", ex);
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
                        case "en-us": dr["OrderTypeName"] = "Need third party transfer"; break;
                        case "zh-cn": dr["OrderTypeName"] = "需要第三方中转"; break;
                        case "zh-hk": dr["OrderTypeName"] = "需要協力廠商中轉"; break;
                    }
                }
                else
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": dr["OrderTypeName"] = "Direct delivery, express delivery completed"; break;
                        case "zh-cn": dr["OrderTypeName"] = "直接产生送货单，交付快递就算完成"; break;
                        case "zh-hk": dr["OrderTypeName"] = "直接產生送貨單，交付快遞就算完成"; break;
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
        //发货
        protected void btnStatus1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    model = bll.GetModel(sb.ToString());
                    if (model != null)
                    {
                        if (!string.IsNullOrEmpty(model.DeliveryNumber) && !string.IsNullOrEmpty(model.LogisticsProviderID.ToString()) && model.LogisticsProviderID != 0)
                        {
                            model.Status = 1;
                            bll.Update(model);
                            RefreshPage();
                        }
                        else
                        {
                            ShowWarning("请填写物流公司和送货单号！");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog(this.PageName, string.Format("SalesShip  Order {0} Update  Failed", sb.ToString()), ex);
                ShowUpdateFailed();
                return;
            }
            Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip  Order {0} Update Success", sb.ToString()));
        }
        //中转签收
        protected void btnStatus2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    model = bll.GetModel(sb.ToString());
                    if (model != null)
                    {
                        model.Status = 2;
                        bll.Update(model);
                        RefreshPage();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog(this.PageName, string.Format("SalesShip  Order {0} Update  Failed", sb.ToString()), ex);
                ShowUpdateFailed();
                return;
            }
            Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip  Order {0} Update Success", sb.ToString()));
        }
        //顾客签收
        protected void btnStatus3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    model = bll.GetModel(sb.ToString());
                    if (model != null)
                    {
                        model.Status = 3;
                        bll.Update(model);
                        RefreshPage();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog(this.PageName, string.Format("SalesShip  Order {0} Update  Failed", sb.ToString()), ex);
                ShowUpdateFailed();
                return;
            }
            Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip  Order {0} Update Success", sb.ToString()));
        }
        //未发送作废
        protected void btnStatus4_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    model = bll.GetModel(sb.ToString());
                    if (model != null)
                    {
                        model.Status = 4;
                        bll.Update(model);
                        RefreshPage();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog(this.PageName, string.Format("SalesShip  Order {0} Update  Failed", sb.ToString()), ex);
                ShowUpdateFailed();
                return;
            }
            Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip  Order {0} Update Success", sb.ToString()));
        }

        //退回
        protected void btnStatus5_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    sb.Append(Grid1.DataKeys[row][0].ToString());
                    model = bll.GetModel(sb.ToString());
                    if (model != null)
                    {
                        model.Status = 5;
                        bll.Update(model);
                        RefreshPage();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog(this.PageName, string.Format("SalesShip  Order {0} Update  Failed", sb.ToString()), ex);
                ShowUpdateFailed();
                return;
            }
            Logger.Instance.WriteOperationLog(this.PageName, string.Format("SalesShip  Order {0} Update Success", sb.ToString()));
        }
        //导出
        protected void btnExport_Click(object sender, EventArgs e)
        {

            NewExportTxns3(Grid1, Window2);
        }
        //打印
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //NewPrintTxns(Grid1, Window2);
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "SalesShipOrderNumber");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "SalesShipOrderNumber");
        }
        #endregion

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("", "SalesShipOrderNumber");
        }

        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.DataItem is DataRowView)
            {
                DataRowView drv = e.DataItem as DataRowView;
                string Status = drv["Status"].ToString().Trim();
                if (Status != "")
                {
                    switch (Status)
                    {
                        case "0":
                            (Grid1.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "创建";
                            break;
                        case "1":
                            (Grid1.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "发货";
                            break;
                        case "2":
                            (Grid1.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "中转签收";
                            break;
                        case "3":
                            (Grid1.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "顾客签收";
                            break;
                        case "4":
                            (Grid1.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "未发送作废";
                            break;
                        case "5":
                            (Grid1.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text = "退回";
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
                string Status = drv["Status"].ToString().Trim();
                FineUI.WindowField editWF = Grid1.FindColumn("EditWindowField") as FineUI.WindowField;

                if (Status != "")
                {
                    switch (Status)
                    {
                        case "0":
                            editWF.Enabled = true;
                            break;
                        case "1":
                            editWF.Enabled = false;
                            break;
                        case "2":
                            editWF.Enabled = false;
                            break;
                        case "3":
                            editWF.Enabled = false;
                            break;
                        case "4":
                            editWF.Enabled = false;
                            break;
                        case "5":
                            editWF.Enabled = false;
                            break;
                    }
                }
            }
        }

        protected void Grid1_RowClick(object sender, FineUI.GridRowClickEventArgs e)
        {

            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                string Status = Grid1.DataKeys[row][2].ToString();

                if (Status != "")
                {
                    switch (Status)
                    {
                        case "0":
                            btnStatus1.Enabled = true;
                            btnStatus2.Enabled = false;
                            btnStatus3.Enabled = false;
                            btnStatus4.Enabled = true;
                            btnStatus5.Enabled = false;
                            break;
                        case "1":
                            btnStatus1.Enabled = false;
                            btnStatus2.Enabled = true;
                            btnStatus3.Enabled = true;
                            btnStatus4.Enabled = true;
                            btnStatus5.Enabled = true;
                            break;
                        case "2":
                            btnStatus1.Enabled = false;
                            btnStatus2.Enabled = false;
                            btnStatus3.Enabled = true;
                            btnStatus4.Enabled = false;
                            btnStatus5.Enabled = false;
                            break;
                        case "3":
                            btnStatus1.Enabled = false;
                            btnStatus2.Enabled = false;
                            btnStatus3.Enabled = false;
                            btnStatus4.Enabled = false;
                            btnStatus5.Enabled = true;
                            break;
                        case "4":
                            btnStatus1.Enabled = false;
                            btnStatus2.Enabled = false;
                            btnStatus3.Enabled = false;
                            btnStatus4.Enabled = false;
                            btnStatus5.Enabled = false;
                            break;
                        case "5":
                            btnStatus1.Enabled = false;
                            btnStatus2.Enabled = false;
                            btnStatus3.Enabled = false;
                            btnStatus4.Enabled = false;
                            btnStatus5.Enabled = false;

                            break;
                    }
                }
            }
        }

    }
}