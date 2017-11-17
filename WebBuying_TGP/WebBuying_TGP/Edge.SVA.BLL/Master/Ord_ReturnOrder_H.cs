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
    /// PO单主表
    /// </summary>
    public partial class Ord_ReturnOrder_H
    {
        private readonly IOrd_ReturnOrder_H dal = DataAccess.CreateOrd_ReturnOrder_H();
        public Ord_ReturnOrder_H()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string POCode)
        {
            return dal.Exists(POCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.Ord_ReturnOrder_H model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.Ord_ReturnOrder_H model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string POCode)
        {

            return dal.Delete(POCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string POCodelist)
        {
            return dal.DeleteList(POCodelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.Ord_ReturnOrder_H GetModel(string POCode)
        {

            return dal.GetModel(POCode);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Edge.SVA.Model.Ord_ReturnOrder_H GetModelByCache(string POCode)
        {

            string CacheKey = "Ord_ReturnOrder_HModel-" + POCode;
            object objModel = Edge.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(POCode);
                    if (objModel != null)
                    {
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Edge.SVA.Model.Ord_ReturnOrder_H)objModel;
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
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2015-12-20
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetListByParm(string strWhere, string filedOrder, string webSiteName)
        {
            return dal.GetListByParm(strWhere, filedOrder, webSiteName);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.Ord_ReturnOrder_H> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.Ord_ReturnOrder_H> DataTableToList(DataTable dt)
        {
            List<Edge.SVA.Model.Ord_ReturnOrder_H> modelList = new List<Edge.SVA.Model.Ord_ReturnOrder_H>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Edge.SVA.Model.Ord_ReturnOrder_H model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Edge.SVA.Model.Ord_ReturnOrder_H();

                    if (dt.Rows[n]["ReturnOrderNumber"] != null && dt.Rows[n]["ReturnOrderNumber"].ToString() != "")
                    {
                        model.ReturnOrderNumber = dt.Rows[n]["ReturnOrderNumber"].ToString();
                    }
                    if (dt.Rows[n]["OrderType"] != null && dt.Rows[n]["OrderType"].ToString() != "")
                    {
                        model.OrderType = int.Parse(dt.Rows[n]["OrderType"].ToString());
                    }
                    if (dt.Rows[n]["ReferenceNo"] != null && dt.Rows[n]["ReferenceNo"].ToString() != "")
                    {
                        model.ReferenceNo = dt.Rows[n]["ReferenceNo"].ToString();
                    }
                    if (dt.Rows[n]["FromStoreID"] != null && dt.Rows[n]["FromStoreID"].ToString() != "")
                    {
                        model.FromStoreID = int.Parse(dt.Rows[n]["FromStoreID"].ToString());
                    }
                    if (dt.Rows[n]["FromContactName"] != null && dt.Rows[n]["FromContactName"].ToString() != "")
                    {
                        model.FromContactName = dt.Rows[n]["FromContactName"].ToString();
                    }
                    if (dt.Rows[n]["FromContactPhone"] != null && dt.Rows[n]["FromContactPhone"].ToString() != "")
                    {
                        model.FromContactPhone = dt.Rows[n]["FromContactPhone"].ToString();
                    }
                    if (dt.Rows[n]["FromMobile"] != null && dt.Rows[n]["FromMobile"].ToString() != "")
                    {
                        model.FromMobile = dt.Rows[n]["FromMobile"].ToString();
                    }
                    if (dt.Rows[n]["FromEmail"] != null && dt.Rows[n]["FromEmail"].ToString() != "")
                    {
                        model.FromEmail = dt.Rows[n]["FromEmail"].ToString();
                    }
                    if (dt.Rows[n]["FromAddress"] != null && dt.Rows[n]["FromAddress"].ToString() != "")
                    {
                        model.FromAddress = dt.Rows[n]["FromAddress"].ToString();
                    }
                    if (dt.Rows[n]["StoreID"] != null && dt.Rows[n]["StoreID"].ToString() != "")
                    {
                        model.StoreID = int.Parse(dt.Rows[n]["StoreID"].ToString());
                    }
                    if (dt.Rows[n]["StoreContactName"] != null && dt.Rows[n]["StoreContactName"].ToString() != "")
                    {
                        model.StoreContactName = dt.Rows[n]["StoreContactName"].ToString();
                    }
                    if (dt.Rows[n]["StoreContactPhone"] != null && dt.Rows[n]["StoreContactPhone"].ToString() != "")
                    {
                        model.StoreContactPhone = dt.Rows[n]["StoreContactPhone"].ToString();
                    }
                    if (dt.Rows[n]["StoreContactEmail"] != null && dt.Rows[n]["StoreContactEmail"].ToString() != "")
                    {
                        model.StoreContactEmail = dt.Rows[n]["StoreContactEmail"].ToString();
                    }
                    if (dt.Rows[n]["StoreMobile"] != null && dt.Rows[n]["StoreMobile"].ToString() != "")
                    {
                        model.StoreMobile = dt.Rows[n]["StoreMobile"].ToString();
                    }
                    if (dt.Rows[n]["StoreAddress"] != null && dt.Rows[n]["StoreAddress"].ToString() != "")
                    {
                        model.StoreAddress = dt.Rows[n]["StoreAddress"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }
                    if (dt.Rows[n]["CreatedBusDate"] != null && dt.Rows[n]["CreatedBusDate"].ToString() != "")
                    {
                        model.CreatedBusDate = DateTime.Parse(dt.Rows[n]["CreatedBusDate"].ToString());
                    }
                    if (dt.Rows[n]["ApproveBusDate"] != null && dt.Rows[n]["ApproveBusDate"].ToString() != "")
                    {
                        model.ApproveBusDate = DateTime.Parse(dt.Rows[n]["ApproveBusDate"].ToString());
                    }
                    if (dt.Rows[n]["ApprovalCode"] != null && dt.Rows[n]["ApprovalCode"].ToString() != "")
                    {
                        model.ApprovalCode = dt.Rows[n]["ApprovalCode"].ToString();
                    }
                    if (dt.Rows[n]["ApproveStatus"] != null && dt.Rows[n]["ApproveStatus"].ToString() != "")
                    {
                        model.ApproveStatus = dt.Rows[n]["ApproveStatus"].ToString();
                    }
                    if (dt.Rows[n]["ApproveOn"] != null && dt.Rows[n]["ApproveOn"].ToString() != "")
                    {
                        model.ApproveOn = DateTime.Parse(dt.Rows[n]["ApproveOn"].ToString());
                    }
                    if (dt.Rows[n]["ApproveBy"] != null && dt.Rows[n]["ApproveBy"].ToString() != "")
                    {
                        model.ApproveBy = int.Parse(dt.Rows[n]["ApproveBy"].ToString());
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
        //public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        //{
        //    return dal.GetList(PageSize, PageIndex, strWhere);
        //}

        #endregion  Method
    }
}

