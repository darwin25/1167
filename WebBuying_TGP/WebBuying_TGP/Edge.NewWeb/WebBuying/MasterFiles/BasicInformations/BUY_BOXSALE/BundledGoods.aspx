<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BundledGoods.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BOXSALE.BundledGoods" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BundledGood</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="SimpleForm1" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
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
                    <ext:SimpleForm ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server"
                        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                        <Items>
                            <ext:TextBox ID="BOMCode" runat="server" Label="主货品编码" Required="true" ShowRedStar="true"
                                Enabled="false">
                            </ext:TextBox>
                            <ext:Form ID="SearchForm" BodyPadding="1px" ShowHeader="False" runat="server" LabelAlign="Right"
                                ShowBorder="false">
                                <Rows>
                                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="70% 20% 10%">
                                        <Items>
                                            <ext:TextBox ID="ProdCode" runat="server" Label="子货品编码" Width="350px" Readonly="true"
                                                Required="true" ShowRedStar="true">
                                            </ext:TextBox>
                                            <ext:Button ID="btnSelect" runat="server" Text="...">
                                            </ext:Button>
                                            <ext:Label ID="lbl123" runat="server" Hidden="true" HideMode="Display">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                            <ext:NumberBox ID="MinQty" runat="server" Label="子货品最小数量" Required="true" ShowRedStar="true"
                                MinValue="0" Text="0" />
                            <ext:NumberBox ID="MaxQty" runat="server" Label="子货品最大数量" Required="true" ShowRedStar="true"
                                MinValue="0" Text="0" CompareOperator="GreaterThanEqual" CompareControl="MinQty"
                                CompareMessage="最大数量应大于最小数量" />
                            <ext:NumberBox ID="DefaultQty" runat="server" Label="子货品默认数量" Required="true" ShowRedStar="true"
                                MinValue="0" Text="0" ></ext:NumberBox>
                            <ext:NumberBox ID="Price" runat="server" Label="附加价格" Required="true" ShowRedStar="true"
                                MinValue="0" Text="0.00" NoDecimal="false" DecimalPrecision="2" />
                            <ext:RadioButtonList ID="ValueType" runat="server" Label="货品价格分摊类型">
                                <ext:RadioItem Text="金额" Value="0" Selected="true" />
                                <ext:RadioItem Text="百分比" Value="1" />
                            </ext:RadioButtonList>
                            <ext:NumberBox ID="PartValue" runat="server" Label="货品价格分摊值" Required="true" ShowRedStar="true"
                                MinValue="0" Text="0.00" NoDecimal="false" DecimalPrecision="2" />
                            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
                            </ext:Label>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="货品">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="True" DataKeyNames="BOMID" AllowPaging="true" IsDatabasePaging="true"
                        ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" 
                        AllowSorting="true" AutoScroll="true">
                        <Toolbars>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <%-- <ext:Button ID="btnNew" Text="Add" Icon="Add" EnablePostBack="false" runat="server">
                                    </ext:Button>--%>
                                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>
                        <Columns>
                            <ext:TemplateField Width="120px" HeaderText="主货品编码">
                                <ItemTemplate>
                                    <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("BOMCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="120px" HeaderText="子货品编码">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Eval("ProdCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="80px" HeaderText="子货品数量">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="子货品最小数量">
                                <ItemTemplate>
                                    <asp:Label ID="lblMinQty" runat="server" Text='<%# Eval("MinQty") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="子货品最大数量">
                                <ItemTemplate>
                                    <asp:Label ID="lblMaxQty" runat="server" Text='<%# Eval("MaxQty") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="子货品默认数量">
                                <ItemTemplate>
                                    <asp:Label ID="lblDefaultQty" runat="server" Text='<%# Eval("DefaultQty") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField ColumnID="ViewWindowField" Width="60px" WindowID="Window1" Icon="Page"
                                Text="View" ToolTip="View" DataTextFormatString="{0}" DataIFrameUrlFields="BOMID"
                                DataIFrameUrlFormatString="Show.aspx?id={0}" DataWindowTitleFormatString="View"
                                Title="View" />
                            <ext:WindowField ColumnID="EditWindowField" Width="60px" WindowID="Window2" Icon="PageEdit"
                                Text="Edit" ToolTip="Edit" DataTextFormatString="{0}" DataIFrameUrlFields="BOMID"
                                DataIFrameUrlFormatString="Modify.aspx?id={0}" DataWindowTitleFormatString="Edit"
                                Title="Edit" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="Window1" Title="View" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="350px" AutoScroll="true">
    </ext:Window>
    <ext:Window ID="Window2" Title="Edit" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank"
        EnableMaximize="false" EnableResize="true" Target="Top" IsModal="True" Width="900px"
        Height="450px">
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
