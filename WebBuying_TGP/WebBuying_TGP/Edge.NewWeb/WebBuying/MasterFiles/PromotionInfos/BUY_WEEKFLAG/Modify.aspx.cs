using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_WEEKFLAG, Edge.SVA.Model.BUY_WEEKFLAG>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingWeekFlagController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingWeekFlagController = null;
            }
            controller = SVASessionInfo.BuyingWeekFlagController;
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
                controller.LoadViewModel(Model.WeekFlagID);
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();

            ExecResult er = controller.Update();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update WeekFlag Success Code:" + controller.ViewModel.MainTable.WeekFlagCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update WeekFlag Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.WeekFlagCode);
                ShowSaveFailed(er.Message);
            }

        }
    }
}