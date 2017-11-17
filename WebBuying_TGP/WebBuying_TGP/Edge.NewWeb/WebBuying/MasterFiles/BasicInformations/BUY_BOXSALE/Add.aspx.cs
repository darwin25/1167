using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BOXSALE, Edge.SVA.Model.BUY_BOXSALE>
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

                InitData();
                btnSelect.OnClientClick = Window2.GetShowReference("../../ComplexInformations/BUY_PRODUCT/List.aspx?picker=true&ProdCode=" + Request.Params["BOMCode"], "Select");
            }
            controller = SVASessionInfo.BuyingBoxSaleController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
            }
            
            if (!ValidateData()) return;

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BoxSale Success Code:" + controller.ViewModel.MainTable.ProdCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BoxSale Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ProdCode);
                ShowAddFailed();
            }

        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);

            this.ProdCode.Text = Tools.SVASessionInfo.BuyingProdCode;
            this.txtDesc.Text = Tools.SVASessionInfo.BuyingProdDesc;

            Tools.SVASessionInfo.BuyingProdCode = null;
            Tools.SVASessionInfo.BuyingProdDesc = null;
        }

        protected void InitData()
        {
            if (Request.Params["BOMCode"] != null)
            {
                this.BOMCode.Text = Request.Params["BOMCode"];
            }
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