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
	/// 国家表
	/// </summary>
	public partial class Nation
	{
		private readonly INation dal=DataAccess.CreateNation();
		public Nation()
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
		public bool Exists(string NationCode,int NationID)
		{
			return dal.Exists(NationCode,NationID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Nation model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Nation model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int NationID)
		{
			
			return dal.Delete(NationID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string NationCode,int NationID)
		{
			
			return dal.Delete(NationCode,NationID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string NationIDlist )
		{
			return dal.DeleteList(NationIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Nation GetModel(int NationID)
		{
			
			return dal.GetModel(NationID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Nation GetModelByCache(int NationID)
		{
			
			string CacheKey = "NationModel-" + NationID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NationID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Nation)objModel;
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
		public List<Edge.SVA.Model.Nation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Nation> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Nation> modelList = new List<Edge.SVA.Model.Nation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Nation model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Nation();
					if(dt.Rows[n]["NationID"]!=null && dt.Rows[n]["NationID"].ToString()!="")
					{
						model.NationID=int.Parse(dt.Rows[n]["NationID"].ToString());
					}
					if(dt.Rows[n]["NationCode"]!=null && dt.Rows[n]["NationCode"].ToString()!="")
					{
					model.NationCode=dt.Rows[n]["NationCode"].ToString();
					}
					if(dt.Rows[n]["CountryCode"]!=null && dt.Rows[n]["CountryCode"].ToString()!="")
					{
					model.CountryCode=dt.Rows[n]["CountryCode"].ToString();
					}
					if(dt.Rows[n]["NationName1"]!=null && dt.Rows[n]["NationName1"].ToString()!="")
					{
					model.NationName1=dt.Rows[n]["NationName1"].ToString();
					}
					if(dt.Rows[n]["NationName2"]!=null && dt.Rows[n]["NationName2"].ToString()!="")
					{
					model.NationName2=dt.Rows[n]["NationName2"].ToString();
					}
					if(dt.Rows[n]["NationName3"]!=null && dt.Rows[n]["NationName3"].ToString()!="")
					{
					model.NationName3=dt.Rows[n]["NationName3"].ToString();
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

