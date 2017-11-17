<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductParticulars.List" %>
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
            <ext:Form ID="SearchForm" ShowBorder="True" BodyPadding="5px" 
                ShowHeader="False" runat="server" LabelAlign="Right">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="30% 5% 65%">
                        <Items>
                            <ext:TextBox ID="txtSelect" runat="server" Label="Select Product" Width="135px" Readonly="true"></ext:TextBox>
                            <ext:Button ID="btnSelect" runat="server" Text="..."></ext:Button>
                            <ext:Label ID="Label1" runat="server" Hidden="true" HideMode="Display"></ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" 
                Title="" BoxFlex="1" Layout="Fit">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false"  PageSize="3"
                        runat="server" EnableCheckBoxSelect="True" DataKeyNames="ProdCode,LanguageID"
                        AllowPaging="true" IsDatabasePaging="true" ForceFit="true"  OnPageIndexChange="Grid1_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server" Enabled="false">
                                    </ext:Button>
                                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Language">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Eval("LanguageID") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="产品功能描述">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssociatedProdCode" runat="server" Text='<%# Eval("ProdFunction") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="产品成分描述">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("ProdIngredients") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="销售包装描述">
                                <ItemTemplate>
                                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("PackDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="销售包装单位">
                                <ItemTemplate>
                                    <asp:Label ID="Label33" runat="server" Text='<%# Eval("PackUnit") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="ProdCode,LanguageID"
                                DataIFrameUrlFormatString="Show.aspx?ProdCode={0}&lanid={1}" DataWindowTitleFormatString="View"
                                Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window3" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="ProdCode,LanguageID"
                                DataIFrameUrlFormatString="Modify.aspx?ProdCode={0}&lanid={1}" DataWindowTitleFormatString="Edit"
                                Title="Edit" />
                        </Columns>
                    </ext:Grid>
                    </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="View" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide"  IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="750px"
        Height="450px">
    </ext:Window>
    <ext:Window ID="Window2" Title="Search" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="450px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px"
        Top="-1000px">
    </ext:Window>
    <ext:Window ID="Window3" Title="Add" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="450px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server"></ext:HiddenField>
    <ext:HiddenField ID="SortField" Text="" runat="server"></ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
