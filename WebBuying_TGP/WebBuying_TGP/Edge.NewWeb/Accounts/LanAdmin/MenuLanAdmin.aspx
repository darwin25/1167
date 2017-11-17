<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuLanAdmin.aspx.cs" Inherits="Edge.Web.Accounts.LanAdmin.MenuLanAdmin" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="HEAD1" runat="server">
    <title>Index</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Form ID="Form2" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Title="&nbsp;" LabelAlign="Right">
        <Rows>
            <ext:FormRow ID="FormRow1" runat="server">
                <Items>
                    <ext:DropDownList ID="ddlList" runat="server" Label="选择菜单" AutoPostBack="True" OnSelectedIndexChanged="ddlList_SelectedIndexChanged">
                    </ext:DropDownList>
                    <ext:Button ID="btnDisplayInsertLan" Text="新增语言" runat="server" OnClick="btnDisplayInsertLan_Click">
                    </ext:Button>
                </Items>
            </ext:FormRow>
        </Rows>
    </ext:Form>
    <ext:HiddenField ID="hfnodeID" runat="server">
    </ext:HiddenField>
    <ext:HiddenField ID="hfLan" runat="server">
    </ext:HiddenField>
    <ext:Form ID="UpdateForm" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Title="&nbsp;" LabelAlign="Right">
        <Rows>
            <ext:FormRow ID="FormRow2" runat="server">
                <Items>
                    <ext:TextBox ID="txtModifyLan" runat="server" Label="菜单名称">
                    </ext:TextBox>
                    <ext:Button ID="btnModifyLan" runat="server" Text="保存" OnClick="btnModifyLan_Click">
                    </ext:Button>
                    <ext:Button ID="btnModifyCancel" runat="server" Text="取消" OnClick="btnModifyCancel_Click">
                    </ext:Button>
                </Items>
            </ext:FormRow>
        </Rows>
    </ext:Form>
    <ext:Form ID="InsertForm" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Title="&nbsp;" LabelAlign="Right" LabelWidth="150">
        <Rows>
            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="40% 30% 10% 10%">
                <Items>
                    <ext:TextBox ID="txtNewLan" runat="server" Label="菜单名称">
                    </ext:TextBox>
                    <ext:DropDownList ID="ddlLanList" runat="server" Label="Language">
                    </ext:DropDownList>
                    <ext:Button ID="btnInsertLan" runat="server" Text="保存" CssClass="submit" OnClick="btnInsertLan_Click">
                    </ext:Button>
                    <ext:Button ID="btnInsertCancel" runat="server" Text="取消" CssClass="submit" OnClick="btnInsertCancel_Click">
                    </ext:Button>
                </Items>
            </ext:FormRow>
        </Rows>
    </ext:Form>
    <ext:Grid ID="Grid1" ShowHeader="false" runat="server" EnableCheckBoxSelect="True"
        DataKeyNames="NodeID,Text,Lan" ShowBorder="false" AllowPaging="false" ForceFit="true"
        Title="该菜单的语言列表" OnRowCommand="Grid1_RowCommand">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" runat="server" OnClick="btnDel_Click">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
            <ext:TemplateField Width="60px" HeaderText="菜单编码">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NodeID") %>'>
                    </asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="菜单名称">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Text") %>'>
                    </asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="Language">
                <ItemTemplate>
                    <asp:Label ID="lblLan" Visible="false" runat="server" Text='<%#Eval("Lan")%>'>
                    </asp:Label>
                    <asp:Label ID="lblLanDesc" runat="server" Text='<%#Eval("LanDesc")%>'>
                    </asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:LinkButtonField HeaderText="&nbsp;" CommandName="edit" Text="Edit" Icon="PageEdit" />
        </Columns>
    </ext:Grid>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
