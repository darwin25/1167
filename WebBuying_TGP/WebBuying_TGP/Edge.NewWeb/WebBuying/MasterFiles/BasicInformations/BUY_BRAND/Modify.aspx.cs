using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BRAND;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BRAND
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BRAND, Edge.SVA.Model.BUY_BRAND>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBrandController controller;
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
                ExtAspNetTool.SetHiden(this.CardIssuerID);
                ExtAspNetTool.SetHiden(this.IndustryID);
            }
            controller = SVASessionInfo.BuyingBrandController;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (Model != null)
                {
                    //存在小图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(Model.BrandPicSFile))
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
                    if (!string.IsNullOrEmpty(Model.BrandPicMFile))
                    {
                        this.FormLoad1.Hidden = true;
                        this.FormReLoad1.Hidden = false;
                        this.btnBack2.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad1.Hidden = false;
                        this.FormReLoad1.Hidden = true;
                        this.btnBack2.Hidden = true;
                    }
                    //存在大图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(Model.BrandPicGFile))
                    {
                        this.FormLoad2.Hidden = true;
                        this.FormReLoad2.Hidden = false;
                        this.btnBack3.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad2.Hidden = false;
                        this.FormReLoad2.Hidden = true;
                        this.btnBack3.Hidden = true;
                    }

                    this.uploadFilePath.Text = Model.BrandPicSFile;
                    this.uploadFilePath1.Text = Model.BrandPicMFile;
                    this.uploadFilePath2.Text = Model.BrandPicGFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                    this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");
                    this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, "Update");
            if (string.IsNullOrEmpty(this.BrandDesc1.Text) || this.BrandDesc1.Text == "<br>")
            {
                ShowWarning(Resources.MessageTips.BrandDesc1CannotBeEmpty);
                return;
            }

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;

                if (!string.IsNullOrEmpty(this.BrandPicSFile.ShortFileName) && this.FormLoad.Hidden == false)
                {
                    if (!ValidateImg(this.BrandPicSFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.BrandPicSFile = this.BrandPicSFile.SaveToServer("BUY_BRAND");
                }
                else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                {
                    if (!ValidateImg(this.uploadFilePath.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.BrandPicSFile = this.uploadFilePath.Text;
                }
                if (!string.IsNullOrEmpty(this.BrandPicMFile.ShortFileName) && this.FormLoad1.Hidden == false)
                {
                    if (!ValidateImg(this.BrandPicMFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.BrandPicMFile = this.BrandPicMFile.SaveToServer("BUY_BRAND");
                }
                else if (this.FormReLoad1.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath1.Text))
                {
                    if (!ValidateImg(this.uploadFilePath1.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.BrandPicMFile = this.uploadFilePath1.Text;
                }
                if (!string.IsNullOrEmpty(this.BrandPicGFile.ShortFileName) && this.FormLoad2.Hidden == false)
                {
                    if (!ValidateImg(this.BrandPicGFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.BrandPicGFile = this.BrandPicGFile.SaveToServer("BUY_BRAND");
                }
                else if (this.FormReLoad2.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath2.Text))
                {
                    if (!ValidateImg(this.uploadFilePath2.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.BrandPicGFile = this.uploadFilePath2.Text;
                }
            }

            ExecResult er = controller.Update();
            if (er.Success)
            {
                if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.BrandPicSFile))
                {
                    DeleteFile(this.uploadFilePath.Text);
                }
                if (this.FormReLoad1.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.BrandPicMFile))
                {
                    DeleteFile(this.uploadFilePath1.Text);
                }
                if (this.FormReLoad2.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.BrandPicGFile))
                {
                    DeleteFile(this.uploadFilePath2.Text);
                }
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Brand\t Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.BrandCode);
                ShowSaveFailed(er.Message);
            }
        }

        #region 图片处理
        //protected void ViewPicture1(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.BrandPicSFile.ShortFileName))
        //    {
        //        this.PicturePath.Text = this.BrandPicSFile.SaveToServer("BUY_BRAND");
        //        FineUI.PageContext.RegisterStartupScript(WindowPicture.GetShowReference("../../../../../TempImage.aspx?url=" + this.PicturePath.Text, "Image"));
        //    }
        //}

        //protected void ViewPicture2(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.BrandPicMFile.ShortFileName))
        //    {
        //        this.PicturePath.Text = this.BrandPicMFile.SaveToServer("BUY_BRAND");
        //        FineUI.PageContext.RegisterStartupScript(WindowPicture.GetShowReference("../../../../../TempImage.aspx?url=" + this.PicturePath.Text, "Image"));
        //    }
        //}

        //protected void ViewPicture3(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.BrandPicGFile.ShortFileName))
        //    {
        //        this.PicturePath.Text = this.BrandPicGFile.SaveToServer("BUY_BRAND");
        //        FineUI.PageContext.RegisterStartupScript(WindowPicture.GetShowReference("../../../../../TempImage.aspx?url=" + this.PicturePath.Text, "Image"));
        //    }
        //}

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            DeleteFile(this.PicturePath.Text);
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
            this.FormLoad1.Hidden = false;
            this.FormReLoad1.Hidden = true;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath1.Text))
            {
                this.FormLoad1.Hidden = true;
                this.FormReLoad1.Hidden = false;
            }
        }

        protected void btnReUpLoad3_Click(object sender, EventArgs e)
        {
            this.FormLoad2.Hidden = false;
            this.FormReLoad2.Hidden = true;
        }

        protected void btnBack3_Click(object sender, EventArgs e)
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