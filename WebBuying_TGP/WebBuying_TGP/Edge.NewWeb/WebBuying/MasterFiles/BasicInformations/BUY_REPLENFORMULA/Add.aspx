<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLENFORMULA.Add" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="375">
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
            <ext:TextBox ID="ReplenFormulaCode" runat="server" Label="Automatic Replenishment Code" Required="true"
                ShowRedStar="true" OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:NumberBox ID="PreDefineDOC" runat="server" Label="Reserved Inventory Days">
            </ext:NumberBox>
            <ext:NumberBox ID="RunningStockDOC" runat="server" Label="Normal Stock Days">
            </ext:NumberBox>
            <ext:NumberBox ID="OrderRoundUpQty" runat="server" Label="Multiple of Order Quantity">
            </ext:NumberBox>
            <ext:NumberBox ID="AVGDailySalesPeriod" runat="server" Label="Number of days for the average number of sales">
            </ext:NumberBox>
            <ext:RadioButtonList ID="Quotation" runat="server" Label="Whether the quantity statistics include the type of offer">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Deposited" runat="server" Label="Whether the quantity statistics include the deposit sales type">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="AdvSales" runat="server" Label="Whether the quantity statistics include the pre-sale sales type">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
             <ext:TextBox ID="Description" runat="server" Label="Description" />
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
