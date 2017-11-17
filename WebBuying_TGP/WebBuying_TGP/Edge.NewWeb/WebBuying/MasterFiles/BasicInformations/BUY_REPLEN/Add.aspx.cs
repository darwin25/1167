using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_REPLEN_H, Edge.SVA.Model.BUY_REPLEN_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BUY_REPLENController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                VendorID.Hidden = false;
                ReplenFormulaID.Hidden = true;
                ControlTool.BindStoreWithType2(StoreID, 1);
                ControlTool.BindStoreWithType2(FormStoreID, 9);
                ControlTool.BindAllSupplier(VendorID);
                ControlTool.BindREPLENFORMULA(ReplenFormulaID);
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BUY_REPLENController = null;
            }
            controller = SVASessionInfo.BUY_REPLENController;
        }
        protected void TargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = this.TargetType.SelectedValue;
            if (val == "1")//总部
            {
                VendorID.Hidden = false;
                FormStoreID.Hidden = true;
            }
            else  //0 供应商
            {
                FormStoreID.Hidden = false;
                VendorID.Hidden = true;
            }
        }

        protected void UseReplenFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = this.UseReplenFormula.SelectedValue;
            if (val =="0")
            {
                ReplenFormulaID.Hidden = true;
            }
            else
            {
                ReplenFormulaID.Hidden = false;
            }
            
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, "Add");
            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                if (TargetType.SelectedValue == "1")
                {
                    if (string.IsNullOrEmpty(VendorID.SelectedValue))
                    {
                        ShowWarning("请选择订货目标。");
                        return;
                    }
                    controller.ViewModel.MainTable.OrderTargetID = Convert.ToInt32(VendorID.SelectedValue);
                }
                else
                {
                    if (string.IsNullOrEmpty(FormStoreID.SelectedValue))
                    {
                        ShowWarning("请选择订货目标。");
                        return;
                    }
                    controller.ViewModel.MainTable.OrderTargetID = Convert.ToInt32(FormStoreID.SelectedValue);
                }
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
            }
            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BUY_REPLEN Success Code:" + controller.ViewModel.MainTable.ReplenCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add BUY_REPLEN Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.ReplenCode);
                ShowSaveFailed(er.Message);
            }
        }
    }
}