using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Edge.SVA.BLL.Domain.DataResources
{
    public class StoreRepostory
    {
        private static readonly object syncObj = new object();
        private static readonly StoreRepostory instance = new StoreRepostory();
        private StoreRepostory()
        {
            LoadDataFromDatabase();
        }

        private void LoadDataFromDatabase()
        {
            Store bll = new Store();
            List<Edge.SVA.Model.Store> list = bll.GetModelList(string.Empty);
            Dictionary<int, Edge.SVA.Model.Store> dic = new Dictionary<int, Edge.SVA.Model.Store>();
            Dictionary<string, Edge.SVA.Model.Store> dic1 = new Dictionary<string, Edge.SVA.Model.Store>();
            foreach (var item in list)
            {
                dic.Add(item.StoreID, item);
                dic1.Add(item.StoreCode, item);
            }
            idDic = dic;
            codeDic = dic1;
        }
        private Dictionary<int, Edge.SVA.Model.Store> idDic = new Dictionary<int, Edge.SVA.Model.Store>();
        private Dictionary<string, Edge.SVA.Model.Store> codeDic = new Dictionary<string, Edge.SVA.Model.Store>();
        public static StoreRepostory Singleton
        {
            get
            {
                return instance;
            }
        }
        public void Refresh()
        {
            //Thread t = new Thread(new ThreadStart(RefreshAsync));
            //t.Start();
            RefreshAsync();
        }
        private void RefreshAsync()
        {
            lock (syncObj)
            {
                LoadDataFromDatabase();
            }
        }
        public Edge.SVA.Model.Store GetModelByID(int id)
        {
            if (!idDic.ContainsKey(id))
            {
                Refresh();
            }
            if (idDic.ContainsKey(id))
            {
                return idDic[id];
            }
            return new Edge.SVA.Model.Store();
        }
        public Edge.SVA.Model.Store GetModelByCode(string code)
        {
            if (!codeDic.ContainsKey(code))
            {
                Refresh();
            }
            if (codeDic.ContainsKey(code))
            {
                return codeDic[code];
            }
            return new Edge.SVA.Model.Store();
        }
    }
}
