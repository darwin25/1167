using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using System.Text;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion
{
    public partial class ListByBauhuas : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProductController productController = new BuyingProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Grid1.PageSize = webset.ContentPageNum;
                logger.WriteOperationLog(this.PageName, "List");

                RptBind("", "PromotionCode");

                btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "Add");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;
                InitData();
            }
        }


        protected void InitData()
        {
            productController.BindDepart(this.DepartCode);
            productController.BindBrand(this.BrandCode);
            productController.BindColor(this.ColorCode);
            productController.BindProSize(this.ProductSizeCode);
            ControlTool.BindYear(this.Year);
            //绑定季节
            ControlTool.BindSEASON(this.SEASON);
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
                    string brandcode = this.BrandCode.SelectedValue;
                    string deptcode = this.DepartCode.SelectedValue;
                    string season = this.SEASON.SelectedValue;
                    string year = this.Year.SelectedValue;
                    string sex = this.SEX.SelectedValue;
                    string color = this.ColorCode.SelectedValue;
                    string size = this.ProductSizeCode.SelectedValue;
                    string code = this.Code.Text.Trim();
                    string desc = this.Desc.Text.Trim();
                    /*产品编号*/
                    if (!string.IsNullOrEmpty(prodcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1");
                        sb.AppendFormat(" and EntityNum like '%{0}%')", prodcode);
                    }
                    /*品牌编号*/
                    if (!string.IsNullOrEmpty(brandcode) && brandcode != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1 ");
                        sb.AppendFormat(" and EntityNum in (select ProdCode  from BUY_PRODUCT where BrandCode='{0}' ))", brandcode);
                    }
                    /*季节*/
                    if (!string.IsNullOrEmpty(season) && season != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1 ");
                        sb.Append(" and EntityNum in (select ProdCode  from BUY_PRODUCT where ProdCode in (select ProdCode from BUY_PRODUCT_CLASSIFY ");
                        sb.AppendFormat(" where ForeignTable='SEASON' and ForeignkeyID={0}))) ",season);
                    }
                    /*部门编号*/
                    if (!string.IsNullOrEmpty(deptcode) && deptcode != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1 ");
                        sb.AppendFormat(" and EntityNum in (select ProdCode  from BUY_PRODUCT where DepartCode like '%{0}%' ))", deptcode);
                    }
                    /*年份*/
                    if (!string.IsNullOrEmpty(year) && year != "----------")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1 ");
                        sb.Append(" and EntityNum in (select ProdCode  from BUY_PRODUCT where ProdCode in (select ProdCode from BUY_PRODUCT_ADD_BAU");
                        sb.AppendFormat(" where  YEAR={0})))", year);
                    }
                    /*性别*/
                    if (!string.IsNullOrEmpty(sex))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1 ");
                        sb.Append(" and EntityNum in (select ProdCode  from BUY_PRODUCT where ProdCode in (select ProdCode from BUY_PRODUCT_CLASSIFY ");
                        sb.AppendFormat(" where ForeignTable='Gender' and ForeignkeyID={0}))) ", sex);
                    }
                    /*颜色*/
                    if (!string.IsNullOrEmpty(color) && color != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1 ");
                        sb.AppendFormat(" and EntityNum in (select ProdCode  from BUY_PRODUCT where ColorCode like '%{0}%' ))", color);
                    }
                    /*尺寸*/
                    if (!string.IsNullOrEmpty(size) && size != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode in (select PromotionCode from Promotion_Hit_PLU where EntityType=1 ");
                        sb.AppendFormat(" and EntityNum in (select ProdCode  from BUY_PRODUCT where ProductSizeCode like '%{0}%' ))", size);
                    }
                    /*编码*/
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" PromotionCode like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    /*描述*/
                    if (!string.IsNullOrEmpty(desc))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "Note";
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

                BuyingNewPromotionController controller = new BuyingNewPromotionController();
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
                logger.WriteErrorLog("CPrice", "Load Field", ex);
            }
        }

        #region 排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            BuyingNewPromotionController controller = new BuyingNewPromotionController();
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

            RptBind("", "PromotionCode");
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind("", "PromotionCode");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("", "PromotionCode");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            NewApproveTxns(Grid1, Window2);
        }

        protected void btnVoid_Click(object sender, EventArgs e)
        {
            NewVoidTxns(Grid1, HiddenWindowForm);
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
                            //(Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            drv["ApprovalCode"] = "";
                            break;
                        case "V":
                            //(Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            drv["ApprovalCode"] = "";
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
                            //(Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            drv["ApprovalCode"] = "";
                            break;
                        case "V":
                            editWF.Enabled = false;
                            //(Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            drv["ApprovalCode"] = "";
                            break;
                    }
                }
            }
        }
    }
}