<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.ReceiveStoreOrder.List" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Index</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="3px"
        Title="" AutoScroll="true" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <ext:Form ID="SearchForm" ShowBorder="True" BodyPadding="5px" ShowHeader="False"
                runat="server" LabelAlign="Right" LabelWidth="110">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:TextBox ID="Code" runat="server" Label="Transaction Number" MaxLength="512">
                            </ext:TextBox>
                            <ext:DropDownList ID="Status" runat="server" Label="Transaction Status">
                                <ext:ListItem Text="-------" Value="" Selected="true" />
                                <ext:ListItem Text="PENDING" Value="P" />
                                <ext:ListItem Text="APPROVED" Value="A" />
                                <ext:ListItem Text="VOID" Value="V" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="OrderType" runat="server" Label="Order Type">
                                <ext:ListItem Text="-------" Value="" Selected="true" />
                                <ext:ListItem Text="Manual" Value="0" />
                                <ext:ListItem Text="Automatic" Value="1" />
                            </ext:DropDownList>
                            <ext:Label ID="Label4" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click"
                                ValidateForms="SearchForm">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:DropDownList ID="FromStoreID" runat="server" Label="Inventory (out) location">
                            </ext:DropDownList>
                            <ext:DropDownList ID="StoreID" runat="server" Label="Inventory (into) location">
                            </ext:DropDownList>
                            <ext:DatePicker ID="CreateStartDate" runat="server" Label="Create Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="CreateEndDate" runat="server" Label="Create Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:DatePicker ID="ApproveStartDate" runat="server" Label="Approved Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="ApproveEndDate" runat="server" Label="Approved Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:Label ID="Label5" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label6" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label2" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:TextBox ID="ProductCode" runat="server" Label="Product Code">
                            </ext:TextBox>
                            <ext:TextBox ID="ProductDesc" runat="server" Label="Product Name">
                            </ext:TextBox>
                            <ext:Label ID="Label7" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label8" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label9" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" Title=""
                BoxFlex="1" Layout="Fit">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="ReceiveOrderNumber,OrderType" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange"
                        OnRowDataBound="Grid1_RowDataBound" OnPreRowDataBound="Grid1_PreRowDataBound"
                        OnSort="Grid1_Sort" AllowSorting="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server">
                                    </ext:Button>
                                    <ext:Button ID="btnApprove" Text="Approve" Icon="Accept" runat="server" OnClick="btnApprove_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnVoid" Text="Void" Icon="Cross" runat="server" OnClick="btnVoid_Click">
                                    </ext:Button>
                                   <%-- <ext:Button ID="btnExport" Text="Export" Icon="ApplicationGo" runat="server" OnClick="btnExport_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnPrint" Text="Print" Icon="Printer" runat="server" OnClick="btnPrint_Click">
                                    </ext:Button>--%>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="100px" HeaderText="Transaction Number" SortField="ReceiveOrderNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%# Eval("ReceiveOrderNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Transaction Status" SortField="ApproveStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveStatus" runat="server" Text='<%# Eval("ApproveStatusName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="Reference No." SortField="ReferenceNo">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Order Type" SortField="OrderType">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderType" runat="server" Text='<%# Eval("OrderTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Approval Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveCode" runat="server" Text='<%# Eval("ApprovalCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Inventory (out) location" SortField="FromStoreID">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplierID" runat="server" Text='<%# Eval("FromStoreName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Inventory (into) location" SortField="StoreID">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreID" runat="server" Text='<%# Eval("StoreName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Created Business Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBusDate" runat="server" Text='<%#Eval("CreatedBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Approve Business Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBusDate" runat="server" Text='<%#Eval("ApproveBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Created Date Time" SortField="CreatedOn">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Created By">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateBy" runat="server" Text='<%# Eval("CreatedByName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Approve On">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("ApproveOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="40px" HeaderText="Approve By">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBy" runat="server" Text='<%# Eval("ApproveByName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="ReceiveOrderNumber"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="ReceiveOrderNumber"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" Title="Edit" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="580px">
    </ext:Window>
    <ext:Window ID="Window2" runat="server" Hidden="true" IsModal="True" Title="" EnableMaximize="true"
        EnableResize="true" Target="Top" EnableIFrame="true" IFrameUrl="about:blank"
        Width="900px" CloseAction="HidePostBack" OnClose="WindowEdit_Close" EnableClose="true"
        Height="580px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
