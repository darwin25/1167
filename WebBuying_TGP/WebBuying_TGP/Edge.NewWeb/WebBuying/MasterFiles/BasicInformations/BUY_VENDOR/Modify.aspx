<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_VENDOR.Modify" %>

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
            <ext:TextBox ID="VendorCode" runat="server" Label="Supplier Code" Required="true" ShowRedStar="true"
                Enabled="false" />
            <ext:TextBox ID="VendorName1" runat="server" Label="Supplier Name 1" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="VendorName2" runat="server" Label="Supplier Name 2" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="VendorName3" runat="server" Label="Supplier Name 3" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="VendorAddress1" runat="server" Label="Supplier Address 1" />
            <ext:TextBox ID="VendorAddress2" runat="server" Label="Supplier Address 2" />
            <ext:TextBox ID="VendorAddress3" runat="server" Label="Supplier Address 3" />
            <ext:TextBox ID="VendorNote" runat="server" Label="Supplier Notes" />
            <ext:RadioButtonList ID="PreferFlag" runat="server" Label="Accredited Supplier">
                <ext:RadioItem Text="Yes" Value="1" />
                <ext:RadioItem Text="No" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:TextBox ID="Contact" runat="server" Label="Contact" />
            <ext:TextBox ID="ContactPosition" runat="server" Label="Contact Position" />
            <ext:TextBox ID="ContactTel" runat="server" Label="Contact Phone" />
            <ext:TextBox ID="ContactFax" runat="server" Label="Contact Fax" />
            <ext:TextBox ID="ContactMobile" runat="server" Label="Contact Mobile" />
            <ext:TextBox ID="ContactEmail" runat="server" Label="Contact E-mail" />
            <ext:NumberBox ID="Terms" runat="server" Label="Terms">
            </ext:NumberBox>
            <%--<ext:TextBox ID="Limit" runat="server" Label="Credit Limit" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true"/>--%>
            <ext:NumberBox ID="Limit" runat="server" Label="Credit Limit" DecimalPrecision="2">
            </ext:NumberBox>
            <ext:TextBox ID="Shipment" runat="server" Label="Freight" />
            <ext:TextBox ID="PayTerm" runat="server" Label="Payment Terms" />
            <ext:TextBox ID="AccountCode" runat="server" Label="Account Code" />
            <ext:RadioButtonList ID="Oversea" runat="server" Label="Overseas Supplier">
                <ext:RadioItem Text="Yes" Value="1" />
                <ext:RadioItem Text="No" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <%--<ext:TextBox ID="InTax" runat="server" Label="Tax Rate (Supplied by Supplier)" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true"/>--%>
            <ext:NumberBox ID="InTax" runat="server" Label="Tax Rate (Supplied by Supplier)" DecimalPrecision="2">
            </ext:NumberBox>
            <ext:RadioButtonList ID="NonOrder" runat="server" Label="Whether to see the order supplier">
                <ext:RadioItem Text="Yes" Value="1" />
                <ext:RadioItem Text="No" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
