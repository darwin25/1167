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
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_COLOR, Edge.SVA.Model.BUY_COLOR>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingColorController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
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

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            if (controller.ViewModel.MainTable != null)
            {               
                //校验图片类型是否正确
                if (!ValidateImg(this.ColorPicFile.FileName))
                {
                    return;
                }
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
                controller.ViewModel.MainTable.ColorPicFile = this.ColorPicFile.SaveToServer("BUY_COLOR");
            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Color Success Code:" + controller.ViewModel.MainTable.ColorCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Color Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ColorCode);
                ShowSaveFailed(er.Message);
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