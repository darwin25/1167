<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_VENDOR.Show" %>
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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="150" >
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
                            <ext:Label ID="VendorCode" runat="server" Label="Supplier Code">
                            </ext:Label>
                            <ext:Label ID="VendorName1" runat="server" Label="Supplier Name 1">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="VendorName2" runat="server" Label="Supplier Name 2">
                            </ext:Label>
                            <ext:Label ID="VendorName3" runat="server" Label="Supplier Name 3">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="VendorAddress1" runat="server" Label="Supplier Address 1">
                            </ext:Label>
                            <ext:Label ID="VendorAddress2" runat="server" Label="Supplier Address 2">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="VendorAddress3" runat="server" Label="Supplier Address 3">
                            </ext:Label>
                            <ext:Label ID="VendorNote" runat="server" Label="Supplier Notes">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="PreferFlagView" runat="server" Label="Accredited Supplier">
                            </ext:Label>
                            <ext:Label ID="Contact" runat="server" Label="Contact">
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
                            <ext:Label ID="ContactFax" runat="server" Label="Contact Fax">
                            </ext:Label>
                            <ext:Label ID="ContactMobile" runat="server" Label="Contact Mobile">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ContactEmail" runat="server" Label="Contact E-mail">
                            </ext:Label>
                            <ext:Label ID="Terms" runat="server" Label="Terms">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Limit" runat="server" Label="Credit Limit">
                            </ext:Label>
                            <ext:Label ID="Shipment" runat="server" Label="Freight">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="PayTerm" runat="server" Label="Payment Terms">
                            </ext:Label>
                            <ext:Label ID="AccountCode" runat="server" Label="Account Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="OverseaView" runat="server" Label="Overseas Supplier">
                            </ext:Label>
                            <ext:Label ID="InTax" runat="server" Label="Tax Rate (Supplied by Supplier)">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow12" runat="server">
                        <Items>
                            <ext:Label ID="NonOrderView" runat="server" Label="Whether to see the order supplier">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:RadioButtonList ID="PreferFlag" runat="server" Label="Accredited Supplier" Hidden="true">
                <ext:RadioItem Text="Yes" Value="1"/>
                <ext:RadioItem Text="No" Value="0"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="Oversea" runat="server" Label="Overseas Supplier" Hidden="true">
                <ext:RadioItem Text="Yes" Value="1"/>
                <ext:RadioItem Text="No" Value="0"/>
            </ext:RadioButtonList>
            <ext:RadioButtonList ID="NonOrder" runat="server" Label="Whether to see the order supplier" Hidden="true">
                <ext:RadioItem Text="Yes" Value="1"/>
                <ext:RadioItem Text="No" Value="0"/>
            </ext:RadioButtonList>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
