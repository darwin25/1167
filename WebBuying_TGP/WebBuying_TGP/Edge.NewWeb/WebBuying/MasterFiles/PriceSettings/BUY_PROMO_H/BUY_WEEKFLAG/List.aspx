<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_PROMO_H.BUY_WEEKFLAG.List" %>
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
        <Toolbars>
            <ext:Toolbar>
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server" 
                Title="" BoxFlex="1" AutoScroll="true">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false"  PageSize="3"
                        runat="server" EnableCheckBoxSelect="False" DataKeyNames="WeekFlagCode" EnableRowDoubleClickEvent="true" 
                        AllowPaging="true" IsDatabasePaging="true"  ForceFit="true" OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" AllowSorting="true" 
                        OnRowDoubleClick="Grid1_OnRowDoubleClick">
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Code" SortField="WeekFlagCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblMonthFlagCode" runat="server" Text='<%# Eval("WeekFlagCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="星期日">
                                <ItemTemplate>
                                    <asp:Label ID="lblDay1Flag" runat="server" Text='<%# Eval("SundayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="星期一">
                                <ItemTemplate>
                                    <asp:Label ID="lblDay2Flag" runat="server" Text='<%# Eval("MondayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="星期二">
                                <ItemTemplate>
                                    <asp:Label ID="lblDay3Flag" runat="server" Text='<%# Eval("TuesdayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="星期三">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("WednesdayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="星期四">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("ThursdayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="星期五">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("FridayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="星期六">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("SaturdayFlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                        </Columns>
                    </ext:Grid>
                    </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:HiddenField ID="SearchFlag" Text="0" runat="server"></ext:HiddenField>
    <ext:HiddenField ID="SortField" Text="" runat="server"></ext:HiddenField>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
