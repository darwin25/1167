<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.StockAdjust.Show" %>

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
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="StockAdjustNumber" runat="server" Label="Transaction Number" Width="200">
                                    </ext:Label>
                                    <ext:Label ID="ReferenceNo" runat="server" Label="Reference No." Width="100">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="lblApproveStatus" runat="server" Label="Transaction Status">
                                    </ext:Label>
                                    <ext:Label ID="ApprovalCode" runat="server" Label="Approval Code">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="CreatedBusDate" runat="server" Label="Created Business Date">
                                    </ext:Label>
                                    <ext:Label ID="ApproveBusDate" runat="server" Label="Approve Business Date">
                                    </ext:Label>
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
                                    <ext:Label ID="ReasonID" runat="server" Label="Reason ID">
                                    </ext:Label>
                                    <ext:Label ID="StockTypeCode" runat="server" Label="Stock Type Code">
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
                                    <ext:Label ID="Store" runat="server" Label="Store">
                                    </ext:Label>
                                    <ext:Label ID="Remark" runat="server" Label="Remarks">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Delivery Note Details">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="ID" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" EnableSummary="true"
                        SummaryPosition="Bottom">
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
                            <ext:BoundField Width="60px" DataField="AdjustQty" HeaderText="Adjust Qty" ColumnID="onAdjustQty">
                            </ext:BoundField>
                            <ext:TemplateField Width="100px" HeaderText="Remarks" SortField="Remark" Hidden="true">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["Remark"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
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
