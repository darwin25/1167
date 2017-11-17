<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Edge.Web.WebBuying.MasterFiles.PromotionInfos.BUY_PRODUCTCLASS.List" %>
<%@ Register Src="~/Controls/checkright.ascx" TagName="checkright" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
         Title="" >
        <Toolbars>
            <ext:Toolbar ID="Toolbar2" runat="server">
                <Items>
                    <ext:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" Text="Add">
                    </ext:Button>
                    <ext:Button ID="btnDelete" Text="Delete" Icon="Delete" OnClick="lbtnDel_Click" runat="server">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Grid ID="Grid1" runat="server" ShowBorder="false" ShowHeader="false" Height="400px"
                EnableCheckBoxSelect="True"  DataKeyNames="ProdClassID" OnPreDataBound="Grid1_PreDataBound"
                OnRowCommand="Grid1_RowCommand"  ForceFit="true">
                <Columns>
                    <ext:BoundField DataField="Name" HeaderText=" 货品大类" DataSimulateTreeLevelField="TreeLevel"
                        Width="250px" />
                    <ext:BoundField DataField="ProductSizeType" HeaderText="尺寸类型" Width="80px" />
                    <ext:WindowField ColumnID="editField" TextAlign="Center" Icon="PageEdit"
                        WindowID="Window1" Title="Edit" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="modify.aspx?id={0}"
                        Width="50px" />
                </Columns>
            </ext:Grid>
        </Items>
    </ext:Panel>
    <ext:Window EnableClose="true" ID="Window1" runat="server" IsModal="true" Hidden="true"
        Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
        Width="650px" Height="450px" OnClose="Window1_Close">
    </ext:Window>
    <uc2:CheckRight ID="CheckRight1" runat="server"></uc2:CheckRight>
    </form>
</body>
</html>
