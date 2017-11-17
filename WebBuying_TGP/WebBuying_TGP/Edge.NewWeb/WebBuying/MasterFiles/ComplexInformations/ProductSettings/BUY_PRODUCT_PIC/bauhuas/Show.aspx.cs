using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCT_PIC;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCT_PIC.bauhuas
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT_PIC_Pending, Edge.SVA.Model.BUY_PRODUCT_PIC_Pending>
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
                controller.LoadViewPendingModel(Model.KeyID);
                if (controller.ViewModel.MainPending != null)
                {
                    if (controller.ViewModel.MainPending.IsVideo == 0)
                    {
                        this.IsVideo.Text = "No";
                    }
                    else
                    {
                        this.IsVideo.Text = "Yes";
                    }
                    if (controller.ViewModel.MainPending.Is360Pic == 0)
                    {
                        this.Is360Pic.Text = "No";
                    }
                    else
                    {
                        this.Is360Pic.Text = "Yes";
                    }
                    if (controller.ViewModel.MainPending.IsSizeCategory == 0)
                    {
                        this.IsSizeCategory.Text = "No";
                    }
                    else
                    {
                        this.IsSizeCategory.Text = "Yes";
                    }
                    this.uploadFilePath.Text = controller.ViewModel.MainPending.ProductThumbnailsFile;
                    this.uploadFilePath1.Text = controller.ViewModel.MainPending.ProductFullPicFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(Model.ProductThumbnailsFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview1.Hidden = string.IsNullOrEmpty(Model.ProductFullPicFile) ? true : false;//没有照片时不显示View按钮(Len)
                }
            }
        }
    }
}