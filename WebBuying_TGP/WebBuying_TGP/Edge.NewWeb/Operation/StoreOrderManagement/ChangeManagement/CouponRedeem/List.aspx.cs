using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Messages.Manager;
using Edge.Web.Controllers;
using System.Text;
using Edge.Web.Controllers.Operation.CouponManagement.ChangeManagement;
using Edge.Web.Tools;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponRedeem
{
    public partial class List : PageBase
    {
        private const string fields = "[CouponAdjustNumber],[TxnDate],[ApproveStatus],[ApproveOn],[ApproveBy],[CreatedOn],[CreatedBy],[UpdatedOn],[UpdatedBy],[CreatedBusDate],[ApproveBusDate],[ApprovalCode]";
        protected static string strWhere = " OprID =" + ((int)CouponController.OprID.Redeemed).ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                this.Grid1.PageSize = webset.ContentPageNum;

                RptBind(strWhere, "CouponAdjustNumber");
                btnNew.OnClientClick = Window2.GetShowReference("Add.aspx", "新增");
                btnApprove.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnVoid.OnClientClick = Grid1.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);

                ControlTool.BindBrand(this.Brand);
                InitStoreByBrand();
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
                }
                else
                {
                    this.btnApprove.Enabled = false;
                    this.btnVoid.Enabled = false;
                }
                this.Grid1.RecordCount = value;
                ViewState["RecordCount"] = value;
            }
        }

        private void RptBind(string strWhere, string orderby)
        {

            //Edge.SVA.BLL.Ord_CouponAdjust_H bll = new Edge.SVA.BLL.Ord_CouponAdjust_H()
            //{
            //    StrWhere = strWhere,
            //    Order = orderby,
            //    Fields = fields,
            //    Ascending = false
            //};

            //System.Data.DataSet ds = null;
            //if (this.RecordCount < 0)
            //{
            //    int count = 0;
            //    ds = bll.GetList(this.Grid1.PageSize, this.Grid1.PageIndex, out count);
            //    this.RecordCount = count;

            //}
            //else
            //{
            //    ds = bll.GetList(this.Grid1.PageSize, this.Grid1.PageIndex);
            //}

            //Tools.DataTool.AddUserName(ds, "CreatedName", "CreatedBy");
            //Tools.DataTool.AddUserName(ds, "ApproveName", "ApproveBy");
            //Tools.DataTool.AddCouponApproveStatusName(ds, "ApproveStatusName", "ApproveStatus");
            //this.Grid1.DataSource = ds.Tables[0].DefaultView;
            //this.Grid1.DataBind();

            try
            {
                #region for search
                if (SearchFlag.Text == "1")
                {
                    StringBuilder sb = new StringBuilder(strWhere);

                    string brandcode = Tools.DALTool.GetBrandCode(Tools.ConvertTool.ToInt(this.Brand.SelectedValue), null);
                    string storecode = Tools.DALTool.GetStoreCode(Tools.ConvertTool.ToInt(this.Store.SelectedValue), null);
                    string code = this.Code.Text.Trim();
                    string status = this.Status.SelectedValue.Trim();
                    string CStatrtDate = this.CreateStartDate.Text;
                    string CEndDate = this.CreateEndDate.Text;
                    string AStatrtDate = this.ApproveStartDate.Text;
                    string AEndDate = this.ApproveEndDate.Text;
                    if (!string.IsNullOrEmpty(brandcode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" BrandCode ='");
                        sb.Append(brandcode);
                        sb.Append("'");
                    }
                    if (!string.IsNullOrEmpty(storecode))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" StoreCode ='");
                        sb.Append(storecode);
                        sb.Append("'");
                    }
                    if (!string.IsNullOrEmpty(code))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        sb.Append(" CouponAdjustNumber like '%");
                        sb.Append(code);
                        sb.Append("%'");
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ApproveStatus";
                        sb.Append(descLan);
                        sb.Append(" ='");
                        sb.Append(status);
                        sb.Append("'");
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
                        string descLan = "ApproveOn";
                        sb.Append(descLan);
                        sb.Append(" >= Cast('");
                        sb.Append(AStatrtDate);
                        sb.Append("' as DateTime) ");
                    }
                    if (!string.IsNullOrEmpty(AEndDate))
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" and ");
                        }
                        string descLan = "ApproveOn";
                        sb.Append(descLan);
                        sb.Append(" < Cast('");
                        sb.Append(AEndDate);
                        sb.Append("' as DateTime) + 1 ");
                    }
                    strWhere = sb.ToString();
                }
                #endregion
                //记录查询条件用于排序
                ViewState["strWhere"] = strWhere;


                ChangeManagementController c = new ChangeManagementController();
                int count = 0;
                DataSet ds = c.GetTransactionList(strWhere, this.Grid1.PageSize, this.Grid1.PageIndex, out count, this.SortField.Text);
                this.RecordCount = count;
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
                Tools.Logger.Instance.WriteErrorLog("Load CouponRedeem", "error", ex);
            }
        }
        #endregion

        #region Event
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //StringBuilder sbMsg = new StringBuilder();
            //foreach (int row in Grid1.SelectedRowIndexArray)
            //{
            //    sb.Append(Grid1.DataKeys[row][0].ToString());
            //    sb.Append(",");
            //    sbMsg.Append(Grid1.DataKeys[row][0].ToString());
            //    sbMsg.Append(";\n");
            //}

            //Window2.Title = Resources.MessageTips.Approve;
            //ApproveTxns(sbMsg.ToString(), Window2.GetShowReference("Approve.aspx?ids=" + sb.ToString().TrimEnd(',')), "");
            ////FineUI.PageContext.RegisterStartupScript(Window2.GetShowReference("Approve.aspx?ids=" + sb.ToString().TrimEnd(',')));
            ////FineUI.PageContext.Redirect("Approve.aspx?ids=" + sb.ToString().TrimEnd(','));
            NewApproveTxns(Grid1, Window2);
        }

        protected void btnVoid_Click(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //StringBuilder sbMsg = new StringBuilder();
            //foreach (int row in Grid1.SelectedRowIndexArray)
            //{
            //    sb.Append(Grid1.DataKeys[row][0].ToString());
            //    sb.Append(",");
            //    sbMsg.Append(Grid1.DataKeys[row][0].ToString());
            //    sbMsg.Append(";\n");
            //}
            //VoidTxns(sbMsg.ToString(), HiddenWindowForm.GetShowReference("Void.aspx?ids=" + sb.ToString().TrimEnd(',')), "");
            ////FineUI.PageContext.Redirect("Void.aspx?ids=" + sb.ToString().TrimEnd(','));
            NewVoidTxns(Grid1, HiddenWindowForm);
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind(strWhere, "CouponAdjustNumber");
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            RptBind(strWhere, "CouponAdjustNumber");
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
                            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            break;
                        case "V":
                            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
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
                            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            break;
                        case "V":
                            editWF.Enabled = false;
                            (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
                            break;
                    }
                }
            }
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            ChangeManagementController c = new ChangeManagementController();
            int count = 0;
            string sortFieldStr = String.Format("{0} {1}", sortField, sortDirection);
            this.SortField.Text = sortFieldStr;
            DataSet ds = c.GetTransactionList(ViewState["strWhere"].ToString(), this.Grid1.PageSize, this.Grid1.PageIndex, out count, this.SortField.Text);
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

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            this.Grid1.PageIndex = 0;
            this.SearchFlag.Text = "1";
            RptBind(strWhere, "CouponAdjustNumber");
        }
        protected void Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitStoreByBrand();
        }
        private void InitStoreByBrand()
        {
            Edge.Web.Tools.ControlTool.BindStoreWithBrand(this.Store, Edge.Web.Tools.ConvertTool.ToInt(this.Brand.SelectedValue));
        }
    }
}
