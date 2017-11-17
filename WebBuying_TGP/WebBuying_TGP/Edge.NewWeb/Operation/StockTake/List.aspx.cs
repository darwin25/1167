using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Messages.Manager;
using System.Data;
using System.Text;
using Edge.Web.Controllers.Operation.StockTakeController;
using Edge.Web.Tools;

namespace Edge.Web.Operation.StockTake
{
    public partial class List : PageBase
    {
        private const string fields = "StockTakeID, StockTakeNumber,StockTakeDate,StoreID,Status,StockTakeType,Remark,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy";

        StockTakeController controller = new StockTakeController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;
                RptBind("", "StockTakeNumber");
                btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "Add");
                btnApprove.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnVoid.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                //导出
                btnExportStockTake01.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnExportStockTake02.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnExporrStockTakeVAR.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                //打印
                //btnPrint.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                ControlTool.BindStoreNew(StoreID);
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
                    //this.btnPrint.Enabled = true;
                    this.btnExportStockTake01.Enabled = true;
                    this.btnExportStockTake02.Enabled = true;
                    this.btnExporrStockTakeVAR.Enabled = true;
                }
                else
                {
                    this.btnApprove.Enabled = false;
                    this.btnVoid.Enabled = false;
                    //this.btnPrint.Enabled = false;
                    this.btnExportStockTake01.Enabled = false;
                    this.btnExportStockTake02.Enabled = false;
                    this.btnExporrStockTakeVAR.Enabled = false;
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

                    int storeid = Tools.ConvertTool.ToInt(this.StoreID.SelectedValue);
                    string code = this.Code.Text.Trim();
                    string status = this.Status.SelectedValue.Trim();
                    string stocktaketype = this.StockTakeType.SelectedValue;
                    string CStatrtDate = this.CreateStartDate.Text;
                    string CEndDate = this.CreateEndDate.Text;
                    string AStatrtDate = this.StockTakeStartDate.Text;
                    string AEndDate = this.StockTakeEndDate.Text;
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
                        sb.Append(" StockTakeNumber like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "Status";
                        sb.Append(descLan);
                        sb.Append(" ='");
                        sb.Append(status);
                        sb.Append("'");
                    }
                    if (!string.IsNullOrEmpty(stocktaketype))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" StockTakeType =");
                        sb.Append(stocktaketype);

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
                        string descLan = "StockTakeDate";
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
                        string descLan = "StockTakeDate";
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
                DataSet ds = controller.GetTransactionList(strWhere, Grid1.PageSize, Grid1.PageIndex, out count, orderby);
                ds.Tables[0].Columns.Add(new DataColumn("StockTakeTypeName", typeof(string)));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int stocktakeType = dr["StockTakeType"] == null ? 0 : Convert.ToInt32(dr["StockTakeType"]);
                    if (stocktakeType == 0)
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["StockTakeTypeName"] = "By Quantity"; break;
                            case "zh-cn": dr["StockTakeTypeName"] = "盘数量"; break;
                            case "zh-hk": dr["StockTakeTypeName"] = "盤數量"; break;
                        }
                    }
                    else
                    {
                        switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                        {
                            case "en-us": dr["StockTakeTypeName"] = "By Serial No"; break;
                            case "zh-cn": dr["StockTakeTypeName"] = "盘序列号"; break;
                            case "zh-hk": dr["StockTakeTypeName"] = "盤序列號"; break;
                        }
                    }
                }
                this.RecordCount = count;
                this.Grid1.DataSource = ds.Tables[0].DefaultView;
                this.Grid1.DataBind();
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteErrorLog("StockTake", "Load Faild", ex);
            }
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            int count = 0;
            DataSet ds = controller.GetTransactionList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count, sortField);
            ds.Tables[0].Columns.Add(new DataColumn("FullStoreID", typeof(string)));
            ds.Tables[0].Columns.Add(new DataColumn("StockTakeTypeName", typeof(string)));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int stocktakeType = dr["StockTakeType"] == null ? 0 : Convert.ToInt32(dr["StockTakeType"]);
                if (stocktakeType == 0)
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": dr["StockTakeTypeName"] = "By Quantity"; break;
                        case "zh-cn": dr["StockTakeTypeName"] = "盘数量"; break;
                        case "zh-hk": dr["StockTakeTypeName"] = "盤數量"; break;
                    }
                }
                else
                {
                    switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
                    {
                        case "en-us": dr["StockTakeTypeName"] = "By Serial No"; break;
                        case "zh-cn": dr["StockTakeTypeName"] = "盘序列号"; break;
                        case "zh-hk": dr["StockTakeTypeName"] = "盤序列號"; break;
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
        //盘点一导出
        protected void btnExportStockTake01_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window2.GetShowReference("Export.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&types=StockTake01", Resources.MessageTips.Export);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n STOCK TAKE NUMBER.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        //盘点二
        protected void btnExportStockTake02_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window2.GetShowReference("Export.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&types=StockTake02",Resources.MessageTips.Export);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n STOCK TAKE NUMBER.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        //差异
        protected void btnExporrStockTakeVAR_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window2.GetShowReference("Export.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&types=StockTakeVAR", Resources.MessageTips.Export);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n STOCK TAKE NUMBER.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        
        //打印
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window2.GetShowReference("Print.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&types=StockTake01", Resources.MessageTips.Print);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n STOCK TAKE NUMBER.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Print, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        //打印盘点二
        protected void btnPrint02_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window2.GetShowReference("Print.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&types=StockTake02", Resources.MessageTips.Print);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n STOCK TAKE NUMBER.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Print, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        //打印差异
        protected void btnTakeVAR_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window2.GetShowReference("Print.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&types=StockTakeVAR", Resources.MessageTips.Print);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n STOCK TAKE NUMBER.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Print, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            RptBind("", "StockTakeNumber");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "StockTakeNumber");
        }
        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.DataItem is DataRowView)
            {
                DataRowView drv = e.DataItem as DataRowView;
                string approveStatus = drv["Status"].ToString().Trim();
                //if (approveStatus != "")
                //{
                //    approveStatus = approveStatus.Substring(0, 1).ToUpper().Trim();
                //    switch (approveStatus)
                //    {
                //        case "A":
                //            break;
                //        case "P":
                //            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                //            break;
                //        case "V":
                //            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                //            break;
                //    }
                //}
            }
        }

        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            if (e.DataItem is DataRowView)
            {
                DataRowView drv = e.DataItem as DataRowView;
                int Status = int.Parse(drv["Status"].ToString());
                FineUI.WindowField editST01 = Grid1.FindColumn("ViewWindowField") as FineUI.WindowField;
                FineUI.WindowField editST02 = Grid1.FindColumn("ViewWindow2") as FineUI.WindowField;
                FineUI.WindowField editSTVAR = Grid1.FindColumn("ViewWindow3") as FineUI.WindowField;
                // FineUI.WindowField editWF = Grid1.FindColumn("EditWindowField") as FineUI.WindowField;

                if (Status != 0)
                {
                    switch (Status)
                    {
                        case 1:
                            editST01.Enabled = true;
                            editST02.Enabled = false;
                            editSTVAR.Enabled = false;
                            break;
                        case 2:
                            editST01.Enabled = false;
                            editST02.Enabled = true;
                            editSTVAR.Enabled = false;
                            break;
                        case 3:
                            editST01.Enabled = false;
                            editST02.Enabled = false;
                            editSTVAR.Enabled = true;
                            break;
                        case 4:
                            editST01.Enabled = false;
                            editST02.Enabled = false;
                            editSTVAR.Enabled = false;
                            break;
                        case 5:
                            editST01.Enabled = false;
                            editST02.Enabled = false;
                            editSTVAR.Enabled = false;
                            break;
                        case 6:
                            editST01.Enabled = false;
                            editST02.Enabled = false;
                            editSTVAR.Enabled = false;
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
            RptBind("", "StockTakeNumber");
        }
    }
}