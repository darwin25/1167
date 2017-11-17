<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.Operation.StockTake.Add" %>

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
                    <ext:HiddenField ID="OrderType" runat="server" Label="Order Type" Text="0">
                    </ext:HiddenField>
                    <ext:Form ID="sform1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                        LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="StockTakeType" runat="server" Label="Count Type">
                                        <ext:ListItem Text="Plate Number" Value="0" Selected="true" />
                                        <ext:ListItem Text="Disk Serial Number" Value="1" />
                                    </ext:DropDownList>
                                    <ext:DatePicker ID="StockTakeDate" runat="server" Label="Count Date" Width="140">
                                    </ext:DatePicker>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="Remark" runat="server" Label="Remarks">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:DropDownList ID="StoreID" runat="server" Label="Store / Warehouse" OnSelectedIndexChanged="StoreID_SelectedIndexChanged"
                                        AutoPostBack="True" Required="true" ShowRedStar="true">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="StoreAddress" runat="server" Label="Address" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="StoreContactName" runat="server" Label="Contact" Enabled="false">
                                    </ext:TextBox>
                                    <ext:TextBox ID="StorePhone" runat="server" Label="Contact Phone" Enabled="false">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
            <%--            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="Search Details"
                 >
                <Items>
                    <ext:Form ID="sform3" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                         LabelAlign="Right" LabelWidth="140">
                        <Rows>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="ProductCode" runat="server" Label="Product Code" >
                                    </ext:TextBox>
                                    <ext:TextBox ID="ProductDesc" runat="server" Label="Product Name" >
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextBox ID="DepartmentCode" runat="server" Label="Department Code" >
                                    </ext:TextBox>
                                    <ext:TextBox ID="DepartmentDesc" runat="server" Label="Department Name " >
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:NumberBox ID="OrderQty" runat="server" Label="Order Qty" MaxValue="1000000" 
                                        NoDecimal="true" NoNegative="true" Required="true" ShowRedStar="true">
                                    </ext:NumberBox>
                                    <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click" ValidateForms="SearchForm">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false"  PageSize="3"
                        runat="server" EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true"
                        EnableRowNumber="True"  ForceFitAllTime="true"
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
                                    <%#((System.Data.DataRow)Container.DataItem)["DepartCode"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="120px" HeaderText="Department Name ">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["DepartName"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Product Code">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["ProdCode"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="120px" HeaderText="Product Name">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["ProdDesc"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="Order Details"
                 >
                <Items>
                    <ext:Grid ID="Grid2" ShowBorder="false" ShowHeader="false"  PageSize="3"
                        runat="server" EnableCheckBoxSelect="false" DataKeyNames="ProdCode" AllowPaging="true"
                        IsDatabasePaging="true" EnableRowNumber="True"  ForceFitAllTime="true"
                        OnPageIndexChange="Grid2_PageIndexChange" OnRowCommand="Grid2_RowCommand">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server" Position="Top" CssStyle="width: 100%;">
                                <Items>
                                    <ext:Button ID="btnDeleteAll" Icon="Delete" EnablePostBack="true" runat="server" Text="Delete All"
                                        OnClick="btnDeleteAll_OnClick">
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
                            <ext:TemplateField Width="60px" HeaderText="Order Quantity" SortField="QTY">
                                <ItemTemplate>
                                    <%#((System.Data.DataRow)Container.DataItem)["QTY"]%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:LinkButtonField HeaderText="&nbsp;" Width="60px" CommandName="Delete" Text="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>--%>
        </Items>
    </ext:Panel>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
