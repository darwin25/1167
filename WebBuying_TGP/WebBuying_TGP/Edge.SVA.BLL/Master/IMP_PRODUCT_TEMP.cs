using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
    /// <summary>
    /// 读入的product
    /// 创建人：lisa
    /// 创建时间：2016-07-08
    /// </summary>
    public partial class IMP_PRODUCT_TEMP
    {
        private readonly IIMP_PRODUCT_TEMP dal = DataAccess.CreateIMP_PRODUCT_TEMP();
        public IMP_PRODUCT_TEMP()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string INTERNAL_PRODUCT_CODE)
        {
            return dal.Exists(INTERNAL_PRODUCT_CODE);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.IMP_PRODUCT_TEMP model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.IMP_PRODUCT_TEMP model)
        {
            return dal.Update(model);
        }
        public bool UpdateTemp(Edge.SVA.Model.IMP_PRODUCT_TEMP model)
        {
            return dal.UpdateTemp(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string INTERNAL_PRODUCT_CODE)
        {

            return dal.Delete(INTERNAL_PRODUCT_CODE);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string INTERNAL_PRODUCT_CODElist)
        {
            return dal.DeleteList(INTERNAL_PRODUCT_CODElist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.IMP_PRODUCT_TEMP GetModel(string INTERNAL_PRODUCT_CODE)
        {

            return dal.GetModel(INTERNAL_PRODUCT_CODE);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Edge.SVA.Model.IMP_PRODUCT_TEMP GetModelByCache(string INTERNAL_PRODUCT_CODE)
        {

            string CacheKey = "IMP_PRODUCT_TEMPModel-" + INTERNAL_PRODUCT_CODE;
            object objModel = Edge.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(INTERNAL_PRODUCT_CODE);
                    if (objModel != null)
                    {
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Edge.SVA.Model.IMP_PRODUCT_TEMP)objModel;
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
        public List<Edge.SVA.Model.IMP_PRODUCT_TEMP> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.IMP_PRODUCT_TEMP> DataTableToList(DataTable dt)
        {
            List<Edge.SVA.Model.IMP_PRODUCT_TEMP> modelList = new List<Edge.SVA.Model.IMP_PRODUCT_TEMP>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Edge.SVA.Model.IMP_PRODUCT_TEMP model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        public bool trunc()
        {
            return dal.trunc();
        }
        #endregion  BasicMethod

    }
}

