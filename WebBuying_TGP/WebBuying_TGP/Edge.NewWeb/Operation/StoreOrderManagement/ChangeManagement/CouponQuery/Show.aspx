<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponQuery.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%-- <script type="text/javascript" src='<%#GetjQueryPath() %>'></script>
    <script type="text/javascript" src='<%#GetjQueryValidatePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSMultiLanguagePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSFunctionPath()%>'></script>
    <script type="text/javascript" src='<%#GetJSThickBoxPath() %>'></script>
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
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
        <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="持有者信息"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="form3" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="NickName" runat="server" Label="昵称：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="MemberMobilePhone" runat="server" Label="会员手机号码：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="MemberEmail" runat="server" Label="会员邮箱地址：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="详细信息"
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Form ID="form2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        EnableBackgroundColor="true" LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponNumber" runat="server" Label="优惠劵编号：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponUID" runat="server" Label="优惠劵物理编号：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponTypeID" runat="server" Label="优惠劵类型：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="BatchCouponID" runat="server" Label="优惠劵批次编号：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponTypeAmount" runat="server" Label="面额：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                              <ext:FormRow>
                                <Items>
                                    <ext:Label ID="Status" runat="server" Label="状态：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                              <ext:FormRow>
                                <Items>
                                    <ext:Label ID="StockStatus" runat="server" Label="库存状态：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:LinkButton ID="lbViewProduct" runat="server" Label="使用产品：" Text="查看">
                                    </ext:LinkButton>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:LinkButton ID="lbViewDeparment" runat="server" Label="使用部门：" Text="查看">
                                    </ext:LinkButton>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponIssueDate" runat="server" Label="创建日期：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CouponExpiryDate" runat="server" Label="有效日期：">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="优惠劵交易信息："
                AutoHeight="true" AutoWidth="true">
                <Items>
                    <ext:Grid ID="ResultGrid" ShowBorder="false" ShowHeader="false" AutoHeight="true"
                        PageSize="3" runat="server" EnableCheckBoxSelect="false" DataKeyNames="IDNumber"
                        AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                        ForceFitAllTime="true" OnPageIndexChange="ResultGrid_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="序号">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("IDNumber")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="品牌编号">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandCode" runat="server" Text='<%#Eval("BrandCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="品牌">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandName" runat="server" Text='<%#Eval("BrandName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="店铺编号">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreCode" runat="server" Text='<%#Eval("StoreCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="120px" HeaderText="店铺">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreName" runat="server" Text='<%#Eval("StoreName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="服务器编号">
                                <ItemTemplate>
                                    <asp:Label ID="lblServerCode" runat="server" Text='<%#Eval("ServerCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="收银机号">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegisterCode" runat="server" Text='<%#Eval("RegisterCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易类型">
                                <ItemTemplate>
                                    <asp:Label ID="lblOprIDName" runat="server" Text='<%#Eval("OprIDName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易编号">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefTxnNo" runat="server" Text='<%#Eval("RefTxnNo")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="业务日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblBusDate" runat="server" Text='<%#Eval("BusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblTxndate" runat="server" Text='<%#Eval("Txndate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="原始金额">
                                <ItemTemplate>
                                    <asp:Label ID="lblOpenBal" runat="server" Text='<%#Eval("OpenBal","{0:N02}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易金额">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount","{0:N02}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="剩余金额">
                                <ItemTemplate>
                                    <asp:Label ID="lblCloseBal" runat="server" Text='<%#Eval("CloseBal","{0:N02}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="授权号">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprovalCode" runat="server" Text='<%#Eval("ApprovalCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:Window ID="Window1" Title="查看" Popup="false" EnableIFrame="true" runat="server"
                CloseAction="Hide"  IFrameUrl="about:blank"
                EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="750px"
                Height="450px">
            </ext:Window>
        </Items>
    </ext:Panel>
    <%-- <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：<%=this.PageName %></b>
    </div>
    <div style="padding-bottom: 10px;">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                <%=this.PageName %>
            </th>
        </tr>
        <tr>
            <td align="right">
                优惠劵编号：
            </td>
            <td>
                <asp:Label ID="CouponNumber" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                优惠劵物理编号：
            </td>
            <td>
                <asp:Label ID="CouponUID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                优惠劵类型：
            </td>
            <td>
                <asp:Label ID="CouponTypeID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                优惠劵批次编号：
            </td>
            <td>
                <asp:Label ID="BatchCouponID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                面额：
            </td>
            <td>
                <asp:Label ID="CouponTypeAmount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                状态：
            </td>
            <td>
                <asp:Label ID="Status" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                库存状态：
            </td>
            <td>
                <asp:Label ID="StockStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                使用产品：
            </td>
            <td>
                <a class="thickbox btn_bg" href="ShowProduct.aspx?Url=&CouponTypeID=<%=this.couponTypetID%>&view=1&height=500&amp;width=800&amp;TB_iframe=True&amp;keepThis=False">
                    查看</a>
            </td>
        </tr>
        <tr>
            <td width="25%" align="right">
                使用部门：
            </td>
            <td width="75%">
                <a class="thickbox btn_bg" href="ShowDeparment.aspx?Url=&CouponTypeID=<%=this.couponTypetID%>&view=1&height=500&amp;width=800&amp;TB_iframe=True&amp;keepThis=False">
                    查看</a>
            </td>
        </tr>
        <tr>
            <td align="right">
                创建日期：
            </td>
            <td>
                <asp:Label ID="CouponIssueDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                有效日期：
            </td>
            <td>
                <asp:Label ID="CouponExpiryDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th colspan="2" align="left">
                优惠劵交易信息：
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Repeater ID="TXNList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtablelist"
                            id="msgtablelist">
                            <tr>
                                <th width="6%">
                                    序号
                                </th>
                                <th width="6%">
                                    品牌编号
                                </th>
                                <th width="6%">
                                    店铺编号
                                </th>
                                <th width="6%">
                                    服务器编号
                                </th>
                                <th width="6%">
                                    收银机号
                                </th>
                                <th width="15%">
                                    交易类型
                                </th>
                                <th width="10%">
                                    交易编号
                                </th>
                                <th width="10%">
                                    业务日期
                                </th>
                                <th width="10%">
                                    交易日期
                                </th>
                                <th width="6%">
                                    原始金额
                                </th>
                                <th width="6%">
                                    交易金额
                                </th>
                                <th width="6%">
                                    剩余金额
                                </th>
                                <th width="6%">
                                    授权号
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <%#Eval("IDNumber")%>
                            </td>
                            <td align="center">
                                <%#Eval("BrandCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("StoreCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("ServerCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("RegisterCode")%>
                            </td>
                            <td align="center">
                                <%#Eval("OprIDName")%>
                            </td>
                            <td align="center">
                                <%#Eval("RefTxnNo")%>
                            </td>
                            <td align="center">
                                <%#Eval("BusDate","{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="center">
                                <%#Eval("Txndate", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td align="center">
                                <%#Eval("OpenBal", "{0:N02}")%>
                            </td>
                            <td align="center">
                                <%#Eval("Amount", "{0:N02}")%>
                            </td>
                            <td align="center">
                                <%#Eval("CloseBal", "{0:N02}")%>
                            </td>
                            <td align="center">
                                <%#Eval("ApprovalCode")%>
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
            <td colspan="2">
                <div class="right">
                    <webdiyer:AspNetPager ID="TXNListPager" runat="server" CustomInfoTextAlign="Left"
                        FirstPageText="First" HorizontalAlign="Right" InvalidPageIndexErrorMessage="Page index is not a valid value."
                        LastPageText="Last" NextPageText="Next" PageIndexBoxType="TextBox" PageIndexOutOfRangeErrorMessage="Page index out of range!"
                        PrevPageText="Prev" ShowPageIndexBox="Always" SubmitButtonText="Go" SubmitButtonClass="pagerSubmit"
                        TextBeforePageIndexBox="" OnPageChanged="TXNListPager_PageChanged" CssClass="asppager"
                        CurrentPageButtonClass="cpb" CustomInfoClass="asppagercustom" CustomInfoHTML="Current:%CurrentPageIndex%/%PageCount% Total:%RecordCount% "
                        CustomInfoSectionWidth="20%" ShowCustomInfoSection="Left" AlwaysShow="True" LayoutType="Table">
                    </webdiyer:AspNetPager>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <div align="center">
                    <input type="button" name="button1" value="返 回" onclick="javascript:history.go(-<%=PageCount %>)"
                        class="submit" />
                    &nbsp;</div>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; text-align: center;">
    </div>--%>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
