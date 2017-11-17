using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using Edge.Web.Controllers.Operation.CouponManagement.BatchCreationOfCoupons.CouponDeliveryConfirmation;
using System.Data;

namespace Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnConfirmation
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponReceive_H, Edge.SVA.Model.Ord_CouponReceive_H>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                this.Grid2.PageSize = webset.ContentPageNum;

                ControlTool.BindStore(SupplierID,"2");
                ControlTool.BindStore(StoreID);

                //ControlTool.BindCouponType(CouponType, -1);

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
                this.CouponReceiveNumber.Text = Model.CouponReceiveNumber;
                this.lblReferenceNo.Text = Model.ReferenceNo;
                this.CreatedBusDate.Text = ConvertTool.ToStringDate(Model.CreatedBusDate.GetValueOrDefault());
                this.lblApproveStatus.Text = DALTool.GetApproveStatusString(Model.ApproveStatus);
                this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
                this.lblCreatedBy.Text = Tools.DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                this.lblApproveBy.Text = Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());

                this.SupplierID.SelectedValue = Model.SupplierID.ToString();
                this.SupplierAddress.Text = Model.SupplierAddress;
                this.SuppliertContactName.Text = Model.SuppliertContactName;
                this.SupplierPhone.Text = Model.SupplierPhone;

                this.StoreID.SelectedValue = Model.StoreID.ToString();
                this.StorerAddress.Text = Model.StorerAddress;
                this.StoreContactName.Text = Model.StoreContactName;
                this.StorePhone.Text = Model.StorePhone;
                this.StoreEmail.Text = Model.StoreEmail;

                CouponDeliveryConfirmationController controller = new CouponDeliveryConfirmationController();
                DataSet ds = controller.GetDetailList(this.CouponReceiveNumber.Text, this.SupplierID.SelectedItem.Text);
                Tools.DataTool.AddID(ds, "ID", 0, 0);
                ViewState["DetailResult2"] = ds.Tables[0];
                this.BindDetail2();
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Edge.SVA.Model.Ord_CouponReceive_H item = null;
            Edge.SVA.Model.Ord_CouponReceive_H dataItem = this.GetDataObject();

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

            item = this.GetPageObject(dataItem);

            item.ReceiveType = 2;
            item.UpdatedBy = DALTool.GetCurrentUser().UserID;
            item.UpdatedOn = System.DateTime.Now;

            if (Tools.DALTool.Update<Edge.SVA.BLL.Ord_CouponReceive_H>(item))
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Coupon Delivery Confirmation {0} Update Success", item.CouponReceiveNumber));
                CloseAndRefresh();
            }
            else
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("Coupon Delivery Confirmation {0} Update Failed", item.CouponReceiveNumber));
                ShowAddFailed();
            }
        }

        protected void StoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.Store model = new Edge.SVA.BLL.Store().GetModel(Tools.ConvertTool.ConverType<int>(StoreID.SelectedValue.ToString()));
            if (model != null)
            {
                StorerAddress.Text = model.StoreAddressDetail;
                StoreContactName.Text = model.Contact;
                StorePhone.Text = model.StoreTel;
            }
            else
            {
                StorerAddress.Text = "";
                StoreContactName.Text = "";
                StorePhone.Text = "";
            }

        }

        protected void SupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edge.SVA.Model.Store model = new Edge.SVA.BLL.Store().GetModel(Tools.ConvertTool.ConverType<int>(this.SupplierID.SelectedValue.ToString()));
            if (model != null)
            {
                SupplierAddress.Text = model.StoreAddressDetail;
                SuppliertContactName.Text = model.Contact;
                SupplierPhone.Text = model.StoreTel;
            }
            else
            {
                SupplierAddress.Text = "";
                SuppliertContactName.Text = "";
                SupplierPhone.Text = "";
            }
        }

        protected override SVA.Model.Ord_CouponReceive_H GetPageObject(SVA.Model.Ord_CouponReceive_H obj)
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

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;
            this.BindDetail2();
        }

        private System.Data.DataTable Detail2
        {
            get
            {
                return ViewState["DetailResult2"] as System.Data.DataTable;
            }
        }

        private void BindDetail2()
        {
            this.Grid2.RecordCount = this.Detail2.Rows.Count;
            this.Grid2.DataSource = DataTool.GetPaggingTable(this.Grid2.PageIndex, this.Grid2.PageSize, this.Detail2);
            this.Grid2.DataBind();
        }
    }
}