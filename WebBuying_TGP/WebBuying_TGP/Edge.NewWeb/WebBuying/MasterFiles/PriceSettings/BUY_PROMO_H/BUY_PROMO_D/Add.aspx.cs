using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.BUY_PROMO_D
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

                Window2.Title = "Search";
            }
            controller = SVASessionInfo.BuyingPromotionController;
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["table"] as DataTable;
            controller.ViewModel.SubTable = dt;

            CloseAndPostBack();
        }

        protected void InitData()
        {
            this.PromotionCode.Text = Request.Params["PromotionCode"].ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("EntityType", typeof(string));
            dt.Columns.Add("EntityTypeName", typeof(string));
            dt.Columns.Add("EntityNum", typeof(string));

            dt.Columns.Add("PromotionCode", typeof(string));
            dt.Columns.Add("HitOP", typeof(string));
            dt.Columns.Add("HitType", typeof(string));
            dt.Columns.Add("HitTypeName", typeof(string));
            dt.Columns.Add("HitAmount", typeof(string));
            dt.Columns.Add("DiscPrice", typeof(string));
            dt.Columns.Add("DiscType", typeof(string));
            dt.Columns.Add("HitOPName", typeof(string));
            dt.Columns.Add("DiscTypeName", typeof(string));

            ViewState["table"] = dt;
            ViewState["count"] = 0;
        }

        protected void EntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EntityNum.Text = "";

            //to do
            this.HitOP.SelectedValue = "0";
            this.HitType.SelectedValue = "0";
            this.HitAmount.Text = string.Empty;
            this.DiscPrice.Text = string.Empty;
            this.DiscType.SelectedValue = "0";

            if (this.EntityType.SelectedValue == "1")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../ComplexInformations/BUY_PRODUCT/List.aspx?multiplepicker=true");
            }
            else if (this.EntityType.SelectedValue == "2")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../BasicInformations/BUY_DEPARTMENT/List.aspx?multiplepicker=true");
            }
            else if (this.EntityType.SelectedValue == "3")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../BasicInformations/BUY_CURRENCY/List.aspx?multiplepicker=true");
            }
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            if (this.EntityType.SelectedValue == "1")
            {
                this.EntityNum.Text = SVASessionInfo.BuyingProdCode;
            }
            else if (this.EntityType.SelectedValue == "2")
            {
                this.EntityNum.Text = SVASessionInfo.BuyingDepartCode;
            }
            else if (this.EntityType.SelectedValue == "3")
            {
                this.EntityNum.Text = SVASessionInfo.BuyingTendCode;
            }
            RptBind();
        }

        protected void RptBind()
        {
            DataTable dt = ViewState["table"] as DataTable;
            if (this.EntityType.SelectedValue != "-1" && this.EntityNum.Text!="")
            {
                string[] entitynumbers = this.EntityNum.Text.Split(',');
                //DataTable viewDT = dt.Clone();
                foreach (string item in entitynumbers)
                {
                    //DataRow dr = viewDT.NewRow();
                    DataRow dr = dt.NewRow();
                    dr["EntityType"] = this.EntityType.SelectedValue;
                    dr["EntityTypeName"] = this.EntityType.SelectedText;
                    dr["EntityNum"] = item;

                    dr["PromotionCode"] = this.PromotionCode.Text;
                    dr["HitOP"] = this.HitOP.SelectedValue;
                    dr["HitType"] = this.HitType.SelectedValue;
                    dr["HitTypeName"] = this.HitType.SelectedText;
                    dr["HitAmount"] = this.HitAmount.Text;
                    dr["DiscPrice"] = this.DiscPrice.Text;
                    dr["DiscType"] = this.DiscType.SelectedValue;
                    dr["HitOPName"] = this.HitOP.SelectedText;
                    dr["DiscTypeName"] = this.DiscType.SelectedText;
                    dt.Rows.Add(dr);
                    //viewDT.Rows.Add(dr);
                }
                //防止多次选取相同记录的处理
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    string types = "";
                //    string ids = "";
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        types += string.Format("{0},", "'" + dt.Rows[i]["EntityType"].ToString() + "'");
                //        ids += string.Format("{0},", "'" + dt.Rows[i]["EntityNum"].ToString() + "'");
                //    }
                //    DataView dvSearch = viewDT.DefaultView;
                //    dvSearch.RowFilter = " EntityType not in (" + types + ") or ( EntityType in (" + types + ") and EntityNum not in (" + ids + ") )";
                //    DataTable dtSearch = dvSearch.ToTable();
                //    dt.Merge(dtSearch);
                //}
                //else
                //{
                //    dt.Merge(viewDT);
                //}

                ViewState["count"] = dt.Rows.Count;
                ViewState["table"] = dt;

                this.EntityNum.Text = string.Empty;
            }                
            this.Grid1.RecordCount = Convert.ToInt32(ViewState["count"]);
            this.Grid1.DataSource = Edge.Web.Tools.ConvertTool.GetPagedTable(dt, this.Grid1.PageIndex + 1, this.Grid1.PageSize);
            this.Grid1.DataBind();
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;

            RptBind();
        }
    }
}