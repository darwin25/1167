<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.ChangeStatus.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--  <script type="text/javascript" src='<%#GetjQueryPath() %>'></script>
    <script type="text/javascript" src='<%#GetjQueryValidatePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSMultiLanguagePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSFunctionPath()%>'></script>
    <script type="text/javascript" src='<%#GetJSPaginationPath() %>'></script>
    <link rel="stylesheet" type="text/css" href='<%#GetPaginationCssPath() %>' />
    <script type="text/javascript" src='<%#GetMy97DatePickerPath() %>'></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
        });

    </script>--%>
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
                                    <ext:DropDownList ID="Brand" runat="server" Label="品牌：" ShowRedStar="true"
                                        AutoPostBack="true" Enabled="false" Resizable="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="StoreCode" runat="server" Label="店铺号：" ShowRedStar="true" Enabled="false"
                                        Resizable="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
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
                            <ext:TemplateField Width="60px" HeaderText="新状态">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("StatusName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="创建日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="原有效日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBy2" runat="server" Text='<%#Eval("OrgExpiryDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <%--  <asp:HiddenField ID="CreatedBy" runat="server" />
    <asp:HiddenField ID="ApproveBy" runat="server" />
    <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：<%=this.PageName %></b>
    </div>
    <div style="padding-bottom: 10px;">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="4" align="left">
                交易信息
            </th>
        </tr>
        <tr>
            <td align="right" width="15%">
                交易编号：
            </td>
            <td width="35%">
                <asp:Label ID="CouponAdjustNumber" runat="server"></asp:Label>
            </td>
            <td align="right" width="15%">
                交易状态：
            </td>
            <td width="35%">
                <asp:Label ID="lblApproveStatus" runat="server" Text="P"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                交易创建工作日期：
            </td>
            <td>
                <asp:Label ID="CreatedBusDate" runat="server"></asp:Label>
            </td>
            <td align="right">
                交易批核工作日期：
            </td>
            <td>
                <asp:Label ID="ApproveBusDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                交易创建时间：
            </td>
            <td>
                <asp:Label ID="CreatedOn" runat="server"></asp:Label>
            </td>
            <td align="right">
                创建人：
            </td>
            <td>
                <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                批核时间：
            </td>
            <td>
                <asp:Label ID="ApproveOn" runat="server"></asp:Label>
            </td>
            <td align="right">
                批核人：
            </td>
            <td>
                <asp:Label ID="lblApproveBy" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                授权号：
            </td>
            <td>
                <asp:Label ID="ApprovalCode" runat="server"></asp:Label>
            </td>
            <td align="right">
                备注：
            </td>
            <td>
                <asp:TextBox ID="Note" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="4" align="left">
                修改选项
            </th>
        </tr>
        <tr>
            <td align="right">
                原因：
            </td>
            <td>
                <asp:DropDownList ID="ReasonID" TabIndex="2" runat="server" CssClass="dropdownlist required cancel">
                </asp:DropDownList>
                <span class="star">*</span>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <th colspan="4" align="left">
                待修改状态优惠券列表
            </th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtablelist">
                            <tr>
                                <th width="10%">
                                    优惠券号码
                                </th>
                                <th width="10%">
                                    优惠券物理编号
                                </th>
                                <th width="20%">
                                    优惠券类型
                                </th>
                                <th width="10%">
                                    批次号
                                </th>
                                <th width="10%">
                                    面额
                                </th>
                                <th width="10%">
                                    原状态
                                </th>
                                <th width="10%">
                                    新状态
                                </th>
                                <th width="10%">
                                    创建日期
                                </th>
                                <th width="10%">
                                    有效日期
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblCouponNumber" runat="server" Text='<%#Eval("CouponNumber")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCouponUID" runat="server" Text='<%#Eval("CouponUID")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCouponType" runat="server" Text='<%#Eval("CouponType")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblBatchCouponID" runat="server" Text='<%#Eval("BatchCode")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCouponAmount" runat="server" Text='<%#Eval("CouponAmount","{0:0.00}")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblOrgStatus" runat="server" Text='<%#Eval("OrgStatusName")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCouponStatus" runat="server" Text='<%#Eval("StatusName")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd}")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblExpiryDate" runat="server" Text='<%#Eval("CouponExpiryDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtablelist"
                    runat="server" id="dtTotal" visible="false">
                    <tr>
                        <td align="center">
                            汇总：
                        </td>
                        <td align="center">
                            面额汇总：
                            <asp:Label ID="lblTotalDenomination" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <div style="line-height: 30px; height: 30px;" />
                <div id="Pagination" class="right flickr" />
                <div style="margin-top: 10px; text-align: center;" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <div align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="提交" OnClick="btnAdd_Click" CssClass="submit"
                        OnClientClick="return confirm( 'Are you sure? ');"></asp:Button>
                    <input type="button" name="button1" value="返 回" onclick="location.href= 'List.aspx'"
                        class="submit" />
                </div>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; text-align: center;">
    </div>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    <%-- <script type="text/javascript">
        
         $(function() {
            //分页参数设置
            $("#Pagination").pagination(<%=pcount %>, {
            callback: pageselectCallback,
            prev_text: "« ",
            next_text: " »",
            items_per_page:<%=pagesize %>,
		    num_display_entries:3,
		    current_page:<%=page %>,
		    num_edge_entries:2,
		    link_to:"?page=__id__&id=<%=this.id %>"
           });
        });
        function pageselectCallback(page_id, jq) {
           //alert(page_id); 回调函数，进一步使用请参阅说明文档
        }

        $(function() {
            $(".msgtablelist tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtablelist tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>--%>
    </form>
</body>
</html>
