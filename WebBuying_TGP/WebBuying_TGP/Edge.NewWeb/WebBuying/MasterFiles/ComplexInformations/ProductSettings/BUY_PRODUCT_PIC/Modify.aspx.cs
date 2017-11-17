using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCT_PIC;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCT_PIC
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT_PIC, Edge.SVA.Model.BUY_PRODUCT_PIC>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProductPictureController controller;
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
        }


        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.KeyID);
                if (controller.ViewModel.MainTable != null)
                {
                    //存在小图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.ProductThumbnailsFile))
                    {
                        this.FormLoad.Hidden = true;
                        this.FormReLoad.Hidden = false;
                        this.btnBack1.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad.Hidden = false;
                        this.FormReLoad.Hidden = true;
                        this.btnBack1.Hidden = true;
                    }
                    //存在中图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.ProductFullPicFile))
                    {
                        this.FormLoad2.Hidden = true;
                        this.FormReLoad2.Hidden = false;
                        this.btnBack2.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad2.Hidden = false;
                        this.FormReLoad2.Hidden = true;
                        this.btnBack2.Hidden = true;
                    }

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ProductThumbnailsFile;
                    this.uploadFilePath2.Text = controller.ViewModel.MainTable.ProductFullPicFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");
                }

            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog("Update", "Update");
            controller.ViewModel.MainTable = this.GetUpdateObject();
            //产品图片
            if (controller.ViewModel.MainTable != null)
            {
                if (!string.IsNullOrEmpty(this.ProductThumbnailsFile.ShortFileName) && this.FormLoad.Hidden == false)
                {
                    if (!ValidateImg(this.ProductThumbnailsFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ProductThumbnailsFile = this.ProductThumbnailsFile.SaveToServer("BUY_PRODUCT_PIC");
                }
                else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                {
                    if (!ValidateImg(this.uploadFilePath.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ProductThumbnailsFile = this.uploadFilePath.Text;
                }
                if (!string.IsNullOrEmpty(this.ProductFullPicFile.ShortFileName) && this.FormLoad2.Hidden == false)
                {
                    if (!ValidateImg(this.ProductFullPicFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ProductFullPicFile = this.ProductFullPicFile.SaveToServer("BUY_PRODUCT_PIC");
                }
                else if (this.FormReLoad2.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath2.Text))
                {
                    if (!ValidateImg(this.uploadFilePath2.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ProductFullPicFile = this.uploadFilePath2.Text;
                }

            }
            ExecResult er = controller.Update();
            if (er.Success)
            {
                if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.ProductThumbnailsFile))
                {
                    DeleteFile(this.uploadFilePath.Text);
                }
                if (this.FormReLoad2.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.ProductFullPicFile))
                {
                    DeleteFile(this.uploadFilePath2.Text);
                }
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Brand\t Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowSaveFailed(er.Message);
            }
            logger.WriteOperationLog("Update", er.Message);
        }

        #region 图片处理

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
        }

        protected void btnReUpLoad1_Click(object sender, EventArgs e)
        {
            this.FormLoad.Hidden = false;
            this.FormReLoad.Hidden = true;
        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath.Text))
            {
                this.FormLoad.Hidden = true;
                this.FormReLoad.Hidden = false;
            }
        }

        protected void btnReUpLoad2_Click(object sender, EventArgs e)
        {
            this.FormLoad2.Hidden = false;
            this.FormReLoad2.Hidden = true;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath2.Text))
            {
                this.FormLoad2.Hidden = true;
                this.FormReLoad2.Hidden = false;
            }
        }
        #endregion

        //校验图片文件是否为允许类型
        protected bool ValidateImg(string imgname)
        {
            if (!string.IsNullOrEmpty(imgname))
            {
                imgname = Path.GetExtension(imgname).TrimStart('.').ToLower();
                if (!webset.WebImageType.ToLower().Split('|').Contains(imgname))
                {
                    ShowWarning(Resources.MessageTips.ImgUpLoadFaild.Replace("{0}", webset.WebImageType.Replace("|", ",")));
                    return false;
                }
            }
            return true;
        }
    }
}