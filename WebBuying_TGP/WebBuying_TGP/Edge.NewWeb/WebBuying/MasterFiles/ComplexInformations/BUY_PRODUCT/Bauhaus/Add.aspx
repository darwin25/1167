<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Add.aspx.cs"
    Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_PRODUCT.Bauhaus.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add</title>
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
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
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
                            <ext:SimpleForm ID="SimpleForm2" ShowBorder="false" ShowHeader="false" runat="server"
                                BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="140">
                                <Items>
                                    <ext:TextBox ID="ProdCode" runat="server" Label="Product Code" Required="true" ShowRedStar="true" />
                                    <ext:DropDownList ID="CompanyID" runat="server" Label="公司名称" ShowRedStar="true" Required="true">
                                    </ext:DropDownList>
                                    <ext:TextBox ID="SKU" runat="server" Label="SKU" ShowRedStar="true" Required="true">
                                    </ext:TextBox>
                                    <ext:DropDownList ID="BrandCode" runat="server" Label="Brand Code" ShowRedStar="true" Required="true" />
                                      <ext:DropDownList runat="server" ID="StoreBrandCode" Label="Store Brand Code"  OnSelectedIndexChanged="StoreBrandCode_SelectedIndexChanged" AutoPostBack="true">
                                      </ext:DropDownList>
                                    <ext:DatePicker ID="Year" runat="server" Label="年份" DateFormatString="yyyy">
                                    </ext:DatePicker>
                                    <ext:DropDownList ID="SEASON" runat="server" Label="季节" ShowRedStar="true" Required="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="DepartCode" runat="server" Label="Department Code" ShowRedStar="true"
                                        Required="true" />
                                     <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" ShowRedStar="true" Required="true" />
                                    <ext:RadioButtonList ID="SEX" runat="server" Label="性别" ShowRedStar="true" Required="true">
                                        <ext:RadioItem Text="男" Value="1" Selected="true" />
                                        <ext:RadioItem Text="女" Value="2" />
                                    </ext:RadioButtonList>
                                    <ext:TextBox ID="MODEL" runat="server" Label="模型" ShowRedStar="true" Required="true">
                                    </ext:TextBox>
                                    <ext:DropDownList ID="ColorCode" runat="server" Label="Color Code" ShowRedStar="true"
                                        Required="true">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="ProductSizeCode" runat="server" Label="Item Size Code" ShowRedStar="true"
                                        Required="true">
                                    </ext:DropDownList>
                                    <ext:FileUpload ID="ProdPicFile" runat="server" Label="Picture of Goods">
                                    </ext:FileUpload>
                                    <ext:Label ID="Label1" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
                                    </ext:Label>
                                </Items>
                            </ext:SimpleForm>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab3" Title="Description" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:SimpleForm ID="SimpleForm4" ShowBorder="false" ShowHeader="false" runat="server"
                                BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="160">
                                <Items>
                                    <ext:TextBox ID="ProdDesc1" runat="server" Label="Product Name1" OnTextChanged="ConvertTextboxToUpperText"
                                        AutoPostBack="true" ShowRedStar="true" Required="true" />
                                    <ext:TextBox ID="ProdDesc2" runat="server" Label="Product Name2" OnTextChanged="ConvertTextboxToUpperText"
                                        AutoPostBack="true" ShowRedStar="true" Required="true" />
                                    <ext:TextBox ID="ProdDesc3" runat="server" Label="Product Name3" OnTextChanged="ConvertTextboxToUpperText"
                                        AutoPostBack="true" ShowRedStar="true" Required="true" />
                                    <ext:TextBox ID="ShortDescription1" runat="server" Label="产品描述1" ShowRedStar="true"
                                        Required="true">
                                    </ext:TextBox>
                                    <ext:TextBox ID="ShortDescription2" runat="server" Label="产品描述2" ShowRedStar="true"
                                        Required="true">
                                    </ext:TextBox>
                                    <ext:TextBox ID="ShortDescription3" runat="server" Label="产品描述3" ShowRedStar="true"
                                        Required="true">
                                    </ext:TextBox>
                                    <ext:TextArea ID="DetailedDescription1" runat="server" Height="100" Label="详细描述1"
                                        ShowRedStar="true" Required="true">
                                    </ext:TextArea>
                                    <ext:TextArea ID="DetailedDescription2" runat="server" Height="100" Label="详细描述2"
                                        ShowRedStar="true" Required="true">
                                    </ext:TextArea>
                                    <ext:TextArea ID="DetailedDescription3" runat="server" Height="100" Label="详细描述3"
                                        ShowRedStar="true" Required="true">
                                    </ext:TextArea>
                                    <ext:DropDownList ID="MATERIAL_1" runat="server" Label="OuterLayerMaterials">
                                    </ext:DropDownList>
                                    <ext:DropDownList ID="MATERIAL_2" runat="server" Label="InnerLayerMaterials">
                                    </ext:DropDownList>
                                </Items>
                            </ext:SimpleForm>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab4" Title="Status" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:SimpleForm ID="SimpleForm5" ShowBorder="false" ShowHeader="false" runat="server"
                                BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                                <Items>
                                    <ext:NumberBox ID="REORDER_LEVEL" runat="server" Label="订货点水平" Text="0.00">
                                    </ext:NumberBox>
                                    <ext:RadioButtonList ID="RETIRED" runat="server" Label="下架">
                                        <ext:RadioItem Text="不是不能销售货品" Value="0" Selected="true" />
                                        <ext:RadioItem Text="是不能销售货品" Value="1" />
                                    </ext:RadioButtonList>
                                    <ext:DatePicker ID="RETIRE_DATE" runat="server" Label="下架日期">
                                    </ext:DatePicker>
                                </Items>
                            </ext:SimpleForm>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab6" Title="Price" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:Grid ID="AddResultListGrid2" ShowBorder="false" ShowHeader="false" PageSize="3"
                                runat="server" EnableCheckBoxSelect="true" DataKeyNames="KeyID" AllowPaging="true"
                                IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid2_PageIndexChange">
                                <Toolbars>
                                    <ext:Toolbar ID="Toolbar2" runat="server" Position="Top">
                                        <Items>
                                            <ext:Button ID="btnViewSearch2" Icon="Add" runat="server" Text="Add" OnClick="btnViewSearch2_Click">
                                            </ext:Button>
                                            <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                            </ext:ToolbarSeparator>
                                            <ext:Button ID="btnDeleteResultItem2" Icon="Delete" runat="server" Text="Delete" OnClick="btnDeleteResultItem2_Click">
                                            </ext:Button>
                                            <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                            </ext:ToolbarSeparator>
                                            <ext:Button ID="btnClearAllResultItem2" Icon="Delete" runat="server" Text="清空" OnClick="btnClearAllResultItem2_Click">
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </Toolbars>
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
                            <ext:SimpleForm ID="SimpleForm3" ShowBorder="false" ShowHeader="false" runat="server"
                                BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                                <Items>
                                    <ext:NumberBox ID="STANDARD_COST" runat="server" Label="标准价格" Text="0.00" ShowRedStar="true"
                                        Required="true" />
                                    <ext:NumberBox ID="EXPORT_COST" runat="server" Label="出口价格" Text="0.00" ShowRedStar="true"
                                        Required="true" />
                                    <ext:NumberBox ID="AVG_Cost" runat="server" Label="平均价格" Text="0.00" ShowRedStar="true"
                                        Required="true" />
                                </Items>
                            </ext:SimpleForm>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="Tab7" Title="其他" BodyPadding="5px" runat="server">
                        <Items>
                            <ext:SimpleForm ID="SimpleForm8" ShowBorder="false" ShowHeader="false" runat="server"
                                BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                                <Items>
                                    <ext:TextBox ID="SIZE_RANGE" runat="server" Label="尺寸范围">
                                    </ext:TextBox>
                                    <ext:TextBox ID="HS_CODE" runat="server" Label="海关编码">
                                    </ext:TextBox>
                                    <ext:TextBox ID="COO" runat="server" Label="首席运营官">
                                    </ext:TextBox>
                                    <ext:TextBox ID="DESIGNER" runat="server" Label="设计师">
                                    </ext:TextBox>
                                    <ext:TextBox ID="BUYER" runat="server" Label="买主">
                                    </ext:TextBox>
                                    <ext:TextBox ID="MERCHANDISER" runat="server" Label="零售商">
                                    </ext:TextBox>
                                    <ext:NumberBox ID="SizeM1" runat="server" Label="尺寸1"></ext:NumberBox>
                                    <ext:NumberBox ID="SizeM2" runat="server" Label="尺寸2"></ext:NumberBox>
                                    <ext:NumberBox ID="SizeM3" runat="server" Label="尺寸3"></ext:NumberBox>
                                    <ext:NumberBox ID="SizeM4" runat="server" Label="尺寸4"></ext:NumberBox>
                                    <ext:NumberBox ID="SizeM5" runat="server" Label="尺寸5"></ext:NumberBox>
                                    <ext:NumberBox ID="SizeM6" runat="server" Label="尺寸6"></ext:NumberBox>
                                    <ext:NumberBox ID="SizeM7" runat="server" Label="尺寸7"></ext:NumberBox>
                                    <ext:NumberBox ID="SizeM8" runat="server" Label="尺寸8"></ext:NumberBox>
                                </Items>
                            </ext:SimpleForm>
                        </Items>
                    </ext:Tab>
                </Tabs>
            </ext:TabStrip>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    <ext:Window ID="WindowSearch" Title="search" Hidden="true" EnableIFrame="true" runat="server"
        CloseAction="Hide" OnClose="WindowEdit_Close" IFrameUrl="about:blank" EnableMaximize="true"
        EnableResize="true" Target="Top" IsModal="True" Width="750px" Height="450px">
    </ext:Window>
    </form>
</body>
</html>
