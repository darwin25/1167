<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.Show" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Basic Information">
                <Items>
                    <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                        Hidden="false">
                        <Rows>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="PromotionCode" runat="server" Label="Promotional Code">
                                    </ext:Label>
                                    <ext:Label ID="Description1" runat="server" Label="Promotional Description 1">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="Description2" runat="server" Label="Promotional Description 2">
                                    </ext:Label>
                                    <ext:Label ID="Description3" runat="server" Label="Promotional Description 3">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="StoreCodeView" runat="server" Label="Store Code">
                                    </ext:Label>
                                    <ext:Label ID="StoreGroupCodeView" runat="server" Label="Store Group Code">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="StartDate" runat="server" Label="促销生效日期">
                                    </ext:Label>
                                    <ext:Label ID="EndDate" runat="server" Label="促销失效日期">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="StartTime" runat="server" Label="促销生效时间">
                                    </ext:Label>
                                    <ext:Label ID="EndTime" runat="server" Label="促销失效时间">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="DayFlagCode" runat="server" Label="一月中促销生效日">
                                    </ext:Label>
                                    <ext:Label ID="WeekFlagCode" runat="server" Label="一周中促销生效日">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="MonthFlagCode" runat="server" Label="促销生效月">
                                    </ext:Label>
                                    <ext:Label ID="MemberPromotionFlagView" runat="server" Label="是否会员促销">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="CardTypeCode" runat="server" Label="会员卡类型编号">
                                    </ext:Label>
                                    <ext:Label ID="CardGradeCode" runat="server" Label="会员卡级别编号">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="BirthdayFlagView" runat="server" Label="是否销售当日生日促销">
                                    </ext:Label>
                                    <ext:Label ID="Note" runat="server" Label="Remarks">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow15" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="CreatedBusDate" runat="server" Label="单据创建时的交易日期">
                                    </ext:Label>
                                    <ext:Label ID="ApproveBusDate" runat="server" Label="Approve Business Date">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="ApprovalCode" runat="server" Label="Approval Code">
                                    </ext:Label>
                                    <ext:Label ID="ApproveStatus" runat="server" Label="Approve Status">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="ApproveOn" runat="server" Label="Approve On">
                                    </ext:Label>
                                    <ext:Label ID="ApproveBy" runat="server" Label="Approve By">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                                    </ext:Label>
                                    <ext:Label ID="CreatedBy" runat="server" Label="Created By">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="UpdatedOn" runat="server" Label="Updated On">
                                    </ext:Label>
                                    <ext:Label ID="UpdatedBy" runat="server" Label="Updated By">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" Hidden="true">
                    </ext:DropDownList>
                    <ext:DropDownList ID="StoreGroupCode" runat="server" Label="Store Group Code" Hidden="true">
                    </ext:DropDownList>
                    <ext:RadioButtonList ID="MemberPromotionFlag" runat="server" Hidden="true">
                        <ext:RadioItem Text="No" Value="0" />
                        <ext:RadioItem Text="Yes" Value="1" />
                    </ext:RadioButtonList>
                    <ext:RadioButtonList ID="BirthdayFlag" runat="server" Hidden="true">
                        <ext:RadioItem Text="No" Value="0" />
                        <ext:RadioItem Text="Yes" Value="1" />
                    </ext:RadioButtonList>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="折扣详情列表">
                <Items>
                    <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                        runat="server" DataKeyNames="KeyID" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Entity Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityNum" runat="server" Text='<%# Eval("EntityNum") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Entity Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityType" runat="server" Text='<%# Eval("EntityType") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="操作符">
                                <ItemTemplate>
                                    <asp:Label ID="lblHitOP" runat="server" Text='<%# Eval("HitOP") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中金额">
                                <ItemTemplate>
                                    <asp:Label ID="lblHitAmount" runat="server" Text='<%# Eval("HitAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="折扣金额">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscPrice" runat="server" Text='<%# Eval("DiscPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Discount Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscType" runat="server" Text='<%# Eval("DiscType") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
