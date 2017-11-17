using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using AtiveMQ.NetUtil;

namespace Edge.Web.Tools
{
    public class MessageNotifyUtil
    {
        private static readonly MessageNotifyUtil instance = new MessageNotifyUtil();
        private MessageNotifyUtil() { }
        public static MessageNotifyUtil GetSingleton()
        {
            return instance;
        }
        public void UpdateStatusP(string noticeNumber)
        {
            string sql = "update MemberNotice set ApproveStatus='P' where NoticeNumber='" + noticeNumber + "'";
            try
            {
                DBUtility.DbHelperSQL.ExecuteSql(sql);
            }
            catch (System.Exception ex)
            {
                Tools.Logger.Instance.WriteErrorLog(" UpdateStatusP NoticeNumber=", noticeNumber, ex);
            }
            SendNotifyFlag();
        }
        public void SendNotifyFlag()
        {
            Thread t = new Thread(new ThreadStart(SendMessage));
            t.Start();
        }
        
        private void SendMessage()
        {
            try
            {
                string server = System.Configuration.ConfigurationManager.AppSettings["MessageServer"].ToString();
                IAtiveMQProductor productor = Factory.CreateIAtiveMQProductor(server, string.Empty, string.Empty, "mc.refreshmessage");
                productor.SendMessage("UpdateFlag");
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}