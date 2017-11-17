<%@ Page Language="c#" CodeBehind="treelist.aspx.cs" AutoEventWireup="True" Inherits="Edge.Web.SysManage.treelist" %>

<%@ Register TagPrefix="uc1" TagName="CheckRight" Src="~/Controls/CheckRight.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>Index</title>
    <link rel="stylesheet" type="text/css" href='<%#GetPaginationCssPath() %>' />

    <script type="text/javascript" src='<%#GetjQueryPath() %>'></script>

    <script type="text/javascript" src='<%#GetJSFunctionPath()%>'></script>

    <script type="text/javascript" src='<%#GetJSPaginationPath() %>'></script>

</head>
<body style="padding: 10px;">
    <form id="Form1" method="post" runat="server">

    <script type="text/javascript">
       $(function() {
            //分页参数设置
            $("#Pagination").pagination(<%=pcount %>, {
            callback: pageselectCallback,
            prev_text: "« ",
            next_text: " »",
            items_per_page:<%=pagesize %>,
		    num_display_entries:3,
		    current_page:<%=page %>,
		    num_edge_entries:2,
		    link_to:"?page=__id__"
           });
        });
        function pageselectCallback(page_id, jq) {
           //alert(page_id); 回调函数，进一步使用请参阅说明文档
        }
        
        $(function() {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function() {
			        $(this).addClass("tr_hover_col");
			    },
			    function() {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        });
    </script>

    <div class="navigation">
        <b>您当前的位置：菜单管理</b></div>
    <div class="spClear">
    </div>
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                <tr>
                    <th width="6%">
                        <input type="checkbox" onclick="checkAll(this);" />选择
                    </th>
                    <th width="6%">
                        编号
                    </th>
                    <th width="6%">
                        同类排序
                    </th>
                    <th width="10%">
                        名称
                    </th>
                    <th width="13%">
                        描述
                    </th>
                    <th width="16%">
                        链接
                    </th>
                    <th width="10%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                </td>
                <td align="center">
                    <asp:Label ID="lb_id" runat="server" Text='<%#Eval("NodeID")%>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblOrderID" runat="server" Text='<%#Eval("OrderID")%>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblText" runat="server" Text='<%#Eval("Text")%>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblcomment" runat="server" Text='<%#Eval("comment")%>'></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lblUrl" runat="server" Text='<%#Eval("Url")%>'></asp:Label>
                </td>
                <td align="center">
                    <span class="btn_bg"><a href="modify.aspx?id=<%#Eval("NodeID") %>">修改</a></span>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="spClear">
    </div>
    <div style="line-height: 30px; height: 30px;">
        <div id="Pagination" class="right flickr">
        </div>
        <div class="left">
            <span class="btn_bg">
                <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm( 'Are you sure? ');"
                    OnClick="lbtnDel_Click">删除</asp:LinkButton>
                <asp:LinkButton ID="lbtnAdd" runat="server" OnClick="lbtnAdd_Click">添加</asp:LinkButton>
            </span>
        </div>
    </div>
    <uc1:CheckRight ID="CheckRight1" runat="server" PermissionID="6"></uc1:CheckRight>
    </form>
</body>
</html>
