<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnOrder.Add" %>

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
                    <ext:Button ID="btnSaveClose" ValidateForms="sform1,sForm4,sform2" Icon="SystemSaveClose"
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
                                    <ext:Label ID="CouponReturnNumber" runat="server" Label="交易编号：">
                                    </ext:Label>
                                    <ext:Label ID="ApprovalCode" runat="server" Label="授权号：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblApproveStatus" runat="server" Label="交易状态：">
                                    </ext:Label>
                                    <ext:Label ID="ApproveBusDate" runat="server" Label="交易批核工作日期：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedBusDate" runat="server" Label="交易创建工作日期：">
                                    </ext:Label>
                                    <ext:Label ID="ApproveOn" runat="server" Label="批核时间：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedOn" runat="server" Label="交易创建时间：">
                                    </ext:Label>
                                    <ext:Label ID="lblApproveBy" runat="server" Label="批核人：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblCreatedBy" runat="server" Label="创建人：">
                                    </ext:Label>
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
                                    <ext:DropDownList ID="BrandID" runat="server" Label="品牌：" AutoPostBack="true"
                                        OnSelectedIndexChanged="BrandID_SelectedIndexChanged" Resizable="true" Required="true" ShowRedStar="true" 
                                        CompareType="String" CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择有效值">                             
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="FromStoreID" runat="server" Label="店铺：" OnSelectedIndexChanged="FromStoreID_SelectedIndexChanged"
                                        AutoPostBack="True" Resizable="true" Required="true" ShowRedStar="true"
                                        CompareType="String" CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="FromAddress" runat="server" Label="地址：" Enabled="false">
                                    </ext:TextBox>
                                    <ext:TextBox ID="FromContactName" runat="server" Label="联系人：" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="FromContactNumber" runat="server" Label="联系电话：" Enabled="false">
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
                                        AutoPostBack="True" Resizable="true" Required="true" ShowRedStar="true" 
                                        CompareType="String" CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="SendAddress" runat="server" Label="地址：" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="StoreContactName" runat="server" Label="联系人：" Enabled="false">
                                    </ext:TextBox>
                                    <ext:TextBox ID="StoreContactPhone" runat="server" Label="联系电话：" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="SendMethod" runat="server" Label="退货单发送方式：" Resizable="true">
                                        <ext:ListItem Text="直接交付（打印）" Value="1" Selected="true" />
                                        <ext:ListItem Text="SMS" Value="2" />
                                        <ext:ListItem Text="Email" Value="3" />
                                        <ext:ListItem Text="Social Network" Value="4" />
                                    </ext:DropDownList>
                                    <ext:TextBox ID="StoreContactEmail" runat="server" Label="邮件发送：">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="优惠券列表"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="sForm5" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="CouponTypeID" runat="server" Label="优惠券类型："
                                        Resizable="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="BatchCouponID" runat="server" Label="优惠券批次号："
                                        Resizable="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="sCouponQty" runat="server" Label="优惠券数量：" MaxValue="10000" 
                                        NoDecimal="true" NoNegative="true">
                                    </ext:NumberBox>
                                    <ext:TextBox ID="sFirstCouponNumber" runat="server" Label="第一张优惠券号码：">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="sCouponUID1" runat="server" Label="第一张优惠券物理编号：">
                                    </ext:TextBox>
                                    <ext:Button ID="SearchButton" Text="搜索" Icon="Find" runat="server" OnClick="SearchButton_Click" ValidateForms="SearchForm">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" AutoHeight="true" PageSize="10"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="CouponNumber" AllowPaging="true"
                        IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true" ForceFitAllTime="true"
                        OnPageIndexChange="Grid1_PageIndexChange">
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
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar3" runat="server">
                                <Items>
                                    <ext:Button ID="btnAdd1" Text="添加到优惠券列表" Icon="Add" runat="server" OnClick="btnAdd1_OnClick">
                                    </ext:Button>
                                    <ext:Button ID="btnAddAll" Text="全部添加" Icon="Add" runat="server" OnClick="btnAddAll_OnClick">
                                    </ext:Button>
                                    <ext:Button ID="btnDelete1" Text="删除" Icon="Delete" runat="server" OnClick="btnDelete1_OnClick" Hidden="true">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                    </ext:Grid>
                    <ext:Grid ID="Grid2" ShowBorder="false" ShowHeader="false" AutoHeight="true" PageSize="10"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="CouponNumber" AllowPaging="true"
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
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnDelete2" Text="删除" Icon="Delete" runat="server" OnClick="btnDelete2_OnClick">
                                    </ext:Button>
                                    <ext:Button ID="btnDeleteAll" Text="全部删除" Icon="Delete" runat="server" OnClick="btnDeleteAll_OnClick">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>

