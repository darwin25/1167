using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCT_PIC;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCT_PIC
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT_PIC, Edge.SVA.Model.BUY_PRODUCT_PIC>
    {
        BuyingProductPictureController controller;
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
                SVASessionInfo.BuyingProductPictureController = null;
            }
            controller = SVASessionInfo.BuyingProductPictureController;
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

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ProductThumbnailsFile;
                    this.uploadFilePath1.Text = controller.ViewModel.MainTable.ProductFullPicFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(Model.ProductThumbnailsFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview1.Hidden = string.IsNullOrEmpty(Model.ProductFullPicFile) ? true : false;//没有照片时不显示View按钮(Len)
                }
            }
        }
    }
}