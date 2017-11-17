<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.CouponReturnManagement.CouponReturnOrder.List" %>

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
        EnableBackgroundColor="true" Title="" AutoScroll="true" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <ext:Form ID="SearchForm" ShowBorder="True" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server" LabelSeparator="0" LabelAlign="Right" LabelWidth="110">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:TextBox ID="Code" runat="server" Label="交易编号：" MaxLength="512">
                            </ext:TextBox>
                            <ext:DropDownList ID="Status" runat="server" Label="交易状态：" Resizable="true">
                                <ext:ListItem Text="-------" Value=""  Selected="true"/>
                                <ext:ListItem Text="PENDING" Value="P" />
                                <ext:ListItem Text="APPROVED" Value="A" />
                                <ext:ListItem Text="VOID" Value="V" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="FromStoreID" runat="server" Label="库存(出)地点：" Resizable="true"></ext:DropDownList>
                            <ext:DropDownList ID="StoreID" runat="server" Label="库存(入)地点：" Resizable="true"></ext:DropDownList>
                            <ext:Button ID="SearchButton" Text="搜索" Icon="Find" runat="server" OnClick="SearchButton_Click" ValidateForms="SearchForm">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="23% 23% 23% 23% 8%">
                        <Items>
                            <ext:DatePicker ID="CreateStartDate" runat="server" Label="创建日期从：" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="CreateEndDate" runat="server" Label="创建日期到：" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="ApproveStartDate" runat="server" Label="批核日期从：" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="ApproveEndDate" runat="server" Label="批核日期到：" DateFormatString="yyyy-MM-dd"> 
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Offsets"></ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" EnableBackgroundColor="true"
                Title="" BoxFlex="1" Layout="Fit">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" AutoHeight="true" PageSize="3"
                        runat="server" EnableCheckBoxSelect="True" DataKeyNames="CouponReturnNumber"
                        AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
                        ForceFitAllTime="true" OnPageIndexChange="Grid1_PageIndexChange" OnRowDataBound="Grid1_RowDataBound"
                        OnPreRowDataBound="Grid1_PreRowDataBound" OnSort="Grid1_Sort" AllowSorting="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnNew" Text="添加" Icon="Add" EnablePostBack="false" runat="server">
                                    </ext:Button>
                                    <ext:Button ID="btnApprove" Text="批核" Icon="Accept" runat="server" OnClick="btnApprove_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnVoid" Text="作废" Icon="Cross" runat="server" OnClick="btnVoid_Click">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="交易编号" SortField="CouponReturnNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lb_id" runat="server" Text='<%# Eval("CouponReturnNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易状态">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveStatus" runat="server" Text='<%# Eval("ApproveStatusName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="授权号">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveCode" runat="server" Text='<%# Eval("ApprovalCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="库存(出)地点">
                                <ItemTemplate>
                                    <asp:Label ID="lblFromStoreID" runat="server" Text='<%# Eval("FullFromStoreID") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="库存(入)地点">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreID" runat="server" Text='<%# Eval("FullStoreID") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易创建工作日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBusDate" runat="server" Text='<%#Eval("CreatedBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易批核工作日期">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBusDate" runat="server" Text='<%#Eval("ApproveBusDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="交易创建时间" SortField="CreatedOn">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateOn" runat="server" Text='<%#Eval("CreatedOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="创建人">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateBy" runat="server" Text='<%# Eval("CreatedByName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="批核时间">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("ApproveOn","{0:yyyy-MM-dd HH:mm:ss}")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="批核人">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproveBy" runat="server" Text='<%# Eval("ApproveByName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="查看" ToolTip="查看" DataTextFormatString="{0}" DataIFrameUrlFields="CouponReturnNumber"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" Title="查看" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                                Text="修改" ToolTip="修改" DataTextFormatString="{0}" DataIFrameUrlFields="CouponReturnNumber"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" Title="修改" />
                        </Columns>
                    </ext:Grid>
                    </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="Window1" Title="" Popup="false" EnableIFrame="true"
        runat="server" CloseAction="Hide" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="900px"
        Height="580px">
    </ext:Window>
    <ext:Window ID="Window2" runat="server" Popup="false" IsModal="True" Title="" EnableMaximize="true"
        EnableResize="true" Target="Top" EnableIFrame="true" IFrameUrl="about:blank"
        Width="900px" CloseAction="HidePostBack" OnClose="WindowEdit_Close" EnableClose="true" Height="580px">
    </ext:Window>
    <ext:Window ID="HiddenWindowForm" Title="" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="50px" Height="50px" Left="-1000px" Top="-1000px">
    </ext:Window> 
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server"></ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>


