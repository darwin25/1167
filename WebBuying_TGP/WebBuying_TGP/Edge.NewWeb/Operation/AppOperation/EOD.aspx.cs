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
    public partial class EOD : PageBase
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
                if (busDate <= DateTime.Today)
                {
                    this.lbSODEOD.Enabled = true;
                }
                else
                {
                    this.lbSODEOD.Enabled = false;
                }
            }
            else
            {
                this.lbSODEOD.Enabled = false;
            }
        }
        protected void lbSODEOD_Click(object sender, EventArgs e)
        {
            this.lbSODEOD.Enabled = false;
            Logger.Instance.WriteOperationLog(this.PageName," SODEOD "+DateTime.Today.ToString());

            this.CloseLoading();
            DateTime newBusDate;
            AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage.ToString());
            Edge.Security.Manager.User currentUser = SVASessionInfo.CurrentUser;

            if (currentUser != null)
            {
                int rtn = DALTool.ExecSODEOD(currentUser.UserID, out newBusDate);
                if (rtn == 0)
                {
                    Logger.Instance.WriteOperationLog(this.PageName," SODEOD Success New BusDate " + newBusDate.ToString());
                    //JscriptPrint("SOD/EOD Success", "EOD.aspx", Resources.MessageTips.SUCESS_TITLE);
                    RefreshSODEOD();
                    FineUI.Alert.ShowInTop(" SOD/EOD Success", Resources.MessageTips.SUCESS_TITLE, FineUI.MessageBoxIcon.Information);                    
                }
                else
                {
                    Logger.Instance.WriteErrorLog(this.PageName," SODEOD Failed " + rtn.ToString());
                    //JscriptPrint("SOD/EOD Failed ", "EOD.aspx", Resources.MessageTips.FAILED_TITLE);
                    FineUI.Alert.ShowInTop(" SOD/EOD Failed ", Resources.MessageTips.FAILED_TITLE, FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                Logger.Instance.WriteErrorLog(this.PageName," user is null !");
            }
        }
    }
}
