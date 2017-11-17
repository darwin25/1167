<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.BUY_PROMO_D.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="SimpleForm1" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
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
            <ext:GroupPanel ID="GroupPanel4" runat="server" EnableCollapse="True" Title="Fundamental Details">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowHeader="false" ShowBorder="false" runat="server"
                        LabelAlign="Right">
                        <Items>
                            <ext:TextBox ID="PromotionCode" runat="server" Label="促销编号" Required="true" ShowRedStar="true"
                                Enabled="false" />
                            <ext:DropDownList ID="EntityType" runat="server" Label="Entity Type" OnSelectedIndexChanged="EntityType_SelectedIndexChanged"
                                AutoPostBack="true">
                                <ext:ListItem Text="--------" Value="0" />
                                <ext:ListItem Text="Prodcode" Value="1" />
                                <ext:ListItem Text="DepartCode" Value="2" />
                                <ext:ListItem Text="TenderCode" Value="3" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="HitOP" runat="server" Label="操作符">
                                <ext:ListItem Text="--------" Value="0" />
                                <ext:ListItem Text="=" Value="1" />
                                <ext:ListItem Text="<>" Value="2" />
                                <ext:ListItem Text="&lt=" Value="3" />
                                <ext:ListItem Text="&gt=" Value="4" />
                                <ext:ListItem Text="<" Value="5" />
                                <ext:ListItem Text=">" Value="6" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="HitType" runat="server" Label="命中类型">
                                <ext:ListItem Text="无条件命中" Value="0" Selected="true" />
                                <ext:ListItem Text="数量" Value="1" />
                                <ext:ListItem Text="金额" Value="2" />
                            </ext:DropDownList>
                            <ext:NumberBox ID="HitAmount" runat="server" Label="命中金额/数量" NoDecimal="false" DecimalPrecision="2" />
                            <ext:DropDownList ID="DiscType" runat="server" Label="Discount Type">
                                <ext:ListItem Text="折扣减去的金额" Value="1" />
                                <ext:ListItem Text="折扣销售的金额" Value="2" />
                                <ext:ListItem Text="折扣减去的百分比" Value="3" />
                                <ext:ListItem Text="折扣销售的百分比" Value="4" />
                            </ext:DropDownList>
                            <ext:NumberBox ID="DiscPrice" runat="server" Label="折扣数值" NoDecimal="false" DecimalPrecision="2" />
                            <ext:Form ID="SearchForm" ShowBorder="false" BodyPadding="0px" ShowHeader="False"
                                runat="server" LabelAlign="Right">
                                <Rows>
                                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="65% 5% 30%">
                                        <Items>
                                            <ext:TextBox ID="EntityNum" runat="server" Label="Entity Code" Enabled="false">
                                            </ext:TextBox>
                                            <ext:Button ID="btnSelect" runat="server" Text="...">
                                            </ext:Button>
                                            <ext:Label ID="Label3" runat="server" Hidden="true" HideMode="Display">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="List">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="10" runat="server"
                        EnableCheckBoxSelect="False" DataKeyNames="EntityNum" AllowPaging="true" IsDatabasePaging="true"
                         ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Entity Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("EntityTypeName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Entity Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("EntityNum")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="操作符">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("HitOPName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中类型">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("HitTypeName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="命中金额/数量">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("HitAmount")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="折扣数值">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("DiscPrice")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Discount Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("DiscTypeName")%>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="Window2" Hidden="true" EnableIFrame="true" runat="server" CloseAction="Hide"
        OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
