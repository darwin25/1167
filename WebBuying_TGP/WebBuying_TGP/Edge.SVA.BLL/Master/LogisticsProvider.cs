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
    /// 物流供应商
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    public partial class LogisticsProvider
    {
        public LogisticsProvider() { }

        private readonly ILogisticsProvider dal = DataAccess.CreateLogisticsProvider();

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
        public int Add(Edge.SVA.Model.LogisticsProvider model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.LogisticsProvider model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int LogisticsProviderID)
        {

            return dal.Delete(LogisticsProviderID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string LogisticsProviderIDlist)
        {
            return dal.DeleteList(LogisticsProviderIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.LogisticsProvider GetModel(int LogisticsProviderID)
        {

            return dal.GetModel(LogisticsProviderID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Edge.SVA.Model.LogisticsProvider GetModelByCache(int LogisticsProviderID)
        {

            string CacheKey = "LogisticsProviderModel-" + LogisticsProviderID;
            object objModel = Edge.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(LogisticsProviderID);
                    if (objModel != null)
                    {
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Edge.SVA.Model.LogisticsProvider)objModel;
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
        public List<Edge.SVA.Model.LogisticsProvider> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.LogisticsProvider> DataTableToList(DataTable dt)
        {
            List<Edge.SVA.Model.LogisticsProvider> modelList = new List<Edge.SVA.Model.LogisticsProvider>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Edge.SVA.Model.LogisticsProvider model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Edge.SVA.Model.LogisticsProvider();
                    if (dt.Rows[n]["LogisticsProviderID"] != null && dt.Rows[n]["LogisticsProviderID"].ToString() != "")
                    {
                        model.LogisticsProviderID = int.Parse(dt.Rows[n]["LogisticsProviderID"].ToString());
                    }
                    if (dt.Rows[n]["LogisticsProviderCode"] != null)
                    {
                        model.LogisticsProviderCode = dt.Rows[n]["LogisticsProviderCode"].ToString();
                    }
                    if (dt.Rows[n]["ProviderName1"] != null)
                    {
                        model.ProviderName1 = dt.Rows[n]["ProviderName1"].ToString();
                    }
                    if (dt.Rows[n]["ProviderName2"] != null)
                    {
                        model.ProviderName2 = dt.Rows[n]["ProviderName2"].ToString();
                    }
                    if (dt.Rows[n]["ProviderName3"] != null)
                    {
                        model.ProviderName3 = dt.Rows[n]["ProviderName3"].ToString();
                    }
                    if (dt.Rows[n]["ProviderContactTel"] != null)
                    {
                        model.ProviderContactTel = dt.Rows[n]["ProviderContactTel"].ToString();
                    }
                    if (dt.Rows[n]["ProviderContact"] != null)
                    {
                        model.ProviderContact = dt.Rows[n]["ProviderContact"].ToString();
                    }
                    if (dt.Rows[n]["ProviderContactEmail"] != null)
                    {
                        model.ProviderContactEmail = dt.Rows[n]["ProviderContactEmail"].ToString();
                    }
                    if (dt.Rows[n]["OrdQueryAddr"] != null)
                    {
                        model.OrdQueryAddr = dt.Rows[n]["OrdQueryAddr"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null)
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["CreatedOn"] != null && dt.Rows[n]["CreatedOn"].ToString() != "")
                    {
                        model.CreatedOn = DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
                    }
                    if (dt.Rows[n]["CreatedBy"] != null && dt.Rows[n]["CreatedBy"].ToString() != "")
                    {
                        model.CreatedBy = int.Parse(dt.Rows[n]["CreatedBy"].ToString());
                    }
                    if (dt.Rows[n]["UpdatedOn"] != null && dt.Rows[n]["UpdatedOn"].ToString() != "")
                    {
                        model.UpdatedOn = DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
                    }
                    if (dt.Rows[n]["UpdatedBy"] != null && dt.Rows[n]["UpdatedBy"].ToString() != "")
                    {
                        model.UpdatedBy = int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
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
