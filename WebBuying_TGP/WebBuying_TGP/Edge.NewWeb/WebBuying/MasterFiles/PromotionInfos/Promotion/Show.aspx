<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                                    <ext:Label ID="PromotionCode" runat="server" Label="Promotional Code">
                                    </ext:Label>
                                    <ext:Label ID="PromotionDesc1" runat="server" Label="Promotional Description 1">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="PromotionDesc2" runat="server" Label="Promotional Description 2">
                                    </ext:Label>
                                    <ext:Label ID="PromotionDesc3" runat="server" Label="Promotional Description 3">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="PromotionNote" runat="server" Label="Remark">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="LoyaltyFlagView" runat="server" Label="是否仅会员促销">
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
                                    <ext:Label ID="ApproveOn" runat="server" Label="Approved On">
                                    </ext:Label>
                                    <ext:Label ID="ApproveBy" runat="server" Label="Approved By">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="CreatedOn" runat="server" Label="创建时间">
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
                    <ext:DropDownList ID="PromotionType" runat="server" Label="促销命中条件类型" Hidden="true">
                        <ext:ListItem Text="Promotion By Hit Qty" Value="0" />
                        <ext:ListItem Text="Promotion By Hit Amount" Value="1" />
                        <ext:ListItem Text="Promotion By Sales Amount" Value="2" />
                    </ext:DropDownList>
                    <ext:RadioButtonList ID="LoyaltyFlag" runat="server" Label="是否仅会员促销" Hidden="true">
                        <ext:RadioItem Text="不是" Value="0" Selected="true" />
                        <ext:RadioItem Text="是的" Value="1" />
                    </ext:RadioButtonList>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel6" runat="server" EnableCollapse="True" Title="店铺设置">
                <Items>
                    <ext:SimpleForm ID="SimpleForm4" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:Label ID="StoreIDView" runat="server" Label="店铺编码">
                            </ext:Label>
                            <ext:Label ID="StoreGroupIDView" runat="server" Label="Store Group Code">
                            </ext:Label>
                            <ext:DropDownList ID="StoreID" runat="server" Label="店铺编码" Hidden="true">
                            </ext:DropDownList>
                            <ext:DropDownList ID="StoreGroupID" runat="server" Label="Store Group Code" Hidden="true">
                            </ext:DropDownList>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="促销时间设置">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:Label ID="StartDate" runat="server" Label="促销生效日期">
                            </ext:Label>
                            <ext:Label ID="EndDate" runat="server" Label="促销失效日期">
                            </ext:Label>
                            <ext:Label ID="StartTime" runat="server" Label="促销生效时间">
                            </ext:Label>
                            <ext:Label ID="EndTime" runat="server" Label="促销失效时间">
                            </ext:Label>
                            <ext:Label ID="DayFlagCode" runat="server" Label="一月中促销生效日">
                            </ext:Label>
                            <ext:Label ID="WeekFlagCode" runat="server" Label="一周中促销生效日">
                            </ext:Label>
                            <ext:Label ID="MonthFlagCode" runat="server" Label="促销生效月">
                            </ext:Label>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="促销针对人群表">
                <Items>
                    <ext:Grid ID="Grid3" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="ObjectKey" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid3_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="促销指定的会员卡类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("LoyaltyCardTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="促销指定的会员卡等级">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("LoyaltyCardGradeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="促销指定的会员忠诚度阀值">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("LoyaltyThreshold") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="是否销售当日生日促销">
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("LoyaltyBirthdayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="促销命中条件表">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                        DataKeyNames="KeyID" AllowPaging="true" IsDatabasePaging="true" ForceFit="true"
                        OnPageIndexChange="Grid1_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="逻辑关系">
                                <ItemTemplate>
                                    <asp:Label ID="lblHitLogicalOpr" runat="server" Text='<%# Eval("LogicalOprName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中类型">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityType" runat="server" Text='<%# Eval("HitTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中金额或数量">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("HitValue") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中关系操作符">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("HitOPName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中货品条件">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("HitItemName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="促销礼品表">
                <Items>
                    <ext:Grid ID="Grid2" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                        DataKeyNames="KeyID" AllowPaging="true" IsDatabasePaging="true" ForceFit="true"
                        OnPageIndexChange="Grid2_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="逻辑关系">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("LogicalOprName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="促销实现方式">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("GiftTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="折扣金额实现的方式">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("DiscountOnName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="折扣金额设定类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("DiscountTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="促销内容值">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("PromotionValue") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="促销货品数量">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("PromotionGiftQty") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="促销货品条件">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("GiftItemName") %>'></asp:Label>
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
