<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.SalesPickOrder.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:HiddenField runat="server" ID="hidSalesPickOrderNumber">
    </ext:HiddenField>
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="" AutoScroll="true">
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="sform1,sform2" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Transaction Information">
                <Items>
                    <ext:HiddenField ID="ApproveStatus" runat="server" Label="Transaction Status" Text="P">
                    </ext:HiddenField>
                    <ext:HiddenField ID="OrderType" runat="server" Label="Order Type" Text="0">
                    </ext:HiddenField>
                    <ext:Form ID="sform1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="200">
                        <Rows>
                            <ext:FormRow Hidden="true">
                                <Items>
                                    <ext:Label ID="SalesPickOrderNumber" runat="server" Label="订单编号" Width="200">
                                    </ext:Label>
                                    <ext:Label ID="lblOrderType" runat="server" Label="Order Type" Width="100">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="ReferenceNo" runat="server" Label="订单号">
                                    </ext:Label>
                                    <ext:Label ID="lblApproveStatus" runat="server" Label="订单状态">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CardNumber" runat="server" Label="会员卡号码">
                                    </ext:Label>
                                    <ext:Label ID="MemberName" runat="server" Label="会员姓名">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="MemberEmail" runat="server" Label="会员邮件地址">
                                    </ext:Label>
                                    <ext:Label ID="MemberMobilePhone" runat="server" Label="会员手机号码">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="ddlPickupLocation" runat="server" Label="拣货仓库编号" ShowRedStar="true"
                                        Required="true" AutoPostBack="true" OnSelectedIndexChanged="ddlPickupLocation_SelectedIndexChanged">
                                    </ext:DropDownList>
                                    <ext:Label ID="StoreName" runat="server" Label="拣货仓库名称">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="PickupStaff" runat="server" Label="拣货人">
                                    </ext:TextBox>
                                    <ext:Label ID="PickupDate" runat="server" Label="拣货时间">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                                    </ext:Label>
                                    <ext:Label ID="CreatedBusDate" runat="server" Label="Created Business Date">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="ApproveOn" runat="server" Label="Approve On">
                                    </ext:Label>
                                    <ext:Label ID="lblApproveBy" runat="server" Label="Approve By">
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
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="Delivery Information">
                <Items>
                    <ext:Form ID="sform3" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="200">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label runat="server" ID="DeliveryNumber" Label="Delivery Note Number" Width="200">
                                    </ext:Label>
                                    <ext:Label runat="server" ID="LogisticsProviderID" Label="Logistics Provider ID" Width="100">
                                    </ext:Label>
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
                                    <ext:Label runat="server" ID="DeliveryCountry" Label="送货所在国家">
                                    </ext:Label>
                                    <ext:Label ID="DeliveryProvince" runat="server" Label="送货所在省">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label runat="server" ID="DeliveryCity" Label="送货所在城市">
                                    </ext:Label>
                                    <ext:Label ID="DeliveryDistrict" runat="server" Label="送货地址所在区县">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="DeliveryFullAddress" runat="server" Label="送货完整地址">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="DeliveryAddressDetail" runat="server" Label="送货详细地址">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="收货信息">
                <Items>
                    <ext:Form ID="sform4" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="200">
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
                                    <ext:Label runat="server" ID="RequestDeliveryDate" Label="要求送货日期">
                                    </ext:Label>
                                    <ext:Label runat="server" ID="DeliveryDate" Label="货物送达日期  ">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="Pick up order details">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="ID,ProdCode,StockTypeCode,OrderQTY,KeyID,OnhandQty,ActualQTY"
                        AllowPaging="true" IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange"
                        EnableSummary="true" AllowCellEditing="true" ClicksToEdit="1" SummaryPosition="Bottom"
                        EnableTextSelection="true">
                         <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server" Position="Top" CssStyle="width: 100%;">
                                <Items>
                                    <ext:Button ID="btnAllOK" Icon="Accept"  runat="server"
                                        Text="All OK" OnClick="btnAllOK_OnClick">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
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
                            <ext:TemplateField Width="100px" HeaderText="Code" SortField="StockTypeCode">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["StockTypeCode"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="On hand Qty" SortField="SalesPickOrderNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblOnhandQty" runat="server" Text='<%#((System.Data.DataRow)Container.DataItem)["OnhandQty"]%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="60px" DataField="OrderQTY" HeaderText="Order Quantity" ColumnID="onOrderQty">
                            </ext:BoundField>
                            <%--    <ext:BoundField Width="60px" DataField="ActualQTY" HeaderText="Actual Qty" ColumnID="onActualQty">
                            </ext:BoundField>--%>
                            <ext:RenderField Width="60px" DataField="ActualQTY" FieldType="Int" HeaderText="Actual Qty"
                                SortField="ActualQTY" ColumnID="onActualQty">
                                <Editor>
                                    <ext:NumberBox runat="server" ID="nmbQTY">
                                    </ext:NumberBox>
                                </Editor>
                            </ext:RenderField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <ext:Window ID="Window1" Title="Export Report" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true"
        EnableResize="true" Target="Top" IsModal="True" Width="300px" Height="200px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
