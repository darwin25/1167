<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PriceSettings.BUY_CPRICE_H.Show" %>
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
         <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="Basic Information"
                 >
            <Items>
            <ext:Form ID="Form3"   ShowHeader="false"
                ShowBorder="false" runat="server" HideMode="Display" Hidden="false">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CPriceCode" runat="server" Label="Price Code">
                            </ext:Label>
                            <ext:Label ID="StoreCodeView" runat="server" Label="Store Code">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StoreGroupCodeView" runat="server" Label="Store Group Code">
                            </ext:Label>
                            <ext:Label ID="VendorCodeView" runat="server" Label="Supplier Code"></ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="StartDate" runat="server" Label="Price Effective Date">
                            </ext:Label>
                            <ext:Label ID="EndDate" runat="server" Label="Price Expiration Date">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CurrencyCodeView" runat="server" Label="Currency Code">
                            </ext:Label>
                            <ext:Label ID="Note" runat="server" Label="Remarks">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CreatedBusDate" runat="server" Label="Created Business Date">
                            </ext:Label>
                            <ext:Label ID="ApproveBusDate" runat="server" Label="Approve Business Date">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ApprovalCode" runat="server" Label="Approval Code">
                            </ext:Label>
                            <ext:Label ID="ApproveStatus" runat="server" Label="Approve Status">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="ApproveOn" runat="server" Label="Approve On">
                            </ext:Label>
                            <ext:Label ID="ApproveBy" runat="server" Label="Approve By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="CreatedOn" runat="server" Label="Created Date Time">
                            </ext:Label>
                            <ext:Label ID="CreatedBy" runat="server" Label="Created By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>                    
                    <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="UpdatedOn" runat="server" Label="Updated On">
                            </ext:Label>
                            <ext:Label ID="UpdatedBy" runat="server" Label="Updated By">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:DropDownList ID="StoreCode" runat="server" Label="Store Code" Hidden="true">
            </ext:DropDownList>
            <ext:DropDownList ID="StoreGroupCode" runat="server" Label="Store Group Code" Hidden="true">
            </ext:DropDownList>
            <ext:DropDownList ID="CurrencyCode" runat="server" Label="Currency Code" Hidden="true"></ext:DropDownList>
        </Items>
        </ext:GroupPanel>
        <ext:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="成本价详情列表"
             >
            <Items>
                <ext:Grid ID="AddResultListGrid" ShowBorder="false" ShowHeader="false" 
                    PageSize="3" runat="server" DataKeyNames="KeyID"
                    AllowPaging="true" IsDatabasePaging="true" ForceFit="true" OnPageIndexChange="AddResultListGrid_PageIndexChange">
                    <Columns>
                        <ext:TemplateField Width="60px" HeaderText="Product Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Eval("ProdName") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Gross Cost">
                                <ItemTemplate>
                                    <asp:Label ID="lblCPriceGrossCost" runat="server" Text='<%# Eval("CPriceGrossCost") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Net Cost Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblCPriceNetCost" runat="server" Text='<%# Eval("CPriceNetCost") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Trade Discount ">
                                <ItemTemplate>
                                    <asp:Label ID="lblCPriceDisc1" runat="server" Text='<%# Eval("CPriceDisc1") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Other Discounts">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("CPriceDisc2") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Special Discount">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("CPriceDisc3") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Discount 4">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("CPriceDisc4") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Purchase Qty">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("CPriceBuy") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Purchase Over Free">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("CPriceGet") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                    </Columns>
                </ext:Grid>
            </Items>
        </ext:GroupPanel>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
