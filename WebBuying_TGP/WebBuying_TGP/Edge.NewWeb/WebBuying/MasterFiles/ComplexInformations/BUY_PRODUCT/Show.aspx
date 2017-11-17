<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Show" %>
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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="220">
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
            <ext:Form ID="Form3"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Display" Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdCode" runat="server" Label="Product Code">
                            </ext:Label>
                            <ext:Label ID="ProdDesc1" runat="server" Label="Product Name 1">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdDesc2" runat="server" Label="Product Name 2">
                            </ext:Label>
                            <ext:Label ID="ProdDesc3" runat="server" Label="Product Name 3">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ScanDesc1" runat="server" Label="Ticket Print Name 1">
                            </ext:Label>
                            <ext:Label ID="ScanDesc2" runat="server" Label="Ticket Print Name 2">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ScanDesc3" runat="server" Label="Ticket Print Name 3">
                            </ext:Label>
                            <ext:Label ID="BrandCodeView" runat="server" Label="Brand">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="PackageSizeCode" runat="server" Label="Package Size">
                            </ext:Label>
                            <ext:Label ID="DepartCodeView" runat="server" Label="Department">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreCodeView" runat="server" Label="Applicable Store">
                            </ext:Label>
                            <ext:Label ID="MinOrderQty" runat="server" Label="Minimum Order Quantity">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="OrderTypeView" runat="server" Label="Applicable Order Type">
                            </ext:Label>
                            <ext:Label ID="WarehouseCodeView" runat="server" Label="Warehouse">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdClassCodeView" runat="server" Label="Goods Category">
                            </ext:Label>
                            <ext:Label ID="GapProdCode" runat="server" Label="Out of Stock Replacement Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ShelfLife" runat="server" Label="Shelf Life Days">
                            </ext:Label>
                            <ext:Label ID="ProdSpec" runat="server" Label="Details of Goods">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdLength" runat="server" Label="Product Length">
                            </ext:Label>
                            <ext:Label ID="ProdWidth" runat="server" Label="Product Width">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdHeight" runat="server" Label="Product Height">
                            </ext:Label>
                            <ext:Label ID="RefGP" runat="server" Label="Proportion of Gross Profit for Consignment">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="NonOrderView" runat="server" Label="Non-Order Goods">
                            </ext:Label>
                            <ext:Label ID="NonSaleView" runat="server" Label="Non-Retail Goods">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ConsignmentView" runat="server" Label="Consignment Goods">
                            </ext:Label>
                            <ext:Label ID="WeightItemView" runat="server" Label="Goods are Sold by Weight">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="DiscAllowView" runat="server" Label="Allow Discounts">
                            </ext:Label>
                            <ext:Label ID="CouponAllowView" runat="server" Label="Allow Coupons to Pay">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow15" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="VisuaItemView" runat="server" Label="Virtual Goods">
                            </ext:Label>
                            <ext:Label ID="TaxRate" runat="server" Label="Tax Rate">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow34" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="isOnlineSKUView" runat="server" Label="Is Online SKU">
                            </ext:Label>
                            <ext:Label ID="Label3" runat="server" Label="" Hidden="true">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow16" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ImportTax" runat="server" Label="Import Tax Rate">
                            </ext:Label>
                            <ext:Label ID="Insurance" runat="server" Label="Insurance Rate">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow17" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Freight" runat="server" Label="Freight">
                            </ext:Label>
                            <ext:Label ID="OthersExpense" runat="server" Label="Other Fee">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow18" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="OriginCountryCode" runat="server" Label="Origin">
                            </ext:Label>
                            <ext:Label ID="ProductTypeView" runat="server" Label="Type of Goods">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow19" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ModifierView" runat="server" Label="Allow Modification">
                            </ext:Label>
                            <ext:Label ID="BOMView" runat="server" Label="BOM">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow30" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="MutexFlagView" runat="server" Label="Mutually Exclusive">
                            </ext:Label>
                            <ext:Label ID="OnAccountView" runat="server" Label="Allow Book Sales">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow20" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="FulfillmentHouseCodeView" runat="server" Label="Warehouse Number">
                            </ext:Label>
                            <ext:Label ID="ReplenFormulaCodeView" runat="server" Label="Automatic Replenishment Formula Number">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow21" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="DiscountLimit" runat="server" Label="Max Percentage Discount Allowed">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow22" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CostCCC" runat="server" Label="Cost Center Code">
                            </ext:Label>
                            <ext:Label ID="CostWO" runat="server" Label="Work Order Number">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow23" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="RevenueCCC" runat="server" Label="Revenue CCC">
                            </ext:Label>
                            <ext:Label ID="RevenueWO" runat="server" Label="Revenue WO">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow24" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="QuotaPerShopPeriod" runat="server" Label="Quota per Store per Period">
                            </ext:Label>
                            <ext:Label ID="CouponSKUView" runat="server" Label="Translate__Special_121_Start是否Coupon货品Translate__Special_121_End">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow25" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StartDate" runat="server" Label="Start Date">
                            </ext:Label>
                            <ext:Label ID="EndDate" runat="server" Label="End Date">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow26" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="DefaultPickupStoreCodeView" runat="server" Label="Default Delivery Warehouse">
                            </ext:Label>
                            <ext:Label ID="ColorCodeView" runat="server" Label="Color of Goods">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow31" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProductSizeCodeView" runat="server" Label="Item Size">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow27" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="InTax" runat="server" Label="Supplier's Import Tax Rate">
                            </ext:Label>
                            <ext:Label ID="Additional" runat="server" Label="Additional Information">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow32" runat="server">
                        <Items>
                            <ext:Form ID="Form2"   ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow33" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath" Hidden="true" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label1" Text="" runat="server" Label="Picture of Goods">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow28" runat="server">
                        <Items>
                            <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                            </ext:Label>
                            <ext:Label ID="CreatedBy" runat="server" Label="Created By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow29" runat="server">
                        <Items>
                            <ext:Label ID="UpdatedOn" runat="server" Label="Last Modified Date Time">
                            </ext:Label>
                            <ext:Label ID="UpdatedBy" runat="server" Label="Last Modified By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:DropDownList ID="BrandCode" runat="server" Label="Brand Code"  Hidden="true"/>
            <ext:DropDownList ID="ProductSizeCode" runat="server" Label="Item Size Code"  Hidden="true"/>
            <ext:DropDownList ID="DepartCode" runat="server" Label="Department Code"  Hidden="true"/>
            <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code"  Hidden="true"/>
            <ext:DropDownList ID="OrderType" runat="server" Label="Applicable Order Type"  Hidden="true">
                <ext:ListItem Text="All" Value="0" />
                <ext:ListItem Text="WH Order (Order at Buying) " Value="1" />
                <ext:ListItem Text="Store Order (Order at Store)" Value="2" />
                <ext:ListItem Text="Center Order (Order at Buying)" Value="3" />
            </ext:DropDownList>
            <ext:DropDownList ID="WarehouseCode" runat="server" Label="Warehouse Code"  Hidden="true"/>
            <ext:DropDownList ID="ProdClassCode" runat="server" Label="Product Category Code"  Hidden="true"/>
            <ext:RadioButtonList ID="NonOrder" runat="server" Label="Non-Order Goods" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="NonSale" runat="server" Label="Non-Retail Goods" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Consignment" runat="server" Label="Consignment Goods" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="WeightItem" runat="server" Label="Goods are Sold by Weight" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="DiscAllow" runat="server" Label="Allow Discounts" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="Not Allowed" Value="0"/>
                <ext:RadioItem Text="Allowed" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CouponAllow" runat="server" Label="Allow Coupons to Pay" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="Not Allowed" Value="0"/>
                <ext:RadioItem Text="Allowed" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="VisuaItem" runat="server" Label="Virtual Goods" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="isOnlineSKU" runat="server" Label="Is Online SKU" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:DropDownList ID="ProductType" runat="server" Label="Type of Goods"  Hidden="true">
                <ext:ListItem Text="All Stocks" Value="1" />
                <ext:ListItem Text="Local Stock" Value="2" />
                <ext:ListItem Text="Service" Value="3" />
            </ext:DropDownList>
            <ext:RadioButtonList ID="Modifier" runat="server" Label="Allow Modification" Hidden="true">
                <ext:RadioItem Text="Not Allowed" Value="0" />
                <ext:RadioItem Text="Allowed" Value="1" />
            </ext:RadioButtonList>

            <ext:RadioButtonList ID="BOM" runat="server" Label="BOM" Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="true"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="MutexFlag" runat="server" Label="Mutually Exclusive" Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="true"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="OnAccount" runat="server" Label="Allow Book Sales" Hidden="true">
                <ext:RadioItem Text="Not Allowed" Value="0"/>
                <ext:RadioItem Text="Allowed" Value="1" Selected="true"/>
            </ext:RadioButtonList>
            <ext:DropDownList ID="FulfillmentHouseCode" runat="server" Label="Warehouse Number"  Hidden="true"></ext:DropDownList>
            <ext:DropDownList ID="ReplenFormulaCode" runat="server" Label="Automatic Replenishment Formula Number"  Hidden="true"></ext:DropDownList>
            <ext:RadioButtonList ID="CouponSKU" runat="server" Label="Coupon Goods" Hidden="true">
                <ext:RadioItem Text="No" Value="0"/>
                <ext:RadioItem Text="Yes" Value="1"/>
            </ext:RadioButtonList>
            <ext:DropDownList ID="DefaultPickupStoreCode" runat="server" Label="Default Delivery Warehouse Code" Hidden="true"></ext:DropDownList>
            <ext:DropDownList ID="ColorCode" runat="server" Label="Color Code" Hidden="true"></ext:DropDownList>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="750px"
        Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
