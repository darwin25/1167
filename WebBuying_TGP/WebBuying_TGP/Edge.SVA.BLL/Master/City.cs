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
	/// 市资料表。（省下一级
	/// </summary>
	public partial class City
	{
		private readonly ICity dal=DataAccess.CreateCity();
		public City()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CityCode)
		{
			return dal.Exists(CityCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.City model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.City model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CityCode)
		{
			
			return dal.Delete(CityCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CityCodelist )
		{
			return dal.DeleteList(CityCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.City GetModel(string CityCode)
		{
			
			return dal.GetModel(CityCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.City GetModelByCache(string CityCode)
		{
			
			string CacheKey = "CityModel-" + CityCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CityCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.City)objModel;
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
		public List<Edge.SVA.Model.City> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.City> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.City> modelList = new List<Edge.SVA.Model.City>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.City model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.City();
					if(dt.Rows[n]["CityCode"]!=null && dt.Rows[n]["CityCode"].ToString()!="")
					{
					model.CityCode=dt.Rows[n]["CityCode"].ToString();
					}
					if(dt.Rows[n]["ProvinceCode"]!=null && dt.Rows[n]["ProvinceCode"].ToString()!="")
					{
					model.ProvinceCode=dt.Rows[n]["ProvinceCode"].ToString();
					}
					if(dt.Rows[n]["CityName1"]!=null && dt.Rows[n]["CityName1"].ToString()!="")
					{
					model.CityName1=dt.Rows[n]["CityName1"].ToString();
					}
					if(dt.Rows[n]["CityName2"]!=null && dt.Rows[n]["CityName2"].ToString()!="")
					{
					model.CityName2=dt.Rows[n]["CityName2"].ToString();
					}
					if(dt.Rows[n]["CityName3"]!=null && dt.Rows[n]["CityName3"].ToString()!="")
					{
					model.CityName3=dt.Rows[n]["CityName3"].ToString();
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

