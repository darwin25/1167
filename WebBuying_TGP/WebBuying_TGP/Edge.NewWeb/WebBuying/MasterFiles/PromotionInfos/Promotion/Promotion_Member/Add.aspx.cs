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
    public partial class Add : Edge.Web.Tools.BasePage<Edge.SVA.BLL.Promotion_Member, PromotionMemberViewModel>
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
            PromotionMemberViewModel item = this.GetAddObject();
            if (item != null)
            {
                item.OprFlag = "Add";
                item.LoyaltyCardTypeName = this.LoyaltyCardTypeID.SelectedText;
                item.LoyaltyCardGradeName = this.LoyaltyCardGradeID.SelectedText;
                item.LoyaltyBirthdayFlagName = this.LoyaltyBirthdayFlag.SelectedText;
                if (!controller.ValidateMemberIsExists(item))
                {
                    controller.AddPromotionMemberViewModel(SVASessionInfo.SiteLanguage, item);
                    CloseAndPostBack();
                }
                else
                {
                    ShowError("Data Duplicated");
                }
            }
            else
            {
                ShowError(Resources.MessageTips.UnKnownSystemError);
            }
        }

        protected void InitData()
        {
            this.PromotionCode.Text = Request.Params["PromotionCode"].ToString();
            controller.BindCardType(this.LoyaltyCardTypeID);
        }

        protected void LoyaltyCardTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LoyaltyCardTypeID.SelectedValue != "-1")
            {
                controller.BindCardGrade(this.LoyaltyCardGradeID, this.LoyaltyCardTypeID.SelectedValue);
            }
        }
    }
}