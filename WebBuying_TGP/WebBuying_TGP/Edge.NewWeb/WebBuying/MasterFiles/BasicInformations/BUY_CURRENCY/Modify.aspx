<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_CURRENCY.Modify" %>
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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
            <ext:TextBox ID="CurrencyCode" runat="server" Label="Currency Code" Required="true" ShowRedStar="true" Enabled="false"/>
            <ext:TextBox ID="CurrencyName1" runat="server" Label="Currency Name 1" Required="true" ShowRedStar="true" OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true"/>
            <ext:TextBox ID="CurrencyName2" runat="server" Label="Currency Name 2" Required="true" ShowRedStar="true" OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true"/>
            <ext:TextBox ID="CurrencyName3" runat="server" Label="Currency Name 3" Required="true" ShowRedStar="true" OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true"/>
            <ext:NumberBox ID="Rate" runat="server" Label="Exchange Rate"DecimalPrecision="4" Required="true" ShowRedStar="true" Text="1"></ext:NumberBox>
            <ext:DropDownList ID="TenderType" runat="server" Label="Payment Types" Required="true" ShowRedStar="true">
                <ext:ListItem  Text="--------" Value="0"/>
                <ext:ListItem  Text="Local Cash" Value="1"/>
                <ext:ListItem  Text="Foreign Cash" Value="2"/>
                <ext:ListItem  Text="Cheque" Value="3"/>
                <ext:ListItem  Text="Credit Card" Value="4"/>
                <ext:ListItem  Text="Debit Card" Value="5"/>
                <ext:ListItem  Text="EPS Card" Value="6"/>
                <ext:ListItem  Text="Coupon" Value="7"/>
                <ext:ListItem  Text="Credit Card Installment" Value="8"/>
                <ext:ListItem  Text="Finance House Installment" Value="9"/>
                <ext:ListItem  Text="On Account" Value="10"/>
                <ext:ListItem  Text="On Account Inter Client" Value="11"/>
                <ext:ListItem  Text="Credit Card Group" Value="12"/>
                <ext:ListItem  Text="Burn Point" Value="15"/>
            </ext:DropDownList>           
            <ext:RadioButtonList ID="Status" runat="server" Label="Status" Required="true" ShowRedStar="true" >
                <ext:RadioItem Text="Invalid" Value="0" Selected="True" />
                <ext:RadioItem Text="Valid" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CashSale" runat="server" Label="是否现金货币" Required="true" ShowRedStar="true" >
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CouponValue" runat="server" Label="是否优惠劵性质" Required="true" ShowRedStar="true">
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:DropDownList ID="Base" runat="server" Label="最小货币单位" Required="true" ShowRedStar="true" >
                <ext:ListItem  Text="1" Value="1"/>
                <ext:ListItem  Text="0.1" Value="0.1"/>
                <ext:ListItem  Text="0.01" Value="0.01"/>
            </ext:DropDownList>
            <ext:NumberBox ID="MinAmt" runat="server" Label="最小支付金额" DecimalPrecision="2" Required="true" ShowRedStar="true" ></ext:NumberBox>
            <ext:NumberBox ID="MaxAmt" runat="server" Label="最大支付金额" DecimalPrecision="2" Required="true" ShowRedStar="true" ></ext:NumberBox>
            <ext:TextBox ID="CardBegin" runat="server" Label="卡号号码范围（开始）"/>
            <ext:TextBox ID="CardEnd" runat="server" Label="卡号号码范围（结束）"/>
            <ext:TextBox ID="CardLen" runat="server" Label="卡号长度"/>
            <ext:TextBox ID="AccountCode" runat="server" Label="账号代码"/>
            <ext:TextBox ID="ContraCode" runat="server" Label="对冲账号代码" />
            <ext:RadioButtonList ID="PayTransfer" runat="server" Label="Translate__Special_121_Start是否换货Translate__Special_121_End">
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Refund_Type" runat="server" Label="Translate__Special_121_Start是否退货Translate__Special_121_End">
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required"  CssStyle="font-size:12px;color:red"></ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
