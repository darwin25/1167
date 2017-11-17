using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_VENDOR;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_VENDOR
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_VENDOR, Edge.SVA.Model.BUY_VENDOR>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingVendorController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingVendorController = null;
            }
            controller = SVASessionInfo.BuyingVendorController;
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
                controller.LoadViewModel(Model.VendorID);

                if (controller.ViewModel.MainTable != null)
                {
                    this.PreferFlagView.Text = this.PreferFlag.SelectedItem == null ? "" : this.PreferFlag.SelectedItem.Text;
                    this.OverseaView.Text = this.Oversea.SelectedItem == null ? "" : this.Oversea.SelectedItem.Text;
                    this.NonOrderView.Text = this.NonOrder.SelectedItem == null ? "" : this.NonOrder.SelectedItem.Text;
                }
            }
        }
    }
}