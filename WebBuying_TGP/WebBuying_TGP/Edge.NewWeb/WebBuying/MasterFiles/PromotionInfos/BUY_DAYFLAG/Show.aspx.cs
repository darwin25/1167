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
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_DAYFLAG, Edge.SVA.Model.BUY_DAYFLAG>
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

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.DayFlagID);

                if (controller.ViewModel.MainTable != null)
                {
                    this.Day1Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day1Flag.GetValueOrDefault(),SVASessionInfo.SiteLanguage);
                    this.Day2Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day2Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day3Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day3Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day4Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day4Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day5Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day5Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day6Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day6Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day7Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day7Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day8Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day8Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day9Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day9Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day10Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day10Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day11Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day11Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day12Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day12Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day13Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day13Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day14Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day14Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day15Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day15Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day16Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day16Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day17Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day17Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day18Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day18Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day19Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day19Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day20Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day20Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day21Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day21Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day22Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day22Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day23Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day23Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day24Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day24Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day25Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day25Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day26Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day26Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day27Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day27Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day28Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day28Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day29Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day29Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day30Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day30Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                    this.Day31Flag.Text = DataTool.GetDayFlagStatusName(controller.ViewModel.MainTable.Day31Flag.GetValueOrDefault(), SVASessionInfo.SiteLanguage);
                }
            }
        }
    }
}