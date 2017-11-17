<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_CURRENCY.Show" %>
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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
                            <ext:Label ID="CurrencyCode" runat="server" Label="Currency Code">
                            </ext:Label>
                            <ext:Label ID="CurrencyName1" runat="server" Label="Currency Name 1">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CurrencyName2" runat="server" Label="Currency Name 2">
                            </ext:Label>
                            <ext:Label ID="CurrencyName3" runat="server" Label="Currency Name 3">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Rate" runat="server" Label="汇率">
                            </ext:Label>
                            <ext:Label ID="TenderTypeView" runat="server" Label="Payment Types">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StatusView" runat="server" Label="Status">
                            </ext:Label>
                            <ext:Label ID="CashSaleView" runat="server" Label="是否现金货币">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CouponValueView" runat="server" Label="优惠劵性质">
                            </ext:Label>
                            <ext:Label ID="BaseView" runat="server" Label="最小货币单位">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="MinAmt" runat="server" Label="最小支付金额">
                            </ext:Label>
                            <ext:Label ID="MaxAmt" runat="server" Label="最大支付金额">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CardBegin" runat="server" Label="卡号号码范围（开始）">
                            </ext:Label>
                            <ext:Label ID="CardEnd" runat="server" Label="卡号号码范围（结束）">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CardLen" runat="server" Label="卡号长度">
                            </ext:Label>
                            <ext:Label ID="AccountCode" runat="server" Label="账号代码">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ContraCode" runat="server" Label="对冲账号代码">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="PayTransferView" runat="server" Label="是否换货">
                            </ext:Label>
                            <ext:Label ID="Refund_TypeView" runat="server" Label="是否退货">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:DropDownList ID="TenderType" runat="server" Label="TenderType:" Hidden="true">
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
            <ext:DropDownList ID="Base" runat="server" Label="最小单位" Required="true" ShowRedStar="true">
                <ext:ListItem  Text="1" Value="1"/>
                <ext:ListItem  Text="0.1" Value="0.1"/>
                <ext:ListItem  Text="0.01" Value="0.01"/>
            </ext:DropDownList>
            <ext:RadioButtonList ID="CashSale" runat="server" Label="是否现金货币" Required="true" ShowRedStar="true" Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Status" runat="server" Label="Status:" Hidden="true">
                <ext:RadioItem Text="Invalid" Value="0" Selected="True" />
                <ext:RadioItem Text="Valid" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="CouponValue" runat="server" Label="CouponValue:" Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="PayTransfer" runat="server" Label="PayTransfer:" Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Refund_Type" runat="server" Label="Refund_Type:" Hidden="true">
                <ext:RadioItem Text="No" Value="0" Selected="True" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
