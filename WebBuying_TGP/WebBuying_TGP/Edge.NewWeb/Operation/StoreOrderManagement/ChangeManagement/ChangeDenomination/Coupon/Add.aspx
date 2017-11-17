<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.ChangeDenomination.Coupon.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="true" ShowHeader="false" runat="server"
        BodyPadding="10px" EnableBackgroundColor="true" Title="SimpleForm" AutoScroll="true"
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
                    <ext:Form ID="Form3" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="CouponTypeID" runat="server" AutoPostBack="true" Label="优惠券类型："
                                        OnSelectedIndexChanged="CouponTypeID_SelectedIndexChanged" Resizable="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="BatchCouponID" runat="server" Label="优惠劵批次编号：" EnableEdit="true"
                                        Resizable="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="CouponCount" runat="server" Label="优惠券数量：" MaxValue="100000000"
                                        NoDecimal="true" NoNegative="true">
                                    </ext:NumberBox>
                                    <ext:TextBox ID="CouponNumber" runat="server" Label="第一张优惠券号码：" MaxLength="20">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="CouponUID" runat="server" Label="优惠劵物理编号：" MaxLength="21">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="优惠券搜索结果列表"
                AutoHeight="true" AutoWidth="true" AutoScroll="true">
                <Items>
                    <ext:Panel ID="Panel11" runat="Server" BodyPadding="3px" EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" Layout="Column">
                        <Items>
                            <ext:CheckBox ID="cbSearchAll" runat="server" AutoPostBack="true" OnCheckedChanged="cbSearchAll_OnCheckedChanged" Text="添加所有搜索结果">
                            </ext:CheckBox>
                        </Items>
                    </ext:Panel>
                    <ext:Grid ID="SearchListGrid" ShowBorder="false" ShowHeader="false" AutoHeight="true"
                        PageSize="3" runat="server" EnableCheckBoxSelect="true" DataKeyNames="CouponNumber"
                        AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                        ForceFitAllTime="true" OnPageIndexChange="RegisterGrid_OnPageIndexChange" ClearSelectedRowsAfterPaging="false">
                        <Columns>
                            <ext:TemplateField Width="130px" HeaderText="优惠券号码">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("CouponNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="130px" HeaderText="优惠券物理编号">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("CouponUID")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("CouponType")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="批次号">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("BatchCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="面额">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("CouponAmount","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="原状态">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("StatusName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="创建日期">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="有效日期">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("CouponExpiryDate","{0:yyyy-MM-dd}")%>'></asp:Label>
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
        <ext:Window ID="WindowContact" Title="" Popup="false" EnableIFrame="true" runat="server"
            CloseAction="HidePostBack" OnClose="WindowContact_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
            Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px" Top="-1000px">
        </ext:Window> 
        <ext:Window ID="WindowEnough" Title="" Popup="false" EnableIFrame="true" runat="server"
            CloseAction="HidePostBack" OnClose="WindowEnough_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
            Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px" Top="-1000px">
        </ext:Window> 
    </form>
</body>
</html>
