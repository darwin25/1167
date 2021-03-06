﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnConfirmation.Modify" %>

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
                    <ext:Button ID="btnSaveClose" ValidateForms="sform1,sform2" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="交易信息"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:HiddenField ID="ApproveStatus" runat="server" Label="交易状态：" Text="P">
                    </ext:HiddenField>
                    <ext:Form ID="sform1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponReceiveNumber" runat="server" Label="交易编号：">
                                    </ext:Label>
                                    <ext:Label ID="lblReferenceNo" runat="server" Label="参考编号：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblApproveStatus" runat="server" Label="交易状态：">
                                    </ext:Label>
                                    <ext:Label ID="ApprovalCode" runat="server" Label="授权号：">
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
                                    <ext:Label ID="CreatedOn" runat="server" Label="交易创建时间：">
                                    </ext:Label>
                                   <ext:Label ID="ApproveOn" runat="server" Label="批核时间：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblCreatedBy" runat="server" Label="创建人：">
                                    </ext:Label>
                                    <ext:Label ID="lblApproveBy" runat="server" Label="批核人：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="Remark" runat="server" Label="备注：">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="库存(出)地点信息"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="sForm4" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="SupplierID" runat="server" Label="供货商：" OnSelectedIndexChanged="SupplierID_SelectedIndexChanged"
                                        AutoPostBack="True" Resizable="true" Required="true" ShowRedStar="true" Enabled="false">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="SupplierAddress" runat="server" Label="地址：" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="SuppliertContactName" runat="server" Label="联系人：" Enabled="false">
                                    </ext:TextBox>
                                    <ext:TextBox ID="SupplierPhone" runat="server" Label="联系电话：" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="库存(入)地点信息"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="sform2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="StoreID" runat="server" Label="总部：" OnSelectedIndexChanged="StoreID_SelectedIndexChanged"
                                        AutoPostBack="True" Resizable="true" Required="true" ShowRedStar="true" Enabled="false" 
                                        CompareType="String" CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="StorerAddress" runat="server" Label="地址：" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="StoreContactName" runat="server" Label="联系人：" Enabled="false">
                                    </ext:TextBox>
                                    <ext:TextBox ID="StorePhone" runat="server" Label="联系电话：" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="StoreEmail" runat="server" Label="邮件发送：">
                                    </ext:TextBox>
                                    <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Offsets"></ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="优惠券列表"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Grid ID="Grid2" ShowBorder="false" ShowHeader="false" AutoHeight="true" PageSize="10"
                        runat="server" EnableCheckBoxSelect="false" DataKeyNames="CouponNumber" AllowPaging="true"
                        IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true" ForceFitAllTime="true"
                        OnPageIndexChange="Grid2_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="优惠券类型编号">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["CouponTypeCode"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券类型名称">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["CouponTypeName"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券批次号">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["BatchCouponCode"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券号码">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["CouponNumber"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券物理编号">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["CouponUID"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券面额">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["CouponAmount"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券状态">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["StatusName"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="库存状态">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["StockStatusName"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="库存所在地点">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["FromStoreName"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="创建日期">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["CouponIssueDate"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="过期日期">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["CouponExpiryDate"]%>
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




