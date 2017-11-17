using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT, Edge.SVA.Model.BUY_PRODUCT>
    {
        BuyingProductController controller = new BuyingProductController();
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
                SVASessionInfo.BuyingProductController = null;
                InitData();
            }
            controller = SVASessionInfo.BuyingProductController;
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
                controller.LoadViewModel(Model.ProdCode);
                if (controller.ViewModel.MainTable != null)
                {

                    this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());

                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    this.BrandCodeView.Text = this.BrandCode.SelectedText;
                    this.StoreCodeView.Text = this.StoreCode.SelectedText;
                    this.DepartCodeView.Text = this.DepartCode.SelectedText;
                    this.ColorCodeView.Text = this.ColorCode.SelectedText;
                    this.ProdClassCodeView.Text = this.ProdClassCode.SelectedText;
                    this.ProductSizeCodeView.Text = this.ProductSizeCode.SelectedText;
                    this.OrderTypeView.Text = this.OrderType.SelectedText;
                    this.WarehouseCodeView.Text = this.WarehouseCode.SelectedText;
                    this.ProductTypeView.Text = this.ProductType.SelectedText;

                    this.NonOrderView.Text = this.NonOrder.SelectedItem == null ? "" : this.NonOrder.SelectedItem.Text;
                    this.NonSaleView.Text = this.NonSale.SelectedItem == null ? "" : this.NonSale.SelectedItem.Text;
                    this.ConsignmentView.Text = this.Consignment.SelectedItem == null ? "" : this.Consignment.SelectedItem.Text;
                    this.WeightItemView.Text = this.WeightItem.SelectedItem == null ? "" : this.WeightItem.SelectedItem.Text;
                    this.DiscAllowView.Text = this.DiscAllow.SelectedItem == null ? "" : this.DiscAllow.SelectedItem.Text;
                    this.CouponAllowView.Text = this.CouponAllow.SelectedItem == null ? "" : this.CouponAllow.SelectedItem.Text;
                    this.VisuaItemView.Text = this.VisuaItem.SelectedItem == null ? "" : this.VisuaItem.SelectedItem.Text;
                    this.CouponSKUView.Text = this.CouponSKU.SelectedItem == null ? "" : this.CouponSKU.SelectedItem.Text;
                    this.isOnlineSKUView.Text = this.isOnlineSKU.SelectedItem == null ? "" : this.isOnlineSKU.SelectedItem.Text;
                    this.BOMView.Text = this.BOM.SelectedItem == null ? "" : this.BOM.SelectedItem.Text;
                    this.MutexFlagView.Text = this.MutexFlag.SelectedItem == null ? "" : this.MutexFlag.SelectedItem.Text;
                    this.OnAccountView.Text = this.OnAccount.SelectedItem == null ? "" : this.OnAccount.SelectedItem.Text;
                    this.ReplenFormulaCodeView.Text = this.ReplenFormulaCode.SelectedText;
                    this.FulfillmentHouseCodeView.Text = this.FulfillmentHouseCode.SelectedText;
                    this.WarehouseCodeView.Text = this.WarehouseCode.SelectedText;
                    this.DefaultPickupStoreCodeView.Text = this.DefaultPickupStoreCode.SelectedText;

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ProdPicFile;
                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(Model.ProdPicFile) ? true : false;//没有照片时不显示View按钮(Len)

                }
            }
        }

        protected void InitData()
        {
            controller.BindBrand(this.BrandCode);
            controller.BindStore(this.StoreCode);
            controller.BindDepart(this.DepartCode);
            controller.BindColor(this.ColorCode);
            controller.BindFulfillmentHouse(this.FulfillmentHouseCode);
            controller.BindProdClass(this.ProdClassCode);
            controller.BindProSize(this.ProductSizeCode);
            controller.BindReplenFormula(this.ReplenFormulaCode);
            controller.BindFulfillmentHouse(this.WarehouseCode);
            controller.BindFulfillmentHouse(this.DefaultPickupStoreCode);
        }
    }
}