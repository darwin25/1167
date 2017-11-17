using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.SVA;
using Newtonsoft;
using System.IO;
using System.Xml.Serialization;
using System.Web;


namespace Edge.SVA.BLL.Domain.DataResources
{
    public class MessageInfoRepostory
    {
        private static readonly object syncObj = new object();
        private static readonly MessageInfoRepostory instance = new MessageInfoRepostory();
        private MessageInfoRepostory()
        {
        }
        private void LoadData()
        {
            XmlSerializer xs = new XmlSerializer(list.GetType());
            using (FileStream fs=new FileStream(pathFile,FileMode.OpenOrCreate))
            {
                list = xs.Deserialize(fs) as List<MessageTemplateInfo>;
            }
        }
        List<MessageTemplateInfo> list = new List<MessageTemplateInfo>();
        public static MessageInfoRepostory Singleton
        {
            get
            {
                return instance;
            }
        }
        private string pathFile = string.Empty;

        public string PathFile
        {
            get { return pathFile; }
            set { pathFile = value; }
        }
        public void Refresh()
        {
            LoadData();
        }

        public MessageTemplateInfo GetMessageTemplateInfo(string transactionTypeID,string messageServiceTypeID)
        {
           return this.list.Find(m => m.TransactionTypeID.Equals(transactionTypeID) && m.MessageServiceTypeID.Equals(messageServiceTypeID));
        }
    }
}
