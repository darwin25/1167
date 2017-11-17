using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain;

namespace Edge.SVA.BLL.Domain.DataResources
{
    public class TransactionTypeRepostory
    {
        private static readonly object syncObj = new object();
        private static readonly TransactionTypeRepostory instance = new TransactionTypeRepostory();
        public static TransactionTypeRepostory Singleton
        {
            get
            {
                return instance;
            }
        }

        private List<KeyValue> transactionTypeList_enus = new List<KeyValue>();
        private List<KeyValue> transactionTypeList_zhcn = new List<KeyValue>();
        private List<KeyValue> transactionTypeList_zhhk = new List<KeyValue>();

        public List<KeyValue> GetTransactionTypeList(string lan)
        {
            switch (lan)
            {
                case LanguageFlag.ZHCN:
                    return transactionTypeList_zhcn;
                case LanguageFlag.ZHHK:
                    return transactionTypeList_zhhk;
                case LanguageFlag.ENUS:
                default:
                    return transactionTypeList_enus;
            }
        }
        private TransactionTypeRepostory()
        {
            LoadDataFromDB();
        }

        private void LoadDataFromDB()
        {
            List<KeyValue> list1 = new List<KeyValue>();
            List<KeyValue> list2 = new List<KeyValue>();
            List<KeyValue> list3 = new List<KeyValue>();
            Edge.SVA.BLL.OperationTable bll = new Edge.SVA.BLL.OperationTable();
            List<Edge.SVA.Model.OperationTable> list = bll.GetModelList(" OprID in (501,504,12,13,14,15,25,26,31,32,36,37,46,47,61,62) order by OprID asc ");
            foreach (var item in list)
            {
                list1.Add(new KeyValue(item.OprID.ToString(), item.OprIDDesc1));
                list2.Add(new KeyValue(item.OprID.ToString(), item.OprIDDesc2));
                list3.Add(new KeyValue(item.OprID.ToString(), item.OprIDDesc3));
            }
            transactionTypeList_enus = list1;
            transactionTypeList_zhcn = list2;
            transactionTypeList_zhhk = list3;
        }
        public void Refresh()
        {
            LoadDataFromDB();
        }
    }
}
