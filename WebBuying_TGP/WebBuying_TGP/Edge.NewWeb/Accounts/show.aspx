<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Edge.Web.Accounts.show" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
        BodyPadding="20px"  Title="SimpleForm" LabelAlign="Right" AutoScroll="true">
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
            <ext:SimpleForm ID="sform1" runat="server" ShowBorder="false" ShowHeader="false"
                Title=""  LabelAlign="Right">
                <Items>
                    <ext:Label ID="lblName" runat="server" Label="用户名">
                    </ext:Label>
                    <ext:Label ID="lblTrueName" runat="server" Label="真实姓名">
                    </ext:Label>                    
                    <ext:Label ID="Description" runat="server" Label="Description">
                    </ext:Label>
                    <ext:RadioButtonList ID="rdblSex" runat="server" Enabled="false" Label="性别">
                        <ext:RadioItem Text="男" Value="1" />
                        <ext:RadioItem Text="女" Value="0" />
                    </ext:RadioButtonList>
                    <ext:Label ID="lblPhone" runat="server" Label="Contact Phone">
                    </ext:Label>
                    <ext:Label ID="lblEmail" runat="server" Label="Email">
                    </ext:Label>
                    <ext:CheckBoxList ID="chblRoles" runat="server" Label="角色分配" Enabled="false" ColumnNumber="3">
                    </ext:CheckBoxList>
                    <ext:RadioButtonList ID="Style" runat="server" Label="用户类别"  Enabled="false">
                        <ext:RadioItem Text="品牌用户" Value="1" Selected="true" />
                        <ext:RadioItem Text="店铺用户" Value="0" />
                    </ext:RadioButtonList>
                    <ext:Form ID="FormBrand" ShowBorder="false" ShowHeader="false" Title="" 
                        runat="server" BodyPadding="10px">
                        <Rows>
                            <ext:FormRow ID="FormRow1" ColumnWidths="20% 80%" runat="server">
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Label="" Hidden="true" HideMode="Visibility">
                                    </ext:Label>
                                    <ext:Tree runat="server" ID="BrandTree" Title="品牌列表">
                                    </ext:Tree>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:Form ID="FormBrandStore" ShowBorder="false" ShowHeader="false" Title="" 
                        runat="server" BodyPadding="10px">
                        <Rows>
                            <ext:FormRow ID="FormRow2" ColumnWidths="20% 80%" runat="server">
                                <Items>
                                    <ext:Label ID="Label2" runat="server" Label="" Hidden="true" HideMode="Visibility">
                                    </ext:Label>
                                    <ext:Tree runat="server" ID="StoreTree" Title="品牌-店铺列表">
                                    </ext:Tree>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:SimpleForm>
        </Items>
    </ext:SimpleForm>
    <uc1:CheckRight ID="CheckRight1" runat="server"></uc1:CheckRight>
    </form>
</body>
</html>
