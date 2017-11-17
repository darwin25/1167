using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.ProductSettings.BUY_PRODUCT_PIC;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCT_PIC.bauhuas
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PRODUCT_PIC_Pending, Edge.SVA.Model.BUY_PRODUCT_PIC_Pending>
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

            try
            {
                controller.ViewModel.MainPending = this.GetAddObject();
                if (controller.ViewModel.MainPending != null)
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
                    controller.ViewModel.MainPending.IsVideo = Convert.ToInt32(this.rblIsVideo.SelectedValue);
                    controller.ViewModel.MainPending.Is360Pic = Convert.ToInt32(this.rblIs360Pic.SelectedValue);
                    controller.ViewModel.MainPending.IsSizeCategory = Convert.ToInt32(this.rblIsSizeCategory.SelectedValue);
                    controller.ViewModel.MainPending.ProductThumbnailsFile = this.ProductThumbnailsFile.SaveToServer("BUY_PRODUCT_PIC");
                    controller.ViewModel.MainPending.ProductFullPicFile = this.ProductFullPicFile.SaveToServer("BUY_PRODUCT_PIC");
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
                ExecResult er = controller.PendingAdd();
                if (er.Success)
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Product Picture Success Code:" + controller.ViewModel.MainPending.ProdCode);
                    CloseAndPostBack();
                }
                else
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Product Picture Failed Code:" + controller.ViewModel.MainPending == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                    ShowAddFailed();
                }
            }
            catch (Exception ex)
            {
                logger.WriteOperationLog("Update", ex.Message);
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