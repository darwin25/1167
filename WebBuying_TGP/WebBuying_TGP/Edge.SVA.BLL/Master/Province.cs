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
	/// 省资料表。（中国一级行政区
	/// </summary>
	public partial class Province
	{
		private readonly IProvince dal=DataAccess.CreateProvince();
		public Province()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProvinceCode)
		{
			return dal.Exists(ProvinceCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Province model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Province model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProvinceCode)
		{
			
			return dal.Delete(ProvinceCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProvinceCodelist )
		{
			return dal.DeleteList(ProvinceCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Province GetModel(string ProvinceCode)
		{
			
			return dal.GetModel(ProvinceCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Province GetModelByCache(string ProvinceCode)
		{
			
			string CacheKey = "ProvinceModel-" + ProvinceCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProvinceCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Province)objModel;
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
		public List<Edge.SVA.Model.Province> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Province> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Province> modelList = new List<Edge.SVA.Model.Province>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Province model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Province();
					if(dt.Rows[n]["ProvinceCode"]!=null && dt.Rows[n]["ProvinceCode"].ToString()!="")
					{
					model.ProvinceCode=dt.Rows[n]["ProvinceCode"].ToString();
					}
					if(dt.Rows[n]["CountryCode"]!=null && dt.Rows[n]["CountryCode"].ToString()!="")
					{
					model.CountryCode=dt.Rows[n]["CountryCode"].ToString();
					}
					if(dt.Rows[n]["ProvinceName1"]!=null && dt.Rows[n]["ProvinceName1"].ToString()!="")
					{
					model.ProvinceName1=dt.Rows[n]["ProvinceName1"].ToString();
					}
					if(dt.Rows[n]["ProvinceName2"]!=null && dt.Rows[n]["ProvinceName2"].ToString()!="")
					{
					model.ProvinceName2=dt.Rows[n]["ProvinceName2"].ToString();
					}
					if(dt.Rows[n]["ProvinceName3"]!=null && dt.Rows[n]["ProvinceName3"].ToString()!="")
					{
					model.ProvinceName3=dt.Rows[n]["ProvinceName3"].ToString();
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

