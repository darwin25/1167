using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BANK;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BANK
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BANK, Edge.SVA.Model.BUY_BANK>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBankController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingBankController = null;
            }
            controller = SVASessionInfo.BuyingBankController;
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
                controller.LoadViewModel(Model.BankID);
            }
        }
    }
}