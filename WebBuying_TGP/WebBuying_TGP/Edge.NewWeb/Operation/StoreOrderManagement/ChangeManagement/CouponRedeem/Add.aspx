<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponRedeem.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="from1,form2,form3" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭">
                    </ext:Button>
                    <ext:ToolbarFill ID="ToolbarFill3" runat="server">
                    </ext:ToolbarFill>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="交易信息"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:HiddenField ID="CreatedBy" runat="server" />
                    <ext:HiddenField ID="ApproveBy" runat="server" />
                    <ext:HiddenField ID="ApproveStatus" runat="server" Text="P" />
                    <ext:Form ID="from1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponAdjustNumber" runat="server" Label="交易编号：">
                                    </ext:Label>
                                    <ext:Label ID="lblApproveStatus" runat="server" Label="交易状态：">
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
                                    <ext:TextBox ID="CouponStatus" runat="server" Label="状态：" Enabled="false" ShowRedStar="true">
                                    </ext:TextBox>
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
            <ext:GroupPanel ID="GroupPanel6" runat="server" EnableCollapse="True" Title="参考交易资料"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="form3" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="Brand" runat="server" Label="品牌：" ShowRedStar="true" Required="true"
                                        OnSelectedIndexChanged="Brand_SelectedIndexChanged" AutoPostBack="true" Resizable="true"
                                        CompareType="String" CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="StoreID" runat="server" Label="店铺号：" ShowRedStar="true" Required="true"
                                        AutoPostBack="True" OnSelectedIndexChanged="StoreID_SelectedIndexChanged" Resizable="true"
                                        CompareType="String" CompareValue="-1" CompareOperator="NotEqual" CompareMessage="请选择有效值">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="ServerCode" runat="server" Label="服务器编号：" MaxLength="30">
                                    </ext:TextBox>
                                    <ext:TextBox ID="RegisterCode" runat="server" Label="收银机号：" MaxLength="30" ShowRedStar="true"
                                        Required="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="TxnDate" runat="server" DateFormatString="yyyy-MM-dd" Label="收银端交易日期："
                                        ShowRedStar="true" Required="true">
                                    </ext:DatePicker>
                                    <ext:TextBox ID="OriginalTxnNo" runat="server" Label="收银端交易编号：" MaxLength="30" ShowRedStar="true"
                                        Required="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="优惠券列表"
                AutoHeight="true" AutoWidth="true">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar5" runat="server" Position="Top">
                        <Items>
                            <ext:Button ID="btnViewSearch" Icon="Add" runat="server" Text="添加优惠券" OnClick="btnViewSearch_Click">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnDeleteResultItem" Icon="Delete" OnClick="btnDeleteResultItem_Click"
                                runat="server" Text="删除">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnClearAllResultItem" ValidateForms="SimpleForm1" Icon="Delete"
                                OnClick="btnClearAllResultItem_Click" runat="server" Text="清空">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" AutoHeight="true"
                        PageSize="3" runat="server" EnableCheckBoxSelect="true" DataKeyNames="CouponNumber"
                        AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                        ForceFitAllTime="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server" Position="Top">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Text="汇总：">
                                    </ext:Label>
                                    <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                                    </ext:ToolbarFill>
                                    <ext:Label ID="Label2" runat="server" Text="面额汇总：">
                                    </ext:Label>
                                    <ext:Label ID="lblTotalDenomination" runat="server">
                                    </ext:Label>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Label ID="lbl5" runat="server" Text="实际扣除金额汇总：">
                                    </ext:Label>
                                    <ext:Label ID="lblTotalActualTxnAmount" runat="server">
                                    </ext:Label>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Label ID="Label3" runat="server" Text="没收金额汇总：">
                                    </ext:Label>
                                    <ext:Label ID="lblTotalForfeitAmount" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="155px" HeaderText="优惠券号码">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("CouponNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="155px" HeaderText="优惠券物理编号">
                                <ItemTemplate>
                                    <asp:Label ID="glblApproveStatus" runat="server" Text='<%#Eval("CouponUID")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠券类型">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveCode" runat="server" Text='<%#Eval("CouponType")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="批次号">
                                <ItemTemplate>
                                    <asp:Label ID="lblBatchCouponID" runat="server" Text='<%#Eval("BatchCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="面额">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBusDate" runat="server" Text='<%#Eval("CouponAmount","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="实际扣除金额">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("ActualTxnAmount","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="没收金额">
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%#Eval("ForfeitAmount","{0:0.00}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="状态">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%#Eval("StatusName")%>'></asp:Label>
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
    <ext:Window EnableClose="true" ID="Window1" Title="" Popup="false" EnableIFrame="true"
        runat="server" CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" Target="Self" IsModal="True" >
        <Items>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="5px"
                EnableBackgroundColor="true" Title="" Layout="Form" Width="850px"
                Height="510px" AutoScroll="true">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar3" runat="server">
                        <Items>
                            <ext:Button ID="btnCloseSearch" Icon="SystemClose" runat="server" Text="关闭" OnClick="btnCloseSearch_Click">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnAddSearchItem" Icon="Add" runat="server" Text="添加" OnClick="btnAddSearchItem_Click">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnSearch" Icon="Find" OnClick="btnSearch_Click" runat="server" Text="搜 索">
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
                            <ext:Form ID="Form4" runat="server" ShowBorder="false" ShowHeader="false" Title=""
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
                    <ext:GroupPanel ID="GroupPanel7" runat="server" EnableCollapse="True" Title="添加选项"
                        AutoHeight="true" AutoWidth="true">
                        <Items>
                            <ext:Form ID="Form5" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                                EnableBackgroundColor="true" LabelAlign="Right">
                                <Rows>
                                    <ext:FormRow>
                                        <Items>
                                            <ext:NumberBox ID="txtActualTxnAmount" runat="server" Label="实际扣除金额（每张优惠券）：" MaxValue="100000000"
                                                NoNegative="true" ShowRedStar="true">
                                            </ext:NumberBox>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:GroupPanel>
                    <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="优惠券搜索结果列表"
                        AutoHeight="true" AutoWidth="true" AutoScroll="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar4" runat="server">
                                <Items>
                                    <ext:CheckBox ID="cbSearchAll" runat="server" AutoPostBack="true">
                                    </ext:CheckBox>
                                    <ext:Label ID="Label12" runat="server" Text="添加所有搜索结果">
                                    </ext:Label>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Items>
                            <ext:Grid ID="SearchListGrid" ShowBorder="false" ShowHeader="false" AutoHeight="true"
                                PageSize="3" runat="server" EnableCheckBoxSelect="true" DataKeyNames="CouponNumber,CouponAmount"
                                AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                                ForceFitAllTime="true" OnPageIndexChange="SearchListGrid_PageIndexChange">
                                <Columns>
                                    <ext:TemplateField Width="60px" HeaderText="优惠券号码">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("CouponNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="优惠券物理编号">
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
            </ext:Panel>
        </Items>
    </ext:Window>
    <ext:Window ID="WindowSearch" Popup="false" EnableIFrame="true" runat="server" CloseAction="Hide"
        OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="850px" Height="560px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
