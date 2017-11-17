using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using System.Data;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponQuery
{
    public partial class Show : PageBase
    {

        private const string fields = "ServerCode,StoreID,RegisterCode,OprID,RefTxnNo,BusDate,Txndate,ApprovalCode,CouponTypeID,OpenBal,Amount,CloseBal";

        public int couponTypetID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                this.ResultGrid.PageSize = webset.ContentPageNum;

                SetObject();

                string strWhere = string.Format("CouponNumber = '{0}'", Request.Params["id"]);
                //RptBind(strWhere, "KeyID", fields); //Modified By Robin 2014-11-04 for RRG
                RptBind(strWhere, "CreatedOn", fields);

                lbViewProduct.OnClientClick = Window1.GetShowReference("ShowProduct.aspx?Url=&CouponTypeID=" + couponTypetID);
                lbViewDeparment.OnClientClick = Window1.GetShowReference("ShowDeparment.aspx?Url=&CouponTypeID=" + couponTypetID);
            }
        }

        private void SetObject()
        {
            this.couponTypetID = Edge.Utils.Tools.ConvertTool.GetInstance().ConverToType<int>(Request.Params["couponTypeID"]);
            //Add By Robin 2014-09-19 for 7-11
            DataSet ds=DALTool.GetMemberByCoupon(Request.Params["id"]);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.NickName.Text = Convert.ToString(ds.Tables[0].Rows[0]["NickName"]);
                this.MemberMobilePhone.Text = Convert.ToString(ds.Tables[0].Rows[0]["MemberMobilePhone"]);
                this.MemberEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["MemberEmail"]);
            }
            //
            this.CouponNumber.Text = Request.Params["id"];
            this.CouponUID.Text = Request.Params["couponUID"];
            this.BatchCouponID.Text = Request.Params["batchCode"];
            this.CouponTypeID.Text = ControlTool.GetDropdownListText(Request.Params["CouponTypeName"], Request.Params["CouponTypeCode"]);
            this.CouponTypeAmount.Text = Request.Params["amount"];
            this.Status.Text = Request.Params["status"];
            this.StockStatus.Text = Request.Params["stockstatus"];
            this.CouponIssueDate.Text = Request.Params["CouponIssueDate"];
            this.CouponExpiryDate.Text = Request.Params["CouponExpiryDate"];

        }

        #region 数据列表绑定
        private void RptBind(string strWhere, string orderby, string fields)
        {
            int currentPage = this.ResultGrid.PageIndex  <= 0 ? 0 : this.ResultGrid.PageIndex ;

            Edge.SVA.BLL.Coupon_Movement bll = new Edge.SVA.BLL.Coupon_Movement();

            //获得总条数
            this.ResultGrid.RecordCount = bll.GetCount(strWhere);

            DataSet ds = bll.GetList(this.ResultGrid.PageSize, currentPage, strWhere, orderby, fields);

            Tools.DataTool.AddID(ds, "IDNumber", this.ResultGrid.PageSize, currentPage);
            Tools.DataTool.AddTxnTypeName(ds, "OprIDName", "OprID");
            DataTool.AddBrandCodeByCouponTypeID(ds, "BrandCode", "CouponTypeID");
            DataTool.AddBrandNameByCouponTypeID(ds, "BrandName", "CouponTypeID");
            Tools.DataTool.AddStoreCode(ds, "StoreCode", "StoreID");
            Tools.DataTool.AddStoreName(ds, "StoreName", "StoreID");

            this.ResultGrid.DataSource = ds.Tables[0].DefaultView;
            this.ResultGrid.DataBind();
        }
        #endregion

        public int PageCount
        {
            get
            {
                if (ViewState["PageCount"] is int) return (int)ViewState["PageCount"];

                return 1;
            }
            set
            {
                ViewState["PageCount"] = value;
            }
        }

        protected void ResultGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            this.ResultGrid.PageIndex = e.NewPageIndex;
            string strWhere = string.Format("CouponNumber = '{0}'", Request.Params["id"]);
            //RptBind(strWhere, "KeyID", fields);  //Modified By Robin 2014-11-04 for RRG
            RptBind(strWhere, "CreatedOn", fields);
        }

        //private const string fields = "ServerCode,StoreID,RegisterCode,OprID,RefTxnNo,BusDate,Txndate,ApprovalCode,CouponTypeID,OpenBal,Amount,CloseBal";
      
        //public int couponTypetID;

        //protected void Page_Load(object sender, EventArgs e)
        //{            
        //    if (!this.IsPostBack)
        //    {
        //        this.TXNListPager.PageSize = webset.ContentPageNum;

        //        SetObject();

        //        string strWhere = string.Format("CouponNumber = '{0}'",Request.Params["id"]);
        //        RptBind(strWhere, "KeyID", fields);
        //    }
        //}

        //protected void TXNListPager_PageChanged(object sender, EventArgs e)
        //{
        //    string strWhere = string.Format("CouponNumber = '{0}'", Request.Params["id"]);
        //    RptBind(strWhere, "KeyID", fields);
        //    this.AnimateRoll("msgtablelist");
        //    this.PageCount++;

        //}

        //private void SetObject()
        //{
        //    this.couponTypetID = Edge.Utils.Tools.ConvertTool.GetInstance().ConverToType<int>(Request.Params["couponTypeID"]);

        //    this.CouponNumber.Text = Request.Params["id"];
        //    this.CouponUID.Text = Request.Params["couponUID"];
        //    this.BatchCouponID.Text = Request.Params["batchCode"];
        //    this.CouponTypeID.Text = ControlTool.GetDropdownListText(Request.Params["CouponTypeName"], Request.Params["CouponTypeCode"]);
        //    this.CouponTypeAmount.Text = Request.Params["amount"];
        //    this.Status.Text = Request.Params["status"];
        //    this.CouponIssueDate.Text = Request.Params["CouponIssueDate"];
        //    this.CouponExpiryDate.Text = Request.Params["CouponExpiryDate"];
           
        //}

        //#region 数据列表绑定
        //private void RptBind(string strWhere, string orderby, string fields)
        //{
        //    int currentPage = this.TXNListPager.CurrentPageIndex - 1 < 0 ? 0 : this.TXNListPager.CurrentPageIndex - 1;

        //    Edge.SVA.BLL.Coupon_Movement bll = new Edge.SVA.BLL.Coupon_Movement();

        //    //获得总条数
        //    this.TXNListPager.RecordCount = bll.GetCount(strWhere);

        //    DataSet ds = bll.GetList(this.TXNListPager.PageSize, currentPage, strWhere, orderby, fields);

        //    Tools.DataTool.AddID(ds, "IDNumber", this.TXNListPager.PageSize, currentPage);
        //    Tools.DataTool.AddTxnTypeName(ds, "OprIDName", "OprID");
        //    DataTool.AddBrandCodeByCouponTypeID(ds, "BrandCode", "CouponTypeID");
        //    Tools.DataTool.AddStoreCode(ds, "StoreCode", "StoreID");

        //    this.TXNList.DataSource = ds.Tables[0].DefaultView;
        //    this.TXNList.DataBind();
        //}
        //#endregion

        //public int PageCount
        //{
        //    get
        //    {
        //        if (ViewState["PageCount"] is int) return (int)ViewState["PageCount"];

        //        return 1;
        //    }
        //    set
        //    {
        //        ViewState["PageCount"] = value;
        //    }
        //}

    }
}
