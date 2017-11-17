<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT_Pending.Show" %>

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
                                Hidden="false" LabelWidth="160">
                                <Rows>
                                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ProdCode" runat="server" Label="Product Code">
                                            </ext:Label>
                                            <ext:Label ID="OldProdCode" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ProdDesc1" runat="server" Label="Product Name1">
                                            </ext:Label>
                                            <ext:Label ID="OldProdDesc1" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ProdDesc2" runat="server" Label="Product Name2">
                                            </ext:Label>
                                            <ext:Label ID="OldProdDesc2" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow41" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ProdDesc3" runat="server" Label="Product Name3">
                                            </ext:Label>
                                            <ext:Label ID="OldProdDesc3" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow28" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="CompanyID" runat="server" Label="公司名称">
                                            </ext:Label>
                                            <ext:Label ID="OldCompanyID" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow29" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SKU" runat="server" Label="SKU">
                                            </ext:Label>
                                            <ext:Label ID="oldSKU" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow36" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="BrandCode" runat="server" Label="Brand Code">
                                            </ext:Label>
                                            <ext:Label ID="oldBrandCode" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow50" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="Year" runat="server" Label="年份">
                                            </ext:Label>
                                            <ext:Label ID="oldYear" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow37" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SEASON" runat="server" Label="季节">
                                            </ext:Label>
                                            <ext:Label ID="oldSEASON" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow38" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SEX" runat="server" Label="性别">
                                            </ext:Label>
                                            <ext:Label ID="oldSEX" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow52" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="MODEL" runat="server" Label="模型">
                                            </ext:Label>
                                            <ext:Label ID="oldMODEL" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow39" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ColorCode" runat="server" Label="Color Code">
                                            </ext:Label>
                                            <ext:Label ID="oldColorCode" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow53" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ProductSizeCode" runat="server" Label="Item Size Code">
                                            </ext:Label>
                                            <ext:Label ID="oldProductSizeCode" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow32" runat="server">
                                        <Items>
                                            <ext:Form ID="Form2" ShowHeader="false" ShowBorder="false" runat="server">
                                                <Rows>
                                                    <ext:FormRow ID="FormRow33" ColumnWidths="0% 40% 10%" runat="server">
                                                        <Items>
                                                            <ext:Label ID="uploadFilePath" Hidden="true" runat="server">
                                                            </ext:Label>
                                                            <ext:Label ID="Label1" Text="" runat="server" Label="Picture of Goods">
                                                            </ext:Label>
                                                            <ext:Button ID="btnPreview" runat="server" Text="View" Icon="Picture">
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:FormRow>
                                                </Rows>
                                            </ext:Form>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab2" Title="Barcode" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" PageSize="3"
                                runat="server" EnableCheckBoxSelect="true" DataKeyNames="Barcode" AllowPaging="true"
                                IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                                <Columns>
                                    <ext:TemplateField Width="60px" HeaderText="Barcode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("Barcode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab3" Title="Description" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form5" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false">
                                <Rows>
                                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ShortDescription1" runat="server" Label="产品描述">
                                            </ext:Label>
                                            <ext:Label ID="oldShortDescription1" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow42" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ShortDescription2" runat="server" Label="产品描述">
                                            </ext:Label>
                                            <ext:Label ID="oldShortDescription2" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="ShortDescription3" runat="server" Label="产品描述">
                                            </ext:Label>
                                            <ext:Label ID="oldShortDescription3" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow43" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="DetailedDescription1" runat="server" Label="详细描述">
                                            </ext:Label>
                                            <ext:Label ID="oldDetailedDescription1" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow44" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="DetailedDescription2" runat="server" Label="详细描述">
                                            </ext:Label>
                                            <ext:Label ID="oldDetailedDescription2" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow45" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="DetailedDescription3" runat="server" Label="详细描述">
                                            </ext:Label>
                                            <ext:Label ID="oldDetailedDescription3" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="MATERIAL_1" runat="server" Label="OuterLayerMaterials">
                                            </ext:Label>
                                            <ext:Label ID="oldMATERIAL_1" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow15" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="MATERIAL_2" runat="server" Label="InnerLayerMaterials">
                                            </ext:Label>
                                            <ext:Label ID="oldMATERIAL_2" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab4" Title="Status" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form6" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false">
                                <Rows>
                                    <ext:FormRow ID="FormRow46" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="REORDER_LEVEL" runat="server" Label="订货点水平">
                                            </ext:Label>
                                            <ext:Label ID="oldREORDER_LEVEL" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow55" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="RETIRED" runat="server" Label="下架">
                                            </ext:Label>
                                            <ext:Label ID="oldRETIRED" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow47" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="RETIRE_DATE" runat="server" Label="下架日期">
                                            </ext:Label>
                                            <ext:Label ID="oldRETIRE_DATE" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow48" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow56" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="CreatedBy" runat="server" Label="Created By">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow49" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="UpdatedOn" runat="server" Label="更新日期">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow57" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="UpdatedBy" runat="server" Label="更新人">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab6" Title="Price" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Grid ID="AddResultListGrid2" ShowBorder="false" ShowHeader="false" PageSize="3"
                                runat="server" EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true"
                                IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid2_PageIndexChange">
                                <Columns>
                                    <ext:TemplateField Width="60px" HeaderText="Price Effective Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("StartDate","{0:yyyy-MM-dd}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Price Expiration Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("EndDate","{0:yyyy-MM-dd}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Retail Price Type">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("RPriceTypeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Retail Price">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Reference price">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("RefPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                    <ext:TemplateField Width="60px" HeaderText="Member Price">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("MemberPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                    </ext:TemplateField>
                                </Columns>
                            </ext:Grid>
                            <ext:Form ID="Form7" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false">
                                <Rows>
                                    <ext:FormRow ID="FormRow35" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="STANDARD_COST" runat="server" Label="成本价格">
                                            </ext:Label>
                                            <ext:Label ID="oldSTANDARD_COST" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="EXPORT_COST" runat="server" Label="出口价格">
                                            </ext:Label>
                                            <ext:Label ID="oldEXPORT_COST" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="AVG_Cost" runat="server" Label="平均价格">
                                            </ext:Label>
                                            <ext:Label ID="OldAVG_Cost" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab8" Title="供应商产品" BodyPadding="5px" runat="server">
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
                    <ext:Tab ID="Tab9" Title="其他" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                                Hidden="false" LabelWidth="160">
                                <Rows>
                                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SIZE_RANGE" runat="server" Label="尺寸范围">
                                            </ext:Label>
                                            <ext:Label ID="oldSIZE_RANGE" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="HS_CODE" runat="server" Label="海关编码">
                                            </ext:Label>
                                            <ext:Label ID="oldHS_CODE" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="COO" runat="server" Label="首席运营官">
                                            </ext:Label>
                                            <ext:Label ID="oldCOO" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="DESIGNER" runat="server" Label="设计师">
                                            </ext:Label>
                                            <ext:Label ID="oldDESIGNER" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="BUYER" runat="server" Label="买主">
                                            </ext:Label>
                                            <ext:Label ID="oldBUYER" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="MERCHANDISER" runat="server" Label="零售商">
                                            </ext:Label>
                                            <ext:Label ID="oldMERCHANDISER" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow16" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM1" runat="server" Label="尺寸1">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM1" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow17" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM2" runat="server" Label="尺寸2">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM2" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow18" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM3" runat="server" Label="尺寸3">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM3" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                     <ext:FormRow ID="FormRow19" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM4" runat="server" Label="尺寸4">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM4" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow20" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM5" runat="server" Label="尺寸5">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM5" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow21" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM6" runat="server" Label="尺寸6">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM6" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow22" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM7" runat="server" Label="尺寸7">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM7" runat="server">
                                            </ext:Label>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow23" runat="server" ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label ID="SizeM8" runat="server" Label="尺寸8">
                                            </ext:Label>
                                            <ext:Label ID="oldSizeM8" runat="server">
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
