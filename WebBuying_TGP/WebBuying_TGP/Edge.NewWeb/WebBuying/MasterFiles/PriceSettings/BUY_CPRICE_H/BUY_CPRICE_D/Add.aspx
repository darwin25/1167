<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H.BUY_CPRICE_D.Add" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="SimpleForm1" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
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
            <ext:TextBox ID="CPriceCode" runat="server" Label="Cost Price Code" Required="true" ShowRedStar="true" Enabled="false"/>
            <ext:DropDownList ID="ProdCode" runat="server" Label="Product Code" ></ext:DropDownList>
            <ext:NumberBox ID="CPriceGrossCost" runat="server" Label="Gross Cost" DecimalPrecision="2"/>
            <ext:NumberBox ID="CPriceNetCost" runat="server" Label="Net Cost Price" DecimalPrecision="2"/>
            <ext:NumberBox ID="CPriceDisc1" runat="server" Label="Trade Discount " DecimalPrecision="2"/>
            <ext:NumberBox ID="CPriceDisc2" runat="server" Label="Other Discounts" DecimalPrecision="2"/>
            <ext:NumberBox ID="CPriceDisc3" runat="server" Label="Special Discount" DecimalPrecision="2"/>
            <ext:NumberBox ID="CPriceDisc4" runat="server" Label="Discount 4" DecimalPrecision="2"/>
            <ext:NumberBox ID="CPriceBuy" runat="server" Label="Purchase Qty" DecimalPrecision="2"/>
            <ext:NumberBox ID="CPriceGet" runat="server" Label="Purchase Over Free" DecimalPrecision="2"/>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
