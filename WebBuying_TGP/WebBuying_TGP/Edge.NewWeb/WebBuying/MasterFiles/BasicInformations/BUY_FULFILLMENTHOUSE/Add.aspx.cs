using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_FULFILLMENTHOUSE;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_FULFILLMENTHOUSE
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_FULFILLMENTHOUSE, Edge.SVA.Model.BUY_FULFILLMENTHOUSE>
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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Fulfillmenthouse Success Code:" + controller.ViewModel.MainTable.FulfillmentHouseCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Fulfillmenthouse Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.FulfillmentHouseCode);
                ShowSaveFailed(er.Message);
            }

        }
    }
}