﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponPushManual.Show" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="20px"
            EnableBackgroundColor="true" Title="" AutoScroll="true" Layout="Form">
            <Toolbars>
                <ext:Toolbar ID="Toolbar2" runat="server">
                    <Items>
                        <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                            Text="关闭">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
            <Items>
                <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="交易信息"
                    AutoHeight="true" AutoWidth="true">
                    <Items>
                        <ext:Form ID="sform1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                            EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                            <Rows>
                                <ext:FormRow>
                                    <Items>
                                        <ext:Label ID="CouponPushNumber" runat="server" Label="交易编号：">
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
                                        <ext:Label ID="CreatedBy" runat="server" Label="创建人：">
                                        </ext:Label>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow>
                                    <Items>
                                        <ext:Label ID="ApproveOn" runat="server" Label="批核时间：">
                                        </ext:Label>
                                        <ext:Label ID="ApproveBy" runat="server" Label="批核人：">
                                        </ext:Label>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow>
                                    <Items>
                                        <ext:Label ID="ApprovalCode" runat="server" Label="授权号：">
                                        </ext:Label>
                                        <ext:Label ID="Remark" runat="server" Label="备注：">
                                        </ext:Label>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                        </ext:Form>
                    </Items>
                </ext:GroupPanel>
                <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="推送优惠券类型列表"
                    AutoHeight="true" AutoWidth="true">
                    <Items>
                        <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" AutoHeight="true"
                            PageSize="3" runat="server" DataKeyNames="CouponTypeCode" AllowPaging="true" 
                            IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                            ForceFitAllTime="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                            <Columns>
                                <ext:TemplateField Width="130px" HeaderText="品牌">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("BrandCode")%>'></asp:Label>-                                       
                                        <asp:Label ID="lblBrandName" runat="server" Text='<%#Eval("BrandName")%>'></asp:Label>
                                    </ItemTemplate>
                                </ext:TemplateField>
                                <ext:TemplateField Width="130px" HeaderText="优惠券类型">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCouponType" runat="server" Text='<%#Eval("CouponTypeCode")%>'></asp:Label>-
                                        <asp:Label ID="lblCouponTypeName" runat="server" Text='<%#Eval("CouponTypeName")%>'></asp:Label>
                                    </ItemTemplate>
                                </ext:TemplateField>
                                <ext:TemplateField Width="60px" HeaderText="优惠券数量">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("CouponQty")%>'></asp:Label>
                                    </ItemTemplate>
                                </ext:TemplateField>
                            </Columns>
                        </ext:Grid>
                    </Items>
                </ext:GroupPanel>
                <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="推送会员"
                    AutoHeight="true" AutoWidth="true">
                    <Items>
                        <ext:SimpleForm ID="sform2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                            EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                            <Items>
                                <ext:DropDownList ID="PushCardBrandID" runat="server" Label="品牌：" Hidden="true">
                                </ext:DropDownList>
                                <ext:DropDownList ID="PushCardTypeID" runat="server" Label="卡类型：" Hidden="true">
                                </ext:DropDownList>
                                <ext:DropDownList ID="PushCardGradeID" runat="server" Label="卡级别：" Hidden="true">
                                </ext:DropDownList>
                                <ext:RadioButtonList ID="RepeatPush" runat="server" Label="重复绑定" Hidden="true">
                                    <ext:RadioItem Text="是" Value="1" />
                                    <ext:RadioItem Text="否" Value="0" Selected="true" />
                                </ext:RadioButtonList>  
                                <ext:Label ID="lblPushCardBrandID" runat="server" Label="品牌：" ></ext:Label>  
                                <ext:Label ID="lblPushCardTypeID" runat="server" Label="卡类型：" ></ext:Label>  
                                <ext:Label ID="lblPushCardGradeID" runat="server" Label="卡级别：" ></ext:Label>  
                                <ext:Label ID="lblRepeatPush" runat="server" Label="重复绑定：" ></ext:Label>  
                            </Items>
                        </ext:SimpleForm>
                    </Items>
                </ext:GroupPanel>
            </Items>
        </ext:Panel>
            <ext:Window ID="WindowSearch" Popup="false" EnableIFrame="true" runat="server" CloseAction="Hide"
            OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
            Target="Top" IsModal="True" Width="850px" Height="560px">
        </ext:Window>
        <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
