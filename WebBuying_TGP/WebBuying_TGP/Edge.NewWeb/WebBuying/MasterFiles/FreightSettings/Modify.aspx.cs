using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Controllers.WebBuying.MasterFiles.FreightSettings;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.FreightSettings
{
    /// <summary>
    /// 修改物流运费设置
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.LogisticsPrice, Edge.SVA.Model.LogisticsPrice>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        LogisticsPriceController controller = new LogisticsPriceController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                //绑定物流供应商
                ControlTool.BindAllLogisticsProvider(LogisticsProviderID);
                //绑定省
                ControlTool.BindProvince(ProvinceCode);
                SVASessionInfo.LogisticsPriceController = null;
            }
            controller = SVASessionInfo.LogisticsPriceController;
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
                controller.LoadViewModel(Model.KeyID);
                if (controller.ViewModel.MainTable != null)
                {
                    //物流供应商
                    this.LogisticsProviderID.Text = DALTool.GetLogisticsProviderName(controller.ViewModel.MainTable.LogisticsProviderID, null);
                    //省编码
                    this.ProvinceCode.Text = DALTool.GetProviceName(controller.ViewModel.MainTable.ProvinceCode, null);
                    //起步价
                    this.StartPrice.Text = string.Format("{0:F}", controller.ViewModel.MainTable.StartPrice);
                    //起步重量
                    this.StartWeight.Text = string.Format("{0:F}", controller.ViewModel.MainTable.StartWeight);
                    //每公斤溢出价格
                    this.OverflowPricePerKG.Text = string.Format("{0:F}", controller.ViewModel.MainTable.OverflowPricePerKG);
                }
               
            }
        }

        //保存并Close
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (this.LogisticsProviderID.SelectedValue != "-1" && this.ProvinceCode.SelectedValue != "-1")
            {
                if (controller.ViewModel.MainTable != null)
                {

                    controller.ViewModel.MainTable.LogisticsProviderID = this.LogisticsProviderID.SelectedValue == "-1" ? 0 : Convert.ToInt32(this.LogisticsProviderID.SelectedValue);
                    controller.ViewModel.MainTable.ProvinceCode = this.ProvinceCode.SelectedValue == "-1" ? null : this.ProvinceCode.SelectedValue;
                    controller.ViewModel.MainTable.StartPrice = Convert.ToDecimal(this.StartPrice.Text);
                    controller.ViewModel.MainTable.StartWeight = Convert.ToDecimal(this.StartWeight.Text);
                    controller.ViewModel.MainTable.OverflowPricePerKG = Convert.ToDecimal(this.OverflowPricePerKG.Text);
                }

                ExecResult er = controller.Update();
                if (er.Success)
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update LogisticsPrice Success KeyID:" + controller.ViewModel.MainTable.KeyID.ToString());
                    CloseAndRefresh();
                }
                else
                {
                    Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update LogisticsPrice Failed KeyID:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.KeyID.ToString());
                }
            }
        }
    }
}