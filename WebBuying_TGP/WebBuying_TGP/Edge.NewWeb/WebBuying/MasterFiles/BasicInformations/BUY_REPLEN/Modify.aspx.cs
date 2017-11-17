using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_REPLEN_H, Edge.SVA.Model.BUY_REPLEN_H>
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
                if (controller.ViewModel.MainTable.TargetType == 1)//总部
                {

                    VendorID.Hidden = false;
                    FormStoreID.Hidden = true;
                    this.VendorID.SelectedItem.Text = DALTool.GetBuyingVendorNameByID(controller.ViewModel.MainTable.OrderTargetID.ToString(), null);
                }
                else  //0 供应商
                {
                    VendorID.Hidden = true;
                    FormStoreID.Hidden = false;
                    this.FormStoreID.SelectedItem.Text = DALTool.GetBuyingStoreNameByID(controller.ViewModel.MainTable.OrderTargetID.ToString(), null);
                }
                if (controller.ViewModel.MainTable.UseReplenFormula == 0)//总部
                {
                    ReplenFormulaID.Hidden = true;
                }
                else
                {
                    ReplenFormulaID.Hidden = false;
                    ReplenFormulaID.SelectedValue = controller.ViewModel.MainTable.ReplenFormulaID.ToString();
                }
                this.StartDate.Text = ConvertTool.ToStringDate(controller.ViewModel.MainTable.StartDate.GetValueOrDefault());
                this.EndDate.Text = ConvertTool.ToStringDate(controller.ViewModel.MainTable.EndDate.GetValueOrDefault());
                BindDetail(controller.ViewModel.DetailTable);
            }
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
            if (val == "0")
            {
                ReplenFormulaID.Hidden = true;
            }
            else
            {
                ReplenFormulaID.Hidden = false;
            }

        }

        #region 操作详情表
        protected void btnDetailAdd_Click(object sender, EventArgs e)
        {
            string replenCode = Request.Params["ReplenCode"];
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_REPLEN_D/Add.aspx?replenCode={0}&UseReplenFormula={1}", replenCode, UseReplenFormula.SelectedValue)));
        }
        protected void btnDeleteDetailItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.Grid1);
            controller.ViewModel.DetailTable = null;
        }

        protected void btnClearAllDetailItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.DetailTable != null)
            {
                DataTable addDT = controller.ViewModel.DetailTable;

                foreach (int row in Grid1.SelectedRowIndexArray)
                {
                    string EntityType = Grid1.DataKeys[row][0].ToString();
                    string EntityNum = Grid1.DataKeys[row][1].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["EntityType"].ToString().Trim() == EntityType && addDT.Rows[j]["EntityCode"].ToString().Trim() == EntityNum)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.DetailTable = addDT;
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

            this.btnDeleteDetailItem.Enabled = btnClearAllDetailItem.Enabled = Grid1.RecordCount > 0 ? true : false;
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            BindDetail(controller.ViewModel.DetailTable);
        }
        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindDetail(controller.ViewModel.DetailTable);
        }
        #endregion

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, "Update");
            controller.ViewModel.MainTable = this.GetUpdateObject();

            Edge.SVA.Model.BUY_REPLEN_H item = null;
            Edge.SVA.Model.BUY_REPLEN_H dataItem = this.GetDataObject();

            if (dataItem == null)
            {
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }


            if (dataItem != null)
            {
                if (dataItem.TargetType == 1)
                {
                    if (string.IsNullOrEmpty(VendorID.SelectedValue))
                    {
                        ShowWarning("请选择订货目标！");
                        return;
                    }
                    controller.ViewModel.MainTable.OrderTargetID = Convert.ToInt32(VendorID.SelectedValue);
                }
                else
                {
                    if (string.IsNullOrEmpty(FormStoreID.SelectedValue))
                    {
                        ShowWarning("请选择订货目标！");
                        return;
                    }
                    dataItem.OrderTargetID = Convert.ToInt32(FormStoreID.SelectedValue);
                }
               
            }


            item = this.GetPageObject(dataItem);
            if (item == null)
            {
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("BUY_REPLEN  Form  {0} No Data", item.ReplenCode));
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }

            item.UpdatedBy = DALTool.GetCurrentUser().UserID;
            item.UpdatedOn = DateTime.Now;
            if (Tools.DALTool.Update<Edge.SVA.BLL.BUY_REPLEN_H>(item))
            {
                Edge.SVA.BLL.BUY_REPLEN_D bll = new SVA.BLL.BUY_REPLEN_D();
                bll.Delete(this.ReplenCode.Text.Trim());
                
                try
                {
                    if (Grid1.RecordCount > 0)
                    {
                        DatabaseUtil.Factory.SetConnecctionString(DBUtility.PubConstant.ConnectionString);
                        DatabaseUtil.Interface.IDatabase database = DatabaseUtil.Factory.CreateIDatabase();
                        database.SetExecuteTimeout(6000);
                        System.Data.DataTable sourceTable = database.GetTableSchema("BUY_REPLEN_D");
                        DatabaseUtil.Interface.IExecStatus es = null;
                        foreach (System.Data.DataRow detail in controller.ViewModel.DetailTable.Rows)
                        {
                            System.Data.DataRow row = sourceTable.NewRow();
                            row["ReplenCode"] = item.ReplenCode;
                            row["EntityType"] = detail["EntityType"];
                            row["EntityCode"] = detail["EntityCode"];
                            row["MinStockQty"] = detail["MinStockQty"];
                            row["RunningStockQty"] = detail["RunningStockQty"];
                            row["OrderRoundUpQty"] = detail["OrderRoundUpQty"];
                            sourceTable.Rows.Add(row);
                        }
                        es = database.InsertBigData(sourceTable, "BUY_REPLEN_D");
                        if (es.Success)
                        {
                            sourceTable.Rows.Clear();
                        }
                        else
                        {
                            throw es.Ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteErrorLog(this.PageName, string.Format("BUY_REPLEN {0} Update Success But Detail Failed", item.ReplenCode), ex);
                    ShowAddFailed();
                    return;
                }
                Logger.Instance.WriteOperationLog(this.PageName, string.Format("BUY_REPLEN {0} Update Success", item.ReplenCode));
                CloseAndRefresh();
            }
        }
    }
}