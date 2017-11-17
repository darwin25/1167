<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Void.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponRedeem.Void" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <ext:PageManager ID="PageManager1" runat="server" />

        <ext:Window ID="Window1" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
            CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
            Target="Top" IsModal="True" Width="230px" Height="100px" AutoScroll="false"> 
        </ext:Window>

    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
