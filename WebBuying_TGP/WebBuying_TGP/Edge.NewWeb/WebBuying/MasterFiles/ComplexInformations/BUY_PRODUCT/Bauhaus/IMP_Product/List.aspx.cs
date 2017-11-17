using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Edge.Security;
using System.IO;
using FineUI;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.IMP_Product
{
    public partial class List : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
        IMP_PRODUCTController controller = new IMP_PRODUCTController();
        Edge.SVA.BLL.IMP_PRODUCT_TEMP product_tempBLL = new Edge.SVA.BLL.IMP_PRODUCT_TEMP();
        BuyingProductController productController = new BuyingProductController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Grid1.PageSize = webset.ContentPageNum;
                logger.WriteOperationLog(this.PageName, "List");

                RptBind("", "");

                btnImport.OnClientClick = Window4.GetShowReference("/PublicForms/ImportForm.aspx?Menu=Product", "Import");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;


                InitData();
                SVASessionInfo.ImportIMP_PRODUCTPath = null;
                SVASessionInfo.IMP_PRODUCTController = null;
            }
            controller = SVASessionInfo.IMP_PRODUCTController;
            productController = SVASessionInfo.BuyingProductController;
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
                    string year = this.Year.Text;
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

                IMP_PRODUCTController controller = new IMP_PRODUCTController();
                int count = 0;

                int startindex = this.Grid1.PageSize * this.Grid1.PageIndex + 1;
                int endindex = this.Grid1.PageSize * (this.Grid1.PageIndex + 1);
                DataSet ds = controller.GetTransactionList(strWhere, startindex, endindex, out count, this.SortField.Text);

                ViewState["Search"] = ds;
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
                logger.WriteErrorLog("IMP_PRODUCT", "Load Field", ex);
            }
        }

        protected void InitData()
        {
            productController.BindDepart(this.DepartCode);
            productController.BindBrand(this.BrandCode);
            productController.BindColor(this.ColorCode);
            productController.BindProSize(this.ProductSizeCode);
            //ControlTool.BindYear(this.Year);
            //绑定季节
            ControlTool.BindSEASON(this.SEASON);
        }

        #region 排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            IMP_PRODUCTController controller = new IMP_PRODUCTController();
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
        protected void btnExport_Click(object sender, EventArgs e)
        {
           

            int count = 0;
            DataSet ds = controller.GetTransactionList(ViewState["strWhere"].ToString(), 0, webset.MaxSearchNum, out count, "INTERNAL_PRODUCT_CODE");
            if (ViewState["Search"] == null)
            {
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            DateTime start = DateTime.Now;
            string fileName = controller.UpLoadFileToServer(ds);
            int records = 0;

            try
            {
                string exportname = "IMP_PRODUCTInfo.xls";

                Tools.ExportTool.ExportFile(fileName, exportname);

                Tools.Logger.Instance.WriteExportLog("Batch Export IMP_PRODUCT", exportname, start, records, null);
            }
            catch (Exception ex)
            {
                string fn = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                Logger.Instance.WriteExportLog("Batch Export IMP_PRODUCT", fn, start, records, ex.Message);
                ShowWarning(ex.Message);
            }
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind("", "");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);


            if (!string.IsNullOrEmpty(SVASessionInfo.ImportIMP_PRODUCTPath))
            {
                DataTable dt = ExcelTool.GetFirstSheet(SVASessionInfo.ImportIMP_PRODUCTPath);
                product_tempBLL.trunc();

                try
                {
                    if (dt != null && dt.Rows.Count != 0)
                    {
                        controller.InsetData(dt);
                        ShowWarning("导入成功!");
                    }

                }
                catch (Exception ex)
                {
                    ShowWarning("导入失败!");
                    logger.WriteOperationLog(this.PageName, ex.Message);
                }
                SVASessionInfo.ImportIMP_PRODUCTPath = null;
            }
            RptBind("", "");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind("", "");
        }
    }
}