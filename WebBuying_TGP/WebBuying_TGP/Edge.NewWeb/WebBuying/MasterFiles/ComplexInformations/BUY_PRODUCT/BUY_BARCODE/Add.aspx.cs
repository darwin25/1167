using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.BUY_BARCODE
{
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
                controller.ViewModel.dtBarCode.Rows.Add(1);
                int RowIndex = controller.ViewModel.dtBarCode.Rows.Count - 1;
                controller.ViewModel.dtBarCode.Rows[RowIndex]["ProdCode"] = this.ProdCode.Text;
                controller.ViewModel.dtBarCode.Rows[RowIndex]["Barcode"] = this.Barcode.Text;
                controller.ViewModel.dtBarCode.Rows[RowIndex]["InternalBarcode"] = this.InternalBarcode.SelectedValue;
            }
                //来自产品审核表
            else
            {

                productPendingController.ViewModel.dtBarCode.Rows.Add(1);
                int RowIndex = productPendingController.ViewModel.dtBarCode.Rows.Count - 1;
                productPendingController.ViewModel.dtBarCode.Rows[RowIndex]["ProdCode"] = this.ProdCode.Text;
                productPendingController.ViewModel.dtBarCode.Rows[RowIndex]["Barcode"] = this.Barcode.Text;
                productPendingController.ViewModel.dtBarCode.Rows[RowIndex]["InternalBarcode"] = this.InternalBarcode.SelectedValue;
            }
            //controller.ViewModel.dtBarCode.Rows[RowIndex]["ProdName"] = this.ProdCode.SelectedText;
            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.ProdCode.Text = Request.Params["ProdCode"].ToString();
        }
    }
}