using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_DISCOUNT;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_DISCOUNT
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_DISCOUNT, Edge.SVA.Model.BUY_DISCOUNT>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingDiscountController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingDiscountController = null;
            }
            controller = SVASessionInfo.BuyingDiscountController;
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
                controller.LoadViewModel(Model.DiscountId);

                if (controller.ViewModel.MainTable != null)
                {
                    this.DiscTypeView.Text = this.DiscType.SelectedText;
                    this.AuthLevelView.Text = this.AuthLevel.SelectedText;
                    this.AllowDiscOnDiscView.Text = this.AllowDiscOnDisc.SelectedItem == null ? "" : this.AllowDiscOnDisc.SelectedItem.Text;
                    this.AllowChgDiscView.Text = this.AllowChgDisc.SelectedItem == null ? "" : this.AllowChgDisc.SelectedItem.Text;
                    this.TransDiscControlView.Text = this.TransDiscControl.SelectedText;
                    this.StatusView.Text = this.Status.SelectedItem == null ? "" : this.Status.SelectedItem.Text;
                }
            }
        }
    }
}