using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.FreightSettings;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.FreightSettings
{
    /// <summary>
    /// 物流运费设置View页面
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.LogisticsPrice, Edge.SVA.Model.LogisticsPrice>
    {
        LogisticsPriceController controller;
        Tools.Logger logger = Tools.Logger.Instance;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.LogisticsPriceController = null;
            }
            controller = SVASessionInfo.LogisticsPriceController;
            logger.WriteOperationLog(this.PageName, "Show");

        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.KeyID);
                if (controller.ViewModel.MainTable != null)
                {
                    //物流供应商
                    this.LogisticsProviderID.Text = DALTool.GetLogisticsProviderName(controller.ViewModel.MainTable.LogisticsProviderID, null);
                    //省编码
                    this.ProvinceCode.Text = DALTool.GetProviceName(controller.ViewModel.MainTable.ProvinceCode,null);
                    //起步价
                    this.StartPrice.Text = string.Format("{0:F}", controller.ViewModel.MainTable.StartPrice);
                    //起步重量
                    this.StartWeight.Text = string.Format("{0:F}", controller.ViewModel.MainTable.StartWeight);
                    //每公斤溢出价格
                    this.OverflowPricePerKG.Text = string.Format("{0:F}", controller.ViewModel.MainTable.OverflowPricePerKG);
                }
            }
        }
    }
}