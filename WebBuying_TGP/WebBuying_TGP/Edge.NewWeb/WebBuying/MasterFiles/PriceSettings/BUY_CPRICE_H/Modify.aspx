<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H.Modify" %>

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
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Basic Information">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:TextBox ID="CPriceCode" runat="server" Label="Cost Code" Required="true" ShowRedStar="true"
                                Enabled="false" />
                            <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" OnSelectedIndexChanged="StoreCode_SelectedIndexChanged"
                                AutoPostBack="true">
                            </ext:DropDownList>
                            <ext:DropDownList ID="StoreGroupCode" runat="server" Label="Store Group Code" OnSelectedIndexChanged="StoreGroupCode_SelectedIndexChanged"
                                AutoPostBack="true">
                            </ext:DropDownList>
                            <ext:DropDownList ID="VendorCode" runat="server" Label="Supplier Code">
                            </ext:DropDownList>
                            <ext:DatePicker ID="StartDate" runat="server" Label="Price Effective Date">
                            </ext:DatePicker>
                            <ext:DatePicker ID="EndDate" runat="server" Label="Price Expiration Date" CompareControl="StartDate"
                                CompareOperator="GreaterThanEqual" CompareMessage="End date should be greater than start date">
                            </ext:DatePicker>
                            <ext:DropDownList ID="CurrencyCode" runat="server" Label="Currency Code">
                            </ext:DropDownList>
                            <ext:TextBox ID="Note" runat="server" Label="Remarks" />
                            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
                            </ext:Label>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Price List">
                <Items>
                    <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar5" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnViewSearch" Icon="Add" runat="server" Text="Add" OnClick="btnViewSearch_Click">
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
                            <ext:TemplateField Width="60px" HeaderText="Product Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Eval("ProdName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Gross Cost">
                                <ItemTemplate>
                                    <asp:Label ID="lblCPriceGrossCost" runat="server" Text='<%# Eval("CPriceGrossCost") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Net Cost Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblCPriceNetCost" runat="server" Text='<%# Eval("CPriceNetCost") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Trade Discount ">
                                <ItemTemplate>
                                    <asp:Label ID="lblCPriceDisc1" runat="server" Text='<%# Eval("CPriceDisc1") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Other Discounts">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("CPriceDisc2") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Special Discount">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("CPriceDisc3") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Discount 4">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("CPriceDisc4") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Purchase Qty">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("CPriceBuy") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Purchase Over Free">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("CPriceGet") %>'></asp:Label>
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
