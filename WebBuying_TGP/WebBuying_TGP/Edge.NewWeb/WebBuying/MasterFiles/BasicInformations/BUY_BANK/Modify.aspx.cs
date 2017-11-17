using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BANK;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BANK
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BANK, Edge.SVA.Model.BUY_BANK>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingBankController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BuyingBankController = null;
            }
            controller = SVASessionInfo.BuyingBankController;
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
                controller.LoadViewModel(Model.BankID);
            }
        }
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");
            int page = 0;
            int.TryParse(Request.Params["page"], out page);

            controller.ViewModel.MainTable = this.GetUpdateObject();

            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.UpdatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.UpdatedOn = System.DateTime.Now;
            }

            ExecResult er = controller.Update();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Bank Update\t Code:" + controller.ViewModel.MainTable.BankCode.ToString());
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Bank Update\t Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.BankCode);
                ShowSaveFailed(er.Message);
            }
        }
    }
}
