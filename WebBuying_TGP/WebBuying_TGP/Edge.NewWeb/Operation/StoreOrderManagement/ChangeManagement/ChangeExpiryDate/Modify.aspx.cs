using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Controllers;
using Edge.Common;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.ChangeExpiryDate
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponAdjust_H, Edge.SVA.Model.Ord_CouponAdjust_H>
    {

        public string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = Request.Params["id"];
            this.Grid1.PageSize = webset.ContentPageNum;
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                Edge.Web.Tools.ControlTool.BindReasonType(ReasonID);
                Edge.Web.Tools.ControlTool.BindStoreWithStoreCode(StoreCode);
                Edge.Web.Tools.ControlTool.BindBrand(Brand);
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                lblCreatedBy.Text = Edge.Web.Tools.DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                CreatedOn.Text = Edge.Web.Tools.ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());

                lblApproveBy.Text = Edge.Web.Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());
                ApproveOn.Text = Edge.Web.Tools.ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());

                this.ApproveStatus.Text = Tools.DALTool.GetApproveStatusString(Model.ApproveStatus);

                //string strWhere = string.Format("CouponAdjustNumber = '{0}'", WebCommon.No_SqlHack(Model.CouponAdjustNumber));
                //RptBind(strWhere);

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
                    this.lblTotalDenomination.Text = bll.GetAllDenominationWithCoupon(strWhere).ToString("N02");
                }

                if (StoreCode.SelectedValue != "")
                {
                    try
                    {
                        Brand.SelectedValue = Tools.DALTool.GetBrandIDByBrandCode(Model.BrandCode, null).ToString().Trim();
                    }
                    catch
                    { }
                }

                this.Brand.Enabled = false;
                this.StoreCode.Enabled = false;
            }
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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Logger.Instance.WriteOperationLog(this.PageName, "Update");

            Edge.SVA.Model.Ord_CouponAdjust_H item = null;
            Edge.SVA.Model.Ord_CouponAdjust_H dataItem = this.GetDataObject();

            //Check model
            if (dataItem == null)
            {
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }
            //Check the transaction whether pending
            if (dataItem.ApproveStatus.ToUpper().Trim() != "P")
            {
                ShowWarningAndClose(Resources.MessageTips.TheTransactionStatusNotPending);
                return;
            }
            //Update model
            item = this.GetPageObject(dataItem);

            if (item != null)
            {
                item.UpdatedOn = System.DateTime.Now;
                item.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                item.BrandCode = Tools.DALTool.GetBrandCode(Tools.ConvertTool.ToInt(this.Brand.SelectedValue), null);//Add Brand Code
            }
            if (Edge.Web.Tools.DALTool.Update<Edge.SVA.BLL.Ord_CouponAdjust_H>(item))
            {
               // Logger.Instance.WriteOperationLog(this.PageName, "Update Coupon Change Expiry Date " + item.CouponAdjustNumber + " " + Resources.MessageTips.UpdateSuccess);

                CloseAndPostBack();
                //JscriptPrint(Resources.MessageTips.UpdateSuccess, "List.aspx", Resources.MessageTips.SUCESS_TITLE);
            }
            else
            {
               // Logger.Instance.WriteOperationLog(this.PageName, "Update Coupon Change Expiry Date " + item.CouponAdjustNumber + " " + Resources.MessageTips.UpdateFailed);

                ShowUpdateFailed();
                //JscriptPrint(Resources.MessageTips.UpdateFailed, "List.aspx", Resources.MessageTips.FAILED_TITLE);
            }
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
        //        Edge.Web.Tools.ControlTool.BindReasonType(ReasonID);
        //    }
        //}

        //protected override void OnLoadComplete(EventArgs e)
        //{
        //    base.OnLoadComplete(e);

        //    if (!this.IsPostBack)
        //    {
             
        //        //string strWhere = string.Format("CouponAdjustNumber = '{0}'", WebCommon.No_SqlHack(Model.CouponAdjustNumber));

        //        //this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
        //        //this.ApproveOn.Text = ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());

        //        //RptBind(strWhere);

        //        //string strWhere = string.Format("CouponAdjustNumber = '{0}'", WebCommon.No_SqlHack(Model.CouponAdjustNumber));

        //        //RptBind(strWhere);
        //        this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
        //        this.ApproveOn.Text = ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());
        //        this.lblCreatedBy.Text = DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
        //        this.lblApproveBy.Text = DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());

        //        this.lblApproveStatus.Text = DALTool.GetApproveStatusString(Model.ApproveStatus);

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
        //            this.lblTotalDenomination.Text = bll.GetAllDenominationWithCoupon(strWhere).ToString("N02");
        //        }
        //    }
        //}

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    Edge.SVA.Model.Ord_CouponAdjust_H item = this.GetUpdateObject();

        //    if (item != null)
        //    {
        //        item.UpdatedOn = System.DateTime.Now;
        //        item.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
        //    }
        //    if (Edge.Web.Tools.DALTool.Update<Edge.SVA.BLL.Ord_CouponAdjust_H>(item))
        //    {
        //        Logger.Instance.WriteOperationLog(this.PageName, "Update Coupon Change Expiry Date " + item.CouponAdjustNumber + " " + Resources.MessageTips.UpdateSuccess);


        //        JscriptPrint(Resources.MessageTips.UpdateSuccess, "List.aspx", Resources.MessageTips.SUCESS_TITLE);
        //    }
        //    else
        //    {
        //        Logger.Instance.WriteOperationLog(this.PageName, "Update Coupon Change Expiry Date " + item.CouponAdjustNumber + " " + Resources.MessageTips.UpdateFailed);


        //        JscriptPrint(Resources.MessageTips.UpdateFailed, "List.aspx", Resources.MessageTips.FAILED_TITLE);
        //    }
        //}


        ////private void RptBind(string strWhere)
        ////{
        ////    if (!int.TryParse(Request.Params["page"], out this.page))
        ////    {
        ////        this.page = 0;
        ////    }

        ////    Edge.SVA.BLL.Ord_CouponAdjust_D bll = new Edge.SVA.BLL.Ord_CouponAdjust_D();
           
        ////    this.pcount = bll.GetCountWithCoupon(strWhere);

        ////    DataSet ds = bll.GetPageListWithCoupon(this.pagesize, this.page, strWhere, "Ord_CouponAdjust_D.CouponNumber");

        ////    DataTool.AddCouponStatus(ds, "StatusName", "Status");
        ////    DataTool.AddCouponUID(ds, "CouponUID", "CouponNumber");

        ////    this.rptList.DataSource = ds.Tables[0].DefaultView;
        ////    this.rptList.DataBind();
        ////}

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
