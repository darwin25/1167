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
	/// 国家资料表
	/// </summary>
	public partial class Country
	{
		private readonly ICountry dal=DataAccess.CreateCountry();
		public Country()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CountryCode)
		{
			return dal.Exists(CountryCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Country model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Country model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CountryCode)
		{
			
			return dal.Delete(CountryCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CountryCodelist )
		{
			return dal.DeleteList(CountryCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Country GetModel(string CountryCode)
		{
			
			return dal.GetModel(CountryCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Country GetModelByCache(string CountryCode)
		{
			
			string CacheKey = "CountryModel-" + CountryCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CountryCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Country)objModel;
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
		public List<Edge.SVA.Model.Country> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Country> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Country> modelList = new List<Edge.SVA.Model.Country>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Country model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Country();
					if(dt.Rows[n]["CountryCode"]!=null && dt.Rows[n]["CountryCode"].ToString()!="")
					{
					model.CountryCode=dt.Rows[n]["CountryCode"].ToString();
					}
					if(dt.Rows[n]["CountryName1"]!=null && dt.Rows[n]["CountryName1"].ToString()!="")
					{
					model.CountryName1=dt.Rows[n]["CountryName1"].ToString();
					}
					if(dt.Rows[n]["CountryName2"]!=null && dt.Rows[n]["CountryName2"].ToString()!="")
					{
					model.CountryName2=dt.Rows[n]["CountryName2"].ToString();
					}
					if(dt.Rows[n]["CountryName3"]!=null && dt.Rows[n]["CountryName3"].ToString()!="")
					{
					model.CountryName3=dt.Rows[n]["CountryName3"].ToString();
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

