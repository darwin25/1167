<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_DISCOUNT.Add" %>

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
            <ext:TextBox ID="DiscountCode" runat="server" Label="Discount Code" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:TextBox ID="ReasonCode" runat="server" Label="Reason Code" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:TextBox ID="Description1" runat="server" Label="Discount Description 1" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="Description2" runat="server" Label="Discount Description 2" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="Description3" runat="server" Label="Discount Description 3" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:DropDownList ID="DiscType" runat="server" Label="Discount Type">
                <ext:ListItem Text="item $ off" Value="0" Selected="true" />
                <ext:ListItem Text="item % off" Value="1" />
                <ext:ListItem Text="trans $ off" Value="2" />
                <ext:ListItem Text="trans % off" Value="3" />
                <ext:ListItem Text="price markdown" Value="4" />
            </ext:DropDownList>
            <ext:NumberBox ID="SalesDiscLevel" runat="server" Label="Discount Priority">
            </ext:NumberBox>
            <%--<ext:TextBox ID="DiscPrice" runat="server" Label="Discount Value" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true"/>--%>
            <ext:NumberBox ID="DiscPrice" runat="server" Label="Discount Value" DecimalPrecision="2">
            </ext:NumberBox>
            <ext:DropDownList ID="AuthLevel" runat="server" Label="Permission Settings">
                <ext:ListItem Text="No Permission" Value="0" Selected="true" />
                <ext:ListItem Text="Administrator Privileges" Value="1" />
                <ext:ListItem Text="Manager Rights" Value="2" />
            </ext:DropDownList>
            <ext:DropDownList ID="AllowDiscOnDisc" runat="server" Label="Allow Discount on Discounted Item">
                <ext:ListItem Text="Not Allowed" Value="0" Selected="true" />
                <ext:ListItem Text="Allowed" Value="1" />
            </ext:DropDownList>
            <ext:DropDownList ID="AllowChgDisc" runat="server" Label="Allow Change of Discount Value">
                <ext:ListItem Text="Not Allowed" Value="0" Selected="true" />
                <ext:ListItem Text="Allowed" Value="1" />
            </ext:DropDownList>
            <ext:DropDownList ID="TransDiscControl" runat="server" Label="Single Book Discount Control">
                <ext:ListItem Text="Not allowed for single order discounts, only single item discounts" Value="0" Selected="true" />
                <ext:ListItem Text="Allowed for single order discounts, calculated on the basis of the Netprice of each item"
                    Value="1" />
                <ext:ListItem Text="Allowed for the whole single discount, if the goods have been discounted, then skip this product record apportionment" Value="2" />
            </ext:DropDownList>
            <ext:RadioButtonList ID="Status" runat="server" Label="Status">
                <ext:RadioItem Text="Invalid" Value="0" />
                <ext:RadioItem Text="Valid" Value="1" Selected="true" />
            </ext:RadioButtonList>
            <ext:TextBox ID="Note" runat="server" Label="Remarks" />
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
