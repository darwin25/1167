<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>

<%@ Page Language="c#" ValidateRequest="false" CodeBehind="add.aspx.cs" AutoEventWireup="True"
    Inherits="Edge.Web.SysManage.add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>TreeAdd</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" LabelAlign="Right">
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
        <Items>
            <ext:TextBox ID="txtName" runat="server" Label="菜单名称">
            </ext:TextBox>
            <ext:DropDownList ID="ddlParent" runat="server" Label="父类" >
            </ext:DropDownList>
            <ext:TextBox ID="txtOrderId" runat="server" Label="排序号">
            </ext:TextBox>
            <ext:TextBox ID="txtUrl" runat="server" Label="链接路径">
            </ext:TextBox>
<%--            <ext:DropDownList ID="ddlImgUrl" Label="Translate__Special_121_Start图标(16x16)Translate__Special_121_End"
                runat="server">
            </ext:DropDownList>--%>
            <ext:DropDownList ID="ddlCategoryList" runat="server" Label="权限类别" 
                OnSelectedIndexChanged="ddlCategoryList_SelectedIndexChanged" 
                AutoPostBack="True" >
            </ext:DropDownList>
            <ext:DropDownList ID="ddlPermissionList" runat="server" Label="绑定权限" >
            </ext:DropDownList>
            <ext:TextBox ID="txtDescription" runat="server" Label="说明">
            </ext:TextBox>
            <ext:CheckBox ID="ckbKeshi" runat="server" Label="是否菜单可见" Text="">
            </ext:CheckBox>
        </Items>
    </ext:SimpleForm>
    <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="6"></uc1:CheckRight>
    </form>
</body>
</html>
