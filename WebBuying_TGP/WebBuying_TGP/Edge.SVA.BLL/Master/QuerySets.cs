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
	/// 优惠信息表
	/// </summary>
	public partial class QuerySets
	{
		private readonly IQuerySets dal=DataAccess.CreateQuerySets();
		public QuerySets()
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
		public bool Exists(int QueryID)
		{
			return dal.Exists(QueryID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.QuerySets model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.QuerySets model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int QueryID)
		{
			
			return dal.Delete(QueryID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string QueryIDlist )
		{
			return dal.DeleteList(QueryIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.QuerySets GetModel(int QueryID)
		{
			
			return dal.GetModel(QueryID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.QuerySets GetModelByCache(int QueryID)
		{
			
			string CacheKey = "QuerySetsModel-" + QueryID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(QueryID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.QuerySets)objModel;
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
		public List<Edge.SVA.Model.QuerySets> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.QuerySets> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.QuerySets> modelList = new List<Edge.SVA.Model.QuerySets>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.QuerySets model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.QuerySets();
					if(dt.Rows[n]["QueryID"]!=null && dt.Rows[n]["QueryID"].ToString()!="")
					{
						model.QueryID=int.Parse(dt.Rows[n]["QueryID"].ToString());
					}
					if(dt.Rows[n]["DataModelID"]!=null && dt.Rows[n]["DataModelID"].ToString()!="")
					{
						model.DataModelID=int.Parse(dt.Rows[n]["DataModelID"].ToString());
					}
					if(dt.Rows[n]["QueryGroup"]!=null && dt.Rows[n]["QueryGroup"].ToString()!="")
					{
					model.QueryGroup=dt.Rows[n]["QueryGroup"].ToString();
					}
					if(dt.Rows[n]["Description"]!=null && dt.Rows[n]["Description"].ToString()!="")
					{
					model.Description=dt.Rows[n]["Description"].ToString();
					}
					if(dt.Rows[n]["Definition"]!=null && dt.Rows[n]["Definition"].ToString()!="")
					{
					model.Definition=dt.Rows[n]["Definition"].ToString();
					}
					if(dt.Rows[n]["ChangeParams"]!=null && dt.Rows[n]["ChangeParams"].ToString()!="")
					{
						model.ChangeParams=int.Parse(dt.Rows[n]["ChangeParams"].ToString());
					}
					if(dt.Rows[n]["DistinctQuery"]!=null && dt.Rows[n]["DistinctQuery"].ToString()!="")
					{
						model.DistinctQuery=int.Parse(dt.Rows[n]["DistinctQuery"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
					model.UpdatedBy=dt.Rows[n]["UpdatedBy"].ToString();
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder);
        }
        ///<summary>
        ///获取分页总数
        ///</summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

