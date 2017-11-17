<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Edge.Web.Index" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Index</title>
    <link href="Style/default.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="~/res/css/default.css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server">
    </ext:PageManager>
    <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="Region1" Height="65px" ShowBorder="false" ShowHeader="false" Position="Top"
                Layout="Fit" runat="server" EnableCollapse="true">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                        <Items>
                            <ext:ToolbarText ID="lblAdminName" runat="server">
                            </ext:ToolbarText>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                            </ext:ToolbarFill>
                            <ext:ToolbarText ID="ToolbarText4" Text="Translate__Special_121_Start&nbsp;&nbsp;Language：Translate__Special_121_End"
                                runat="server">
                            </ext:ToolbarText>
                            <ext:DropDownList ID="ddlLanguage" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged"
                                runat="server">
                                <ext:ListItem Text="English" Value="en" />
                                <ext:ListItem Text="Simplified Chinese" Value="zh_cn" />
                                <ext:ListItem Text="Traditional Chinese" Value="zh_tw" />
                            </ext:DropDownList>
                            <ext:ToolbarText ID="ToolbarText1" runat="server">
                            </ext:ToolbarText>
                            <ext:Button ID="btnLogout" runat="server" Text="Log out" Icon="ControlPowerBlue" OnClick="logout_click"
                                ConfirmText="OK to exit the system?">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:ContentPanel ShowBorder="false" CssClass="header" ShowHeader="false" ID="ContentPanel1"
                        runat="server">
                        <div class="logo">
                        </div>
                        <div class="title">
                            edgeBuying System
                        </div>
                        <div class="version">
                            Copyright &copy; 2012. VEI. All Rights Reserved.Version:
                            <asp:Label ID="lblVersion" runat="server"></asp:Label>
                        </div>
                    </ext:ContentPanel>
                </Items>
            </ext:Region>
             <ext:Region ID="leftPanel" RegionSplit="true" Width="200px" ShowHeader="true" Title="Menu"
                Icon="Outline" EnableCollapse="true" Layout="Fit" RegionPosition="Left" runat="server">
            </ext:Region>
            <ext:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center" runat="server">
                <Items>
                    <ext:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="Home" Layout="Fit" Icon="House" runat="server" IFrameUrl="AdminCenter.aspx"
                                EnableIFrame="true">
                                <Toolbars>
                                    <ext:Toolbar ID="Toolbar2" runat="server">
                                        <Items>
                                            <ext:ToolbarFill ID="ToolbarFill2" runat="server">
                                            </ext:ToolbarFill>
                                        </Items>
                                    </ext:Toolbar>
                                </Toolbars>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    <ext:Menu ID="menuSettings" runat="server">
        <ext:MenuButton ID="btnExpandAll" IconUrl="/res/images/expand-all.gif" Text="Expand Menu"
            EnablePostBack="false" runat="server">
        </ext:MenuButton>
        <ext:MenuButton ID="btnCollapseAll" IconUrl="/res/images/collapse-all.gif" Text="Collapse Menu"
            EnablePostBack="false" runat="server">
        </ext:MenuButton>
        <ext:MenuButton ID="MenuTheme" EnablePostBack="false" Text="Theme" runat="server">
            <Menu ID="Menu4" runat="server">
                <ext:MenuCheckBox Text="Neptune " ID="MenuThemeNeptune" Checked="true" GroupName="MenuTheme"
                    runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="Blue " ID="MenuThemeBlue" GroupName="MenuTheme" runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="Gray " ID="MenuThemeGray" GroupName="MenuTheme" runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="Access" ID="MenuThemeAccess" GroupName="MenuTheme" runat="server">
                </ext:MenuCheckBox>
            </Menu>
        </ext:MenuButton>
        <ext:MenuButton EnablePostBack="false" Text="Menu Style" ID="MenuStyle" runat="server">
            <Menu ID="Menu1" runat="server">
                <ext:MenuCheckBox Text="Tree Menu" ID="MenuStyleTree" Checked="true" GroupName="MenuStyle"
                    runat="server">
                </ext:MenuCheckBox>
                <ext:MenuCheckBox Text="Accordion + Tree Menu" ID="MenuStyleAccordion" GroupName="MenuStyle" runat="server">
                </ext:MenuCheckBox>
            </Menu>
        </ext:MenuButton>
    </ext:Menu>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
    <script src="/res/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
        var leftPanelClientID = '<%= leftPanel.ClientID %>';
        var btnExpandAllClientID = '<%= btnExpandAll.ClientID %>';
        var btnCollapseAllClientID = '<%= btnCollapseAll.ClientID %>';
        var menuSettingsClientID = '<%= menuSettings.ClientID %>';
        var MenuThemeClientID = '<%= MenuTheme.ClientID %>';
        var MenuStyleClientID = '<%= MenuStyle.ClientID %>';
        F.ready(function () {

            var mainTabStrip = F(mainTabStripClientID);
            var leftPanel = F(leftPanelClientID);
            var mainMenu = leftPanel.items.getAt(0);
            var btnExpandAll = F(btnExpandAllClientID);
            var btnCollapseAll = F(btnCollapseAllClientID);
            var menuSettings = F(menuSettingsClientID);
            var MenuTheme = F(MenuThemeClientID);
            var MenuStyle = F(MenuStyleClientID);

            var menuType = 'accordion';
            if (mainMenu.isXType('treepanel')) {
                menuType = 'menu';
            }

            // 当前展开的手风琴面板
            function getExpandedPanel() {
                var panel = null;
                mainMenu.items.each(function (item) {
                    if (!item.getCollapsed()) {
                        panel = item;
                    }
                });
                return panel;
            }

            // 点击展开菜单
            btnExpandAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    mainMenu.expandAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).expandAll();
                    }
                }
            });

            // 点击折叠菜单
            btnCollapseAll.on('click', function () {
                if (menuType == 'menu') {
                    // 左侧为树控件
                    mainMenu.collapseAll();
                } else {
                    // 左侧为树控件+手风琴控件
                    var expandedPanel = getExpandedPanel();
                    if (expandedPanel) {
                        expandedPanel.items.getAt(0).collapseAll();
                    }
                }
            });

            // 切换主题
            function MenuThemeItemCheckChange(cmp, checked) {
                if (checked) {
                    var lang = 'neptune';
                    if (cmp.id.indexOf('MenuThemeBlue') >= 0) {
                        lang = 'blue';
                    } else if (cmp.id.indexOf('MenuThemeGray') >= 0) {
                        lang = 'gray';
                    } else if (cmp.id.indexOf('MenuThemeAccess') >= 0) {
                        lang = 'access';
                    }
                    F.cookie('Theme_v4', lang, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuTheme.menu.items.each(function (item, index) {
                item.on('checkchange', MenuThemeItemCheckChange);
            });

            // 点击菜单样式
            function MenuStyleItemCheckChange(cmp, checked) {
                if (checked) {
                    var menuStyle = 'accordion';
                    if (cmp.id.indexOf('MenuStyleTree') >= 0) {
                        menuStyle = 'tree';
                    }
                    F.cookie('MenuStyle_v4', menuStyle, {
                        expires: 100 // 单位：天
                    });
                    top.window.location.reload();
                }
            }
            MenuStyle.menu.items.each(function (item, index) {
                item.on('checkchange', MenuStyleItemCheckChange);
            });

            function createToolbar(tabConfig) {

                // 由工具栏上按钮获得当前标签页中的iframe节点
                function getCurrentIFrameNode(btn) {
                    return $('#' + btn.id).parents('.f-tab').find('iframe');
                }

                var openNewWindowButton = new Ext.Button({
                    text: 'Open New Tab',
                    type: 'button',
                    icon: '/res/icon/tab_go.png',
                    listeners: {
                        click: function () {
                            var iframeNode = getCurrentIFrameNode(this);
                            window.open(iframeNode.attr('src'), '_blank');
                        }
                    }
                });

                var refreshButton = new Ext.Button({
                    text: "Refresh",
                    type: 'button',
                    icon: '/res/icon/reload.png',
                    listeners: {
                        click: function () {
                            var iframeNode = getCurrentIFrameNode(this);
                            iframeNode[0].contentWindow.location.reload();
                        }
                    }
                });

                var toolbar = new Ext.Toolbar({
                    //items: ['->', sourcecodeButton, '-', refreshButton, '-', openNewWindowButton]
                    items: ['->', refreshButton]
                });

                tabConfig['tbar'] = toolbar;
            }

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.initTreeTabStrip(mainMenu, mainTabStrip, createToolbar, true, false, false);

            // 添加示例标签页
            window.addExampleTab = function (id, url, text, icon, refreshWhenExist) {
                // 动态添加一个标签页
                // mainTabStrip： 选项卡实例
                // id： 选项卡ID
                // url: 选项卡IFrame地址 
                // text： 选项卡标题
                // icon： 选项卡图标
                // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
                // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
                F.util.addMainTab(mainTabStrip, id, url, text, icon, null, refreshWhenExist);
            };

            // 移除选中标签页
            window.removeActiveTab = function () {
                var activeTab = mainTabStrip.getActiveTab();
                mainTabStrip.removeTab(activeTab.id);
            };



            // 添加工具图标，并在点击时显示上下文菜单
            // 专业版提醒：请将 type:'gear' 改为 iconFont:'gear'
            leftPanel.addTool({
                type: 'gear',
                //tooltip: '系统设置',
                handler: function (event) {
                    menuSettings.showBy(this);
                }
            });

        });

       
    </script>
</body>
</html>
