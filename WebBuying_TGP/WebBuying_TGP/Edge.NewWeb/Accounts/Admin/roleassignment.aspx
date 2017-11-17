<%@ Page Language="c#" CodeBehind="RoleAssignment.aspx.cs" AutoEventWireup="True"
    Inherits="Edge.Web.Accounts.Admin.RoleAssignment" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>Index</title>
    <%--		<META http-equiv="Content-Type" content="text/html; charset=gb2312">--%>
</head>
<body style="padding: 10px;">
    <form id="Form1" method="post" runat="server">
    <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：角色分配</b>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <td align="center" height="25">
                <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="22">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3" Width="100%">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="BtnOk" runat="server" Text="确定" OnClick="BtnOk_Click" CssClass="submit" />
                <asp:Button ID="Btnback" runat="server" Text="返回" OnClick="Btnback_Click" CssClass="submit" />
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; text-align: center;">
    </div>
    <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="4"></uc1:CheckRight>
    </form>
</body>
</html>
