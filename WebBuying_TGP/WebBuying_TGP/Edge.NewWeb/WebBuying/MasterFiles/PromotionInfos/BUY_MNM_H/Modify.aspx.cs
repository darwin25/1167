using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_MNM_H, Edge.SVA.Model.BUY_MNM_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingMnmController controller = new BuyingMnmController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);


                //对详情表的操作
                this.WindowSearch.Title = "Search";
                if (this.AddResultListGrid.RecordCount == 0)
                {
                    this.btnClearAllResultItem.Enabled = false;
                }
                else
                {
                    this.btnClearAllResultItem.Enabled = true;
                }

                InitData();
            }
            controller = SVASessionInfo.BuyingMnmController;
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
                controller.LoadViewModel(Model.MNMCode);


                if (controller.ViewModel.MainTable != null)
                {
                    this.StartTime.Text = controller.ViewModel.MainTable.StartDate.HasValue ? controller.ViewModel.MainTable.StartDate.Value.ToString("HH:mm") : string.Empty;
                    this.EndTime.Text = controller.ViewModel.MainTable.EndDate.HasValue ? controller.ViewModel.MainTable.EndDate.Value.ToString("HH:mm") : string.Empty;

                    controller.ViewModel.DayCode = controller.ViewModel.MainTable.DayFlagCode;
                    controller.ViewModel.WeekCode = controller.ViewModel.MainTable.WeekFlagCode;
                    controller.ViewModel.MonthCode = controller.ViewModel.MainTable.MonthFlagCode;
                }

                //下拉框取值
                if (this.StoreCode.SelectedValue != "-1")
                {
                    this.StoreGroupCode.Enabled = false;
                }
                else
                {
                    this.StoreGroupCode.Enabled = true;
                }
                if (this.StoreGroupCode.SelectedValue != "-1")
                {
                    this.StoreCode.Enabled = false;
                }
                else
                {
                    this.StoreCode.Enabled = true;
                }
                if (this.LoyaltyCardTypeCode.SelectedValue != "-1")
                {
                    controller.BindCardGrade(LoyaltyCardGradeCode, this.LoyaltyCardTypeCode.SelectedValue);
                }
                this.LoyaltyCardGradeCode.SelectedValue = controller.ViewModel.MainTable.LoyaltyCardGradeCode;

                //子表取值
                if (controller.ViewModel.SubTable != null)
                {
                    BindResultList(controller.ViewModel.SubTable);
                }
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Update ");

            controller.ViewModel.MainTable = this.GetUpdateObject();
            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;
                controller.ViewModel.MainTable.CreatedOn = System.DateTime.Now;
            }

            ExecResult er = controller.Update(); //controller.Update();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Promotion Success Code:" + controller.ViewModel.MainTable.MNMCode);
                CloseAndPostBack();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Update Promotion Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.MNMCode);
                ShowSaveFailed(er.Message);
            }
            
        }

        protected void StoreCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreCode.SelectedValue != "-1")
            {
                this.StoreGroupCode.Enabled = false;
            }
            else
            {
                this.StoreGroupCode.Enabled = true;
            }
        }

        protected void StoreGroupCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreGroupCode.SelectedValue != "-1")
            {
                this.StoreCode.Enabled = false;
            }
            else
            {
                this.StoreCode.Enabled = true;
            }
        }

        protected void LoyaltyCardTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LoyaltyCardTypeCode.SelectedValue != "-1")
            {
                controller.BindCardGrade(LoyaltyCardGradeCode, this.LoyaltyCardTypeCode.SelectedValue);
            }
        }

        #region 操作详情表
        protected void btnViewSearch_Click(object sender, EventArgs e)
        {
            ExecuteJS(WindowSearch.GetShowReference(string.Format("BUY_MNM_D/Add.aspx?MNMCode={0}", this.MNMCode.Text)));
        }

        protected void btnClearAllResultItem_Click(object sender, EventArgs e)
        {
            ClearGird(this.AddResultListGrid);
            controller.ViewModel.SubTable = null;
        }
        protected void btnDeleteResultItem_Click(object sender, EventArgs e)
        {
            if (controller.ViewModel.SubTable != null)
            {
                DataTable addDT = controller.ViewModel.SubTable;

                foreach (int row in AddResultListGrid.SelectedRowIndexArray)
                {
                    string KeyID = AddResultListGrid.DataKeys[row][0].ToString();
                    for (int j = addDT.Rows.Count - 1; j >= 0; j--)
                    {
                        if (addDT.Rows[j]["KeyID"].ToString().Trim() == KeyID)
                        {
                            addDT.Rows.Remove(addDT.Rows[j]);
                        }
                    }
                    addDT.AcceptChanges();
                }

                controller.ViewModel.SubTable = addDT;

                BindResultList(controller.ViewModel.SubTable);

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

            BindResultList(controller.ViewModel.SubTable);
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            BindResultList(controller.ViewModel.SubTable);
        }

        protected void Window1Edit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            this.DayFlagCode.Text = controller.ViewModel.DayCode;
            this.MonthFlagCode.Text = controller.ViewModel.MonthCode;
            this.WeekFlagCode.Text = controller.ViewModel.WeekCode;
        }

        #endregion

        protected void InitData()
        {
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
            controller.BindCardType(LoyaltyCardTypeCode);
        }

        protected void btnAddDay_Click(object sender, EventArgs e)
        {
            ExecuteJS(Window1.GetShowReference("BUY_DAYFLAG/List.aspx"));
        }

        protected void btnAddWeek_Click(object sender, EventArgs e)
        {
            ExecuteJS(Window1.GetShowReference("BUY_WEEKFLAG/List.aspx"));
        }

        protected void btnAddMonth_Click(object sender, EventArgs e)
        {
            ExecuteJS(Window1.GetShowReference("BUY_MONTHFLAG/List.aspx"));
        }

    }
}