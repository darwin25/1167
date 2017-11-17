using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_REPLEN_H, Edge.SVA.Model.BUY_REPLEN_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BUY_REPLENController controller;
        Edge.SVA.BLL.BUY_REPLENFORMULA REPLENFORMULABLL = new SVA.BLL.BUY_REPLENFORMULA(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.BUY_REPLENController = null;

            }
            controller = SVASessionInfo.BUY_REPLENController;
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
                controller.LoadViewModel(Request.Params["id"]);
                if (controller.ViewModel.MainTable.UseReplenFormula == 0)
                {
                    this.UseReplenFormula.Text = "Do not use";
                    ReplenFormulaID.Hidden = true;
                }
                else
                {
                    this.UseReplenFormula.Text = "Use";
                    ReplenFormulaID.Hidden = false;
                    Edge.SVA.Model.BUY_REPLENFORMULA  BUY_REPLENFORMULA= REPLENFORMULABLL.GetModel(Convert.ToInt32(controller.ViewModel.MainTable.ReplenFormulaID));
                    if (BUY_REPLENFORMULA != null)
                    {
                        ReplenFormulaID.Text = BUY_REPLENFORMULA.ReplenFormulaCode;
                    }
                }
                this.StoreID.Text = DALTool.GetBuyingStoreNameByID(controller.ViewModel.MainTable.StoreID.ToString(), null);

                if (controller.ViewModel.MainTable.TargetType == 1)//总部
                {
                 
                    this.TargetType.Text = "HQ";
                    VendorID.Hidden = false;
                    FormStoreID.Hidden = true;
                    this.VendorID.Text = DALTool.GetBuyingVendorNameByID(controller.ViewModel.MainTable.OrderTargetID.ToString(), null);
                }
                else  //0 供应商
                {
                    this.TargetType.Text = "Supplier";
                    VendorID.Hidden = true;
                    FormStoreID.Hidden = false;
                    this.FormStoreID.Text =DALTool.GetBuyingStoreNameByID(controller.ViewModel.MainTable.OrderTargetID.ToString(), null);
                }
                if (controller.ViewModel.MainTable.Status == 0)
                {
                    this.Status.Text = "Invalid";
                }
                else
                {
                    this.Status.Text = "Valid";
                }
                this.CreateStartDate.Text = ConvertTool.ToStringDate(controller.ViewModel.MainTable.StartDate.GetValueOrDefault());
                this.CreateEndDate.Text = ConvertTool.ToStringDate(controller.ViewModel.MainTable.EndDate.GetValueOrDefault());
                BindDetail(controller.ViewModel.DetailTable);
            }
        }

        private void BindDetail(DataTable dt)
        {
            if (dt != null)
            {

                this.Grid1.PageSize = webset.ContentPageNum;
                this.Grid1.RecordCount = dt.Rows.Count;

                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.Grid1.PageIndex + 1, this.Grid1.PageSize);
                this.Grid1.DataSource = viewDT;
                this.Grid1.DataBind();

            }
            else
            {
                this.Grid1.PageSize = webset.ContentPageNum;
                this.Grid1.PageIndex = 0;
                this.Grid1.RecordCount = 0;
                this.Grid1.DataSource = null;
                this.Grid1.DataBind();
            }
        }
    }
}