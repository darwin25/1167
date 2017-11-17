<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewrole.aspx.cs" Inherits="Edge.Web.Accounts.Admin.viewrole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>show</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
    <ext:Form ID="Form2" runat="server" BodyPadding="10px" 
        ShowBorder="false" ShowHeader="false" Title="Form" AutoScroll="true" LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Rows>
            <ext:FormRow ID="FormRow1" runat="server">
                <Items>
                    <ext:Label ID="TxtNewname" runat="server" Label="角色名">
                    </ext:Label>
                </Items>
            </ext:FormRow>
            <ext:FormRow ID="FormRow5" runat="server">
                <Items>
                   <%-- <ext:CheckBoxList ID="ckblBrand" runat="server" ColumnNumber="3" ColumnVertical="false" Enabled="false" Label="品牌权限">
                    </ext:CheckBoxList>--%>
                </Items>
            </ext:FormRow>
        </Rows>
    </ext:Form>
    </form>
</body>
</html>
