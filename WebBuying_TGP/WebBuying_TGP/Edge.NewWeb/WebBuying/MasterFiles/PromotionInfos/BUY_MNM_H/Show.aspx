<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H.Show" %>

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
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Basic Information">
                <Items>
                    <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                        Hidden="false">
                        <Rows>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="MNMCode" runat="server" Label="Promotional Code">
                                    </ext:Label>
                                    <ext:Label ID="MNMTypeView" runat="server" Label="促销命中条件类型">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="Description1" runat="server" Label="Promotional Description 1">
                                    </ext:Label>
                                    <ext:Label ID="Description2" runat="server" Label="Promotional Description 2">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="Description3" runat="server" Label="Promotional Description 3">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
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
                                    <ext:Label ID="LoyaltyOnlyView" runat="server" Label="是否仅会员混配促销">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="LoyaltyCardTypeCode" runat="server" Label="混配促销指定的会员卡类型">
                                    </ext:Label>
                                    <ext:Label ID="LoyaltyCardGradeCode" runat="server" Label="混配促销指定的会员卡等级">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="LoyaltyThreshold" runat="server" Label="混配促销指定的会员忠诚度阀值">
                                    </ext:Label>
                                    <ext:Label ID="HitTypeView" runat="server" Label="命中类型">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow16" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="HitOPView" runat="server" Label="命中关系操作符">
                                    </ext:Label>
                                    <ext:Label ID="HitAmount" runat="server" Label="命中金额">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow17" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="Label3" runat="server" Label="混配促销指定的会员忠诚度阀值">
                                    </ext:Label>
                                    <ext:Label ID="Label4" runat="server" Label="命中类型">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow18" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="HitQty" runat="server" Label="命中数量">
                                    </ext:Label>
                                    <ext:Label ID="GiftTypeView" runat="server" Label="礼品类型">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow19" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="GiftQty" runat="server" Label="礼品货品数量">
                                    </ext:Label>
                                    <ext:Label ID="PromotionTypeView" runat="server" Label="折扣金额设定类型">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow20" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="PromotionOnView" runat="server" Label="折扣实现方式">
                                    </ext:Label>
                                    <ext:Label ID="AmountTypeView" runat="server" Label="指定金额内容类型">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow21" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="Amount" runat="server" Label="金额或者折扣">
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
                    <ext:DropDownList ID="MNMType" runat="server" Label="促销命中条件类型" Hidden="true">
                        <ext:ListItem Text="Promotion By Hit Qty" Value="0" />
                        <ext:ListItem Text="Promotion By Hit Amount" Value="1" />
                        <ext:ListItem Text="Promotion By Sales Amount" Value="2" />
                    </ext:DropDownList>
                    <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" Hidden="true">
                    </ext:DropDownList>
                    <ext:DropDownList ID="StoreGroupCode" runat="server" Label="Store Group Code" Hidden="true">
                    </ext:DropDownList>
                    <ext:RadioButtonList ID="LoyaltyOnly" runat="server" Label="是否仅会员混配促销" Hidden="true">
                        <ext:RadioItem Text="No" Value="0" Selected="true" />
                        <ext:RadioItem Text="Yes" Value="1" />
                    </ext:RadioButtonList>
                    <ext:DropDownList ID="HitType" runat="server" Label="命中类型" Hidden="true">
                        <ext:ListItem Text="Hit must be same SKU" Value="0" Selected="true" />
                        <ext:ListItem Text="Hit must be each SKU" Value="1" />
                        <ext:ListItem Text="Hit can be any SKU" Value="2" />
                        <ext:ListItem Text="Hit Qty is fixed" Value="99" />
                    </ext:DropDownList>
                    <ext:DropDownList ID="HitOP" runat="server" Label="操作符" Hidden="true">
                        <ext:ListItem Text="--------" Value="0" />
                        <ext:ListItem Text="=" Value="1" />
                        <ext:ListItem Text="<>" Value="2" />
                        <ext:ListItem Text="&lt=" Value="3" />
                        <ext:ListItem Text="&gt=" Value="4" />
                        <ext:ListItem Text="<" Value="5" />
                        <ext:ListItem Text=">" Value="6" />
                    </ext:DropDownList>
                    <ext:DropDownList ID="GiftType" runat="server" Label="礼品类型" Hidden="true">
                        <ext:ListItem Text="Gift must be same SKU" Value="0" Selected="true" />
                        <ext:ListItem Text="Gift must be each SKU" Value="1" />
                        <ext:ListItem Text="Gift can be any SKU" Value="2" />
                        <ext:ListItem Text="Gift must be same SKU with Hit " Value="3" />
                        <ext:ListItem Text="Gift Qty is fixed" Value="99" />
                    </ext:DropDownList>
                    <ext:DropDownList ID="PromotionType" runat="server" Label="折扣金额设定类型" Hidden="true">
                        <ext:ListItem Text="Sales at" Value="0" Selected="true" />
                        <ext:ListItem Text="Sales off" Value="1" />
                    </ext:DropDownList>
                    <ext:DropDownList ID="PromotionOn" runat="server" Label="折扣实现方式" Hidden="true">
                        <ext:ListItem Text="Discount on Hit" Value="0" Selected="true" />
                        <ext:ListItem Text="Discount on Gift" Value="1" />
                        <ext:ListItem Text="Discount on Transaction" Value="2" />
                    </ext:DropDownList>
                    <ext:RadioButtonList ID="AmountType" runat="server" Label="指定金额内容类型" Hidden="true">
                        <ext:RadioItem Text="金额" Value="$" Selected="true" />
                        <ext:RadioItem Text="百分比" Value="%" />
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
                                    <asp:Label ID="lblEntityType" runat="server" Text='<%# Eval("EntityTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="货品的类型">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("TypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="货品数量">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
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
