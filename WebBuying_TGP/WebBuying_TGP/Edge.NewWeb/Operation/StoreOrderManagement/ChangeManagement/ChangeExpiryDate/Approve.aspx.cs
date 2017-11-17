using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers;
using System.Data;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.ChangeExpiryDate
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
                        //JscriptPrint(Resources.MessageTips.NotSelected, "List.aspx?page=0", Resources.MessageTips.WARNING_TITLE);
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
                        Edge.SVA.Model.Ord_CouponAdjust_H mode = new Edge.SVA.BLL.Ord_CouponAdjust_H().GetModel(id);

                        DataRow dr = dt.NewRow();
                        dr["TxnNo"] = id;
                        dr["ApproveCode"] = CouponController.ApproveCouponForApproveCode(mode, CouponController.OprID.Expired, out isSuccess);
                        if (isSuccess)
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Coupon Change Expiry Date " + mode.CouponAdjustNumber + " " + Resources.MessageTips.ApproveCode);


                            dr["ApprovalMsg"] = Resources.MessageTips.ApproveCode;
                        }
                        else
                        {
                            Logger.Instance.WriteOperationLog(this.PageName, "Approve Coupon Change Expiry Date " + mode.CouponAdjustNumber + " " + Resources.MessageTips.ApproveError);

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

        protected void Grid1_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {

        }

        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            //if (e.DataItem is DataRowView)
            //{
            //    DataRowView drv = e.DataItem as DataRowView;
            //    string approveStatus = drv["ApproveStatus"].ToString().Trim();
            //    FineUI.WindowField editWF = Grid1.FindColumn("EditWindowField") as FineUI.WindowField;

            //    if (approveStatus != "")
            //    {
            //        approveStatus = approveStatus.Substring(0, 1).ToUpper().Trim();
            //        switch (approveStatus)
            //        {
            //            case "A":
            //                editWF.Enabled = false;
            //                break;
            //            case "P":
            //                editWF.Enabled = true;
            //                (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
            //                break;
            //            case "V":
            //                editWF.Enabled = false;
            //                (Grid1.Rows[e.RowIndex].FindControl("lblApproveCode") as Label).Text = "";
            //                break;
            //        }
            //    }
            //}
        }
    }
}
