<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.Operation.StockTake.List" %>

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
            <ext:Form ID="SearchForm" ShowBorder="True" BodyPadding="5px" 
                ShowHeader="False" runat="server"  LabelAlign="Right" LabelWidth="110">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:TextBox ID="Code" runat="server" Label="Inventory Number" MaxLength="512">
                            </ext:TextBox>
                            <ext:DropDownList ID="Status" runat="server" Label="Transaction Status" >
                                <ext:ListItem Text="-------" Value="" Selected="true" />
                                <ext:ListItem Text="Registered" Value="1" />
                                <ext:ListItem Text="First Inventory" Value="2" />
                                <ext:ListItem Text="Second Inventory" Value="3" />
                                <ext:ListItem Text="Generate Difference Table" Value="3" />
                                <ext:ListItem Text="End of Inventory" Value="3" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="StockTakeType" runat="server" Label="Count Type" >
                                <ext:ListItem Text="-------" Value="" Selected="true" />
                                <ext:ListItem Text="Plate Number" Value="0" />
                                <ext:ListItem Text="Disk Serial Number" Value="1" />
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
                            <ext:DropDownList ID="StoreID" runat="server" Label="Store" >
                            </ext:DropDownList>
                            <ext:DatePicker ID="CreateStartDate" runat="server" Label="Create Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="CreateEndDate" runat="server" Label="Create Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label3" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:DatePicker ID="StockTakeStartDate" runat="server" Label="Count Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="StockTakeEndDate" runat="server" Label="Count Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:Label ID="Label5" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label6" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label2" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" 
                Title="" BoxFlex="1" Layout="Fit">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false"  PageSize="3"
                        runat="server" EnableCheckBoxSelect="True" DataKeyNames="StockTakeNumber,StockTakeType"
                        AllowPaging="true" IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound"
                        OnPreRowDataBound="Grid1_PreRowDataBound" OnSort="Grid1_Sort" AllowSorting="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server">
                                    </ext:Button>
                                    <ext:Button ID="btnApprove" Text="End Inventory" Icon="Accept" runat="server" OnClick="btnApprove_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnVoid" Text="Void" Icon="Cross" runat="server" OnClick="btnVoid_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnExportStockTake01" Text="Export Count 1" Icon="ApplicationGo" runat="server"
                                        OnClick="btnExportStockTake01_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnExportStockTake02" Text="Export Count 2" Icon="ApplicationGo" runat="server"
                                        OnClick="btnExportStockTake02_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnExporrStockTakeVAR" Text="Export Differences" Icon="ApplicationGo" runat="server"
                                        OnClick="btnExporrStockTakeVAR_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnPrint" Text="Print Count 1" Icon="Printer" runat="server" OnClick="btnPrint_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnPrint02" Text="Print Count 2" Icon="Printer" runat="server" OnClick="btnPrint02_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnTakeVAR" Text="Print Differences" Icon="Printer" runat="server" OnClick="btnTakeVAR_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Inventory Number" SortField="StockTakeNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%# Eval("StockTakeNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Inventory Status" SortField="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockTakeStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Count Type" SortField="StockTakeType">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("StockTakeTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Store" SortField="StoreID">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreID" runat="server" Text='<%# Eval("StoreName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Count Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockTakeDate" runat="server" Text='<%#Eval("StockTakeDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Created Date Time" SortField="CreatedOn">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Created By">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateBy" runat="server" Text='<%# Eval("CreatedByName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                           <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="Count 1" ToolTip="Count 1" DataTextFormatString="{0}" DataIFrameUrlFields="StockTakeNumber"
                                DataIFrameUrlFormatString="StockTake01.aspx?id={0}" Title="Count 1" />
                            <ext:WindowField ColumnID="ViewWindow2" Width="60px" WindowID="Window1" Icon="Page"
                                Text="Count 2" ToolTip="Count 2" Title="Count 2" DataTextFormatString="{0}" DataIFrameUrlFormatString="StockTake02.aspx?id={0}"
                                DataIFrameUrlFields="StockTakeNumber" />
                            <ext:WindowField ColumnID="ViewWindow3" Width="60px" WindowID="Window1" Icon="Page"
                                Text="Difference" ToolTip="Difference" Title="Difference" DataTextFormatString="{0}" DataIFrameUrlFormatString="StockTakeVAR.aspx?id={0}"
                                DataIFrameUrlFields="StockTakeNumber" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="Modal Form" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="580px">
    </ext:Window>
    <ext:Window ID="Window2" runat="server" Hidden="true" IsModal="True" Title="Modal Form" EnableMaximize="true"
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
