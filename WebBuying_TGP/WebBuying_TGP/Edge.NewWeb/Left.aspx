<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="Controls/CheckRight.ascx" %>

<%@ Page Language="c#" CodeBehind="Left.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Admin.Left" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>Left</title>
</head>
<body class="tree_bgcolor">
    <form id="Form2" method="post" runat="server">
    <table width="200" height="100%" border="0" cellpadding="0" cellspacing="0" class="tree_bgcolor">
        <tr>
            <td class="left1_bgimage">
            </td>
        </tr>
        <tr>
            <td height="100%" valign="top" class="leftbj_bgimage">
                <div align="left">
                    <font color="#314a72">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= strWelcome %></font></div>
                    <asp:TreeView ID="TreeView1" runat="server" SelectExpands="True">
                </asp:TreeView>
               
            </td>
        </tr>
        <tr>
            <td class="left2_bgimage">
            </td>
        </tr>
    </table>
  
    <uc1:CheckRight ID="CheckRight2" runat="server"></uc1:CheckRight>
    </form>
</body>
</html>
