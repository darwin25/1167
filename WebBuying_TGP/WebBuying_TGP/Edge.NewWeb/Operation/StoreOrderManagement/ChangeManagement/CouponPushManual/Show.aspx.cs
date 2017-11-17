using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponPush_H, Edge.SVA.Model.Ord_CouponPush_H>
    {
        public string id = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AddResultListGrid.PageSize = webset.ContentPageNum;
            this.id = Request.Params["id"];

            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

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
                CreatedBy.Text = Edge.Web.Tools.DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                CreatedOn.Text = Edge.Web.Tools.ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());

                ApproveBy.Text = Edge.Web.Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());
                ApproveOn.Text = Edge.Web.Tools.ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());

                this.ApproveStatus.Text = Edge.Web.Tools.DALTool.GetApproveStatusString(Model.ApproveStatus);

                this.lblPushCardBrandID.Text = Model.PushCardBrandID == null ? "" : Tools.DALTool.GetBrandCode(Convert.ToInt32(Model.PushCardBrandID), null) + "-" + Tools.DALTool.GetBrandName(Convert.ToInt32(Model.PushCardBrandID), null);
                this.lblPushCardTypeID.Text = Model.PushCardTypeID == null ? "" : Tools.DALTool.GetCardTypeCode(Convert.ToInt32(Model.PushCardTypeID), null) + "-" + Tools.DALTool.GetCardTypeName(Convert.ToInt32(Model.PushCardTypeID), null);
                this.lblPushCardGradeID.Text = Model.PushCardGradeID == null ? "" : Tools.DALTool.GetCardGradeCode(Convert.ToInt32(Model.PushCardGradeID), null) + "-" + Tools.DALTool.GetCardGradeName(Convert.ToInt32(Model.PushCardGradeID), null);

                this.lblRepeatPush.Text = this.RepeatPush.SelectedItem == null ? "" : this.RepeatPush.SelectedItem.Text;

                RptBind();
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
    }
}