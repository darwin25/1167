<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MNM_H.BUY_DAYFLAG.List" %>
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
                    <ext:Grid ID="Grid1" Width="2500px" ShowBorder="false" ShowHeader="false"  PageSize="5"
                        runat="server" EnableCheckBoxSelect="False" DataKeyNames="DayFlagCode" EnableRowDoubleClickEvent="true"
                        AllowPaging="true" IsDatabasePaging="true"  ForceFit="true"
                        OnPageIndexChange="Grid1_PageIndexChange" OnSort="Grid1_Sort" AllowSorting="true"
                        OnRowDoubleClick="Grid1_OnRowDoubleClick">
                        <Columns>
                            <ext:TemplateField Width="75px" HeaderText="Code" SortField="DayFlagCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblDayFlagCode" runat="server" Text='<%# Eval("DayFlagCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblNote" runat="server" Text='<%# Eval("Note") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第一天">
                                <ItemTemplate>
                                    <asp:Label ID="lblDay1Flag" runat="server" Text='<%# Eval("Day1FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二天">
                                <ItemTemplate>
                                    <asp:Label ID="lblDay2Flag" runat="server" Text='<%# Eval("Day2FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第三天">
                                <ItemTemplate>
                                    <asp:Label ID="lblDay3Flag" runat="server" Text='<%# Eval("Day3FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第四天">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Day4FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第五天">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Day5FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第六天">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Day6FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第七天">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Day7FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第八天">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("Day8FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第九天">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Day9FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十天">
                                <ItemTemplate>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Day10FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十一天">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Day11FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十二天">
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Day12FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十三天">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Day13FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十四天">
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Day14FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十五天">
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("Day15FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十六天">
                                <ItemTemplate>
                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("Day16FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十七天">
                                <ItemTemplate>
                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("Day17FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十八天">
                                <ItemTemplate>
                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("Day18FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第十九天">
                                <ItemTemplate>
                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("Day19FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十天">
                                <ItemTemplate>
                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("Day20FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十一天">
                                <ItemTemplate>
                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("Day21FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十二天">
                                <ItemTemplate>
                                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("Day22FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十三天">
                                <ItemTemplate>
                                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("Day23FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十四天">
                                <ItemTemplate>
                                    <asp:Label ID="Label24" runat="server" Text='<%# Eval("Day24FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十五天">
                                <ItemTemplate>
                                    <asp:Label ID="Label25" runat="server" Text='<%# Eval("Day25FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十六天">
                                <ItemTemplate>
                                    <asp:Label ID="Label26" runat="server" Text='<%# Eval("Day26FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十七天">
                                <ItemTemplate>
                                    <asp:Label ID="Label27" runat="server" Text='<%# Eval("Day27FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十八天">
                                <ItemTemplate>
                                    <asp:Label ID="Label28" runat="server" Text='<%# Eval("Day28FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第二十九天">
                                <ItemTemplate>
                                    <asp:Label ID="Label29" runat="server" Text='<%# Eval("Day29FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第三十天">
                                <ItemTemplate>
                                    <asp:Label ID="Label30" runat="server" Text='<%# Eval("Day30FlagName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="75px" HeaderText="第三十一天" >
                                <ItemTemplate>
                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("Day31FlagName") %>'></asp:Label>
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
