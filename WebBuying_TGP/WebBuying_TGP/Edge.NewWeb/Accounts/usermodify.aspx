<%@ Page Language="c#" CodeBehind="usermodify.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.usermodify" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>usermodify</title>
</head>
<body >
    <form id="form1" runat="server">
   <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" LabelAlign="Right">
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
            <ext:TextBox ID="txtUserName" runat="server" Label="用户名" >
            </ext:TextBox>
            <ext:TextBox ID="txtTrueName" runat="server" Label="真实姓名">
            </ext:TextBox>
            <ext:RadioButtonList ID="rdblSex" runat="server" Label="用户性别" Width="200px">
                <ext:RadioItem Text="男" Value="1" Selected="true" />
                <ext:RadioItem Text="女" Value="0" />
            </ext:RadioButtonList>
            <ext:TextBox ID="txtPhone" runat="server" Label="Contact Phone">
            </ext:TextBox>
            <ext:TextBox ID="txtEmail" runat="server" Label="Email">
            </ext:TextBox>
        </Items>
    </ext:SimpleForm>
    <%--	<uc1:CheckRight id="CheckRight1" runat="server"></uc1:CheckRight>--%>
    </form>
</body>
</html>
