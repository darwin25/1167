<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_DEPARTMENT.Modify" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="180">
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
            <ext:TextBox ID="DepartCode" runat="server" Label="Department Code" Required="true" ShowRedStar="true"
                Enabled="false" />
            <ext:TextBox ID="DepartName1" runat="server" Label="Department Name 1" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="DepartName2" runat="server" Label="Department Name 2" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="DepartName3" runat="server" Label="Department Name 3" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:DropDownList runat="server" ID="StoreBrandCode" Label="Store Brand Code">
            </ext:DropDownList>
            <ext:Form ID="FormLoad" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow1" ColumnWidths="0% 80% 10%" runat="server">
                        <Items>
                            <ext:Label ID="uploadFilePath" Hidden="true" Text="" runat="server">
                            </ext:Label>
                            <ext:FileUpload ID="DepartPicFile" runat="server" Label="Department Picture File">
                            </ext:FileUpload>
                            <ext:Button ID="btnBack1" runat="server" Text="返回" HideMode="Display" Hidden="true"
                                OnClick="btnBack1_Click">
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
                            <ext:Label ID="Label1" runat="server" Label="Department Picture File">
                            </ext:Label>
                            <ext:Button ID="btnPreview" runat="server" Text="View" HideMode="Display" Icon="Picture">
                            </ext:Button>
                            <ext:Button ID="btnReUpLoad1" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad1_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormLoad1" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow3" ColumnWidths="0% 80% 10%" runat="server">
                        <Items>
                            <ext:Label ID="uploadFilePath1" Hidden="true" Text="" runat="server">
                            </ext:Label>
                            <ext:FileUpload ID="DepartPicFile2" runat="server" Label="Department Picture File 2">
                            </ext:FileUpload>
                            <ext:Button ID="btnBack2" runat="server" Text="返回" HideMode="Display" Hidden="true"
                                OnClick="btnBack2_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormReLoad1" ShowBorder="false" ShowHeader="false" Title="" runat="server"
                HideMode="Display" Hidden="true">
                <Rows>
                    <ext:FormRow ID="FormRow4" ColumnWidths="69% 11% 20%" runat="server">
                        <Items>
                            <ext:Label ID="Label2" runat="server" Label="Department Picture File 2">
                            </ext:Label>
                            <ext:Button ID="btnPreview1" runat="server" Text="View" HideMode="Display" Icon="Picture">
                            </ext:Button>
                            <ext:Button ID="btnReUpLoad2" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad2_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormLoad2" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow5" ColumnWidths="0% 80% 10%" runat="server">
                        <Items>
                            <ext:Label ID="uploadFilePath2" Hidden="true" Text="" runat="server">
                            </ext:Label>
                            <ext:FileUpload ID="DepartPicFile3" runat="server" Label="Department Picture File 3">
                            </ext:FileUpload>
                            <ext:Button ID="btnBack3" runat="server" Text="返回" HideMode="Display" Hidden="true"
                                OnClick="btnBack3_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormReLoad2" ShowBorder="false" ShowHeader="false" Title="" runat="server"
                HideMode="Display" Hidden="true">
                <Rows>
                    <ext:FormRow ID="FormRow6" ColumnWidths="69% 11% 20%" runat="server">
                        <Items>
                            <ext:Label ID="Label3" runat="server" Label="Department Picture File 3">
                            </ext:Label>
                            <ext:Button ID="btnPreview2" runat="server" Text="View" HideMode="Display" Icon="Picture">
                            </ext:Button>
                            <ext:Button ID="btnReUpLoad3" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad3_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TextBox ID="DepartNote" runat="server" Label="Department Notes" />
            <ext:DropDownList ID="ReplenFormulaCode" runat="server" Label="Replenishment Formula Code">
            </ext:DropDownList>
            <ext:DropDownList ID="FulfillmentHouseCode" runat="server" Label="Supply Warehouse Code">
            </ext:DropDownList>
            <ext:TextBox ID="CostCCC" runat="server" Label="Cost Center Code" />
            <ext:TextBox ID="CostWO" runat="server" Label="Work Order Number" />
            <ext:TextBox ID="RevenueCCC" runat="server" Label="Revenue CCC" />
            <ext:TextBox ID="RevenueWO" runat="server" Label="Revenue WO" />
            <ext:RadioButtonList ID="NonOrder" runat="server" Label="Non-Order Goods" Required="true"
                ShowRedStar="true">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="NonSale" runat="server" Label="Non-Retail Goods" Required="true"
                ShowRedStar="true">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Consignment" runat="server" Label="Consignment Goods" Required="true"
                ShowRedStar="true">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="WeightItem" runat="server" Label="Goods are Sold by Weight" Required="true"
                ShowRedStar="true">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="DiscAllow" runat="server" Label="Allow Discounts" Required="true"
                ShowRedStar="true">
                <ext:RadioItem Text="Not Allowed" Value="0" />
                <ext:RadioItem Text="Allowed" Value="1" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CouponAllow" runat="server" Label="Allow Coupons to Pay" Required="true"
                ShowRedStar="true">
                <ext:RadioItem Text="Not Allowed" Value="0" />
                <ext:RadioItem Text="Allowed" Value="1" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="VisuaItem" runat="server" Label="Virtual Goods" Required="true" ShowRedStar="true">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CouponSKU" runat="server" Label="Coupon Goods">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
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
            <%--<ext:TextBox ID="DiscountLimit" runat="server" Label="Max Percentage Discount Allowed" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true" Text="100.00"/>--%>
            <ext:NumberBox ID="DiscountLimit" runat="server" Label="Max Percentage Discount Allowed" DecimalPrecision="2"
                Text="100">
            </ext:NumberBox>
            <ext:RadioButtonList ID="OnAccount" runat="server" Label="Allow Book Sales">
                <ext:RadioItem Text="Not Allowed" Value="0" />
                <ext:RadioItem Text="Allowed" Value="1" Selected="true" />
            </ext:RadioButtonList>
            <ext:DropDownList ID="WarehouseCode" runat="server" Label="Warehouse Code">
            </ext:DropDownList>
            <ext:DropDownList ID="DefaultPickupStoreCode" runat="server" Label="Default Delivery Warehouse Code">
            </ext:DropDownList>
            <ext:TextBox ID="Additional" runat="server" Label="Additional Information" Required="true" ShowRedStar="true">
            </ext:TextBox>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <ext:Window ID="WindowPicture" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="750px"
        Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright2" runat="server" />
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
