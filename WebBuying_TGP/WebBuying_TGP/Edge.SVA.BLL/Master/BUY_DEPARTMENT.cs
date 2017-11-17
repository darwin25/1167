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
    /// 货品部门表
    /// </summary>
    public partial class BUY_DEPARTMENT
    {
        private readonly IBUY_DEPARTMENT dal = DataAccess.CreateBUY_DEPARTMENT();
        public BUY_DEPARTMENT()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DepartCode)
        {
            return dal.Exists(DepartCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.BUY_DEPARTMENT model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.BUY_DEPARTMENT model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string DepartCode)
        {

            return dal.Delete(DepartCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string DepartCodelist)
        {
            return dal.DeleteList(DepartCodelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.BUY_DEPARTMENT GetModel(string DepartCode)
        {

            return dal.GetModel(DepartCode);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Edge.SVA.Model.BUY_DEPARTMENT GetModelByCache(string DepartCode)
        {

            string CacheKey = "BUY_DEPARTMENTModel-" + DepartCode;
            object objModel = Edge.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(DepartCode);
                    if (objModel != null)
                    {
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Edge.SVA.Model.BUY_DEPARTMENT)objModel;
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
        public List<Edge.SVA.Model.BUY_DEPARTMENT> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Edge.SVA.Model.BUY_DEPARTMENT> DataTableToList(DataTable dt)
        {
            List<Edge.SVA.Model.BUY_DEPARTMENT> modelList = new List<Edge.SVA.Model.BUY_DEPARTMENT>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Edge.SVA.Model.BUY_DEPARTMENT model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Edge.SVA.Model.BUY_DEPARTMENT();
                    if (dt.Rows[n]["DepartCode"] != null && dt.Rows[n]["DepartCode"].ToString() != "")
                    {
                        model.DepartCode = dt.Rows[n]["DepartCode"].ToString();
                    }
                    if (dt.Rows[n]["DepartName1"] != null && dt.Rows[n]["DepartName1"].ToString() != "")
                    {
                        model.DepartName1 = dt.Rows[n]["DepartName1"].ToString();
                    }
                    if (dt.Rows[n]["DepartName2"] != null && dt.Rows[n]["DepartName2"].ToString() != "")
                    {
                        model.DepartName2 = dt.Rows[n]["DepartName2"].ToString();
                    }
                    if (dt.Rows[n]["DepartName3"] != null && dt.Rows[n]["DepartName3"].ToString() != "")
                    {
                        model.DepartName3 = dt.Rows[n]["DepartName3"].ToString();
                    }
                    if (dt.Rows[n]["DepartPicFile"] != null && dt.Rows[n]["DepartPicFile"].ToString() != "")
                    {
                        model.DepartPicFile = dt.Rows[n]["DepartPicFile"].ToString();
                    }
                    if (dt.Rows[n]["DepartPicFile2"] != null && dt.Rows[n]["DepartPicFile2"].ToString() != "")
                    {
                        model.DepartPicFile2 = dt.Rows[n]["DepartPicFile2"].ToString();
                    }
                    if (dt.Rows[n]["DepartPicFile3"] != null && dt.Rows[n]["DepartPicFile3"].ToString() != "")
                    {
                        model.DepartPicFile3 = dt.Rows[n]["DepartPicFile3"].ToString();
                    }
                    if (dt.Rows[n]["DepartNote"] != null && dt.Rows[n]["DepartNote"].ToString() != "")
                    {
                        model.DepartNote = dt.Rows[n]["DepartNote"].ToString();
                    }
                    if (dt.Rows[n]["ReplenFormulaCode"] != null && dt.Rows[n]["ReplenFormulaCode"].ToString() != "")
                    {
                        model.ReplenFormulaCode = dt.Rows[n]["ReplenFormulaCode"].ToString();
                    }
                    if (dt.Rows[n]["FulfillmentHouseCode"] != null && dt.Rows[n]["FulfillmentHouseCode"].ToString() != "")
                    {
                        model.FulfillmentHouseCode = dt.Rows[n]["FulfillmentHouseCode"].ToString();
                    }
                    if (dt.Rows[n]["CostCCC"] != null && dt.Rows[n]["CostCCC"].ToString() != "")
                    {
                        model.CostCCC = dt.Rows[n]["CostCCC"].ToString();
                    }
                    if (dt.Rows[n]["CostWO"] != null && dt.Rows[n]["CostWO"].ToString() != "")
                    {
                        model.CostWO = dt.Rows[n]["CostWO"].ToString();
                    }
                    if (dt.Rows[n]["RevenueCCC"] != null && dt.Rows[n]["RevenueCCC"].ToString() != "")
                    {
                        model.RevenueCCC = dt.Rows[n]["RevenueCCC"].ToString();
                    }
                    if (dt.Rows[n]["RevenueWO"] != null && dt.Rows[n]["RevenueWO"].ToString() != "")
                    {
                        model.RevenueWO = dt.Rows[n]["RevenueWO"].ToString();
                    }
                    if (dt.Rows[n]["NonOrder"] != null && dt.Rows[n]["NonOrder"].ToString() != "")
                    {
                        model.NonOrder = int.Parse(dt.Rows[n]["NonOrder"].ToString());
                    }
                    if (dt.Rows[n]["NonSale"] != null && dt.Rows[n]["NonSale"].ToString() != "")
                    {
                        model.NonSale = int.Parse(dt.Rows[n]["NonSale"].ToString());
                    }
                    if (dt.Rows[n]["Consignment"] != null && dt.Rows[n]["Consignment"].ToString() != "")
                    {
                        model.Consignment = int.Parse(dt.Rows[n]["Consignment"].ToString());
                    }
                    if (dt.Rows[n]["WeightItem"] != null && dt.Rows[n]["WeightItem"].ToString() != "")
                    {
                        model.WeightItem = int.Parse(dt.Rows[n]["WeightItem"].ToString());
                    }
                    if (dt.Rows[n]["DiscAllow"] != null && dt.Rows[n]["DiscAllow"].ToString() != "")
                    {
                        model.DiscAllow = int.Parse(dt.Rows[n]["DiscAllow"].ToString());
                    }
                    if (dt.Rows[n]["CouponAllow"] != null && dt.Rows[n]["CouponAllow"].ToString() != "")
                    {
                        model.CouponAllow = int.Parse(dt.Rows[n]["CouponAllow"].ToString());
                    }
                    if (dt.Rows[n]["VisuaItem"] != null && dt.Rows[n]["VisuaItem"].ToString() != "")
                    {
                        model.VisuaItem = int.Parse(dt.Rows[n]["VisuaItem"].ToString());
                    }
                    if (dt.Rows[n]["CouponSKU"] != null && dt.Rows[n]["CouponSKU"].ToString() != "")
                    {
                        model.CouponSKU = int.Parse(dt.Rows[n]["CouponSKU"].ToString());
                    }
                    if (dt.Rows[n]["BOM"] != null && dt.Rows[n]["BOM"].ToString() != "")
                    {
                        model.BOM = int.Parse(dt.Rows[n]["BOM"].ToString());
                    }
                    if (dt.Rows[n]["MutexFlag"] != null && dt.Rows[n]["MutexFlag"].ToString() != "")
                    {
                        model.MutexFlag = int.Parse(dt.Rows[n]["MutexFlag"].ToString());
                    }
                    if (dt.Rows[n]["DiscountLimit"] != null && dt.Rows[n]["DiscountLimit"].ToString() != "")
                    {
                        model.DiscountLimit = decimal.Parse(dt.Rows[n]["DiscountLimit"].ToString());
                    }
                    if (dt.Rows[n]["OnAccount"] != null && dt.Rows[n]["OnAccount"].ToString() != "")
                    {
                        model.OnAccount = int.Parse(dt.Rows[n]["OnAccount"].ToString());
                    }
                    if (dt.Rows[n]["WarehouseCode"] != null && dt.Rows[n]["WarehouseCode"].ToString() != "")
                    {
                        model.WarehouseCode = dt.Rows[n]["WarehouseCode"].ToString();
                    }
                    if (dt.Rows[n]["DefaultPickupStoreCode"] != null && dt.Rows[n]["DefaultPickupStoreCode"].ToString() != "")
                    {
                        model.DefaultPickupStoreCode = dt.Rows[n]["DefaultPickupStoreCode"].ToString();
                    }
                    if (dt.Rows[n]["Additional"] != null && dt.Rows[n]["Additional"].ToString() != "")
                    {
                        model.Additional = dt.Rows[n]["Additional"].ToString();
                    }
                    if (dt.Rows[n]["Flag1"] != null && dt.Rows[n]["Flag1"].ToString() != "")
                    {
                        model.Flag1 = int.Parse(dt.Rows[n]["Flag1"].ToString());
                    }
                    if (dt.Rows[n]["Flag2"] != null && dt.Rows[n]["Flag2"].ToString() != "")
                    {
                        model.Flag2 = int.Parse(dt.Rows[n]["Flag2"].ToString());
                    }
                    if (dt.Rows[n]["Flag3"] != null && dt.Rows[n]["Flag3"].ToString() != "")
                    {
                        model.Flag3 = int.Parse(dt.Rows[n]["Flag3"].ToString());
                    }
                    if (dt.Rows[n]["Flag4"] != null && dt.Rows[n]["Flag4"].ToString() != "")
                    {
                        model.Flag4 = int.Parse(dt.Rows[n]["Flag4"].ToString());
                    }
                    if (dt.Rows[n]["Flag5"] != null && dt.Rows[n]["Flag5"].ToString() != "")
                    {
                        model.Flag5 = int.Parse(dt.Rows[n]["Flag5"].ToString());
                    }
                    if (dt.Rows[n]["Flag6"] != null && dt.Rows[n]["Flag6"].ToString() != "")
                    {
                        model.Flag6 = int.Parse(dt.Rows[n]["Flag6"].ToString());
                    }
                    if (dt.Rows[n]["Flag7"] != null && dt.Rows[n]["Flag7"].ToString() != "")
                    {
                        model.Flag7 = int.Parse(dt.Rows[n]["Flag7"].ToString());
                    }
                    if (dt.Rows[n]["Flag8"] != null && dt.Rows[n]["Flag8"].ToString() != "")
                    {
                        model.Flag8 = int.Parse(dt.Rows[n]["Flag8"].ToString());
                    }
                    if (dt.Rows[n]["Flag9"] != null && dt.Rows[n]["Flag9"].ToString() != "")
                    {
                        model.Flag9 = int.Parse(dt.Rows[n]["Flag9"].ToString());
                    }
                    if (dt.Rows[n]["Flag10"] != null && dt.Rows[n]["Flag10"].ToString() != "")
                    {
                        model.Flag10 = int.Parse(dt.Rows[n]["Flag10"].ToString());
                    }
                    if (dt.Rows[n]["Memo1"] != null && dt.Rows[n]["Memo1"].ToString() != "")
                    {
                        model.Memo1 = dt.Rows[n]["Memo1"].ToString();
                    }
                    if (dt.Rows[n]["Memo2"] != null && dt.Rows[n]["Memo2"].ToString() != "")
                    {
                        model.Memo2 = dt.Rows[n]["Memo2"].ToString();
                    }
                    if (dt.Rows[n]["Memo3"] != null && dt.Rows[n]["Memo3"].ToString() != "")
                    {
                        model.Memo3 = dt.Rows[n]["Memo3"].ToString();
                    }
                    if (dt.Rows[n]["Memo4"] != null && dt.Rows[n]["Memo4"].ToString() != "")
                    {
                        model.Memo4 = dt.Rows[n]["Memo4"].ToString();
                    }
                    if (dt.Rows[n]["Memo5"] != null && dt.Rows[n]["Memo5"].ToString() != "")
                    {
                        model.Memo5 = dt.Rows[n]["Memo5"].ToString();
                    }
                    if (dt.Rows[n]["Memo6"] != null && dt.Rows[n]["Memo6"].ToString() != "")
                    {
                        model.Memo6 = dt.Rows[n]["Memo6"].ToString();
                    }
                    if (dt.Rows[n]["Memo7"] != null && dt.Rows[n]["Memo7"].ToString() != "")
                    {
                        model.Memo7 = dt.Rows[n]["Memo7"].ToString();
                    }
                    if (dt.Rows[n]["Memo8"] != null && dt.Rows[n]["Memo8"].ToString() != "")
                    {
                        model.Memo8 = dt.Rows[n]["Memo8"].ToString();
                    }
                    if (dt.Rows[n]["Memo9"] != null && dt.Rows[n]["Memo9"].ToString() != "")
                    {
                        model.Memo9 = dt.Rows[n]["Memo9"].ToString();
                    }
                    if (dt.Rows[n]["Memo10"] != null && dt.Rows[n]["Memo10"].ToString() != "")
                    {
                        model.Memo10 = dt.Rows[n]["Memo10"].ToString();
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
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

