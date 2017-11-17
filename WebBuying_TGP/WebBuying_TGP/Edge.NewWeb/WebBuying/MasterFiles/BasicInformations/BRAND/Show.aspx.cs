using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BRAND;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BRAND
{
    /// <summary>
    /// 店铺品牌View
    /// 创建人：lisa
    /// 创建时间：2016-08-11
    /// </summary>
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Brand, Edge.SVA.Model.Brand>
    {
        BrandController controller;
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
                SVASessionInfo.BrandController = null;
            }
            controller = SVASessionInfo.BrandController;
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
                controller.LoadViewModel(Model.StoreBrandID);
                if (controller.ViewModel.MainTable != null)
                {

                    this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());

                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.StoreBrandPicSFile;
                    this.uploadFilePath1.Text = controller.ViewModel.MainTable.StoreBrandPicMFile;
                    this.uploadFilePath2.Text = controller.ViewModel.MainTable.StoreBrandPicGFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");

                    this.btnPreview.Hidden = string.IsNullOrEmpty(Model.StoreBrandPicSFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview1.Hidden = string.IsNullOrEmpty(Model.StoreBrandPicMFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview2.Hidden = string.IsNullOrEmpty(Model.StoreBrandPicGFile) ? true : false;//没有照片时不显示View按钮(Len)

                }
            }
        }
    }
}