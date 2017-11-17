<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" ValidateRequest="false" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductParticulars.Modify" %>
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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right"  LabelWidth="150">
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
            <ext:DropDownList ID="LanguageID" runat="server" Label="Language"  Enabled="false"></ext:DropDownList>
            <ext:TextBox ID="ProdFunction" runat="server" Label="产品功能描述"/>
            <ext:TextBox ID="ProdIngredients" runat="server" Label="产品成分描述"/>
            <ext:TextBox ID="ProdInstructions" runat="server" Label="产品使用说明"/>
            <ext:TextBox ID="PackDesc" runat="server" Label="销售包装描述"/>
            <ext:TextBox ID="PackUnit" runat="server" Label="销售包装单位"/>
            <ext:TextBox ID="Memo1" runat="server" Label="货品扩展属性1"/>
            <ext:TextBox ID="Memo2" runat="server" Label="货品扩展属性2"/>
            <ext:TextBox ID="Memo3" runat="server" Label="货品扩展属性3"/>
            <ext:TextBox ID="Memo4" runat="server" Label="货品扩展属性4"/>
            <ext:TextBox ID="Memo5" runat="server" Label="货品扩展属性5"/>
            <ext:TextBox ID="Memo6" runat="server" Label="货品扩展属性6"/>
            <ext:TextBox ID="MemoTitle1" runat="server" Label="货品扩展属性标题1"/>
            <ext:TextBox ID="MemoTitle2" runat="server" Label="货品扩展属性标题2"/>
            <ext:TextBox ID="MemoTitle3" runat="server" Label="货品扩展属性标题3"/>
            <ext:TextBox ID="MemoTitle4" runat="server" Label="货品扩展属性标题4"/>
            <ext:TextBox ID="MemoTitle5" runat="server" Label="货品扩展属性标题5"/>
            <ext:TextBox ID="MemoTitle6" runat="server" Label="货品扩展属性标题6"/>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required"  CssStyle="font-size:12px;color:red"></ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
