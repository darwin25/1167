using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BRAND;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.SVA;
using Edge.Web.Controllers.Accounts;
using Edge.SVA.Model;
using Edge.SVA.BLL.Domain.DataResources;
using System.IO;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BRAND
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BRAND, Edge.SVA.Model.BUY_BRAND>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBrandController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, "Add");

            if (string.IsNullOrEmpty(this.BrandDesc1.Text) || this.BrandDesc1.Text == "<br>")
            {
                ShowWarning(Resources.MessageTips.BrandDesc1CannotBeEmpty);
                return;
            }

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                //校验图片类型是否正确
                if (!ValidateImg(this.BrandPicSFile.FileName))
                {
                    return;
                }
                if (!ValidateImg(this.BrandPicMFile.FileName))
                {
                    return;
                }
                if (!ValidateImg(this.BrandPicGFile.FileName))
                {
                    return;
                }

                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
                controller.ViewModel.MainTable.BrandPicSFile = this.BrandPicSFile.SaveToServer("BUY_BRAND");
                controller.ViewModel.MainTable.BrandPicMFile = this.BrandPicMFile.SaveToServer("BUY_BRAND");
                controller.ViewModel.MainTable.BrandPicGFile = this.BrandPicGFile.SaveToServer("BUY_BRAND");
            }
            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Brand Success Code:" + controller.ViewModel.MainTable.BrandCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Brand Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.BrandCode);
                ShowSaveFailed(er.Message);
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