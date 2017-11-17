<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.Operation.DeliveryOrderManagement.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="" AutoScroll="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="sform1,sform2" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="订单信息">
                <Items>
                    <ext:Form ID="sform1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="180">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="TxnNo" runat="server" Label="Transaction Number" Width="200">
                                    </ext:Label>
                                    <ext:Label ID="lblTxnType" runat="server" Label="Order Type" Width="100">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Label="">
                                    </ext:Label>
                                    <ext:Label ID="lblStatus" runat="server" Label="Transaction Status">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="BusDate" runat="server" Label="交易日期">
                                    </ext:Label>
                                    <ext:DropDownList ID="Status" runat="server" Label="Transaction Status">
                                        <ext:ListItem Text="-------" Value="-1" Selected="true" />
                                        <ext:ListItem Value="5" Text="交易完成" />
                                        <ext:ListItem Value="6" Text="交付运送" />
                                        <ext:ListItem Value="8" Text="拒收" />
                                        <ext:ListItem Value="9" Text="已延迟" />
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                                    </ext:Label>
                                    <ext:Label ID="lblCreatedBy" runat="server" Label="Created By">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="StoreCode" runat="server" Label="Store Code">
                                    </ext:Label>
                                    <ext:Label ID="StoreName" runat="server" Label="Store Name">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblPickupType" runat="server" Label="退货方式">
                                    </ext:Label>
                                    <ext:Label ID="PickupStoreCode" runat="server" Label="快递送货到达的店铺编号">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="PaySettleDate" runat="server" Label="退还支付最后完成日期">
                                    </ext:Label>
                                    <ext:Label ID="CompleteDate" runat="server" Label="交易单最终完成日期">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="Remark" runat="server" Label="Remarks">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Delivery Information">
                <Items>
                    <ext:Form ID="sform3" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="180">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="LogisticsProviderID" runat="server" Label="Logistics Provider ID" Width="200">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="DeliveryNumber" runat="server" Label="Delivery Note Number" Width="100">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label runat="server" ID="lblDeliveryFlag" Label="送货标志">
                                    </ext:Label>
                                    <ext:Label ID="DeliverBy" runat="server" Label="送货员">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="DeliveryFullAddress" runat="server" Label="送货完整地址">
                                    </ext:Label>
                                    <ext:Label ID="DeliveryAddressDetail" runat="server" Label="送货详细地址">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="收货信息">
                <Items>
                    <ext:Form ID="sform4" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="180">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label runat="server" ID="Contact" Label="收货人" Width="200">
                                    </ext:Label>
                                    <ext:Label runat="server" ID="ContactPhone" Label="Contact Phone" Width="100">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label runat="server" ID="SettlementDate" Label="收到货的日期">
                                    </ext:Label>
                                    <ext:Label runat="server" ID="SettlementStaffID" Label="提货最后确认人">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="Order Details">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="SeqNo" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true"  OnPageIndexChange="Grid1_PageIndexChange" EnableSummary="true" SummaryPosition="Bottom">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Product Code" SortField="ProdCode">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["ProdCode"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="Product Name" SortField="ProdDesc">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["ProdDesc"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                             <ext:BoundField Width="60px" DataField="QTY" HeaderText="Order Quantity" ColumnID="onQty" ></ext:BoundField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
