<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG.Add" %>

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
            <ext:TextBox ID="WeekFlagCode" runat="server" Label="周设置编码" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:TextBox ID="Note" runat="server" Label="Remarks" />
            <ext:RadioButtonList ID="SundayFlag" runat="server" Label="星期日">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="MondayFlag" runat="server" Label="星期一">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="TuesdayFlag" runat="server" Label="星期二">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="WednesdayFlag" runat="server" Label="星期三">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="ThursdayFlag" runat="server" Label="星期四">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="FridayFlag" runat="server" Label="星期五">
                <ext:RadioItem Text="生效" Value="1" />
                <ext:RadioItem Text="Invalid" Value="0" Selected="true" />
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="SaturdayFlag" runat="server" Label="星期六">
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
