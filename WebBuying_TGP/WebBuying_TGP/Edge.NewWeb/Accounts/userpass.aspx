<%@ Page Language="c#" CodeBehind="userPass.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.userPass" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>userPass</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:TextBox ID="txtUserName" runat="server" Label="用户名">
            </ext:TextBox>
            <ext:TextBox ID="txtOldPassword" runat="server" Label="原密码" TextMode="Password">
            </ext:TextBox>
            <ext:TextBox ID="txtPassword" runat="server" Label="新密码" TextMode="Password">
            </ext:TextBox>
            <ext:TextBox ID="txtPassword1" runat="server" Label="新密码确认" TextMode="Password">
            </ext:TextBox>
        </Items>
    </ext:SimpleForm>
    <uc1:CheckRight ID="CheckRight1" runat="server"></uc1:CheckRight>
    </form>
</body>
</html>
