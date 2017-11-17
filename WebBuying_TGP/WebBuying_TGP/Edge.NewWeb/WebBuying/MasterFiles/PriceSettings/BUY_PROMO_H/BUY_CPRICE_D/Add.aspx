<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.BUY_CPRICE_D.Add" %>
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
            <ext:TextBox ID="PromotionCode" runat="server" Label="促销编号" Required="true" ShowRedStar="true" Enabled="false"/>
            <ext:TextBox ID="EntityNum" runat="server" Label="Entity Code"></ext:TextBox>
            <ext:DropDownList ID="EntityType" runat="server" Label="Entity Type" >
                <ext:ListItem Text="--------" Value="0" />
                <ext:ListItem Text="Prodcode" Value="1" />
                <ext:ListItem Text="DepartCode" Value="2" />
                <ext:ListItem Text="TenderCode" Value="3" />
            </ext:DropDownList>
            <ext:DropDownList ID="HitOP" runat="server" Label="操作符" >
                <ext:ListItem Text="--------" Value="0" />
                <ext:ListItem Text="=" Value="1" />
                <ext:ListItem Text="<>" Value="2" />
                <ext:ListItem Text="'<='" Value="3" />
                <ext:ListItem Text="'>='" Value="4" />
                <ext:ListItem Text="<" Value="5" />   
                <ext:ListItem Text=">" Value="6" />       
            </ext:DropDownList>
            <ext:TextBox ID="HitAmount" runat="server" Label="命中金额" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true"/>
            <ext:TextBox ID="DiscPrice" runat="server" Label="折扣金额" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true"/>
            <ext:DropDownList ID="DiscType" runat="server" Label="Discount Type" >
                <ext:ListItem Text="折扣减去的金额" Value="1" />
                <ext:ListItem Text=" 折扣销售的金额" Value="2" />
                <ext:ListItem Text="折扣减去的百分比" Value="3" />
                <ext:ListItem Text="折扣销售的百分比" Value="4" />
            </ext:DropDownList>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
