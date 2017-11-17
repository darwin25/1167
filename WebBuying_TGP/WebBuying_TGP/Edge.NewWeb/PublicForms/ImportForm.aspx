<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportForm.aspx.cs" Inherits="Edge.Web.PublicForms.ImportForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ImportForm</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <ext:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="0">
        <Items>
            <ext:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server"
                BodyPadding="10px" Title="SimpleForm" AutoScroll="true" LabelAlign="Right">
                <Toolbars>
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
                            <ext:Button ID="btnSaveClose2" ValidateForms="SimpleForm1" Icon="SystemSaveClose"
                                OnClick="btnSaveClose_Click" runat="server" Text="Save & Close">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Label runat="server">
                    </ext:Label>
                    <ext:FileUpload runat="server" ID="ImportFile" Label="Import File">
                    </ext:FileUpload>
                </Items>
            </ext:SimpleForm>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
