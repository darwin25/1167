<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.SalesPickOrder.Export" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Assembly="GrapeCity.ActiveReports.Web.v10, Version=10.0.5602.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="GrapeCity.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Export</title>
</head>
<body>
    <form name="formSubmit" id="formSubmit" runat="server" metohd="post" action="/Operation/StoreOrderManagement/SalesPickOrder/Export.aspx">
    <input type="hidden" id="hidIds" runat="server" />
    <input type="hidden" id="hidUrl" name="hidUrl" runat="server" />
    <input type="hidden" id="hidlanguage" name="hidlanguage" runat="server" />
    <div style="margin-bottom: 10px;">
        <asp:Button ID="btnWord" runat="server" Text="Word" UseSubmitBehavior="False" CssClass="options_button"
            OnClick="btnWord_Click" />
        <table>
            <tr>
                <td>
                    导出/打印方式：
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlShow" AutoPostBack="true" OnSelectedIndexChanged="ddlShow_SelectedIndexChanged " Width="100"  >
                        <asp:ListItem Value="1" Text="按订单" />
                        <asp:ListItem Value="2" Text="按会员" />
                        <asp:ListItem Value="3" Text="按产品编号" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel runat="server" ID="pnShow">
        <ActiveReportsWeb:WebViewer ID="WebViewerShipmentSalesPickOrderList" runat="server"
            Height="650" Width="100%" ViewerType="FlashViewer">
            <FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1" Url="/Flash/Grapecity.ActiveReports.Flash.v10.swf"
                ResourceUrl="/Flash/Grapecity.ActiveReports.Flash.v10.Resources.swf" >
            </FlashViewerOptions>
        </ActiveReportsWeb:WebViewer>
    </asp:Panel>
    </form>
    <uc2:checkright ID="Checkright1" runat="server" />
</body>
</html>
