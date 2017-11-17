<%@ Page Language="c#" CodeBehind="LogIndex.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.SysManage.LogIndex" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>Index</title>
</head>
<body >
    <form id="Form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" 
        PageSize="3" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID"
        AllowPaging="true" IsDatabasePaging="true" ForceFit="true" onpageindexchange="Grid1_PageIndexChange">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
                    </ext:Button>
                        <ext:Button ID="btnDeleteAll" Text="清除全部日志" Icon="Delete" OnClick="lbtnDelAll_Click" runat="server">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
          <ext:TemplateField Width="60px" HeaderText="Code">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="日期">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("datetime") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
               <ext:TemplateField Width="60px" HeaderText="时间">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("datetime") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
               <ext:TemplateField Width="60px" HeaderText="信息">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("loginfo") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField> 
          <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page" Text="View"
               
                DataWindowTitleField="ID" DataWindowTitleFormatString="View" />
        </Columns>
    </ext:Grid>
    <ext:Window ID="Window1" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="750px"
        Height="450px">
    </ext:Window>
    <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="5"></uc1:CheckRight>
    </form>
</body>
</html>
