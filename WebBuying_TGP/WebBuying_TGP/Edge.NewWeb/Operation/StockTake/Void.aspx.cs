using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers.Operation.StockTakeController;
using System.Data;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.StockTake
{
    public partial class Void : PageBase
    {
        Tools.Logger logger = Tools.Logger.Instance;
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
                    logger.WriteOperationLog(this.PageName, "Void");
                    btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
                    //btnClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
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
                    bool isSuccess = false;
                    StockTakeController controller = new StockTakeController();

                    foreach (string id in idList)
                    {
                        DataRow dr = dt.NewRow();
                        dr["StockTakeNumber"] = id;

                        int r = controller.UpdateStatus(id,6);
                        if (r == 0)
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Close Stock Take Success :" + id);
                            dr["Status"] = "作废成功";
                        }
                        else
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Close Stock Take Failed :" + id);
                            dr["Status"] = "作废失败";
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