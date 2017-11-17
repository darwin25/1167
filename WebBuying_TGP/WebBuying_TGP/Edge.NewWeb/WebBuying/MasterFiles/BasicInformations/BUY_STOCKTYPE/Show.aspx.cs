using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_STOCKTYPE;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_STOCKTYPE
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_STOCKTYPE, Edge.SVA.Model.BUY_STOCKTYPE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingStockTypeController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingStockTypeController = null;
            }
            controller = SVASessionInfo.BuyingStockTypeController;
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
                controller.LoadViewModel(Model.StockTypeID);

                if (controller.ViewModel.MainTable != null)
                {
                    this.NeedSerialnoView.Text = this.NeedSerialno.SelectedItem == null ? "" : this.NeedSerialno.SelectedItem.Text;
                }
            }
        }
    }
}