using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_PRODUCTSIZE;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_PRODUCTSIZE
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCTSIZE, Edge.SVA.Model.BUY_PRODUCTSIZE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProductSizeController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingProductSizeController = null;
            }
            controller = SVASessionInfo.BuyingProductSizeController;
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
                controller.LoadViewModel(Model.ProductSizeID);
            }
        }
    }
}