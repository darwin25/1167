<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.IMP_Product.List" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                            <ext:DropDownList ID="SEASON" runat="server" Label="季节">
                            </ext:DropDownList>
                            <ext:DropDownList ID="DepartCode" runat="server" Label="Department Code">
                            </ext:DropDownList>
                            <ext:Label ID="Label2" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:DatePicker ID="Year" runat="server" Label="年份" DateFormatString="yyyy">
                            </ext:DatePicker>
                            <ext:DropDownList ID="SEX" runat="server" Label="性别">
                                <ext:ListItem Text="----------" Value="" />
                                <ext:ListItem Text="男" Value="1" />
                                <ext:ListItem Text="女" Value="2" />
                            </ext:DropDownList>
                            <ext:Label ID="Label3" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="46% 46% 8%">
                        <Items>
                            <ext:DropDownList ID="ColorCode" runat="server" Label="颜色">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ProductSizeCode" runat="server" Label="尺寸">
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
                        EnableCheckBoxSelect="True" DataKeyNames="INTERNAL_PRODUCT_CODE" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange"
                        OnSort="Grid1_Sort" AllowSorting="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" Icon="PageExcel"
                                        EnableAjax="false" DisableControlBeforePostBack="false">
                                    </ext:Button>
                                    <ext:Button ID="btnImport" Text="导入" Icon="PageGo" EnablePostBack="false"  runat="server">
                                    </ext:Button>
                                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Product Code" SortField="INTERNAL_PRODUCT_CODE">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Eval("INTERNAL_PRODUCT_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="商品名称">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="End Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("RETIRE_DATE","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="最后更新时间">
                                <ItemTemplate>
                                    <asp:Label ID="lblEndDate" runat="server" Text='<%# Eval("LAST_UPDATE_DATE","{0:yyyy-MM-dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="INTERNAL_PRODUCT_CODE"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" DataWindowTitleFormatString="View"
                                Title="View" />
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
    <ext:Window ID="Window4" Title="导入" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" OnClose="WindowEdit_Close" EnableMaximize="true"
        EnableResize="true" Target="Top" IsModal="True" Width="700px" Height="180px">
    </ext:Window>
    <ext:Window ID="Window5" Title="导入" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" OnClose="WindowEdit_Close" EnableMaximize="true"
        EnableResize="true" Target="Top" IsModal="True" Width="580px" Height="350px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <ext:HiddenField ID="SortField" Text="" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
