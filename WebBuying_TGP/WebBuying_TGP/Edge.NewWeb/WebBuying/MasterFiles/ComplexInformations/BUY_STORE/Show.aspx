<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.ComplexInformations.BUY_STORE.Show" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150">
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
            <ext:Form ID="Form3" ShowHeader="false" ShowBorder="false" runat="server" HideMode="Display"
                Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreCode" runat="server" Label="Store Code">
                            </ext:Label>
                            <ext:Label ID="StatusView" runat="server" Label="Store Status">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreName1" runat="server" Label="Store Name1">
                            </ext:Label>
                            <ext:Label ID="StoreName2" runat="server" Label="Store Name2">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreName3" runat="server" Label="Store Name3">
                            </ext:Label>
                            <ext:Label ID="StoreTypeIDView" runat="server" Label="Store Type Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="BankCode" runat="server" Label="Bank Code">
                            </ext:Label>
                            <ext:Label ID="BrandCode" runat="server" Label="Store Brand Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreCountry" runat="server" Label="Store Country">
                            </ext:Label>
                            <ext:Label ID="StoreProvince" runat="server" Label="Store Province">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ContactPosition" runat="server" Label="Contact Position">
                            </ext:Label>
                            <ext:Label ID="ContactTel" runat="server" Label="Contact Phone">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreCity" runat="server" Label="Store City">
                            </ext:Label>
                            <ext:Label ID="StoreDistrict" runat="server" Label="Store District">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreAddressDetail1" runat="server" Label="Store Address Detail 1">
                            </ext:Label>
                            <ext:Label ID="StoreAddressDetail2" runat="server" Label="Store Address Detail 2">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreAddressDetail3" runat="server" Label="Store Address Detail 3">
                            </ext:Label>
                            <ext:Label ID="StoreFullDetail1" runat="server" Label="Store Full Address 1">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreFullDetail2" runat="server" Label="Store Full Address 2">
                            </ext:Label>
                            <ext:Label ID="StoreFullDetail3" runat="server" Label="Store Full Address 3">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreTel" runat="server" Label="Store Telephone">
                            </ext:Label>
                            <ext:Label ID="StoreFax" runat="server" Label="Store Fax">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreEmail" runat="server" Label="Store Email">
                            </ext:Label>
                            <ext:Label ID="Contact" runat="server" Label="Store Contact">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ContactPhone" runat="server" Label="Store Contact Phone">
                            </ext:Label>
                            <ext:Label ID="StoreLongitude" runat="server" Label="Store Coordinates, Longitude">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreLatitude" runat="server" Label="Store Coordinates, Latitude">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow15" runat="server">
                        <Items>
                            <ext:Form ID="Form2" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow16" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath1" Hidden="true" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label1" Text="" runat="server" Label="Store Image Address">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview1" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow17" runat="server">
                        <Items>
                            <ext:Form ID="Form4" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow18" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath2" Hidden="true" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label3" Text="" runat="server" Label="Store Icon File">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview2" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow19" runat="server">
                        <Items>
                            <ext:Form ID="Form5" ShowHeader="false" ShowBorder="false" runat="server">
                                <Rows>
                                    <ext:FormRow ID="FormRow20" ColumnWidths="0% 40% 10%" runat="server">
                                        <Items>
                                            <ext:Label ID="uploadFilePath3" Hidden="true" runat="server">
                                            </ext:Label>
                                            <ext:Label ID="Label4" Text="" runat="server" Label="Shadow Image File">
                                            </ext:Label>
                                            <ext:Button ID="btnPreview3" runat="server" Text="View" Icon="Picture">
                                            </ext:Button>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow21" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="LocationCode" runat="server" Label="Area Code">
                            </ext:Label>
                            <ext:Label ID="StoreNote" runat="server" Label="Store Notes">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow22" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreOpenTime" runat="server" Label="Store Open Time">
                            </ext:Label>
                            <ext:Label ID="StoreCloseTime" runat="server" Label="Store Close Time">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow23" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ComparableView" runat="server" Label="Showcase Store">
                            </ext:Label>
                            <ext:Label ID="GLCode" runat="server" Label="GL Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow24" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="RegionCode" runat="server" Label="Region Code">
                            </ext:Label>
                            <ext:Label ID="OrgCode" runat="server" Label="Org Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow25" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreIP" runat="server" Label="Store IP Address">
                            </ext:Label>
                            <ext:Label ID="SubInvCode" runat="server" Label="Sub Stock Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:RadioButtonList ID="Status" runat="server" Label="Store Status" Hidden="true">
                <ext:RadioItem Text="Open" Value="1" />
                <ext:RadioItem Text="Close" Value="0" />
            </ext:RadioButtonList>
            <ext:DropDownList ID="StoreTypeID" runat="server" Label="Store Type" Hidden="true">
                <ext:ListItem Text="---------" Value="0" />
                <ext:ListItem Text="Retail" Value="1" />
                <ext:ListItem Text="Road show" Value="2" />
                <ext:ListItem Text=" CC" Value="3" />
                <ext:ListItem Text="CC support" Value="4" />
                <ext:ListItem Text="RAN" Value="5" />
                <ext:ListItem Text="Commercial BU" Value="6" />
                <ext:ListItem Text="Warehouse" Value="9" />
            </ext:DropDownList>
            <ext:RadioButtonList ID="Comparable" runat="server" Label="Showcase Store" Hidden="true">
                <ext:RadioItem Text="No" Value="0" />
                <ext:RadioItem Text="Yes" Value="1" />
            </ext:RadioButtonList>
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
