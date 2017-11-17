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

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
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

                        RptBind("" + Request["ProdCode"] + "", "ProdCode");
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
                    //string brandcode = this.txtBrandCode.Text.Trim();
                    string brandcode = this.BrandCode.SelectedValue;
                    string deptcode = this.DepartCode.SelectedValue;
                    string storecode = this.txtStoreCode.Text.Trim();
                    string decription = this.txtDesc.Text.Trim();
                    string season = this.SEASON.SelectedValue;
                    string year = this.Year.SelectedValue;
                    string sex = this.SEX.SelectedValue;
                    string color = this.ColorCode.SelectedValue;
                    string size = this.ProductSizeCode.SelectedValue;
                    /*产品编号*/
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
                    #region
                    //if (!string.IsNullOrEmpty(brandcode))
                    //{
                    //    if (sb.Length > 0)
                    //    {
                    //        sb.Append(" and ");
                    //    }
                    //    string descLan = "BrandCode";
                    //    sb.Append(descLan);
                    //    sb.Append(" like '%");
                    //    sb.Append(brandcode);
                    //    sb.Append("%'");
                    //}
                    #endregion
                    /*品牌编号*/
                    if (!string.IsNullOrEmpty(brandcode) && brandcode != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" BrandCode");
                        sb.Append(" = '");
                        sb.Append(brandcode);
                        sb.Append("'");
                    }
                    /*季节*/
                    if (!string.IsNullOrEmpty(season) && season != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ProdCode in (select ProdCode from BUY_PRODUCT_CLASSIFY where ForeignTable='SEASON'");
                        sb.AppendFormat(" and ForeignkeyID={0})", season);
                    }
                    /*部门编号*/
                    if (!string.IsNullOrEmpty(deptcode) && deptcode != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" DepartCode");
                        sb.Append(" like '%");
                        sb.Append(deptcode);
                        sb.Append("%'");
                    }
                    /*年份*/
                    if (!string.IsNullOrEmpty(year) && year != "----------")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ProdCode in (select ProdCode from BUY_PRODUCT_ADD_BAU");
                        sb.AppendFormat(" where  YEAR={0})", year);
                    }
                    /*性别*/
                    if (!string.IsNullOrEmpty(sex))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ProdCode in (select ProdCode from BUY_PRODUCT_CLASSIFY where ForeignTable='Gender'");
                        sb.AppendFormat(" and ForeignkeyID={0})", sex);
                    }
                    /*颜色*/
                    if (!string.IsNullOrEmpty(color) && color != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ColorCode");
                        sb.Append(" like '%");
                        sb.Append(color);
                        sb.Append("%'");
                    }
                    /*尺寸*/
                    if (!string.IsNullOrEmpty(size) && size != "-1")
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ProductSizeCode");
                        sb.Append(" like '%");
                        sb.Append(size);
                        sb.Append("%'");
                    }
                    /*店铺编号*/
                    if (!string.IsNullOrEmpty(storecode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" StoreCode");
                        sb.Append(" like '%");
                        sb.Append(storecode);
                        sb.Append("%'");
                    }
                    /*描述*/
                    if (!string.IsNullOrEmpty(decription))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" ProdDesc1");
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