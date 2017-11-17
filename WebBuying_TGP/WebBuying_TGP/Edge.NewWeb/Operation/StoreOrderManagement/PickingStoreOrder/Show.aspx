<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.PickingStoreOrder.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Show</title>
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
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </ext:ToolbarSeparator>
                    <%--      <ext:Button ID="btnExport" Icon="PageExcel" EnablePostBack="false" runat="server"
                        Text="Export Report">
                    </ext:Button>--%>
                    <%--<ext:Button ID="Button1" runat="server" Text="Export to GC Delivery Transaction"
                        OnClick="btnExport_Click" Icon="PageExcel" EnableAjax="false" DisableControlBeforePostBack="false">
                    </ext:Button>--%>
                    <%--<ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnPrintPR" runat="server" Text="Export to Supplier PR" Icon="Printer" OnClick="btnPrintPR_Click">
                    </ext:Button>--%>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Trading Information">
                <Items>  
                    <ext:HiddenField ID="ApproveStatus" runat="server" Label="Trading Status" Text="P">
                    </ext:HiddenField>
                    <ext:HiddenField ID="OrderType" runat="server" Label="Order Type" Text="0">
                    </ext:HiddenField>
                    <ext:Form ID="sform1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="200">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="PickingOrderNumber" runat="server" Label="Transaction Number" Width="200">
                                    </ext:Label>
                                    <ext:Label ID="lblOrderType" runat="server" Label="Order Type" Width="100">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblApproveStatus" runat="server" Label="Trading Status">
                                    </ext:Label>
                                    <ext:Label ID="ApprovalCode" runat="server" Label="Approval Code">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedBusDate" runat="server" Label="Transaction Creation Date">
                                    </ext:Label>
                                    <ext:Label ID="ApproveBusDate" runat="server" Label="Transaction Approval Date">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedOn" runat="server" Label="Transaction Created On">
                                    </ext:Label>
                                    <ext:Label ID="lblCreatedBy" runat="server" Label="Created By">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="ApproveOn" runat="server" Label="Approved On">
                                    </ext:Label>
                                    <ext:Label ID="lblApproveBy" runat="server" Label="Approved By">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="Remark" runat="server" Label="Remark">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="Inventory (out) Location Information">
                <Items>
                    <ext:Form ID="sForm4" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="200">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="FromStoreID" runat="server" Label="Warehouse">
                                    </ext:Label>
                                    <ext:Label ID="FromAddress" runat="server" Label="Address">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="FromContactName" runat="server" Label="Contact">
                                    </ext:Label>
                                    <ext:Label ID="FromContactPhone" runat="server" Label="Contact Number">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="Inventory (in) Location Information">
                <Items>
                    <ext:Form ID="sform2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="200">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="StoreID" runat="server" Label="Store">
                                    </ext:Label>
                                    <ext:Label ID="StoreAddress" runat="server" Label="Address">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="StoreContactName" runat="server" Label="Contact">
                                    </ext:Label>
                                    <ext:Label ID="StoreContactPhone" runat="server" Label="Contact Number">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Pick up order details">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="ID" AllowPaging="true" IsDatabasePaging="true"
                       ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" EnableSummary="true" SummaryPosition="Bottom">
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
                            <ext:BoundField Width="60px" DataField="OrderQTY"  HeaderText="Order Qty"  ColumnID="onOrderQty" ></ext:BoundField>
                            <ext:BoundField Width="60px" DataField="ActualQTY" HeaderText="Actual Qty"  ColumnID="onActualQty" ></ext:BoundField>
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
