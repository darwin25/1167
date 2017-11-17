using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineUI;
using System.Threading;
using System.Text;
using System.IO;
using System.Globalization;
using Edge.Common;
using Asp.Net.WebFormLib;
using Edge.Security.Manager;
using System.Web.Security;
using Edge.Web.Admin;
using Edge.Messages.Manager;
using Edge.Web.Tools;
using System.Data;
using System.Configuration;

namespace Edge.Web
{
    public class PageBase : WebPageBase
    {
        protected Edge.Web.Tools.MessageNotifyUtil messageNotifyUtil = Edge.Web.Tools.MessageNotifyUtil.GetSingleton();
        protected override void OnInit(EventArgs e)
        {
            var pm = PageManager.Instance;
            if (pm != null && !pm.IsFineUIAjaxPostBack)
            {
                HttpCookie themeCookie = Request.Cookies["Theme_v4"];
                if (themeCookie != null)
                {
                    try
                    {
                        string themeValue = themeCookie.Value;
                        pm.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }
                    catch (Exception)
                    {
                        pm.Theme = FineUI.Theme.Neptune;
                    }
                }
            }

            if (Context != null && Context.Session != null)
            {
                base.OnInit(e);

                CheckRight();

                if (!IsPostBack)
                {
                    if (pm != null)
                    {

                        HttpCookie langCookie = Request.Cookies["Language"];
                        if (langCookie != null)
                        {
                            string langValue = langCookie.Value;
                            pm.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                        }
                    }
                }
            }


        }



        private bool IsSystemTheme(string themeName)
        {
            themeName = themeName.ToLower();
            string[] themes = Enum.GetNames(typeof(Theme));
            foreach (string theme in themes)
            {
                if (theme.ToLower() == themeName)
                {
                    return true;
                }
            }
            return false;
        }

        protected internal Edge.Security.Model.WebSet webset;

        public PageBase()
        {
            //this.Load += new EventHandler(ManagePage_Load);
            webset = new Edge.Security.Manager.WebSet().loadConfig(Edge.Common.Utils.GetXmlMapPath("Configpath"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Header.DataBind();
        }

        protected override void InitializeCulture()
        {
            if (SVASessionInfo.SiteLanguage != null)
            {
                string lan = SVASessionInfo.SiteLanguage.ToString().ToLower();
                UICulture = lan;
                Culture = lan;

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lan);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lan);

            }
            base.InitializeCulture();
        }


        //private void CheckLogin()
        //{
        //    if (this is Edge.Web.Admin.Login)
        //    {
        //        SVASessionInfo.CurrentUser = null;
        //    }
        //    else
        //    {
        //        if (!Context.User.Identity.IsAuthenticated)
        //        {
        //            FormsAuthentication.SignOut();
        //            Session.Clear();
        //            Session.Abandon();
        //            Response.Clear();

        //            string url = null;
        //            if (Request.ApplicationPath == "/")
        //            {
        //                //不存在虚拟目录
        //                url = Request.ApplicationPath + "Login.aspx";
        //            }
        //            else
        //            {
        //                //存在虚拟目录
        //                url = Request.ApplicationPath + "/Login.aspx";
        //            }
        //            FineUI.Alert.ShowInTop(Resources.MessageTips.Timeout, "", FineUI.MessageBoxIcon.Warning, "top.location='" + url + "';");
        //            //Response.Write("<script defer> window.alert('" + Resources.MessageTips.Timeout + "');parent.location='" + url + "';</script>");
        //            //Response.End();
        //        }

        //    }
        //}

        #region 提示窗
        /// <summary>
        /// 添加Edit删除提示(Url = back) 后退
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptPrint(string msg, string url, string title)
        {
            StringBuilder msbox = new StringBuilder(300);
            msbox.Append("<script type=\"text/javascript\">");
            msbox.AppendFormat("parent.jAlert(\"{0}\",\"{1}\");", msg, title);
            msbox.AppendFormat(" var url=\"{0}\"; ", url);
            msbox.Append("if ( url== \"back\") { parent.sysMain.history.back(-1);}");
            msbox.Append("else if (url != \"\") { parent.sysMain.location.href = url;}");
            msbox.Append("</script>");
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "ShowjAlert", msbox.ToString());
        }

