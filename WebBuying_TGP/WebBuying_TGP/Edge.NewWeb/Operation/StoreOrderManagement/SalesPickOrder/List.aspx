<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.Operation.StoreOrderManagement.SalesPickOrder.List" %>

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
                            <ext:TextBox ID="Code" runat="server" Label="拣货单号" MaxLength="512">
                            </ext:TextBox>
                            <ext:TextBox ID="ReferenceNo" runat="server" Label="交易单号" MaxLength="64">
                            </ext:TextBox>
                            <ext:DropDownList ID="OrderType" runat="server" Label="Order Type">
                                <ext:ListItem Text="-------" Value="" Selected="true" />
                                <ext:ListItem Text="直接产生快递单，拣货单完成" Value="1" />
                                <ext:ListItem Text="需要第三方中转" Value="2" />
                            </ext:DropDownList>
                            <ext:TextBox ID="CardNumber" runat="server" Label="卡号">
                            </ext:TextBox>
                            <ext:Button ID="SearchButton" Text="Search" Icon="Find" runat="server" OnClick="SearchButton_Click"
                                ValidateForms="SearchForm">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:DatePicker ID="CreateStartDate" runat="server" Label="Create Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="CreateEndDate" runat="server" Label="Create Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="ApproveStartDate" runat="server" Label="Approved Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="ApproveEndDate" runat="server" Label="Approved Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:DropDownList runat="server" ID="ApproveStatus" Label="Status">
                                <ext:ListItem Text="-------" Value="" Selected="true" />
                                <ext:ListItem Value="P" Text="PENDING" />
                                <ext:ListItem Value="A" Text="APPROVED" />
                                <ext:ListItem Value="V" Text="VOID" />
                            </ext:DropDownList>
                            <ext:TextBox ID="ProductCode" runat="server" Label="Product Code">
                            </ext:TextBox>
                            <ext:TextBox ID="ProductDesc" runat="server" Label="Product Name">
                            </ext:TextBox>
                            <ext:TextBox ID="OrderQty" runat="server" Label="Order Qty" Readonly="true">
                            </ext:TextBox>
                            <ext:Label ID="Label9" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:TextBox runat="server" ID="MemberEmail" Label="会员邮件">
                            </ext:TextBox>
                            <ext:TextBox runat="server" ID="MemberMobilePhone" Label="会员手机">
                            </ext:TextBox>
                            <ext:Label ID="Label2" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label4" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                            <ext:Label ID="Label5" runat="server" Label="" Hidden="true" HideMode="Offsets">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" Title=""
                BoxFlex="1" Layout="Fit">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                         EnableCheckBoxSelect="True" DataKeyNames="SalesPickOrderNumber,OrderType"
                        AllowPaging="true" IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange"
                        OnRowDataBound="Grid1_RowDataBound" OnPreRowDataBound="Grid1_PreRowDataBound"
                        OnSort="Grid1_Sort" AllowSorting="true" SortField="ReferenceNo" SortDirection="ASC">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnApprove" Text="拣货确认" Icon="Accept" runat="server" OnClick="btnApprove_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnVoid" Text="Void" Icon="Cross" runat="server" OnClick="btnVoid_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnExport" Text="导出/打印" Icon="Printer" runat="server" OnClick="btnExport_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="80px" HeaderText="拣货单号" SortField="SalesPickOrderNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%# Eval("SalesPickOrderNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Transaction Status" SortField="ApproveStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveStatus" runat="server" Text='<%# Eval("ApproveStatusName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="80px" HeaderText="交易单号" SortField="ReferenceNo">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReferenceNo") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Order Type" SortField="OrderType">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderType" runat="server" Text='<%# Eval("OrderTypeName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="会员卡号">
                                <ItemTemplate>
                                    <asp:Label ID="lblCardNumber" runat="server" Text='<%# Eval("CardNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Approval Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveCode" runat="server" Text='<%# Eval("ApprovalCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Created Business Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBusDate" runat="server" Text='<%#Eval("CreatedBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Approve Business Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBusDate" runat="server" Text='<%#Eval("ApproveBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
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
                            <ext:TemplateField Width="60px" HeaderText="Approve On">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("ApproveOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Approve By">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBy" runat="server" Text='<%# Eval("ApproveByName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="SalesPickOrderNumber"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="SalesPickOrderNumber"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" Title="Edit" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="580px">
    </ext:Window>
    <ext:Window ID="Window2" runat="server" Hidden="true" IsModal="True" Title="" EnableMaximize="true"
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
