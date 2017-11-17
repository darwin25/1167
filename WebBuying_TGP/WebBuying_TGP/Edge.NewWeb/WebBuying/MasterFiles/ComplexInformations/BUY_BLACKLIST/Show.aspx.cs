using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_BLACKLIST;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_BLACKLIST
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BLACKLIST, Edge.SVA.Model.BUY_BLACKLIST>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBlackListController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingBlackListController = null;
            }
            controller = SVASessionInfo.BuyingBlackListController;
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
                controller.LoadViewModel(Model.BlackID);
            }
        }
    }
}