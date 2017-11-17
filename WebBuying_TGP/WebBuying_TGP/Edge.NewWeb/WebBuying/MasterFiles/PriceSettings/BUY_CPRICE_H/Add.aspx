<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
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
            <ext:TextBox ID="CPriceCode" runat="server" Label="Cost Code" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" Enabled="false" />
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
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
