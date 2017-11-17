using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Tools;
using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H;


namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H.BUY_RPRICE_D
{
    public partial class Add : PageBase
    {
        BuyingPriceController controller = new BuyingPriceController();
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
            controller = SVASessionInfo.BuyingPriceController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            controller.ViewModel.SubTable.Rows.Add(1);
            int RowIndex = controller.ViewModel.SubTable.Rows.Count - 1;
            controller.ViewModel.SubTable.Rows[RowIndex]["KeyID"] = -1 - RowIndex;
            controller.ViewModel.SubTable.Rows[RowIndex]["RPriceCode"] = this.RPriceCode.Text;
            controller.ViewModel.SubTable.Rows[RowIndex]["ProdCode"] = this.ProdCode.SelectedValue;
            controller.ViewModel.SubTable.Rows[RowIndex]["RPriceTypeCode"] = this.RPriceTypeCode.SelectedValue;
            controller.ViewModel.SubTable.Rows[RowIndex]["Price"] = ConvertTool.ToDecimal(this.Price.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["RefPrice"] = ConvertTool.ToDecimal(this.RefPrice.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["PromotionPrice"] = ConvertTool.ToDecimal(this.PromotionPrice.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["MemberPrice"] = ConvertTool.ToDecimal(this.MemberPrice.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["RPriceTypeName"] = this.RPriceTypeCode.SelectedText;
            controller.ViewModel.SubTable.Rows[RowIndex]["ProdName"] = this.ProdCode.SelectedText;
            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.RPriceCode.Text = Request.Params["RPriceCode"].ToString();
            controller.BindProdCode(this.ProdCode);
            controller.BindRPriceTypeCode(this.RPriceTypeCode);
        }
    }
}