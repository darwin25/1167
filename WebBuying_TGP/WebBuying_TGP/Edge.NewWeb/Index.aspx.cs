using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edge.Security.Manager;
using System.Data;
using System.Configuration;
using System.Web.Security;
using Newtonsoft.Json.Linq;
using FineUI;
using Edge.Utils.Tools;
using Edge.SVA.Model;
using Edge.Web.Tools;
using Edge.Web.Controllers;

namespace Edge.Web
{
    public partial class Index : PageBase
    {

        AccountsPrincipal user;
        User currentUser;
        public string strWelcome;
        private static string WebVersion = "";

        #region Page_Init
        private string _menuType = "menu";
        protected void Page_Init(object sender, EventArgs e)
        {

            //if (Context.User.Identity.Name != string.Empty)
            //{
            //    string menuType = "menu";

            //    // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            //    JObject ids = GetClientIDS(mainTabStrip);

            //    Tree treeMenu = InitTreeMenu();
            //    ids.Add("mainMenu", treeMenu.ClientID);
            //    ids.Add("menuType", "menu");

            //    string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            //    PageContext.RegisterStartupScript(idsScriptStr);
            //}

            HttpCookie menuCookie = Request.Cookies["MenuStyle_v4"];
            if (menuCookie != null)
            {
                _menuType = menuCookie.Value;
            }
            if (_menuType == "accordion")
            {
                InitAccordionMenu();

            }
            else
            {
                InitTreeMenu();
            }

        }

        private void InitThemeMenuButton()
        {
            string themeMenuID = "MenuThemeBlue";

            string themeValue = PageManager1.Theme.ToString().ToLower();
            switch (themeValue)
            {
                case "blue":
                    themeMenuID = "MenuThemeBlue";
                    break;
                case "gray":
                    themeMenuID = "MenuThemeGray";
                    break;
                case "access":
                    themeMenuID = "MenuThemeAccess";
                    break;
                case "neptune":
                    themeMenuID = "MenuThemeNeptune";
                    break;

            }

            SetSelectedMenuID(MenuTheme, themeMenuID);
        }
        private void InitMenuStyleButton()
        {
            string menuStyleID = "MenuStyleTree";

            HttpCookie menuStyleCookie = Request.Cookies["MenuStyle_v4"];
            if (menuStyleCookie != null)
            {
                switch (menuStyleCookie.Value)
                {
                    case "menu":
                        menuStyleID = "MenuStyleTree";
                        break;
                    case "accordion":
                        menuStyleID = "MenuStyleAccordion";
                        break;
                }
            }


            SetSelectedMenuID(MenuStyle, menuStyleID);
        }
        private void SetSelectedMenuID(MenuButton menuButton, string selectedMenuID)
        {
            foreach (FineUI.MenuItem item in menuButton.Menu.Items)
            {
                MenuCheckBox menu = (item as MenuCheckBox);
                if (menu != null && menu.ID == selectedMenuID)
                {
                    menu.Checked = true;
                }
                else
                {
                    menu.Checked = false;
                }
            }
        }

