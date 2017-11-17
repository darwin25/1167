using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE;
using System.Text;
using System.Data;
using FineUI;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE
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

                //RptBind("", "Barcode");
                RptBind("ProdCode='" + this.txtProdCode.Text + "'", "Barcode");

                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;

                btnSelect.OnClientClick = Window2.GetShowReference("../../ComplexInformations/BUY_PRODUCT/List.aspx?picker=true", "Select");
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

                    string barcode = this.BarCode.Text.Trim();
                    string prodcode = this.ProdCode.Text.Trim();
                    if (!string.IsNullOrEmpty(barcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" Barcode like '%");
                        sb.Append(barcode);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(prodcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ProdCode";
                        sb.Append(descLan);
                        sb.Append(" like '%");
                        sb.Append(prodcode);
                        sb.Append("%'");
                    }
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                BuyingBarCodeController controller = new BuyingBarCodeController();
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
                logger.WriteErrorLog("BarCode", "Load Field", ex);
            }
        }

        #region 排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            BuyingBarCodeController controller = new BuyingBarCodeController();
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

            //RptBind("", "Barcode");
            RptBind("ProdCode='" + this.txtProdCode.Text + "'", "Barcode");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);

            if (!string.IsNullOrEmpty(Tools.SVASessionInfo.BuyingProdCode))
            {
                btnNew.Enabled = true;
                btnNew.OnClientClick = Window3.GetShowReference("Add.aspx", Resources.MessageTips.Add);
                this.txtSelect.Text = Tools.SVASessionInfo.BuyingProdCode;
                this.txtProdCode.Text = Tools.SVASessionInfo.BuyingProdCode;
                this.txtDesc.Text = Tools.SVASessionInfo.BuyingProdDesc;
            }
            RptBind("ProdCode='" + this.txtProdCode.Text + "'", "Barcode");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            //RptBind("", "Barcode");
            RptBind("ProdCode='" + this.txtProdCode.Text + "'", "Barcode");
        }
    }
}