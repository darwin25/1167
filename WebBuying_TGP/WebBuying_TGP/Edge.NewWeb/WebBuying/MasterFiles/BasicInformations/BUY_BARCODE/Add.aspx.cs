using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BARCODE
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BARCODE, Edge.SVA.Model.BUY_BARCODE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBarCodeController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingBarCodeController = null;

                if (!string.IsNullOrEmpty(Tools.SVASessionInfo.BuyingProdCode))
                {
                    this.ProdCode.Enabled = false;
                    this.ProdCode.Readonly = true;
                    this.ProdCode.Text = Tools.SVASessionInfo.BuyingProdCode;
                }
            }
            controller = SVASessionInfo.BuyingBarCodeController;
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
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BarCode Success Code:" + controller.ViewModel.MainTable.Barcode);
                //CloseAndRefresh();
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BarCode Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.Barcode);
                ShowAddFailed();
            }

        }
    }
}