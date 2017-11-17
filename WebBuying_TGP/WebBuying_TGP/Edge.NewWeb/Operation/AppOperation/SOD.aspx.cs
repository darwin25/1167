using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Web.Tools;
using Edge.Security.Manager;

namespace Edge.Web.Operation.AppOperation
{
    public partial class SOD : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshSODEOD();
            }
        }
        private void RefreshSODEOD()
        {
            DateTime busDate;
            if (DateTime.TryParse(DALTool.GetBusinessDate(), out busDate))
            {
                this.lbNowBusDate.Text = busDate.ToString("yyyy-MM-dd");
            }
        }
        protected void lbSetSODEODTime_Click(object sender, EventArgs e)
        {
            this.lbSetSODEODTime.Enabled = false;
            this.tpEODTime.Enabled = false;

            Logger.Instance.WriteOperationLog(this.PageName, " SetSODEOD " + DateTime.Today.ToString());

            this.CloseLoading();
            string eodTime = this.tpEODTime.Text;
            AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage.ToString());
            Edge.Security.Manager.User currentUser = SVASessionInfo.CurrentUser;

            if (currentUser != null)
            {
                try
                {
                    DALTool.SODEODSetTime(eodTime);
                    Logger.Instance.WriteOperationLog(this.PageName, "Set SODEOD Success New BusDate " + eodTime);
                    //JscriptPrint("Set SOD/EOD Success", "EOD.aspx", Resources.MessageTips.SUCESS_TITLE);
                    //FineUI.Alert.ShowInTop("Set SOD/EOD Success", Resources.MessageTips.SUCESS_TITLE, FineUI.MessageBoxIcon.Information, "location.href='SOD.aspx'");
                }
                catch (System.Exception ex)
                {
                    Logger.Instance.WriteErrorLog(this.PageName, " it doesn't matter, Set SODEOD Failed " + eodTime, ex);
                    //JscriptPrint("Set SOD/EOD Failed ", "EOD.aspx", Resources.MessageTips.FAILED_TITLE);
                    //FineUI.Alert.ShowInTop("Set SOD/EOD Failed ", Resources.MessageTips.FAILED_TITLE, FineUI.MessageBoxIcon.Error, "location.href='SOD.aspx'");
                    //FineUI.Alert.ShowInTop("Set SOD/EOD Failed ", Resources.MessageTips.FAILED_TITLE, FineUI.MessageBoxIcon.Error);
                }
                FineUI.Alert.ShowInTop("Set SOD/EOD Success", Resources.MessageTips.SUCESS_TITLE, FineUI.MessageBoxIcon.Information);
            }
            else
            {
                Logger.Instance.WriteErrorLog(this.PageName, " user is null !");
            }
            this.lbSetSODEODTime.Enabled = true;
            this.tpEODTime.Enabled = true;
        }
    }
}
