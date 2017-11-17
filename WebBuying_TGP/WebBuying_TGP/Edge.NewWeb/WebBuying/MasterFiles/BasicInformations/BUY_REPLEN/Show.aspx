<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
    <link href="/res/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="375">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Basic Information">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowHeader="false" ShowBorder="false" runat="server"
                        LabelAlign="Right">
                        <Items>
                            <ext:Label ID="ReplenCode" runat="server" Label="Code">
                            </ext:Label>
                            <ext:Label runat="server" ID="UseReplenFormula" Label="Whether to use the replenishment formula">
                            </ext:Label>
                             <ext:Label runat="server" ID="ReplenFormulaID" Label="Formula">
                            </ext:Label>
                            <ext:Label ID="StoreID" runat="server" Label="Store">
                            </ext:Label>
                            <ext:Label ID="TargetType" runat="server" Label="Order Target Type" >
                            </ext:Label>
                            <ext:Label ID="FormStoreID" runat="server" Label="Order Target">
                            </ext:Label>
                            <ext:Label ID="VendorID" runat="server" Label="Order Target">
                            </ext:Label>
                            <ext:Label ID="CreateStartDate" runat="server" Label="Effective Date From" >
                            </ext:Label>
                            <ext:Label ID="CreateEndDate" runat="server" Label="Effective Date To" >
                            </ext:Label>
                            <ext:Label runat="server" ID="Status" Label="Status">
                            </ext:Label>
                            <ext:Label runat="server" ID="Priority" Label="Priority">
                            </ext:Label>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="Store Replenishment Details">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="EntityType,EntityNum" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" >
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Entity Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityTypeName" runat="server" Text='<%#Eval("EntityTypeName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Entity Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityNum" runat="server" Text='<%#Eval("EntityCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Minimum Stock Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblMinStockQty" runat="server" Text='<%#Eval("MinStockQty")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Normal Stock Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblRunningStockQty" runat="server" Text='<%#Eval("RunningStockQty")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Multiple of Order Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderRoundUpQty" runat="server" Text='<%#Eval("OrderRoundUpQty")%>'></asp:Label>
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
