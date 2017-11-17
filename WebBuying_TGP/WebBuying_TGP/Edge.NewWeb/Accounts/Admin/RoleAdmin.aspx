<%@ Page Language="c#" CodeBehind="RoleAdmin.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.Admin.RoleAdmin" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>Index</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Grid ID="Grid1" ShowHeader="false" runat="server" EnableCheckBoxSelect="True"
        DataKeyNames="RoleID,Description" ShowBorder="false" AllowPaging="false" ForceFit="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server">
                    </ext:Button>
                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" ConfirmText="确认删除？" OnClick="lbtnDel_Click"
                        runat="server">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
            <ext:TemplateField Width="60px" HeaderText="角色名">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
             <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="RoleID"
                DataIFrameUrlFormatString="viewrole.aspx?RoleID={0}" DataWindowTitleField="Description"
                DataWindowTitleFormatString="View" />
            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="RoleID"
                DataIFrameUrlFormatString="editrole.aspx?RoleID={0}" DataWindowTitleField="Description"
                DataWindowTitleFormatString="Edit" />
        </Columns>
    </ext:Grid>
    <ext:Window ID="Window1" Title="View" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <ext:Window ID="Window2" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="750px"
        Height="450px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px"
        Top="-1000px">
    </ext:Window>
    <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="4"></uc1:CheckRight>
    </form>
</body>
</html>
