<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLEN.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
    <link href="/res/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="375">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Basic Information">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowHeader="false" ShowBorder="false" runat="server"
                        LabelAlign="Right">
                        <Items>
                            <ext:TextBox ID="ReplenCode" runat="server" Label="Code" MaxLength="20" Required="true"
                                ShowRedStar="true" Enabled="true">
                            </ext:TextBox>
                            <ext:RadioButtonList ID="UseReplenFormula" runat="server" Label="Whether to use the replenishment formula" AutoPostBack="true"
                                OnSelectedIndexChanged="UseReplenFormula_SelectedIndexChanged">
                                <ext:RadioItem Text="Do not use" Value="0" Selected="true" />
                                <ext:RadioItem Text="Use" Value="1" />
                            </ext:RadioButtonList>
                            <ext:DropDownList runat="server" ID="ReplenFormulaID" Label="Formula">
                            </ext:DropDownList>
                            <ext:DropDownList ID="StoreID" runat="server" Label="Store" Required="true" ShowRedStar="true">
                            </ext:DropDownList>
                            <ext:RadioButtonList ID="TargetType" runat="server" Label="Order Target Type" AutoPostBack="true"
                                OnSelectedIndexChanged="TargetType_SelectedIndexChanged">
                                <ext:RadioItem Text="HQ" Value="1" Selected="true" />
                                <ext:RadioItem Text="Supplier" Value="0" />
                            </ext:RadioButtonList>
                            <ext:DropDownList ID="FormStoreID" runat="server" Label="Order Target" Hidden="true">
                            </ext:DropDownList>
                            <ext:DropDownList ID="VendorID" runat="server" Label="Vendor ID" Hidden="true">
                            </ext:DropDownList>
                            <ext:DatePicker ID="StartDate" runat="server" Label="Effective Date From" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DatePicker ID="EndDate" runat="server" Label="Effective Date To" DateFormatString="yyyy-MM-dd">
                            </ext:DatePicker>
                            <ext:DropDownList runat="server" ID="Status" Label="Status">
                                <ext:ListItem Text="Invalid" Value="0" />
                                <ext:ListItem Text="Valid" Value="1" Selected="true" />
                            </ext:DropDownList>
                            <ext:NumberBox runat="server" ID="Priority" Label="Priority">
                            </ext:NumberBox>
                            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
                            </ext:Label>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="Store Replenishment Details">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="EntityType,EntityCode" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar5" runat="server" Position="Top">
                                <Items>
                                    <ext:Button ID="btnDetailAdd" Icon="Add" runat="server" Text="Add Detail" OnClick="btnDetailAdd_Click">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnDeleteDetailItem" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteDetailItem_Click"
                                        Enabled="false">
                                    </ext:Button>
                                    <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                    </ext:ToolbarSeparator>
                                    <ext:Button ID="btnClearAllDetailItem" Icon="Delete" runat="server" Text="Clear" OnClick="btnClearAllDetailItem_Click"
                                        Enabled="false">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Entity Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityTypeName" runat="server" Text='<%#Eval("EntityTypeName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Entity Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntityNum" runat="server" Text='<%#Eval("EntityCode")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Minimum Stock Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblMinStockQty" runat="server" Text='<%#Eval("MinStockQty")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Normal Stock Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblRunningStockQty" runat="server" Text='<%#Eval("RunningStockQty")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Multiple of Order Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblOrderRoundUpQty" runat="server" Text='<%#Eval("OrderRoundUpQty")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="WindowSearch" Hidden="true" EnableIFrame="true" runat="server" CloseAction="Hide"
        OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="550px" Height="400px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
