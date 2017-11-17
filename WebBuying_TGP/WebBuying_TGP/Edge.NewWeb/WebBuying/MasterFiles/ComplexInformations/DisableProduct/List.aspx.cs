using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.DisableProduct
{
    /// <summary>
    /// 导入下架产品
    /// 创建人：lisa
    /// 创建时间：2016-12-14
    /// </summary>
    public partial class List : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
        ProductModifyTempController controller = new ProductModifyTempController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Grid1.PageSize = webset.ContentPageNum;
                logger.WriteOperationLog(this.PageName, "List");

                RptBind("", "");

                btnImport.OnClientClick = Window4.GetShowReference("/PublicForms/ImportForm.aspx?Menu=ProductModifyTemp", "Import");
                SVASessionInfo.ProductModifyTempController = null;
                btnUpdate.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnUpdate.ConfirmText = Resources.MessageTips.ConfirmNoProductModifyTemp;
            }
            controller = SVASessionInfo.ProductModifyTempController;
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
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ProdCode like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;

                ProductModifyTempController controller = new ProductModifyTempController();
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
                Tools.Logger.Instance.WriteErrorLog("Load ProductModifyTemp", "error", ex);
            }
        }

        #region 排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            ProductModifyTempController controller = new ProductModifyTempController();
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

      
       
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);

            if (!string.IsNullOrEmpty(SVASessionInfo.ProductModifyTempPath))
            {
                DataTable dt = ExcelTool.GetFirstSheet(SVASessionInfo.ProductModifyTempPath);

                try
                {
                    if (dt != null && dt.Rows.Count != 0)
                    {
                        dt.Columns.Add("Status", typeof(int));
                        dt.Columns.Add("CreatedOn", typeof(DateTime));
                        foreach (System.Data.DataRow item in dt.Rows)
                        {
                            item["Status"] = 0;
                            item["CreatedOn"] = DateTime.Now;
                        }
                        controller.InsetData(dt);
                        ShowWarning("导入成功!");
                    }

                }
                catch (Exception ex)
                {
                    ShowWarning("导入失败!");
                    logger.WriteOperationLog(this.PageName, ex.Message);
                }
                SVASessionInfo.ProductModifyTempPath = null;
            }
            RptBind("", "");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("", "");
        }
        //批核
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            NewApproveTxns(Grid1, HiddenWindowForm);
        }
        //同步数据到Sva
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            controller.UpdateSVAProduct();
        }
    }
}