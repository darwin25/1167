<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT.Show" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="180">
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
            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="DepartCode" runat="server" Label="Department Code">
                            </ext:Label>
                            <ext:Label ID="DepartName1" runat="server" Label="Department Name 1">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="DepartName2" runat="server" Label="Department Name 2">
                            </ext:Label>
                            <ext:Label ID="DepartName3" runat="server" Label="Department Name 3">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow22" runat="server" ColumnWidths="50%">
                        <Items>
                            <ext:Label runat="server" ID="StoreBrandCode" Label="Store Brand Code">
                            </ext:Label>
                            <ext:Label runat="server" ID="StoreBrandName" Label="Store Brand Name">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:Form ID="Form2" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow2" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath" Hidden="true" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label1" Text="" runat="server" Label="Department Picture File">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server">
                        <Items>
                            <ext:Form ID="Form4" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow4" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath1" Hidden="true" Text="" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label2" Text="" runat="server" Label="Department Picture File 2">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview1" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server">
                        <Items>
                            <ext:Form ID="Form5" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow6" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath2" Hidden="true" Text="" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label3" Text="" runat="server" Label="Department Picture File 3">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview2" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server">
                        <Items>
                            <ext:Label ID="DepartNote" runat="server" Label="Department Notes">
                            </ext:Label>
                            <ext:Label ID="ReplenFormulaCodeView" runat="server" Label="Replenishment Formula Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server">
                        <Items>
                            <ext:Label ID="FulfillmentHouseCodeView" runat="server" Label="Supply Warehouse Code">
                            </ext:Label>
                            <ext:Label ID="CostCCC" runat="server" Label="Cost Center Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow13" runat="server">
                        <Items>
                            <ext:Label ID="CostWO" runat="server" Label="Work Order Number">
                            </ext:Label>
                            <ext:Label ID="RevenueCCC" runat="server" Label="Revenue CCC">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow14" runat="server">
                        <Items>
                            <ext:Label ID="RevenueWO" runat="server" Label="Revenue WO">
                            </ext:Label>
                            <ext:Label ID="NonOrderView" runat="server" Label="Non-Order Goods">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow15" runat="server">
                        <Items>
                            <ext:Label ID="NonSaleView" runat="server" Label="Non-Retail Goods">
                            </ext:Label>
                            <ext:Label ID="ConsignmentView" runat="server" Label="Consignment Goods">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow16" runat="server">
                        <Items>
                            <ext:Label ID="WeightItemView" runat="server" Label="Goods are Sold by Weight">
                            </ext:Label>
                            <ext:Label ID="DiscAllowView" runat="server" Label="Allow Discounts">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow17" runat="server">
                        <Items>
                            <ext:Label ID="CouponAllowView" runat="server" Label="Allow Coupons to Pay">
                            </ext:Label>
                            <ext:Label ID="VisuaItemView" runat="server" Label="Virtual Goods">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow18" runat="server">
                        <Items>
                            <ext:Label ID="CouponSKUView" runat="server" Label="Coupon Goods">
                            </ext:Label>
                            <ext:Label ID="BOMView" runat="server" Label="BOM">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow19" runat="server">
                        <Items>
                            <ext:Label ID="MutexFlagView" runat="server" Label="Mutually Exclusive">
                            </ext:Label>
                            <ext:Label ID="DiscountLimit" runat="server" Label="Max Percentage Discount Allowed">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow20" runat="server">
                        <Items>
                            <ext:Label ID="OnAccountView" runat="server" Label="Allow Book Sales">
                            </ext:Label>
                            <ext:Label ID="WarehouseCodeView" runat="server" Label="Warehouse Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow21" runat="server">
                        <Items>
                            <ext:Label ID="DefaultPickupStoreCodeView" runat="server" Label="Default Delivery Warehouse Code">
                            </ext:Label>
                            <ext:Label ID="Additional" runat="server" Label="Additional Information">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server">
                        <Items>
                            <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                            </ext:Label>
                            <ext:Label ID="CreatedBy" runat="server" Label="Created By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server">
                        <Items>
                            <ext:Label ID="UpdatedOn" runat="server" Label="Last Modified Date Time">
                            </ext:Label>
                            <ext:Label ID="UpdatedBy" runat="server" Label="Last Modified By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:RadioButtonList ID="NonOrder" runat="server" Label="Non-Order Goods" Required="true"
                ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="NonSale" runat="server" Label="Non-Retail Goods" Required="true"
                ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Consignment" runat="server" Label="Consignment Goods" Required="true"
                ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="WeightItem" runat="server" Label="Goods are Sold by Weight" Required="true"
                ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="DiscAllow" runat="server" Label="Allow Discounts" Required="true"
                ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="Not Allowed" Value="0" />
                <ext:RadioItem Text="Allowed" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CouponAllow" runat="server" Label="Allow Coupons to Pay" Required="true"
                ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="Not Allowed" Value="0" />
                <ext:RadioItem Text="Allowed" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="VisuaItem" runat="server" Label="Virtual Goods" Required="true" ShowRedStar="true"
                Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CouponSKU" runat="server" Label="Coupon Goods" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="BOM" runat="server" Label="BOM"
                Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="MutexFlag" runat="server" Label="Mutually Exclusive" Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="OnAccount" runat="server" Label="Allow Book Sales" Hidden="true">
                <ext:RadioItem Text="Not Allowed" Value="0" />
                <ext:RadioItem Text="Allowed" Value="1" Selected="true" />
            </ext:RadioButtonList>
            <ext:DropDownList ID="ReplenFormulaCode" runat="server" Label="Replenishment Formula Code" Hidden="true">
            </ext:DropDownList>
            <ext:DropDownList ID="FulfillmentHouseCode" runat="server" Label="Supply Warehouse Code" Hidden="true">
            </ext:DropDownList>
            <ext:DropDownList ID="WarehouseCode" runat="server" Label="Warehouse Code" Hidden="true">
            </ext:DropDownList>
            <ext:DropDownList ID="DefaultPickupStoreCode" runat="server" Label="Default Delivery Warehouse Code" Hidden="true">
            </ext:DropDownList>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
