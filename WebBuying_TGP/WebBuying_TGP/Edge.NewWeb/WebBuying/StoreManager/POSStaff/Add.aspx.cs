using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.POSStaff;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.WebBuying.StoreManager.POSStaff
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.POSSTAFF, Edge.SVA.Model.POSSTAFF>
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

                //对Store的操作
                this.WindowSearch.Title = "Search";
                if (this.AddResultListGrid.RecordCount == 0)
                {
                    this.btnClearAllResultItem.Enabled = false;
                }
                else
                {
                    this.btnClearAllResultItem.Enabled = true;
                }
            }
            controller = SVASessionInfo.POSStaffController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string stafflevel="";
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
                if (Cashier.Checked) {stafflevel="1";}
                else {stafflevel="0";}
                if (Sales.Checked) {stafflevel="1"+stafflevel;}
                else {stafflevel="0"+stafflevel;}
                if (Supervisor.Checked) {stafflevel="1"+stafflevel;}
                else {stafflevel="0"+stafflevel;}
                controller.ViewModel.MainTable.StaffLevel = Convert.ToInt32(stafflevel, 2);
                controller.ViewModel.MainTable.StaffPWD = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(this.StaffPWD.Text, "md5");
            }

            ExecResult er = controller.AddData(); //controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add POSStaff Success Code:" + controller.ViewModel.MainTable.StaffCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add POSStaff Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.StaffCode);
                ShowSaveFailed(er.Message);
            }

        }
        

        #region 操作Store
        protected void btnViewSearch_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference("Store/Add.aspx"));
        }

        protected void btnClearAllResultItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid);
        }
        protected void btnDeleteResultItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.StoreTable != null)
            {
                DataTable addDT = controller.ViewModel.StoreTable;

                foreach (int row in AddResultListGrid.SelectedRowIndexArray)
                {
                    string storecode = AddResultListGrid.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["StoreCode"].ToString().Trim() == storecode)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.StoreTable = addDT;
                BindResultList(controller.ViewModel.StoreTable);

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

            this.btnDeleteResultItem.Enabled = btnClearAllResultItem.Enabled = AddResultListGrid.RecordCount > 0 ? true : false;
        }

        protected void AddResultListGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            AddResultListGrid.PageIndex = e.NewPageIndex;

            BindResultList(controller.ViewModel.StoreTable);
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindResultList(controller.ViewModel.StoreTable);
        }
        #endregion
    }
}