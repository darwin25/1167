<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_WEEKFLAG.Show" %>

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
                            <ext:Label ID="WeekFlagCode" runat="server" Label="Code">
                            </ext:Label>
                            <ext:Label ID="Note" runat="server" Label="Remarks">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="SundayFlag" runat="server" Label="星期日">
                            </ext:Label>
                            <ext:Label ID="MondayFlag" runat="server" Label="星期一">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="TuesdayFlag" runat="server" Label="星期二">
                            </ext:Label>
                            <ext:Label ID="WednesdayFlag" runat="server" Label="星期三">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ThursdayFlag" runat="server" Label="星期四">
                            </ext:Label>
                            <ext:Label ID="FridayFlag" runat="server" Label="星期五">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="SaturdayFlag" runat="server" Label="星期六">
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
