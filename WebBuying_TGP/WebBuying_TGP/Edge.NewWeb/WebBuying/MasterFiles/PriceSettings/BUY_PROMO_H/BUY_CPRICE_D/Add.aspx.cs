using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.BUY_CPRICE_D
{
    public partial class Add : PageBase
    {
        BuyingPromotionController controller = new BuyingPromotionController();
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
            controller = SVASessionInfo.BuyingPromotionController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Edge.SVA.Model.BUY_PROMO_D model = new SVA.Model.BUY_PROMO_D();
            model.PromotionCode = this.PromotionCode.Text;
            model.EntityNum = this.EntityNum.Text;
            model.EntityType = Convert.ToInt32(this.EntityType.SelectedValue);
            model.HitOP = Convert.ToInt32(this.HitOP.SelectedValue);
            model.HitAmount = Convert.ToDecimal(this.HitAmount.Text);
            model.DiscPrice = Convert.ToDecimal(this.DiscPrice.Text);
            model.DiscType = Convert.ToInt32(this.DiscType.SelectedValue);
            controller.ViewModel.NewModellist.Add(model);
            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.PromotionCode.Text = Request.Params["PromotionCode"].ToString();
            //controller.BindProdCode(this.ProdCode);
            //controller.BindRPriceTypeCode(this.RPriceTypeCode);
        }
    }
}