        /// 添加Edit删除提示并且Close
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptPrintAndClose(string msg, string url, string title)
        {

            StringBuilder msbox = new StringBuilder(300);
            msbox.Append("<script type=\"text/javascript\">");
            msbox.AppendFormat("parent.jAlert(\"{0}\",\"{1}\");", msg, title);
            msbox.AppendFormat(" var url=\"{0}\"; ", url);
            msbox.Append("if ( url== \"back\") { parent.sysMain.history.back(-1);}");
            msbox.Append("else if (url != \"\") { parent.sysMain.location.href = url;}");
            msbox.Append("window.top.tb_remove();");
            msbox.Append("window.top.$('#TB_load').remove();");
            msbox.Append("</script>");
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JscriptPrintAndClose", msbox.ToString());
        }

        /// 添加Edit删除提示并且聚焦控件
        /// </summary>
        /// <param name="msgtitle">提示文字</param>
        /// <param name="url">返回地址</param>
        /// <param name="msgcss">CSS样式</param>
        protected void JscriptPrintAndFocus(string msg, string url, string title, string clientID)
        {

            StringBuilder msbox = new StringBuilder(300);
            msbox.Append("<script type=\"text/javascript\">");
            msbox.AppendFormat("parent.jAlert(\" {0}\",\"{1}\",function(){{", msg, title);                      //Format{->{{   } ->}}
            msbox.AppendFormat("if($(\"#{0}\").length > 0){{$(\"#{0}\").focus();}}}}); ", clientID);             //Format{->{{   } ->}}
            msbox.AppendFormat(" var url=\"{0}\"; ", url);
            msbox.Append("if ( url== \"back\") { parent.sysMain.history.back(-1);}");
            msbox.Append("else if (url != \"\") { parent.sysMain.location.href = url;}");
            msbox.Append("</script>");
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JscriptPrintAndFocus", msbox.ToString());
        }

