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
	/// 店铺组
	/// </summary>
	public partial class BUY_STOREGROUP
	{
		private readonly IBUY_STOREGROUP dal=DataAccess.CreateBUY_STOREGROUP();
		public BUY_STOREGROUP()
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
		public bool Exists(int StoreGroupID)
		{
			return dal.Exists(StoreGroupID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_STOREGROUP model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_STOREGROUP model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreGroupID)
		{
			
			return dal.Delete(StoreGroupID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StoreGroupIDlist )
		{
			return dal.DeleteList(StoreGroupIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_STOREGROUP GetModel(int StoreGroupID)
		{
			
			return dal.GetModel(StoreGroupID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_STOREGROUP GetModelByCache(int StoreGroupID)
		{
			
			string CacheKey = "BUY_STOREGROUPModel-" + StoreGroupID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreGroupID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_STOREGROUP)objModel;
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
		public List<Edge.SVA.Model.BUY_STOREGROUP> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_STOREGROUP> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_STOREGROUP> modelList = new List<Edge.SVA.Model.BUY_STOREGROUP>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_STOREGROUP model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_STOREGROUP();
					if(dt.Rows[n]["StoreGroupID"]!=null && dt.Rows[n]["StoreGroupID"].ToString()!="")
					{
						model.StoreGroupID=int.Parse(dt.Rows[n]["StoreGroupID"].ToString());
					}
					if(dt.Rows[n]["StoreGroupCode"]!=null && dt.Rows[n]["StoreGroupCode"].ToString()!="")
					{
					model.StoreGroupCode=dt.Rows[n]["StoreGroupCode"].ToString();
					}
					if(dt.Rows[n]["StoreGroupName1"]!=null && dt.Rows[n]["StoreGroupName1"].ToString()!="")
					{
					model.StoreGroupName1=dt.Rows[n]["StoreGroupName1"].ToString();
					}
					if(dt.Rows[n]["StoreGroupName2"]!=null && dt.Rows[n]["StoreGroupName2"].ToString()!="")
					{
					model.StoreGroupName2=dt.Rows[n]["StoreGroupName2"].ToString();
					}
					if(dt.Rows[n]["StoreGroupName3"]!=null && dt.Rows[n]["StoreGroupName3"].ToString()!="")
					{
					model.StoreGroupName3=dt.Rows[n]["StoreGroupName3"].ToString();
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

