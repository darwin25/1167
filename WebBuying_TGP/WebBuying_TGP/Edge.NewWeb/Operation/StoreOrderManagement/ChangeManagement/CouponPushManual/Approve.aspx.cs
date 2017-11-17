using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual
{
    public partial class Approve : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    btnClose.OnClientClick = FineUI.ActiveWindow.GetHidePostBackReference();
                    if (!hasRight)
                    {
                        return;
                    }
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TxnNo", typeof(string));
                    dt.Columns.Add("ApproveCode", typeof(string));
                    dt.Columns.Add("ApprovalMsg", typeof(string));

                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");

                    bool isSuccess = false;
                    foreach (string id in idList)
                    {
                        Edge.SVA.Model.Ord_CouponPush_H mode = new Edge.SVA.BLL.Ord_CouponPush_H().GetModel(id);

                        DataRow dr = dt.NewRow();
                        dr["TxnNo"] = id;
                        dr["ApproveCode"] = Edge.Web.Controllers.CouponController.ApproveCouponForApproveCode(mode,out isSuccess);
                        if (isSuccess)
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Coupon Push " + mode.CouponPushNumber + " " + Resources.MessageTips.ApproveCode);

                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveCode;
                        }
                        else
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Coupon Push " + mode.CouponPushNumber + " " + Resources.MessageTips.ApproveError);

                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveError;
                        }
                        dt.Rows.Add(dr);
                    }
                    this.Grid1.DataSource = dt;
                    this.Grid1.DataBind();
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Approve " + ex);
                    Alert.ShowInTop(Resources.MessageTips.SystemError, "", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference());
                }
            }
        }
    }
}