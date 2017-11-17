<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual.Coupon.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <ext:SimpleForm ID="SimpleForm1" ShowBorder="true" ShowHeader="false" runat="server"
            BodyPadding="20px" EnableBackgroundColor="true" Title="SimpleForm" AutoScroll="true"
            LabelAlign="Right">
            <Toolbars>
                    <ext:Toolbar ID="Toolbar3" runat="server">
                        <Items>
                            <ext:Button ID="btnCloseSearch" Icon="SystemClose" runat="server" Text="关闭">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnAddSearchItem" Icon="Add" runat="server" Text="添加" OnClick="btnAddSearchItem_Click">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnSearch" Icon="Find" OnClick="btnSearch_Click" runat="server" Text="搜 索" ValidateForms="Form3">
                            </ext:Button>
                            <ext:ToolbarFill ID="ToolbarFill4" runat="server">
                            </ext:ToolbarFill>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="筛选条件"
                        AutoHeight="true" AutoWidth="true">
                        <Items>
                            <ext:SimpleForm ID="sform2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                                EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                                <Items>
                                    <ext:DropDownList ID="CouponBrandID" runat="server" Label="品牌：" Resizable="true"
                                         OnSelectedIndexChanged="CouponBrandID_SelectedIndexChanged" AutoPostBack="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="CouponTypeID" runat="server" Label="优惠券类型：" Resizable="true">
                                    </ext:DropDownList>
                                    <ext:NumberBox ID="CouponQty" runat="server" Label="优惠券数量："></ext:NumberBox>
                                </Items>
                            </ext:SimpleForm>
                        </Items>
                    </ext:GroupPanel>
                    <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="搜索结果列表"
                        AutoHeight="true" AutoWidth="true" AutoScroll="true">
                        <Items>
                            <ext:Panel ID="Panel11" runat="Server" BodyPadding="3px" EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" Layout="Column">
                                <Items>
                                    <ext:CheckBox ID="cbSearchAll" runat="server" AutoPostBack="true" OnCheckedChanged="cbSearchAll_OnCheckedChanged" Text="添加所有搜索结果">
                                    </ext:CheckBox>
                                </Items>
                            </ext:Panel>
                            <ext:Grid ID="SearchListGrid" ShowBorder="false" ShowHeader="false" AutoHeight="true"
                                PageSize="3" runat="server" EnableCheckBoxSelect="true" DataKeyNames="CouponTypeCode"
                                AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                                ForceFitAllTime="true" OnPageIndexChange="RegisterGrid_OnPageIndexChange" ClearSelectedRowsAfterPaging="false">
                                <Columns>
                                    <ext:TemplateField Width="130px" HeaderText="品牌">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("BrandCode")%>'></asp:Label>-                                       
                                            <asp:Label ID="lblBrandName" runat="server" Text='<%#Eval("BrandName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="130px" HeaderText="优惠券类型">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCouponTypeID" runat="server" Text='<%#Eval("CouponTypeCode")%>'></asp:Label>-
                                            <asp:Label ID="lblCouponTypeName" runat="server" Text='<%#Eval("CouponTypeName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:GroupPanel>
                </Items>
        </ext:SimpleForm>
        <ext:HiddenField ID="hfSelectedIDS" runat="server">
        </ext:HiddenField>
    </form>
</body>
</html>
