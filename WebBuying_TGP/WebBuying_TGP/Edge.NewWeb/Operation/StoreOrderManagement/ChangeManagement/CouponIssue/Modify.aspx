<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponIssue.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        EnableBackgroundColor="true" Title="" AutoScroll="true" Layout="Form">
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="from1,form2" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:HiddenField ID="CreatedBy" runat="server" />
            <ext:HiddenField ID="ApproveBy" runat="server" />
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="交易信息"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="from1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponAdjustNumber" runat="server" Label="交易编号：">
                                    </ext:Label>
                                    <ext:Label ID="ApproveStatus" runat="server" Label="交易状态：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedBusDate" runat="server" Label="交易创建工作日期：">
                                    </ext:Label>
                                    <ext:Label ID="ApproveBusDate" runat="server" Label="交易批核工作日期：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedOn" runat="server" Label="创建时间：">
                                    </ext:Label>
                                    <ext:Label ID="lblCreatedBy" runat="server" Label="创建人：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="ApproveOn" runat="server" Label="批核时间：">
                                    </ext:Label>
                                    <ext:Label ID="lblApproveBy" runat="server" Label="批核人：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="ApprovalCode" runat="server" Label="授权号：">
                                    </ext:Label>
                                    <ext:TextBox ID="Note" runat="server" Label="备注：">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="修改选项"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="form2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="Brand" runat="server" Label="品牌：" ShowRedStar="true" Required="true"
                                        OnSelectedIndexChanged="Brand_SelectedIndexChanged" AutoPostBack="true" Resizable="true" Enabled="false"
                                        CompareType="String" CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="StoreID" runat="server" Label="发行对象：" ShowRedStar="true" Required="true" Enabled="false"
                                        AutoPostBack="True" Resizable="true" CompareType="String" CompareValue="-1" CompareOperator="NotEqual"
                                        CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                    <%--<ext:DropDownList ID="StoreCode" runat="server" Label="发行对象：" ShowRedStar="true"
                                        Required="true">
                                    </ext:DropDownList>--%>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponStatus" runat="server" Label="状态：">
                                    </ext:Label>
                                    <ext:DropDownList ID="ReasonID" runat="server" Label="原因：" ShowRedStar="true" Required="true"
                                        Resizable="true" CompareType="String" CompareValue="-1" CompareOperator="NotEqual"
                                        CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="发行优惠券列表"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" AutoHeight="true" PageSize="3"
                        runat="server" EnableCheckBoxSelect="false" DataKeyNames="CouponAdjustNumber"
                        AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                        ForceFitAllTime="true" OnPageIndexChange="Grid1_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server" Position="Top">
                                <Items>
                                    <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                                    </ext:ToolbarFill>
                                    <ext:Label ID="Label3" runat="server" Text="面额汇总：">
                                    </ext:Label>
                                    <ext:Label ID="lblTotalDenomination" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="优惠券号码">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("CouponNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券物理编号">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveStatus" runat="server" Text='<%#Eval("CouponUID")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券类型">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveCode" runat="server" Text='<%#Eval("CouponType")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="批次号">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBusDate" runat="server" Text='<%#Eval("BatchCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="面额">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBusDate" runat="server" Text='<%#Eval("CouponAmount","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="原状态">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%#Eval("OrgStatusName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="创建日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="有效日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBy2" runat="server" Text='<%#Eval("CouponExpiryDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
