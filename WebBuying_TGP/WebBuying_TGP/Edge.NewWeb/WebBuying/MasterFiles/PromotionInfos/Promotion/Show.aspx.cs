using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion
{
    public partial class Show : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_H, Edge.SVA.Model.Promotion_H>
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
                InitData();
                SVASessionInfo.BuyingNewPromotionController = null;
            }
            controller = SVASessionInfo.BuyingNewPromotionController;
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
                controller.LoadViewModel(Model.PromotionCode);

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


                this.StoreIDView.Text = this.StoreID.SelectedText;
                this.StoreGroupIDView.Text = this.StoreGroupID.SelectedText;
                this.LoyaltyFlagView.Text = this.LoyaltyFlag.SelectedItem == null ? "" : this.LoyaltyFlag.SelectedItem.Text;

                if (controller.ViewModel.PromotionHitList != null)
                {
                    BindHitList(controller.ViewModel.PromotionHitList);
                }
                if (controller.ViewModel.PromotionGiftList != null)
                {
                    BindGiftList(controller.ViewModel.PromotionGiftList);
                }
                if (controller.ViewModel.PromotionMemberList != null)
                {
                    BindMemberList(controller.ViewModel.PromotionMemberList);
                }
            }
        }

        private void BindHitList(List<PromotionHitViewModel> list)
        {
            this.Grid1.RecordCount = list.Count;
            this.Grid1.DataSource = list;
            this.Grid1.DataBind();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            BindHitList(controller.ViewModel.PromotionHitList);
        }

        private void BindGiftList(List<PromotionGiftViewModel> list)
        {
            this.Grid2.RecordCount = list.Count;
            this.Grid2.DataSource = list;
            this.Grid2.DataBind();
        }

        protected void Grid2_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid2.PageIndex = e.NewPageIndex;

            BindGiftList(controller.ViewModel.PromotionGiftList);
        }

        private void BindMemberList(List<PromotionMemberViewModel> list)
        {
            this.Grid3.RecordCount = list.Count;
            this.Grid3.DataSource = list;
            this.Grid3.DataBind();
        }

        protected void Grid3_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid3.PageIndex = e.NewPageIndex;

            BindMemberList(controller.ViewModel.PromotionMemberList);
        }

        protected void InitData()
        {
            controller.BindStore(StoreID);
            controller.BindStoreGroup(StoreGroupID);
        }
    }
}