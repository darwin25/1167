using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Utils
{
    public class Dialog
    {
        /// <summary>
        /// Tips提示
        /// </summary>
        /// <param name="pageCurrent">当前页面对象</param>
        /// <param name="msg">弹出消息内容</param>
        /// <param name="time">关闭时间</param>
        /// <param name="url">跳转页面为空表示不跳转</param>
        public static void Tips(System.Web.UI.Page pageCurrent, string msg, double time, string url)
        {
            StringBuilder strbox = new StringBuilder();
            strbox.Append("$(function(){ lhgdialog.tips(\"" + msg + "\",\"" + time + "\",\"i.png\");");
            string u = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                u = "setTimeout(\"window.location.href=\'" + url + "'\", " + time * 1000 + ");";
            }
            strbox.Append("" + u + "});");
            pageCurrent.ClientScript.RegisterClientScriptBlock(pageCurrent.GetType(), "lhgdialog.tips", strbox.ToString(), true);
        }

        /// <summary>
        /// 弹出提示
        /// </summary>
        /// <param name="pageCurrent">当前页面对象</param>
        /// <param name="msg">弹出消息内容</param>
        /// <param name="url">跳转页面为空表示不跳转"back"表示返回</param>
        public static void Alert(System.Web.UI.Page pageCurrent, string msg, string url)
        {
            StringBuilder strbox = new StringBuilder();
            string u = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                if (url == "back")
                {
                    u = "function(){setTimeout(function(){history.back(-1);},1);}";
                }
                else
                {
                    u = "function(){setTimeout(function(){window.location.href='" + url + "';},1);}";
                }
                strbox.Append("$(function(){ lhgdialog.alertjump(\"" + msg + "\"," + u + ",\"\",\"Infomation\"); });");
            }
            else
            {
                strbox.Append("$(function(){ lhgdialog.alert(\"" + msg + "\",\"\",\"Infomation\");}); ");
            }
            pageCurrent.ClientScript.RegisterClientScriptBlock(pageCurrent.GetType(), "lhgdialog.alert", strbox.ToString(), true);
        }
        /// <summary>
        /// Confirm弹出提示框
        /// </summary>
        /// <param name="pageCurrent">当前页面对象</param>
        /// <param name="msg">弹出消息内容</param>
        /// <param name="Determine">确定内容lhgdialog.tips("你点击了确定按钮。");</param>
        /// <param name="Cancel">取消内容lhgdialog.tips("你点击了关闭");</param>
        /// <param name="url">跳转页面为空表示不跳转"back"表示返回</param>
        public static void Confirm(System.Web.UI.Page pageCurrent, string msg, string Determine, string Cancel, string url)
        {
            StringBuilder strbox = new StringBuilder();
            strbox.Append("$(function(){ lhgdialog.confirm(\"" + msg + "\",");
            string u = string.Empty;
            strbox.Append("function(){" + Determine + "");
            if (!string.IsNullOrEmpty(url))
            {
                if (url == "back")
                {
                    u = "setTimeout(function(){history.back(-1);},2000);";
                }
                else
                {
                    u = "setTimeout(function(){window.location.href='" + url + "';},2000);";
                }
            }
            strbox.Append("" + u + "},");
            strbox.Append("function(){" + Cancel + "})");
            strbox.Append("});");
            pageCurrent.ClientScript.RegisterClientScriptBlock(pageCurrent.GetType(), "lhgdialog.confirm", strbox.ToString(), true);
        }
        /// <summary>
        /// 弹出框
        /// </summary>
        /// <param name="pageCurrent">当前页面对象</param>
        /// <param name="id">窗口ID</param>
        /// <param name="title">窗口标题</param>
        /// <param name="msg">弹出消息内容</param>
        /// <param name="icon">弹出框图标类型：warning警告消息，msg新消息，ok这是一个正确消息，rss订阅信息，lock锁定</param>
        public static void DialogBox(System.Web.UI.Page pageCurrent, string id, string title, string msg, string icon, string url)
        {
            StringBuilder strbox = new StringBuilder();
            strbox.Append("$(function(){ $.dialog({");
            strbox.Append("id:\"" + id + "\",");
            strbox.Append("title:\"" + title + "\",");
            strbox.Append("content:\"" + msg + "\",");
            strbox.Append("icon:\"" + icon + ".png\"");
            string u = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                if (url == "back")
                {
                    u = ",close:function(){{history.back(-1);};";
                }
                else
                {
                    u = ",close:function(){window.location.href='" + url + "';}";
                }
            }
            strbox.Append("" + u + "}); });");
            pageCurrent.ClientScript.RegisterClientScriptBlock(pageCurrent.GetType(), "$.dialog", strbox.ToString(), true);
        }
    }
}
