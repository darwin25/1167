using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BRAND;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BRAND
{
    /// <summary>
    /// 店铺品牌
    /// 创建人：Lisa
    /// 创建时间：2016-08-10
    /// </summary>
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind("StoreBrandID>0", "StoreBrandCode");
                btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "Add");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;
            }
        }
        #region Event
        private void RptBind(string strWhere, string orderby)
        {
            try
            {
                #region for search
                if (SearchFlag.Text == "1")
                {
                    StringBuilder sb = new StringBuilder(strWhere);

                    string code = this.Code.Text.Trim();
                    string desc = this.Desc.Text.Trim();
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" StoreBrandCode like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(desc))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "StoreBrandName1";
                        sb.Append(descLan);
                        sb.Append(" like '%");
                        sb.Append(desc);
                        sb.Append("%'");
                    }
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                BrandController controller = new BrandController();
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
                Tools.Logger.Instance.WriteErrorLog("Load Brand", "error", ex);
            }
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            BrandController controller = new BrandController();
            int count = 0;
            string orderStr = String.Format("{0} {1}", sortField, sortDirection);
            this.SortField.Text = orderStr;
            DataSet ds = controller.GetTransactionList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count, orderStr);
            this.Grid1.RecordCount = count;

            DataTable table = ds.Tables[0];

            Grid1.DataSource = table;
            Grid1.DataBind();
        }
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            BindGridWithSort(e.SortField, e.SortDirection);
        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            //ExecuteJS(HiddenWindowForm.GetShowReference("Delete.aspx?ids=" + sb.ToString().TrimEnd(',')));
            ExecuteJS(HiddenWindowForm.GetShowReference("Delete.aspx?ids=" + sb.ToString().TrimEnd(',')));
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("StoreBrandID>0", "StoreBrandCode");
        }

        #endregion

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("StoreBrandID>0", "StoreBrandCode");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("StoreBrandID>0", "StoreBrandCode");
        }
    }
}