using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edge.SVA.IDAL;
using Edge.SVA.DALFactory;
using System.Data;

namespace Edge.SVA.BLL
{
    /// <summary>
    /// 物流价格设置表。 按省份
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    public partial class LogisticsPrice
    {
        public LogisticsPrice() { }
        private readonly ILogisticsPrice dal = DataAccess.CreateLogisticsPrice();

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int KeyID)
        {
            return dal.Exists(KeyID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.LogisticsPrice model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.LogisticsPrice model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int KeyID)
        {

            return dal.Delete(KeyID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string KeyIDlist)
        {
            return dal.DeleteList(KeyIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.LogisticsPrice GetModel(int KeyID)
        {

            return dal.GetModel(KeyID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Edge.SVA.Model.LogisticsPrice GetModelByCache(int KeyID)
        {

            string CacheKey = "LogisticsPriceModel-" + KeyID;
            object objModel = Edge.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(KeyID);
                    if (objModel != null)
                    {
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Edge.SVA.Model.LogisticsPrice)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.LogisticsPrice> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.LogisticsPrice> DataTableToList(DataTable dt)
        {
            List<Edge.SVA.Model.LogisticsPrice> modelList = new List<Edge.SVA.Model.LogisticsPrice>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Edge.SVA.Model.LogisticsPrice model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Edge.SVA.Model.LogisticsPrice();
                    if (dt.Rows[n]["KeyID"] != null && dt.Rows[n]["KeyID"].ToString() != "")
                    {
                        model.KeyID = int.Parse(dt.Rows[n]["KeyID"].ToString());
                    }
                    if (dt.Rows[n]["LogisticsProviderID"] != null && dt.Rows[n]["LogisticsProviderID"].ToString() != "")
                    {
                        model.LogisticsProviderID = int.Parse(dt.Rows[n]["LogisticsProviderID"].ToString());
                    }
                    if (dt.Rows[n]["ProvinceCode"] != null)
                    {
                        model.ProvinceCode = dt.Rows[n]["ProvinceCode"].ToString();
                    }
                    if (dt.Rows[n]["StartPrice"] != null && dt.Rows[n]["StartPrice"].ToString() != "")
                    {
                        model.StartPrice = decimal.Parse(dt.Rows[n]["StartPrice"].ToString());
                    }
                    if (dt.Rows[n]["StartWeight"] != null && dt.Rows[n]["StartWeight"].ToString() != "")
                    {
                        model.StartWeight = decimal.Parse(dt.Rows[n]["StartWeight"].ToString());
                    }
                    if (dt.Rows[n]["OverflowPricePerKG"] != null && dt.Rows[n]["OverflowPricePerKG"].ToString() != "")
                    {
                        model.OverflowPricePerKG = decimal.Parse(dt.Rows[n]["OverflowPricePerKG"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  Method
    }
}
