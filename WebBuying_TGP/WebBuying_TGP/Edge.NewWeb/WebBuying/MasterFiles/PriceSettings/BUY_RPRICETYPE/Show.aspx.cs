using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICETYPE;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_RPRICETYPE
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_RPRICETYPE, Edge.SVA.Model.BUY_RPRICETYPE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingPriceTypeController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingPriceTypeController = null;
            }
            controller = SVASessionInfo.BuyingPriceTypeController;
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
                controller.LoadViewModel(Model.RPriceTypeID);

                if (controller.ViewModel.MainTable != null)
                {
                    this.SupervisorView.Text = this.Supervisor.SelectedItem == null ? "" : this.Supervisor.SelectedItem.Text;
                    this.SerialNoView.Text = this.SerialNo.SelectedItem == null ? "" : this.SerialNo.SelectedItem.Text;
                    this.DiscountView.Text = this.Discount.SelectedItem == null ? "" : this.Discount.SelectedItem.Text;
                    this.MemberShipView.Text = this.MemberShip.SelectedItem == null ? "" : this.MemberShip.SelectedItem.Text;
                    this.RANOnlyView.Text = this.RANOnly.SelectedItem == null ? "" : this.RANOnly.SelectedItem.Text;
                    this.DAMOnlyView.Text = this.DAMOnly.SelectedItem == null ? "" : this.DAMOnly.SelectedItem.Text;
                }
            }
        }
    }
}