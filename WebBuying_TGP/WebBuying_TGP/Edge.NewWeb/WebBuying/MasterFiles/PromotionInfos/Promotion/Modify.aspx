<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Modify" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
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
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" >
                        <Items>
                            <ext:TextBox ID="PromotionCode" runat="server" Label="Promotional Code" Required="true" ShowRedStar="true"
                                Enabled="false" />
                            <ext:TextBox ID="PromotionDesc1" runat="server" Label="Promotional Description 1" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="PromotionDesc2" runat="server" Label="Promotional Description 2" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="PromotionDesc3" runat="server" Label="Promotional Description 3" OnTextChanged="ConvertTextboxToUpperText"
                                AutoPostBack="true" />
                            <ext:TextBox ID="PromotionNote" runat="server" Label="Remarks" />
                            <ext:RadioButtonList ID="LoyaltyFlag" runat="server" Label="是否仅会员促销" OnSelectedIndexChanged="LoyaltyFlag_SelectedIndexChanged"
                                AutoPostBack="true">
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
                            <ext:DropDownList ID="StoreID" runat="server" Label="Store Code" AutoPostBack="true">
                            </ext:DropDownList>
                            <ext:DropDownList ID="StoreGroupID" runat="server" Label="Store Group Code" OnSelectedIndexChanged="StoreGroupID_SelectedIndexChanged"
                                AutoPostBack="true">
                            </ext:DropDownList>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="促销时间设置">
                <Items>
                    <ext:SimpleForm ID="SimpleForm3" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="120">
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
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="促销针对人群表">
                <Items>
                    <ext:Grid ID="Grid3" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                        EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid3_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar3" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnMemberAdd" Icon="Add" runat="server" Text="Add" OnClick="btnMemberAdd_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnMemberDelete" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteMemberItem_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnClearAllMember" Icon="Delete" runat="server" Text="清空" OnClick="btnClearAllMemberItem_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
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
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="WindowSearch" DataTextFormatString="{0},{1}"  DataIFrameUrlFields="KeyID,PromotionCode"
                                Icon="PageEdit" Text="Edit" DataIFrameUrlFormatString="Promotion_Member/Modify.aspx?id={0}&promotioncode={1}"
                                DataWindowTitleFormatString="Edit" Title="Edit" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="促销命中条件表">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                        EnableCheckBoxSelect="true" DataKeyNames="HitSeq" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar5" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnHitAdd" Icon="Add" runat="server" Text="Add" OnClick="btnHitAdd_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnDeleteHitItem" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteHitItem_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnClearAllHitItem" Icon="Delete" runat="server" Text="清空" OnClick="btnClearAllHitItem_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
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
                             <ext:WindowField ColumnID="EditWindowField2" Width="60px" WindowID="WindowSearch" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="HitSeq,PromotionCode"
                                DataIFrameUrlFormatString="Promotion_Hit/Modify.aspx?id={0}&promotioncode={1}" DataWindowTitleFormatString="Edit"
                                Title="Edit" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="促销礼品表">
                <Items>
                    <ext:Grid ID="Grid2" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                        EnableCheckBoxSelect="true" DataKeyNames="GiftSeq" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid2_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar2" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnGiftAdd" Icon="Add" runat="server" Text="Add" OnClick="btnGiftAdd_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnDeleteGiftItem" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteGiftItem_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnClearAllGiftItem" Icon="Delete" runat="server" Text="清空" OnClick="btnClearAllGiftItem_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
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
                            <ext:WindowField ColumnID="EditWindowField3" Width="60px" WindowID="WindowSearch" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="GiftSeq,PromotionCode"
                                DataIFrameUrlFormatString="Promotion_Gift/Modify.aspx?id={0}&promotioncode={1}" DataWindowTitleFormatString="Edit"
                                Title="Edit" />
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
        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="900px"
        Height="250px">
    </ext:Window>
    <ext:Window ID="WindowSearch" Hidden="true" EnableIFrame="true" runat="server" CloseAction="Hide"
        OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    </form>
</body>
</html>
