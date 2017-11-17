<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.Enquiry.StockQuery.List" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/res/css/common.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .f-grid-row-summary .f-grid-cell-inner
        {
            font-weight: bold;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="3px"
        Title="" AutoScroll="true" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <ext:Form ID="SearchForm" ShowBorder="True" BodyPadding="5px" ShowHeader="False"
                runat="server" LabelAlign="Right">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:TextBox ID="ProductCode" runat="server" Label="Product Code">
                            </ext:TextBox>
                            <ext:TextBox ID="ProductDesc" runat="server" Label="Product Name">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:TextBox ID="DepartmentCode" runat="server" Label="Department Code">
                            </ext:TextBox>
                            <ext:TextBox ID="DepartmentDesc" runat="server" Label="Department Name ">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="46% 20% 34%">
                        <Items>
                            <ext:DropDownList ID="StoreID" runat="server" Label="Warehouse / Store">
                            </ext:DropDownList>
                             <ext:RadioButtonList ID="rblOnhand" runat="server" Label="In Stock" >
                                <ext:RadioItem Value="1" Text="Yes" Selected="true" />
                                 <ext:RadioItem Value="-1" Text="No" />
                            </ext:RadioButtonList>
                            <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click"
                                ValidateForms="SearchForm">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" Title=""
                BoxFlex="1" Layout="Fit">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="ProdCode,ProdDesc1" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange"
                        OnSort="Grid1_Sort" AllowSorting="true" OnRowDoubleClick="Grid1_OnRowDoubleClick"
                        EnableSummary="false" SummaryPosition="Bottom">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnExport" Text="Export" Icon="ApplicationGo" runat="server" OnClick="btnExport_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnPrint" Text="Print" Icon="Printer" runat="server" OnClick="btnPrint_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Product Code" SortField="ProdCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Eval("ProdCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="150px" HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdDesc1" runat="server" Text='<%# Eval("ProdDesc1") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Department Code" SortField="DepartCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartCode" runat="server" Text='<%# Eval("DepartCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="150px" HeaderText="Department Name " SortField="DepartCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblDepartName" runat="server" Text='<%# Eval("DepartName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Brand" SortField="BrandCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandCode" runat="server" Text='<%# Eval("BrandName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="150px" HeaderText="Store Name" SortField="StoreID">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreName" runat="server" Text='<%# Eval("StoreName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Stock Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockType" runat="server" Text='<%# Eval("StockTypeCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="60px" DataField="OnhandQty" HeaderText="On hand Qty" ColumnID="onhandQty">
                            </ext:BoundField>
                            <ext:BoundField Width="60px" DataField="Price" HeaderText="Price" ColumnID="money" DataFormatString="{0:F2}">
                            </ext:BoundField>
                            <ext:TemplateField HeaderText="Total Price" Width="120px">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotolPrice" runat="server" Text='<%# "$" + GetXiaoji(Eval("Price").ToString(), Eval("OnhandQty").ToString()) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" DataIFrameUrlFormatString="Show.aspx?id={0}" DataWindowTitleFormatString="View"
                                Title="View" Hidden="true" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="View" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="550px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px"
        Top="-1000px">
    </ext:Window>
    <ext:Window ID="Window2" runat="server" Hidden="true" IsModal="True" Title="" EnableMaximize="true"
        EnableResize="true" Target="Top" EnableIFrame="true" IFrameUrl="about:blank"
        Width="900px" CloseAction="HidePostBack" OnClose="WindowEdit_Close" EnableClose="true"
        Height="550px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <ext:HiddenField ID="SortField" Text="" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
