<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.StoreManager.POSStaff.Show" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="收款机员工信息">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:Label ID="StaffCode" runat="server" Label="收款机员工编号" />
                            <ext:Label ID="StaffName" runat="server" Label="收款机员工姓名" />
                        </Items>
                    </ext:SimpleForm>
                    <ext:Form ID="StaffLevelForm" ShowBorder="True" BodyPadding="5px" ShowHeader="False"
                        runat="server" LabelAlign="Right" Enabled="false">
                        <Rows>
                            <ext:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <ext:CheckBox ID="Cashier" runat="server" Label="收银员" />
                                    <ext:CheckBox ID="Sales" runat="server" Label="促销员" />
                                    <ext:CheckBox ID="Supervisor" runat="server" Label="管理员" />
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
