using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BRAND;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BRAND
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BRAND, Edge.SVA.Model.BUY_BRAND>
    {
        BuyingBrandController controller;
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
                SVASessionInfo.BuyingBrandController = null;
            }
            controller = SVASessionInfo.BuyingBrandController;
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
                controller.LoadViewModel(Model.BrandID);
                if (controller.ViewModel.MainTable != null)
                {

                    this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());

                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.BrandPicSFile;
                    this.uploadFilePath1.Text = controller.ViewModel.MainTable.BrandPicMFile;
                    this.uploadFilePath2.Text = controller.ViewModel.MainTable.BrandPicGFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(Model.BrandPicSFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview1.Hidden = string.IsNullOrEmpty(Model.BrandPicMFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview2.Hidden = string.IsNullOrEmpty(Model.BrandPicGFile) ? true : false;//没有照片时不显示View按钮(Len)

                }
            }
        }
    }
}