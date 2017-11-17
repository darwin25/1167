<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_PRODUCTSTYLE.Show" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Show</title>
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
                    
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form ID="Form3"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Display" Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdCodeStyle" runat="server" Label="Product Type Code">
                            </ext:Label>
                            <ext:Label ID="ProdCode" runat="server" Label="Product Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProductSizeType" runat="server" Label="Product Size Type">
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
