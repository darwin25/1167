using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    public partial class List : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Grid1.PageSize = webset.ContentPageNum;
                logger.WriteOperationLog(this.PageName, "List");

                RptBind("", "ProdCode");

                btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "Add");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;

                //支持BarCode的单项选择
                if (Request["picker"] != null)
                {
                    this.Grid1.EnableRowDoubleClickEvent = true;
                    this.Grid1.EnableCheckBoxSelect = false;
                    this.btnNew.Hidden = true;
                    this.btnDelete.Hidden = true;
                    FineUI.WindowField editWF = Grid1.FindColumn("EditWindowField") as FineUI.WindowField;
                    editWF.Hidden = true;
                    if (Request["BOM"] != null)
                    {
                        if (Request["BOM"] == "1")
                        {
                            RptBind("BOM=1", "ProdCode");
                        }
                    }
                    if (Request["ProdCode"] != null)
                    {

                        RptBind(""+Request["ProdCode"]+"", "ProdCode");
                    }
                }
                //支持促销界面的批量选择
                if (Request["multiplepicker"] != null)
                {
                    //this.Grid1.EnableRowDoubleClick = true;
                    this.Grid1.EnableCheckBoxSelect = true;
                    this.btnAddPicker.Hidden = false;
                    this.btnNew.Hidden = true;
                    this.btnDelete.Hidden = true;
                    FineUI.WindowField editWF = Grid1.FindColumn("EditWindowField") as FineUI.WindowField;
                    editWF.Hidden = true;
                }
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

                    string prodcode = this.txtProdCode.Text.Trim();
                    string brandcode = this.txtBrandCode.Text.Trim();
                    string storecode = this.txtStoreCode.Text.Trim();
                    string decription = this.txtDesc.Text.Trim();
                    if (!string.IsNullOrEmpty(prodcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ProdCode like '%");
                        sb.Append(prodcode);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(brandcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "BrandCode";
                        sb.Append(descLan);
                        sb.Append(" like '%");
                        sb.Append(brandcode);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(storecode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "StoreCode";
                        sb.Append(descLan);
                        sb.Append(" like '%");
                        sb.Append(storecode);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(decription))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ProdDesc1";
                        sb.Append(descLan);
                        sb.Append(" like '%");
                        sb.Append(decription);
                        sb.Append("%'");
                    }
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                BuyingProductController controller = new BuyingProductController();
                int count = 0;
                DataSet ds = controller.GetTransactionList(strWhere, this.Grid1.PageSize, this.Grid1.PageIndex, out count, this.SortField.Text);
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

        #region 排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            BuyingProductController controller = new BuyingProductController();
            int count = 0;
            string sortFieldStr = String.Format("{0} {1}", sortField, sortDirection);
            this.SortField.Text = sortFieldStr;
            DataSet ds = controller.GetTransactionList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count, this.SortField.Text);
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

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            ExecuteJS(HiddenWindowForm.GetShowReference("Delete.aspx?ids=" + sb.ToString().TrimEnd(',')));
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