<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListByBauhuas.aspx.cs"
    Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.ListByBauhuas" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>List</title>
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
                            <ext:TextBox ID="txtProdCode" runat="server" Label="Product Code">
                            </ext:TextBox>
                            <%-- <ext:TextBox ID="txtBrandCode" runat="server" Label="Brand Code">
                            </ext:TextBox>--%>
                            <ext:DropDownList runat="server" ID="BrandCode" Label="Brand">
                            </ext:DropDownList>
                            <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click"
                                ValidateForms="SearchForm">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:DropDownList ID="SEASON" runat="server" Label="Season">
                            </ext:DropDownList>
                            <ext:DropDownList ID="DepartCode" runat="server" Label="Department Code">
                            </ext:DropDownList>
                            <ext:Label ID="Label2" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:DropDownList ID="Year" runat="server" Label="Year">
                            </ext:DropDownList>
                            <ext:DropDownList ID="SEX" runat="server" Label="Gender">
                                <ext:ListItem Text="----------" Value="" />
                                <ext:ListItem Text="Male" Value="1" />
                                <ext:ListItem Text="Female" Value="2" />
                            </ext:DropDownList>
                            <ext:Label ID="Label3" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:DropDownList ID="ColorCode" runat="server" Label="Color">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ProductSizeCode" runat="server" Label="Size">
                            </ext:DropDownList>
                            <ext:Label ID="Label4" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:TextBox ID="txtStoreCode" runat="server" Label="Store Code" MaxLength="512">
                            </ext:TextBox>
                            <ext:TextBox ID="txtDesc" runat="server" Label="Description">
                            </ext:TextBox>
                            <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
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
                        OnSort="Grid1_Sort" AllowSorting="true" OnRowDoubleClick="Grid1_OnRowDoubleClick">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnAddPicker" Text="Add" Icon="Add" OnClick="btnAddPicker_Click" runat="server"
                                        Hidden="true">
                                    </ext:Button>
                                    <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server">
                                    </ext:Button>
                                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
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
                            <ext:TemplateField Width="150px" HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdDesc1" runat="server" Text='<%# Eval("ProdDesc1") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Brand Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblBrandCode" runat="server" Text='<%# Eval("BrandName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Store Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreCode" runat="server" Text='<%# Eval("StoreName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Start Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="End Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("EndDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="ProdCode"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" DataWindowTitleFormatString="View"
                                Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="ProdCode"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" DataWindowTitleFormatString="Edit"
                                Title="Edit" />
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
    <ext:Window ID="Window2" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="900px"
        Height="550px" EnableClose="true">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px"
        Top="-1000px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <ext:HiddenField ID="SortField" Text="" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
