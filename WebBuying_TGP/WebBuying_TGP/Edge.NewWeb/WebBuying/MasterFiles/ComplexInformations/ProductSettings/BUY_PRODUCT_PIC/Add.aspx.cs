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

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCT_PIC
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT_PIC, Edge.SVA.Model.BUY_PRODUCT_PIC>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingProductPictureController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingProductPictureController = null;

                if (!string.IsNullOrEmpty(Tools.SVASessionInfo.BuyingProdCode))
                {
                    this.ProdCode.Enabled = false;
                    this.ProdCode.Readonly = true;
                    this.ProdCode.Text = Tools.SVASessionInfo.BuyingProdCode;
                }

            }
            controller = SVASessionInfo.BuyingProductPictureController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                //校验图片类型是否正确
                if (!ValidateImg(this.ProductThumbnailsFile.FileName))
                {
                    return;
                }
                if (!ValidateImg(this.ProductFullPicFile.FileName))
                {
                    return;
                }

                controller.ViewModel.MainTable.ProductThumbnailsFile = this.ProductThumbnailsFile.SaveToServer("BUY_PRODUCT_PIC");
                controller.ViewModel.MainTable.ProductFullPicFile = this.ProductFullPicFile.SaveToServer("BUY_PRODUCT_PIC");
            }
            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Product Picture Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Product Picture Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowAddFailed();
            }
        }

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