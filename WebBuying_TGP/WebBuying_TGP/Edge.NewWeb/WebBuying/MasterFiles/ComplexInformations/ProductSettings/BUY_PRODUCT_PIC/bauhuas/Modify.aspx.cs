using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCT_PIC;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCT_PIC.bauhuas
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT_PIC_Pending, Edge.SVA.Model.BUY_PRODUCT_PIC_Pending>
    {
        #region 全局变量
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProductPictureController controller;
        Edge.SVA.BLL.BUY_PRODUCT_Pending productPendingBLL = new SVA.BLL.BUY_PRODUCT_Pending();
        Edge.SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending bauPendingBLL = new SVA.BLL.BUY_PRODUCT_ADD_BAU_Pending();
        Edge.SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending classfiyPendingBLL = new SVA.BLL.BUY_PRODUCT_CLASSIFY_Pending();
        Edge.SVA.BLL.BUY_Product_Particulars_Pending particularsPendingBLL = new SVA.BLL.BUY_Product_Particulars_Pending();
        #endregion
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
                controller.LoadViewPendingModel(Model.KeyID);
                //产品图片
                if (controller.ViewModel.MainPending != null)
                {
                    //存在小图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainPending.ProductThumbnailsFile))
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
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainPending.ProductFullPicFile))
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

                    this.uploadFilePath.Text = controller.ViewModel.MainPending.ProductThumbnailsFile;
                    this.uploadFilePath2.Text = controller.ViewModel.MainPending.ProductFullPicFile;
                    this.rblIsVideo.SelectedValue = controller.ViewModel.MainPending.IsVideo.ToString();
                    this.rblIs360Pic.SelectedValue = controller.ViewModel.MainPending.Is360Pic.ToString();
                    this.rblIsSizeCategory.SelectedValue = controller.ViewModel.MainPending.IsSizeCategory.ToString();
                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");
                }

            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");
            try
            {
                controller.ViewModel.MainPending = this.GetUpdateObject();

                if (controller.ViewModel.MainPending != null)
                {
                    if (!string.IsNullOrEmpty(this.ProductThumbnailsFile.ShortFileName) && this.FormLoad.Hidden == false)
                    {
                        if (!ValidateImg(this.ProductThumbnailsFile.FileName))
                        {
                            return;
                        }
                        controller.ViewModel.MainPending.ProductThumbnailsFile = this.ProductThumbnailsFile.SaveToServer("BUY_PRODUCT_PIC");
                    }
                    else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                    {
                        if (!ValidateImg(this.uploadFilePath.Text))
                        {
                            return;
                        }
                        controller.ViewModel.MainPending.ProductThumbnailsFile = this.uploadFilePath.Text;
                    }
                    if (!string.IsNullOrEmpty(this.ProductFullPicFile.ShortFileName) && this.FormLoad2.Hidden == false)
                    {
                        if (!ValidateImg(this.ProductFullPicFile.FileName))
                        {
                            return;
                        }
                        controller.ViewModel.MainPending.ProductFullPicFile = this.ProductFullPicFile.SaveToServer("BUY_PRODUCT_PIC");
                    }
                    else if (this.FormReLoad2.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath2.Text))
                    {
                        if (!ValidateImg(this.uploadFilePath2.Text))
                        {
                            return;
                        }
                        controller.ViewModel.MainPending.ProductFullPicFile = this.uploadFilePath2.Text;
                    }

                    controller.ViewModel.MainPending.IsVideo = Convert.ToInt32(this.rblIsVideo.SelectedValue);
                    controller.ViewModel.MainPending.Is360Pic = Convert.ToInt32(this.rblIs360Pic.SelectedValue);
                    controller.ViewModel.MainPending.IsSizeCategory = Convert.ToInt32(this.rblIsSizeCategory.SelectedValue);

                }
                /*ViewBUY_PRODUCT_Pending表中记录如果没有就新增*/
                Edge.SVA.Model.BUY_PRODUCT_Pending productPending = productPendingBLL.GetModel(this.ProdCode.Text);
                if (productPending == null)
                {
                    productPendingBLL.Add(this.ProdCode.Text);
                    //更新状态为0
                    Edge.SVA.Model.BUY_PRODUCT_Pending entity = new SVA.Model.BUY_PRODUCT_Pending();
                    entity.Status = 0;
                    productPendingBLL.Update(entity);
                }
                /*ViewBUY_PRODUCT_ADD_BAU_Pending表中记录，如果没有就新增*/
                Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending bauPending = bauPendingBLL.GetModel(this.ProdCode.Text);
                if (bauPending == null)
                {
                    bauPendingBLL.Add(this.ProdCode.Text);
                }
                /*ViewBUY_PRODUCT_CLASSIFY_Pending表中及记录，如果没有就新增*/
                Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending classfiyPending = classfiyPendingBLL.GetPRODUCT_CLASSIFY(this.ProdCode.Text);
                if (classfiyPending == null)
                {
                    classfiyPendingBLL.Add(this.ProdCode.Text);
                }
                /*ViewparticularsPendingBLL表中记录，如果没有就新增*/
                Edge.SVA.Model.BUY_Product_Particulars_Pending particularsPending = particularsPendingBLL.GetParticularsPending(this.ProdCode.Text);
                if (particularsPending == null)
                {
                    particularsPendingBLL.Add(this.ProdCode.Text);
                }
                ExecResult er = controller.PendingUpdate();
                if (er.Success)
                {
                    if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainPending.ProductThumbnailsFile))
                    {
                        DeleteFile(this.uploadFilePath.Text);
                    }
                    if (this.FormReLoad2.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainPending.ProductFullPicFile))
                    {
                        DeleteFile(this.uploadFilePath2.Text);
                    }
                    CloseAndPostBack();
                }
                else
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Brand\t Code:" + controller.ViewModel.MainPending == null ? "No Data" : controller.ViewModel.MainPending.ProdCode);
                    ShowSaveFailed(er.Message);
                }

            }
            catch (Exception ex)
            {
                logger.WriteOperationLog("Update", ex.Message);
                ShowAddFailed();
            }
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