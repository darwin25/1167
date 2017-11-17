<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.BUY_RPRICE_M.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:HiddenField runat="server" ID="hidTypes">
    </ext:HiddenField>
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
            <ext:TextBox ID="RPriceCode" runat="server" Label="Retail Price Code" Hidden="true" HideMode="Offsets" />
            <ext:TextBox ID="ProdCode" runat="server" Label="Product Code" Required="true" ShowRedStar="true"
                Enabled="false" />
            <ext:DropDownList ID="RPriceTypeCode" runat="server" Label="Retail Price Type Code">
            </ext:DropDownList>
            <ext:NumberBox ID="RefPrice" runat="server" Label="Reference price" DecimalPrecision="2" Required="true"
                ShowRedStar="true">
            </ext:NumberBox>
            <ext:NumberBox ID="Price" runat="server" Label="Retail Price" DecimalPrecision="2" Required="true"
                ShowRedStar="true">
            </ext:NumberBox>
            <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" OnSelectedIndexChanged="StoreCode_SelectedIndexChanged"
                AutoPostBack="true">
            </ext:DropDownList>
            <ext:DropDownList ID="StoreGroupCode" runat="server" Label="Store Group Code" OnSelectedIndexChanged="StoreGroupCode_SelectedIndexChanged"
                AutoPostBack="true">
            </ext:DropDownList>
            <ext:DatePicker ID="StartDate" runat="server" Label="Price Effective Date">
            </ext:DatePicker>
            <ext:DatePicker ID="EndDate" runat="server" Label="Price Expiration Date" CompareControl="StartDate"
                CompareOperator="GreaterThanEqual" CompareMessage="End date should be greater than start date">
            </ext:DatePicker>
            <ext:NumberBox ID="MemberPrice" runat="server" Label="Member Price" DecimalPrecision="2"
                NoDecimal="false" />
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
