using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;

namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.BUY_RPRICE_M
{
    public partial class Add : PageBase
    {
        BuyingProductController controller = new BuyingProductController();
        BuyingProductPendingController productPendingController = new BuyingProductPendingController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(this.btnClose);
                string types = Request.Params["types"];
                if (!string.IsNullOrEmpty(types))
                {
                    hidTypes.Text = types;
                }
                InitData();
                //ExtAspNetTool.SetHidenText(this.RPriceCode, "************");
            }
            controller = SVASessionInfo.BuyingProductController;
            productPendingController = SVASessionInfo.BuyingProductPendingController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            Edge.SVA.BLL.BUY_RPRICE_M bllrp = new SVA.BLL.BUY_RPRICE_M();
            string sql = @"select top 1* from BUY_RPRICE_M where ProdCode='" + this.ProdCode.Text + "' order by keyID desc";
            controller.ViewModel.dtRprice = DBUtility.DbHelperSQL.Query(sql).Tables[0];
            DataTool.AddBuyingRPriceTypeName(controller.ViewModel.dtRprice, "RPriceTypeName", "RPriceTypeCode");
             //来自产品表
            if (Request.Form["hidTypes"] != "productPending")
            {
                controller.ViewModel.dtRprice.Rows.Add(1);
                int RowIndex = controller.ViewModel.dtRprice.Rows.Count - 1;
                controller.ViewModel.dtRprice.Rows[RowIndex]["KeyID"] = -1 - RowIndex;
                controller.ViewModel.dtRprice.Rows[RowIndex]["ProdCode"] = this.ProdCode.Text;
                controller.ViewModel.dtRprice.Rows[RowIndex]["RPriceCode"] = this.RPriceCode.Text;
                if (this.StartDate.Text != "")
                {
                    controller.ViewModel.dtRprice.Rows[RowIndex]["StartDate"] = this.StartDate.Text;
                }
                if (this.EndDate.Text != "")
                {
                    controller.ViewModel.dtRprice.Rows[RowIndex]["EndDate"] = this.EndDate.Text;
                }
                controller.ViewModel.dtRprice.Rows[RowIndex]["RPriceTypeCode"] = this.RPriceTypeCode.SelectedValue;
                controller.ViewModel.dtRprice.Rows[RowIndex]["RefPrice"] = ConvertTool.ToDecimal(this.RefPrice.Text);
                controller.ViewModel.dtRprice.Rows[RowIndex]["Price"] = ConvertTool.ToDecimal(this.Price.Text);
                controller.ViewModel.dtRprice.Rows[RowIndex]["StoreCode"] = this.StoreCode.SelectedValue;
                controller.ViewModel.dtRprice.Rows[RowIndex]["StoreGroupCode"] = this.StoreGroupCode.SelectedValue;
                controller.ViewModel.dtRprice.Rows[RowIndex]["RPriceTypeName"] = this.RPriceTypeCode.SelectedText;
                //controller.ViewModel.dtRprice.Rows[RowIndex]["PromotionPrice"] = ConvertTool.ToDecimal(this.PromotionPrice.Text);
                controller.ViewModel.dtRprice.Rows[RowIndex]["MemberPrice"] = ConvertTool.ToDecimal(this.MemberPrice.Text);
            }
            //来自产品审核表
            else
            {
                productPendingController.ViewModel.dtRprice.Rows.Add(1);
                int RowIndex = productPendingController.ViewModel.dtRprice.Rows.Count - 1;
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["KeyID"] = -1 - RowIndex;
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["ProdCode"] = this.ProdCode.Text;
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["RPriceCode"] = this.RPriceCode.Text;
                if (this.StartDate.Text != "")
                {
                    productPendingController.ViewModel.dtRprice.Rows[RowIndex]["StartDate"] = this.StartDate.Text;
                }
                if (this.EndDate.Text != "")
                {
                    productPendingController.ViewModel.dtRprice.Rows[RowIndex]["EndDate"] = this.EndDate.Text;
                }
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["RPriceTypeCode"] = this.RPriceTypeCode.SelectedValue;
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["RefPrice"] = ConvertTool.ToDecimal(this.RefPrice.Text);
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["Price"] = ConvertTool.ToDecimal(this.Price.Text);
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["StoreCode"] = this.StoreCode.SelectedValue;
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["StoreGroupCode"] = this.StoreGroupCode.SelectedValue;
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["RPriceTypeName"] = this.RPriceTypeCode.SelectedText;
                //controller.ViewModel.dtRprice.Rows[RowIndex]["PromotionPrice"] = ConvertTool.ToDecimal(this.PromotionPrice.Text);
                productPendingController.ViewModel.dtRprice.Rows[RowIndex]["MemberPrice"] = ConvertTool.ToDecimal(this.MemberPrice.Text);
            }
            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.ProdCode.Text = Request.Params["ProdCode"].ToString();
            controller.BindRPriceType(this.RPriceTypeCode);
            controller.BindStore(StoreCode);
            controller.BindStoreGroup(StoreGroupCode);
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
    }
}