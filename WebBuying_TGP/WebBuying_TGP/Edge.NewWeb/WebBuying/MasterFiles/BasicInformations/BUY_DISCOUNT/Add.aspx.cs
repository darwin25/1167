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
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_DISCOUNT, Edge.SVA.Model.BUY_DISCOUNT>
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
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Discount Success Code:" + controller.ViewModel.MainTable.DiscountCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Discount Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.DiscountCode);
                ShowSaveFailed(er.Message);
            }

        }
    }
}