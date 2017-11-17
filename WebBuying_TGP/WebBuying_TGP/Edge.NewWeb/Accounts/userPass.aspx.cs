using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Edge.Security.Manager;
using Edge.Web.Tools;

namespace Edge.Web.Accounts
{
    /// <summary>
    /// userPass 的摘要说明。
    /// </summary>
    public partial class userPass : PageBase
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!hasRight)
                {
                    return;
                }
                if (Context.User.Identity.IsAuthenticated)
                {
                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
                    User currentUser = new Edge.Security.Manager.User(user);
                    this.txtUserName.Text = currentUser.UserName;
                    this.txtUserName.Enabled = false;
                }
            }
        }

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码Edit器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void btnSaveClose_Click(object sender, System.EventArgs e)
        {

            SiteIdentity SID = new SiteIdentity(User.Identity.Name);
            if (SID.TestPassword(txtOldPassword.Text) == 0)
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.PasswordOldIncorrect, FineUI.MessageBoxIcon.Warning);
                return;
            }

            if (this.txtPassword.Text.Trim() == "")
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.PasswordOldNewIncorrect, FineUI.MessageBoxIcon.Warning);
                return;
            }

            if (this.txtPassword.Text.Trim() != this.txtPassword1.Text.Trim())
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.PasswordOldNewIncorrect, FineUI.MessageBoxIcon.Warning);
                return;
            }

            AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
            User currentUser = new Edge.Security.Manager.User(user);

            currentUser.Password = AccountsPrincipal.EncryptPassword(txtPassword.Text);

            if (!currentUser.Update())
            {
                FineUI.Alert.ShowInTop(Resources.MessageTips.UpdateFailed, FineUI.MessageBoxIcon.Warning);
            }
            else
            {
                Logger.Instance.WriteOperationLog(this.PageName, "Change Password " + currentUser.UserName);

                FineUI.Alert.ShowInTop(Resources.MessageTips.UpdateSuccess, FineUI.MessageBoxIcon.Warning);
            }
        }

    }
}
