<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs"  ValidateRequest="false" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_BRAND.Add" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add</title>
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
            <ext:TextBox ID="BrandCode" runat="server" Label="Brand Code" MaxLength="20" Required="true"
                ShowRedStar="true" OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true">
            </ext:TextBox>
            <ext:TextBox ID="BrandName1" runat="server" Label="Brand Name" MaxLength="512"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true">
            </ext:TextBox>
            <ext:TextBox ID="BrandName2" runat="server" Label="品牌名称2" MaxLength="512"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true">
            </ext:TextBox>
            <ext:TextBox ID="BrandName3" runat="server" Label="品牌名称3" MaxLength="512"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true">
            </ext:TextBox>
            <ext:HtmlEditor ID="BrandDesc1" runat="server" Height="100" Label="品牌描述1"></ext:HtmlEditor>
            <ext:HtmlEditor ID="BrandDesc2" runat="server" Height="100" Label="品牌描述2"></ext:HtmlEditor>
            <ext:HtmlEditor ID="BrandDesc3" runat="server" Height="100" Label="品牌描述3"></ext:HtmlEditor>
            <ext:HiddenField ID="uploadFilePath" runat="server"></ext:HiddenField>
            <ext:Form ID="Form2" ShowHeader="false"  ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow1" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:FileUpload ID="BrandPicSFile" runat="server" Label="小图文件路径名">
                            </ext:FileUpload>
                            <ext:Label ID="label1" runat="server" HideMode="Display" Hidden="true"></ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="Form3" ShowHeader="false"  ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow2" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:FileUpload ID="BrandPicMFile" runat="server" Label="中图文件路径名">
                            </ext:FileUpload>
                            <ext:Label ID="label2" runat="server" HideMode="Display" Hidden="true"></ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="Form4" ShowHeader="false"  ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow3" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:FileUpload ID="BrandPicGFile" runat="server" Label="大图文件路径名">
                            </ext:FileUpload>
                            <ext:Label ID="label3" runat="server" HideMode="Display" Hidden="true"></ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TextBox ID="CardIssuerID" runat="server" Label="Translate__Special_121_Start发行方IDTranslate__Special_121_End"></ext:TextBox>
            <ext:TextBox ID="IndustryID" runat="server" Label="外键"></ext:TextBox>
            <ext:Window ID="WindowPic" Title="" Hidden="true" EnableIFrame="true" runat="server"
                CloseAction="HidePostBack" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
                Target="Top" IsModal="True" Width="750px" Height="450px"> 
            </ext:Window>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required"  CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>

