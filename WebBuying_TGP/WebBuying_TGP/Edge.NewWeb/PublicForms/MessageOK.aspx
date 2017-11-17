<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageOK.aspx.cs" Inherits="Edge.Web.PublicForms.MessageOK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MessageOK</title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server"/>
        <ext:Panel ID="Panel1" ShowBorder="false" ShowHeader="false" runat="server"
                         Title="">
            <Items>
                <ext:Panel ID="Panel2" ShowBorder="false" ShowHeader="false" runat="server"
                         Title="" AutoScroll="true" BodyPadding="10px" Height="250px">
                    <Items>
                        <ext:Label ID="label" runat="server" EncodeText="false"></ext:Label>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel6" ShowBorder="false" ShowHeader="false" runat="server"
                         Title=""  BodyPadding="10px" Height="20px">
                    <Items>
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
                                    <ext:Button ID="btnOK" runat="server" Text="确定"  OnClick="btnOK_Click"  Icon="Application"></ext:Button>
                                </Items>
                            </ext:Panel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>
    </form>
</body>
</html>
