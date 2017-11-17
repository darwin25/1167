using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PromotionInfos.Promotion;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Promotion_Member
{
    public partial class Modify : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_Member, PromotionMemberViewModel>
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
                controller.BindCardType(this.LoyaltyCardTypeID);
                InitData();

            }
            controller = SVASessionInfo.BuyingNewPromotionController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            PromotionMemberViewModel item = this.GetUpdateObject();
            if (item != null)
            {
                item.OprFlag = "Update";
                item.KeyID = Convert.ToInt32(Request.Params["id"]);
                item.LoyaltyCardTypeName = this.LoyaltyCardTypeID.SelectedText;
                item.LoyaltyCardGradeName = this.LoyaltyCardGradeID.SelectedText;
                item.LoyaltyBirthdayFlagName = this.LoyaltyBirthdayFlag.SelectedText;
                controller.UpdatePromotionMemberViewModel(SVASessionInfo.SiteLanguage, item);
                CloseAndPostBack();
            }
            else
            {
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }
        }

        protected void InitData()
        {
            this.PromotionCode.Text = Request.Params["PromotionCode"].ToString();
        }

        protected void LoyaltyCardTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LoyaltyCardTypeID.SelectedValue != "-1")
            {
                controller.BindCardGrade(this.LoyaltyCardGradeID, this.LoyaltyCardTypeID.SelectedValue);
            }
        }

        protected override void SetObject()
        {
            int id = Convert.ToInt32(Request.Params["id"]);
            if (id == 0) return;

            PromotionMemberViewModel mmm = controller.ViewModel.PromotionMemberList.Find(mm => mm.KeyID.Equals(id));
            if (mmm != null)
            {
                this.SetObject(mmm, this.Form.Controls.GetEnumerator());
                //this.LoyaltyCardTypeID.SelectedValue = mmm.LoyaltyCardTypeID.ToString();
                if (this.LoyaltyCardTypeID.SelectedValue != "-1")
                {
                    controller.BindCardGrade(LoyaltyCardGradeID, this.LoyaltyCardTypeID.SelectedValue);
                }
                this.LoyaltyCardGradeID.SelectedValue = mmm.LoyaltyCardGradeID.ToString();
                //this.LoyaltyThreshold.Text = mmm.LoyaltyThreshold.ToString();
                //this.LoyaltyBirthdayFlag.SelectedValue = mmm.LoyaltyBirthdayFlag.ToString();
            }


        }
    }
}