        protected void CloseLoading()
        {
            StringBuilder msbox = new StringBuilder(300);
            msbox.Append("<script type=\"text/javascript\">");
            msbox.Append("window.top.tb_remove();");
            msbox.Append("window.top.$('#TB_load').remove();");
            msbox.Append("</script>");
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "CloseLoading", msbox.ToString());
        }

        protected void AnimateRoll(string id)
        {
            id = id.StartsWith("#") ? id : "#" + id;

            StringBuilder msbox = new StringBuilder(300);
            msbox.Append("<script type=\"text/javascript\">");
            msbox.AppendFormat("if($('{0}').length > 0 ) {{ ", id);
            msbox.AppendFormat("$('html,body').animate({{scrollTop:$('{0}').offset().top}}, 800)}}", id);
            msbox.Append("</script>");

            ClientScript.RegisterStartupScript(Page.GetType(), "AnimateRoll", msbox.ToString());
        }
        #endregion

        #region 备用方法
        ///// <summary>
        ///// 组合URL语句
        ///// </summary>
        ///// <param name="_classId">类别ID</param>
        ///// <param name="_keywords">关健字</param>
        ///// <returns></returns>
        protected string CombUrlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append("keywords=" + HttpContext.Current.Server.UrlEncode(_keywords) + "&");
            }

            return strTemp.ToString();
        }

        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        protected void DeleteFile(string _filepath)
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                return;
            }
            string fullpath = Edge.Common.Utils.GetMapPath(_filepath);
            if (System.IO.File.Exists(fullpath))
            {
                System.IO.File.Delete(fullpath);
            }
        }

        /// <summary>
        /// 生成缩略图的方法
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        /// <returns></returns>
        protected string MakeThumbnail(string _filepath)
        {
            if (!string.IsNullOrEmpty(_filepath) && webset.IsThumbnail == 1)
            {
                string _filename = _filepath.Substring(_filepath.LastIndexOf("/") + 1);
                string _newpath = webset.WebFilePath;
                //检查保存的路径 是否有/开头结尾
                if (_newpath.StartsWith("/") == false)
                {
                    _newpath = "/" + _newpath;
                }
                if (_newpath.EndsWith("/") == false)
                {
                    _newpath = _newpath + "/";
                }
                _newpath = _newpath + "Thumbnail/";

                //检查是否有该路径没有就创建
                if (!Directory.Exists(Edge.Common.Utils.GetMapPath(_newpath)))
                {
                    Directory.CreateDirectory(Edge.Common.Utils.GetMapPath(_newpath));
                }
                //调用生成类方法
                ImageThumbnailMake.MakeThumbnail(_filepath, _newpath + _filename, webset.ProWidth, webset.ProHight, "Cut");

                return _newpath + _filename;
            }

            return _filepath;
        }

        /// <summary>
        /// 刷新整个页面
        /// </summary>
        protected void RefreshParentPage()
        {
            Response.Write("<script language=javascript>self.parent.location.reload();  </script>");
        }

        /// <summary>
        /// 父页面跳转页面
        /// </summary>
        protected void RedirectParentPageTo(string url)
        {
            Response.Write("<script language=javascript>self.parent.location='" + url + "';  </script>");
        }

        /// <summary>
        /// 刷新当前页面
        /// </summary>
        protected void RefreshPage()
        {
            Response.Redirect(Request.Url.ToString());
        }

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="str"></param>
        protected void SaveLogs(string str, string Particular)
        {
            if (webset.WebLogStatus == 0)
            {
                return;
            }
            Edge.Security.Manager.SysManage bll = new Edge.Security.Manager.SysManage();
            bll.AddLog(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), str, Particular);
        }

        protected static string ResolveUrl(string relativeUrl)
        {
            if (relativeUrl == null) throw new ArgumentNullException("relativeUrl");

            if (relativeUrl.Length == 0 || relativeUrl[0] == '/' ||
                relativeUrl[0] == '\\') return relativeUrl;

            int idxOfScheme =
              relativeUrl.IndexOf(@"://", StringComparison.Ordinal);
            if (idxOfScheme != -1)
            {
                int idxOfQM = relativeUrl.IndexOf('?');
                if (idxOfQM == -1 || idxOfQM > idxOfScheme) return relativeUrl;
            }

            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append(HttpRuntime.AppDomainAppVirtualPath);
            if (sbUrl.Length == 0 || sbUrl[sbUrl.Length - 1] != '/') sbUrl.Append('/');

            // found question mark already? query string, do not touch!
            bool foundQM = false;
            bool foundSlash; // the latest char was a slash?
            if (relativeUrl.Length > 1
                && relativeUrl[0] == '~'
                && (relativeUrl[1] == '/' || relativeUrl[1] == '\\'))
            {
                relativeUrl = relativeUrl.Substring(2);
                foundSlash = true;
            }
            else foundSlash = false;
            foreach (char c in relativeUrl)
            {
                if (!foundQM)
                {
                    if (c == '?') foundQM = true;
                    else
                    {
                        if (c == '/' || c == '\\')
                        {
                            if (foundSlash) continue;
                            else
                            {
                                sbUrl.Append('/');
                                foundSlash = true;
                                continue;
                            }
                        }
                        else if (foundSlash) foundSlash = false;
                    }
                }
                sbUrl.Append(c);
            }

            return sbUrl.ToString();
        }
        #endregion

        private static Dictionary<string, Edge.Security.Model.SysNode> nodeCache = null;
        public Dictionary<string, Edge.Security.Model.SysNode> NodeCache
        {
            get
            {
                if (nodeCache == null)
                {
                    nodeCache = new Dictionary<string, Edge.Security.Model.SysNode>();
                }
                return nodeCache;
            }
        }

        public string PageName
        {
            get
            {
                string path = System.Web.HttpContext.Current.Request.Path;

                path = path.Remove(0, System.Web.HttpContext.Current.Request.ApplicationPath.Length);
                if (path.StartsWith("/")) path = path.Remove(0, 1);

                string lan = Thread.CurrentThread.CurrentCulture.Name.ToLower();
                string key = string.Format("{0}_{1}", path, lan);

                lock (typeof(PageBase))
                {
                    if (NodeCache.ContainsKey(key)) return NodeCache[key].Text;

                    Edge.Security.Manager.SysManage manage = new Edge.Security.Manager.SysManage();
                    Edge.Security.Model.SysNode node = manage.GetNodeByUrl(path, lan);
                    if (node == null) return "";

                    NodeCache.Add(key, node);

                    return node.Text;
                }
            }
        }

        #region JS和CS引用方法
        protected string RemainVal(string val)
        {
            return "Translate__Remain_121_Start" + val + "Translate__Remain_121_End";
        }
        protected string GetJSMultiLanguagePath()
        {
            string lan = Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            string path = "~/js/" + lan + "/messages.js";
            return ResolveUrl(path);
        }

        protected string GetJSFunctionPath()
        {
            //string path = "~/js/function.min.js";
            string path = "~/js/function.js";
            return ResolveUrl(path);
        }

        protected string GetjQueryPath()
        {
            string path = "~/js/jquery-1.4.1.min.js";
            return ResolveUrl(path);
        }

        protected string GetjQueryUiPath()
        {
            string path = "~/js/jquery-ui-1.8.21.custom.min.js";
            return ResolveUrl(path);
        }

        protected string GetjQueryUiCssPath()
        {
            string path = "~/js/css/redmond/jquery-ui-1.8.21.custom.css";
            return ResolveUrl(path);
        }

        protected string GetjQueryValidatePath()
        {
            string path = "~/js/jquery.validate.min.js";
            return ResolveUrl(path);
        }

        protected string GetjQueryFormPath()
        {
            string path = "~/js/jquery.form.js";
            return ResolveUrl(path);
        }

        protected string GetPaginationCssPath()
        {
            string path = "~/Style/pagination.css";
            return ResolveUrl(path);
        }

        protected string GetJSPaginationPath()
        {
            string path = "~/js/jquery.pagination.js";
            return ResolveUrl(path);
        }

        protected string GetJSThickBoxPath()
        {
            string path = "~/js/thickbox.js";
            return ResolveUrl(path);
        }

        protected string GetJSThickBoxCssPath()
        {
            string path = "~/Style/thickbox.css";
            return ResolveUrl(path);
        }

        protected string GetMy97DatePickerPath()
        {
            string path = "~/My97DatePicker/WdatePicker.js";
            return ResolveUrl(path);
        }

        protected string GetSearchBoxJqueryPath()
        {
            string path = "~/js/jquery-1.5.2.min.js";
            return ResolveUrl(path);
        }

        protected string GetSearchBoxCommonJsPath()
        {
            string path = "~/js/CommonJs.js";
            return ResolveUrl(path);
        }

        protected string GetSearchBoxDynamicConJsPath()
        {
            string path = "~/js/dynamicCon.js";
            return ResolveUrl(path);
        }

        protected string GetjQeruyAlertsStylePath()
        {
            string path = "~/js/jQeruyAlerts/jquery.alerts.css";
            return ResolveUrl(path);
        }

        protected string GetjQeruyAlertsPath()
        {
            string path = "~/js/jQeruyAlerts/jquery.alerts.js";
            return ResolveUrl(path);
        }

        protected string GetjQueryLigeruiCSS()
        {
            string path = "~/js/ui/skins/Aqua/css/ligerui-all.css";
            return ResolveUrl(path);
        }

        protected string GetjQueryLigerui()
        {
            string path = "~/js/ui/js/ligerui.min.js";
            return ResolveUrl(path);
        }

        protected string GetjQueryLigeruiBase()
        {
            string path = "~/js/ui/js/core/base.js";
            return ResolveUrl(path);
        }
        #endregion

        #region 提示方法
        /// <summary>
        //Close本窗体，然后刷新父窗体
        /// </summary>
        protected void CloseAndRefresh()
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        /// <summary>
        //Close本窗体，然后Posback父窗体
        /// </summary>
        protected void CloseAndPostBack()
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void ShowError(string msg)
        {
            Alert.ShowInTop(msg, MessageBoxIcon.Error);
        }
        /// <summary>
        //警告式提示
        /// </summary>
        protected void ShowWarning(string msg)
        {
            Alert.ShowInTop(msg, MessageBoxIcon.Warning);
        }

        /// <summary>
        //警告式提示
        /// </summary>
        protected void ShowWarningAndClose(string msg)
        {
            Alert.ShowInTop(msg, "", MessageBoxIcon.Warning, ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        //更新失败提示
        /// </summary>
        protected void ShowUpdateFailed()
        {
            Alert.ShowInTop(Resources.MessageTips.UpdateFailed, MessageBoxIcon.Error);
        }

        /// <summary>
        //新增失败提示
        /// </summary>
        protected void ShowAddFailed()
        {
            Alert.ShowInTop(Resources.MessageTips.AddFailed, MessageBoxIcon.Error);
        }

        /// <summary>
        //新增失败提示自定义消息
        /// </summary>
        protected void ShowSaveFailed(string strmessage)
        {
            Alert.ShowInTop(strmessage, MessageBoxIcon.Error);
        }
        #endregion

        #region 图片
        protected string GetServerPath(string subPath)
        {
            string basePath = System.Web.HttpContext.Current.Server.MapPath("~/UploadFiles/");
            return basePath + subPath;
        }
        #endregion


        #region 检查权限
        /// <summary>
        /// 加载完成时设置控件值，若需要修改控件值，在子类重写OnLoadComplete在加载完基本后
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
        }
        protected bool hasRight = true;
        private int PermissionID = -1;
        protected void CheckRight()
        {
            if (this is Login)
            {
                SVASessionInfo.CurrentUser = null;
            }
            else
            {
                if (Context.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(Context.User.Identity.Name) && SVASessionInfo.CurrentUser.UserName.Length >= 1)
                {
                    string name = Context.User.Identity.Name;

                    Edge.Security.Model.WebSet webset = new Edge.Security.Manager.WebSet().loadConfig(Edge.Common.Utils.GetXmlMapPath("Configpath"));
                    AccountsPrincipal user = new AccountsPrincipal(name, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                    //if (SVASessionInfo.CurrentUser.UserName.Length==0)
                    //{
                    //    Edge.Security.Manager.User currentUser = new Edge.Security.Manager.User(user);
                    //    SVASessionInfo.CurrentUser = currentUser;
                    //    SVASessionInfo.UserStyle = currentUser.Style;
                    //    Response.Write("<script defer>location.reload();</script>");
                    //}
                    PermissionID = PermissionMapper.GetSingleton().GetPermissionIDfromURL(Request.Path);
                    if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
                    {
                        hasRight = false;

                        FineUI.Alert.ShowInTop(Resources.MessageTips.NotPermission, "", FineUI.MessageBoxIcon.Warning, FineUI.ActiveWindow.GetHideRefreshReference());
                    }

                }
                else
                {
                    hasRight = false;

                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Session.Abandon();
                    Response.Clear();

                    string url = null;
                    if (Request.ApplicationPath == "/")
                    {
                        //不存在虚拟目录
                        url = Request.ApplicationPath + "Login.aspx";
                    }
                    else
                    {
                        //存在虚拟目录
                        url = Request.ApplicationPath + "/Login.aspx";
                    }
                    FineUI.Alert.ShowInTop(Resources.MessageTips.Timeout, "", FineUI.MessageBoxIcon.Warning, "top.location='" + url + "';");
                }
            }
        }
        #endregion

        protected virtual void WindowEdit_Close(object sender, FineUI.WindowCloseEventArgs e)
        {

        }

        #region Operation
        protected void ApproveTxns(string ids, string okScript, string cancelScript)
        {
            //string msg = FineUI.Confirm.GetShowReference(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + ids, Resources.MessageTips.Approve, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
            //FineUI.PageContext.RegisterStartupScript(msg);

            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + ids, Resources.MessageTips.Approve, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        protected void VoidTxns(string ids, string okScript, string cancelScript)
        {
            //string msg = FineUI.Confirm.GetShowReference(MessagesTool.instance.GetMessage("10018") + "\n TXN NO.: \n" + ids, Resources.MessageTips.Void, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
            //FineUI.PageContext.RegisterStartupScript(msg);
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10018") + "\n TXN NO.: \n" + ids, Resources.MessageTips.Void, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        protected void NewApproveTxns(FineUI.Grid Grid, FineUI.Window Window)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid.SelectedRowIndexArray)
            {
                sb.Append(Grid.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }

            string okScript = Window.GetShowReference("Approve.aspx?ids=" + sb1.ToString().TrimEnd(','), Resources.MessageTips.Approve);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Approve, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        protected void NewVoidTxns(FineUI.Grid Grid, FineUI.Window Window)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid.SelectedRowIndexArray)
            {
                sb.Append(Grid.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }


     

            string okScript = Window.GetShowReference("Void.aspx?ids=" + sb1.ToString().TrimEnd(','), Resources.MessageTips.Void);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10018") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Void, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }
        /// <summary>
        /// 导出
        /// 创建人：王丽
        /// 创建时间：2015-11-27
        /// </summary>
        /// <param name="Grid"></param>
        /// <param name="Window"></param>
        //protected void NewExportTxns(FineUI.Grid Grid, FineUI.Window Window)
        //{
        //    int orderType = 0;
        //    StringBuilder sb = new StringBuilder();
        //    foreach (int row in Grid.SelectedRowIndexArray)
        //    {
        //        if (!string.IsNullOrEmpty(Grid.DataKeys[row][1].ToString()))
        //        {
        //            orderType = Convert.ToInt32(Grid.DataKeys[row][1].ToString());
        //        }
        //        sb.Append(Grid.DataKeys[row][0].ToString());
        //        sb.Append(",");
        //    }
        //    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
        //    idList = (from m in idList orderby m ascending select m).ToList();
        //    StringBuilder sb1 = new StringBuilder();
        //    foreach (var item in idList)
        //    {
        //        sb1.Append(item);
        //        sb1.Append(",");
        //    }
        //    string okScript = Window.GetShowReference("Export.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&orderType=" + orderType, Resources.MessageTips.Export);
           

        //    string cancelScript = "";
        //   ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
          
        //}


        protected void NewExportTxns3(FineUI.Grid Grid, FineUI.Window Window)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbOrderType = new StringBuilder();
            StringBuilder sbTxnNo = new StringBuilder();
            foreach (int row in Grid.SelectedRowIndexArray)
            {
               
                sb.Append(Grid.DataKeys[row][0].ToString());
                sb.Append(",");
                sbOrderType.Append(Grid.DataKeys[row][1].ToString());
                sbOrderType.Append(",");
                sbTxnNo.Append(Grid.DataKeys[row][3].ToString());
                sbTxnNo.Append(",");
            }
            string okScript = Window.GetShowReference("Export.aspx?ids=" + sb.ToString().TrimEnd(',') + "&orderType=" + sbOrderType + "&txnNos=" + sbTxnNo.ToString().TrimEnd(','), Resources.MessageTips.Export);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);

        }


        protected void NewExportTxns2(FineUI.Grid Grid, FineUI.Window Window)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in Grid.SelectedRowIndexArray)
            {
                sb.Append(Grid.DataKeys[row][0].ToString());
                sb.Append(",");
            }
            List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
            idList = (from m in idList orderby m ascending select m).ToList();
            StringBuilder sb1 = new StringBuilder();
            foreach (var item in idList)
            {
                sb1.Append(item);
                sb1.Append(",");
            }
            string okScript = Window.GetShowReference("Export.aspx?ids=" + sb1.ToString().TrimEnd(','), Resources.MessageTips.Export);
            string cancelScript = "";
            ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        }

        //protected void NewExportTxns3(FineUI.Grid Grid, FineUI.Window Window)
        //{
        //    int orderType = 0;
        //    StringBuilder sb = new StringBuilder();
        //    StringBuilder sbCard = new StringBuilder();
        //    foreach (int row in Grid.SelectedRowIndexArray)
        //    {
        //        if (!string.IsNullOrEmpty(Grid.DataKeys[row][1].ToString()))
        //        {
        //            orderType = Convert.ToInt32(Grid.DataKeys[row][1].ToString());
        //        }
        //        sb.Append(Grid.DataKeys[row][0].ToString());
        //        sb.Append(",");
        //        sbCard.Append(Grid.DataKeys[row][2].ToString());
        //        sbCard.Append(",");
        //    }
        //    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
        //    idList = (from m in idList orderby m ascending select m).ToList();
        //    StringBuilder sb1 = new StringBuilder();
        //    foreach (var item in idList)
        //    {
        //        sb1.Append(item);
        //        sb1.Append(",");
        //    }
        //    string okScript = Window.GetShowReference("Export.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&orderType=" + orderType + "&cardnumbers=" + sbCard.ToString().TrimEnd(','), Resources.MessageTips.Export);


        //    string cancelScript = "";
        //    ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Export, FineUI.MessageBoxIcon.Question, okScript, cancelScript);

        //}
        /// <summary>
        /// 打印
        /// 创建人：王丽
        /// 创建时间：2015-11-27
        /// </summary>
        /// <param name="Grid"></param>
        /// <param name="Window"></param>
        //protected void NewPrintTxns(FineUI.Grid Grid, FineUI.Window Window)
        //{
        //    int orderType = 0;
        //    StringBuilder sb = new StringBuilder();
        //    foreach (int row in Grid.SelectedRowIndexArray)
        //    {
        //        orderType = Convert.ToInt32(Grid.DataKeys[row][1].ToString());
        //        sb.Append(Grid.DataKeys[row][0].ToString());
        //        sb.Append(",");
        //    }
        //    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
        //    idList = (from m in idList orderby m ascending select m).ToList();
        //    StringBuilder sb1 = new StringBuilder();
        //    foreach (var item in idList)
        //    {
        //        sb1.Append(item);
        //        sb1.Append(",");
        //    }
        //    string okScript = Window.GetShowReference("Print.aspx?ids=" + sb1.ToString().TrimEnd(',') + "&orderType=" + orderType, Resources.MessageTips.Print);
        //    string cancelScript = "";
        //    ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Print, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        //}
        //protected void NewPrintTxns2(FineUI.Grid Grid, FineUI.Window Window)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (int row in Grid.SelectedRowIndexArray)
        //    {
        //        sb.Append(Grid.DataKeys[row][0].ToString());
        //        sb.Append(",");
        //    }
        //    List<string> idList = Edge.Utils.Tools.StringHelper.SplitString(sb.ToString(), ",");
        //    idList = (from m in idList orderby m ascending select m).ToList();
        //    StringBuilder sb1 = new StringBuilder();
        //    foreach (var item in idList)
        //    {
        //        sb1.Append(item);
        //        sb1.Append(",");
        //    }
        //    string okScript = Window.GetShowReference("Print.aspx?ids=" + sb1.ToString().TrimEnd(','), Resources.MessageTips.Print);
        //    string cancelScript = "";
        //    ShowConfirmDialog(MessagesTool.instance.GetMessage("10017") + "\n TXN NO.: \n" + sb1.ToString().Replace(",", ";\n"), Resources.MessageTips.Print, FineUI.MessageBoxIcon.Question, okScript, cancelScript);
        //}

        #endregion
        #region Alert
        #endregion


        #region Basic Confirm
        public void ShowConfirmDialog(string msg, string title, MessageBoxIcon icon, string okScript, string cancelScript)
        {
            FineUI.PageContext.RegisterStartupScript(Confirm.GetShowReference(msg, title, icon, okScript, cancelScript, Target.Top));
        }
        #endregion
        #region Dec Basic Confirm
        public void AreYouSure(string okScript, string cancelScript)
        {
            ShowConfirmDialog("Are you sure?", "System Info", MessageBoxIcon.Question, okScript, cancelScript);
        }
        #endregion


        #region Public Button Event
        public void ExecuteJS(string jsStr)
        {
            PageContext.RegisterStartupScript(jsStr);
        }
        protected void RegisterCloseEvent(FineUI.Button btn)
        {
            btn.OnClientClick = ActiveWindow.GetHideReference();
        }
        protected virtual void RegisterGrid_OnPageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null)
            {
                grid.PageIndex = e.NewPageIndex;
            }
        }
        #endregion

        #region Textbox转换为正 Int格式
        protected virtual void ConvertTextboxToInt(object sender, EventArgs e)
        {
            FineUI.TextBox tf = sender as FineUI.TextBox;
            if (tf != null)
            {
                int dec;
                if (int.TryParse(tf.Text.Trim(), out dec))
                {
                    if (dec >= 0 && dec <= 100000000)
                    {
                        tf.ClearInvalid();
                        tf.Text = dec.ToString();
                    }
                    else
                    {
                        tf.MarkInvalid(tf.RegexMessage);
                    }
                }
                else
                {
                    tf.MarkInvalid(tf.RegexMessage);
                }
            }
        }
        #endregion

        #region Textbox转换为正 Decimal格式
        protected virtual void ConvertTextboxToDecimal(object sender, EventArgs e)
        {
            FineUI.TextBox tf = sender as FineUI.TextBox;
            if (tf != null)
            {
                decimal dec;
                if (decimal.TryParse(tf.Text.Trim(), out dec))
                {
                    if (dec >= 0 && dec <= 100000000)
                    {
                        tf.ClearInvalid();
                        tf.Text = String.Format("{0:F}", dec);
                    }
                    else
                    {
                        tf.MarkInvalid(tf.RegexMessage);
                    }
                }
                else
                {
                    tf.MarkInvalid(tf.RegexMessage);
                }
            }
        }
        #endregion

        #region ValidateForm Rules

        protected virtual bool CheckAndConvertTextboxToDecimal(FineUI.TextBox tf)
        {
            decimal dec;
            if (decimal.TryParse(tf.Text.Trim(), out dec))
            {
                if (dec >= 0 && dec <= 100000000)
                {
                    tf.ClearInvalid();
                    tf.Text = String.Format("{0:F}", dec);
                    return true;
                }
                else
                {
                    tf.MarkInvalid(tf.RegexMessage);
                    return false;
                }
            }
            else
            {
                tf.MarkInvalid(tf.RegexMessage);
                return false;
            }
        }
        protected virtual bool CheckAndConvertTextboxListToDecimal(List<FineUI.TextBox> tfs)
        {
            bool rtn = true;
            foreach (var item in tfs)
            {
                if (!CheckAndConvertTextboxToDecimal(item))
                {
                    rtn = false;
                }
            }
            return rtn;
        }
        #endregion

        public void InitWindowSize(Window window)
        {
            int width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            window.Width = width - 300;
        }

        public void SetGirdSelectAll(Grid grid, bool check)
        {
            //if (check)
            //{
            //    int len = grid.PageSize;
            //    int[] indexs = new int[len];
            //    for (int i = 0; i < len; i++)
            //    {
            //        indexs[i] = i;
            //    }
            //    grid.SelectedRowIndexArray = indexs;
            //}
            //else
            //{
            //    grid.SelectedRowIndexArray = new int[] { };
            //}
            grid.Enabled = !check;
        }

        /// <summary>
        /// 清空列表记录
        /// </summary>
        /// <param name="grid"></param>
        public void ClearGird(Grid grid)
        {
            grid.RecordCount = 0;
            grid.PageIndex = 0;
            grid.DataSource = null;
            grid.DataBind();
        }

        protected virtual void ConvertAllTextboxToUpperText(object sender, EventArgs e)
        {
            FineUI.TextBox tf = sender as FineUI.TextBox;
            if (tf != null)
            {
                tf.Text = tf.Text.ToUpper();
            }
        }


        public void SaveCSV(DataSet ds, string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";

            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }


            data = "";

            dt = ds.Tables[1];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }


            data = "";

            dt = ds.Tables[2];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }

            data = "";

            dt = ds.Tables[3];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }

            data = "";

            dt = ds.Tables[4];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }


            data = "";

            dt = ds.Tables[5];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();

        }

        public void SaveCSVStoreOrder(DataSet ds, string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";

            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }


            data = "";

            dt = ds.Tables[1];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }


            data = "";

            dt = ds.Tables[2];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }

            data = "";

            dt = ds.Tables[3];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(",") || str.Contains("\"")
                        || str.Contains("\r") || str.Contains("\n")) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }

            
            sw.Close();
            fs.Close();

        }

        public void SendReceoveOrderViaEmail(string ShipmentOrderNumber)
        {

            string sendfrom = ConfigurationSettings.AppSettings["Sendfrom"];
            string receipient = ConfigurationSettings.AppSettings["EmailReceipients"];
            string password = ConfigurationSettings.AppSettings["EmailPassword"];
            string smtphost = ConfigurationSettings.AppSettings["SMTPHost"];
            string smtpport = ConfigurationSettings.AppSettings["SMTPPort"];

            string subject = "Your order has been approved and ready for Shipping";
            string body = "Dear Store admin, " +
               Environment.NewLine +
               Environment.NewLine +
               "This is to notify you that Shipment Order Number - " + ShipmentOrderNumber + " has been approved from HQ:" +
               Environment.NewLine +
               Environment.NewLine +
               "Please folow the link below for details:" +
               Environment.NewLine +
               Environment.NewLine +
               //Request.Url.GetLeftPart(UriPartial.Authority).ToString() + "/WebBuying/WebLinks/StoreReceive.aspx?id=" + ShipmentOrderNumber +
               FullyQualifiedApplicationPath + "WebLinks/StoreReceive.aspx?id=" + ShipmentOrderNumber +
               Environment.NewLine +
               Environment.NewLine +
               "";

            SendEmail(subject, body, sendfrom, receipient, password, smtphost, smtpport);

        }

        private void SendEmail(string subject, string body, string sendfrom, string receipient,
                                string password, string smtphost, string smtpport)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(sendfrom, receipient);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = smtphost;
            smtp.EnableSsl = true;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential(sendfrom, password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = NetworkCred;
            smtp.Port = Int32.Parse(smtpport);
            smtp.Send(mail);


        }

        public string FullyQualifiedApplicationPath
        {
            get
            {
                //Return variable declaration
                string appPath = null;

                //Getting the current context of HTTP request
                HttpContext context = HttpContext.Current;

                //Checking the current context content
                if (context != null)
                {
                    //Formatting the fully qualified website url/name
                    appPath = string.Format("{0}://{1}{2}{3}",
                      context.Request.Url.Scheme,
                      context.Request.Url.Host,
                      context.Request.Url.Port == 80
                        ? string.Empty : ":" + context.Request.Url.Port,
                      context.Request.ApplicationPath);
                }
                if (!appPath.EndsWith("/"))
                    appPath += "/";
                return appPath;
            }
        }
    }
}