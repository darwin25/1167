using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using Edge.Web.Controllers.Operation.CouponManagement.CouponReturnManagement.CouponReturnOrder;
using System.Data;

namespace Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnOrder
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Ord_CouponReturn_H, Edge.SVA.Model.Ord_CouponReturn_H>
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

                ControlTool.BindBrand(BrandID);
                ControlTool.BindStore(StoreID);

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
                this.CouponReturnNumber.Text = Model.CouponReturnNumber;
                this.ApprovalCode.Text = Model.ApprovalCode;
                this.CreatedBusDate.Text = ConvertTool.ToStringDate(Model.CreatedBusDate.GetValueOrDefault());
                this.ApproveBusDate.Text = ConvertTool.ToStringDate(Model.ApproveBusDate.GetValueOrDefault());
                this.lblApproveStatus.Text = DALTool.GetApproveStatusString(Model.ApproveStatus);
                this.CreatedOn.Text = ConvertTool.ToStringDateTime(Model.CreatedOn.GetValueOrDefault());
                this.ApproveOn.Text = ConvertTool.ToStringDateTime(Model.ApproveOn.GetValueOrDefault());
                this.lblCreatedBy.Text = Tools.DALTool.GetUserName(Model.CreatedBy.GetValueOrDefault());
                this.lblApproveBy.Text = Tools.DALTool.GetUserName(Model.ApproveBy.GetValueOrDefault());
                this.lblRemark.Text = Model.Remark;

                this.BrandID.SelectedValue = Model.BrandID.ToString();
                this.lblBrandID.Text = BrandID.SelectedItem.Text;
                int brandID = 0;
                brandID = int.TryParse(this.BrandID.SelectedValue, out brandID) ? brandID : 0;
                ControlTool.BindStore(FromStoreID, brandID);
                this.FromStoreID.SelectedValue = Model.FromStoreID.ToString();
                this.lblFromStoreID.Text = FromStoreID.SelectedItem.Text;
                this.lblFromAddress.Text = Model.FromAddress;
                this.lblFromContactName.Text = Model.FromContactName;
                this.lblFromContactNumber.Text = Model.FromContactNumber;

                this.StoreID.SelectedValue = Model.StoreID.ToString();
                this.lblStoreID.Text = StoreID.SelectedItem.Text;
                this.lblSendAddress.Text = Model.SendAddress;
                this.lblStoreContactName.Text = Model.StoreContactName;
                this.lblStoreContactPhone.Text = Model.StoreContactPhone;
                this.SendMethod.SelectedValue = Model.SendMethod.ToString();
                lblSendMethod.Text = SendMethod.SelectedItem.Text;
                lblStoreContactEmail.Text = Model.StoreContactEmail;

                CouponReturnOrderController controller = new CouponReturnOrderController();
                DataSet ds = controller.GetDetailList(this.CouponReturnNumber.Text, FromStoreID.SelectedItem.Text);
                //Add By Robin 2014-11-25 for static card status
                int StockStatus=0;
                int Status = 1;
                if (this.Model.ApproveStatus == "A") { StockStatus = 7; }
                else { StockStatus = 6; }
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

        protected override SVA.Model.Ord_CouponReturn_H GetPageObject(SVA.Model.Ord_CouponReturn_H obj)
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
    }
}