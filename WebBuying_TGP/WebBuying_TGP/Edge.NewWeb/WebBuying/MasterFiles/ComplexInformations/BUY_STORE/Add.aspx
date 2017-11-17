<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_STORE.Add" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
            <ext:TextBox ID="StoreCode" runat="server" Label="Store Code" Required="true" ShowRedStar="true"
                OnTextChanged="ConvertTextboxToUpperText" AutoPostBack="true" />
            <ext:RadioButtonList ID="Status" runat="server" Label="Store Status">
                <ext:RadioItem Text="Close" Value="0" />
                <ext:RadioItem Text="Open" Value="1" Selected="true" />
            </ext:RadioButtonList>
            <ext:TextBox ID="StoreName1" runat="server" Label="Store Name1" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="StoreName2" runat="server" Label="Store Name2" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:TextBox ID="StoreName3" runat="server" Label="Store Name3" OnTextChanged="ConvertTextboxToUpperText"
                AutoPostBack="true" />
            <ext:DropDownList ID="StoreTypeID" runat="server" Label="Store Type">
                <ext:ListItem Text="---------" Value="0" />
                <ext:ListItem Text="Retail" Value="1" />
                <ext:ListItem Text="Road show" Value="2" />
                <ext:ListItem Text=" CC" Value="3" />
                <ext:ListItem Text="CC support" Value="4" />
                <ext:ListItem Text="RAN" Value="5" />
                <ext:ListItem Text="Commercial BU" Value="6" />
                <ext:ListItem Text="Warehouse" Value="9" />
            </ext:DropDownList>
            <ext:TextBox ID="BankCode" runat="server" Label="Bank Code" />
            <ext:DropDownList runat="server" ID="StoreBrandCode" Label="Store Brand Code"></ext:DropDownList>
            <ext:TextBox ID="StoreCountry" runat="server" Label="Store Country" />
            <ext:TextBox ID="StoreProvince" runat="server" Label="Store Province" />
            <ext:TextBox ID="StoreCity" runat="server" Label="Store City" />
            <ext:TextBox ID="StoreDistrict" runat="server" Label="Store District" />
            <ext:TextBox ID="StoreAddressDetail1" runat="server" Label="Store Address Detail 1" />
            <ext:TextBox ID="StoreAddressDetail2" runat="server" Label="Store Address Detail 2" />
            <ext:TextBox ID="StoreAddressDetail3" runat="server" Label="Store Address Detail 3" />
            <ext:TextBox ID="StoreFullDetail1" runat="server" Label="Store Full Address 1" />
            <ext:TextBox ID="StoreFullDetail2" runat="server" Label="Store Full Address 2" />
            <ext:TextBox ID="StoreFullDetail3" runat="server" Label="Store Full Address 3" />
            <ext:TextBox ID="StoreTel" runat="server" Label="Store Telephone" />
            <ext:TextBox ID="StoreFax" runat="server" Label="Store Fax" />
            <ext:TextBox ID="StoreEmail" runat="server" Label="Store Email" />
            <ext:TextBox ID="Contact" runat="server" Label="Store Contact" />
            <ext:TextBox ID="ContactPhone" runat="server" Label="Store Contact Phone" />
            <ext:TextBox ID="StoreLongitude" runat="server" Label="Store Coordinates, Longitude" />
            <ext:TextBox ID="StoreLatitude" runat="server" Label="Store Coordinates, Latitude" />
            <ext:Form ID="Form2" ShowHeader="false" ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow1" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:FileUpload ID="StorePicFile" runat="server" Label="Store Image Address">
                            </ext:FileUpload>
                            <ext:HiddenField ID="uploadFilePath" runat="server">
                            </ext:HiddenField>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow2" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:FileUpload ID="MapsPicFile" runat="server" Label="Store Icon File">
                            </ext:FileUpload>
                            <ext:HiddenField ID="uploadFilePath1" runat="server">
                            </ext:HiddenField>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form ID="Form4" ShowHeader="false" ShowBorder="false" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow3" ColumnWidths="85% 15%" runat="server">
                        <Items>
                            <ext:FileUpload ID="MapsPicShadowFile" runat="server" Label="Shadow Image File">
                            </ext:FileUpload>
                            <ext:HiddenField ID="uploadFilePath2" runat="server">
                            </ext:HiddenField>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TextBox ID="LocationCode" runat="server" Label="Area Code">
            </ext:TextBox>
            <ext:TextBox ID="StoreNote" runat="server" Label="Store Notes">
            </ext:TextBox>
            <ext:TextBox ID="StoreOpenTime" runat="server" Label="Store Open Time">
            </ext:TextBox>
            <ext:TextBox ID="StoreCloseTime" runat="server" Label="Store Close Time">
            </ext:TextBox>
            <ext:RadioButtonList ID="Comparable" runat="server" Label="Showcase Store">
                <ext:RadioItem Text="No" Value="0" Selected="true" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
            <ext:TextBox ID="GLCode" runat="server" Label="GL Code">
            </ext:TextBox>
            <ext:TextBox ID="RegionCode" runat="server" Label="Region Code">
            </ext:TextBox>
            <ext:TextBox ID="OrgCode" runat="server" Label="Org Code">
            </ext:TextBox>
            <ext:TextBox ID="StoreIP" runat="server" Label="Store IP Address">
            </ext:TextBox>
            <ext:TextBox ID="SubInvCode" runat="server" Label="Sub Stock Code">
            </ext:TextBox>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
