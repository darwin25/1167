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
	/// 盘点注册
	/// </summary>
	public partial class STK_STake01
	{
		private readonly ISTK_STake01 dal=DataAccess.CreateSTK_STake01();
        public STK_STake01()
		{}
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
        public bool Exists(string StockTakeNumber, int StoreID, string ProdCode, string SerialNo)
		{
            return dal.Exists(StockTakeNumber, StoreID, ProdCode, SerialNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Edge.SVA.Model.STK_STAKE01 model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Edge.SVA.Model.STK_STAKE01 model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo)
		{

            return dal.Delete(StockTakeNumber, StoreID, ProdCode, StoreType, SerialNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string StockTakeNumber)
		{

            return dal.Delete(StockTakeNumber);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool DeleteList(string StockTakeNumber)
		{
            return dal.DeleteList(StockTakeNumber);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Edge.SVA.Model.STK_STAKE01 GetModel(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo)
		{

            return dal.GetModel(StockTakeNumber, StoreID, ProdCode, StoreType, SerialNo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Edge.SVA.Model.STK_STAKE01 GetModelByCache(string StockTakeNumber, int StoreID, string ProdCode, string StoreType, string SerialNo)
		{

            string CacheKey = "STK_STake_HModel-" + StockTakeNumber + "-" + StoreID + "-" + ProdCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(StockTakeNumber, StoreID, ProdCode, StoreType, SerialNo);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (Edge.SVA.Model.STK_STAKE01)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Edge.SVA.Model.STK_STAKE01> GetModelList(string strWhere)
		{            
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Edge.SVA.Model.STK_STAKE01> DataTableToList(DataTable dt)
		{
            List<Edge.SVA.Model.STK_STAKE01> modelList = new List<Edge.SVA.Model.STK_STAKE01>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Edge.SVA.Model.STK_STAKE01 model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Edge.SVA.Model.STK_STAKE01();
                    if (dt.Rows[n]["StoreID"] != null && dt.Rows[n]["StoreID"].ToString() != "")
					{
                        model.StoreID = int.Parse(dt.Rows[n]["StoreID"].ToString());
					}
					if(dt.Rows[n]["StockTakeNumber"]!=null && dt.Rows[n]["StockTakeNumber"].ToString()!="")
					{
					    model.StockTakeNumber=dt.Rows[n]["StockTakeNumber"].ToString();
					}
                    if (dt.Rows[n]["ProdCode"] != null && dt.Rows[n]["ProdCode"].ToString() != "")
                    {
                        model.ProdCode = dt.Rows[n]["ProdCode"].ToString();
                    }
                    if (dt.Rows[n]["STOCKTYPE"] != null && dt.Rows[n]["STOCKTYPE"].ToString() != "")
                    {
                        model.StockType = dt.Rows[n]["STOCKTYPE"].ToString();
                    }
                    if (dt.Rows[n]["QTY"] != null && dt.Rows[n]["QTY"].ToString() != "")
                    {
                        model.QTY = int.Parse(dt.Rows[n]["QTY"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["SerialNo"] != null && dt.Rows[n]["SerialNo"].ToString() != "")
                    {
                        model.SerialNo = dt.Rows[n]["SerialNo"].ToString();
                    }
                    if (dt.Rows[n]["SEQ"] != null && dt.Rows[n]["SEQ"].ToString() != "")
                    {
                        model.SEQ = int.Parse(dt.Rows[n]["SEQ"].ToString());
                    }
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

