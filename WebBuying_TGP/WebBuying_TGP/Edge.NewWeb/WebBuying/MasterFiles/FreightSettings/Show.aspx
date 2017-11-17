<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.FreightSettings.Show" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
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
                    <ext:FormRow ID="FormRow11" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="LogisticsProviderID" runat="server" Label="物流供应商">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow12" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="ProvinceCode" runat="server" Label="省编码">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow13" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="StartPrice" runat="server" Label="起步价" EncodeText="false">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow14" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="StartWeight" runat="server" Label="起步重量" EncodeText="false">
                            </ext:Label>
                        </Items>
                    </ext:FormRow> 
                     <ext:FormRow ID="FormRow15" runat="server" ColumnWidths="100%">
                        <Items>
                            <ext:Label ID="OverflowPricePerKG" runat="server" Label="每公斤溢出价格" EncodeText="false">
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

