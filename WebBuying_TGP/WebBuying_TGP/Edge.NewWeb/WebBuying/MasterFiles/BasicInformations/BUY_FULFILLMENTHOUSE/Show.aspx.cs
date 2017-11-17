using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_FULFILLMENTHOUSE;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_FULFILLMENTHOUSE
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_FULFILLMENTHOUSE, Edge.SVA.Model.BUY_FULFILLMENTHOUSE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingFulfillmenthouseController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingFulfillmenthouseController = null;
            }
            controller = SVASessionInfo.BuyingFulfillmenthouseController;
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
                controller.LoadViewModel(Model.FulfillmentHouseID);

                if (controller.ViewModel.MainTable != null)
                {
                    this.PriorityView.Text = this.Priority.SelectedItem == null ? "" : this.Priority.SelectedItem.Text;
                }
            }
        }
    }
}