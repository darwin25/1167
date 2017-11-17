<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponQuery.List" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%-- <script type="text/javascript" src='<%#GetjQueryPath() %>'></script>
    <script type="text/javascript" src='<%#GetjQueryValidatePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSFunctionPath()%>'></script>
    <script type="text/javascript" src='<%#GetMy97DatePickerPath() %>'></script>
    <script type="text/javascript" src='<%#GetJSThickBoxPath() %>'></script>
    <script type="text/javascript" src='<%#GetJSMultiLanguagePath() %>'></script>
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
        function check() {
            var reg = /^(\d{1,2},){0,1}(\d{1,3},){0,1}\d{1,3}(\.\d{1,2})?$/gi;
            var regDigits = /^\d+$/gi;

            var couponTypeAmount = $("#CouponTypeAmount").val();
            var couponNumber = $("#CouponNumber").val();
            var couponUID = $("#CouponUID").val();

            if (couponTypeAmount.length > 0 && !reg.exec(couponTypeAmount)) return false;
            if (couponNumber.length > 0 && !regDigits.exec(couponNumber)) return false;
            if (couponUID.length > 0 && !regDigits.exec(couponUID)) return false;

            window.top.tb_show();
            return true;
        }
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        EnableBackgroundColor="true" Title="" AutoScroll="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnSearch" Icon="Find" runat="server" Text="查询" OnClick="btnSearch_Click"
                        ValidateForms="form2">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="查询条件"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="form2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="CouponTypeID" runat="server" Label="优惠劵类型：" 
                                        AutoPostBack="True" OnSelectedIndexChanged="CouponTypeID_SelectedIndexChanged" Resizable="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="BatchCouponID" runat="server" Label="优惠劵批次编号：" EnableEdit="true"
                                        Resizable="true" ForceSelection="false">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="CouponNumber" runat="server" Label="优惠劵编号：" MaxLength="20">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="CouponUID" runat="server" Label="优惠劵物理编号：" MaxLength="21">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="CouponTypeAmount" runat="server" Label="面额：" MaxValue="100000000" NoNegative="true">
                                    </ext:NumberBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="Status" runat="server" Label="状态：" Resizable="true">
                                    </ext:DropDownList >
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="Products" runat="server" Label="使用产品：" Resizable="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="Deparment" runat="server" Label="使用部门：" Resizable="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="CouponCreatedOn" runat="server" Label="创建日期：" DateFormatString="yyyy-MM-dd"
                                        MaxLength="512">
                                    </ext:DatePicker>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DatePicker ID="CouponExpiryDate" runat="server" Label="有效日期：" DateFormatString="yyyy-MM-dd"
                                        MaxLength="512">
                                    </ext:DatePicker>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="Brand" runat="server" Label="品牌："
                                        OnSelectedIndexChanged="Brand_SelectedIndexChanged" AutoPostBack="true" Resizable="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="StoreID" runat="server" Label="店铺号："
                                        AutoPostBack="True"  Resizable="true">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="查询结果"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Grid ID="ResultGrid" ShowBorder="false" ShowHeader="false" AutoHeight="true"
                        PageSize="3" runat="server" EnableCheckBoxSelect="false" DataKeyNames="CouponNumber"
                        AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                        ForceFitAllTime="true" OnPageIndexChange="ResultGrid_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="序号">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="115px" HeaderText="优惠券编号">
                                <ItemTemplate>
                                    <asp:Label ID="lblCouponNumber" runat="server" Text='<%#Eval("CouponNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="115px" HeaderText="优惠券物理编号">
                                <ItemTemplate>
                                    <asp:Label ID="glblApproveStatus" runat="server" Text='<%#Eval("CouponUID")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="优惠劵类型编号">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveCode" runat="server" Text='<%#Eval("CouponTypeCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="批次号">
                                <ItemTemplate>
                                    <asp:Label ID="lblBatchCouponID" runat="server" Text='<%#Eval("BatchCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="状态">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusName" runat="server" Text='<%#Eval("StatusName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="金额">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBusDate" runat="server" Text='<%#Eval("CouponAmount","{0:0.00}")%>'></asp:Label>
                                    <asp:HiddenField ID="AmountStatus" runat="server" Value='<%#Eval("NewCouponAmount","{0:0.00}")%>' />
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="创建日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="有效日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblCouponExpiryDate" runat="server" Text='<%#Eval("CouponExpiryDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="详细" ToolTip="详细" DataTextFormatString="{0}" DataIFrameUrlFields="CouponNumber,CouponUID,BatchCode,CouponTypeCode,CouponTypeName,StatusName,NewCouponAmount,CreatedOnText,CouponExpiryDateText,CouponTypeID"
                                DataIFrameUrlFormatString="Show.aspx?id={0}&couponUID={1}&batchCode={2}&CouponTypeCode={3}&CouponTypeName={4}&status={5}&amount={6}&CouponIssueDate={7}&CouponExpiryDate={8}&couponTypeID={9}"
                                Title="详细" />
                        </Columns>
                    </ext:Grid>
                    <ext:Window EnableClose="true" ID="Window1" Title="详细" Popup="false" EnableIFrame="true" runat="server"
                        CloseAction="Hide"  IFrameUrl="about:blank"
                        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="900px"
                        Height="580px">
                    </ext:Window>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <%--<div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：<%=this.PageName %></b>
    </div>
    <div style="padding-bottom: 10px;">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th align="left">
                <%=this.PageName %>
            </th>
            <th align="right">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查询" CssClass="submit"
                    OnClientClick="check();" />
            </th>
        </tr>
        <tr>
            <td align="right">
                优惠劵类型：
            </td>
            <td>
                <asp:DropDownList ID="CouponTypeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CouponTypeID_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                优惠劵批次编号：
            </td>
            <td>
                <bac:batchAutoComplete ID="BatchCouponID" runat="server" CoupontTypeClientID="CouponTypeID" />
            </td>
        </tr>
        <tr>
            <td align="right">
                优惠劵编号：
            </td>
            <td>
                <asp:TextBox ID="CouponNumber" runat="server" MaxLength="20" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                优惠劵物理编号：
            </td>
            <td>
                <asp:TextBox ID="CouponUID" runat="server" MaxLength="21" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                面额：
            </td>
            <td>
                <asp:TextBox ID="CouponTypeAmount" runat="server" CssClass="input svaAmount"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                状态：
            </td>
            <td>
                <asp:DropDownList ID="Status" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                使用产品：
            </td>
            <td>
                <asp:DropDownList ID="Products" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                使用部门：
            </td>
            <td width="75%">
                <asp:DropDownList ID="Deparment" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                创建日期：
            </td>
            <td>
                <asp:TextBox ID="CouponCreatedOn" runat="server" onclick="WdatePicker()" CssClass="input dateISO"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                有效日期：
            </td>
            <td>
                <asp:TextBox ID="CouponExpiryDate" runat="server" onclick="WdatePicker()" CssClass="input dateISO"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtablelist" id="msgtablelist">
                            <tr>
                                <th width="6%">
                                    序号
                                </th>
                                <th width="10%">
                                    优惠劵编号
                                </th>
                                <th width="10%">
                                    优惠劵物理编号
                                </th>
                                <th width="15%">
                                    优惠劵类型编号
                                </th>
                                <th width="10%">
                                    批次号
                                </th>
                                <th width="6%">
                                    状态
                                </th>
                                <th width="6%">
                                    面额
                                </th>
                                <th width="10%">
                                    创建日期
                                </th>
                                <th width="10%">
                                    有效日期
                                </th>
                                <th width="6%">
                                    &nbsp;
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("ID")%>
                            </td>
                            <td align="center">
                                <%#Eval("CouponNumber")%>
                            </td>
                            <td align="center">
                                <%#Eval("CouponUID")%>
                            </td>
                            <td align="center">
                                <%#Eval("CouponTypeCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("BatchCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("StatusName")%>
                            </td>
                            <td align="center">
                                <%#Eval("NewCouponAmount")%>
                            </td>
                            <td align="center">
                                <%#Eval("CreatedOn", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="center">
                                <%#Eval("CouponExpiryDate","{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="center">
                                <span class="btn_bg"><a href="Show.aspx?id=<%#Eval("CouponNumber") %>&couponUID=<%#Eval("CouponUID") %>&batchCode=<%#Eval("BatchCode")%>&CouponTypeCode=<%#Eval("CouponTypeCode") %>&CouponTypeName=<%#Eval("CouponTypeName") %>&status=<%#Eval("StatusName")%>&amount= <%#Eval("NewCouponAmount","{0:N02}")%>&CouponIssueDate=<%#Eval("CreatedOn","{0:yyyy-MM-dd}")%>&CouponExpiryDate=<%#Eval("CouponExpiryDate","{0:yyyy-MM-dd}")%>&couponTypeID=<%#Eval("CouponTypeID") %>">
                                    详细</a> </span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="clear" />
                <div class="right">
                    <webdiyer:AspNetPager ID="rptListPager" runat="server" CustomInfoTextAlign="Left"
                        FirstPageText="First" HorizontalAlign="Right" InvalidPageIndexErrorMessage="Page index is not a valid value."
                        LastPageText="Last" NextPageText="Next" PageIndexBoxType="TextBox" PageIndexOutOfRangeErrorMessage="Page index out of range!"
                        PrevPageText="Prev" ShowPageIndexBox="Always" SubmitButtonText="Go" SubmitButtonClass="pagerSubmit"
                        TextBeforePageIndexBox="" OnPageChanged="rptListPager_PageChanged" CssClass="asppager"
                        CurrentPageButtonClass="cpb" CustomInfoClass="asppagercustom" CustomInfoHTML="Current:%CurrentPageIndex%/%PageCount% Total:%RecordCount% "
                        CustomInfoSectionWidth="20%" ShowCustomInfoSection="Left" AlwaysShow="False"
                        LayoutType="Table">
                    </webdiyer:AspNetPager>
                </div>
            </td>
        </tr>
    </table>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
    <%--  <script type="text/javascript">

        $(function () {
            $(".msgtablelist tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtablelist tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>--%>
</body>
</html>
