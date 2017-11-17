using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_PROMO_H, Edge.SVA.Model.BUY_PROMO_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingPromotionController controller = new BuyingPromotionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingPromotionController = null;

                InitData();
            }
            controller = SVASessionInfo.BuyingPromotionController;
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
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Promotion Success Code:" + controller.ViewModel.MainTable.PromotionCode);
                CloseAndRefresh();
            }
            else
            {
                Tools.Logger.Instance.WriteOperationLog(this.PageName, "Add Promotion Failed Code:" + controller.ViewModel.MainTable == null ? "No Data" : controller.ViewModel.MainTable.PromotionCode);
                ShowSaveFailed(er.Message);
            }

        }

        protected void InitData()
        {
            this.PromotionCode.Text = DALTool.GetREFNOCode("PPC");
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
            controller.BindCardType(CardTypeCode);
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

        protected void CardTypeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CardTypeCode.SelectedValue != "-1")
            {
                controller.BindCardGrade(CardGradeCode, this.CardTypeCode.SelectedValue);
            }
        }

        protected void MemberPromotionFlag_SelectChanged(object sender, EventArgs e)
        {
            if (this.MemberPromotionFlag.SelectedValue == "0")
            {
                this.CardTypeCode.Enabled = this.CardGradeCode.Enabled = this.BirthdayFlag.Enabled = false;
            }
            else
            {
                this.CardTypeCode.Enabled = this.CardGradeCode.Enabled = this.BirthdayFlag.Enabled = true;
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