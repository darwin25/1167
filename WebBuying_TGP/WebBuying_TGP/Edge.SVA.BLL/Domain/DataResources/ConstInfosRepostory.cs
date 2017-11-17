using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain;

namespace Edge.SVA.BLL.Domain.DataResources
{
    public class ConstInfosRepostory
    {
        public enum InfoType
        {
            MessageServiceType,
            ValidType
        }
        private static readonly object syncObj = new object();
        private static readonly ConstInfosRepostory instance = new ConstInfosRepostory();
        public static ConstInfosRepostory Singleton
        {
            get
            {
                return instance;
            }
        }
        private Dictionary<InfoType, List<KeyValue>> dic_enus = new Dictionary<InfoType, List<KeyValue>>();
        private Dictionary<InfoType, List<KeyValue>> dic_zhcn = new Dictionary<InfoType, List<KeyValue>>();
        private Dictionary<InfoType, List<KeyValue>> dic_zhhk = new Dictionary<InfoType, List<KeyValue>>();

        #region TransactionTypeList
        private void LoadTransactionType()
        {
            List<KeyValue> enus = new List<KeyValue>();
            List<KeyValue> zhcn = new List<KeyValue>();
            List<KeyValue> zhhk = new List<KeyValue>();

            enus.Add(new KeyValue("0", "Notification"));
            enus.Add(new KeyValue("1", "Email"));
            enus.Add(new KeyValue("2", "SMS"));
            enus.Add(new KeyValue("3", "MMS"));
            enus.Add(new KeyValue("4", "MSN"));
            enus.Add(new KeyValue("5", "QQ"));
            enus.Add(new KeyValue("6", "Whatsapp"));
            enus.Add(new KeyValue("7", "FACEBOOK"));
            enus.Add(new KeyValue("8", "SINAWEIBO"));
            zhcn.Add(new KeyValue("0", "内部消息"));
            zhcn.Add(new KeyValue("1", "邮件"));
            zhcn.Add(new KeyValue("2", "短信"));
            zhcn.Add(new KeyValue("3", "彩信"));
            zhcn.Add(new KeyValue("4", "MSN"));
            zhcn.Add(new KeyValue("5", "QQ"));
            zhcn.Add(new KeyValue("6", "Whatsapp"));
            zhcn.Add(new KeyValue("7", "FACEBOOK"));
            zhcn.Add(new KeyValue("8", "新浪微博"));
            zhhk.Add(new KeyValue("0", "內部消息"));
            zhhk.Add(new KeyValue("1", "郵件"));
            zhhk.Add(new KeyValue("2", "短信"));
            zhhk.Add(new KeyValue("3", "彩信"));
            zhhk.Add(new KeyValue("4", "MSN"));
            zhhk.Add(new KeyValue("5", "QQ"));
            zhhk.Add(new KeyValue("6", "Whatsapp"));
            zhhk.Add(new KeyValue("7", "FACEBOOK"));
            zhhk.Add(new KeyValue("8", "新浪微博"));

            dic_enus.Add(InfoType.MessageServiceType, enus);
            dic_zhcn.Add(InfoType.MessageServiceType, zhcn);
            dic_zhhk.Add(InfoType.MessageServiceType, zhhk);
        }   

        #endregion

        #region ValidDesc        
        private void LoadValidDesc()
        {
            List<KeyValue> enus = new List<KeyValue>();
            List<KeyValue> zhcn = new List<KeyValue>();
            List<KeyValue> zhhk = new List<KeyValue>();

            enus.Add(new KeyValue("0", "Close"));
            enus.Add(new KeyValue("1", "Open"));
            zhcn.Add(new KeyValue("0", "启动"));
            zhcn.Add(new KeyValue("1", "关闭"));
            zhhk.Add(new KeyValue("0", "啟動"));
            zhhk.Add(new KeyValue("1", "關閉"));

            dic_enus.Add(InfoType.ValidType, enus);
            dic_zhcn.Add(InfoType.ValidType, zhcn);
            dic_zhhk.Add(InfoType.ValidType, zhhk);
        }
        #endregion

        private ConstInfosRepostory()
        {
            LoadTransactionType();
            LoadValidDesc();
        }

        #region Public Methonds
        public List<KeyValue> GetKeyValueList(string lan, InfoType type)
        {
            switch (lan)
            {
                case LanguageFlag.ZHCN:
                    return dic_zhcn[type];
                case LanguageFlag.ZHHK:
                    return dic_zhhk[type];
                case LanguageFlag.ENUS:
                default:
                    return dic_enus[type];
            }
        }
        public string GetKeyValueDesc(string id, string lan, InfoType type)
        {
            string rtn = string.Empty;
            KeyValue kv = GetKeyValueList(lan, type).Find(mm => mm.Key.Equals(id));
            if (kv != null)
            {
                rtn = kv.Value;
            }
            return rtn;
        }
        #endregion

    }
}
