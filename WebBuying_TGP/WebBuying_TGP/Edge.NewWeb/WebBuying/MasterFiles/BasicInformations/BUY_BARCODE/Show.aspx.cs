using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BARCODE, Edge.SVA.Model.BUY_BARCODE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBarCodeController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingBarCodeController = null;
            }
            controller = SVASessionInfo.BuyingBarCodeController;
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
                controller.LoadViewModel(Model.Barcode);
                if (controller.ViewModel.MainTable != null)
                {
                    this.InternalBarcodeView.Text = this.InternalBarcode.SelectedItem == null ? "" : this.InternalBarcode.SelectedItem.Text;
                }
            }
        }
    }
}