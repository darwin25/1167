using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN;
using Edge.Web.Tools;
using System.Data;

namespace Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN.BUY_REPLEN_D
{
    /// <summary>
    /// 店铺的自动补货详情设置
    /// 创建人：lisa
    /// 创建时间：2016-07-13
    /// </summary>
    public partial class Add : PageBase
    {
        BUY_REPLENController controller = new BUY_REPLENController();
        protected int useReplenFormula = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                RegisterCloseEvent(this.btnClose);
                useReplenFormula = Convert.ToInt32(Request.Params["UseReplenFormula"]);
                hidUseReplenFormula.Text = useReplenFormula.ToString();
                InitData();

                Window2.Title = "Search";
            }
            controller = SVASessionInfo.BUY_REPLENController;
        }
        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["table"] as DataTable;
            controller.ViewModel.DetailTable = dt;
            CloseAndPostBack();
        }

        protected void InitData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EntityType", typeof(string));
            dt.Columns.Add("EntityTypeName", typeof(string));
            dt.Columns.Add("EntityCode", typeof(string));
            dt.Columns.Add("MinStockQty", typeof(int));
            dt.Columns.Add("RunningStockQty", typeof(int));
            dt.Columns.Add("OrderRoundUpQty", typeof(int));
            ViewState["table"] = dt;
            ViewState["count"] = 0;
        }

        protected void EntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Request.Form["hidUseReplenFormula"]) == 0)
            {
                if (string.IsNullOrEmpty(MinStockQty.Text))
                {
                    ShowWarning("请填写最小允许库存！");
                    this.EntityType.SelectedValue = "0"; 
                    return;
                }
                if (string.IsNullOrEmpty(RunningStockQty.Text))
                {
                    ShowWarning("请填写正常库存数量！");
                    this.EntityType.SelectedValue = "0"; 
                    return;
                }
                if (string.IsNullOrEmpty(OrderRoundUpQty.Text))
                {
                    ShowWarning("订货数量的倍数！");
                    this.EntityType.SelectedValue = "0"; 
                    return;
                }


            }
            this.EntityCode.Text = "";
            if (this.EntityType.SelectedValue == "1")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../ComplexInformations/BUY_PRODUCT/ListByBauhuas.aspx?multiplepicker=true");
            }
            else if (this.EntityType.SelectedValue == "2")
            {
                btnSelect.OnClientClick = Window2.GetShowReference("../../../BasicInformations/BUY_DEPARTMENT/List.aspx?multiplepicker=true");
            }
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            if (this.EntityType.SelectedValue == "1")
            {
                this.EntityCode.Text = SVASessionInfo.BuyingProdCode;
            }
            else if (this.EntityType.SelectedValue == "2")
            {
                this.EntityCode.Text = SVASessionInfo.BuyingDepartCode;
            }
            RptBind();
        }

        protected void RptBind()
        {
           
            DataTable dt = ViewState["table"] as DataTable;
            if (this.EntityType.SelectedValue != "-1" && this.EntityCode.Text != "")
            {
                string[] entitynumbers = this.EntityCode.Text.Split(',');
                DataTable viewDT = dt.Clone();
                foreach (string item in entitynumbers)
                {
                    DataRow dr = viewDT.NewRow();
                    if (!string.IsNullOrEmpty(this.EntityType.SelectedValue))
                    {
                        dr["EntityType"] = this.EntityType.SelectedValue;
                    }
                    if (!string.IsNullOrEmpty(this.EntityType.SelectedText))
                    {
                        dr["EntityTypeName"] = this.EntityType.SelectedText;
                    }
                    if (!string.IsNullOrEmpty(item))
                    {
                        dr["EntityCode"] = item;
                    }
                    if (!string.IsNullOrEmpty(this.MinStockQty.Text))
                    {
                        dr["MinStockQty"] = this.MinStockQty.Text;
                    }
                    if (!string.IsNullOrEmpty(this.RunningStockQty.Text))
                    {
                        dr["RunningStockQty"] = this.RunningStockQty.Text;
                    }
                    if (!string.IsNullOrEmpty(this.OrderRoundUpQty.Text))
                    {
                        dr["OrderRoundUpQty"] = this.OrderRoundUpQty.Text;
                    }
                    viewDT.Rows.Add(dr);
                }
                //防止多次选取相同记录的处理
                if (dt != null && dt.Rows.Count > 0)
                {
                    string types = "";
                    string ids = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        types += string.Format("{0},", "'" + dt.Rows[i]["EntityType"].ToString() + "'");
                        ids += string.Format("{0},", "'" + dt.Rows[i]["EntityCode"].ToString() + "'");
                    }
                    DataView dvSearch = viewDT.DefaultView;
                    dvSearch.RowFilter = " EntityType not in (" + types + ") or ( EntityType in (" + types + ") and EntityCode not in (" + ids + ") )";
                    DataTable dtSearch = dvSearch.ToTable();
                    dt.Merge(dtSearch);
                }
                else
                {
                    dt.Merge(viewDT);
                }

                ViewState["count"] = dt.Rows.Count;
                ViewState["table"] = dt;

                this.EntityCode.Text = string.Empty;
            }
            this.Grid1.RecordCount = dt.Rows.Count;
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