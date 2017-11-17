using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_STORE;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_STORE
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_STORE, Edge.SVA.Model.BUY_STORE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingStoreController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                //绑定店铺品牌
                ControlTool.BindStoreBrand(this.StoreBrandCode);
                SVASessionInfo.BuyingStoreController = null;
            }
            controller = SVASessionInfo.BuyingStoreController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;

                controller.ViewModel.MainTable.StorePicFile = this.StorePicFile.SaveToServer("BUY_STORE");
                controller.ViewModel.MainTable.MapsPicFile = this.MapsPicFile.SaveToServer("BUY_STORE");
                controller.ViewModel.MainTable.MapsPicShadowFile = this.MapsPicShadowFile.SaveToServer("BUY_STORE");
            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Store Success Code:" + controller.ViewModel.MainTable.StoreCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Store Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.StoreCode);
                //ShowAddFailed();
                ShowSaveFailed(er.Message);
            }

        }
    }
}