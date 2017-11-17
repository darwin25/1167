<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.IMP_Product.Show" %>

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
            <ext:TabStrip ID="TabStrip1" Width="850px" ShowBorder="false" ActiveTabIndex="0"
                runat="server">
                <Tabs>
                    <ext:Tab ID="Tab1" Title="Basic Information" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form4" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false" LabelWidth="150">
                                <Rows>
                                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="INTERNAL_PRODUCT_CODE" runat="server" Label="Product Code">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                     <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="ProductName1" runat="server" Label="Product Name1">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="ProductName2" runat="server" Label="Product Name2">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow41" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="ProductName3" runat="server" Label="Product Name3">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow28" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="CompanyID" runat="server" Label="公司名称">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow16" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="BARCODE" runat="server" Label="Barcode">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="SUPPLIER_PRODUCT_CODE" runat="server" Label="供货商产品编码">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                     <ext:FormRow ID="FormRow30" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="BrandCode" runat="server" Label="Brand Code">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow36" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="BrandName" runat="server" Label="Brand Name">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                     <ext:FormRow ID="FormRow29" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="SKU" runat="server" Label="SKU">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow50" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="YEAR" runat="server" Label="年份">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow37" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SEASON" runat="server" Label="季节">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%" Hidden="true">
                                        <Items>
                                            <ext:Label ID="ARTICLE" runat="server" Label="ARTICLE">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow31" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="CatNameEn" runat="server" Label="Department Name 1">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow32" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="CatNameSC" runat="server" Label="Department Name 2">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow33" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="CatNameTC" runat="server" Label="Department Name 3">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow38" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SEX" runat="server" Label="性别">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow52" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="MODEL" runat="server" Label="模型">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow39" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="COLOR" runat="server" Label="Color Code">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow53" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="PSIZE" runat="server" Label="Item Size Code">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow17" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="CLASS" runat="server" Label="货品样式">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab2" Title="详细" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form5" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false"  LabelWidth="160">
                                <Rows>
                                    <ext:FormRow ID="FormRow20" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="DESCRIPTION" runat="server" Label="产品说明">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow21" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="DESCRIPTION2" runat="server" Label="产品说明2">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow26" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="LOCAL_DESCRIPTION" runat="server" Label="地方说明">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="ShortDescription1" runat="server" Label="产品描述">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow42" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="ShortDescription2" runat="server" Label="产品描述">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="ShortDescription3" runat="server" Label="产品描述">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow43" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="DetailedDescription1" runat="server"  Label="详细描述">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow44" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="DetailedDescription2" runat="server"  Label="详细描述">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow45" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="DetailedDescription3" runat="server" Label="详细描述">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="MATERIAL_1" runat="server" Label="OuterLayerMaterials">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow15" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="MATERIAL_2" runat="server" Label="InnerLayerMaterials">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab3" Title="Status" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form6" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false">
                                <Rows>
                                    <ext:FormRow ID="FormRow46" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="REORDER_LEVEL" runat="server" Label="订货点水平">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow55" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="RETIRED" runat="server" Label="下架">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow47" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="RETIRE_DATE" runat="server" Label="下架日期">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow18" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="LAST_UPDATE_DATE" runat="server" Label="最后更新时间">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow19" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="LAST_UPDATE_USER" runat="server" Label="最后更新人">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab4" Title="Price" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form2" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false">
                                <Rows>
                                    <ext:FormRow ID="FormRow25" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="PRICE" runat="server" Label="标准价格">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow35" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="STANDARD_COST" runat="server" Label="成本价格">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow23" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="EXPORT_COST" runat="server" Label="出口价格">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow24" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="AVG_Cost" runat="server" Label="平均价格">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                     <ext:FormRow ID="FormRow27" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="FINAL_DISCOUNT_PRICE" runat="server" Label="最后折扣价格">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab5" Title="供应商产品" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Grid ID="AddResultListGrid3" ShowBorder="false" ShowHeader="false" PageSize="3"
                                runat="server" EnableCheckBoxSelect="true" DataKeyNames="ProdCode" AllowPaging="true"
                                IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid3_PageIndexChange">
                                <Columns>
                                    <ext:TemplateField Width="60px" HeaderText="供应商编号">
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("VendorCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="货品号">
                                        <ItemTemplate>
                                            <asp:Label ID="Label13" runat="server" Text='<%#Eval("ProdCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="供应商产品编号">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("SUPPLIER_PRODUCT_CODE")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="30px" HeaderText="税">
                                        <ItemTemplate>
                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("in_tax")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="优先权">
                                        <ItemTemplate>
                                            <asp:Label ID="Label11" runat="server" Text='<%#Eval("Prefer")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="是否默认供应商">
                                        <ItemTemplate>
                                            <asp:Label ID="Label12" runat="server" Text='<%#GetIsDefault(Convert.ToInt32(Eval("IsDefault")))%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab6" Title="其他" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false" LabelWidth="160">
                                <Rows>
                                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="SIZE_RANGE" runat="server" Label="尺寸范围">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="HS_CODE" runat="server" Label="海关编码">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="COO" runat="server" Label="首席运营官">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="DESIGNER" runat="server" Label="设计师">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="BUYER" runat="server" Label="买主">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="100%">
                                        <Items>
                                            <ext:Label ID="MERCHANDISER" runat="server" Label="零售商">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                </Tabs>
            </ext:TabStrip>
        </Items>
    </ext:SimpleForm>
    <ext:Window ID="WindowPic" Title="Image" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" IFrameUrl="about:blank" EnableMaximize="false" EnableResize="true"
        Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
