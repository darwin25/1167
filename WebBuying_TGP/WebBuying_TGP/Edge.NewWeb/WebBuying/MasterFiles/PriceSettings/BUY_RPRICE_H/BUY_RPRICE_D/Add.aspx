<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_RPRICE_H.BUY_RPRICE_D.Add" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="140">
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
            <ext:TextBox ID="RPriceCode" runat="server" Label="价格编号" Required="true" ShowRedStar="true"
                Enabled="false" />
            <ext:DropDownList ID="ProdCode" runat="server" Label="Product Code">
            </ext:DropDownList>
            <ext:DropDownList ID="RPriceTypeCode" runat="server" Label="Retail Price Type Code">
            </ext:DropDownList>
            <%--<ext:TextBox ID="Price" runat="server" Label="Sales Price" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true"/>--%>
            <ext:NumberBox ID="Price" runat="server" Label="Sales Price" DecimalPrecision="2" NoDecimal="false" />
            <%--<ext:TextBox ID="RefPrice" runat="server" Label="Reference price" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true"/>--%>
            <ext:NumberBox ID="RefPrice" runat="server" Label="Reference price" DecimalPrecision="2" NoDecimal="false" />
            <ext:NumberBox ID="PromotionPrice" runat="server" Label="Promotion Price" DecimalPrecision="2"
                NoDecimal="false" />
            <ext:NumberBox ID="MemberPrice" runat="server" Label="Member Price" DecimalPrecision="2"
                NoDecimal="false" />
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
