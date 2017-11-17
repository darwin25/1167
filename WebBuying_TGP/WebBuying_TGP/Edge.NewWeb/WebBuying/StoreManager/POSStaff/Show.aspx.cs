using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.POSStaff;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.StoreManager.POSStaff
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.POSSTAFF, Edge.SVA.Model.POSSTAFF>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        POSStaffController controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);
                SVASessionInfo.POSStaffController = null;
            }
            controller = SVASessionInfo.POSStaffController;
        }
        protected override void OnLoadComplete(EventArgs e)
        {
            string stafflevel;
            base.OnLoadComplete(e);
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.LoadViewModel(Model.StaffID);

                controller.LoadStoreListByStaffID(Model.StaffID);

                if (controller.ViewModel.StoreTable != null)
                {
                    BindResultList(controller.ViewModel.StoreTable);
                }
                stafflevel = Convert.ToString(int.Parse(Model.StaffLevel.ToString()), 2);
                stafflevel = stafflevel.PadLeft(3);
                if (stafflevel.ToString().Substring(2, 1) == "1") { Cashier.Checked = true; }
                else { Cashier.Checked = false; }
                if (stafflevel.ToString().Substring(1, 1) == "1") { Sales.Checked = true; }
                else { Sales.Checked = false; }
                if (stafflevel.ToString().Substring(0, 1) == "1") { Supervisor.Checked = true; }
                else { Supervisor.Checked = false; }
            }
        }

        private void BindResultList(DataTable dt)
        {
            if (dt != null)
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.RecordCount = dt.Rows.Count;
                DataTable viewDT = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.AddResultListGrid.PageIndex + 1, this.AddResultListGrid.PageSize);
                this.AddResultListGrid.DataSource = viewDT;
                this.AddResultListGrid.DataBind();

            }
            else
            {
                this.AddResultListGrid.PageSize = webset.ContentPageNum;
                this.AddResultListGrid.PageIndex = 0;
                this.AddResultListGrid.RecordCount = 0;
                this.AddResultListGrid.DataSource = null;
                this.AddResultListGrid.DataBind();
            }
        }

        protected void AddResultListGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;

            BindResultList(controller.ViewModel.StoreTable);
        }
    }
}