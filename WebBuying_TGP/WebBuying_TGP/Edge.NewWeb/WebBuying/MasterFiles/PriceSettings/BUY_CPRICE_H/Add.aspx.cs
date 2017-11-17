using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_CPRICE_H, Edge.SVA.Model.BUY_CPRICE_H>
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

                InitData();
            }
            controller = SVASessionInfo.BuyingCPriceController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.CreatedBusDate = DateTime.Now;
                controller.ViewModel.MainTable.ApproveStatus = "P";
                controller.ViewModel.MainTable.CreatedOn = DateTime.Now;
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;

                controller.ViewModel.MainTable.StoreCode = this.StoreCode.SelectedValue == "-1" ? null : this.StoreCode.SelectedValue;
                controller.ViewModel.MainTable.StoreGroupCode = this.StoreGroupCode.SelectedValue == "-1" ? null : this.StoreGroupCode.SelectedValue;
                controller.ViewModel.MainTable.CurrencyCode = this.CurrencyCode.SelectedValue == "-1" ? null : this.CurrencyCode.SelectedValue;
            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add CPrice Success Code:" + controller.ViewModel.MainTable.CPriceCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add CPrice Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.CPriceCode);
                ShowSaveFailed(er.Message);
            }

        }

        protected void InitData()
        {
            this.CPriceCode.Text = DALTool.GetREFNOCode("CPC");
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
            controller.BindCurrency(CurrencyCode);
            controller.BindVendor(VendorCode);
        }

        protected void StoreCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreCode.SelectedValue != "-1")
            {
                this.StoreGroupCode.Enabled = false;
            }
            else
            {
                this.StoreGroupCode.Enabled = true;
            }
        }

        protected void StoreGroupCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreGroupCode.SelectedValue != "-1")
            {
                this.StoreCode.Enabled = false;
            }
            else
            {
                this.StoreCode.Enabled = true;
            }
        }
    }
}