<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.PickingStoreOrder.Print" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<%@ Register assembly="GrapeCity.ActiveReports.Web.v10, Version=10.0.5602.0, Culture=neutral, PublicKeyToken=cc4967777c49a3ff" namespace="GrapeCity.ActiveReports.Web" tagprefix="ActiveReportsWeb" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>打印</title>
</head>
<body>
    <form name="formSubmit" id="formSubmit" runat="server" method="post" action="/Operation/StoreOrderManagement/PickingStoreOrder/Print.aspx">
    <ext:PageManager ID="PageManager1" runat="server"  />
    <input type="hidden" id="hid_do" name="hid_do" runat="server" />
    <input type="hidden" id="hidID" name="hidID" runat="server" />
    <input type="hidden" id="hidUrl" name="hidUrl" runat="server" />
    <ActiveReportsWeb:WebViewer ID="WebViewerPickingStoreOrder" runat="server" Width="100%"
        ViewerType="FlashViewer" BorderStyle="None" Height="550" BackColor="White">
        <flashvieweroptions multipageviewcolumns="1" multipageviewrows="1" url="/Flash/Grapecity.ActiveReports.Flash.v10.swf"  
            resourceurl="/Flash/Grapecity.ActiveReports.Flash.v10.Resources.swf">
           <PrintOptions AdjustPaperOrientation="None" />
        </flashvieweroptions>
    </ActiveReportsWeb:WebViewer>
    </form>
    <uc2:checkright ID="Checkright1" runat="server" />
</body>
</html>