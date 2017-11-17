using System;
using System.Web;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using Edge.Security.Manager;
using System.Xml;
using Edge.Common;
using Asp.Net.WebFormLib;
using Edge.SVA.Model.Domain;
using Edge.Web.Tools;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.Utils;
namespace Edge.Web 
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
        {
            AppConfig appconfig = AppConfig.Singleton;

            MessageInfoRepostory.Singleton.PathFile = Server.MapPath("~/XmlConfig/MessageTemplates.config");
            MessageInfoRepostory.Singleton.Refresh();
            ITranslater translater = Asp.Net.WebFormLib.Factory.CreateITranslater();

            translater.RegisterConfig(Server.MapPath("~/ObjectsConfig_en-us.config"), LanguageFlag.ENUS);
            translater.RegisterConfig(Server.MapPath("~/ObjectsConfig_zh-cn.config"), LanguageFlag.ZHCN);
            translater.RegisterConfig(Server.MapPath("~/ObjectsConfig_zh-hk.config"), LanguageFlag.ZHHK);

             Edge.Security.Model.WebSet webset = new Edge.Security.Manager.WebSet().loadConfig(Edge.Common.Utils.GetXmlMapPath("Configpath"));

            PermissionMapper.GetSingleton().SetWebVirtualPath(webset.WebPath);
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/XmlConfig/WebPages.config"));
            XmlNodeList xnl = doc.SelectNodes("//WebPages/PublicWebPages/Page");
            foreach (XmlNode item in xnl)
            {
                string url = item.Attributes["Url"].Value;
                if (url.Equals(string.Empty))
                {
                    continue;
                }
                string permissionID = item.Attributes["PermissionID"].Value;
                int id = -1;
                if (int.TryParse(permissionID, out id))
                {
                    PermissionMapper.GetSingleton().AddSpecialPage(url, id);
                }
                else
                {
                    PermissionMapper.GetSingleton().AddSpecialPage(url, -1);
                }
            }
            PermissionMapper.GetSingleton().Refresh();
            Edge.Messages.Manager.MessagesTool.instance.Refresh("SVA");            
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
            SVASessionInfo.UserStyle = 1;


            if ((Context.User.Identity.IsAuthenticated)&&(SVASessionInfo.SiteLanguage == null))
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.Abandon();
                Response.Clear();
                string url = null;
                if (Request.ApplicationPath == "/")
                {
                    //不存在虚拟目录
                    url = Request.ApplicationPath + "Login.aspx";
                }
                else
                {
                    //存在虚拟目录
                    url = Request.ApplicationPath + "/Login.aspx";
                }
                //Response.Write("<script defer>window.alert('" + Resources.MessageTips.Timeout + "');parent.location='" + url + "';</script>");
                FineUI.Alert.ShowInTop(Resources.MessageTips.Timeout, "", FineUI.MessageBoxIcon.Warning, "top.location='" + url + "';");
                Response.End();
            }

            //实现动态域名切换，根据不同域名访问不同页面
            //string tempStr = Request.ServerVariables["SERVER_NAME"];
            //try
            //{
            //    if (tempStr != "")
            //    {                                      
            //        if (tempStr.Trim().StartsWith("www.Edge.com"))
            //        {
            //            Response.Redirect("Index.aspx");
            //        }
            //        else
            //        {
            //            Response.Redirect("Default.aspx");
            //        }
                    
            //    }
            //}
            //catch //(System.Exception ex)
            //{
            //    //Response.Write(tempStr+":"+ex.Message);
            //}

	        

		}
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_Error(Object sender, EventArgs e)
		{
			#region


//			Exception ex=Server.GetLastError();		
////			bool LogInFile=bool.Parse(ConfigurationManager.AppSettings.Get("LogInFile"));
////			bool LogInDB=bool.Parse(ConfigurationManager.AppSettings.Get("LogInDB"));
//			string LogLastDays=ConfigurationManager.AppSettings.Get("LogLastDays");
//			string errmsg="";
//			string Particular="";
//			if(ex.InnerException!=null)
//			{
//				errmsg=ex.InnerException.Message;
//				Particular=ex.InnerException.StackTrace;					
//			}
//			else
//			{
//				errmsg=ex.Message;
//				Particular=ex.StackTrace;
//			}
////			if(LogInFile)
////			{
////				string filename=Server.MapPath("~/ErrorMessage.txt");					
////				string strTime=DateTime.Now.ToString();
////				StreamWriter sw=new StreamWriter(filename,true);
////				sw.WriteLine(strTime+"："+errmsg+Particular);
////				sw.Close();
////			}			
////			if(LogInDB)
////			{				
//				Assistant.AddLog(errmsg,Particular);
//				Assistant.DelOverdueLog(LogLastDays);
////			}
//			Server.Transfer("ErrorMsg.aspx");


			#endregion
		}
		protected void Session_End(Object sender, EventArgs e)
		{		
			
		}
		protected void Application_End(Object sender, EventArgs e)
		{
		}
			
		#region Web 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码Edit器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

