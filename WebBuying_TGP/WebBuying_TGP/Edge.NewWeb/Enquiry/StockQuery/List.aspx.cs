using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using System.Data;
using Edge.Web.Tools;
using Newtonsoft.Json.Linq;
using Edge.Messages.Manager;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_STOREGROUP;

namespace Edge.Web.WebBuying.Enquiry.StockQuery
{
    public partial class List : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BuyingStoreGroupController c = new BuyingStoreGroupController();

                string username = Tools.DALTool.GetCurrentUser().UserName;
                int storeid = c.GetStoreIDByUser(username);

                Grid1.PageSize = webset.ContentPageNum;
                logger.WriteOperationLog(this.PageName, "List");
                ControlTool.BindStoreWithType(StoreID, 0);
                RptBind("", "ProdCode");
                //导出
                //btnExport.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                //打印
                //btnPrint.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnExport.Enabled = false;
                btnPrint.Enabled = false;
                OutputSummaryData();
            }
        }

        private void RptBind(string strWhere, string orderby)
        {
            try
            {
                if (!string.IsNullOrEmpty(ProductCode.Text))
                {
                    if (string.IsNullOrEmpty(strWhere))
                    {
                        strWhere = " t.prodcode like '%" + ProductCode.Text.Trim() + "%'";
                    }
                    else
                    {
                        strWhere =strWhere+ " and t.prodcode like '%" + ProductCode.Text.Trim() + "%'";
                    }
                }
                if (!string.IsNullOrEmpty(ProductDesc.Text))
                {
                    if (string.IsNullOrEmpty(strWhere))
                    {
                        strWhere =  " (proddesc1 like '%" + ProductDesc.Text.Trim() + "%' or proddesc2 like '%" + ProductDesc.Text.Trim() + "%' or proddesc3 like '%" + ProductDesc.Text.Trim() + "%') ";
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
                if (StoreID.SelectedIndex != 0)
                {
                    if (string.IsNullOrEmpty(strWhere))
                    {
                        strWhere = " b.StoreID = " + StoreID.SelectedValue.Trim();
                    }
                    else
                    {
                        strWhere = strWhere + " and b.StoreID = " + StoreID.SelectedValue.Trim();
                    }
                }
                if (!string.IsNullOrEmpty(rblOnhand.SelectedValue))
                {
                    if (rblOnhand.SelectedValue == "1")
                    {
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strWhere = " OnhandQty > 0";
                        }
                        else
                        {
                            strWhere = strWhere + " and OnhandQty >0";
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(strWhere))
                        {
                            strWhere = " OnhandQty < 0";
                        }
                        else
                        {
                            strWhere = strWhere + " and OnhandQty <0";
                        }
                    }
                }
                ViewState["strWhere"] = strWhere;
                BuyingProductController controller = new BuyingProductController();
                int count = 0;
                DataSet ds = controller.GetStockList(strWhere, this.Grid1.PageSize, this.Grid1.PageIndex, out count, this.SortField.Text);
                this.Grid1.RecordCount = count;
                if (ds != null)
                {
                    this.Grid1.DataSource = ds.Tables[0].DefaultView;
                    this.Grid1.DataBind();
                }
                else
                {
                    this.Grid1.Reset();
                }
            }
            catch (Exception ex)
            {
                logger.WriteErrorLog("ProdCode", "Load Field", ex);
            }
        }

        private void OutputSummaryData()
        {
            DataTable source = GetDataTable();
            JObject summary = new JObject();
            int OnhandQtyTotal = 0;
            decimal moneyTotal = 0;
            if (this.Grid1.RecordCount > 0)
            {
                foreach (DataRow row in source.Rows)
                {
                    if (!string.IsNullOrEmpty(row["onhandQty"].ToString()))
                    {
                        OnhandQtyTotal += Convert.ToInt32(row["onhandQty"]);
                    }
                    if (!string.IsNullOrEmpty(row["money"].ToString()))
                    {
                        moneyTotal += Convert.ToDecimal(row["money"]);
                    }
                }
                
                summary.Add("onhandQty", OnhandQtyTotal);
                summary.Add("money", moneyTotal.ToString("F2"));
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
            Edge.SVA.BLL.BUY_PRODUCT product = new SVA.BLL.BUY_PRODUCT();
            table.Columns.Add(new DataColumn("onhandQty", typeof(int)));
            table.Columns.Add(new DataColumn("money", typeof(decimal)));
            DataRow row = null;
            row = table.NewRow();
            DataSet ds = product.GetSummary(ViewState["strWhere"].ToString());
            row[0] = ds.Tables[0].Rows[0]["OnhandQty"];
            row[1] = ds.Tables[0].Rows[0]["Price"];
            table.Rows.Add(row);
            return table;
        }
        #endregion

        #region 排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            BuyingProductController controller = new BuyingProductController();
            int count = 0;
            string sortFieldStr = String.Format("{0} {1}", sortField, sortDirection);
            this.SortField.Text = sortFieldStr;
            DataSet ds = controller.GetStockList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count, this.SortField.Text);
            this.Grid1.RecordCount = count;

            DataTable table = ds.Tables[0];

            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            BindGridWithSort(e.SortField, e.SortDirection);
        }
        #endregion

        protected string GetXiaoji(string Price, string OnhandQty)
        {

            if (!string.IsNullOrEmpty(Price))
            {
                float price = Convert.ToSingle(Price);
                int onhandQty = Convert.ToInt32(OnhandQty);
                return String.Format("{0:F}", price * onhandQty);
            }
            else
            {
                return String.Format("{0:F}", 0);
            }
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "ProdCode");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "ProdCode");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("", "ProdCode");
            OutputSummaryData();
            if (StoreID.SelectedText == "----------")
            {
                btnExport.Enabled = false;
                btnPrint.Enabled = false;
            }
            else
            {
                btnExport.Enabled = true;
                btnPrint.Enabled = true;
            }
        }

        //导出
        protected void btnExport_Click(object sender, EventArgs e)
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
            string okScript = Window2.GetShowReference("Export.aspx?ids=" + sb1.ToString().TrimEnd(',')+"&storeId="+this.StoreID.SelectedValue);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
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
            string okScript = Window2.GetShowReference("Print.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&storeId=" + this.StoreID.SelectedValue);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Print, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }

        protected void Grid1_OnRowDoubleClick(object sender, FineUI.GridRowClickEventArgs e)
        {
            Tools.SVASessionInfo.BuyingProdCode = this.Grid1.DataKeys[e.RowIndex][0].ToString();
            Tools.SVASessionInfo.BuyingProdDesc = this.Grid1.DataKeys[e.RowIndex][1].ToString();
            CloseAndPostBack();
        }

        protected void btnAddPicker_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            Tools.SVASessionInfo.BuyingProdCode = sb.ToString().TrimEnd(',');
            CloseAndPostBack();
        }

    }
}