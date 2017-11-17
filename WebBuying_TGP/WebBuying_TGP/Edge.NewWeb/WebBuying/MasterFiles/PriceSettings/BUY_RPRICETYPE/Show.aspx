<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_RPRICETYPE.Show" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
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
            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="RPriceTypeCode" runat="server" Label="Retail Price Type Code">
                            </ext:Label>
                            <ext:Label ID="RPriceTypeName1" runat="server" Label="零售价类型名称1">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="RPriceTypeName2" runat="server" Label="零售价类型名称2">
                            </ext:Label>
                            <ext:Label ID="RPriceTypeName3" runat="server" Label="零售价类型名称3">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="AdditionalType" runat="server" Label="附加类型">
                            </ext:Label>
                            <ext:Label ID="SupervisorView" runat="server" Label="是否需要管理员登录">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="SerialNoView" runat="server" Label="是否需要输入序列号">
                            </ext:Label>
                            <ext:Label ID="DiscountView" runat="server" Label="是否折扣标志">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="TypeLevel" runat="server" Label="类型级别">
                            </ext:Label>
                            <ext:Label ID="MemberShipView" runat="server" Label="是否用于会员">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StockTypeCode" runat="server" Label="库存类型编码">
                            </ext:Label>
                            <ext:Label ID="RANOnlyView" runat="server" Label="Translate__Special_121_Start是否用于RAN货品Translate__Special_121_End">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="DAMOnlyView" runat="server" Label="是否用于损坏货品">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:RadioButtonList ID="Supervisor" runat="server" Label="是否需要管理员登录" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="SerialNo" runat="server" Label="是否需要输入序列号" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Discount" runat="server" Label="是否折扣标志" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="MemberShip" runat="server" Label="是否用于会员" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="RANOnly" runat="server" Label="Translate__Special_121_Start是否用于RAN货品Translate__Special_121_End"
                Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="DAMOnly" runat="server" Label="是否用于损坏货品" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
