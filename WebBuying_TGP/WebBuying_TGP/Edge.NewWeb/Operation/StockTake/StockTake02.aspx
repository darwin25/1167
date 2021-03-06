﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockTake02.aspx.cs" Inherits="Edge.Web.Operation.StockTake.StockTake02" %>

<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>盘点二</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="" AutoScroll="true" >
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="Close">
                    </ext:Button>
                    <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </ext:ToolbarSeparator>
                    <ext:Button ID="btnSaveClose" ValidateForms="sform1,sform2" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="库存盘点二">
                <Items>
                    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" PageSize="3" runat="server"
                        EnableCheckBoxSelect="false" DataKeyNames="ProdCode,StockType,SerialNo,QTY" AllowPaging="true"
                        IsDatabasePaging="true" ForceFit="true" AllowCellEditing="true"
                        ClicksToEdit="1" OnSort="Grid1_Sort" AllowSorting="true" SortDirection="ASC" >
                        <Columns>
                            <ext:TemplateField Width="60px" HeaderText="Product Code" SortField="ProdCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdCode" runat="server" Text='<%# Eval("ProdCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="100px" HeaderText="Product Name" SortField="ProdDesc">
                                <ItemTemplate>
                                    <asp:Label ID="lblProdDesc" runat="server" Text='<%# Eval("ProdDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="货品部门" SortField="DeptCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeptCode" runat="server" Text='<%# Eval("DeptCode") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField Width="60px" HeaderText="Stock Type Code" SortField="StockType">
                                <ItemTemplate>
                                    <asp:Label ID="lblStockType" runat="server" Text='<%# Eval("StockType") %>'></asp:Label>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:RenderField Width="60px" DataField="QTY" FieldType="Int" HeaderText="数量" SortField="QTY">
                                <Editor>
                                    <ext:TextBox ID="nmbQTY" runat="server" Regex="^[0-9]{1,}$" ></ext:TextBox>  
                                </Editor>
                            </ext:RenderField>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:GroupPanel>
        </Items>
    </ext:Panel>
    <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
