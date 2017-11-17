using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_CPRICE_H, Edge.SVA.Model.BUY_CPRICE_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingCPriceController controller = new BuyingCPriceController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingCPriceController = null;
            }
            controller = SVASessionInfo.BuyingCPriceController;
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
                controller.LoadViewModel(Model.CPriceCode);

                if (controller.ViewModel.MainTable != null)
                {
                    this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());

                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    ApproveBy.Text = Edge.Web.Tools.DALTool.GetUserName(controller.ViewModel.MainTable.ApproveBy.GetValueOrDefault());
                    ApproveOn.Text = Edge.Web.Tools.ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.ApproveOn.GetValueOrDefault());
                    this.ApproveStatus.Text = Edge.Web.Tools.DALTool.GetApproveStatusString(controller.ViewModel.MainTable.ApproveStatus);
                }

                this.StoreCodeView.Text = DALTool.GetBuyingStoreName(controller.ViewModel.MainTable.StoreCode, null);
                this.StoreGroupCodeView.Text = DALTool.GetBuyingStoreGroupName(controller.ViewModel.MainTable.StoreCode, null);
                this.CurrencyCodeView.Text = DALTool.GetBuyingCurrencyName(controller.ViewModel.MainTable.StoreCode, null);
                this.VendorCodeView.Text = DALTool.GetBuyingVendorName(controller.ViewModel.MainTable.VendorCode, null);


                if (controller.ViewModel.SubTable != null)
                {
                    BindResultList(controller.ViewModel.SubTable);
                }
            }
        }

        private void BindResultList(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize);
                this.AddResultListGrid.DataSource = viewDT;
                this.AddResultListGrid.DataBind();

            }
            else
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.PageIndex = 0;
                this.AddResultListGrid.RecordCount = 0;
                this.AddResultListGrid.DataSource = null;
                this.AddResultListGrid.DataBind();
            }
        }

        protected void AddResultListGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;

            BindResultList(controller.ViewModel.SubTable);
        }
    }
}