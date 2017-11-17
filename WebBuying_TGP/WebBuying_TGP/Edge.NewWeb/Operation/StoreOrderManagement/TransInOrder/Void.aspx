<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Void.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.TransInOrder.Void" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Void</title>
</head>
<body>
    <form id="form1" runat="server">
     <ext:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />
    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" 
        runat="server" EnableCheckBoxSelect="false" DataKeyNames="TxnNo" ForceFit="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
            <ext:TemplateField Width="60px" HeaderText="Transaction Number">
                <ItemTemplate>
                    <asp:Label ID="lb_id" runat="server" Text='<%# Eval("TxnNo") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="Approval Code">
                <ItemTemplate>
                    <asp:Label ID="lblApproveCode" runat="server" Text='<%# Eval("ApproveCode") %>' ForeColor="Red"></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
        </Columns>
    </ext:Grid>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>

