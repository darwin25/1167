<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TempImage.aspx.cs" Inherits="Edge.Web.TempImage" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server">
    </ext:PageManager>
        <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="1px">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Image ID="img" runat="server" ImageUrl="" ShowLabel="false" ImageWidth="700px">
            </ext:Image>
            <%--<asp:Image ID="img" runat="server" Width="700px"/>--%>
        </Items>
    </ext:SimpleForm>
    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <td style="text-align: center;">
                <asp:Label ID="" runat="server"></asp:Label>
                <asp:Image ID="img" runat="server" Width="700px"/>
            </td>
        </tr>
    </table>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
