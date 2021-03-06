﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.Add" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Basic Information">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:TextBox ID="PromotionCode" runat="server" Label="Price Code" Required="true" ShowRedStar="true"
                                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" Enabled="false" />
                            <ext:TextBox ID="Description1" runat="server" Label="Promotional Description 1" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="Description2" runat="server" Label="Promotional Description 2" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="Description3" runat="server" Label="Promotional Description 3" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <%--                        <ext:RadioButtonList ID="MemberPromotionFlag" runat="server" Label="是否会员促销"
                            OnSelectedIndexChanged="MemberPromotionFlag_SelectChanged" AutoPostBack="true">
                            <ext:RadioItem  Text="No" Value="0" Selected="true"/>
                            <ext:RadioItem  Text="Yes" Value="1" />
                        </ext:RadioButtonList>        
                        <ext:DropDownList ID="CardTypeCode" runat="server" Label="会员卡类型编号"  
                             OnSelectedIndexChanged="CardTypeCode_SelectedIndexChanged" AutoPostBack="true"
                            />
                        <ext:DropDownList ID="CardGradeCode" runat="server" Label="会员卡级别编号"  
                             />
                        <ext:RadioButtonList ID="BirthdayFlag" runat="server" Label="是否销售当日生日促销" Enabled="false">
                            <ext:RadioItem  Text="No" Value="0" Selected="true"/>
                            <ext:RadioItem  Text="Yes" Value="1" />
                        </ext:RadioButtonList>   --%>
                            <ext:TextBox ID="Note" runat="server" Label="Remarks" />
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="会员设置">
                <Items>
                    <ext:SimpleForm ID="SimpleForm5" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:RadioButtonList ID="MemberPromotionFlag" runat="server" Label="是否会员促销" OnSelectedIndexChanged="MemberPromotionFlag_SelectChanged"
                                AutoPostBack="true">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                            <ext:DropDownList ID="CardTypeCode" runat="server" Label="会员卡类型编号" OnSelectedIndexChanged="CardTypeCode_SelectedIndexChanged"
                                AutoPostBack="true" />
                            <ext:DropDownList ID="CardGradeCode" runat="server" Label="会员卡级别编号" />
                            <ext:RadioButtonList ID="BirthdayFlag" runat="server" Label="是否销售当日生日促销">
                                <ext:RadioItem Text="No" Value="0" Selected="true" />
                                <ext:RadioItem Text="Yes" Value="1" />
                            </ext:RadioButtonList>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel6" runat="server" EnableCollapse="True" Title="店铺设置">
                <Items>
                    <ext:SimpleForm ID="SimpleForm4" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" OnSelectedIndexChanged="StoreCode_SelectedIndexChanged"
                                AutoPostBack="true">
                            </ext:DropDownList>
                            <ext:DropDownList ID="StoreGroupCode" runat="server" Label="Store Group Code" OnSelectedIndexChanged="StoreGroupCode_SelectedIndexChanged"
                                AutoPostBack="true">
                            </ext:DropDownList>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="促销时间设置">
                <Items>
                    <ext:SimpleForm ID="SimpleForm3" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
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
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
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
