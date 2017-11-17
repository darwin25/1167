using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_STORE;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_STORE
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_STORE, Edge.SVA.Model.BUY_STORE>
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

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (hasRight)
            {
                if (!this.IsPostBack)
                {
                    
                   controller.LoadViewModel(Model.StoreID);
                    if (controller.ViewModel.MainTable != null)
                    {
                        //存在小图片时不需要验证此字段
                        if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.StorePicFile))
                        {
                            this.FormLoad1.Hidden = true;
                            this.FormReLoad1.Hidden = false;
                            this.btnBack1.Hidden = false;
                        }
                        else
                        {
                            this.FormLoad1.Hidden = false;
                            this.FormReLoad1.Hidden = true;
                            this.btnBack1.Hidden = true;
                        }
                        //存在中图片时不需要验证此字段
                        if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.MapsPicFile))
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
                        //存在大图片时不需要验证此字段
                        if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.MapsPicShadowFile))
                        {
                            this.FormLoad3.Hidden = true;
                            this.FormReLoad3.Hidden = false;
                            this.btnBack3.Hidden = false;
                        }
                        else
                        {
                            this.FormLoad3.Hidden = false;
                            this.FormReLoad3.Hidden = true;
                            this.btnBack3.Hidden = true;
                        }

                        this.uploadFilePath1.Text = controller.ViewModel.MainTable.StorePicFile;
                        this.uploadFilePath2.Text = controller.ViewModel.MainTable.MapsPicFile;
                        this.uploadFilePath3.Text = controller.ViewModel.MainTable.MapsPicShadowFile;

                        this.btnPreview1.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath1.Text, "Image");
                        this.btnPreview2.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath2.Text, "Image");
                        this.btnPreview3.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath3.Text, "Image");
                    }
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;

                if (!string.IsNullOrEmpty(this.StorePicFile.ShortFileName) && this.FormLoad1.Hidden == false)
                {
                    if (!ValidateImg(this.StorePicFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.StorePicFile = this.StorePicFile.SaveToServer("BUY_STORE");
                }
                else if (this.FormReLoad1.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath1.Text))
                {
                    if (!ValidateImg(this.uploadFilePath1.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.StorePicFile = this.uploadFilePath1.Text;
                }
                if (!string.IsNullOrEmpty(this.MapsPicFile.ShortFileName) && this.FormLoad2.Hidden == false)
                {
                    if (!ValidateImg(this.MapsPicFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.MapsPicFile = this.MapsPicFile.SaveToServer("BUY_STORE");
                }
                else if (this.FormReLoad2.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath2.Text))
                {
                    if (!ValidateImg(this.uploadFilePath2.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.MapsPicFile = this.uploadFilePath2.Text;
                }
                if (!string.IsNullOrEmpty(this.MapsPicShadowFile.ShortFileName) && this.FormLoad3.Hidden == false)
                {
                    if (!ValidateImg(this.MapsPicShadowFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.MapsPicShadowFile = this.MapsPicShadowFile.SaveToServer("BUY_STORE");
                }
                else if (this.FormReLoad3.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath3.Text))
                {
                    if (!ValidateImg(this.uploadFilePath3.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.MapsPicShadowFile = this.uploadFilePath3.Text;
                }

            }

            ExecResult er = controller.Update();
            if (er.Success)
            {
                if (this.FormReLoad1.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.StorePicFile))
                {
                    DeleteFile(this.uploadFilePath1.Text);
                }
                if (this.FormReLoad2.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.MapsPicFile))
                {
                    DeleteFile(this.uploadFilePath2.Text);
                }
                if (this.FormReLoad3.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.MapsPicShadowFile))
                {
                    DeleteFile(this.uploadFilePath3.Text);
                }

                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Store Success Code:" + controller.ViewModel.MainTable.StoreCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Store Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.StoreCode);
                ShowSaveFailed(er.Message);
            }

        }

        protected void btnReUpLoad1_Click(object sender, EventArgs e)
        {
            this.FormLoad1.Hidden = false;
            this.FormReLoad1.Hidden = true;
        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath1.Text))
            {
                this.FormLoad1.Hidden = true;
                this.FormReLoad1.Hidden = false;
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

        protected void btnReUpLoad3_Click(object sender, EventArgs e)
        {
            this.FormLoad3.Hidden = false;
            this.FormReLoad3.Hidden = true;
        }

        protected void btnBack3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath3.Text))
            {
                this.FormLoad3.Hidden = true;
                this.FormReLoad3.Hidden = false;
            }
        }

        //校验图片文件是否为允许类型
        protected bool ValidateImg(string imgname)
        {
            if (!string.IsNullOrEmpty(imgname))
            {
                imgname = Path.GetExtension(imgname).TrimStart('.');
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