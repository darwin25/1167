<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addrole.aspx.cs" Inherits="Edge.Web.Accounts.Admin.addrole" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>addrole</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
    <ext:Form ID="Form2" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Title="Form" AutoScroll="true" LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="Form2" Icon="SystemSaveClose" OnClick="btnSaveClose_Click"
                        runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Rows>
            <ext:FormRow ID="FormRow1" runat="server">
                <Items>
                    <ext:TextBox ID="TxtNewname" runat="server" Label="角色名" ShowRedStar="true" Required="true">
                    </ext:TextBox>
                </Items>
            </ext:FormRow>
        </Rows>
    </ext:Form>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
