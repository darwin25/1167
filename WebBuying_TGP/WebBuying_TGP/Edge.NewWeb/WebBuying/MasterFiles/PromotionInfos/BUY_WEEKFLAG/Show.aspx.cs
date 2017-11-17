using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_WEEKFLAG, Edge.SVA.Model.BUY_WEEKFLAG>
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

                if (controller.ViewModel.MainTable != null)
                {
                    this.SundayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.SundayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.MondayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.MondayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.TuesdayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.TuesdayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.WednesdayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.WednesdayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.ThursdayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.ThursdayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.FridayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.FridayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.SaturdayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.SaturdayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                }
            }
        }
    }
}