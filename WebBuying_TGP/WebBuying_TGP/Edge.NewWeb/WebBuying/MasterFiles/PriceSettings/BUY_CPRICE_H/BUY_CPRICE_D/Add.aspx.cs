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
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H.BUY_CPRICE_D
{
    public partial class Add : PageBase
    {
        BuyingCPriceController controller = new BuyingCPriceController();
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
            controller = SVASessionInfo.BuyingCPriceController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            controller.ViewModel.SubTable.Rows.Add(1);
            int RowIndex = controller.ViewModel.SubTable.Rows.Count - 1;
            controller.ViewModel.SubTable.Rows[RowIndex]["KeyID"] = -1 - RowIndex;
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceCode"] = this.CPriceCode.Text;
            controller.ViewModel.SubTable.Rows[RowIndex]["ProdCode"] = this.ProdCode.SelectedValue;
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceGrossCost"] = ConvertTool.ToDecimal(this.CPriceGrossCost.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceNetCost"] = ConvertTool.ToDecimal(this.CPriceNetCost.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceDisc1"] = ConvertTool.ToDecimal(this.CPriceDisc1.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceDisc2"] = ConvertTool.ToDecimal(this.CPriceDisc2.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceDisc3"] = ConvertTool.ToDecimal(this.CPriceDisc3.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceDisc4"] = ConvertTool.ToDecimal(this.CPriceDisc4.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceBuy"] = ConvertTool.ToDecimal(this.CPriceBuy.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["CPriceGet"] = ConvertTool.ToDecimal(this.CPriceGet.Text);
            controller.ViewModel.SubTable.Rows[RowIndex]["ProdName"] = this.ProdCode.SelectedText;
            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.CPriceCode.Text = Request.Params["CPriceCode"].ToString();
            controller.BindProdCode(this.ProdCode);
        }
    }
}