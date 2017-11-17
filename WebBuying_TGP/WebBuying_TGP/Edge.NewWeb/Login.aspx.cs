using System;
using Edge.Security.Manager;
using System.Web.Security;
using Edge.SVA.Model;
using System.Globalization;
using System.Threading;
using System.Configuration;
using System.IO;
using System.Web;
using Edge.Utils.Tools;
using Edge.Web.Tools;
using Edge.SVA.Model.Domain.WebInterfaces;
using Edge.Web.Controllers;
using System.Text;
using Edge.SVA.Model.Domain;

namespace Edge.Web.Admin
{

    /// <summary>
    /// Login 的摘要说明。
    /// </summary>
    public partial class Login : PageBase, IForm
    {
        private static string WebVersion = "";
        Tools.Logger logger = Tools.Logger.Instance;
        private static bool NoCheckCode = true;

        //#region Web 窗体设计器生成的代码
        //override protected void OnInit(EventArgs e)
        //{
        //    //
        //    // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //    //
        //    InitializeComponent();
        //    base.OnInit(e);
        //}

        ///// <summary>
        ///// 设计器支持所需的方法 - 不要使用代码Edit器修改
        ///// 此方法的内容。
        ///// </summary>
        //private void InitializeComponent()
        //{    
        //    this.btnLogin.Click += new System.Web.UI.ImageClickEventHandler(this.btnLogin_Click);

        //}
        //#endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();

                SetLanguage(webset.SiteLanguage);

                NoCheckCode = GetCheckCode();

                // 设置样式和语言下拉列表的选中值
                string themeValue = PageManager1.Theme.ToString().ToLower();
                HttpCookie themeCookie = Request.Cookies["Theme"];
                if (themeCookie != null)
                {
                    themeValue = themeCookie.Value;
                }
                ddlLanguage.SelectedValue = PageManager1.Language.ToString().ToLower();
                string lan = LanConvertUtil.ConvertToOldLanFromNewLan(ddlLanguage.SelectedValue);
                Asp.Net.WebFormLib.Factory.CreateITranslater().LanguageLan = lan;
                SVASessionInfo.SiteLanguage = lan;
                //Edge.Security.Data.User user = new Security.Data.User();
                //user.Create("admin", AccountsPrincipal.EncryptPassword("123@abc#"), "Administrator", "1", "", "", 0, "", true, "AA", 1, "");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (SVASessionInfo.PassErrorCount > 3)
            {
                txtUsername.Enabled = false;
                txtPass.Enabled = false;
                btnLogin.Enabled = true;
                FineUI.Alert.ShowInTop(Resources.MessageTips.SystemLocked);
                return;
            }

            if (!NoCheckCode)
            {
                if (SVASessionInfo.CheckCode != null)
                {
                    //所填写的验证码不符
                    if (SVASessionInfo.CheckCode.ToLower() != this.CheckCode.Text.ToLower())
                    {
                        FineUI.Alert.ShowInTop(Resources.MessageTips.SecurityCodeDifferent, "", FineUI.MessageBoxIcon.Warning);

                        Refresh();

                        //FineUI.Alert.ShowInTop(Resources.MessageTips.SecurityCodeDifferent, "", FineUI.MessageBoxIcon.Warning, "location.href='Login.aspx'");
                        //SVASessionInfo.CheckCode = null;
                        return;
                    }
                    else
                    {
                        SVASessionInfo.CheckCode = null;
                    }
                }
                else
                {
                    FineUI.PageContext.Redirect("Login.aspx");
                }
            }

