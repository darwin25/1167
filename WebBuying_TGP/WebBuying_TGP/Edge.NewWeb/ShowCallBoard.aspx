<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="../Controls/checkright.ascx" %>

<%@ Page Language="c#" CodeBehind="ShowCallBoard.aspx.cs" AutoEventWireup="True"
    Inherits="Edge.Web.Admin.ShowCallBoard" %>

<%@ Register TagPrefix="uc1" TagName="CopyRight" Src="../Controls/CopyRight.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head runat="server">
    <title>show</title>
    <link href="style.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="Form2" method="post" runat="server">
    <div align="center">
        <table width="600" border="0" cellspacing="0" cellpadding="0" align="center">
            <tr>
                <td height="22">
                    <div align="right">
                        [ <a href="main.aspx" onclick="javascript:history.back();return false;">返回</a> ]
                    </div>
                </td>
            </tr>
        </table>
        <table width="600" border="0" align="center" cellpadding="5" cellspacing="0">
            <tr>
                <td bgcolor='<%=Application[SVASessionInfo.UserStyle.ToString()+"xtable_bgcolor"]%>'>
                    <table width="100%" border="1" cellpadding="5" cellspacing="0" bordercolorlight='<%=Application[SVASessionInfo.UserStyle.ToString()+"xtable_bordercolorlight"]%>'
                        bordercolordark='<%=Application[SVASessionInfo.UserStyle.ToString()+"xtable_bordercolordark"]%>'>
                        <tr>
                            <td height="22">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td height="22" align="center">
                                            <asp:Label ID="lblTitle" runat="server" Width="100%" Font-Bold="True" Font-Size="Small"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" align="center">
                                            <asp:Label ID="lblCreateDate" runat="server" Width="100%" Font-Italic="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="24" style="height: 24px">
                                            <asp:Label ID="lblContent" runat="server" Width="100%"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <uc1:CopyRight id="Copyright2" runat="server">
    </uc1:CopyRight>
    </form>
</body>
</html>
