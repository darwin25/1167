<%@ Page Language="c#" CodeBehind="PermissionAdmin.aspx.cs" AutoEventWireup="True"
    Inherits="Edge.Web.Accounts.Admin.PermissionAdmin" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>Index</title>
    <link rel="stylesheet" type="text/css" href='<%#GetPaginationCssPath() %>' />
    <script type="text/javascript" src='<%#GetjQueryPath() %>'></script>
    <script type="text/javascript" src='<%#GetjQueryValidatePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSMultiLanguagePath() %>'></script>
    <script type="text/javascript" src='<%#GetJSFunctionPath()%>'></script>
    <script type="text/javascript" src='<%#GetJSPaginationPath() %>'></script>
    <style type="text/css">
    .lbl{text-align:left; margin-left:105px;}
    </style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Form ID="Form2" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Title="&nbsp;" LabelAlign="Right">
        <Rows>
            <ext:FormRow ID="FormRow1" runat="server">
                <Items>
                    <ext:DropDownList ID="ClassList" runat="server" Label="选择权限类别" AutoPostBack="True"
                        OnSelectedIndexChanged="ClassList_SelectedIndexChanged">
                    </ext:DropDownList>
                    <%--<ext:Button ID="BtnDelCategory" Text="Delete" runat="server" OnClick="BtnDelCategory_Click">
                    </ext:Button>--%>
                </Items>
            </ext:FormRow>
            <ext:FormRow ID="FormRow2" runat="server">
                <Items>
                    <ext:TextBox ID="PermissionsName" runat="server" Text="" Label="增加新权限">
                    </ext:TextBox>
                    <ext:Button ID="BtnAddPermissions" runat="server" Text="Add" OnClick="BtnAddPermissions_Click">
                    </ext:Button>
                </Items>
            </ext:FormRow>
        </Rows>
    </ext:Form>
    <ext:Grid ID="Grid1" ShowHeader="false" runat="server" EnableCheckBoxSelect="True"
        DataKeyNames="PermissionID,Description" ShowBorder="false" AllowPaging="false"
        ForceFit="true" Title="该类别的权限列表" OnRowCommand="Grid1_RowCommand">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" runat="server" OnClick="btnDelete_Click">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
            <ext:TemplateField Width="60px" HeaderText="权限编码">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("PermissionID") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="权限名称">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:LinkButtonField HeaderText="&nbsp;" CommandName="edit" Text="Edit" Icon="PageEdit" />
        </Columns>
    </ext:Grid>
    <ext:Window ID="Window1" Title="Edit"  Hidden="true" EnableIFrame="false"
            EnableMaximize="true" Target="Self" EnableResize="true" runat="server"
            IsModal="true" Width="750px" Height="450px">
        <Items>
            <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
                BodyPadding="10px"  Title="SimpleForm">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <ext:Button ID="btnClose" Icon="SystemClose" runat="server"
                                Text="Close" OnClick="btnClose_Click">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </ext:ToolbarSeparator>
                            <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                                OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Label ID="lblPermId" runat="server"  CssClass="lbl">
                    </ext:Label>
                    <ext:TextBox ID="txtNewName" runat="server" Label="新权限名称" Required="true" ShowRedStar="true">
                    </ext:TextBox>
                </Items>
            </ext:SimpleForm>
        </Items>
    </ext:Window>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
