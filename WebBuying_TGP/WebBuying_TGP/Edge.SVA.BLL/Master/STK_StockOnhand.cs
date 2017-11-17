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
	/// 货品库存表。货品实际
	/// </summary>
	public partial class STK_StockOnhand
	{
		private readonly ISTK_StockOnhand dal=DataAccess.CreateSTK_StockOnhand();
		public STK_StockOnhand()
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
		public bool Exists(int StoreID,string StockTypeCode,string ProdCode)
		{
			return dal.Exists(StoreID,StockTypeCode,ProdCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.STK_StockOnhand model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.STK_StockOnhand model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreID,string StockTypeCode,string ProdCode)
		{
			
			return dal.Delete(StoreID,StockTypeCode,ProdCode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.STK_StockOnhand GetModel(int StoreID,string StockTypeCode,string ProdCode)
		{
			
			return dal.GetModel(StoreID,StockTypeCode,ProdCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.STK_StockOnhand GetModelByCache(int StoreID,string StockTypeCode,string ProdCode)
		{
			
			string CacheKey = "STK_StockOnhandModel-" + StoreID+StockTypeCode+ProdCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreID,StockTypeCode,ProdCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.STK_StockOnhand)objModel;
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
		public List<Edge.SVA.Model.STK_StockOnhand> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.STK_StockOnhand> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.STK_StockOnhand> modelList = new List<Edge.SVA.Model.STK_StockOnhand>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.STK_StockOnhand model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.STK_StockOnhand();
					if(dt.Rows[n]["StoreID"]!=null && dt.Rows[n]["StoreID"].ToString()!="")
					{
						model.StoreID=int.Parse(dt.Rows[n]["StoreID"].ToString());
					}
					if(dt.Rows[n]["StockTypeCode"]!=null && dt.Rows[n]["StockTypeCode"].ToString()!="")
					{
					model.StockTypeCode=dt.Rows[n]["StockTypeCode"].ToString();
					}
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["OnhandQty"]!=null && dt.Rows[n]["OnhandQty"].ToString()!="")
					{
						model.OnhandQty=int.Parse(dt.Rows[n]["OnhandQty"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
						model.CreatedBy=int.Parse(dt.Rows[n]["CreatedBy"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
						model.UpdatedBy=int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
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

