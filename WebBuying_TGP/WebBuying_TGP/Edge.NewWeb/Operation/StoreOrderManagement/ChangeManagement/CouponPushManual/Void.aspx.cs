using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Controllers;
using Edge.Web.Tools;
using FineUI;

namespace Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual
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
                        ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");

                    string resultMsg = CouponController.BatchVoidCoupon(idList, CouponController.ApproveType.CouponPush);

                    Logger.Instance.WriteOperationLog(this.PageName, "Void Coupon Push " + idList.ToString());

                    Alert.ShowInTop(resultMsg, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Void Coupon Push:" + ex);
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