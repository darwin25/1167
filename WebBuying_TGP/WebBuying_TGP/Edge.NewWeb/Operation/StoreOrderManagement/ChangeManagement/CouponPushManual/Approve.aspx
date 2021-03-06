﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual.Approve" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />
    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" AutoHeight="true"
        runat="server" EnableCheckBoxSelect="false" DataKeyNames="TxnNo" EnableRowNumber="True" AutoWidth="true"
        ForceFitAllTime="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
            <ext:TemplateField Width="60px" HeaderText="交易编号">
                <ItemTemplate>
                    <asp:Label ID="lb_id" runat="server" Text='<%# Eval("TxnNo") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="授权号">
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
