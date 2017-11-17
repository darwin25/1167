using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MONTHFLAG;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MONTHFLAG
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_MONTHFLAG, Edge.SVA.Model.BUY_MONTHFLAG>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingMonthFlagController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingMonthFlagController = null;
            }
            controller = SVASessionInfo.BuyingMonthFlagController;
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
                controller.LoadViewModel(Model.MonthFlagID);

                if (controller.ViewModel.MainTable != null)
                {
                    this.JanuaryFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.JanuaryFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.FebruaryFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.FebruaryFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.MarchFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.MarchFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.AprilFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.AprilFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.MayFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.MayFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.JuneFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.JuneFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.JulyFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.JulyFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.AugustFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.AugustFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.SeptemberFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.SeptemberFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.OctoberFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.OctoberFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.NovemberFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.NovemberFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.DecemberFlag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.DecemberFlag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                }
            }
        }
    }
}