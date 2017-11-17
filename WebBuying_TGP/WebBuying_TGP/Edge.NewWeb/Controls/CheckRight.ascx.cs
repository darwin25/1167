
namespace Edge.Web.Controls
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    using Edge.Security.Manager;
    using System.Configuration;
    using System.Web.Security;
    using Edge.Common;
    using System.Text;

    /// <summary>
    ///	CheckRight 的摘要说明。
    /// </summary>
    public partial class CheckRight : System.Web.UI.UserControl
    {
        //public Window ModelDialogSelf
        //{
        //    get
        //    {
        //        return ModelDialogSelfID;
        //    }
        //}
        //public Window ModelDialogParent
        //{
        //    get
        //    {
        //        return ModelDialogParentID;
        //    }
        //}

        //public Window ApprovedDialog
        //{
        //    get
        //    {
        //        return this.ApproveDialog;
        //    }
        //}
        //public void SetApproveDialog(string txnNo, string approveCode)
        //{

        //}

        public int PermissionID = -1;
        protected void Page_Load(object sender, System.EventArgs e)
        {
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
        ///		设计器支持所需的方法 - 不要使用代码Edit器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            //if (!Page.IsPostBack)
            //{
            //    if (Context.User.Identity.IsAuthenticated)
            //    {
            //        Edge.Security.Model.WebSet webset = new Edge.Security.Manager.WebSet().loadConfig(Utils.GetXmlMapPath("Configpath"));
            //        AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。
            //        if (Session["UserInfo"] == null)
            //        {
            //            Edge.Security.Manager.User currentUser = new Edge.Security.Manager.User(user);
            //            Session["UserInfo"] = currentUser;
            //            Session["Style"] = currentUser.Style;
            //            Response.Write("<script defer>location.reload();</script>");
            //        }
            //        PermissionID = PermissionMapper.GetSingleton().GetPermissionIDfromURL(Request.Path);
            //        if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
            //        {
            //            Response.Clear();
            //            FineUI.Alert.ShowInTop(Resources.MessageTips.NotPermission, "", FineUI.MessageBoxIcon.Warning, FineUI.ActiveWindow.GetHideReference());
            //            //Response.Write("<script defer>window.alert('" + Resources.MessageTips.NotPermission + "');history.back(); </script>");
            //            //Response.End();
            //        }

            //    }
            //    else
            //    {
            //        FormsAuthentication.SignOut();
            //        Session.Clear();
            //        Session.Abandon();
            //        Response.Clear();

            //        string url = null;
            //        if (Request.ApplicationPath == "/")
            //        {
            //            //不存在虚拟目录
            //            url = Request.ApplicationPath + "Login.aspx";
            //        }
            //        else
            //        {
            //            //存在虚拟目录
            //            url = Request.ApplicationPath + "/Login.aspx";
            //        }
            //        Response.Write("<script defer> window.alert('" + Resources.MessageTips.Timeout + "');parent.location='" + url + "';</script>");
            //        Response.End();
            //    }

            //}
        }

        #endregion
    }
}
