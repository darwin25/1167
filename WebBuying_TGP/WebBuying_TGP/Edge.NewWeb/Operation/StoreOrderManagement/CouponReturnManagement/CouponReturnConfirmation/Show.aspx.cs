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
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponReceive_H, Edge.SVA.Model.Ord_CouponReceive_H>
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

                ControlTool.BindStore(SupplierID, "2");
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
                this.lblRemark.Text = Model.Remark;

                this.SupplierID.SelectedValue = Model.SupplierID.ToString();
                this.lblSupplierID.Text = SupplierID.SelectedItem.Text;
                this.lblSupplierAddress.Text = Model.SupplierAddress;
                this.lblSuppliertContactName.Text = Model.SuppliertContactName;
                this.lblSupplierPhone.Text = Model.SupplierPhone;

                this.StoreID.SelectedValue = Model.StoreID.ToString();
                this.lblStoreID.Text = StoreID.SelectedItem.Text;
                this.lblStorerAddress.Text = Model.StorerAddress;
                this.lblStoreContactName.Text = Model.StoreContactName;
                this.lblStorePhone.Text = Model.StorePhone;
                this.lblStoreEmail.Text = Model.StoreEmail;

                CouponDeliveryConfirmationController controller = new CouponDeliveryConfirmationController();
                DataSet ds = controller.GetDetailList(this.CouponReceiveNumber.Text, this.SupplierID.SelectedItem.Text);
                //Add By Robin 2014-11-25 for static card status
                int StockStatus=0;
                int Status = 1;
                if (this.Model.ApproveStatus == "A") { 
                    StockStatus = 2;
                    Status = 0;
                }
                else { StockStatus = 7; }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row["StatusName"] = Tools.DALTool.GetCouponTypeStatusName(Status);
                    row["StockStatusName"] = Tools.DALTool.GetCouponStockStatusName(StockStatus);
                }
                //End
                Tools.DataTool.AddID(ds, "ID", 0, 0);
                ViewState["DetailResult2"] = ds.Tables[0];
                this.BindDetail2();
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