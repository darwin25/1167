<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.BasicInformations.BUY_REPLENFORMULA.Show" %>

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
        BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right" LabelWidth="375">
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
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:Label ID="ReplenFormulaCode" runat="server" Label="Automatic Replenishment Code：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <ext:Label ID="PreDefineDOC" runat="server" Label="Reserved Inventory Days：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server">
                        <Items>
                            <ext:Label ID="RunningStockDOC" runat="server" Label="Normal Stock Days：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server">
                        <Items>
                            <ext:Label ID="OrderRoundUpQty" runat="server" Label="Multiple of Order Quantity：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server">
                        <Items>
                            <ext:Label ID="AVGDailySalesPeriod" runat="server" Label="Number of days for the average number of sales：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server">
                        <Items>
                            <ext:Label ID="QuotationView" runat="server" Label="Whether the quantity statistics include the type of offer：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server">
                        <Items>
                            <ext:Label ID="DepositedView" runat="server" Label="Whether the quantity statistics include the deposit sales type：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server">
                        <Items>
                            <ext:Label ID="AdvSalesView" runat="server" Label="Whether the quantity statistics include the pre-sale sales type：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow9" runat="server">
                        <Items>
                            <ext:Label ID="Description" runat="server" Label="Description：">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
