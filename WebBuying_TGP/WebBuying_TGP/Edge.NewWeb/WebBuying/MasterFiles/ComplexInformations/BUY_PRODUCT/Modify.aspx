<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Modify" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" >
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
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="180">
                        <Items>
                            <ext:TextBox ID="ProdCode" runat="server" Label="Product Code" Required="true" ShowRedStar="true"
                                Enabled="false" />
                            <ext:TextBox ID="ProdDesc1" runat="server" Label="Product Name1" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="ProdDesc2" runat="server" Label="Product Name2" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="ProdDesc3" runat="server" Label="Product Name3" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="ScanDesc1" runat="server" Label="Scan Print Name 1" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="ScanDesc2" runat="server" Label="Scan Print Name2" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="ScanDesc3" runat="server" Label="Scan Print Name3" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:DropDownList ID="BrandCode" runat="server" Label="Brand Code" />
                            <ext:TextBox ID="PackageSizeCode" runat="server" Label="Package Size Code" />
                            <ext:DropDownList ID="DepartCode" runat="server" Label="Department Code" />
                            <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" />
                            <ext:NumberBox ID="MinOrderQty" runat="server" Label="Minimum Order Quantity" DecimalPrecision="2"
                                Text="1">
                            </ext:NumberBox>
                            <ext:DropDownList ID="OrderType" runat="server" Label="Applicable Order Type">
                                <ext:ListItem Text="All" Value="0" Selected="true" />
                                <ext:ListItem Text="WH Order (Order at Buying) " Value="1" />
                                <ext:ListItem Text="Store Order (Order at Store)" Value="2" />
                                <ext:ListItem Text="Center Order (Order at Buying)" Value="3" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="WarehouseCode" runat="server" Label="Warehouse Code" />
                            <ext:DropDownList ID="ProdClassCode" runat="server" Label="Product Category Code" />
                            <ext:TextBox ID="GapProdCode" runat="server" Label="Out of Stock Replacement Code">
                            </ext:TextBox>
                            <ext:NumberBox ID="ShelfLife" runat="server" Label="Shelf Life Days">
                            </ext:NumberBox>
                            <ext:TextBox ID="ProdSpec" runat="server" Label="Details of Goods" />
                            <ext:NumberBox ID="ProdLength" runat="server" Label="Product Length" DecimalPrecision="2" Text="1">
                            </ext:NumberBox>
                            <ext:NumberBox ID="ProdWidth" runat="server" Label="Product Width" DecimalPrecision="2" Text="1">
                            </ext:NumberBox>
                            <ext:NumberBox ID="ProdHeight" runat="server" Label="Product Height" DecimalPrecision="2" Text="1">
                            </ext:NumberBox>
                            <ext:NumberBox ID="RefGP" runat="server" Label="Proportion of Gross Profit for Consignment" DecimalPrecision="2" Text="1">
                            </ext:NumberBox>
                            <ext:RadioButtonList ID="NonOrder" runat="server" Label="Non-Order Goods">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="NonSale" runat="server" Label="Non-Retail Goods">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="Consignment" runat="server" Label="Consignment Goods">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="WeightItem" runat="server" Label="Goods are Sold by Weight">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="DiscAllow" runat="server" Label="Allow Discounts">
                                <ext:RadioItem Text="Not Allowed" Value="0" Selected="true" />
                                <ext:RadioItem Text="Allowed" Value="1" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="CouponAllow" runat="server" Label="Allow Coupons to Pay">
                                <ext:RadioItem Text="Not Allowed" Value="0" />
                                <ext:RadioItem Text="Allowed" Value="1" Selected="true" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="VisuaItem" runat="server" Label="Virtual Goods">
                                <ext:RadioItem Text="No" Value="0" />
                                <ext:RadioItem Text="Yes" Value="1" Selected="true" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="isOnlineSKU" runat="server" Label="Is Online SKU">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:NumberBox ID="TaxRate" runat="server" Label="Tax Rate" DecimalPrecision="2" Text="0">
                            </ext:NumberBox>
                            <ext:NumberBox ID="ImportTax" runat="server" Label="Import Tax Rate" DecimalPrecision="2" Text="0">
                            </ext:NumberBox>
                            <ext:NumberBox ID="Insurance" runat="server" Label="Insurance Rate" DecimalPrecision="2" Text="0">
                            </ext:NumberBox>
                            <ext:NumberBox ID="Freight" runat="server" Label="Freight" DecimalPrecision="2" Text="0">
                            </ext:NumberBox>
                            <ext:NumberBox ID="OthersExpense" runat="server" Label="Other Fee" DecimalPrecision="2"
                                Text="0">
                            </ext:NumberBox>
                            <ext:TextBox ID="OriginCountryCode" runat="server" Label="Origin">
                            </ext:TextBox>
                            <ext:DropDownList ID="ProductType" runat="server" Label="Type of Goods">
                                <ext:ListItem Text="All Stocks" Value="1" Selected="true" />
                                <ext:ListItem Text="Local Stock" Value="2" />
                                <ext:ListItem Text="Service" Value="3" />
                            </ext:DropDownList>
                            <ext:RadioButtonList ID="Modifier" runat="server" Label="Allow Modification">
                                <ext:RadioItem Text="Not Allowed" Value="0" />
                                <ext:RadioItem Text="Allowed" Value="1" Selected="true" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="BOM" runat="server" Label="BOM"
                                OnSelectedIndexChanged="BOM_SelectedIndexChanged" AutoPostBack="true">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="MutexFlag" runat="server" Label="Mutually Exclusive" Enabled="false">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:RadioButtonList ID="OnAccount" runat="server" Label="Allow Book Sales">
                                <ext:RadioItem Text="Not Allowed" Value="0" />
                                <ext:RadioItem Text="Allowed" Value="1" Selected="true" />
                            </ext:RadioButtonList>
                            <ext:DropDownList ID="FulfillmentHouseCode" runat="server" Label="Warehouse Number">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ReplenFormulaCode" runat="server" Label="Automatic Replenishment Formula Number">
                            </ext:DropDownList>
                            <ext:NumberBox ID="DiscountLimit" runat="server" Label="Max Percentage Discount Allowed" DecimalPrecision="2"
                                Text="100">
                            </ext:NumberBox>
                            <ext:TextBox ID="CostCCC" runat="server" Label="Cost Center Code" />
                            <ext:TextBox ID="CostWO" runat="server" Label="Work Order Number" />
                            <ext:TextBox ID="RevenueCCC" runat="server" Label="Revenue CCC" />
                            <ext:TextBox ID="RevenueWO" runat="server" Label="Revenue WO"/>
                            <ext:RadioButtonList ID="CouponSKU" runat="server" Label="Coupon Goods">
                                <ext:RadioItem Text="No" Value="0" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:DatePicker ID="StartDate" runat="server" Label="Start Date">
                            </ext:DatePicker>
                            <ext:DatePicker ID="EndDate" runat="server" Label="End Date" CompareControl="StartDate"
                                CompareOperator="GreaterThanEqual" CompareMessage="End date should be greater than start date">
                            </ext:DatePicker>
                            <ext:DropDownList ID="DefaultPickupStoreCode" runat="server" Label="Default Delivery Warehouse Code">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ColorCode" runat="server" Label="Color Code">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ProductSizeCode" runat="server" Label="Item Size Code">
                            </ext:DropDownList>
                            <ext:NumberBox ID="InTax" runat="server" Label="Supplier's Import Tax Rate">
                            </ext:NumberBox>
                            <ext:TextBox ID="Additional" runat="server" Label="Additional Information">
                            </ext:TextBox>
                            <ext:Form ID="FormLoad" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Offsets">
                                <Rows>
                                    <ext:FormRow ID="FormRow1" ColumnWidths="0% 80% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath" Hidden="true" Text="" runat="server">
                                            </ext:Label>
                                            <ext:FileUpload ID="ProdPicFile" runat="server" Label="Picture of Goods">
                                            </ext:FileUpload>
                                            <ext:Button ID="btnBack" runat="server" Text="返回" HideMode="Display" Hidden="true"
                                                OnClick="btnBack_Click">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                            <ext:Form ID="FormReLoad" ShowBorder="false" ShowHeader="false" Title="" runat="server"
                                HideMode="Display" Hidden="true">
                                <Rows>
                                    <ext:FormRow ID="FormRow2" ColumnWidths="69% 11% 20%" runat="server">
                                        <Items>
                                            <ext:Label ID="Label7" runat="server" Label="Picture of Goods">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview" runat="server" Text="View" HideMode="Display" Icon="Picture">
                                            </ext:Button>
                                            <ext:Button ID="btnReUpLoad" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad_Click">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
                            </ext:Label>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Barcode">
                <Items>
                    <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="Barcode" AllowPaging="true"
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
                            <ext:TemplateField Width="60px" HeaderText="Barcode">
                                <ItemTemplate>
                                    <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("Barcode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="Retail Price">
                <Items>
                    <ext:Grid ID="AddResultListGrid2" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid2_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar2" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnViewSearch2" Icon="Add" runat="server" Text="Add" OnClick="btnViewSearch2_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnDeleteResultItem2" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteResultItem2_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnClearAllResultItem2" Icon="Delete" runat="server" Text="清空" OnClick="btnClearAllResultItem2_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Price Effective Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("StartDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Price Expiration Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("EndDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Retail Price Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("RPriceTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Retail Price">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Reference price">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("RefPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Member Price">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("MemberPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="Cost Price">
                <Items>
                    <ext:SimpleForm ID="SimpleForm3" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:DatePicker ID="StartDate1" runat="server" Label="Price Effective Date">
                            </ext:DatePicker>
                            <ext:DatePicker ID="EndDate1" runat="server" Label="Price Expiration Date">
                            </ext:DatePicker>
                            <ext:TextBox ID="CPriceGrossCost" runat="server" Label="Gross Cost" OnTextChanged="ConvertTextboxToDecimal"
                                AutoPostBack="true" />
                            <ext:TextBox ID="CPriceDisc1" runat="server" Label="Trade Discount " OnTextChanged="ConvertTextboxToDecimal"
                                AutoPostBack="true" />
                            <ext:TextBox ID="CPriceDisc2" runat="server" Label="Other Discounts" OnTextChanged="ConvertTextboxToDecimal"
                                AutoPostBack="true" />
                            <ext:TextBox ID="CPriceDisc3" runat="server" Label="Special Discount" OnTextChanged="ConvertTextboxToDecimal"
                                AutoPostBack="true" />
                            <ext:TextBox ID="CPriceDisc4" runat="server" Label="Discount 4" OnTextChanged="ConvertTextboxToDecimal"
                                AutoPostBack="true" />
                            <ext:TextBox ID="CPriceNetCost" runat="server" Label="Net Cost Price" OnTextChanged="ConvertTextboxToDecimal"
                                AutoPostBack="true" />
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    <ext:Window ID="WindowSearch" Hidden="true" EnableIFrame="true" runat="server" CloseAction="Hide"
        OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px" OnClose="WindowPic_Close">
    </ext:Window>
    </form>
</body>
</html>
