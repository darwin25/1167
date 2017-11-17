<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.Controllers.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" LabelAlign="Right"  LabelWidth="150">
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
            <ext:Label ID="BOMCode" runat="server" Label="主货品编码">
            </ext:Label>
            <ext:Label ID="ProdCode" runat="server" Label="子货品编码">
            </ext:Label>
            <ext:NumberBox ID="MinQty" runat="server" Label="子货品最小数量" Required="true" ShowRedStar="true"
                MinValue="0" Text="0" />
            <ext:NumberBox ID="MaxQty" runat="server" Label="子货品最大数量" Required="true" ShowRedStar="true"
                MinValue="0" Text="0" CompareOperator="GreaterThanEqual" CompareControl="MinQty"
                CompareMessage="最大数量应大于最小数量" />
            <ext:NumberBox ID="DefaultQty" runat="server" Label="子货品默认数量" Required="true" ShowRedStar="true"
                MinValue="0" Text="0" />
            <ext:NumberBox ID="Price" runat="server" Label="附加价格" Required="true" ShowRedStar="true"
                MinValue="0" Text="0.00" NoDecimal="false" DecimalPrecision="2" />
            <ext:RadioButtonList ID="ValueType" runat="server" Label="货品价格分摊类型">
                <ext:RadioItem Text="金额" Value="0" Selected="true" />
                <ext:RadioItem Text="百分比" Value="1" />
            </ext:RadioButtonList>
            <ext:NumberBox ID="PartValue" runat="server" Label="货品价格分摊值" Required="true" ShowRedStar="true"
                MinValue="0" Text="0.00" NoDecimal="false" DecimalPrecision="2" />
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    <ext:Window ID="Window2" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="900px"
        Height="450px">
    </ext:Window>
    </form>
</body>
</html>
