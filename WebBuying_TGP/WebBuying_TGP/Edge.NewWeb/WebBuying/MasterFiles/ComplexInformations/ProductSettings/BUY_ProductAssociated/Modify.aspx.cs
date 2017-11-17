using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_ProductAssociated;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductAssociated
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_ProductAssociated, Edge.SVA.Model.BUY_ProductAssociated>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProdAssociatedController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingProdAssociatedController = null;
            }
            controller = SVASessionInfo.BuyingProdAssociatedController;
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
                    if (!string.IsNullOrEmpty(controller.ViewModel.MainTable.AssociatedProdFile))
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

                    this.uploadFilePath.Text = controller.ViewModel.MainTable.AssociatedProdFile;

                    this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, "Update");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                if (!string.IsNullOrEmpty(this.AssociatedProdFile.ShortFileName) && this.FormLoad.Hidden == false)
                {
                    if (!ValidateImg(this.AssociatedProdFile.FileName))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.AssociatedProdFile = this.AssociatedProdFile.SaveToServer("BUY_ProductAssociated");
                }
                else if (this.FormReLoad.Hidden == false && !string.IsNullOrEmpty(this.uploadFilePath.Text))
                {
                    if (!ValidateImg(this.uploadFilePath.Text))
                    {
                        return;
                    }
                    controller.ViewModel.MainTable.AssociatedProdFile = this.uploadFilePath.Text;
                }
            }

            ExecResult er = controller.Update();
            if (er.Success)
            {
                if (this.FormReLoad.Hidden == true && string.IsNullOrEmpty(controller.ViewModel.MainTable.AssociatedProdFile))
                {
                    DeleteFile(this.uploadFilePath.Text);
                }
                //修改完成后将ProdCode返还到查询界面
                SVASessionInfo.BuyingProdCode = this.ProdCode.Text;
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "BUY_ProductAssociated Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowSaveFailed(er.Message);
            }
        }

        #region 图片处理

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