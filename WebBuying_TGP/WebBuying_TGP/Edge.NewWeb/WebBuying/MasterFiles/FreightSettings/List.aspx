<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.FreightSettings.List" %>

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
                            <ext:DropDownList ID="LogisticsProviderID" runat="server" Label="物流供应商">
                            </ext:DropDownList>
                            <ext:TextBox runat="server" ID="ProvinceCode" Label="省">
                            </ext:TextBox>
                            <ext:Label ID="Label4" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
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
                        EnableCheckBoxSelect="True" DataKeyNames="KeyID" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort"
                        AllowSorting="true">
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
                            <ext:TemplateField Width="60px" HeaderText="物流供应商" SortField="LogisticsProviderID">
                                <ItemTemplate>
                                    <asp:Label ID="lblLogisticsProviderID" runat="server" Text='<%# Eval("LogisticsProviderName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="省名称" SortField="ProvinceCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblProvinceCode" runat="server" Text='<%# Eval("LogisticsProvinceName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="起步价">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartPrice" runat="server" Text='<%#string.Format("{0:F}",Eval("StartPrice")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="起步重量">
                                <ItemTemplate>
                                    <asp:Label ID="lblStartWeight" runat="server" Text='<%#string.Format("{0:F}",Eval("StartWeight")) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="每公斤溢出价格">
                                <ItemTemplate>
                                    <asp:Label ID="lblOverflowPricePerKG" runat="server" Text='<%#string.Format("{0:F}",Eval("OverflowPricePerKG"))%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="KeyID"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="KeyID"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" Title="Edit" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="600px" Height="400px">
    </ext:Window>
    <ext:Window ID="Window2" runat="server" Hidden="true" IsModal="True" Title="" EnableMaximize="true"
        EnableResize="true" Target="Top" EnableIFrame="true" IFrameUrl="about:blank"
        Width="600px" CloseAction="HidePostBack" OnClose="WindowEdit_Close" EnableClose="true"
        Height="400px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="50px"
        Height="50px" Left="-1000px" Top="-1000px">
    </ext:Window>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server">
    </ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
