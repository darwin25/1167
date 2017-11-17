using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_DAYFLAG;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_DAYFLAG
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_DAYFLAG, Edge.SVA.Model.BUY_DAYFLAG>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingDayFlagController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingDayFlagController = null;
            }
            controller = SVASessionInfo.BuyingDayFlagController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add DayFlag Success Code:" + controller.ViewModel.MainTable.DayFlagCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add DayFlag Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.DayFlagCode);
                ShowSaveFailed(er.Message);
            }

        }
    }
}