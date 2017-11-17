using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Tools;
using System.Text;
using Edge.Web.Controllers;
using FineUI;
using Edge.Web.Controllers.Operation.CouponManagement.ChangeManagement.ChangeStatus;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.ChangeStatus
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponAdjust_H, Edge.SVA.Model.Ord_CouponAdjust_H>
    {
        ChangeStatusController controller = new  ChangeStatusController();

        #region Basic Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.Window1.Title = "搜索";
                this.WindowSearch.Title = "搜索";
                RegisterCloseEvent(btnClose);

                Edge.Web.Tools.ControlTool.BindReasonType(ReasonID);
                //Edge.Web.Tools.ControlTool.BindCouponType(CouponTypeID);
                Edge.Web.Tools.ControlTool.BindCouponType(CouponTypeID, "CouponTypeID =-1");
                Edge.Web.Tools.ControlTool.BindBrand(Brand);

                //btnAddSearchItem.OnClientClick = this.SearchListGrid.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDeleteResultItem.OnClientClick = this.AddResultListGrid.GetNoSelectionAlertReference(Resources.MessageTips.NotSelected);
                btnDeleteResultItem.ConfirmIcon = FineUI.MessageBoxIcon.Question;
                btnDeleteResultItem.ConfirmText = Resources.MessageTips.ConfirmDeleteRecord;

                InitData();
                SVASessionInfo.ChangeStatusController = null;
            }
            controller = SVASessionInfo.ChangeStatusController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Edge.SVA.Model.Ord_CouponAdjust_H item = this.GetAddObject();

            if (item != null)
            {
                if (item.CouponAdjustNumber.Equals(string.Empty))
                {
                    ShowAddFailed();
                    return;
                }
                item.BrandCode = Tools.DALTool.GetBrandCode(Tools.ConvertTool.ToInt(this.Brand.SelectedValue), null);//Add Brand Code
                item.StoreCode = Tools.DALTool.GetStoreCode(Tools.ConvertTool.ToInt(this.StoreID.SelectedValue), null);//Add Store Code
                item.OprID = Convert.ToInt32(Enum.Parse(typeof(Edge.Web.Controllers.CouponController.OprID), Edge.Web.Controllers.CouponController.OprID.ChangeStatus.ToString()));
                item.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                item.UpdatedOn = null;
                item.UpdatedBy = null;
                item.ApproveOn = null;
            }
            //老界面代码
            //if (ViewState["AddResult"] == null || ((DataTable)ViewState["AddResult"]).Rows.Count <= 0)
            //{
            //    ShowWarming(Resources.MessageTips.SelectCoupons);
            //    return;
            //}
            //新界面代码
            if (controller.ViewModel.CouponTable == null || controller.ViewModel.CouponTable.Rows.Count <= 0)
            {
                ShowWarning(Resources.MessageTips.SelectCoupons);
                return;
            }
            int count = Edge.Web.Tools.DALTool.Add<Edge.SVA.BLL.Ord_CouponAdjust_H>(item);
            if (count > 0)
            {
                //老界面代码
                //if (ViewState["AddResult"] != null)
                //{
                //    DataTable issuedDT = (DataTable)ViewState["AddResult"];
                //    DatabaseUtil.Factory.SetConnecctionString(DBUtility.PubConstant.ConnectionString);
                //    DatabaseUtil.Interface.IDatabase database = DatabaseUtil.Factory.CreateIDatabase();
                //    database.SetExecuteTimeout(600);

                //    DataTable needInsertDt = database.GetTableSchema("Ord_CouponAdjust_D");
                //    foreach (DataRow row in issuedDT.Rows)
                //    {
                //        DataRow dr = needInsertDt.NewRow();
                //        dr["CouponAdjustNumber"] = this.CouponAdjustNumber.Text;
                //        dr["CouponNumber"] = row["CouponNumber"];
                //        needInsertDt.Rows.Add(dr);
                //    }
                //    DatabaseUtil.Interface.IExecStatus es = database.InsertBigData(needInsertDt, "Ord_CouponAdjust_D");
                //    if (!es.Success)
                //    {
                //        ShowAddFailed();
                //        return;
                //    }
                //}
                //新界面代码
                if (controller.ViewModel.CouponTable != null)
                {
                    DataTable issuedDT = controller.ViewModel.CouponTable;
                    DatabaseUtil.Factory.SetConnecctionString(DBUtility.PubConstant.ConnectionString);
                    DatabaseUtil.Interface.IDatabase database = DatabaseUtil.Factory.CreateIDatabase();
                    database.SetExecuteTimeout(600);

                    DataTable needInsertDt = database.GetTableSchema("Ord_CouponAdjust_D");
                    foreach (DataRow row in issuedDT.Rows)
                    {
                        DataRow dr = needInsertDt.NewRow();
                        dr["CouponAdjustNumber"] = this.CouponAdjustNumber.Text;
                        dr["CouponNumber"] = row["CouponNumber"];
                        needInsertDt.Rows.Add(dr);
                    }
                    DatabaseUtil.Interface.IExecStatus es = database.InsertBigData(needInsertDt, "Ord_CouponAdjust_D");
                    if (!es.Success)
                    {
                        ShowAddFailed();
                        return;
                    }
                }

                Logger.Instance.WriteOperationLog(this.PageName, "Add Coupon Change Status  " + item.CouponAdjustNumber + " " + Resources.MessageTips.AddSuccess);

                CloseAndRefresh();
            }
            else
            {
                Logger.Instance.WriteOperationLog(this.PageName, "Add Coupon Change Status  " + item.CouponAdjustNumber + " " + Resources.MessageTips.AddFailed);

                ShowAddFailed();
            }
        }

        #endregion

        #region Basic Functions
        private void InitData()
        {
            this.CouponAdjustNumber.Text = DALTool.GetREFNOCode(Edge.Web.Controllers.CouponController.CouponRefnoCode.OrderCouponStatusAdjustmentHighSecurity);
            CreatedOn.Text = Edge.Web.Tools.DALTool.GetSystemDateTime();
            lblCreatedBy.Text = Edge.Web.Tools.DALTool.GetUserName(Edge.Web.Tools.DALTool.GetCurrentUser().UserID);
            CreatedBusDate.Text = Edge.Web.Tools.DALTool.GetBusinessDate();
            this.lblApproveStatus.Text = DALTool.GetApproveStatusString(ApproveStatus.Text);

            btnAddSearchItem.Enabled = SearchListGrid.RecordCount > 0 ? true : false;
            btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;

            Tools.ControlTool.BindBatchID(BatchCouponID);
            InitStoreByBrand();
        }

        protected override SVA.Model.Ord_CouponAdjust_H GetPageObject(SVA.Model.Ord_CouponAdjust_H obj)
        {
            List<System.Web.UI.Control> list = new List<System.Web.UI.Control>();

            foreach (System.Web.UI.Control con in this.Panel1.Controls)
            {
                if (con is FineUI.GroupPanel)
                {
                    foreach (System.Web.UI.Control c in con.Controls) list.Add(c);
                }
            }
            return base.GetPageObject(obj, list.GetEnumerator());
        }

        private void SummaryAmounts(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                decimal totalDenomination = Tools.ConvertTool.ConverType<decimal>(table.Compute(" sum(CouponAmount) ", "").ToString());
                this.lblTotalDenomination.Text = totalDenomination.ToString("N2");
            }
            else
            {
                this.lblTotalDenomination.Text = "0.00";
            }
        }
        #endregion

        #region Search Functions

        private DataTable GetSearchDataTable()
        {
            Edge.SVA.BLL.Coupon bll = new Edge.SVA.BLL.Coupon();

            int top = Edge.Web.Tools.ConvertTool.ConverType<int>(CouponCount.Text.Trim());
            int batchCouponID = Edge.Web.Tools.ConvertTool.ConverType<int>(BatchCouponID.Text.ToString().Trim());
            string couponNumber = CouponNumber.Text.Trim();
            string couponTypeID = CouponTypeID.SelectedValue;
            //string strWhere = string.Format(" Status != {0}", (int)CouponController.CouponStatus.Dormant);
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(webset.CouponStatusChangeStatusEnable))
            {

                strWhere = string.Format(" Coupon.Status in ( {0} )", webset.CouponStatusChangeStatusEnable);
            }
            else
            {
                strWhere = string.Format(" Coupon.Status in ( {0} )", "-1");
            }
            string filedOrder = " Coupon.CouponNumber ASC ";

            if (string.IsNullOrEmpty(couponTypeID))
            {
                couponTypeID = Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(this.StoreID.SelectedValue), 1);
            }

            strWhere = GetCouponSearchStrWhere(top, batchCouponID, couponNumber, couponTypeID, this.CouponUID.Text.Trim(), strWhere);

            //Display message
            int count = bll.GetCount(strWhere);

            if (count <= 0)
            {
                //this.JscriptPrint(Messages.Manager.MessagesTool.instance.GetMessage("90180"), "", Resources.MessageTips.WARNING_TITLE);
                ShowWarning(Messages.Manager.MessagesTool.instance.GetMessage("90180"));
                return null;
            }


            if ((top > webset.MaxSearchNum) || ((count > webset.MaxSearchNum) && top <= 0))
            {
                top = webset.MaxSearchNum;
                ShowWarning(Resources.MessageTips.IsMaxSearchLimit);
               // this.JscriptPrint(Resources.MessageTips.IsMaxSearchLimit, "", Resources.MessageTips.WARNING_TITLE);
            }

            DataSet ds = bll.GetListForBatchOperation(top, strWhere, filedOrder);

            //Edge.Web.Tools.DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");
            //Edge.Web.Tools.DataTool.AddCouponTypeName(ds, "CouponType", "CouponTypeID");
            //Edge.Web.Tools.DataTool.AddCouponStatus(ds, "StatusName", "Status");
            //Tools.DataTool.AddBatchCode(ds, "BatchCode", "BatchCouponID");

            return ds.Tables[0];
        }

        //绑定搜索结果列表
        private void BindSearchList()
        {
            if (ViewState["SearchResult"] != null)
            {
                this.SearchListGrid.PageSize = webset.ContentPageNum;
                DataTable dt = (DataTable)ViewState["SearchResult"];
                this.SearchListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.SearchListGrid.PageIndex + 1, this.SearchListGrid.PageSize);
                this.SearchListGrid.DataSource = Tools.DALTool.GetCouponViewDataTable(viewDT);
                this.SearchListGrid.DataBind();
            }
            else
            {
                this.SearchListGrid.PageSize = webset.ContentPageNum;
                this.SearchListGrid.PageIndex = 0;
                this.SearchListGrid.RecordCount = 0;
                this.SearchListGrid.DataSource = null;
                this.SearchListGrid.DataBind();
            }

            btnAddSearchItem.Enabled = SearchListGrid.RecordCount > 0 ? true : false;
        }

        //绑定待添加结果列表
        private void BindResultList()
        {
            if (ViewState["AddResult"] != null)
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                DataTable dt = (DataTable)ViewState["AddResult"];
                this.AddResultListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize);
                this.AddResultListGrid.DataSource = Tools.DALTool.GetCouponViewDataTable(viewDT);
                this.AddResultListGrid.DataBind();

                SummaryAmounts(dt);

            }
            else
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.PageIndex = 0;
                this.AddResultListGrid.RecordCount = 0;
                this.AddResultListGrid.DataSource = null;
                this.AddResultListGrid.DataBind();
            }

            btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;

            this.Brand.Enabled = this.StoreID.Enabled = AddResultListGrid.RecordCount > 0 ? false : true;
        }

        private void AddItem()
        {
            if (ViewState["SearchResult"] != null)
            {
                if (ViewState["AddResult"] == null)
                {
                    ViewState["AddResult"] = ((DataTable)ViewState["SearchResult"]).Clone();
                }
                DataTable addDTView = (DataTable)ViewState["AddResult"];
                if (addDTView.DefaultView.Count >= webset.MaxShowNum)
                {
                    ShowWarning(Resources.MessageTips.IsMaximumLimit);
                    return;
                }

                DataTable dtSearch = ((DataTable)ViewState["SearchResult"]).Clone();

                if (!cbSearchAll.Checked)
                {
                    string ids = "";

                    foreach (int row in SearchListGrid.SelectedRowIndexArray)
                    {
                        ids += string.Format("{0},", "'" + SearchListGrid.DataKeys[row][0].ToString() + "'");
                    }

                    ids = ids.TrimEnd(',');

                    if (string.IsNullOrEmpty(ids.Trim()))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    DataTable vsDT = (DataTable)ViewState["SearchResult"];
                    DataView dvSearch = vsDT.DefaultView;
                    dvSearch.RowFilter = "CouponNumber in (" + ids + ")";
                    dtSearch = dvSearch.ToTable();
                    foreach (DataRowView drv in dvSearch)
                    {
                        drv.Delete();
                    }
                    vsDT.AcceptChanges();
                    ViewState["SearchResult"] = vsDT;
                }
                else
                {
                    dtSearch = (DataTable)ViewState["SearchResult"];
                    ViewState["SearchResult"] = ((DataTable)ViewState["SearchResult"]).Clone();
                    cbSearchAll.Checked = false;
                }

                DataTable addDT = (DataTable)ViewState["AddResult"];
                DataTable newSearchDT = Edge.Web.Tools.ConvertTool.CombineTheSameDatatable2(addDT, dtSearch, "CouponNumber");
                ViewState["AddResult"] = newSearchDT;

                BindResultList();
                BindSearchList();
            }
        }

        private void DeleteItem()
        {
            //老界面代码
            //if (ViewState["AddResult"] != null)
            //{
            //    DataTable addDT = (DataTable)ViewState["AddResult"];

            //    foreach (int row in AddResultListGrid.SelectedRowIndexArray)
            //    {
            //        string couponNumber = AddResultListGrid.DataKeys[row][0].ToString();
            //        for (int j = addDT.Rows.Count - 1; j >= 0; j--)
            //        {
            //            if (addDT.Rows[j]["CouponNumber"].ToString().Trim() == couponNumber)
            //            {
            //                addDT.Rows.Remove(addDT.Rows[j]);
            //            }
            //        }
            //        addDT.AcceptChanges();
            //    }

            //    ViewState["AddResult"] = addDT;
            //    BindResultList();
            //}
            //转移界面删除代码
            if (controller.ViewModel.CouponTable != null)
            {
                DataTable addDT = controller.ViewModel.CouponTable;

                foreach (int row in AddResultListGrid.SelectedRowIndexArray)
                {
                    string couponNumber = AddResultListGrid.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["CouponNumber"].ToString().Trim() == couponNumber)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.CouponTable = addDT;
                BindResultList(controller.ViewModel.CouponTable);

            }
        }

        private void DeleteAllItem()
        {
            //老界面代码
            //if (ViewState["AddResult"] != null)
            //{
            //    DataTable addDT = ((DataTable)ViewState["AddResult"]).Clone();
            //    ViewState["AddResult"] = addDT;
            //    BindResultList();
            //}
            //删除界面代码
            if (controller.ViewModel.CouponTable != null)
            {
                DataTable addDT = controller.ViewModel.CouponTable.Clone();
                controller.ViewModel.CouponTable = addDT;
                BindResultList(controller.ViewModel.CouponTable);
            }
        }

        private void InitSearchList()
        {
            ViewState["SearchResult"] = null;
            BindSearchList();
        }

        private void InitResultList()
        {
            //老界面代码
            //ViewState["AddResult"] = null;
            //BindResultList();
            //删除界面代码
            controller.ViewModel.CouponTable = null;
            BindResultList(controller.ViewModel.CouponTable);
        }
        #endregion

        #region Search Events

        protected void btnViewSearch_Click(object sender, EventArgs e)
        {
            //InitSearchList();
            //this.Window1.Hidden = false;

            //转移界面
            ExecuteJS(WindowSearch.GetShowReference(string.Format("Coupon/Add.aspx?BrandID={0}&StoreID={1}", this.Brand.SelectedValue, this.StoreID.SelectedValue)));

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchListGrid.PageIndex = 0;

            int top = Edge.Web.Tools.ConvertTool.ConverType<int>(CouponCount.Text.Trim());
            int batchCouponID = Edge.Web.Tools.ConvertTool.ConverType<int>(BatchCouponID.SelectedValue);
            string couponNumber = CouponNumber.Text.Trim();
            string couponTypeID = CouponTypeID.SelectedValue;

            if ((top <= 0) && (batchCouponID <= 0) && string.IsNullOrEmpty(couponNumber) && string.IsNullOrEmpty(couponTypeID) && string.IsNullOrEmpty(this.CouponUID.Text.Trim()))
            {
                ShowWarning(Resources.MessageTips.NoSearchCondition);
                return;
            }

            if (top > webset.MaxSearchNum)
            {

                ShowWarning(Resources.MessageTips.IsMaxSearchLimit);
                return;
            }

            DataTable dt = GetSearchDataTable();
            ViewState["SearchResult"] = dt;
            BindSearchList();
        }

        protected void btnCloseSearch_Click(object sender, EventArgs e)
        {
            InitSearchList();
            this.Window1.Hidden = true;
        }

        protected void btnDeleteResultItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        protected void btnClearAllResultItem_Click(object sender, EventArgs e)
        {
            DeleteAllItem();
        }

        protected void btnAddSearchItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        protected void SearchListGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SearchListGrid.PageIndex = e.NewPageIndex;
            BindSearchList();
        }

        protected void AddResultListGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            //老界面代码
            //AddResultListGrid.PageIndex = e.NewPageIndex;
            //BindResultList();
            //删除界面代码
            AddResultListGrid.PageIndex = e.NewPageIndex;
            BindResultList(controller.ViewModel.CouponTable);
        }

        protected void CouponTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CouponTypeID.SelectedValue != "-1")
            {
                Tools.ControlTool.BindBatchID(BatchCouponID, Tools.ConvertTool.ConverType<int>(CouponTypeID.SelectedValue));
            }
            else
            {
                Tools.ControlTool.BindBatchID(BatchCouponID);
            }

        }

        protected void cbSearchAll_CheckedChanged(object sender, EventArgs e)
        {
            //if ((!this.cbSearchAll.Checked) && this.rptSearchList.Items.Count > 0)
            //{
            //    this.btnAddItem.Visible = true;
            //}
            //else
            //{
            //    this.btnAddItem.Visible = false;
            //}
            //this.lbtnDeleteIssued.Visible = !this.cbSearchAll.Checked;
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            //老界面
            //base.WindowEdit_Close(sender, e);
            //InitSearchList();

            base.WindowEdit_Close(sender, e);
            BindResultList(controller.ViewModel.CouponTable);
        }
        #endregion

        protected void Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitStoreByBrand();
            InitCouponTypeByStore();
            InitSearchList();
        }

        protected void StoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCouponTypeByStore();
            InitSearchList();
        }
        private void InitStoreByBrand()
        {
            Edge.Web.Tools.ControlTool.BindStoreWithBrand(StoreID, Edge.Web.Tools.ConvertTool.ToInt(this.Brand.SelectedValue));
        }
        private void InitCouponTypeByStore()
        {
            if (!string.IsNullOrEmpty(this.StoreID.SelectedValue))
                Edge.Web.Tools.ControlTool.BindCouponType(CouponTypeID, "CouponTypeID in (" + Tools.DALTool.GetCouponTypeListByStoreIDBingding(Tools.ConvertTool.ToInt(this.StoreID.SelectedValue), 2) + ") order by CouponTypeCode");
            else
                Edge.Web.Tools.ControlTool.BindCouponType(CouponTypeID, " 1>2");
        }

        //绑定添加结果（新）
        private void BindResultList(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                //DataTable dt = (DataTable)ViewState["AddResult"];
                this.AddResultListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize);
                this.AddResultListGrid.DataSource = Tools.DALTool.GetCouponViewDataTable(viewDT);
                this.AddResultListGrid.DataBind();

                SummaryAmounts(dt);
            }
            else
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.PageIndex = 0;
                this.AddResultListGrid.RecordCount = 0;
                this.AddResultListGrid.DataSource = null;
                this.AddResultListGrid.DataBind();
            }

            this.btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;
            this.Brand.Enabled = this.StoreID.Enabled = AddResultListGrid.RecordCount > 0 ? false : true;
        }

    }
}
