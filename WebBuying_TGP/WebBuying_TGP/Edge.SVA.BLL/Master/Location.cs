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
	/// 区域
	/// </summary>
	public partial class Location
	{
		private readonly ILocation dal=DataAccess.CreateLocation();
		public Location()
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
		public bool Exists(int LocationID)
		{
			return dal.Exists(LocationID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Location model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Location model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LocationID)
		{
			
			return dal.Delete(LocationID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string LocationIDlist )
		{
			return dal.DeleteList(LocationIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Location GetModel(int LocationID)
		{
			
			return dal.GetModel(LocationID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Location GetModelByCache(int LocationID)
		{
			
			string CacheKey = "LocationModel-" + LocationID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(LocationID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Location)objModel;
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
		public List<Edge.SVA.Model.Location> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Location> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Location> modelList = new List<Edge.SVA.Model.Location>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Location model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Location();
					if(dt.Rows[n]["LocationID"]!=null && dt.Rows[n]["LocationID"].ToString()!="")
					{
						model.LocationID=int.Parse(dt.Rows[n]["LocationID"].ToString());
					}
					if(dt.Rows[n]["ParentLoactionID"]!=null && dt.Rows[n]["ParentLoactionID"].ToString()!="")
					{
						model.ParentLoactionID=int.Parse(dt.Rows[n]["ParentLoactionID"].ToString());
					}
					if(dt.Rows[n]["LocationName1"]!=null && dt.Rows[n]["LocationName1"].ToString()!="")
					{
					model.LocationName1=dt.Rows[n]["LocationName1"].ToString();
					}
					if(dt.Rows[n]["LocationName2"]!=null && dt.Rows[n]["LocationName2"].ToString()!="")
					{
					model.LocationName2=dt.Rows[n]["LocationName2"].ToString();
					}
					if(dt.Rows[n]["LocationName3"]!=null && dt.Rows[n]["LocationName3"].ToString()!="")
					{
					model.LocationName3=dt.Rows[n]["LocationName3"].ToString();
					}
					if(dt.Rows[n]["LocationType"]!=null && dt.Rows[n]["LocationType"].ToString()!="")
					{
						model.LocationType=int.Parse(dt.Rows[n]["LocationType"].ToString());
					}
					if(dt.Rows[n]["Lotitude"]!=null && dt.Rows[n]["Lotitude"].ToString()!="")
					{
					model.Lotitude=dt.Rows[n]["Lotitude"].ToString();
					}
					if(dt.Rows[n]["Longitude"]!=null && dt.Rows[n]["Longitude"].ToString()!="")
					{
					model.Longitude=dt.Rows[n]["Longitude"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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
					if(dt.Rows[n]["LocationFullPath"]!=null && dt.Rows[n]["LocationFullPath"].ToString()!="")
					{
					model.LocationFullPath=dt.Rows[n]["LocationFullPath"].ToString();
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

