using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponQuery
{
    public partial class List : PageBase
    {

        private const string fields = "CouponNumber,CouponTypeID,BatchCouponID,Status,StockStatus,CouponAmount,CreatedOn,CouponExpiryDate";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ResultGrid.PageSize = webset.ContentPageNum;

                //ControlTool.BindCouponType(CouponTypeID);
                Edge.Web.Tools.ControlTool.BindCouponTypeWithoutBrand(CouponTypeID, " 1=1 order by CouponTypeCode");
                ControlTool.BindCouponStatus(Status);
                ControlTool.BindCouponStockStatus(StockStatus);
                ControlTool.BindProduct(Products);
                ControlTool.BindDeparment(Deparment);
                this.BindBatchID(BatchCouponID);

                Edge.Web.Tools.ControlTool.BindBrand(Brand);
                InitStoreByBrand();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.BatchCouponID.SelectedValue == null)
            {
                ShowWarning(Resources.MessageTips.NoData);
                RptBind(null);
                return;
            }
            //不填内容直接搜索时要弹出提示消息
            if (!this.hasInput())
            {
                ShowWarning(Resources.MessageTips.NoSearchCondition);
                RptBind(null);
                return;
            }

            this.RecordCount = -1;
            this.ResultGrid.PageIndex = 0;

            string strWhere = GetStrWhere();
                        
            Logger.Instance.WriteOperationLog(this.PageName, "Coupon Enquiry");

            RptBind(strWhere);
        }

        protected void CouponTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CouponTypeID.SelectedValue == "-1")
            {
                ControlTool.BindProduct(Products);
                ControlTool.BindDeparment(Deparment);
                this.BindBatchID(BatchCouponID);
            }
            else
            {
                int couponTypeID = ConvertTool.ConverType<int>(this.CouponTypeID.SelectedValue);

                ControlTool.BindDeparment(Deparment, couponTypeID);
                ControlTool.BindProduct(Products, couponTypeID);

                this.BindBatchID(BatchCouponID, Tools.ConvertTool.ConverType<int>(CouponTypeID.SelectedValue));
            }
        }

        private void RptBind(string strWhere)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                this.ResultGrid.RecordCount = 0;
                this.ResultGrid.DataSource = null; 
                this.ResultGrid.DataBind();
                return;
            }
           /// int currentPage = this.ResultGrid.PageIndex < 1 ? 0 : this.ResultGrid.PageIndex - 1;

            Edge.SVA.BLL.Coupon coupon = new Edge.SVA.BLL.Coupon();
            DataSet ds = null;
            if (this.RecordCount < 0)
            {
                int count = 0;
                ds = coupon.GetListForTotal(this.ResultGrid.PageSize, this.ResultGrid.PageIndex, strWhere, "CouponNumber", fields, 600);
                this.RecordCount = ds != null && ds.Tables.Count > 1 ? int.TryParse(ds.Tables[1].Rows[0]["Total"].ToString(), out count) ? count : 0 : 0;
            }
            else
            {
                ds = coupon.GetList(this.ResultGrid.PageSize, this.ResultGrid.PageIndex, strWhere, "CouponNumber", fields, 600);
            }

            this.ResultGrid.RecordCount = this.RecordCount < 0 ? 0 : this.RecordCount;

            if (ds == null || ds.Tables[0].DefaultView.Count <= 0)
            {
                this.ResultGrid.RecordCount = 0;
                this.ResultGrid.DataSource = null;
                this.ResultGrid.DataBind();
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            DataTool.AddCouponTypeCode(ds, "CouponTypeCode", "CouponTypeID");
            DataTool.AddCouponTypeName(ds, "CouponTypeName", "CouponTypeID");
            DataTool.AddCouponStatus(ds, "StatusName", "Status");
            DataTool.AddCouponStockStatus(ds, "StockStatusName", "StockStatus");
            DataTool.AddID(ds, "ID", this.ResultGrid.PageSize, this.ResultGrid.PageIndex);
            DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");
            DataTool.AddBatchCode(ds, "BatchCode", "BatchCouponID");
            DataTool.AddCouponAmount(ds, "NewCouponAmount", "CouponAmount", "CouponTypeID");
            DataTool.AddDateFormat(ds, "CreatedOnText", "CreatedOn");
            DataTool.AddDateFormat(ds, "CouponExpiryDateText", "CouponExpiryDate");
            this.ResultGrid.DataSource = ds.Tables[0].DefaultView;
            this.ResultGrid.DataBind();

           /// this.CloseLoading();
        }

        private string GetStrWhere()
        {
            string strWhere = "";
            if (this.Brand.SelectedValue!="-1")
            {
                if (this.StoreID.SelectedValue != "-1")
                {
                    strWhere += string.Format(" LocateStoreID = '{0}' and ", this.StoreID.SelectedValue.Trim());
                }
                else
                {
                    string storeids = SVASessionInfo.CurrentUser.SqlConditionAllStoresIDsByBrandID(this.Brand.SelectedValue);
                    if (!string.IsNullOrEmpty(storeids))
                    {
                        strWhere += string.Format(" LocateStoreID in {0} and ", storeids);
                    }
                }
            }
            //else
            //{
            //    strWhere += string.Format(" LocateStoreID in {0} and ", SVASessionInfo.CurrentUser.SqlConditionStoreIDs);
            //}
            if (!string.IsNullOrEmpty(this.CouponNumber.Text))
            {
                strWhere += string.Format(" CouponNumber = '{0}' and ", this.CouponNumber.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.CouponUID.Text))
            {
                strWhere += string.Format(" CouponNumber in (select CouponNumber from CouponUIDMap where CouponUID =  '{0}') and ", this.CouponUID.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.CouponTypeID.SelectedValue) && this.CouponTypeID.SelectedValue != "-1")
            {
                strWhere += string.Format(" CouponTypeID = {0} and ", this.CouponTypeID.SelectedValue);
            }
            if (this.CouponTypeID.SelectedValue == "-1")//if (string.IsNullOrEmpty(this.CouponTypeID.SelectedValue))
            {
                if (!string.IsNullOrEmpty(this.Products.SelectedValue) && !string.IsNullOrEmpty(this.Deparment.SelectedValue))
                {
                    strWhere += string.Format(" CouponTypeID in ({0},{1}) and ", this.Products.SelectedValue, this.Deparment.SelectedValue);
                }
                else if (!string.IsNullOrEmpty(this.Products.SelectedValue))
                {
                    strWhere += string.Format(" CouponTypeID in ({0}) and ", this.Products.SelectedValue);
                }
                else if (!string.IsNullOrEmpty(this.Deparment.SelectedValue))
                {
                    strWhere += string.Format(" CouponTypeID in ({0}) and ", this.Deparment.SelectedValue);
                }
            }
            if (!string.IsNullOrEmpty(this.BatchCouponID.SelectedValue.Trim()))
            {
                strWhere += string.Format(" BatchCouponID = {0} and ", this.BatchCouponID.SelectedValue.Trim());
            }
            if (!string.IsNullOrEmpty(this.CouponTypeAmount.Text))
            {
                //strWhere += string.Format(" CouponTypeID in (select CouponTypeID from CouponType where CouponTypeAmount =  '{0}') and ", this.CouponTypeAmount.Text.Replace(",", "").Trim());
                strWhere += string.Format("  CouponAmount = {0} and ", this.CouponTypeAmount.Text.Replace(",", "").Trim());
            }
            if (!string.IsNullOrEmpty(this.Status.SelectedValue.Trim()))
            {
                strWhere += string.Format(" Status = '{0}' and ", this.Status.SelectedValue.Trim());
            }
            if (!string.IsNullOrEmpty(this.StockStatus.SelectedValue.Trim()))
            {
                strWhere += string.Format(" StockStatus = '{0}' and ", this.StockStatus.SelectedValue.Trim());
            }
            if (!string.IsNullOrEmpty(this.CouponCreatedOn.Text))
            {
                strWhere += string.Format(" Convert(char(10),CreatedOn,120) = '{0}' and ", this.CouponCreatedOn.Text);
            }
            if (!string.IsNullOrEmpty(this.CouponExpiryDate.Text))
            {
                strWhere += string.Format(" Convert(char(10),CouponExpiryDate,120) = '{0}' and ", this.CouponExpiryDate.Text);
            }
            //Add By Robin 2014-09-19 for 7-11 Modified by Robin 2014-10-08
            if (!string.IsNullOrEmpty(this.MemberMobilePhone.Text) || !string.IsNullOrEmpty(this.MemberEmail.Text))
            {
                if (!string.IsNullOrEmpty(this.MemberMobilePhone.Text) && !string.IsNullOrEmpty(this.MemberEmail.Text))
                    strWhere += string.Format(" CardNumber in (select CardNumber from [Card] C inner join Member M on C.MemberID=M.MemberID where M.MemberMobilePhone='{0}' and M.MemberEmail='{1}') and ", this.MemberMobilePhone.Text.Trim(), this.MemberEmail.Text.Trim());
                if (!string.IsNullOrEmpty(this.MemberMobilePhone.Text) && string.IsNullOrEmpty(this.MemberEmail.Text))
                    strWhere += string.Format(" CardNumber in (select CardNumber from [Card] C inner join Member M on C.MemberID=M.MemberID where M.MemberMobilePhone='{0}') and ", this.MemberMobilePhone.Text.Trim());
                if (string.IsNullOrEmpty(this.MemberMobilePhone.Text) && !string.IsNullOrEmpty(this.MemberEmail.Text))
                    strWhere += string.Format(" CardNumber in (select CardNumber from [Card] C inner join Member M on C.MemberID=M.MemberID where M.MemberEmail='{0}') and ", this.MemberEmail.Text.Trim());
            }
            //End
            if (!string.IsNullOrEmpty(strWhere)) strWhere = strWhere.Substring(0, strWhere.Length - 4);

            return strWhere;
        }

        private bool hasInput()
        {
            if (this.Brand.SelectedValue!="-1")
            {
                return true;
            }
            //Add By Robin 2014-09-19
            if (!string.IsNullOrEmpty(this.MemberMobilePhone.Text.Trim())) return true;
            if (!string.IsNullOrEmpty(this.MemberEmail.Text.Trim())) return true; 
            //End
            if (!string.IsNullOrEmpty(this.CouponTypeID.SelectedValue) && this.CouponTypeID.SelectedValue != "-1") return true; 

            if (!string.IsNullOrEmpty(this.CouponNumber.Text.Trim())) return true;

            if (!string.IsNullOrEmpty(this.CouponUID.Text.Trim())) return true;

            if (!string.IsNullOrEmpty(this.CouponTypeAmount.Text)) return true;

            if (!string.IsNullOrEmpty(this.Status.SelectedValue)) return true;

            if (!string.IsNullOrEmpty(this.StockStatus.SelectedValue)) return true;

            if (!string.IsNullOrEmpty(this.Products.SelectedValue) && this.Products.SelectedValue != "-1") return true;

            if (!string.IsNullOrEmpty(this.Deparment.SelectedValue) && this.Deparment.SelectedValue != "-1") return true;

            if (!string.IsNullOrEmpty(this.CouponCreatedOn.Text)) return true;

            if (!string.IsNullOrEmpty(this.CouponExpiryDate.Text)) return true;

            if (!string.IsNullOrEmpty(this.BatchCouponID.SelectedValue)) return true;

            return false;            
        }
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
                ViewState["RecordCount"] = value;
            }
        }

        protected void ResultGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            this.ResultGrid.PageIndex = e.NewPageIndex;

            RptBind(GetStrWhere());
        }

        public void BindBatchID(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.BatchCoupon().GetBatchID();
            ddl.DataSource = ds.Tables[0];
            ddl.DataTextField = "BatchCouponCode";
            ddl.DataValueField = "BatchCouponID";
            ddl.DataBind();
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
            ddl.SelectedIndex = 0;
        }

        public void BindBatchID(FineUI.DropDownList ddl, int couponType)
        {
            ddl.Items.Clear();
            DataSet ds = new Edge.SVA.BLL.BatchCoupon().GetBatchIDByType(couponType);
            ddl.DataSource = ds.Tables[0];
            ddl.DataTextField = "BatchCouponCode";
            ddl.DataValueField = "BatchCouponID";
            ddl.DataBind();
            ddl.Items.Insert(0, new FineUI.ListItem() { Text = "----------", Value = "" });//Add by Nathan for All dropdownlist default value.
        }

        protected void Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitStoreByBrand();
        }

        private void InitStoreByBrand()
        {
            Edge.Web.Tools.ControlTool.BindAllStoreWithBrand(StoreID, Edge.Web.Tools.ConvertTool.ToInt(this.Brand.SelectedValue));
        }


        //private const string fields = "CouponNumber,CouponTypeID,BatchCouponID,Status,CouponAmount,CreatedOn,CouponExpiryDate";

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!this.IsPostBack)
        //    {
        //        this.rptListPager.PageSize = webset.ContentPageNum;

        //        ControlTool.BindCouponType(CouponTypeID);
        //        ControlTool.BindCouponStatus(Status);
        //        ControlTool.BindProduct(Products);
        //        ControlTool.BindDeparment(Deparment);

        //    }

        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    this.RecordCount = -1;
        //    this.rptListPager.CurrentPageIndex = 1;
        //    if (!this.hasInput())
        //    {
        //        this.CloseLoading();
        //        JscriptPrint(Resources.MessageTips.NoSearchCondition, "", Resources.MessageTips.WARNING_TITLE);
        //        RptBind(null);
        //        return;
        //    }

        //    string strWhere = GetStrWhere();

        //    Logger.Instance.WriteOperationLog(this.PageName, "Coupon Enquiry");

        //    RptBind(strWhere);


        //}

        //protected void rptListPager_PageChanged(object sender, EventArgs e)
        //{
        //    RptBind(GetStrWhere());

        //    this.AnimateRoll("msgtablelist");
        //}

        //protected void CouponTypeID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ControlTool.AddTitle(this.CouponTypeID);

        //    if (string.IsNullOrEmpty(this.CouponTypeID.SelectedValue))
        //    {
        //        ControlTool.BindProduct(Products);
        //        ControlTool.BindDeparment(Deparment);
        //        this.BatchCouponID.DataSource = Controllers.BatchController.GetInstance().GetBatch(10);
        //        return;
        //    }
        //    int couponTypeID = ConvertTool.ConverType<int>(this.CouponTypeID.SelectedValue);

        //    ControlTool.BindDeparment(Deparment, couponTypeID);
        //    ControlTool.BindProduct(Products, couponTypeID);

        //    this.BatchCouponID.DataSource = Controllers.BatchController.GetInstance().GetBatch(10, couponTypeID);
        //}

        //private void RptBind(string strWhere)
        //{
        //    if (string.IsNullOrEmpty(strWhere))
        //    {
        //        this.rptList.DataSource = null; ;
        //        this.rptList.DataBind();
        //        this.rptListPager.RecordCount = 0;
        //        this.CloseLoading();
        //        return;
        //    }
        //    int currentPage = this.rptListPager.CurrentPageIndex < 1 ? 0 : this.rptListPager.CurrentPageIndex - 1;

        //    Edge.SVA.BLL.Coupon coupon = new Edge.SVA.BLL.Coupon();
        //    DataSet ds = null;
        //    if (this.RecordCount < 0)
        //    {
        //        int count = 0;
        //        ds = coupon.GetListForTotal(this.rptListPager.PageSize, currentPage, strWhere, "CouponNumber", fields, 600);
        //        this.RecordCount = ds != null && ds.Tables.Count > 1 ? int.TryParse(ds.Tables[1].Rows[0]["Total"].ToString(), out count) ? count : 0 : 0;
        //    }
        //    else
        //    {
        //        ds = coupon.GetList(this.rptListPager.PageSize, currentPage, strWhere, "CouponNumber", fields, 600);
        //    }

        //    this.rptListPager.RecordCount = this.RecordCount < 0 ? 0 : this.RecordCount;

        //    if (ds == null || ds.Tables[0].DefaultView.Count <= 0)
        //    {
        //        JscriptPrintAndClose(Resources.MessageTips.NoData, "", Resources.MessageTips.WARNING_TITLE);
        //        this.rptList.DataSource = null;
        //        this.rptList.DataBind();
        //        this.rptListPager.RecordCount = 0;
        //        return;
        //    }

        //    DataTool.AddCouponTypeCode(ds, "CouponTypeCode", "CouponTypeID");
        //    DataTool.AddCouponTypeName(ds, "CouponTypeName", "CouponTypeID");
        //    DataTool.AddCouponStatus(ds, "StatusName", "Status");
        //    DataTool.AddID(ds, "ID", this.rptListPager.PageSize, currentPage);
        //    DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");
        //    DataTool.AddBatchCode(ds, "BatchCode", "BatchCouponID");
        //    DataTool.AddCouponAmount(ds, "NewCouponAmount", "CouponAmount", "CouponTypeID");
        //    this.rptList.DataSource = ds.Tables[0].DefaultView;
        //    this.rptList.DataBind();

        //    this.CloseLoading();
        //}

        //private string GetStrWhere()
        //{
        //    string strWhere = "";

        //    if (!string.IsNullOrEmpty(this.CouponNumber.Text))
        //    {
        //        strWhere += string.Format("CouponNumber = '{0}' and ", this.CouponNumber.Text.Trim());
        //    }
        //    if (!string.IsNullOrEmpty(this.CouponUID.Text))
        //    {
        //        strWhere += string.Format("CouponNumber in (select CouponNumber from CouponUIDMap where CouponUID =  '{0}') and ", this.CouponUID.Text.Trim());
        //    }
        //    if (!string.IsNullOrEmpty(this.CouponTypeID.SelectedValue))
        //    {
        //        strWhere += string.Format("CouponTypeID = {0} and ", this.CouponTypeID.SelectedValue);
        //    }
        //    if (string.IsNullOrEmpty(this.CouponTypeID.SelectedValue))
        //    {
        //        if (!string.IsNullOrEmpty(this.Products.SelectedValue) && !string.IsNullOrEmpty(this.Deparment.SelectedValue))
        //        {
        //            strWhere += string.Format("CouponTypeID in ({0},{1}) and ", this.Products.SelectedValue, this.Deparment.SelectedValue);
        //        }
        //        else if (!string.IsNullOrEmpty(this.Products.SelectedValue))
        //        {
        //            strWhere += string.Format("CouponTypeID in ({0}) and ", this.Products.SelectedValue);
        //        }
        //        else if (!string.IsNullOrEmpty(this.Deparment.SelectedValue))
        //        {
        //            strWhere += string.Format("CouponTypeID in ({0}) and ", this.Deparment.SelectedValue);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(this.BatchCouponID.Text))
        //    {
        //        strWhere += string.Format("BatchCouponID = {0} and ", this.BatchCouponID.Value);
        //    }

        //    if (!string.IsNullOrEmpty(this.CouponTypeAmount.Text))
        //    {
        //        strWhere += string.Format("CouponTypeID in (select CouponTypeID from CouponType where CouponTypeAmount =  '{0}') and ", this.CouponTypeAmount.Text.Replace(",", "").Trim());
        //    }
        //    if (!string.IsNullOrEmpty(this.Status.Text))
        //    {
        //        strWhere += string.Format("Status = '{0}' and ", this.Status.SelectedValue);
        //    }
        //    if (!string.IsNullOrEmpty(this.CouponCreatedOn.Text))
        //    {
        //        strWhere += string.Format("Convert(char(10),CreatedOn,120) = '{0}' and ", this.CouponCreatedOn.Text);
        //    }
        //    if (!string.IsNullOrEmpty(this.CouponExpiryDate.Text))
        //    {
        //        strWhere += string.Format("Convert(char(10),CouponExpiryDate,120) = '{0}' and ", this.CouponExpiryDate.Text);
        //    }
        //    if (!string.IsNullOrEmpty(strWhere)) strWhere = strWhere.Substring(0, strWhere.Length - 4);

        //    return strWhere;
        //}

        //private bool hasInput()
        //{
        //    if (!string.IsNullOrEmpty(this.CouponNumber.Text.Trim())) return true;

        //    if (!string.IsNullOrEmpty(this.CouponUID.Text.Trim())) return true;

        //    if (!string.IsNullOrEmpty(this.CouponTypeID.SelectedValue)) return true;

        //    if (!string.IsNullOrEmpty(this.BatchCouponID.Text)) return true;

        //    if (!string.IsNullOrEmpty(this.CouponTypeAmount.Text)) return true;

        //    if (!string.IsNullOrEmpty(this.Status.SelectedValue)) return true;

        //    if (!string.IsNullOrEmpty(this.Products.SelectedValue)) return true;

        //    if (!string.IsNullOrEmpty(this.Deparment.SelectedValue)) return true;

        //    if (!string.IsNullOrEmpty(this.CouponCreatedOn.Text)) return true;

        //    if (!string.IsNullOrEmpty(this.CouponExpiryDate.Text)) return true;

        //    return false;
        //}

        //private int RecordCount
        //{
        //    get
        //    {
        //        if (ViewState["RecordCount"] == null || string.IsNullOrEmpty(ViewState["RecordCount"].ToString())) return -1;
        //        int count = 0;
        //        return int.TryParse(ViewState["RecordCount"].ToString(), out count) ? count : -1;
        //    }
        //    set
        //    {
        //        ViewState["RecordCount"] = value;
        //    }
        //}
    }
}
