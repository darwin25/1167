<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCTSTYLE.Modify" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
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
            <ext:TextBox ID="ProdCodeStyle" runat="server" Label="Product Type Code" Required="true" ShowRedStar="true" Enabled="false"/>
            <%--<ext:Form ID="FormLoad"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow1" ColumnWidths="50% 5% 45%" runat="server">
                        <Items>
                            <ext:TextBox ID="ProdCode" runat="server" Label="Product Code" Width="223"
                                Readonly="true"></ext:TextBox>
                            <ext:Button ID="btnSelect" runat="server" Text="..."></ext:Button>
                            <ext:Label ID="Label1" runat="server" Hidden="true" HideMode="Display"></ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>--%>
            <ext:TextBox ID="ProdCode" runat="server" Label="Product Code" Enabled="false"></ext:TextBox>
            <ext:TextBox ID="ProductSizeType" runat="server" Label="Product Size Type"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true"/>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required"  CssStyle="font-size:12px;color:red"></ext:Label>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="Window2" Title="Search" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
