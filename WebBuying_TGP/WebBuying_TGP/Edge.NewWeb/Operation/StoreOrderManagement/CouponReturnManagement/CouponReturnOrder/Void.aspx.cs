using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Web.Controllers;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnOrder
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
                        return;
                    }

                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");

                    Logger.Instance.WriteOperationLog(this.PageName, "Batch Void Coupon:" + ids);
                    string resultMsg = CouponController.BatchVoidCoupon(idList, CouponController.ApproveType.CouponReturn);
                    Logger.Instance.WriteOperationLog(this.PageName, "Batch Void Coupon:" + resultMsg);
                    //FineUI.PageContext.RegisterStartupScript(Window1.GetShowReference("~/PublicForms/MessageVoid.aspx", "Void"));
                    Alert.ShowInTop(resultMsg, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Batch Void Coupon:" + ex);
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
