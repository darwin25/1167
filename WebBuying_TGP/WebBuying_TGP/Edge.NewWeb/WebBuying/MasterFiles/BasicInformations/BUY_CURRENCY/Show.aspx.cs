using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_CURRENCY;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_CURRENCY
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_CURRENCY, Edge.SVA.Model.BUY_CURRENCY>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingCurrencyController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingCurrencyController = null;
            }
            controller = SVASessionInfo.BuyingCurrencyController;
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
                controller.LoadViewModel(Model.CurrencyID);
                this.TenderTypeView.Text = this.TenderType.SelectedText;
                this.StatusView.Text = this.Status.SelectedItem == null ? "" : this.Status.SelectedItem.Text;
                this.CashSaleView.Text = this.CashSale.SelectedItem == null ? "" : this.CashSale.SelectedItem.Text;
                this.CouponValueView.Text = this.CouponValue.SelectedItem == null ? "" : this.CouponValue.SelectedItem.Text;
                this.PayTransferView.Text = this.PayTransfer.SelectedItem == null ? "" : this.PayTransfer.SelectedItem.Text;
                this.Refund_TypeView.Text = this.Refund_Type.SelectedItem == null ? "" : this.Refund_Type.SelectedItem.Text;
                this.BaseView.Text = this.Base.SelectedText;
                this.Rate.Text = controller.ViewModel.MainTable.Rate.ToString().TrimEnd('M');
            }
        }
    }
}