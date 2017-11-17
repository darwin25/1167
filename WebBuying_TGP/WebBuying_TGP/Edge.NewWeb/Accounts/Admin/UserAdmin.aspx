<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>

<%@ Page Language="c#" CodeBehind="UserAdmin.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.Admin.UserAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Index</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
        EnableCheckBoxSelect="True" DataKeyNames="UserID,UserName" AllowPaging="true"
        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server">
                    </ext:Button>
                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
            <ext:TemplateField Width="60px" HeaderText="用户名">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="真实姓名">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("TrueName") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("SexName") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="Contact Phone">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Phone") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="电子邮件">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="UserName"
                DataIFrameUrlFormatString="../show.aspx?username={0}" DataWindowTitleFormatString="View"
                Title="View" />
            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="UserName"
                DataIFrameUrlFormatString="../userupdate.aspx?username={0}" DataWindowTitleFormatString="Edit"
                Title="Edit" />
        </Columns>
    </ext:Grid>
    <ext:Window ID="Window1" Title="View" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="550px">
    </ext:Window>
    <ext:Window ID="Window2" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="750px" Height="550px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px"
        Top="-1000px">
    </ext:Window>
    <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="3"></uc1:CheckRight>
    </form>
</body>
</html>
