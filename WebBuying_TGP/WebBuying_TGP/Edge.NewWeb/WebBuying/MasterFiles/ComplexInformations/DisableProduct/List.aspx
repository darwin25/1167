<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.DisableProduct.List" %>

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
        <items>
            <ext:Form ID="SearchForm" ShowBorder="True" BodyPadding="5px" ShowHeader="False"
                runat="server" LabelAlign="Right">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:TextBox ID="Code" runat="server" Label="Product Code">
                            </ext:TextBox>
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
                        EnableCheckBoxSelect="True" DataKeyNames="ProdCode" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange"
                        OnSort="Grid1_Sort" AllowSorting="true" SortField="ProdCode" SortDirection="ASC">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnImport" Text="导入" Icon="PageGo" EnablePostBack="false"  runat="server">
                                    </ext:Button>
                                      <ext:Button ID="btnApprove" Text="Approve" Icon="Accept" runat="server" OnClick="btnApprove_Click">
                                     </ext:Button>
                                      <ext:Button ID="btnUpdate" Text="同步" Icon="Accept" runat="server" OnClick="btnUpdate_Click">
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
                            <ext:TemplateField Width="60px" HeaderText="Product Name" SortField="ProdCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdName" runat="server" Text='<%# Eval("ProdName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="80px" HeaderText="是否在onlineshipping上使用">
                                <ItemTemplate>
                                    <asp:Label ID="IsOnlineSKU" runat="server" Text='<%# Eval("IsOnlineSKUName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="实际销售价格">
                                <ItemTemplate>
                                    <asp:Label ID="lbl实际销售价格" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                              <ext:TemplateField Width="60px" HeaderText="Reference price">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefPrice" runat="server" Text='<%# Eval("RefPrice") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="推荐标志">
                                <ItemTemplate>
                                    <asp:Label ID="lblFeature" runat="server" Text='<%# Eval("Feature") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                             <ext:TemplateField Width="60px" HeaderText="热卖标志">
                                <ItemTemplate>
                                    <asp:Label ID="lblHotSale" runat="server" Text='<%# Eval("HotSale") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                              <ext:TemplateField Width="60px" HeaderText="Status" SortField="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Created Date Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                           <%-- <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="ProdCode"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" DataWindowTitleFormatString="View"
                                Title="View" />--%>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="View" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="550px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="审核" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px"
        Top="-1000px">
        </ext:Window>
    <ext:Window ID="Window4" Title="导入" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" OnClose="WindowEdit_Close" EnableMaximize="true"
        EnableResize="true" Target="Top" IsModal="True" Width="700px" Height="180px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <ext:HiddenField ID="SortField" Text="" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
