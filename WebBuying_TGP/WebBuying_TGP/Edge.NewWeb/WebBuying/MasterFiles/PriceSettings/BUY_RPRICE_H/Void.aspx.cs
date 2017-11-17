using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using FineUI;
using Edge.Web.Controllers.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H;

namespace Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H
{
    public partial class Void : PageBase
    {
        BuyingPriceController controller = new BuyingPriceController();
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
                        this.ShowWarning(Resources.MessageTips.NotSelected);
                        return;
                    }
                    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(ids, ",");

                    string resultMsg = controller.BatchVoid(idList);

                    Logger.Instance.WriteOperationLog(this.PageName, "Void Price:" + resultMsg);

                    Alert.ShowInTop(resultMsg, "", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference());
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteOperationLog(this.PageName, "Void Price:" + ex);
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