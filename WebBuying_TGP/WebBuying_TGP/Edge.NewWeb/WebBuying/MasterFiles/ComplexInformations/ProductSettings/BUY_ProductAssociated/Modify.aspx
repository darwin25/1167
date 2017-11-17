<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductAssociated.Modify" %>
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
            <ext:TextBox ID="ProdCode" runat="server" Label="Product Code" Required="true" ShowRedStar="true"
                Enabled="false"/>
            <ext:TextBox ID="AssociatedProdCode" runat="server" Label="Associated Product Code" Required="true" ShowRedStar="true"
                Enabled="false"/>
            <ext:TextBox ID="AssociatedProdName" runat="server" Label="Associated Product Name"/>
            <ext:Form ID="FormLoad"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow2" ColumnWidths="0% 80% 10%" runat="server">
                        <Items>
                            <ext:Label ID="uploadFilePath" Hidden="true" Text="" runat="server">
                            </ext:Label>
                            <ext:FileUpload ID="AssociatedProdFile" runat="server" Label="Picture of Goods">
                            </ext:FileUpload>
                            <ext:Button ID="btnBack" runat="server" Text="返回" HideMode="Display" Hidden="true" OnClick="btnBack_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormReLoad" ShowBorder="false" ShowHeader="false" Title=""  runat="server" HideMode="Display" Hidden="true">
                <Rows>
                    <ext:FormRow ID="FormRow3" ColumnWidths="69% 11% 20%" runat="server">
                        <Items>
                        <ext:Label ID="Label2" runat="server" Label="Picture of Goods"></ext:Label>
                            <ext:Button ID="btnPreview" runat="server" Text="View" HideMode="Display" Icon="Picture">
                            </ext:Button>
                            <ext:Button ID="btnReUpLoad" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad_Click"> 
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TextBox ID="Note" runat="server" Label="Remarks"/>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required"  CssStyle="font-size:12px;color:red"></ext:Label>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="Window2" Title="Search" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="900px" Height="450px">
    </ext:Window>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
