<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EOD.aspx.cs" Inherits="Edge.Web.Operation.AppOperation.EOD" %>


<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EOD</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" LabelAlign="Right">
       <%-- <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    
                </Items>
            </ext:Toolbar>
        </Toolbars>--%>
        <Items>
            <ext:Label ID="lbNowBusDate" runat="server" Label="当前工作日" Text="">
            </ext:Label>
            <ext:LinkButton ID="lbSODEOD" runat="server" Text="SOD/EOD" OnClick="lbSODEOD_Click">
            </ext:LinkButton>
        </Items>
    </ext:SimpleForm>

<%--    <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：<%=this.PageName %></b>
    </div>
    <div style="padding-bottom: 10px;">
        
    </div>
    <div style="text-align:center;padding-top:40px;">
    <asp:Label ID="" runat="server" Text=""></asp:Label><br /><br />
    <span class="btn_bg"><asp:LinkButton ID="" runat="server" onclick=""></asp:LinkButton></span>    
    </div>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
