<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreReceive.aspx.cs" Inherits="Edge.Web.WebLinks.StoreReceive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <h2><%: Title %>
                
            </h2>
            <p class="text-danger">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </p>

            <div class="form-horizontal">
                <h2></h2>
                <hr />
                <div class="form-inline">
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtStoreOrderNumber" CssClass="col-md-3 control-label" >Store Order Number:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtStoreOrderNumber" ForeColor="Blue" Height="28px" Font-Size="Large" />
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtPickingOrderNumber" CssClass="col-md-3 control-label">Picking Order Number:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtPickingOrderNumber" ForeColor="Blue" Height="28px" Font-Size="Large" />
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtShippingOrderNumber" CssClass="col-md-3 control-label">Shipping Order Number:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtShippingOrderNumber" ForeColor="Blue" Height="28px" Font-Size="Large" />
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtReceiveOrderNumber" CssClass="col-md-3 control-label">Receive Order Number:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtReceiveOrderNumber" ForeColor="Blue" Height="28px" Font-Size="Large" />
                    </div>
                </div>
                <br />
                <br />
                <div class="form-inline">                      
                    <div class="col-md-12">                                                                    
                         <asp:GridView ID="GridView1" runat="server" CssClass="footable"  
                             AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" 
                             ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" 
                             DataKeyNames="ProdCode" 
                             OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="ProdCode" HeaderText="Product Code" />                                      
                                    <asp:BoundField DataField="ProdDesc1" HeaderText="Product Name" />      
                                    <asp:BoundField DataField="OrderQty" HeaderText="Order Quantity" />
                                    <asp:BoundField DataField="ReceiveQty" HeaderText="Receive Quantity" />
                                    <%--<asp:BoundField DataField="orderamount" HeaderText="Order Amount" DataFormatString="{0:n2}"/>    --%>                                
                                    <asp:BoundField DataField="ApproveBusDate" HeaderText="Shipment Approve Business Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="FromStoreName" HeaderText="From Store Name" />  
                                    <asp:BoundField DataField="ApproveStatus" HeaderText="Receive Approval Status" />  
                                </Columns>
                                <EmptyDataTemplate>                                    
                                    <div class="form-inline">
                    
                                        <div class="col-md-12" style="text-align: center">
                                            <asp:Label ID="lbEmpty"  runat="server" Text="No purchases found for this date range" ForeColor="#009933" Width="100%" ></asp:Label>                                        
                                        </div>
                                    </div> 
                                </EmptyDataTemplate>
                            </asp:GridView>    
       
                         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                             SelectMethod="GetReceiveOrderDetail" 
                             TypeName="Edge.Web.Controllers.Operation.StoreOrderManagement.ReceiveStoreOrder.ReceiveStoreOrderController">
                             <SelectParameters>
                                 <asp:QueryStringParameter Name="ShipmentOrderNumber" QueryStringField="id" 
                                     Type="String" />
                             </SelectParameters>
                         </asp:ObjectDataSource>
                        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
                            rel="stylesheet" type="text/css" />
                        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
                        <script type="text/javascript">
                            $(function () {
                                $('[id*=GridView1]').footable();
                            });
                    </script>
                    </div>
                    <div class="form-inline">
                    <div class="col-md-12"> 
                        <%--<asp:Button runat="server"  Text="Approve" CssClass="btn btn-primary btn-md" ID="btnApprove" OnClick="btnApprove_Click" Width="200px" />--%>
                        
                    </div>
        <%--            <div class="col-md-12"> 
                        <asp:Button runat="server"  Text="Export to CSV" CssClass="btn btn-primary btn-md" ID="btnExport" OnClick="btnExport_Click" Width="200px"/>                                                
                    </div>--%>
                    </div>
                    <div class="form-inline">
                        <ul class="pager">
                          <li><a href="../Index.aspx"><span class="glyphicon glyphicon-home"></span> Home</a></li>
                      
                        </ul>
                    </div>
                    <p></p>
                </div>  
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal1">
                <div class="center1">
                    <img alt="" src="../Images/Loading.gif"/>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
