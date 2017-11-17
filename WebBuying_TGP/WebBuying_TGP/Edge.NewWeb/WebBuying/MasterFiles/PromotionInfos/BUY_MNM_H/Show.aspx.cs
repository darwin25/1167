using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.BUY_MNM_H, Edge.SVA.Model.BUY_MNM_H>
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
                InitData();
                SVASessionInfo.BuyingMnmController = null;
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
                    this.UpdatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.UpdatedBy.GetValueOrDefault());
                    this.CreatedBy.Text = DALTool.GetUserName(controller.ViewModel.MainTable.CreatedBy.GetValueOrDefault());

                    this.CreatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.CreatedOn);
                    this.UpdatedOn.Text = Edge.Utils.Tools.StringHelper.GetDateTimeString(controller.ViewModel.MainTable.UpdatedOn);

                    ApproveBy.Text = Edge.Web.Tools.DALTool.GetUserName(controller.ViewModel.MainTable.ApproveBy.GetValueOrDefault());
                    ApproveOn.Text = Edge.Web.Tools.ConvertTool.ToStringDateTime(controller.ViewModel.MainTable.ApproveOn.GetValueOrDefault());
                    this.ApproveStatus.Text = Edge.Web.Tools.DALTool.GetApproveStatusString(controller.ViewModel.MainTable.ApproveStatus);
                }


                this.StoreCodeView.Text = this.StoreCode.SelectedText;
                this.StoreGroupCodeView.Text = this.StoreGroupCode.SelectedText;
                this.MNMTypeView.Text = this.MNMType.SelectedText;
                this.LoyaltyOnlyView.Text = this.LoyaltyOnly.SelectedItem == null ? "" : this.LoyaltyOnly.SelectedItem.Text;
                this.HitTypeView.Text = this.HitType.SelectedText;
                this.HitOPView.Text = this.HitOP.SelectedText;
                this.GiftTypeView.Text = this.GiftType.SelectedText;
                this.PromotionTypeView.Text = this.PromotionType.SelectedText;
                this.PromotionOnView.Text = this.PromotionOn.SelectedText;
                this.AmountTypeView.Text = this.AmountType.SelectedItem == null ? "" : this.AmountType.SelectedItem.Text;


                if (controller.ViewModel.SubTable != null)
                {
                    BindResultList(controller.ViewModel.SubTable);
                }
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

            BindResultList(controller.ViewModel.SubTable);
        }

        protected void InitData()
        {
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
        }
    }
}