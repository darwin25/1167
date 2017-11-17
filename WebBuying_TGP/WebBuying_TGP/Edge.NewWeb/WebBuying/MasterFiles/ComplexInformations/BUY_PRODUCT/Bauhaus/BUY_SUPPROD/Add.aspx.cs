using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.BUY_SUPPROD
{
    /// <summary>
    /// 创建者：Lisa
    /// 创建时间：2016-02-27
    /// </summary>
    public partial class Add : PageBase
    {
        BuyingProductController controller = new BuyingProductController();
        BuyingProductPendingController productPendingController = new BuyingProductPendingController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(this.btnClose);
                string types = Request.Params["types"];
                if (!string.IsNullOrEmpty(types))
                {
                    hidTypes.Text = types;
                }
                InitData();

            }
            controller = SVASessionInfo.BuyingProductController;
            productPendingController = SVASessionInfo.BuyingProductPendingController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
             //来自产品表
            if (Request.Form["hidTypes"] != "productPending")
            {
                controller.ViewModel.dtSUPPROD.Rows.Add(1);
                int RowIndex = controller.ViewModel.dtSUPPROD.Rows.Count - 1;
                controller.ViewModel.dtSUPPROD.Rows[RowIndex]["VendorCode"] = this.SUPPLIER.SelectedValue;
                controller.ViewModel.dtSUPPROD.Rows[RowIndex]["ProdCode"] = this.ProdCode.Text;
                controller.ViewModel.dtSUPPROD.Rows[RowIndex]["SUPPLIER_PRODUCT_CODE"] = this.SUPPLIER_PRODUCT_CODE.Text;
                controller.ViewModel.dtSUPPROD.Rows[RowIndex]["in_tax"] = this.in_tax.Text;
                controller.ViewModel.dtSUPPROD.Rows[RowIndex]["Prefer"] = this.Prefer.SelectedValue;
                controller.ViewModel.dtSUPPROD.Rows[RowIndex]["IsDefault"] = this.IsDefault.SelectedValue;
            }
            //来自产品审核表
            else
            {
                productPendingController.ViewModel.dtSUPPROD.Rows.Add(1);
                int RowIndex = productPendingController.ViewModel.dtSUPPROD.Rows.Count - 1;
                productPendingController.ViewModel.dtSUPPROD.Rows[RowIndex]["VendorCode"] = this.SUPPLIER.SelectedValue;
                productPendingController.ViewModel.dtSUPPROD.Rows[RowIndex]["ProdCode"] = this.ProdCode.Text;
                productPendingController.ViewModel.dtSUPPROD.Rows[RowIndex]["SUPPLIER_PRODUCT_CODE"] = this.SUPPLIER_PRODUCT_CODE.Text;
                productPendingController.ViewModel.dtSUPPROD.Rows[RowIndex]["in_tax"] = this.in_tax.Text;
                productPendingController.ViewModel.dtSUPPROD.Rows[RowIndex]["Prefer"] = this.Prefer.SelectedValue;
                productPendingController.ViewModel.dtSUPPROD.Rows[RowIndex]["IsDefault"] = this.IsDefault.SelectedValue;
            }
            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.ProdCode.Text = Request.Params["ProdCode"].ToString();
            //绑定季节
            ControlTool.BindAllSupplier(this.SUPPLIER);
        }
    }
}