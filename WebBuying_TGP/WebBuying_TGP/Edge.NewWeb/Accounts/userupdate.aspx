<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>

<%@ Page Language="c#" CodeBehind="userupdate.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.Accounts.userupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>userupdate</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="20px" Title="SimpleForm" LabelAlign="Right" AutoScroll="true">
        <toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </toolbars>
        <items>
            <ext:SimpleForm ID="sform1" runat="server" ShowBorder="false" ShowHeader="false"
                Title="" LabelAlign="Right">
                <Items>
                    <ext:HiddenField ID="userid" runat="Server">
                    </ext:HiddenField>
                    <ext:Button ID="EmployeeButton" Text="Show Employee List" Icon="Find" runat="server" OnClick="EmployeeButton_Click">
                    </ext:Button>
                    <ext:TextBox ID="txtUserName" runat="server" Label="用户名" Enabled="false">
                    </ext:TextBox>
                    <ext:TextBox ID="txtPassword" runat="server" Label="密码" TextMode="Password">
                    </ext:TextBox>
                    <ext:TextBox ID="txtTrueName" runat="server" Label="真实姓名">
                    </ext:TextBox>
                    <ext:TextBox ID="Description" runat="server" Label="Description">
                    </ext:TextBox>
                    <ext:RadioButtonList ID="rdblSex" runat="server" Label="性别">
                        <ext:RadioItem Text="男" Value="1" Selected="true" />
                        <ext:RadioItem Text="女" Value="0" />
                    </ext:RadioButtonList>
                    <ext:TextBox ID="txtPhone" runat="server" Label="Contact Phone">
                    </ext:TextBox>
                    <ext:TextBox ID="txtEmail" runat="server" Label="Email">
                    </ext:TextBox>
                    <ext:CheckBoxList ID="chblRoles" runat="server" Label="角色分配" ColumnNumber="3">
                    </ext:CheckBoxList>
                    <ext:RadioButtonList ID="Style" runat="server" Label="用户类别"  AutoPostBack="true"
                        OnSelectedIndexChanged="Style_SelectedIndexChanged">
                        <ext:RadioItem Text="品牌用户" Value="1" Selected="true" />
                        <ext:RadioItem Text="店铺用户" Value="0" />
                    </ext:RadioButtonList>
                    <ext:Form ID="FormBrand" ShowBorder="false" ShowHeader="false" Title="" runat="server"
                        BodyPadding="10px">
                        <Rows>
                            <ext:FormRow ID="FormRow1" ColumnWidths="20% 80%" runat="server">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Label="品牌树形" Hidden="true" HideMode="Visibility">
                                    </ext:Label>
                                    <ext:Tree runat="server" ID="BrandTree"  OnNodeCheck="BindTree_NodeCheck" Title="品牌列表">
                                        <Toolbars>
                                            <ext:Toolbar ID="Toolbar2" runat="server">
                                                <Items>
                                                    <ext:CheckBox ID="CheakAllBrands" Text="全选" AutoPostBack="true" runat="server" OnCheckedChanged="CheakAllBrands_CheckedChanged">
                                                    </ext:CheckBox>
                                                </Items>
                                            </ext:Toolbar>
                                        </Toolbars>
                                    </ext:Tree>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:Form ID="FormBrandStore" ShowBorder="false" ShowHeader="false" Title="店铺树形" runat="server"
                        BodyPadding="10px" Hidden="true">
                        <Rows>
                            <ext:FormRow ID="FormRow2" ColumnWidths="20% 80%" runat="server">
                                <Items>
                                    <ext:Label ID="Label2" runat="server" Label="" Hidden="true" HideMode="Visibility">
                                    </ext:Label>
                                   <ext:Tree runat="server" ID="MyTree" OnNodeCheck="StoreTree_NodeCheck" Title="品牌-店铺列表">
                                        <Toolbars>
                                            <ext:Toolbar ID="Toolbar3" runat="server">
                                                <Items>
                                                    <ext:CheckBox ID="CheckAll" Text="全选" AutoPostBack="true" runat="server" OnCheckedChanged="CheckAll_CheckedChanged">
                                                    </ext:CheckBox>
                                                </Items>
                                            </ext:Toolbar>
                                        </Toolbars>
                                    </ext:Tree>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:Form ID="FormSubUser" ShowBorder="false" ShowHeader="false" Title="" runat="server"
                        BodyPadding="10px" Hidden="true">
                        <Rows>
                            <ext:FormRow ID="FormRowSubUser" ColumnWidths="20% 80%" runat="server">
                                <Items>
                                    <ext:Label ID="Label3" runat="server" Label="下属列表" Hidden="true" HideMode="Visibility">
                                    </ext:Label>
                                    <ext:Tree runat="server" ID="SubUserTree" Title="下属列表">
                                        <Toolbars>
                                            <ext:Toolbar ID="Toolbar4" runat="server">
                                                <Items>
                                                    <ext:CheckBox ID="CheckAllSubUser" Text="全选" AutoPostBack="true" runat="server" OnCheckedChanged="CheckAllEmployee_CheckedChanged">
                                                    </ext:CheckBox>
                                                </Items>
                                            </ext:Toolbar>
                                        </Toolbars>
                                    </ext:Tree>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:SimpleForm>
        </items>
    </ext:SimpleForm>
    <uc1:CheckRight ID="CheckRight1" runat="server">
    </uc1:CheckRight>
    </form>
</body>
</html>
