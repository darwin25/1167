using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Common;
using Edge.Web.Tools;
using System.Data;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponActive
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponAdjust_H, Edge.SVA.Model.Ord_CouponAdjust_H>
    {
        public string id = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Grid1.PageSize = webset.ContentPageNum;
            this.id = Request.Params["id"];

            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                this.CouponStatus.Text = Tools.DALTool.GetCouponTypeStatusName((int)Controllers.CouponController.CouponStatus.Activated);
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!this.IsPostBack && Model != null)
            {
                if (!hasRight)
                {
                    return;
                }
                this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
                this.ApproveOn.Text = ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());
                this.CreatedBy.Text = DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                this.ApproveBy.Text = DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());

                this.ApproveStatus.Text = Edge.Web.Tools.DALTool.GetApproveStatusString(this.ApproveStatus.Text);

                SVA.Model.Brand brand = new SVA.BLL.Brand().GetModelByCode(Model.BrandCode);
                string brandText = brand == null ? "" : DALTool.GetStringByCulture(brand.BrandName1, brand.BrandName2, brand.BrandName3);
                this.Brand.Text = brand == null ? "" : ControlTool.GetDropdownListText(brandText, brand.BrandCode);

                if (brand != null)
                {
                    List<SVA.Model.Store> stores = new SVA.BLL.Store().GetModelList(string.Format("StoreCode = '{0}' and BrandID='{1}'", Edge.Common.WebCommon.No_SqlHack(Model.StoreCode), brand.BrandID));
                    string storeText = stores == null || stores.Count <= 0 ? null : DALTool.GetStringByCulture(stores[0].StoreName1, stores[0].StoreName2, stores[0].StoreName3);
                    this.StoreCode.Text = stores == null || stores.Count <= 0 ? "" : ControlTool.GetDropdownListText(storeText, stores[0].StoreCode);
                }


                SVA.Model.Reason reason = new SVA.BLL.Reason().GetModel(Model.ReasonID.GetValueOrDefault());
                this.ReasonID.Text = reason == null ? "" : DALTool.GetStringByCulture(reason.ReasonDesc1, reason.ReasonDesc2, reason.ReasonDesc3);
                this.ReasonID.Text = reason == null ? "" : ControlTool.GetDropdownListText(ReasonID.Text, reason.ReasonCode);

                if (Model.ApproveStatus != "A")
                {
                    this.ApproveOn.Text = null;
                    this.ApprovalCode.Text = null;
                }

                string strWhere = string.Format("Ord_CouponAdjust_D.CouponAdjustNumber = '{0}'", WebCommon.No_SqlHack(Model.CouponAdjustNumber));

                if (Model.ApproveStatus.ToUpper().Trim() == "A") strWhere = string.Format(" Coupon_Movement.RefTxnNo ='{0}' and Coupon_Movement.OprID = '{1}' ", WebCommon.No_SqlHack(Model.CouponAdjustNumber), WebCommon.No_SqlHack(Model.OprID.ToString()));

                ViewState["StrWhere"] = strWhere;
                ViewState["ApproveStatus"] = Model.ApproveStatus;

                RptBind();

                //汇总金额
                Edge.SVA.BLL.Ord_CouponAdjust_D bll = new SVA.BLL.Ord_CouponAdjust_D();
                if (Model.ApproveStatus.ToUpper().Trim() == "A")
                {
                    this.lblTotalDenomination.Text = bll.GetAllDenominationWithCoupon_Movement(strWhere).ToString("N02");
                }
                else
                {
                    this.lblTotalDenomination.Text = bll.GetAllDenominationWithOrd_CouponAdjust_D(strWhere).ToString("N02");
                }
            }
        }

        protected override void SetObject()
        {
            foreach (System.Web.UI.Control con in this.Panel1.Controls)
            {
                if (con is FineUI.GroupPanel)
                {
                    base.SetObject(Model, con.Controls.GetEnumerator());
                }
            }
        }

        private void RptBind()
        {
            if (ViewState["StrWhere"] != null && ViewState["ApproveStatus"] != null)
            {
                string strWhere = ViewState["StrWhere"].ToString();
                string status = ViewState["ApproveStatus"].ToString();

                Edge.SVA.BLL.Ord_CouponAdjust_D bll = new Edge.SVA.BLL.Ord_CouponAdjust_D();

                if (status.ToUpper().Trim() == "A")
                {
                    this.Grid1.RecordCount = bll.GetCountWithCoupon_Movement(strWhere);

                    DataSet ds = bll.GetPageListWithCoupon_Movement(this.Grid1.PageSize, this.Grid1.PageIndex, strWhere, "Coupon_Movement.CouponNumber");

                    DataTool.AddCouponStatus(ds, "StatusName", "Status");
                    DataTool.AddCouponStatus(ds, "OrgStatusName", "OrgStatus");
                    DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");
                    DataTool.AddCouponTypeName(ds, "CouponType", "CouponTypeID");
                    DataTool.AddBatchCode(ds, "BatchCode", "BatchCouponID");

                    this.Grid1.DataSource = ds.Tables[0].DefaultView;
                    this.Grid1.DataBind();
                }
                else
                {
                    this.Grid1.RecordCount = bll.GetCountWithCoupon(strWhere);

                    DataSet ds = bll.GetPageListWithCoupon(this.Grid1.PageSize, this.Grid1.PageIndex, strWhere, "Ord_CouponAdjust_D.CouponNumber");

                    DataTool.AddCouponStatus(ds, "StatusName", "Status");
                    DataTool.AddCouponStatus(ds, "OrgStatusName", "Status");
                    DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");
                    DataTool.AddCouponTypeName(ds, "CouponType", "CouponTypeID");
                    DataTool.AddBatchCode(ds, "BatchCode", "BatchCouponID");

                    this.Grid1.DataSource = ds.Tables[0].DefaultView;
                    this.Grid1.DataBind();

                }
            }
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            RptBind();
        }

        //public int pcount;                      //总条数
        //public int page;                        //当前页
        //public int pagesize;                    //设置每页显示的大小
        //public string id = null;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    this.pagesize = webset.ContentPageNum;
        //    this.id = Request.Params["id"];

        //    if (!this.IsPostBack)
        //    {
        //        this.CouponStatus.Text = Tools.DALTool.GetCouponTypeStatusName((int)Controllers.CouponController.CouponStatus.Activated);
        //    }
        //}

        //protected override void OnLoadComplete(EventArgs e)
        //{
        //    base.OnLoadComplete(e);

        //    if (!this.IsPostBack)
        //    {
        //        this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
        //        this.ApproveOn.Text = ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());
        //        this.CreatedBy.Text = DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
        //        this.ApproveBy.Text = DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());

        //        this.ApproveStatus.Text = Edge.Web.Tools.DALTool.GetApproveStatusString(this.ApproveStatus.Text);

        //        SVA.Model.Store store = new SVA.BLL.Store().GetModelByCode(Model.StoreCode);
        //        string storeText = store == null ? "" : DALTool.GetStringByCulture(store.StoreName1, store.StoreName2, store.StoreName3);
        //        this.StoreCode.Text = store == null ? "" : ControlTool.GetDropdownListText(storeText, store.StoreCode);

        //        SVA.Model.Brand brand = new SVA.BLL.Brand().GetModelByCode(Model.BrandCode);
        //        string brandText = brand == null ? "" : DALTool.GetStringByCulture(brand.BrandName1, brand.BrandName2, brand.BrandName3);
        //        this.Brand.Text = brand == null ? "" : ControlTool.GetDropdownListText(brandText, brand.BrandCode);

        //        SVA.Model.Reason reason = new SVA.BLL.Reason().GetModel(Model.ReasonID.GetValueOrDefault());
        //        this.ReasonID.Text = reason == null ? "" : DALTool.GetStringByCulture(reason.ReasonDesc1, reason.ReasonDesc2, reason.ReasonDesc3);
        //        this.ReasonID.Text = reason == null ? "" : ControlTool.GetDropdownListText(ReasonID.Text, reason.ReasonCode);

        //        if (Model.ApproveStatus != "A")
        //        {
        //            this.ApproveOn.Text = null;
        //            this.ApprovalCode.Text = null;
        //        }

        //        string strWhere = string.Format("Ord_CouponAdjust_D.CouponAdjustNumber = '{0}'", WebCommon.No_SqlHack(Model.CouponAdjustNumber));

        //        if (Model.ApproveStatus.ToUpper().Trim() == "A") strWhere = string.Format(" Coupon_Movement.RefTxnNo ='{0}' and Coupon_Movement.OprID = '{1}' ", WebCommon.No_SqlHack(Model.CouponAdjustNumber), WebCommon.No_SqlHack(Model.OprID.ToString()));

        //        RptBind(strWhere, Model.ApproveStatus);


        //        //汇总金额
        //        Edge.SVA.BLL.Ord_CouponAdjust_D bll = new SVA.BLL.Ord_CouponAdjust_D();
        //        this.dtTotal.Visible = true;
        //        if (Model.ApproveStatus.ToUpper().Trim() == "A")
        //        {
        //            this.lblTotalDenomination.Text = bll.GetAllDenominationWithCoupon_Movement(strWhere).ToString("N02");
        //        }
        //        else
        //        {
        //            this.lblTotalDenomination.Text = bll.GetAllDenominationWithOrd_CouponAdjust_D(strWhere).ToString("N02");
        //        }
        //    }
        //}

        //private void RptBind(string strWhere, string status)
        //{
        //    if (!int.TryParse(Request.Params["page"], out this.page))
        //    {
        //        this.page = 0;
        //    }

        //    Edge.SVA.BLL.Ord_CouponAdjust_D bll = new Edge.SVA.BLL.Ord_CouponAdjust_D();

        //    if (status.ToUpper().Trim() == "A")
        //    {
        //        this.pcount = bll.GetCountWithCoupon_Movement(strWhere);

        //        DataSet ds = bll.GetPageListWithCoupon_Movement(this.pagesize, this.page, strWhere, "Coupon_Movement.CouponNumber");

        //        DataTool.AddCouponStatus(ds, "StatusName", "Status");
        //        DataTool.AddCouponStatus(ds, "OrgStatusName", "OrgStatus");
        //        DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");
        //        DataTool.AddCouponTypeName(ds, "CouponType", "CouponTypeID");
        //        DataTool.AddBatchCode(ds, "BatchCode", "BatchCouponID");

        //        this.rptList.DataSource = ds.Tables[0].DefaultView;
        //        this.rptList.DataBind();
        //    }
        //    else
        //    {
        //        this.pcount = bll.GetCountWithCoupon(strWhere);

        //        DataSet ds = bll.GetPageListWithCoupon(this.pagesize, this.page, strWhere, "Ord_CouponAdjust_D.CouponNumber");

        //        DataTool.AddCouponStatus(ds, "StatusName", "Status");
        //        DataTool.AddCouponStatus(ds, "OrgStatusName", "Status");
        //        DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");
        //        DataTool.AddCouponTypeName(ds, "CouponType", "CouponTypeID");
        //        DataTool.AddBatchCode(ds, "BatchCode", "BatchCouponID");

        //        this.rptList.DataSource = ds.Tables[0].DefaultView;
        //        this.rptList.DataBind();

        //    }
        //}
    }
}
