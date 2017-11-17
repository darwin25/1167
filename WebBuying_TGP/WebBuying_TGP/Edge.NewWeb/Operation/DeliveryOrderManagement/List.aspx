<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.Operation.DeliveryOrderManagement.List" %>

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
                            <ext:TextBox ID="Code" runat="server" Label="Transaction Number">
                            </ext:TextBox>
                            <ext:DropDownList ID="Status" runat="server" Label="Transaction Status">
                                <ext:ListItem Text="-------" Value="-1" Selected="true" />
                                <ext:ListItem Text="已付款未提货" Value="4" />
                                <ext:ListItem Text="交易完成" Value="5" />
                                <ext:ListItem Text="交付运送" Value="6" />
                                <ext:ListItem Text="拒收" Value="8" />
                                <ext:ListItem Text="已延迟" Value="9" />
                            </ext:DropDownList>
                            <ext:Label ID="Label5" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click"
                                ValidateForms="SearchForm">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="20% 20% 20% 20% 20%">
                        <Items>
                            <ext:DatePicker ID="StartBusDate" runat="server" Label="交易日期从" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="EndBusDate" runat="server" Label="交易日期到" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="CreateStartDate" runat="server" Label="Create Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="CreateEndDate" runat="server" Label="Create Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" Title=""
                BoxFlex="1" Layout="Fit" AutoScroll="true">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="TransNum" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort"
                        AllowSorting="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnExport" Text="导出/打印" Icon="Printer" runat="server" OnClick="btnExport_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnPrint" Text="测试" Icon="Accept" runat="server" OnClick="btnTest_Click" Hidden="true">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="150px" HeaderText="Transaction Number" SortField="TransNum">
                                <ItemTemplate>
                                    <asp:Label ID="lblTxnNo" runat="server" Text='<%# Eval("TransNum") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="90px" HeaderText="Transaction Status">
                                <ItemTemplate>
                                    <%#Edge.Web.Tools.DALTool.GetStatusName(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Status")))%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="120px" HeaderText="交易类型">
                                <ItemTemplate>
                                    <%#Edge.Web.Tools.DALTool.GetTransTypeName(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "TransType")))%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="交易店铺">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreCode" runat="server" Text='<%# Eval("StoreCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="150px" HeaderText="交易日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblBusDate" runat="server" Text='<%# Eval("BusDate","{0:yyyy-MM-dd HH:mm:ss}") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <%-- <ext:TemplateField Width="150px" HeaderText="卡号">
                                <ItemTemplate>
                                    <asp:Label ID="lblCardNumber" runat="server" Text='<%# Eval("CardNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="交易金额" TextAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#string.Format("{0:F2}", Convert.ToDouble(Eval("TotalAmount"))) %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>--%>
                            <ext:TemplateField Width="100px" HeaderText="Delivery Note Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeliveryNumber" runat="server" Text='<%# Eval("DeliveryNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="送货供应商" SortField="LogisticsProviderID">
                                <ItemTemplate>
                                    <asp:Label ID="lblLogisticsProviderID" runat="server" Text='<%# Eval("ProviderName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="150px" HeaderText="Created Date Time" SortField="CreatedOn">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="80px" HeaderText="Created By" SortField="CreatedBy">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateBy" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="80px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="TransNum"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="80px" WindowID="Window2" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="TransNum"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" Title="Edit" />
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
