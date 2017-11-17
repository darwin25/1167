<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_MONTHFLAG.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
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
            <ext:TextBox ID="MonthFlagCode" runat="server" Label="月设置编码" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:TextBox ID="Note" runat="server" Label="Remarks" />
            <ext:RadioButtonList ID="JanuaryFlag" runat="server" Label="一月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="FebruaryFlag" runat="server" Label="二月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="MarchFlag" runat="server" Label="三月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="AprilFlag" runat="server" Label="四月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="MayFlag" runat="server" Label="五月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="JuneFlag" runat="server" Label="六月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="JulyFlag" runat="server" Label="七月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="AugustFlag" runat="server" Label="八月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="SeptemberFlag" runat="server" Label="九月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="OctoberFlag" runat="server" Label="十月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="NovemberFlag" runat="server" Label="十一月">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="DecemberFlag" runat="server" Label="十二月">
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
