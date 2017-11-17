<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.FreightSettings.Add" %>

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
        BodyPadding="10px"  Title="SimpleForm" AutoScroll="true"
        LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close" OnClientClick=" CheckAdd()">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:DropDownList ID="LogisticsProviderID" runat="server" Label="物流供应商" 
                Required="true" ShowRedStar="true">
            </ext:DropDownList>
            <ext:DropDownList ID="ProvinceCode" runat="server" Label="省编码"  Required="true"
                ShowRedStar="true">
            </ext:DropDownList>
            <ext:NumberBox ID="StartPrice" runat="server" Label="起步价格" Text="0">
            </ext:NumberBox>
            <ext:NumberBox ID="StartWeight" runat="server" Label="起步重量" Text="0">
            </ext:NumberBox>
            <ext:NumberBox ID="OverflowPricePerKG" runat="server" Label="每公斤溢出价格" Text="0">
            </ext:NumberBox>
            <ext:Label ID="lblDesc" runat="server" Text="*Is Required" CssStyle="font-size:12px;color:red">
            </ext:Label>
        </Items>
    </ext:SimpleForm>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
    <script type="text/javascript" src="/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        function CheckAdd() {
            if ($("#SimpleForm1_LogisticsProviderID").val() == "----------") {
                $("#SimpleForm1_LogisticsProviderID").css("border-color", "red");
                return false;
            }
            if ($("#SimpleForm1_ProvinceCode").val() == "----------") {
                $("#SimpleForm1_ProvinceCode").css("border-color", "red");
                return false;
            }
            return true;

        }
    </script>
</body>
</html>
