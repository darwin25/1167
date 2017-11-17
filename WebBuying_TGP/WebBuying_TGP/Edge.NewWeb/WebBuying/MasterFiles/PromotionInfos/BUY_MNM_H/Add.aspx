<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H.Add" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="200">
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
            <ext:TextBox ID="MNMCode" runat="server" Label="混配促销编码" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:DropDownList ID="MNMType" runat="server" Label="促销命中条件类型">
                <ext:ListItem Text="Promotion By Hit Qty" Value="0" />
                <ext:ListItem Text="Promotion By Hit Amount" Value="1" />
                <ext:ListItem Text="Promotion By Sales Amount" Value="2" />
            </ext:DropDownList>
            <ext:TextBox ID="Description1" runat="server" Label="混配Promotional Description 1" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="Description2" runat="server" Label="混配Promotional Description 2" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="Description3" runat="server" Label="混配Promotional Description 3" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" OnSelectedIndexChanged="StoreCode_SelectedIndexChanged"
                AutoPostBack="true">
            </ext:DropDownList>
            <ext:DropDownList ID="StoreGroupCode" runat="server" Label="Store Group Code" OnSelectedIndexChanged="StoreGroupCode_SelectedIndexChanged"
                AutoPostBack="true">
            </ext:DropDownList>
            <ext:DatePicker ID="StartDate" runat="server" Label="Price Effective Date">
            </ext:DatePicker>
            <ext:DatePicker ID="EndDate" runat="server" Label="Price Expiration Date" CompareControl="StartDate"
                CompareOperator="GreaterThanEqual" CompareMessage="End date should be greater than start date">
            </ext:DatePicker>
            <ext:TimePicker ID="StartTime" runat="server" Label="促销生效时间" Text="00:00" Increment="120">
            </ext:TimePicker>
            <ext:TimePicker ID="EndTime" runat="server" Label="促销失效时间" Text="23:59" Increment="120">
            </ext:TimePicker>
            <ext:Form ID="Form2" ShowHeader="false" ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow1" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:TextBox ID="DayFlagCode" runat="server" Label="一月中促销生效日">
                            </ext:TextBox>
                            <ext:Button ID="btnAddDay" runat="server" Text="Add" Icon="Add" OnClick="btnAddDay_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow2" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:TextBox ID="WeekFlagCode" runat="server" Label="一周中促销生效日">
                            </ext:TextBox>
                            <ext:Button ID="btnAddWeek" runat="server" Text="Add" Icon="Add" OnClick="btnAddWeek_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="Form4" ShowHeader="false" ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow3" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:TextBox ID="MonthFlagCode" runat="server" Label="促销生效月">
                            </ext:TextBox>
                            <ext:Button ID="btnAddMonth" runat="server" Text="Add" Icon="Add" OnClick="btnAddMonth_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:RadioButtonList ID="LoyaltyOnly" runat="server" Label="是否仅会员混配促销">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:DropDownList ID="LoyaltyCardTypeCode" runat="server" Label="混配促销指定的会员卡类型" OnSelectedIndexChanged="LoyaltyCardTypeCode_SelectedIndexChanged"
                AutoPostBack="true" />
            <ext:DropDownList ID="LoyaltyCardGradeCode" runat="server" Label="混配促销指定的会员卡等级" />
            <ext:TextBox ID="LoyaltyThreshold" runat="server" Label="混配促销指定的会员忠诚度阀值" />
            <ext:DropDownList ID="HitType" runat="server" Label="命中类型">
                <ext:ListItem Text="Hit must be same SKU" Value="0" Selected="true" />
                <ext:ListItem Text="Hit must be each SKU" Value="1" />
                <ext:ListItem Text="Hit can be any SKU" Value="2" />
                <ext:ListItem Text="Hit Qty is fixed" Value="99" />
            </ext:DropDownList>
            <ext:DropDownList ID="HitOP" runat="server" Label="操作符">
                <ext:ListItem Text="--------" Value="0" />
                <ext:ListItem Text="=" Value="1" />
                <ext:ListItem Text="<>" Value="2" />
                <ext:ListItem Text="&lt=" Value="3" />
                <ext:ListItem Text="&gt=" Value="4" />
                <ext:ListItem Text="<" Value="5" />
                <ext:ListItem Text=">" Value="6" />
            </ext:DropDownList>
            <%--<ext:TextBox ID="HitAmount" runat="server" Label="命中金额" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true" Text="0.00"/>--%>
            <ext:NumberBox ID="HitAmount" runat="server" Label="命中金额" DecimalPrecision="2" Text="0">
            </ext:NumberBox>
            <ext:NumberBox ID="HitQty" runat="server" Label="命中数量">
            </ext:NumberBox>
            <ext:DropDownList ID="GiftType" runat="server" Label="礼品类型">
                <ext:ListItem Text="Gift must be same SKU" Value="0" Selected="true" />
                <ext:ListItem Text="Gift must be each SKU" Value="1" />
                <ext:ListItem Text="Gift can be any SKU" Value="2" />
                <ext:ListItem Text="Gift must be same SKU with Hit " Value="3" />
                <ext:ListItem Text="Gift Qty is fixed" Value="99" />
            </ext:DropDownList>
            <ext:NumberBox ID="GiftQty" runat="server" Label="礼品货品数量">
            </ext:NumberBox>
            <ext:DropDownList ID="PromotionType" runat="server" Label="折扣金额设定类型">
                <ext:ListItem Text="Sales at" Value="0" Selected="true" />
                <ext:ListItem Text="Sales off" Value="1" />
            </ext:DropDownList>
            <ext:DropDownList ID="PromotionOn" runat="server" Label="折扣实现方式">
                <ext:ListItem Text="Discount on Hit" Value="0" Selected="true" />
                <ext:ListItem Text="Discount on Gift" Value="1" />
                <ext:ListItem Text="Discount on Transaction" Value="2" />
            </ext:DropDownList>
            <ext:RadioButtonList ID="AmountType" runat="server" Label="指定金额内容类型">
                <ext:RadioItem Text="金额" Value="$" Selected="true" />
                <ext:RadioItem Text="百分比" Value="%" />
            </ext:RadioButtonList>
            <%--<ext:TextBox ID="Amount" runat="server" Label="金额或者折扣" OnTextChanged="ConvertTextboxToDecimal" AutoPostBack="true" Text="0.00"/>--%>
            <ext:NumberBox ID="Amount" runat="server" Label="金额或者折扣" DecimalPrecision="2" Text="0">
            </ext:NumberBox>
            <ext:DropDownList ID="LoyaltyBirthdayFlag" runat="server" Label="是否销售当日生日促销">
                <ext:ListItem Text="不是生日促销" Value="0" Selected="true" />
                <ext:ListItem Text="会员生日当日" Value="1" />
                <ext:ListItem Text="会员生日当周" Value="2" />
                <ext:ListItem Text="会员生日当月" Value="3" />
            </ext:DropDownList>
            <ext:TextBox ID="Note" runat="server" Label="Remarks" />
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    <ext:Window ID="Window1" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="900px"
        Height="250px">
    </ext:Window>
    </form>
</body>
</html>
