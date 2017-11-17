<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFileBox.ascx.cs" Inherits="Edge.Web.Controls.UploadFileBox" %>
<div>
<asp:TextBox ID="UploadText" runat="server" CssClass="input w380 left" MaxLength="512" Enabled="false"></asp:TextBox>
<asp:HiddenField ID="UploadValue" runat="server" />

<a class="pictures" style="margin-left:2px;margin-right:2px" href="javascript:void(0);" id="fileUpload" runat="server"  enableviewstate="false" title="Upload">
    <asp:FileUpload ID="Files" runat="server" />
</a>
<a id="preview" runat="server" enableviewstate="false" class="thickbox preview" href="~/TempImage.aspx?Url=&height=500&amp;width=800&amp;TB_iframe=True&amp;keepThis=False"
onclick="checkUrl(this);" title="Preview"></a>
<a id="delete" runat="server" enableviewstate="false" class="delete" style="cursor:pointer;margin-left:2px;" title="Delete"></a>
</div>
