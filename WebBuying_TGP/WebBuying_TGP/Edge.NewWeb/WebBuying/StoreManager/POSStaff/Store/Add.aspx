<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.StoreManager.POSStaff.Store.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="3px"
        Title="" AutoScroll="true">
        <Items>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button ID="btnCloseSearch" Icon="SystemClose" runat="server" Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnAddSearchItem" Icon="Add" runat="server" Text="Add" OnClick="btnAddSearchItem_Click">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
            <ext:Panel ID="Panel2" runat="server" EnableCollapse="True" AutoScroll="true" BodyPadding="3px"
                ShowHeader="false" ShowBorder="false">
                <Items>
                    <ext:Panel ID="Panel11" runat="Server" BodyPadding="3px" ShowHeader="false" ShowBorder="false"
                        Layout="Column">
                        <Items>
                            <ext:CheckBox ID="cbSearchAll" runat="server" AutoPostBack="true" OnCheckedChanged="cbSearchAll_OnCheckedChanged"
                                Text="Add all search results">
                            </ext:CheckBox>
                        </Items>
                    </ext:Panel>
                    <ext:Grid ID="SearchListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="StoreCode" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true"  OnPageIndexChange="RegisterGrid_OnPageIndexChange"
                        ClearSelectedRowsAfterPaging="false">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Store Code" SortField="StoreCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreCode" runat="server" Text='<%# Eval("StoreCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Store Name1">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreName1" runat="server" Text='<%# Eval("StoreName1") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:HiddenField ID="hfSelectedIDS" runat="server" />
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
