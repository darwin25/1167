<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_BLACKLIST.List" %>
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
            <ext:Form ID="SearchForm" ShowBorder="True" BodyPadding="5px" 
                ShowHeader="False" runat="server" LabelAlign="Right">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:TextBox ID="Code" runat="server" Label="账号代码" MaxLength="512">
                            </ext:TextBox>
                            <ext:TextBox ID="Desc" runat="server" Label="客户名称" MaxLength="512">
                            </ext:TextBox>
                            <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" 
                Title="" BoxFlex="1" Layout="Fit">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false"  PageSize="3"
                        runat="server" EnableCheckBoxSelect="True" DataKeyNames="BlackID"
                        AllowPaging="true" IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" AllowSorting="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server">
                                    </ext:Button>
                                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="账号代码" SortField="AccountCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccountCode" runat="server" Text='<%# Eval("AccountCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="客户名称">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerName" runat="server" Text='<%# Eval("CustomerName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="客户编码">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerCode" runat="server" Text='<%# Eval("CustomerCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerContact" runat="server" Text='<%# Eval("CustomerContact") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="联系人1">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerContact1" runat="server" Text='<%# Eval("CustomerContact1") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="信用卡号">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreditCardNo" runat="server" Text='<%# Eval("CreditCardNo") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                             <ext:TemplateField Width="60px" HeaderText="昵称">
                                <ItemTemplate>
                                    <asp:Label ID="lblNickName" runat="server" Text='<%# Eval("NickName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                             <ext:TemplateField Width="60px" HeaderText="手机号码">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("MobileNo") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                           <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="BlackID"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" DataWindowTitleFormatString="View"
                                Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="BlackID"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" DataWindowTitleFormatString="Edit"
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
    <ext:Window ID="Window2" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="450px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false"
        EnableResize="true" Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px"
        Top="-1000px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server"></ext:HiddenField>
    <ext:HiddenField ID="SortField" Text="" runat="server"></ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
