using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;
using Edge.Web.Controllers.Operation.StoreOrderManagement.ReturnStoreOrder;
using System.Data;

namespace Edge.Web.Operation.StoreOrderManagement.ReturnStoreOrder
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
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning, "location.href='List.aspx'");
                        return;
                    }

                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");

                    //Add By Robin for Not batch void
                    bool isSuccess = false;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TxnNo", typeof(string));
                    dt.Columns.Add("ApproveCode", typeof(string));
                    dt.Columns.Add("ApprovalMsg", typeof(string));

                    foreach (string id in idList)
                    {
                        Edge.SVA.Model.Ord_ReturnOrder_H mode = new Edge.SVA.BLL.Ord_ReturnOrder_H().GetModel(id);

                        DataRow dr = dt.NewRow();
                        dr["TxnNo"] = id;
                        dr["ApproveCode"] = ReturnStoreOrderController.Void(mode, out isSuccess);

                        if (isSuccess)
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Void Success :" + id);

                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveCode;
                        }
                        else
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Void Failed :" + id);
                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveError;
                        }

                        dt.Rows.Add(dr);
                    }
                    this.Grid1.DataSource = dt;
                    this.Grid1.DataBind();
                    //End

                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Void Return Store Order:" + ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }

        protected override void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            base.WindowEdit_Close(sender, e);
            Response.Redirect("List.aspx");
        }
    }
}
