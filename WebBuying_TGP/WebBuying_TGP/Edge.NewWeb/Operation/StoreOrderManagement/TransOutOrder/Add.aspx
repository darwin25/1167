<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.TransOutOrder.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add</title>
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
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Transaction Information">
                <Items>
                    <ext:HiddenField ID="ApproveStatus" runat="server" Label="Transaction Status" Text="P">
                    </ext:HiddenField>
                    <ext:Form ID="sform1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:Label ID="TransOutOrderNumber" runat="server" Label="Transaction Number">
                                    </ext:Label>
                                    <ext:Label ID="lblOrderType" runat="server" Label="Order Type">
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
                                    <ext:DropDownList ID="ReasonID" runat="server" Label="Reason" AutoPostBack="True" Required="false"
                                        ShowRedStar="false">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="Remark" runat="server" Label="Remarks">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="Inventory (out) Location Information">
                <Items>
                    <ext:Form ID="sForm4" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="FromStoreID" runat="server" Label="Store" OnSelectedIndexChanged="FromStoreID_SelectedIndexChanged"
                                        AutoPostBack="True" Required="true" ShowRedStar="true">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="FromAddress" runat="server" Label="Address">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="FromContactName" runat="server" Label="Contact">
                                    </ext:TextBox>
                                    <ext:TextBox ID="FromContactPhone" runat="server" Label="Contact Phone">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel5" runat="server" EnableCollapse="True" Title="Inventory (in) Location Information">
                <Items>
                    <ext:Form ID="sform2" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="StoreID" runat="server" Label="Store" OnSelectedIndexChanged="StoreID_SelectedIndexChanged"
                                        AutoPostBack="True" Required="true" ShowRedStar="true">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="StoreAddress" runat="server" Label="Address">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="StoreContactName" runat="server" Label="Contact">
                                    </ext:TextBox>
                                    <ext:TextBox ID="StoreContactPhone" runat="server" Label="Contact Phone">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Search Details">
                <Items>
                    <ext:Form ID="sform3" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="ProductCode" runat="server" Label="Product Code">
                                    </ext:TextBox>
                                    <ext:TextBox ID="ProductDesc" runat="server" Label="Product Name">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="DepartmentCode" runat="server" Label="Department Code">
                                    </ext:TextBox>
                                    <ext:TextBox ID="DepartmentDesc" runat="server" Label="Department Name ">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="TransOutQty" runat="server" Label="Trans Out Qty" MaxValue="1000000" NoDecimal="true"
                                        NoNegative="true" Required="true" ShowRedStar="true">
                                    </ext:NumberBox>
                                    <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click"
                                        ValidateForms="SearchForm">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true" ForceFit="true"
                        OnPageIndexChange="Grid1_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar4" runat="server">
                                <Items>
                                    <ext:Button ID="btnSelectAll" Text="Select All" Icon="Accept" runat="server" OnClick="btnSelectAll_OnClick">
                                    </ext:Button>
                                    <ext:Button ID="btnAdd" Text="Add" Icon="Add" runat="server" OnClick="btnAddDetail_OnClick">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Department Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeptCode" runat="server" Text='<%# Eval("DepartCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="120px" HeaderText="Department Name ">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("DepartName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Product Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProdCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="120px" HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ProdDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="Delivery Note Details">
                <Items>
                    <ext:Grid ID="Grid2" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="ProdCode" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid2_PageIndexChange" OnRowCommand="Grid2_RowCommand">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server" Position="Top" CssStyle="width: 100%;">
                                <Items>
                                    <ext:Button ID="btnDeleteAll" Icon="Delete" EnablePostBack="true" runat="server"
                                        Text="Delete All" OnClick="btnDeleteAll_OnClick">
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
                            <ext:TemplateField Width="60px" HeaderText="Trans Out Qty" SortField="TransOutQty">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["TransOutQty"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="Remarks" SortField="Remark" Hidden="true">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["Remark"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:LinkButtonField HeaderText="&nbsp;" Width="60px" CommandName="Delete" Text="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
