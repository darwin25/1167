using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_PRODUCTSIZE;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_PRODUCTSIZE
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCTSIZE, Edge.SVA.Model.BUY_PRODUCTSIZE>
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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add ProductSize Success Code:" + controller.ViewModel.MainTable.ProductSizeCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add ProductSize Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProductSizeCode);
                ShowSaveFailed(er.Message);
            }

        }
    }
}