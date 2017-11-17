<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Edge.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        html, body
        {
            height: 100%;
            overflow: hidden;
        }
        .top
        {
            position: absolute;
            left: 0;
            top: 0;
            right: 0;
            height: 100px;
            background-color: #07c;
        }
        .side
        {
            position: absolute;
            left: 0;
            top: 100px;
            bottom: 32px;
            width: 160px;
            overflow: auto;
            background-color: #e1e2e3;
        }
        .splitter
        {
            position: absolute;
            left: 160px;
            top: 100px;
            bottom: 32px;
            width: 2px;
            background-color: #456;
            cursor:e-resize;
            text-align:center;
        }
        .main
        {
            position: absolute;
            left: 162px;
            top: 100px;
            bottom: 32px;
            right: 0px;
            width: auto;
            background-color: #f4f5f6;
            z-index: 2;
        }
        .bottom
        {
            position: absolute;
            left: 0;
            bottom: 0;
            right: 0;
            height: 32px;
            background-color: #456;
        }
        .main iframe
        {
            width: 100%;
            height: 100%;
        }
        /*------ for ie6 ------*/
        html
        { *padding:100px032px0;}
        .top
        { *height:100px;*margin-top:-100px;}
        .side
        { *height:100%;*float:left;*margin-right:-160px;}
         .splitter
        { *height:100%;*float:left;*margin-right:-160px;}
        .main
        { *height:100%;*margin-left:160px;}
        .bottom
        { *height:32px;}
        .top, .side, .main, .bottom
        { *position:relative;*top:0;*right:0;*bottom:0;*left:0;}</style>
     
     <script   language="javascript">
         var isResizing = false;
         function Resize_mousedown(event, obj) {
             obj.mouseDownX = event.clientX;
             obj.leftTdW = obj.previousSibling.offsetWidth;
             obj.setCapture();
             isResizing = true;
         }
         function Resize_mousemove(event, obj) {
             if (!isResizing) return;
             var newWidth = obj.leftTdW * 1 + event.clientX * 1 - obj.mouseDownX;
             if (newWidth > 0) obj.previousSibling.style.width = newWidth + 'px';
             else obj.previousSibling.style.width = 1 + 'px';
         }
         function Resize_mouseup(event, obj) {
             if (!isResizing) return;
             obj.releaseCapture();
             isResizing = false;
         }
         function Resize_setDefault(event, obj) {
             if (obj.innerText == "<") {
                 obj.parentNode.previousSibling.style.width = 1 + 'px';
                 obj.innerText = ">";
             }
             else {
                 obj.parentNode.previousSibling.style.width = 150 + 'px';
                 obj.innerText = "<";
             }
             event.cancelBubble = true;
         }   
  </script>   
</head>
<body>
    <form id="form1" runat="server">
       <div class="top">
    </div>
    <div class="side">
    	<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </div>
      <div class="splitter" nmousedown="Resize_mousedown(event,this);"   onmouseup="Resize_mouseup(event,this);"   onmousemove="Resize_mousemove(event,this);">
    	<<font   style="size:2px;background-color:#f4f5f6;cursor:pointer;"   onmousedown="Resize_setDefault(event,this);"><</font>
    </div>
    <div class="main">
    	<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </div>
    <div class="bottom">
    </form>
</body>
</html>