        private Accordion InitAccordionMenu()
        {
            
            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            leftPanel.Items.Add(accordionMenu);
            user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            currentUser = SVASessionInfo.CurrentUser;
            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
            DataSet ds;
            ds = sm.GetTreeListByLan("", SVASessionInfo.SiteLanguage);
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["ParentID"]) == 0)
                    {
                        AccordionPane accordionPane = new AccordionPane();
                        accordionPane.Title = ds.Tables[0].Rows[i]["Text"].ToString();
                        accordionPane.Layout = Layout.Fit;
                        accordionPane.ShowBorder = false;
                        accordionPane.BodyPadding = "2px 0 0 0";
                       
                        accordionMenu.Items.Add(accordionPane);

                        Tree innerTree = new Tree();
                        innerTree.EnableArrows = true;
                        innerTree.ShowBorder = false;
                        innerTree.ShowHeader = false;
                        innerTree.EnableIcons = false;
                        innerTree.AutoScroll = true;
                        accordionPane.Items.Add(innerTree);
                        ResolveMenuTree(ds.Tables[0], Convert.ToInt32(ds.Tables[0].Rows[i]["nodeid"]), innerTree.Nodes);
                        ResolveTreeNode(innerTree.Nodes);//重新设置结点图标

                    }
                }

            }
            return accordionMenu;
        }



        private Tree InitTreeMenu()
        {
            Tree treeMenu = new Tree();
            treeMenu.ID = "treeMenu";
            treeMenu.EnableArrows = true;
            treeMenu.ShowBorder = false;
            treeMenu.ShowHeader = false;
            treeMenu.EnableIcons = true;
            treeMenu.AutoScroll = true;
            leftPanel.Items.Add(treeMenu);

            //// 重新设置每个节点的图标
            //ResolveTreeNode(treeMenu.Nodes);

            user = new AccountsPrincipal(Context.User.Identity.Name, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
            currentUser = SVASessionInfo.CurrentUser;
            Edge.Security.Manager.SysManage sm = new Edge.Security.Manager.SysManage();
            DataSet ds;
            ds = sm.GetTreeListByLan("", SVASessionInfo.SiteLanguage);

            BindTreeView(treeMenu, ds.Tables[0]);

            ResolveTreeNode(treeMenu.Nodes);

            return treeMenu;
        }


        private int ResolveMenuTree(DataTable menus, int parentMenuId, FineUI.TreeNodeCollection nodes)
        {
            int count = 0;
            for (int i = 0; i < menus.Rows.Count; i++)
            {
                if (menus.Rows[i]["KeshiPublic"].ToString().ToLower() == "true")
                {
                    int permissionid = int.Parse(menus.Rows[i]["PermissionID"].ToString().Trim());

                    //权限控制菜单		
                    if ((permissionid == -1) || (user.HasPermissionID(permissionid)))//绑定用户有权限的和没设权限的（即公开的菜单）
                    {
                        if (Convert.ToInt32(menus.Rows[i]["ParentID"]) == parentMenuId)
                        {
                            FineUI.TreeNode rootnode = new FineUI.TreeNode();
                            rootnode.Text = menus.Rows[i]["text"].ToString();
                            rootnode.NodeID = menus.Rows[i]["nodeid"].ToString();
                            // rootnode.NavigateUrl = string.IsNullOrEmpty(url.Trim()) ? "javascript:;" : url;
                            rootnode.NavigateUrl = string.IsNullOrEmpty(menus.Rows[i]["url"].ToString().Trim()) ? "" : menus.Rows[i]["url"].ToString();
                            rootnode.Expanded = false;
                            //rootnode.IconUrl = imageurl;

                            nodes.Add(rootnode);
                            int childCount = ResolveMenuTree(menus, Convert.ToInt32(menus.Rows[i]["NodeID"]), rootnode.Nodes);
                            if (childCount == 0)
                            {
                                rootnode.Leaf = true;
                            }
                            count++;
                        }
                    }
                }
            }
            return count;

        }

        //邦定根节点
        public void BindTreeView(Tree treeMenu, DataTable dt)
        {
            DataRow[] drs = dt.Select("ParentID= " + 0);//　选出所有子节点	

            //菜单状态
            string MenuExpanded = ConfigurationManager.AppSettings.Get("MenuExpanded");
            // bool menuExpand = bool.Parse(MenuExpanded);

            treeMenu.Nodes.Clear(); // 清空树
            foreach (DataRow r in drs)
            {
                if (r["KeshiPublic"].ToString().ToLower() == "true")
                {
                    string nodeid = r["NodeID"].ToString();
                    string text = r["Text"].ToString();
                    string parentid = r["ParentID"].ToString();
                    string location = r["Location"].ToString();
                    string url = r["Url"].ToString();
                    string imageurl = r["ImageUrl"].ToString();
                    int permissionid = int.Parse(r["PermissionID"].ToString().Trim());

                    //权限控制菜单		
                    if ((permissionid == -1) || (user.HasPermissionID(permissionid)))//绑定用户有权限的和没设权限的（即公开的菜单）
                    {
                        FineUI.TreeNode rootnode = new FineUI.TreeNode();
                        rootnode.Text = text;
                        rootnode.NodeID = nodeid;
                        // rootnode.NavigateUrl = string.IsNullOrEmpty(url.Trim()) ? "javascript:;" : url;
                        rootnode.NavigateUrl = string.IsNullOrEmpty(url.Trim()) ? "" : url;
                        rootnode.Expanded = true;
                        //rootnode.IconUrl = imageurl;

                        treeMenu.Nodes.Add(rootnode);

                        int sonparentid = int.Parse(nodeid);// or =location
                        CreateNode(sonparentid, rootnode, dt, treeMenu);
                    }

                }
            }
        }


        public void CreateNode(int parentid, FineUI.TreeNode parentnode, DataTable dt, Tree treeMenu)
        {
            DataRow[] drs = dt.Select("ParentID= " + parentid);//选出所有子节点			
            foreach (DataRow r in drs)
            {
                if (r["KeshiPublic"].ToString().ToLower() == "true")
                {
                    string nodeid = r["NodeID"].ToString();
                    string text = r["Text"].ToString();
                    string location = r["Location"].ToString();
                    string url = r["Url"].ToString();
                    string imageurl = r["ImageUrl"].ToString();
                    int permissionid = int.Parse(r["PermissionID"].ToString().Trim());

                    //权限控制菜单
                    if ((permissionid == -1) || (user.HasPermissionID(permissionid)))
                    {

                        FineUI.TreeNode node = new FineUI.TreeNode();
                        node.Text = text;
                        node.NodeID = nodeid;
                        //node.NavigateUrl = string.IsNullOrEmpty(url.Trim()) ? "javascript:;" : url;
                        node.NavigateUrl = string.IsNullOrEmpty(url.Trim()) ? "" : url;
                        //node.IconUrl = imageurl;
                        node.Expanded = false;
                        //node.Expanded=true;
                        int sonparentid = int.Parse(nodeid);// or =location

                        if (parentnode == null)
                        {
                            treeMenu.Nodes.Clear();
                            parentnode = new FineUI.TreeNode();
                            treeMenu.Nodes.Add(parentnode);
                        }
                        parentnode.Nodes.Add(node);
                        CreateNode(sonparentid, node, dt, treeMenu);
                    }//endif
                }

            }//endforeach		

        }
        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitThemeMenuButton();
                InitMenuStyleButton();
                if (Context.User.Identity.Name != string.Empty)
                {


                    // 设置语言下拉列表的选中值
                    ddlLanguage.SelectedValue = PageManager1.Language.ToString().ToLower();
                    string lan = LanConvertUtil.ConvertToOldLanFromNewLan(ddlLanguage.SelectedValue);
                    Asp.Net.WebFormLib.Factory.CreateITranslater().LanguageLan = lan;
                    SVASessionInfo.SiteLanguage = lan;

                    AppController app = new AppController();
                    if (!string.IsNullOrEmpty(SVASessionInfo.CurrentUser.UserName))
                    {
                        SVASessionInfo.CurrentUser = app.GetLoginUser(SVASessionInfo.CurrentUser.UserName, lan);
                    }

                    #region 原来page init位置的函数
                    if (Context.User.Identity.Name != string.Empty)
                    {
                       

                        // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
                        JObject ids = GetClientIDS(mainTabStrip);

                        if (_menuType == "menu")
                        {
                            Tree treeMenu = InitTreeMenu();
                            ids.Add("mainMenu", treeMenu.ClientID);
                            ids.Add("menuType", "menu");
                        }
                        else
                        {
                            Accordion accordionMenu = InitAccordionMenu();
                            ids.Add("mainMenu", accordionMenu.ClientID);
                            ids.Add("menuType", "accordion");
                        }

                        string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
                        PageContext.RegisterStartupScript(idsScriptStr);
                        this.lblAdminName.Text = String.Format("<span style=\"font-weight:bold;color:red;\">{0}</span> [{1}]", currentUser.UserName, Request.UserHostAddress);
                    }
                    #endregion

                    if (string.IsNullOrEmpty(WebVersion))
                    {
                        lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    }
                }
                else
                {
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

        #region Event

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
            PageContext.Refresh();
        }

        protected void logout_click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Clear();
            FineUI.PageContext.Redirect("Login.aspx");
        }

        #endregion

        #region Tree

        /// <summary>
        /// 重新设置每个节点的图标
        /// </summary>
        /// <param name="nodes"></param>
        private void ResolveTreeNode(FineUI.TreeNodeCollection nodes)
        {
            foreach (FineUI.TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.IconUrl = GetIconForTreeNode(node.NavigateUrl);
                    }
                }
                else
                {
                    ResolveTreeNode(node.Nodes);
                }
            }
        }

        /// <summary>
        /// 根据链接地址返回相应的图标
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetIconForTreeNode(string url)
        {
            string iconUrl = "~/images/filetype/vs_unknow.png";
            url = url.ToLower();
            int lastDotIndex = url.LastIndexOf('.');
            string fileType = url.Substring(lastDotIndex + 1);
            if (fileType == "txt")
            {
                iconUrl = "~/images/filetype/vs_txt.png";
            }
            else if (fileType == "aspx")
            {
                iconUrl = "~/images/filetype/vs_aspx.png";
            }
            else if (fileType == "htm" || fileType == "html")
            {
                iconUrl = "~/images/filetype/vs_htm.png";
            }

            return iconUrl;
        }

        #endregion
    }
}
