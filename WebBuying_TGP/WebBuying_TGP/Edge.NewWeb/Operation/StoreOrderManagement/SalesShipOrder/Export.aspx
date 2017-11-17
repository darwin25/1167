<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.SalesShipOrder.Export" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register Assembly="GrapeCity.ActiveReports.Web.v10, Version=10.0.5602.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff"
    Namespace="GrapeCity.ActiveReports.Web" TagPrefix="ActiveReportsWeb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Export</title>
</head>
<body>
    <form name="formSubmit" id="formSubmit" runat="server" metohd="post" action="/Operation/StoreOrderManagement/SalesShipOrder/Export.aspx">
    <input type="hidden" id="hidIds" runat="server" />
    <input type="hidden" id="hidTxnNos" runat="server" />
    <input type="hidden" id="hidUrl" name="hidUrl" runat="server" />
    <input type="hidden" id="hidlanguage" name="hidlanguage" runat="server" />
    <div style="margin-bottom: 10px;">
        <asp:Button ID="btnWord" runat="server" Text="Word" UseSubmitBehavior="False" CssClass="options_button"
            OnClick="btnWord_Click" />
        <ActiveReportsWeb:WebViewer ID="WebViewerShipmentSalesShipOrderList" runat="server"
            Height="650" Width="100%" ViewerType="FlashViewer">
            <FlashViewerOptions MultiPageViewColumns="1" MultiPageViewRows="1"  
                url="/Flash/Grapecity.ActiveReports.Flash.v10.swf"   
                resourceurl="/Flash/Grapecity.ActiveReports.Flash.v10.Resources.swf" 
                ResourceLocale="">
            </FlashViewerOptions>
        </ActiveReportsWeb:WebViewer>
    </div>
    </form>
    <uc2:checkright ID="Checkright1" runat="server" />
</body>
</html>
