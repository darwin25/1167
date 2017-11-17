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
    public partial class StockTake02 : Edge.Web.Tools.BasePage<Edge.SVA.BLL.STK_STake02, Edge.SVA.Model.STK_STAKE02>
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
                controller.InitSTK02FromSTK01(Request.Params["id"]);    
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
                detail = controller.GetSTK02(strWhere, Grid1.PageSize, Grid1.PageIndex, out count, "ProdCode");
                this.Grid1.DataSource = detail.Tables[0].DefaultView;
                this.Grid1.DataBind();
                               
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (this.Grid1.Rows.Count <= 0)
            {
                Logger.Instance.WriteOperationLog(this.PageName, "STK_STAKE02 no data");
                ShowWarning(Resources.MessageTips.NoData);
                return;
            }
            Dictionary<int, Dictionary<string, object>> modifiedDict = Grid1.GetModifiedDict();
            for (int i = 0, count = Grid1.Rows.Count; i < count; i++)
            {
                Edge.SVA.Model.STK_STAKE02 item = new SVA.Model.STK_STAKE02();
                item.StockTakeNumber = Request.Params["id"];
                if (modifiedDict.ContainsKey(i))
                {
                    Dictionary<string, object> rowDict = modifiedDict[i];
                    if (rowDict.ContainsKey("Panel1_GroupPanel1_Grid1_ctl04"))
                    {
                        
                        
                        item.StockTakeNumber = Request.Params["id"];
                        item.ProdCode = Grid1.Rows[i].DataKeys[0].ToString();
                        item.StockType = Grid1.Rows[i].DataKeys[1].ToString();
                        item.SerialNo = Grid1.Rows[i].DataKeys[2].ToString();
                        item.QTY = Convert.ToInt32(rowDict["Panel1_GroupPanel1_Grid1_ctl04"].ToString());
                        try
                        {
                            Tools.DALTool.Update<Edge.SVA.BLL.STK_STake02>(item);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.WriteErrorLog(this.PageName, string.Format("Stock Take 02 {0} Update Failed", item.StockTakeNumber), ex);
                            ShowAddFailed();
                            return;
                        }
                    }
                }
            }
            controller.UpdateStatus(Request.Params["id"], 3);
            Logger.Instance.WriteOperationLog(this.PageName, " Stock Take 02 Update Success");
            CloseAndRefresh();
        }

        protected override SVA.Model.STK_STAKE02 GetPageObject(SVA.Model.STK_STAKE02 obj)
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
            DataSet ds = controller.GetSTK02(strWhere, Grid1.PageSize, Grid1.PageIndex, out count, "ProdCode");

            DataTable table = ds.Tables[0];

            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            Grid1.DataSource = view1;
            Grid1.DataBind();
        }
   
    }
}