<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_STOREGROUP.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="店铺列表">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:TextBox ID="StoreGroupCode" runat="server" Label="Store Group Code" Required="true" ShowRedStar="true"
                                Enabled="false" />
                            <ext:TextBox ID="StoreGroupName1" runat="server" Label="店铺组名称1" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="StoreGroupName2" runat="server" Label="店铺组名称2" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="StoreGroupName3" runat="server" Label="店铺组名称3" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:DropDownList runat="server" ID="StoreBrandCode" Label="Store Brand Code">
                            </ext:DropDownList>
                            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
                            </ext:Label>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="店铺列表">
                <Items>
                    <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="StoreCode" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar5" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnViewSearch" Icon="Add" runat="server" Text="添加店铺" OnClick="btnViewSearch_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnDeleteResultItem" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteResultItem_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnClearAllResultItem" Icon="Delete" runat="server" Text="清空" OnClick="btnClearAllResultItem_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
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
            </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    <ext:Window ID="WindowSearch" Hidden="true" EnableIFrame="true" runat="server" CloseAction="Hide"
        OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    </form>
</body>
</html>
