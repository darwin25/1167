using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion
{
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_H, Edge.SVA.Model.Promotion_H>
    {
        Tools.Logger logger = Tools.Logger.Instance;
        BuyingNewPromotionController controller = new BuyingNewPromotionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(btnClose);

                SVASessionInfo.BuyingNewPromotionController = null;

                InitData();
            }
            controller = SVASessionInfo.BuyingNewPromotionController;
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

                controller.ViewModel.MainTable.StoreID = this.StoreID.SelectedValue == "-1" ? 0 : ConvertTool.ToInt(this.StoreID.SelectedValue);
                controller.ViewModel.MainTable.StoreGroupID = this.StoreGroupID.SelectedValue == "-1" ? 0 : ConvertTool.ToInt(this.StoreGroupID.SelectedValue);

                controller.ViewModel.MainTable.StartDate = Edge.Utils.Tools.ConvertTool.GetInstance().ConverNullable<DateTime>(this.StartDate.Text + " " + this.StartTime.Text);
                controller.ViewModel.MainTable.EndDate = Edge.Utils.Tools.ConvertTool.GetInstance().ConverNullable<DateTime>(this.EndDate.Text + " " + this.EndTime.Text);
            }

            if (controller.ViewModel.MainTable.StartDate > controller.ViewModel.MainTable.EndDate)
            {
                ShowWarning("失效日期不能大于生效日期!");
                return;
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
            this.PromotionCode.Text = DALTool.GetREFNOCode("PROM");
            controller.BindStore(StoreID);
            controller.BindStoreGroup(StoreGroupID);
            //controller.BindCardType(LoyaltyCardTypeID);

            //this.LoyaltyCardTypeID.Enabled = false;
            //this.LoyaltyCardGradeID.Enabled = false;
            //this.LoyaltyThreshold.Enabled = false;
        }

        protected void StoreID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreID.SelectedValue != "-1")
            {
                this.StoreGroupID.Enabled = false;
            }
            else
            {
                this.StoreGroupID.Enabled = true;
            }
        }

        protected void StoreGroupID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.StoreGroupID.SelectedValue != "-1")
            {
                this.StoreID.Enabled = false;
            }
            else
            {
                this.StoreID.Enabled = true;
            }
        }

        //protected void LoyaltyCardTypeID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.LoyaltyCardTypeID.SelectedValue != "-1")
        //    {
        //        controller.BindCardGrade(LoyaltyCardGradeID, this.LoyaltyCardTypeID.SelectedValue);
        //    }
        //}

        protected void LoyaltyFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.LoyaltyFlag.SelectedValue == "1")
            //{
            //    this.LoyaltyCardTypeID.Enabled = true;
            //    this.LoyaltyCardGradeID.Enabled = true;
            //    this.LoyaltyThreshold.Enabled = true;
            //}
            //else
            //{
            //    this.LoyaltyCardTypeID.Enabled = false;
            //    this.LoyaltyCardGradeID.Enabled = false;
            //    this.LoyaltyThreshold.Enabled = false;
            //}
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

        protected bool ValidateData()
        {
            //DateTime startdate = Convert.ToDateTime(this.StartDate.Text);
            //DateTime enddate = Convert.ToDateTime(this.StartDate.Text);
            //if (startdate > enddate)
            //{
            //    ShowWarning("失效日期不能大于生效日期!");
            //    return false;
            //}
            return true;
        }
    }
}