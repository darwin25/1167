<%@ Page language="c#" Codebehind="LogShow.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.SysManage.LogShow" %>
<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<head id="Head1" runat="server">
		<title>LogShow</title>
    </head>
	<body >
    <form id="Form1" method="post" runat="server">	
      <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm">
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
            <ext:Label ID="lblTime" runat="server" Label="出错时间">
            </ext:Label>
            <ext:Label ID="lblErrMsg" runat="server" Label="错误信息">
            </ext:Label>
            <ext:Label ID="lblParticular" runat="server" Label="堆栈详细">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
     <uc1:CheckRight id="CheckRight1" runat="server"></uc1:CheckRight>
     </form>
	</body>
</HTML>
