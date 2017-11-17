<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
</head>
<body>
       <form id="Form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="180">
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
            <ext:TextBox ID="ProdClassCode" runat="server" Label="Product Category Code" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:TextBox ID="ProdClassDesc1" runat="server" Label="货品大类描述1" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="ProdClassDesc2" runat="server" Label="货品大类描述2" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="ProdClassDesc3" runat="server" Label="货品大类描述3" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
               <ext:DropDownList ID="ParentID" runat="server" Label="父类"></ext:DropDownList>
            <ext:DropDownList ID="ProductSizeType" runat="server" Label="此大类货品使用的尺寸类型" Required="true"
                ShowRedStar="true">
            </ext:DropDownList>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
