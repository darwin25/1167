<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.Promotion.Promotion_Hit.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
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
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Fundamental Details">
                <Items>
                    <ext:SimpleForm ID="SimpleForm2" ShowHeader="false" ShowBorder="false" runat="server"
                        LabelAlign="Right">
                        <Items>
                            <ext:TextBox ID="PromotionCode" runat="server" Label="促销编号" Required="true" ShowRedStar="true"
                                Enabled="false" />
                            <ext:NumberBox ID="HitSeq" runat="server" Label="命中条件序号" Required="true" ShowRedStar="true"
                                Enabled="false" />
                            <ext:RadioButtonList ID="HitLogicalOpr" runat="server" Label="命中条件之间的逻辑关系" Width="200">
                                <ext:RadioItem Text="和" Value="0" Selected="true" />
                                <ext:RadioItem Text="或" Value="1" />
                            </ext:RadioButtonList>
                            <ext:DropDownList ID="HitType" runat="server" Label="命中类型">
                                <ext:ListItem Text="无条件命中" Value="0" Selected="true" />
                                <ext:ListItem Text="数量" Value="1" />
                                <ext:ListItem Text="金额" Value="2" />
                            </ext:DropDownList>
                            <ext:NumberBox ID="HitValue" runat="server" Label="命中金额/数量" />
                            <ext:DropDownList ID="HitOP" runat="server" Label="命中关系操作符">
                                <ext:ListItem Text="--------" Value="0" />
                                <ext:ListItem Text="=" Value="1" />
                                <ext:ListItem Text="<>" Value="2" />
                                <ext:ListItem Text="&lt=" Value="3" />
                                <ext:ListItem Text="&gt=" Value="4" />
                                <ext:ListItem Text="<" Value="5" />
                                <ext:ListItem Text=">" Value="6" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="HitItem" runat="server" Label="命中货品条件">
                                <ext:ListItem Text="没有具体的货品条件，全场货品都参与" Value="0" />
                                <ext:ListItem Text="任意货品合计" Value="1" />
                                <ext:ListItem Text="任意一个单独货品满足数量或者金额" Value="2" />
                                <ext:ListItem Text="每一个货品都需要满足数量或者金额" Value="3" />
                                <ext:ListItem Text="支付类型条件" Value="4" />
                            </ext:DropDownList>
                            <ext:HiddenField ID="OprFlag" runat="server" Text="Update">
                            </ext:HiddenField>
                        </Items>
                    </ext:SimpleForm>
                </Items>
            </ext:GroupPanel>
            <ext:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="促销命中表的指定货品列表">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
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
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
