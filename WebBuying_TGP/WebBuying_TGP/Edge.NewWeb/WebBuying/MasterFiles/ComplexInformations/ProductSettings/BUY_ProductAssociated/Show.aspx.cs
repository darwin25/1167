using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductAssociated;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductAssociated
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_ProductAssociated, Edge.SVA.Model.BUY_ProductAssociated>
    {
        BuyingProdAssociatedController controller;
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingProdAssociatedController = null;
            }
            controller = SVASessionInfo.BuyingProdAssociatedController;
            logger.WriteOperationLog(this.PageName, "Show");

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.KeyID);
                if (controller.ViewModel.MainTable != null)
                {
                    this.uploadFilePath.Text = controller.ViewModel.MainTable.AssociatedProdFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.AssociatedProdFile) ? true : false;//没有照片时不显示View按钮(Len)
                }
            }
        }
    }
}