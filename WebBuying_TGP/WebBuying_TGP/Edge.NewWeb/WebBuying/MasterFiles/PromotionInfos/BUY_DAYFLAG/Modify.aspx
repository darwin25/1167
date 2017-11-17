<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_DAYFLAG.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify</title>
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
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:TextBox ID="DayFlagCode" runat="server" Label="日设置编码" Required="true" ShowRedStar="true"
                Enabled="false" />
            <ext:TextBox ID="Note" runat="server" Label="Remarks" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:RadioButtonList ID="Day1Flag" runat="server" Label="第一天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day2Flag" runat="server" Label="第二天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day3Flag" runat="server" Label="第三天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day4Flag" runat="server" Label="第四天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day5Flag" runat="server" Label="第五天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day6Flag" runat="server" Label="第六天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day7Flag" runat="server" Label="第七天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day8Flag" runat="server" Label="第八天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day9Flag" runat="server" Label="第九天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day10Flag" runat="server" Label="第十天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day11Flag" runat="server" Label="第十一天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day12Flag" runat="server" Label="第十二天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day13Flag" runat="server" Label="第十三天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day14Flag" runat="server" Label="第十四天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day15Flag" runat="server" Label="第十五天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day16Flag" runat="server" Label="第十六天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day17Flag" runat="server" Label="第十七天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day18Flag" runat="server" Label="第十八天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day19Flag" runat="server" Label="第十九天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day20Flag" runat="server" Label="第二十天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day21Flag" runat="server" Label="第二十一天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day22Flag" runat="server" Label="第二十二天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day23Flag" runat="server" Label="第二十三天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day24Flag" runat="server" Label="第二十四天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day25Flag" runat="server" Label="第二十五天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day26Flag" runat="server" Label="第二十六天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day27Flag" runat="server" Label="第二十七天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day28Flag" runat="server" Label="第二十八天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day29Flag" runat="server" Label="第二十九天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day30Flag" runat="server" Label="第三十天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Day31Flag" runat="server" Label="第三十一天">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
