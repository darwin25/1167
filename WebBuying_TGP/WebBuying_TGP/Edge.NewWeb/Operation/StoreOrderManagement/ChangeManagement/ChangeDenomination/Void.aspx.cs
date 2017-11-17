using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.ChangeDenomination
{
    public partial class Void : PageBase
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
                    string ids = Request.Params["ids"];
                    if (string.IsNullOrEmpty(ids))
                    {
                        Alert.ShowInTop(Resources.MessageTips.NotSelected, "", MessageBoxIcon.Warning, "location.href='List.aspx'");
                        //JscriptPrint(Resources.MessageTips.NotSelected, "List.aspx?page=0", Resources.MessageTips.WARNING_TITLE);
                        return;
                    }
                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");

                    string resultMsg = CouponController.BatchVoidCoupon(idList, CouponController.ApproveType.CouponAdjust);

                    Logger.Instance.WriteOperationLog(this.PageName, "Void Coupon Change Denomination " + idList.ToString());

                    //SVASessionInfo.MessageHTML = resultMsg;

                    //Alert.ShowInTop(resultMsg, "", MessageBoxIcon.Information, "location.href='List.aspx'");
                    //FineUI.PageContext.RegisterStartupScript(Window1.GetShowReference("~/PublicForms/MessageVoid.aspx", "Void"));
                    Alert.ShowInTop(resultMsg, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Void Coupon Change Denomination:" + ex);
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