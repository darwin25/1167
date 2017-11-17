using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT;
using Edge.Web.Tools;


namespace Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.BUY_RPRICE_M
{
    public partial class Add : PageBase
    {
        BuyingProductController controller = new BuyingProductController();
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
                //ExtAspNetTool.SetHidenText(this.RPriceCode, "************");
            }
            controller = SVASessionInfo.BuyingProductController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
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


            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.ProdCode.Text = Request.Params["ProdCode"].ToString();
            //this.RPriceCode.Text = DALTool.GetREFNOCode("RPC");
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