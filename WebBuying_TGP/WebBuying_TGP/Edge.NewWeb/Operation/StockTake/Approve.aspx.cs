using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using System.Data;
using FineUI;
using Edge.Web.Controllers.Operation.StockTakeController;

namespace Edge.Web.Operation.StockTake
{
    public partial class Approve : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (!hasRight)
                    {
                        return;
                    }
                    btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("StockTakeNumber", typeof(string));
                    dt.Columns.Add("Status", typeof(string));
                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");
                    StockTakeController controller = new StockTakeController();

                    foreach (string id in idList)
                    {
                        DataRow dr = dt.NewRow();
                        dr["StockTakeNumber"] = id;

                        int r = controller.CloseStockTake(id, DALTool.GetCurrentUser().UserID);
                        if (r == 0)
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Close Stock Take Success :" + id);
                            dr["Status"] = "End Inventory";
                        }
                        else
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Close Stock Take Failed :" + id);
                            dr["Status"] = "盘点失败";
                        }

                        dt.Rows.Add(dr);
                    }
                    this.Grid1.DataSource = dt;
                    this.Grid1.DataBind();
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Close Stock Take Fail :" + ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }
    }
}
