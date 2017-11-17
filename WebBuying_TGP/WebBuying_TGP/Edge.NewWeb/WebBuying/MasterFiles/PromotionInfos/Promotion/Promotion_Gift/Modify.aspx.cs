using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using Edge.Web.Tools;
using System.Data;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Promotion_Gift
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_Gift, PromotionGiftViewModel>
    {
        BuyingNewPromotionController controller = new BuyingNewPromotionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(this.btnClose);

                InitData();

            }
            controller = SVASessionInfo.BuyingNewPromotionController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Logger.Instance.WriteOperationLog(this.PageName, " Update ");
            try
            {

                PromotionGiftViewModel item = this.GetUpdateObject();
                if (item != null)
                {
                    item.GiftSeq = ConvertTool.ToInt(Request.Params["id"]);
                    item.OprFlag = this.OprFlag.Text;
                    item.LogicalOprName = DALTool.GetLogicalOprName(this.GiftLogicalOpr.SelectedValue);
                    item.GiftTypeName = this.PromotionGiftType.SelectedText;
                    item.GiftItemName = this.PromotionGiftItem.SelectedText;
                    item.DiscountTypeName = this.PromotionDiscountType.SelectedText;
                    item.DiscountOnName = this.PromotionDiscountOn.SelectedText;
                    item.GiftPluTable = controller.ViewModel.GiftPluTable;
                    controller.UpdatePromotionGiftViewModel(SVASessionInfo.SiteLanguage, item);
                    CloseAndPostBack();
                }
                else
                {
                    ShowError(Resources.MessageTips.UnKnownSystemError);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteErrorLog("Update Promotion Gift", "Failed", ex);
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }
        }

        protected void InitData()
        {
            this.PromotionCode.Text = Request.Params["promotioncode"].ToString();
            this.GiftSeq.Text = Request.Params["id"].ToString();
        }

        protected override void SetObject()
        {
            int id = ConvertTool.ToInt(Request.Params["id"]);
            if (id == 0) return;
            PromotionGiftViewModel mmm = controller.ViewModel.PromotionGiftList.Find(mm => mm.GiftSeq.Equals(id));
            if (mmm != null)
            {
                this.SetObject(mmm, this.Form.Controls.GetEnumerator());
                if (mmm.OprFlag == "Add")
                {
                    this.OprFlag.Text = "Add";
                }
                else
                {
                    this.OprFlag.Text = "Update";
                }
                controller.ViewModel.GiftPluTable = mmm.GiftPluTable;
                BindGiftPLUList(mmm.GiftPluTable);
            }       
        }

        #region 操作PLU表
        private void BindGiftPLUList(DataTable dt)
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
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            BindGiftPLUList(controller.ViewModel.GiftPluTable);
        }
        #endregion
    }
}