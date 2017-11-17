<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs"   ValidateRequest="false" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BRAND.Modify" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modify</title>
    <link href="/res/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true"
        LabelAlign="Right" LabelWidth="150">
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
            <ext:TextBox ID="StoreBrandCode" runat="server" Label="Brand Code" MaxLength="20" Required="true"
                ShowRedStar="true" Enabled="false">
            </ext:TextBox>
            <ext:TextBox ID="StoreBrandName1" runat="server" Label="Brand Name 1" MaxLength="512"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true">
            </ext:TextBox>
            <ext:TextBox ID="StoreBrandName2" runat="server" Label="品牌名称2" MaxLength="512"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true">
            </ext:TextBox>
            <ext:TextBox ID="StoreBrandName3" runat="server" Label="品牌名称3" MaxLength="512"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true">
            </ext:TextBox>
            <ext:HtmlEditor ID="StoreBrandDesc1" runat="server" Height="100" Label="品牌描述1"></ext:HtmlEditor>
            <ext:HtmlEditor ID="StoreBrandDesc2" runat="server" Height="100" Label="品牌描述2"></ext:HtmlEditor>
            <ext:HtmlEditor ID="StoreBrandDesc3" runat="server" Height="100" Label="品牌描述3"></ext:HtmlEditor>
            <ext:HiddenField ID="PicturePath" runat="server"></ext:HiddenField>
            <ext:Form ID="FormLoad"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow1" ColumnWidths="0% 80% 10%" runat="server">
                        <Items>
                            <ext:Label ID="uploadFilePath" Hidden="true" Text="" runat="server">
                            </ext:Label>
                            <ext:FileUpload ID="BrandPicSFile" runat="server" Label="小图文件路径名">
                            </ext:FileUpload>
                            <ext:Button ID="btnBack1" runat="server" Text="返回" HideMode="Display" Hidden="true" OnClick="btnBack1_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormReLoad" ShowBorder="false" ShowHeader="false" Title=""  runat="server" HideMode="Display" Hidden="true">
                <Rows>
                    <ext:FormRow ID="FormRow2" ColumnWidths="69% 11% 20%" runat="server">
                        <Items>
                        <ext:Label ID="Label1" runat="server" Label="小图文件路径名"></ext:Label>
                            <ext:Button ID="btnPreview" runat="server" Text="View" HideMode="Display" Icon="Picture">
                            </ext:Button>
                            <ext:Button ID="btnReUpLoad1" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad1_Click"> 
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>

            <ext:Form ID="FormLoad1"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow3" ColumnWidths="0% 80% 10%" runat="server">
                        <Items>
                            <ext:Label ID="uploadFilePath1" Hidden="true" Text="" runat="server">
                            </ext:Label>
                            <ext:FileUpload ID="BrandPicMFile" runat="server" Label="中图文件路径名">
                            </ext:FileUpload>
                            <ext:Button ID="btnBack2" runat="server" Text="返回" HideMode="Display" Hidden="true" OnClick="btnBack2_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormReLoad1" ShowBorder="false" ShowHeader="false" Title=""  runat="server" HideMode="Display" Hidden="true">
                <Rows>
                    <ext:FormRow ID="FormRow4" ColumnWidths="69% 11% 20%" runat="server">
                        <Items>
                            <ext:Label ID="Label2" runat="server" Label="中图文件路径名"></ext:Label>
                            <ext:Button ID="btnPreview1" runat="server" Text="View" HideMode="Display" Icon="Picture">
                            </ext:Button>
                            <ext:Button ID="btnReUpLoad2" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad2_Click"> 
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>

            <ext:Form ID="FormLoad2"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Offsets">
                <Rows>
                    <ext:FormRow ID="FormRow5" ColumnWidths="0% 80% 10%" runat="server">
                        <Items>
                            <ext:Label ID="uploadFilePath2" Hidden="true" Text="" runat="server">
                            </ext:Label>
                            <ext:FileUpload ID="BrandPicGFile" runat="server" Label="大图文件路径名">
                            </ext:FileUpload>
                            <ext:Button ID="btnBack3" runat="server" Text="返回" HideMode="Display" Hidden="true" OnClick="btnBack3_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="FormReLoad2" ShowBorder="false" ShowHeader="false" Title=""  runat="server" HideMode="Display" Hidden="true">
                <Rows>
                    <ext:FormRow ID="FormRow6" ColumnWidths="69% 11% 20%" runat="server">
                        <Items>
                            <ext:Label ID="Label3" runat="server" Label="大图文件路径名"></ext:Label>
                            <ext:Button ID="btnPreview2" runat="server" Text="View" HideMode="Display" Icon="Picture">
                            </ext:Button>
                            <ext:Button ID="btnReUpLoad3" runat="server" Text="Re-Upload" HideMode="Display" OnClick="btnReUpLoad3_Click"> 
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TextBox ID="CardIssuerID" runat="server" Label="货品发行方"></ext:TextBox>
            <ext:TextBox ID="IndustryID" runat="server" Label="外键"></ext:TextBox>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required"  CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <ext:Window ID="WindowPicture" Title="" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px"> 
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>

