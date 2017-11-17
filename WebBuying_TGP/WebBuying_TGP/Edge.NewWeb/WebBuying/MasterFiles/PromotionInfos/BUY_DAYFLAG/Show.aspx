<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_DAYFLAG.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="DayFlagCode" runat="server" Label="Code">
                            </ext:Label>
                            <ext:Label ID="Note" runat="server" Label="Remarks">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day1Flag" runat="server" Label="第一天">
                            </ext:Label>
                            <ext:Label ID="Day2Flag" runat="server" Label="第二天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day3Flag" runat="server" Label="第三天">
                            </ext:Label>
                            <ext:Label ID="Day4Flag" runat="server" Label="第四天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day5Flag" runat="server" Label="第五天">
                            </ext:Label>
                            <ext:Label ID="Day6Flag" runat="server" Label="第六天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day7Flag" runat="server" Label="第七天">
                            </ext:Label>
                            <ext:Label ID="Day8Flag" runat="server" Label="第八天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day9Flag" runat="server" Label="第九天">
                            </ext:Label>
                            <ext:Label ID="Day10Flag" runat="server" Label="第十天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day11Flag" runat="server" Label="第十一天">
                            </ext:Label>
                            <ext:Label ID="Day12Flag" runat="server" Label="第十二天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day13Flag" runat="server" Label="第十三天">
                            </ext:Label>
                            <ext:Label ID="Day14Flag" runat="server" Label="第十四天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day15Flag" runat="server" Label="第十五天">
                            </ext:Label>
                            <ext:Label ID="Day16Flag" runat="server" Label="第十六天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day17Flag" runat="server" Label="第十七天">
                            </ext:Label>
                            <ext:Label ID="Day18Flag" runat="server" Label="第十八天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day19Flag" runat="server" Label="第十九天">
                            </ext:Label>
                            <ext:Label ID="Day20Flag" runat="server" Label="第二十天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day21Flag" runat="server" Label="第二十一天">
                            </ext:Label>
                            <ext:Label ID="Day22Flag" runat="server" Label="第二十二天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day23Flag" runat="server" Label="第二十三天">
                            </ext:Label>
                            <ext:Label ID="Day24Flag" runat="server" Label="第二十四天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day25Flag" runat="server" Label="第二十五天">
                            </ext:Label>
                            <ext:Label ID="Day26Flag" runat="server" Label="第二十六天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow15" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day27Flag" runat="server" Label="第二十七天">
                            </ext:Label>
                            <ext:Label ID="Day28Flag" runat="server" Label="第二十八天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow16" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day29Flag" runat="server" Label="第二十九天">
                            </ext:Label>
                            <ext:Label ID="Day30Flag" runat="server" Label="第三十天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow17" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Day31Flag" runat="server" Label="第三十一天">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
