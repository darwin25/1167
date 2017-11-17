<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>

<%@ Page Language="c#" CodeBehind="userinfo.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.userinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>userinfo</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" LabelAlign="Right">
       <%-- <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>--%>
        <Items>
            <ext:Label ID="lblName" runat="server" Label="用户名">
            </ext:Label>
            <ext:Label ID="lblTrueName" runat="server" Label="真实姓名" >
            </ext:Label>
            <ext:RadioButtonList ID="rdblSex" runat="server" Enabled="false" Label="性别" Width="200px" Hidden="true">
                <ext:RadioItem Text="男" Value="1" />
                <ext:RadioItem Text="女" Value="0" />
            </ext:RadioButtonList>
            <ext:Label ID="lblSex" runat="server" Label="性别">
            </ext:Label>
            <ext:Label ID="lblPhone" runat="server" Label="Contact Phone">
            </ext:Label>
            <ext:Label ID="lblEmail" runat="server" Label="Email">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc1:CheckRight ID="CheckRight1" runat="server"></uc1:CheckRight>
    </form>
</body>
</html>
