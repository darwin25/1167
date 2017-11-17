using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_COLOR;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.IO;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_COLOR
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_COLOR, Edge.SVA.Model.BUY_COLOR>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingColorController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingColorController = null;
            }
            controller = SVASessionInfo.BuyingColorController;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                controller.LoadViewModel(Model.ColorID);
                if (controller.ViewModel.MainTable != null)
                {
                    //存在图片时不需要验证此字段
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.ColorPicFile))
                    {
                        this.FormLoad.Hidden = true;
                        this.FormReLoad.Hidden = false;
                        this.btnBack.Hidden = false;
                    }
                    else
                    {
                        this.FormLoad.Hidden = false;
                        this.FormReLoad.Hidden = true;
                        this.btnBack.Hidden = true;
                    }

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.ColorPicFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, "Update");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;

                if (!string.IsNullOrEmpty(this.ColorPicFile.ShortFileName) && this.FormLoad.Hidden == false)
                {
                    if (!ValidateImg(this.ColorPicFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ColorPicFile = this.ColorPicFile.SaveToServer("BUY_COLOR");
                }
                else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                {
                    if (!ValidateImg(this.uploadFilePath.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.ColorPicFile = this.uploadFilePath.Text;
                }
            }

            ExecResult er = controller.Update();
            if (er.Success)
            {
                if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.ColorPicFile))
                {
                    DeleteFile(this.uploadFilePath.Text);
                }
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Color\t Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ColorCode);
                ShowSaveFailed(er.Message);
            }
        }

        #region 图片处理
        //protected void ViewPicture(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.ColorPicFile.ShortFileName))
        //    {
        //        this.uploadFilePath.Text = this.ColorPicFile.SaveToServer("BUY_COLOR");
        //        FineUI.PageContext.RegisterStartupScript(WindowPicture.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image"));
        //    }
        //}

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            DeleteFile(this.uploadFilePath.Text);
        }

        protected void btnReUpLoad_Click(object sender, EventArgs e)
        {
            this.FormLoad.Hidden = false;
            this.FormReLoad.Hidden = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.uploadFilePath.Text))
            {
                this.FormLoad.Hidden = true;
                this.FormReLoad.Hidden = false;
            }
        }
        #endregion

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