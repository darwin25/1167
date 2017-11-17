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
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_STORE, Edge.SVA.Model.BUY_STORE>
    {
        BuyingStoreController controller;
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
                SVASessionInfo.BuyingStoreController = null;
            }
            controller = SVASessionInfo.BuyingStoreController;
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
                controller.LoadViewModel(Model.StoreID);
                if (controller.ViewModel.MainTable != null)
                {

                    //this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    //this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());

                    //this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    //this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);
                    this.BrandCode.Text = controller.ViewModel.MainTable.StoreBrandCode+"-"+DALTool.GetBrandName(controller.ViewModel.MainTable.StoreBrandCode, null);
                    this.uploadFilePath1.Text = controller.ViewModel.MainTable.StorePicFile;
                    this.uploadFilePath2.Text = controller.ViewModel.MainTable.MapsPicFile;
                    this.uploadFilePath3.Text = controller.ViewModel.MainTable.MapsPicShadowFile;

                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");
                    this.btnPreview3.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath3.Text, "Image");

                    this.btnPreview1.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.StorePicFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview2.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.MapsPicFile) ? true : false;//没有照片时不显示View按钮(Len)
                    this.btnPreview3.Hidden = string.IsNullOrEmpty(controller.ViewModel.MainTable.MapsPicShadowFile) ? true : false;//没有照片时不显示View按钮(Len)

                    this.StatusView.Text = this.Status.SelectedItem == null ? "" : this.Status.SelectedItem.Text;
                    this.StoreTypeIDView.Text = this.StoreTypeID.SelectedValue == "0" ? "" : this.StoreTypeID.SelectedText;
                    this.ComparableView.Text = this.Comparable.SelectedItem == null ? "" : this.Comparable.SelectedItem.Text;
                }
            }
        }
    }
}