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
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_BANK, Edge.SVA.Model.BUY_BANK>
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

                InitData();

                SVASessionInfo.BuyingBankController = null;
            }
            controller = SVASessionInfo.BuyingBankController;
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

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Bank Success Code:" + controller.ViewModel.MainTable.BankCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Bank Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.BankCode);
                //ShowAddFailed();
                ShowSaveFailed(er.Message);
            }

        }

        protected void InitData()
        {
            //if (webset.IsConvertToUpper)
            //{
            //    foreach (var item in this.SimpleForm1.Controls)
            //    {
            //        if (item is FineUI.TextBox)
            //        {
            //            FineUI.TextBox tx = item as FineUI.TextBox;
            //            FindControl(tx.ID);
            //            ExecuteJS(tx.ClientID + "OnTextChanged='ConvertTextboxToUpperText'");
            //            //tx.Text = tx.Text.ToUpper();
            //            tx.AutoPostBack = true;
            //        }
            //    }
            //}
        }
    }
}