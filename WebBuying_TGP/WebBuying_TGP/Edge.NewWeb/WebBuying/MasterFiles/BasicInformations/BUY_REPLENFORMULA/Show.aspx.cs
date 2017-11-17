using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLENFORMULA;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLENFORMULA
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_REPLENFORMULA, Edge.SVA.Model.BUY_REPLENFORMULA>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingReplenformulaController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingReplenformulaController = null;
            }
            controller = SVASessionInfo.BuyingReplenformulaController;
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
                controller.LoadViewModel(Model.ReplenFormulaID);

                if (controller.ViewModel.MainTable != null)
                {
                    if (controller.ViewModel.MainTable.Quotation == 0)
                    {
                        this.QuotationView.Text = "不是";
                    }
                    else
                    {
                        this.QuotationView.Text = "Yes";
                    }
                    if (controller.ViewModel.MainTable.Deposited == 0)
                    {
                        this.DepositedView.Text = "不是";
                    }
                    else
                    {
                        this.DepositedView.Text = "Yes";
                    }
                    if (controller.ViewModel.MainTable.AdvSales == 0)
                    {
                        this.AdvSalesView.Text = "不是";
                    }
                    else
                    {
                        this.AdvSalesView.Text = "Yes";
                    }
                }
            }
        }
    }
}