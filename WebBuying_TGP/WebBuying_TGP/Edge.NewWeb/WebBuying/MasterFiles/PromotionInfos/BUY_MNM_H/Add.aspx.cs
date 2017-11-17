using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_MNM_H, Edge.SVA.Model.BUY_MNM_H>
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

                SVASessionInfo.BuyingMnmController = null;

                InitData();
            }
            controller = SVASessionInfo.BuyingMnmController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            logger.WriteOperationLog(this.PageName, " Add ");

            controller.ViewModel.MainTable = this.GetAddObject();

            if (controller.ViewModel.MainTable != null)
            {
                controller.ViewModel.MainTable.CreatedBusDate = DateTime.Now;
                controller.ViewModel.MainTable.ApproveStatus = "P";
                controller.ViewModel.MainTable.CreatedOn = DateTime.Now;
                controller.ViewModel.MainTable.CreatedBy = Edge.Web.Tools.DALTool.GetCurrentUser().UserID;

                controller.ViewModel.MainTable.StoreCode = this.StoreCode.SelectedValue == "-1" ? null : this.StoreCode.SelectedValue;
                controller.ViewModel.MainTable.StoreGroupCode = this.StoreGroupCode.SelectedValue == "-1" ? null : this.StoreGroupCode.SelectedValue;

                controller.ViewModel.MainTable.StartDate = Edge.Utils.Tools.ConvertTool.GetInstance().ConverNullable<DateTime>(this.StartDate.Text + " " + this.StartTime.Text);
                controller.ViewModel.MainTable.EndDate = Edge.Utils.Tools.ConvertTool.GetInstance().ConverNullable<DateTime>(this.EndDate.Text + " " + this.EndTime.Text);
            }

            ExecResult er = controller.Add();
            if (er.Success)
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Promotion Success Code:" + controller.ViewModel.MainTable.MNMCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Promotion Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.MNMCode);
                ShowSaveFailed(er.Message);
            }

        }

        protected void InitData()
        {
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
            controller.BindCardType(LoyaltyCardTypeCode);
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

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            this.DayFlagCode.Text = controller.ViewModel.DayCode;
            this.MonthFlagCode.Text = controller.ViewModel.MonthCode;
            this.WeekFlagCode.Text = controller.ViewModel.WeekCode;
        }
    }
}