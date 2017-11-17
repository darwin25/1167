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

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Promotion_Hit
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_Hit, PromotionHitViewModel>
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

                PromotionHitViewModel item = this.GetUpdateObject();
                if (item != null)
                {
                    item.HitSeq = ConvertTool.ToInt(Request.Params["id"]);
                    item.OprFlag = this.OprFlag.Text;
                    item.HitOPName = this.HitOP.SelectedText;
                    item.LogicalOprName = DALTool.GetLogicalOprName(this.HitLogicalOpr.SelectedValue);
                    item.HitTypeName = this.HitType.SelectedText;
                    item.HitItemName = this.HitItem.SelectedText;
                    item.HitPluTable = controller.ViewModel.HitPluTable;
                    controller.UpdatePromotionHitViewModel(SVASessionInfo.SiteLanguage, item);
                    CloseAndPostBack();
                }
                else
                {
                    ShowError(Resources.MessageTips.UnKnownSystemError);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteErrorLog("Update Promotion Hit", "Failed", ex);
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }
        }

        protected void InitData()
        {
            this.PromotionCode.Text = Request.Params["promotioncode"].ToString();
            this.HitSeq.Text = Request.Params["id"].ToString();
        }

        protected override void SetObject()
        {
            int id = ConvertTool.ToInt(Request.Params["id"]);
            if (id == 0) return;
            PromotionHitViewModel mmm = controller.ViewModel.PromotionHitList.Find(mm => mm.HitSeq.Equals(id));
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
                controller.ViewModel.HitPluTable = mmm.HitPluTable;
                BindHitPLUList(mmm.HitPluTable);
            }         
        }

        #region 操作PLU表
        private void BindHitPLUList(DataTable dt)
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

            BindHitPLUList(controller.ViewModel.HitPluTable);
        }
        #endregion
    }
}