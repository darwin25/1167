<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.Operation.TransactionQuery.List" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="" AutoScroll="true">
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
                AutoScroll="true">
                <Items>
                    <ext:Form ID="form2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="MemberMobilePhone" runat="server" Label="会员手机号码" MaxLength="512" />
                                </Items>
                                <Items>
                                    <ext:TextBox ID="MemberEmail" runat="server" MaxLength="512" Label="会员邮箱地址">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="CardNumber" runat="server" Label="卡号" MaxLength="20" />
                                </Items>
                                <Items>
                                    <ext:TextBox ID="TransNum" runat="server" Label="Transaction Number">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow >
                                <Items>
                                    <ext:TextBox ID="SalesPickOrderNumber" runat="server" Label="拣货单号">
                                    </ext:TextBox>
                                </Items>
                                <Items>
                                    <ext:TextBox ID="SalesShipOrderNumber" runat="server" Label="Delivery Note Number">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="查询结果">
                <Items>
                    <ext:GroupPanel ID="GroupPanelSales" runat="server" EnableCollapse="True" Title="销售单">
                        <Items>
                            <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                                EnableCheckBoxSelect="false" DataKeyNames="TransNum" AllowPaging="true" IsDatabasePaging="true"
                                ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" AllowSorting="true">
                                <Columns>
                                    <ext:TemplateField Width="150px" HeaderText="Transaction Number" SortField="TransNum">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTxnNo" runat="server" Text='<%# Eval("TransNum") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="90px" HeaderText="Transaction Status">
                                        <ItemTemplate>
                                            <%#Edge.Web.Tools.DALTool.GetStatusName(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Status")))%>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="120px" HeaderText="交易类型">
                                        <ItemTemplate>
                                            <%#Edge.Web.Tools.DALTool.GetTransTypeName(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "TransType")))%>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="100px" HeaderText="交易店铺">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStoreCode" runat="server" Text='<%# Eval("StoreCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="150px" HeaderText="交易日期">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBusDate" runat="server" Text='<%# Eval("BusDate","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="100px" HeaderText="Delivery Note Number">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeliveryNumber" runat="server" Text='<%# Eval("DeliveryNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="100px" HeaderText="送货供应商" SortField="LogisticsProviderID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLogisticsProviderID" runat="server" Text='<%# Eval("ProviderName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="150px" HeaderText="Created Date Time" SortField="CreatedOn">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="80px" HeaderText="Created By" SortField="CreatedBy">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreateBy" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:WindowField ColumnID="ViewWindowField" Width="80px" WindowID="Window1" Icon="Page"
                                        Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="TransNum"
                                        DataIFrameUrlFormatString="../DeliveryOrderManagement/Show.aspx?id={0}" Title="View" />
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:GroupPanel>
                    <ext:GroupPanel ID="GrouPanelSalesPickOrder" runat="server" EnableCollapse="True"
                        Title="销售拣货单">
                        <Items>
                            <ext:Grid ID="Grid2" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                                EnableCheckBoxSelect="false"  DataKeyNames="SalesPickOrderNumber,OrderType,ReferenceNo" AllowPaging="true"
                                IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid2_PageIndexChange"
                                AllowSorting="true" SortField="ReferenceNo" SortDirection="ASC">
                                <Columns>
                                    <ext:TemplateField Width="80px" HeaderText="拣货单号" SortField="SalesPickOrderNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lb_id" runat="server" Text='<%# Eval("SalesPickOrderNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Transaction Status" SortField="ApproveStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveStatus" runat="server" Text='<%# Eval("ApproveStatusName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="80px" HeaderText="交易单号" SortField="ReferenceNo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Order Type" SortField="OrderType">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderType" runat="server" Text='<%# Eval("OrderTypeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="会员卡号">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCardNumber" runat="server" Text='<%# Eval("CardNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Approval Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveCode" runat="server" Text='<%# Eval("ApprovalCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Created Business Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedBusDate" runat="server" Text='<%#Eval("CreatedBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Approve Business Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveBusDate" runat="server" Text='<%#Eval("ApproveBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Created Date Time" SortField="CreatedOn">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Created By">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("CreatedByName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Approve On">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("ApproveOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Approve By">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveBy" runat="server" Text='<%# Eval("ApproveByName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:WindowField ColumnID="ViewWindowField2" Width="60px" WindowID="Window1" Icon="Page"
                                        Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="SalesPickOrderNumber"
                                        DataIFrameUrlFormatString="../StoreOrderManagement/SalesPickOrder/Show.aspx?id={0}" Title="View" />
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:GroupPanel>
                    <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="销售送货单">
                        <Items>
                            <ext:Grid ID="Grid3" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                                EnableCheckBoxSelect="false" EnableMultiSelect="false" DataKeyNames="SalesShipOrderNumber,OrderType,Status,TxnNo,ReferenceNo"
                                AllowPaging="true" IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid3_PageIndexChange"
                                AllowSorting="true" SortField="ReferenceNo" SortDirection="ASC" OnRowDataBound="Grid3_RowDataBound">
                                <Columns>
                                    <ext:TemplateField Width="80px" HeaderText="Delivery Note Number" SortField="SalesShipOrderNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("SalesShipOrderNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Transaction Status" SortField="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="80px" HeaderText="拣货单号" SortField="ReferenceNo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="80px" HeaderText="交易单号" SortField="TxnNo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("TxnNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Order Type" SortField="OrderType">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("OrderTypeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Created Date Time" SortField="CreatedOn">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Created By">
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("CreatedByName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:WindowField ColumnID="ViewWindowField3" Width="60px" WindowID="Window1" Icon="Page"
                                        Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="SalesShipOrderNumber"
                                        DataIFrameUrlFormatString="../StoreOrderManagement/SalesShipOrder/Show.aspx?id={0}" Title="View" />
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:GroupPanel>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="详细" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="550px">
    </ext:Window>
    <ext:Window ID="Window2" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="550px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="false" Width="50px" Height="50px" Left="-1000px" Top="-1000px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
