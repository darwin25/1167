<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowProduct.aspx.cs" Inherits="Edge.Web.Operation.CouponManagement.ChangeManagement.CouponQuery.ShowProduct" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
   
   <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Grid1" />
    <ext:Grid ID="Grid1" ShowBorder="false" ShowHeader="false" AutoHeight="true" PageSize="3"
        runat="server" EnableCheckBoxSelect="false" DataKeyNames="BrandID"
        AllowPaging="true" IsDatabasePaging="true" EnableRowNumber="True" AutoWidth="true"
        ForceFitAllTime="true" OnPageIndexChange="Grid1_PageIndexChange">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Columns>
            <ext:TemplateField Width="60px" HeaderText="品牌">
                <ItemTemplate>
                    <asp:Label ID="lblBrandName" runat="server" Text='<%#Eval("BrandName")%>'></asp:Label>
                    <asp:HiddenField ID="lblBrandID" runat="server" Value='<%#Eval("BrandID")%>'></asp:HiddenField>
                </ItemTemplate>
            </ext:TemplateField>
            <ext:TemplateField Width="60px" HeaderText="产品">
                <ItemTemplate>
                    <asp:Label ID="lblDepartCode" runat="server" Text='<%#Eval("ProdCode")%>'></asp:Label>
                </ItemTemplate>
            </ext:TemplateField>
        </Columns>
    </ext:Grid>
   <%-- <div class="navigation">
        <span class="back"><a href="#"></a></span><b>您当前的位置：<%=this.PageName %></b>
    </div>
    <div style="padding-bottom: 10px;">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <td align="center">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtablelist">
                            <tr>
                                <th width="10%">
                                    品牌
                                </th>
                                <th width="10%">
                                    产品
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblBrandName" runat="server" Text='<%#Eval("BrandName")%>'></asp:Label>
                                <asp:HiddenField ID="lblBrandID" runat="server" Value='<%#Eval("BrandID")%>'></asp:HiddenField>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblDepartCode" runat="server" Text='<%#Eval("ProdCode")%>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td>
                <div style="line-height: 30px; height: 30px;">
                    <div id="Pagination" class="right flickr" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="text-align: center">
                    <input type="button" id="btnClose" class="submit" onclick="javascript:window.top.tb_remove();" value="关 闭" />
                </div>
            </td>
        </tr>
    </table>--%>
      <uc2:checkright ID="Checkright1" runat="server" />
    </form>
</body>
</html>
