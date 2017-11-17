<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_STOREGROUP.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show</title>
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
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="店铺资料">
                <Items>
                    <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                        Hidden="false">
                        <Rows>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="StoreGroupCode" runat="server" Label="Store Group Code">
                                    </ext:Label>
                                    <ext:Label ID="StoreGroupName1" runat="server" Label="店铺组名称1">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="StoreGroupName2" runat="server" Label="店铺组名称2">
                                    </ext:Label>
                                    <ext:Label ID="StoreGroupName3" runat="server" Label="店铺组名称3">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label runat="server" ID="StoreBrandCode" Label="Store Brand Code">
                                    </ext:Label>
                                    <ext:Label runat="server" ID="StoreBrandName" Label="Store Brand Name">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="店铺列表">
                <Items>
                    <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" DataKeyNames="StoreCode" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
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
    </form>
</body>
</html>
