using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using System.Data;
using Edge.Web.Controllers.Operation.StockTakeController;

namespace Edge.Web.Operation.StockTake
{
    public partial class StockTakeVAR : Edge.Web.Tools.BasePage<Edge.SVA.BLL.STK_STakeVAR, Edge.SVA.Model.STK_STAKEVAR>
    {
        DataSet detail;
        StockTakeController controller = new StockTakeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                controller.GenStockTakeVAR(Request.Params["id"]);    
                RegisterCloseEvent(btnClose);
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            string StockTakeNumber = Request.Params["id"];
            string strWhere = "StockTakeNumber='" + StockTakeNumber + "'"; 
            if (!this.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }

                int count = 0;
                detail = controller.GetSTKVAR(strWhere, Grid1.PageSize, Grid1.PageIndex, out count, "ProdCode");
                this.Grid1.DataSource = detail.Tables[0].DefaultView;
                this.Grid1.DataBind();
                               
            }
        }

        protected override SVA.Model.STK_STAKEVAR GetPageObject(SVA.Model.STK_STAKEVAR obj)
        {
            List<System.Web.UI.Control> list = new List<System.Web.UI.Control>();

            foreach (System.Web.UI.Control con in this.Panel1.Controls)
            {
                if (con is FineUI.GroupPanel)
                {
                    foreach (System.Web.UI.Control c in con.Controls) list.Add(c);
                }
            }
            return base.GetPageObject(obj, list.GetEnumerator());
        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            //this.BindDetail();
        }

        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            BindGridWithSort(e.SortField, e.SortDirection);
        }

        //排序
        private void BindGridWithSort(string sortField, string sortDirection)
        {
            string StockTakeNumber = Request.Params["id"];
            string strWhere = "StockTakeNumber='" + StockTakeNumber + "'";
            int count = 0;
            DataSet ds = controller.GetSTKVAR(strWhere, Grid1.PageSize, Grid1.PageIndex, out count, "ProdCode");

            DataTable table = ds.Tables[0];

            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            Grid1.DataSource = view1;
            Grid1.DataBind();
        }
   
    }
}