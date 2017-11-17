using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain;
using Edge.SVA.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Edge.Web.Controllers.Operation.CouponManagement.ChangeManagement.CouponPushManual;
using Edge.Web.Controllers;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponPush_H, Edge.SVA.Model.Ord_CouponPush_H>
    {
        public string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = Request.Params["id"];
            this.AddResultListGrid.PageSize = webset.ContentPageNum;
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                Edge.Web.Tools.ControlTool.BindBrand(this.PushCardBrandID);

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
                this.lblCreatedBy.Text = DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                this.lblApproveBy.Text = DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());

                this.ApproveStatus.Text = DALTool.GetApproveStatusString(Model.ApproveStatus);

                if (Model.ApproveStatus != "A")
                {
                    this.ApproveOn.Text = null;
                    this.ApprovalCode.Text = null;
                }

                ViewState["ApproveStatus"] = Model.ApproveStatus;

                this.PushCardBrandID.SelectedValue = Model.PushCardBrandID.ToString();
                InitCardTypeByBrand();
                this.PushCardTypeID.SelectedValue = Model.PushCardTypeID.ToString();
                InitCardGradeByCardType();
                this.PushCardGradeID.SelectedValue = Model.PushCardGradeID.ToString();

                RptBind();
            }
        }

        protected override SVA.Model.Ord_CouponPush_H GetPageObject(SVA.Model.Ord_CouponPush_H obj)
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
            Edge.SVA.BLL.Ord_CouponPush_D bll = new SVA.BLL.Ord_CouponPush_D();
            DataSet ds = bll.GetListByPage(" CouponPushNumber = '" + id + "'", "CouponPushNumber", this.AddResultListGrid.PageSize * this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize * (this.AddResultListGrid.PageIndex + 1));
            this.AddResultListGrid.RecordCount = bll.GetRecordCount(" CouponPushNumber = '" + id + "'");
            Tools.DataTool.AddBrandCode(ds, "BrandCode", "CouponBrandID");
            Tools.DataTool.AddBrandName(ds, "BrandName", "CouponBrandID");
            Tools.DataTool.AddCouponTypeCode(ds, "CouponTypeCode", "CouponTypeID");
            Tools.DataTool.AddCouponTypeName(ds, "CouponTypeName", "CouponTypeID");
            this.AddResultListGrid.DataSource = ds.Tables[0].DefaultView;
            this.AddResultListGrid.DataBind();
        }

        protected void AddResultListGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;
            RptBind();
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Logger.Instance.WriteOperationLog(this.PageName, "Update");

            Edge.SVA.Model.Ord_CouponPush_H item = null;
            Edge.SVA.Model.Ord_CouponPush_H dataItem = this.GetDataObject();

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
                item.PushCardBrandID = Tools.ConvertTool.ToInt(this.PushCardBrandID.SelectedValue);//Add Brand Code
                item.PushCardTypeID = Tools.ConvertTool.ToInt(this.PushCardTypeID.SelectedValue);
                item.PushCardGradeID = Tools.ConvertTool.ToInt(this.PushCardGradeID.SelectedValue);
            }
            if (Edge.Web.Tools.DALTool.Update<Edge.SVA.BLL.Ord_CouponPush_H>(item))
            {
                CloseAndPostBack();
            }
            else
            {
                ShowUpdateFailed();
            }
        }

        #region 卡信息控制
        protected void PushCardBrandID_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCardTypeByBrand();
        }
        protected void PushCardTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitCardGradeByCardType();
        }
        private void InitCardTypeByBrand()
        {
            if (this.PushCardBrandID.SelectedValue != "-1")
            {
                DataSet ds = new Edge.SVA.BLL.CardType().GetList("BrandID = " + Convert.ToInt32(this.PushCardBrandID.SelectedValue) + " order by CardTypeCode");
                Edge.Web.Tools.ControlTool.BindDataSet(this.PushCardTypeID, ds, "CardTypeID", "CardTypeName1", "CardTypeName2", "CardTypeName3", "CardTypeCode");
            }
            else
            {
                this.PushCardTypeID.Items.Clear();
            }
        }
        private void InitCardGradeByCardType()
        {
            if (this.PushCardBrandID.SelectedValue != "-1")
            {
                Tools.ControlTool.BindCardGrade(this.PushCardGradeID, Convert.ToInt32(this.PushCardTypeID.SelectedValue));
            }
            else
            {
                this.PushCardGradeID.Items.Clear();
            }
        }
        #endregion

    }
}