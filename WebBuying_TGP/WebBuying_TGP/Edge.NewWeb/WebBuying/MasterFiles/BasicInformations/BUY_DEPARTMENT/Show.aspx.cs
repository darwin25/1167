using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_DEPARTMENT, Edge.SVA.Model.BUY_DEPARTMENT>
    {
        BuyingDepartmentController controller = new BuyingDepartmentController();
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingDepartmentController = null;
                InitData();
            }
            controller = SVASessionInfo.BuyingDepartmentController;
            logger.WriteOperationLog(this.PageName, "Show");

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.DepartCode);
                if (controller.ViewModel.MainTable != null)
                {

                    this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());
                    this.StoreBrandName.Text = DALTool.GetBrandName(controller.ViewModel.MainTable.StoreBrandCode, null);
                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    this.NonOrderView.Text = this.NonOrder.SelectedItem == null ? "" : this.NonOrder.SelectedItem.Text;
                    this.NonSaleView.Text = this.NonSale.SelectedItem == null ? "" : this.NonSale.SelectedItem.Text;
                    this.ConsignmentView.Text = this.Consignment.SelectedItem == null ? "" : this.Consignment.SelectedItem.Text;
                    this.WeightItemView.Text = this.WeightItem.SelectedItem == null ? "" : this.WeightItem.SelectedItem.Text;
                    this.DiscAllowView.Text = this.DiscAllow.SelectedItem == null ? "" : this.DiscAllow.SelectedItem.Text;
                    this.CouponAllowView.Text = this.CouponAllow.SelectedItem == null ? "" : this.CouponAllow.SelectedItem.Text;
                    this.VisuaItemView.Text = this.VisuaItem.SelectedItem == null ? "" : this.VisuaItem.SelectedItem.Text;
                    this.CouponSKUView.Text = this.CouponSKU.SelectedItem == null ? "" : this.CouponSKU.SelectedItem.Text;
                    this.BOMView.Text = this.BOM.SelectedItem == null ? "" : this.BOM.SelectedItem.Text;
                    this.MutexFlagView.Text = this.MutexFlag.SelectedItem == null ? "" : this.MutexFlag.SelectedItem.Text;
                    this.OnAccountView.Text = this.OnAccount.SelectedItem == null ? "" : this.OnAccount.SelectedItem.Text;
                    this.ReplenFormulaCodeView.Text = this.ReplenFormulaCode.SelectedText;
                    this.FulfillmentHouseCodeView.Text = this.FulfillmentHouseCode.SelectedText;
                    this.WarehouseCodeView.Text = this.WarehouseCode.SelectedText;
                    this.DefaultPickupStoreCodeView.Text = this.DefaultPickupStoreCode.SelectedText;

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.DepartPicFile;
                    this.uploadFilePath1.Text = controller.ViewModel.MainTable.DepartPicFile2;
                    this.uploadFilePath2.Text = controller.ViewModel.MainTable.DepartPicFile3;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.DepartPicFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview1.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.DepartPicFile2) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview2.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.DepartPicFile3) ? true : false;//没有照片时不显示View按钮(Len)

                }
            }
        }

        protected void InitData()
        {
            controller.BindReplenFormula(this.ReplenFormulaCode);
            controller.BindFulfillmentHouse(this.FulfillmentHouseCode);
            controller.BindFulfillmentHouse(this.WarehouseCode);
            controller.BindFulfillmentHouse(this.DefaultPickupStoreCode);
        }
    }
}