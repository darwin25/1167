<%@ Page Language="c#" CodeBehind="EditRole.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.Admin.EditRole" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>EditRole</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
    <ext:Form ID="Form2" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Title="Form" AutoScroll="true" LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Rows>
            <ext:FormRow ID="FormRow1" runat="server">
                <Items>
                    <ext:TextBox ID="TxtNewname" runat="server" Label="角色名">
                    </ext:TextBox>
                </Items>
            </ext:FormRow>
                        <ext:FormRow ID="FormRow2" runat="server">
                <Items>
                    <ext:DropDownList ID="CategoryDownList" runat="server" Label="权限类别" OnSelectedIndexChanged="CategoryDownList_SelectedIndexChanged"
                        AutoPostBack="true">
                    </ext:DropDownList>
                </Items>
            </ext:FormRow>
            <ext:FormRow ID="FormRow3" runat="server">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" BodyPadding="5px" 
                        ShowBorder="false" ShowHeader="false" Layout="HBox" Height="200px" BoxConfigPadding="5px"
                        BoxConfigAlign="Stretch" BoxConfigPosition="Right" BoxConfigChildMargin="0 5 0 0">
                        <Items>
                            <ext:Tree ID="treeLeftPermission" runat="server" AutoScroll="true" EnableArrows="true"
                                Title="可添加" OnNodeCommand="treeLeftPermission_NodeCommand" Height="200px" Width="250px">
                            </ext:Tree>
                            <ext:Tree ID="treeRightPermission" runat="server" AutoScroll="true" EnableArrows="true"
                                Title="已添加" OnNodeCommand="treeRightPermission_NodeCommand" Height="200px" Width="250px"
                                AbsoluteX="250">
                            </ext:Tree>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:FormRow>
            <ext:FormRow ID="FormRow4" runat="server">
                <Items>
                    <ext:Form ID="FormPermission" ShowBorder="false" ShowHeader="false" Title="" runat="server"
                        BodyPadding="10px">
                        <Rows>
                            <ext:FormRow ID="FormRow5" ColumnWidths="20% 80%" runat="server">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Visibility">
                                    </ext:Label>
                                    <ext:Tree runat="server" ID="MyTree1" OnNodeCheck="MyTree1_NodeCheck" Title="权限列表">
                                        <Toolbars>
                                            <ext:Toolbar ID="Toolbar2" runat="server">
                                                <Items>
                                                    <ext:CheckBox ID="MyTree1CheckAll" Text="全选" AutoPostBack="true" runat="server" OnCheckedChanged="MyTree1CheckAll_CheckedChanged">
                                                    </ext:CheckBox>
                                                </Items>
                                            </ext:Toolbar>
                                        </Toolbars>
                                    </ext:Tree>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:FormRow>
            <%-- <ext:FormRow ID="FormRow4" runat="server" >
                <Items>
                    <ext:CheckBox ID="cbSelectAll" runat="server" Text="全选" Label="品牌权限" 
                        AutoPostBack="True" OnCheckedChanged="cbSelectAll_CheckedChanged" >
                    </ext:CheckBox>
                </Items>
            </ext:FormRow>
            <ext:FormRow ID="FormRow5" runat="server">
                <Items>
                    <ext:CheckBoxList ID="ckblBrand" runat="server" ColumnNumber="3" ColumnVertical="false" >
                    </ext:CheckBoxList>
                </Items>
            </ext:FormRow>--%>
        </Rows>
    </ext:Form>
    <ext:HiddenField ID="RoleID" runat="Server">
    </ext:HiddenField>
    <%--    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm">
        <Items>
            <ext:TextBox ID="txtPassword1" runat="server" Label="密码验证" TextMode="Password" Required="true"
                ShowRedStar="true" CompareControl="txtPassword">
            </ext:TextBox>
            <ext:TextBox ID="txtTrueName" runat="server" Label="真实姓名">
            </ext:TextBox>
            <ext:RadioButtonList ID="rdblSex" runat="server" Label="性别" Width="100px">
                <ext:RadioItem Text="男" Value="1" Selected="true" />
                <ext:RadioItem Text="女" Value="0" />
            </ext:RadioButtonList>
            <ext:TextBox ID="txtPhone" runat="server" Label="Contact Phone">
            </ext:TextBox>
            <ext:TextBox ID="txtEmail" runat="server" Label="Email">
            </ext:TextBox>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssClass="showMessage">
            </ext:Label>
        </Items>
    </ext:SimpleForm>--%>
    <%--<div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置Edit角色信息</b>
    </div>
    <div style="padding-bottom: 10px;">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                Edit角色信息
            </th>
        </tr>
        <tr align="left">
            <td width="50%" valign="middle">
                初始权限名称
                <asp:TextBox ID="TxtNewname" runat="server"></asp:TextBox>&nbsp;
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <b>
                    <asp:Label ID="RoleLabel" runat="server"></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td height="30" valign="middle" colspan="2">
                <b>&nbsp;&nbsp; 权限类别</b>
                <asp:DropDownList ID="CategoryDownList" runat="server" AutoPostBack="True" Width="245px"
                    BackColor="GhostWhite" OnSelectedIndexChanged="CategoryDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td height="22" colspan="2">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                    <tr>
                        <td valign="top" align="center" width="43%">
                            <asp:ListBox ID="CategoryList" runat="server" Width="100%" Rows="15" BackColor="AliceBlue"
                                Font-Size="9pt" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                        <td align="center" valign="middle" width="14%">
                            <p>
                                <asp:Button ID="AddPermissionButton" runat="server" CssClass="submit" Text="Translate__Special_121_Start增加权限 >>Translate__Special_121_End"
                                    OnClick="AddPermissionButton_Click"></asp:Button></p>
                            <p>
                                <asp:Button ID="RemovePermissionButton" runat="server" CssClass="submit" Text="Translate__Special_121_Start<< 移除权限Translate__Special_121_End"
                                    OnClick="RemovePermissionButton_Click"></asp:Button></p>
                        </td>
                        <td valign="top" align="center" width="43%">
                            <asp:ListBox ID="PermissionList" runat="server" Width="100%" Rows="15" BackColor="AliceBlue"
                                Font-Size="9pt" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <th colspan="2" align="left">
                品牌列表
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBox ID="cbSelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbSelectAll_CheckedChanged"
                    Text="全选" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3" Width="100%">
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
    <div align="center">
    </div>
    <div style="margin-top: 10px; text-align: center;">
        <asp:Button ID="BtnUpName" runat="server" Text="保存" OnClick="BtnUpName_Click" CssClass="submit" />
        <asp:Button ID="button2" runat="server" Text="返回" OnClick="button2_Click" CssClass="submit" />
        <asp:Button ID="RemoveRoleButton" runat="server" Text="删除当前角色" OnClick="RemoveRoleButton_Click"
            CssClass="submit"></asp:Button>
    </div>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
