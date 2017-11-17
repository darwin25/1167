<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.Modify" %>

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
                                Enabled="false" />
                            <ext:TextBox ID="Description1" runat="server" Label="Promotional Description 1" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="Description2" runat="server" Label="Promotional Description 2" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="Description3" runat="server" Label="Promotional Description 3" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
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
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Price List">
                <Items>
                    <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar5" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnViewSearch" Icon="Add" runat="server" Text="重设" OnClick="btnViewSearch_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnDeleteResultItem" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteResultItem_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnClearAllResultItem" Icon="Delete" runat="server" Text="清空" OnClick="btnClearAllResultItem_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Entity Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityNum" runat="server" Text='<%# Eval("EntityNum") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Entity Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityType" runat="server" Text='<%# Eval("EntityTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="操作符">
                                <ItemTemplate>
                                    <asp:Label ID="lblHitOP" runat="server" Text='<%# Eval("HitOPName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("HitTypeName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中金额/数量">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("HitAmount")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="折扣数值">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscPrice" runat="server" Text='<%# Eval("DiscPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Discount Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscType" runat="server" Text='<%# Eval("DiscTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    <ext:Window ID="Window1" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="Window1Edit_Close" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="900px"
        Height="250px">
    </ext:Window>
    <ext:Window ID="WindowSearch" Hidden="true" EnableIFrame="true" runat="server" CloseAction="Hide"
        OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    </form>
</body>
</html>
