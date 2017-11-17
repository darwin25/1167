using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BOXSALE, Edge.SVA.Model.BUY_BOXSALE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBoxSaleController controller;
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
            controller = SVASessionInfo.BuyingBoxSaleController;
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
                controller.LoadViewModel(Model.BOMID);
                this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());
            }
        }
    }
}