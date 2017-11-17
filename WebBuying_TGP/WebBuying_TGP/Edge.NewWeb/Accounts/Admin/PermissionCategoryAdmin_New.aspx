<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionCategoryAdmin_New.aspx.cs" Inherits="Edge.Web.Accounts.Admin.PermissionCategoryAdmin_New" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add</title>
</head>
<body>
    <form id="form1" runat="server">
      <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="10px"  Title="SimpleForm" LabelAlign="Right">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:TextBox ID="txtName" runat="server" Label="名称" Required="true" ShowRedStar="true">
            </ext:TextBox>
            <ext:DropDownList ID="ddlParent" Label="上级菜单" Required="true" ShowRedStar="true"
                runat="server" >
            </ext:DropDownList>
            <ext:NumberBox ID="txtOrderID" Label="排序" Required="true" ShowRedStar="true" runat="server">
            </ext:NumberBox>
        </Items>
    </ext:SimpleForm>
    </form>
</body>
</html>
