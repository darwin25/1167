using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using System.Data;
using System.IO;
namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE
{
    /// <summary>
    /// 修改捆绑货品
    /// 创建人：王丽
    /// 创建时间：2015-11-19
    /// </summary>
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BOXSALE, Edge.SVA.Model.BUY_BOXSALE>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBoxSaleController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingBoxSaleController = null;
            }
            controller = SVASessionInfo.BuyingBoxSaleController;
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
                controller.LoadViewModel(Model.BOMID);
            }
        }

        //修改
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;
            }
            if (!ValidateData()) return;
            ExecResult er = controller.Update();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Vendor Success Code:" + controller.ViewModel.MainTable.BOMCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Vendor Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.BOMCode);
                ShowUpdateFailed();
            }
           

        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);

            this.ProdCode.Text = Tools.SVASessionInfo.BuyingProdCode;

            Tools.SVASessionInfo.BuyingProdCode = null;
            Tools.SVASessionInfo.BuyingProdDesc = null;
        }

        protected bool ValidateData()
        {
            int defaultqty = ConvertTool.ToInt(this.DefaultQty.Text);
            int maxqty = ConvertTool.ToInt(this.MaxQty.Text);
            int minqty = ConvertTool.ToInt(this.MinQty.Text);
            if (defaultqty < minqty || defaultqty > maxqty)
            {
                ShowWarning(Resources.MessageTips.SetDefaultQty);
                return false;
            }
            return true;
        }
    }
}