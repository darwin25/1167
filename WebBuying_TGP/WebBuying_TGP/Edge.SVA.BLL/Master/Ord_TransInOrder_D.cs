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
    /// PO单明细表
    /// </summary>
    public partial class Ord_TransInOrder_D
    {
        private readonly IOrd_TransInOrder_D dal = DataAccess.CreateOrd_TransInOrder_D();
        public Ord_TransInOrder_D()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

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
        public int Add(Edge.SVA.Model.Ord_TransInOrder_D model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.Ord_TransInOrder_D model)
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
        /// 按单号删除数据
        /// </summary>
        public bool Delete(string TransInOrderNumber)
        {
            return dal.Delete(TransInOrderNumber);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.Ord_TransInOrder_D GetModel(int KeyID)
        {

            return dal.GetModel(KeyID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Edge.SVA.Model.Ord_TransInOrder_D GetModelByCache(int KeyID)
        {

            string CacheKey = "Ord_TransInOrder_DModel-" + KeyID;
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
            return (Edge.SVA.Model.Ord_TransInOrder_D)objModel;
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
        public List<Edge.SVA.Model.Ord_TransInOrder_D> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.Ord_TransInOrder_D> DataTableToList(DataTable dt)
        {
            List<Edge.SVA.Model.Ord_TransInOrder_D> modelList = new List<Edge.SVA.Model.Ord_TransInOrder_D>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Edge.SVA.Model.Ord_TransInOrder_D model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Edge.SVA.Model.Ord_TransInOrder_D();
                    if (dt.Rows[n]["KeyID"] != null && dt.Rows[n]["KeyID"].ToString() != "")
                    {
                        model.KeyID = int.Parse(dt.Rows[n]["KeyID"].ToString());
                    }
                    if (dt.Rows[n]["TransInOrderNumber"] != null && dt.Rows[n]["TransInOrderNumber"].ToString() != "")
                    {
                        model.TransInOrderNumber = dt.Rows[n]["TransInOrderNumber"].ToString();
                    }
                    if (dt.Rows[n]["ProdCode"] != null && dt.Rows[n]["ProdCode"].ToString() != "")
                    {
                        model.ProdCode = dt.Rows[n]["ProdCode"].ToString();
                    }
                    if (dt.Rows[n]["TransInQty"] != null && dt.Rows[n]["TransInQty"].ToString() != "")
                    {
                        model.TransInQty = int.Parse(dt.Rows[n]["TransInQty"].ToString());
                    }
                    if (dt.Rows[n]["ReasonID"] != null && dt.Rows[n]["ReasonID"].ToString() != "")
                    {
                        model.ReasonID = int.Parse(dt.Rows[n]["ReasonID"].ToString());
                    }
                    if (dt.Rows[0]["Remark"] != null && dt.Rows[0]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[0]["Remark"].ToString();
                    }
                    modelList.Add(model);
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

         /// <summary>
        /// 求总库存数量
        /// 创建人：Lisa
        /// 创建时间：2016-03-28
        /// </summary>
        /// <returns></returns>
        public DataSet GetSummary(string strWhere)
        {
            return dal.GetSummary(strWhere);
        }

        #endregion  Method
    }
}

