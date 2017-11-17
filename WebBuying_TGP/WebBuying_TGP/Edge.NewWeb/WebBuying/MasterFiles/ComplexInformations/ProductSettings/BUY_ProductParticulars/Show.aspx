<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.ProductSettings.BUY_ProductParticulars.Show" %>
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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
                            <ext:Label ID="ProdCode" runat="server" Label="Product Code">
                            </ext:Label>
                            <ext:Label ID="LanguageIDView" runat="server" Label="Language">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdFunction" runat="server" Label="产品功能描述">
                            </ext:Label>
                            <ext:Label ID="ProdIngredients" runat="server" Label="产品成分描述">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ProdInstructions" runat="server" Label="产品使用说明">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="PackDesc" runat="server" Label="销售包装描述 ">
                            </ext:Label>
                            <ext:Label ID="PackUnit" runat="server" Label="销售包装单位">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Memo1" runat="server" Label="货品扩展属性1">
                            </ext:Label>
                            <ext:Label ID="Memo2" runat="server" Label="货品扩展属性2">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Memo3" runat="server" Label="货品扩展属性3">
                            </ext:Label>
                            <ext:Label ID="Memo4" runat="server" Label="货品扩展属性4">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Memo5" runat="server" Label="货品扩展属性5">
                            </ext:Label>
                            <ext:Label ID="Memo6" runat="server" Label="货品扩展属性6">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="MemoTitle1" runat="server" Label="货品扩展属性标题1">
                            </ext:Label>
                            <ext:Label ID="MemoTitle2" runat="server" Label="货品扩展属性标题2">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="MemoTitle3" runat="server" Label="货品扩展属性标题3">
                            </ext:Label>
                            <ext:Label ID="MemoTitle4" runat="server" Label="货品扩展属性标题4">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="MemoTitle5" runat="server" Label="货品扩展属性标题5">
                            </ext:Label>
                            <ext:Label ID="MemoTitle6" runat="server" Label="货品扩展属性标题6">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:DropDownList ID="LanguageID" runat="server" Label="Language"  Hidden="true"></ext:DropDownList>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
