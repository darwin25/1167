<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageVoid.aspx.cs" Inherits="Edge.Web.PublicForms.MessageVoid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MessageVoid</title>
    <style>
        .lblcenter
        {
            text-align: center;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server"/>
    <ext:Form ID="SimpleForm1" runat="server" ShowBorder="false" ShowHeader="false" Title=""
                     LabelAlign="Top" AutoScroll="false">
        <Rows>
            <ext:FormRow>
                <Items>
                    <ext:Label ID="lblMessage" runat="server" EncodeText="false" CssClass="lblcenter"></ext:Label>
                </Items>           
            </ext:FormRow>
            <ext:FormRow ColumnWidths="35% 65%">
                <Items>
                    <ext:Label runat="server" Text=""></ext:Label>
                    <ext:Button ID="btnOK" runat="server" Text="确定"  OnClick="btnOK_Click" ></ext:Button>
                </Items>
            </ext:FormRow>              
        </Rows>
    </ext:Form>
        <%--<ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server"
                         Title="" Layout="Row">
            <Items>
                <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server"
                         Title="" AutoScroll="true">
                    <Items>
                        <ext:Label ID="lblMessage" runat="server"></ext:Label>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel3" ShowBorder="false" Layout="Column" ShowHeader="false" 
                        runat="server" >
                    <Items>
                        <ext:Panel ID="Panel4" ShowBorder="false" ColumnWidth="45%" ShowHeader="false" 
                            runat="server">
                                <Items>
                                    <ext:Label runat="server" ID="label1" Text="" HideMode="Display" ></ext:Label>
                                </Items>
                            </ext:Panel>
                            <ext:Panel ID="Panel5" ShowBorder="false" ColumnWidth="55%" ShowHeader="false" 
                                runat="server">
                                <Items>
                                    <ext:Button ID="btnOK" runat="server" Text="确定"  OnClick="btnOK_Click" ></ext:Button>
                                </Items>
                            </ext:Panel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>--%>
    </form>
</body>
</html>