            string userName = Edge.Common.PageValidate.InputText(txtUsername.Text.Trim(), 30);
            string Password = Edge.Common.PageValidate.InputText(txtPass.Text.Trim(), 30);
            logger.WriteOperationLog("Login", " Login Operation userName:" + userName);
            if (SVASessionInfo.SiteLanguage == null)
            {
                SetLanguage(webset.SiteLanguage);
            }
            AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(userName, Password, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。	
            if (newUser == null)
            {
                FineUI.Alert.ShowInTop("Login Error： " + userName);

                Refresh();

                SVASessionInfo.PassErrorCount++;

            }
            else
            {
                AppController app = new AppController();
                User currentUser = app.GetLoginUser(userName, SVASessionInfo.SiteLanguage);
                Context.User = newUser;
                if (((SiteIdentity)User.Identity).TestPassword(Password) == 0)
                {
                    FineUI.Alert.ShowInTop(Resources.MessageTips.PasswordInvalid);

                    SVASessionInfo.PassErrorCount++;
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userName, false);
                    //日志
                    //UserLog.AddLog(currentUser.UserName, currentUser.UserType, Request.UserHostAddress, Request.Url.AbsoluteUri, "登录成功");

                    SVASessionInfo.CurrentUser = currentUser;
                    SVASessionInfo.UserStyle = currentUser.Style;

                    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage);
                    //Edge.SVA.BLL.RelationRoleIssuer bll=new Edge.SVA.BLL.RelationRoleIssuer();
                    //SessionInfo.CardIssuersStr=bll.GetCardIssuersStr(user.RoleIDList);
                    //Edge.SVA.BLL.RelationRoleBrand bll = new Edge.SVA.BLL.RelationRoleBrand();
                    //SessionInfo.BrandIDsStr = bll.GetBrandIDsStr(user.RoleIDList);

                    //StringBuilder sb1 = new StringBuilder();
                    //foreach (var item in currentUser.BrandInfoList)
                    //{
                    //    sb1.Append(",");
                    //    sb1.Append(item.Key);
                    //}
                    //if (sb1.Length >= 1)
                    //{
                    //    SessionInfo.BrandIDsStr = "(" + sb1.ToString().Substring(1) + ")";
                    //}
                    //if (currentUser.SqlConditionBrandIDs.Length>0)
                    //{

                    //}

                    //SessionInfo.BrandIDsStr = currentUser.SqlConditionBrandIDs;
                    //if (SVASessionInfo.ReturnPage != "")
                    //{
                    //    string returnpage = SVASessionInfo.ReturnPage;
                    //    SVASessionInfo.ReturnPage = null;
                    //    FineUI.PageContext.Redirect(returnpage);
                    //}
                    //else
                    //{
                    //    FineUI.PageContext.Redirect("Index.aspx");
                    //    SVASessionInfo.PassErrorCount = 0;
                    //}

                    FineUI.PageContext.Redirect("Index.aspx");
                    SVASessionInfo.PassErrorCount = 0;
                }
            }
        }


        private void LoadData()
        {
            // 创建一个 6 位的随机数并保存在 Session 对象中
            SVASessionInfo.CheckCode = GenerateRandomCode();
        }

        /// <summary>
        /// 创建一个 6 位的随机数
        /// </summary>
        /// <returns></returns>
        private string GenerateRandomCode()
        {
            string s = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                s += random.Next(10).ToString();
            }
            return s;
        }


        protected bool SetLanguage(string lan)
        {
            Edge.Messages.Manager.MessagesTool.instance.MessageLan = lan;

            if (!string.IsNullOrEmpty(lan))
            {
                UICulture = lan;
                Culture = lan;

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lan);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lan);
                SVASessionInfo.SiteLanguage = lan;
                //Asp.Net.WebFormLib.Factory.CreateITranslater().LanguageLan = SVASessionInfo.SiteLanguage.ToString();
                return true;
            }
            else
            {
                SVASessionInfo.SiteLanguage = webset.SiteLanguage;
                //Asp.Net.WebFormLib.Factory.CreateITranslater().LanguageLan = SVASessionInfo.SiteLanguage.ToString();
                return false;
            }
        }

        private bool GetCheckCode()
        {
            bool result = false;
            try
            {
                //string cfgVal = ConfigurationManager.AppSettings["NoCheckCode"];
                //result = bool.Parse(cfgVal);
                return true;
            }
            catch
            { }

            return result;
        }

        /// <summary>
        /// 修改语言
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

            HttpCookie langCookie = new HttpCookie("Language", ddlLanguage.SelectedValue);
            langCookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(langCookie);

            string lan = LanConvertUtil.ConvertToOldLanFromNewLan(ddlLanguage.SelectedValue);
            Asp.Net.WebFormLib.Factory.CreateITranslater().LanguageLan = lan;
            SVASessionInfo.SiteLanguage = lan;
            FineUI.PageContext.Redirect("Login.aspx");

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            imgCaptcha.ImageUrl = "~/Ashx/ValidateCode.ashx?w=223&h=30&t=" + DateTime.Now.Ticks;
        }
        /// <summary>
        /// 刷新验证码
        /// <author>Len</author>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Refresh()
        {
            this.txtPass.Text = "";
            this.CheckCode.Text = "";
            LoadData();
            imgCaptcha.ImageUrl = "~/Ashx/ValidateCode.ashx?w=223&h=30&t=" + DateTime.Now.Ticks;
        }

        //protected void Page_Load(object sender, System.EventArgs e)
        //{
        //    // 在此处放置用户代码以初始化页面
        //    if (!IsPostBack)
        //    {
        //        Edge.Web.Accounts.LanAdmin.LanTools.BindLanList(this.ddlLanList);
        //        this.ddlLanList.SelectedValue = webset.SiteLanguage;
        //        SetLanguage(webset.SiteLanguage);


        //        NoCheckCode = GetCheckCode();

        //        if (NoCheckCode)
        //        {
        //            this.CheckCodeTR.Visible = false;
        //        }
        //        else
        //        {
        //            this.CheckCodeTR.Visible = true;
        //        }

        //        if (string.IsNullOrEmpty(WebVersion))
        //        {
        //            this.lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        //        }
        //    }
        //}

        //private void btnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        //{
        //    if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
        //    {
        //        int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
        //        if (PassErroeCount > 3)
        //        {
        //            txtUsername.Disabled = true;
        //            txtPass.Disabled = true;
        //            btnLogin.Enabled = false;
        //            //this.lblMsg.Text = "对不起，你错误登录了三次，系统登录锁定！";
        //            this.lblMsg.Text = Resources.MessageTips.SystemLocked;
        //            return;
        //        }

        //    }

        //    if (!NoCheckCode)
        //    {
        //        if ((Session["CheckCode"] != null) && (Session["CheckCode"].ToString() != ""))
        //        {
        //            if (Session["CheckCode"].ToString().ToLower() != this.CheckCode.Value.ToLower())
        //            {
        //                //this.lblMsg.Text = "所填写的验证码与所给的不符 !";
        //                this.lblMsg.Text = Resources.MessageTips.SecurityCodeDifferent;
        //                Session["CheckCode"] = null;
        //                return;
        //            }
        //            else
        //            {
        //                Session["CheckCode"] = null;
        //            }
        //        }
        //        else
        //        {
        //            Response.Redirect("login.aspx");
        //        }
        //    }

        //    string userName=Edge.Common.PageValidate.InputText(txtUsername.Value.Trim(),30);
        //    string Password=Edge.Common.PageValidate.InputText(txtPass.Value.Trim(),30);
        //    logger.WriteOperationLog("Login", " Login Operation userName:" + userName);
        //    if (SVASessionInfo.SiteLanguage == null)
        //    {
        //        this.ddlLanList.SelectedValue = webset.SiteLanguage;
        //        SetLanguage(webset.SiteLanguage);
        //    }
        //    AccountsPrincipal newUser = AccountsPrincipal.ValidateLogin(userName, Password, SVASessionInfo.SiteLanguage.ToString());//todo: 修改成多语言。	
        //    if (newUser == null)
        //    {				
        //        this.lblMsg.Text = "Login Error： " + userName;
        //        if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
        //        {
        //            int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
        //            Session["PassErrorCountAdmin"] = PassErroeCount + 1;
        //        }
        //        else
        //        {
        //            Session["PassErrorCountAdmin"] = 1;
        //        }
        //    }
        //    else 
        //    {				
        //        User currentUser=new Edge.Security.Manager.User(newUser);
        //        //if (currentUser.UserType != "AA")
        //        //{
        //        //    this.lblMsg.Text = "你非管理员用户，你没有权限登录后台系统！";
        //        //    return;
        //        //}
        //        Context.User = newUser;
        //        if(((SiteIdentity)User.Identity).TestPassword( Password) == 0)
        //        {
        //            this.lblMsg.Text = Resources.MessageTips.PasswordInvalid;
        //            if ((Session["PassErrorCountAdmin"] != null) && (Session["PassErrorCountAdmin"].ToString() != ""))
        //            {
        //                int PassErroeCount = Convert.ToInt32(Session["PassErrorCountAdmin"]);
        //                Session["PassErrorCountAdmin"] = PassErroeCount + 1;
        //            }
        //            else
        //            {
        //                Session["PassErrorCountAdmin"] = 1;
        //            }
        //        }
        //        else
        //        {					
        //            FormsAuthentication.SetAuthCookie( userName,false );
        //            //日志
        //            //UserLog.AddLog(currentUser.UserName, currentUser.UserType, Request.UserHostAddress, Request.Url.AbsoluteUri, "登录成功");

        //            Session["UserInfo"]=currentUser;
        //            Session["Style"]=currentUser.Style;



        //            AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage.ToString());
        //            //Edge.SVA.BLL.RelationRoleIssuer bll=new Edge.SVA.BLL.RelationRoleIssuer();
        //            //SessionInfo.CardIssuersStr=bll.GetCardIssuersStr(user.RoleIDList);
        //            Edge.SVA.BLL.RelationRoleBrand bll = new Edge.SVA.BLL.RelationRoleBrand();
        //            SessionInfo.BrandIDsStr = bll.GetBrandIDsStr(user.RoleIDList);

        //            if(Session["returnPage"]!=null)
        //            {
        //                string returnpage=Session["returnPage"].ToString();
        //                Session["returnPage"]=null;
        //                Response.Redirect(returnpage);
        //            }
        //            else
        //            {
        //                //Response.Redirect("main.htm");
        //                Response.Redirect("Index.aspx");
        //            }
        //        }
        //    }		
        //}

        //protected void ddlLanList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SetLanguage(this.ddlLanList.SelectedValue);
        //}


        //private bool GetCheckCode()
        //{
        //    bool result = false;
        //    try
        //    {
        //       string cfgVal= ConfigurationManager.AppSettings["NoCheckCode"];
        //        result = bool.Parse(cfgVal); 

        //    }
        //    catch
        //    { }

        //    return result;
        //}




        #region IForm Members

        public bool ValidateForm()
        {
            return true;
        }

        #endregion
    }
}
