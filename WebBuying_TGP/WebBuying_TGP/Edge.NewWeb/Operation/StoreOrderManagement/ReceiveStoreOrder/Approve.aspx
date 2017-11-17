<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.ReceiveStoreOrder.Approve" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Approve</title>
</head>
<body >
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
   <%-- <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：<%=this.PageName %></b>
    </div>
    <div style="padding-bottom: 10px;">
    </div>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtablelist">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <th colspan="2" align="left">
                    <%=this.PageName %>
                </th>
            </tr>
            <tr>
                <td width="25%">
                    交易编号:
                </td>
                <td width="75%">
                    <asp:Label ID="TxnNo" runat="server" Text='<%#Eval("TxnNo") %>'></asp:Label>
                </td>
            </tr>
            <tr style="text-align: center; color: Red; font-size: large;">
                <td>
                    <%#Eval("ApprovalMsg")%>
                </td>
                <td>
                    <asp:Label ID="errorMsg" runat="server" Text='<%#Eval("ApproveCode") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td colspan="2" align="center">
                    <div style="text-align: center;">
                        <input type="button" value="关 闭" class="submit" onclick="javascript:window.top.tb_remove();parent.frames['sysMain'].location.href= 'List.aspx' " />
                    </div>
                </td>
            </tr>
            </table>
        </FooterTemplate>
    </asp:Repeater>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>

