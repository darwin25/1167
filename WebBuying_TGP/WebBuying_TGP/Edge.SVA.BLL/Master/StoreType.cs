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
	/// 店铺类型表
	/// </summary>
	public partial class StoreType
	{
		private readonly IStoreType dal=DataAccess.CreateStoreType();
		public StoreType()
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
		public bool Exists(int StoreTypeID)
		{
			return dal.Exists(StoreTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.StoreType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.StoreType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreTypeID)
		{
			
			return dal.Delete(StoreTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StoreTypeIDlist )
		{
			return dal.DeleteList(StoreTypeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.StoreType GetModel(int StoreTypeID)
		{
			
			return dal.GetModel(StoreTypeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.StoreType GetModelByCache(int StoreTypeID)
		{
			
			string CacheKey = "StoreTypeModel-" + StoreTypeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreTypeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.StoreType)objModel;
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
		public List<Edge.SVA.Model.StoreType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.StoreType> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.StoreType> modelList = new List<Edge.SVA.Model.StoreType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.StoreType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.StoreType();
					if(dt.Rows[n]["StoreTypeID"]!=null && dt.Rows[n]["StoreTypeID"].ToString()!="")
					{
						model.StoreTypeID=int.Parse(dt.Rows[n]["StoreTypeID"].ToString());
					}
					if(dt.Rows[n]["StoreTypeName1"]!=null && dt.Rows[n]["StoreTypeName1"].ToString()!="")
					{
					model.StoreTypeName1=dt.Rows[n]["StoreTypeName1"].ToString();
					}
					if(dt.Rows[n]["StoreTypeName2"]!=null && dt.Rows[n]["StoreTypeName2"].ToString()!="")
					{
					model.StoreTypeName2=dt.Rows[n]["StoreTypeName2"].ToString();
					}
					if(dt.Rows[n]["StoreTypeName3"]!=null && dt.Rows[n]["StoreTypeName3"].ToString()!="")
					{
					model.StoreTypeName3=dt.Rows[n]["StoreTypeName3"].ToString();
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
					if(dt.Rows[n]["StoreTypeCode"]!=null && dt.Rows[n]["StoreTypeCode"].ToString()!="")
					{
					model.StoreTypeCode=dt.Rows[n]["StoreTypeCode"].ToString();
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
        /// <summary>
        /// 获取分页总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

