using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Tools;
using System.Text;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE;
using Edge.SVA.Model.Domain.WebInterfaces;
using FineUI;
namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE
{
    /// <summary>
    /// 捆绑货品
    /// 创建人：王丽
    /// 创建时间：2015-11-19
    /// </summary>
    public partial class BundledGoods : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BOXSALE, Edge.SVA.Model.BUY_BOXSALE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBoxSaleController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                this.Grid1.PageSize = webset.ContentPageNum;
                if (!string.IsNullOrEmpty(Request.Params["ProdCode"]))
                {
                    string Code = Request.Params["ProdCode"];
                    this.BOMCode.Text = Code;
                    RptBind("BOMCode='" + Code + "'", "CreatedOn");
                }
                logger.WriteOperationLog(this.PageName, "update");
                //btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "Add");
                btnDelete.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDelete.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDelete.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;
                SVASessionInfo.BuyingBoxSaleController = null;
                BuyingBoxSaleController controller1 = new BuyingBoxSaleController();
                DataSet dsProdCode=controller1.GetList("BOMCode='" + BOMCode.Text + "'");
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(" ProdCode!='{0}' ", BOMCode.Text);
                if (dsProdCode != null && dsProdCode.Tables.Count > 0)
                {
                    foreach (DataRow row in dsProdCode.Tables[0].Rows)
                    {
                        sb.AppendFormat(" and ProdCode!='{0}'",row["ProdCode"]);
                    }
                    btnSelect.OnClientClick = Window2.GetShowReference("../../ComplexInformations/BUY_PRODUCT/List.aspx?picker=true&ProdCode=" + sb.ToString(), "Select");
                }
            }
            controller = SVASessionInfo.BuyingBoxSaleController;
        }


        #region Event
        private void RptBind(string strWhere, string orderby)
        {
            try
            {
               
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;
                BuyingBoxSaleController controller = new BuyingBoxSaleController();
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
                logger.WriteErrorLog("BUY_BOXSALE", "List", ex);
            }
        }
        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            BuyingBoxSaleController controller = new BuyingBoxSaleController();
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
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid1.SelectedRowIndexArray)
            {
                sb.Append(Grid1.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            ExecuteJS(HiddenWindowForm.GetShowReference("Delete.aspx?ids=" + sb.ToString().TrimEnd(',')));
            CloseAndPostBack();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            if (!string.IsNullOrEmpty(Request.Params["ProdCode"]))
            {
                string Code = Request.Params["ProdCode"];

                RptBind("BOMCode='" + Code + "'", "CreatedOn");
            }
        }
        //Close按钮
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            if (!string.IsNullOrEmpty(Tools.SVASessionInfo.BuyingProdCode))
            {
                this.ProdCode.Text = Tools.SVASessionInfo.BuyingProdCode;
            }
            if (!string.IsNullOrEmpty(Request.Params["ProdCode"]))
            {
                string Code = Request.Params["ProdCode"];

                RptBind("BOMCode='" + Code + "'", "CreatedOn");
            }
        }
        //保存并Close
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                logger.WriteOperationLog(this.PageName, " Add ");

                controller.ViewModel.MainTable = this.GetAddObject();

                if (controller.ViewModel.MainTable != null)
                {
                    controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                    controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
                }

                if (!ValidateData()) return;

                ExecResult er = controller.Add();
                if (er.Success)
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BoxSale Success Code:" + controller.ViewModel.MainTable.ProdCode);
                    CloseAndPostBack();
                    //RefreshPage();
                }
                else
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BoxSale Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                    ShowAddFailed();
                }
            }
            catch (Exception ex)
            {
                logger.WriteErrorLog("ProdCode", "Load Field", ex);
            }

        }
        //判断输入框的值
        protected bool ValidateData()
        {
            int defaultqty = ConvertTool.ToInt(this.DefaultQty.Text);
            int maxqty = ConvertTool.ToInt(this.MaxQty.Text);
            int minqty = ConvertTool.ToInt(this.MinQty.Text);
            if (defaultqty < minqty || defaultqty > maxqty)
            {
                ShowWarning(Resources.MessageTips.SetDefaultQty);
                return false;
            }
            return true;
        }
        #endregion

    }
}