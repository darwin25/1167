<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_DISCOUNT.Show" %>
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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="180">
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
                            <ext:Label ID="DiscountCode" runat="server" Label="Discount Code">
                            </ext:Label>
                            <ext:Label ID="ReasonCode" runat="server" Label="Reason Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Description1" runat="server" Label="Discount Description 1">
                            </ext:Label>
                            <ext:Label ID="Description2" runat="server" Label="Discount Description 2">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Description3" runat="server" Label="Discount Description 3">
                            </ext:Label>
                            <ext:Label ID="DiscTypeView" runat="server" Label="Discount Type">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="SalesDiscLevel" runat="server" Label="Discount Priority">
                            </ext:Label>
                            <ext:Label ID="DiscPrice" runat="server" Label="Discount Value">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="AuthLevelView" runat="server" Label="Permission Settings">
                            </ext:Label>
                            <ext:Label ID="AllowDiscOnDiscView" runat="server" Label="Allow Discount on Discounted Item">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="AllowChgDiscView" runat="server" Label="Allow Change of Discount Value">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="TransDiscControlView" runat="server" Label="Single Book Discount Control">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server">
                        <Items>
                            <ext:Label ID="StatusView" runat="server" Label="Status">
                            </ext:Label>
                            <ext:Label ID="Note" runat="server" Label="Remarks">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:SimpleForm>
    <ext:DropDownList ID="DiscType" runat="server" Label="Discount Type" Hidden="true">
        <ext:ListItem  Text="item $ off" Value="0"/>
        <ext:ListItem  Text="item % off" Value="1"/>
        <ext:ListItem  Text="trans $ off" Value="2"/>
        <ext:ListItem  Text="trans % off" Value="3"/>
        <ext:ListItem  Text="price markdown" Value="4"/>
    </ext:DropDownList>
    <ext:DropDownList ID="AuthLevel" runat="server" Label="Permission Settings">
        <ext:ListItem Text="No Permission" Value="0" Selected="true" />
        <ext:ListItem Text="Administrator Privileges" Value="1"/>
        <ext:ListItem Text="Manager Rights" Value="2"/>
    </ext:DropDownList>
    <ext:DropDownList ID="AllowDiscOnDisc" runat="server" Label="Allow Discount on Discounted Item">
        <ext:ListItem Text="Not Allowed" Value="0" Selected="true" />
        <ext:ListItem Text="Allowed" Value="1"/>
    </ext:DropDownList>
    <ext:DropDownList ID="AllowChgDisc" runat="server" Label="Allow Change of Discount Value">
        <ext:ListItem Text="Not Allowed" Value="0" Selected="true" />
        <ext:ListItem Text="Allowed" Value="1"/>
    </ext:DropDownList>
    <ext:DropDownList ID="TransDiscControl" runat="server" Label="Single Book Discount Control">
        <ext:ListItem Text="Not allowed for single order discounts, only single item discounts" Value="0" Selected="true" />
        <ext:ListItem Text="Allowed for single order discounts, calculated on the basis of the Netprice of each item" Value="1"/>
        <ext:ListItem Text="Allowed for the whole single discount, if the goods have been discounted, then skip this product record apportionment" Value="2"/>
    </ext:DropDownList>
    <ext:RadioButtonList ID="Status" runat="server" Label="Status" Hidden="true">
        <ext:RadioItem Text="Invalid" Value="0" />
        <ext:RadioItem Text="Valid" Value="1" />
    </ext:RadioButtonList>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
