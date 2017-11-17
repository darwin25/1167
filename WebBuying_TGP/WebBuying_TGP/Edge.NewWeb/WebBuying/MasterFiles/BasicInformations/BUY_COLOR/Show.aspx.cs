using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_COLOR;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_COLOR
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_COLOR, Edge.SVA.Model.BUY_COLOR>
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
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.ColorID);
                this.uploadFilePath.Text = controller.ViewModel.MainTable.ColorPicFile;
                this.btnPreview.OnClientClick = WindowPic.GetShowReference("../../../../TempImage.aspx?url=" + this.uploadFilePath.Text, "Image");
                this.btnPreview.Hidden = string.IsNullOrEmpty(Model.ColorPicFile) ? true : false;//没有照片时不显示View按钮(Len)

            }
        }
    }
}