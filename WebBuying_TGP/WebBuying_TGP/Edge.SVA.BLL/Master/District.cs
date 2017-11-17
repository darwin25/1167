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
	/// 区县资料表。（city下一级。中国第三级行政区
	/// </summary>
	public partial class District
	{
		private readonly IDistrict dal=DataAccess.CreateDistrict();
		public District()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DistrictCode)
		{
			return dal.Exists(DistrictCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.District model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.District model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DistrictCode)
		{
			
			return dal.Delete(DistrictCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DistrictCodelist )
		{
			return dal.DeleteList(DistrictCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.District GetModel(string DistrictCode)
		{
			
			return dal.GetModel(DistrictCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.District GetModelByCache(string DistrictCode)
		{
			
			string CacheKey = "DistrictModel-" + DistrictCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DistrictCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.District)objModel;
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
		public List<Edge.SVA.Model.District> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.District> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.District> modelList = new List<Edge.SVA.Model.District>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.District model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.District();
					if(dt.Rows[n]["DistrictCode"]!=null && dt.Rows[n]["DistrictCode"].ToString()!="")
					{
					model.DistrictCode=dt.Rows[n]["DistrictCode"].ToString();
					}
					if(dt.Rows[n]["CityCode"]!=null && dt.Rows[n]["CityCode"].ToString()!="")
					{
					model.CityCode=dt.Rows[n]["CityCode"].ToString();
					}
					if(dt.Rows[n]["DistrictName1"]!=null && dt.Rows[n]["DistrictName1"].ToString()!="")
					{
					model.DistrictName1=dt.Rows[n]["DistrictName1"].ToString();
					}
					if(dt.Rows[n]["DistrictName2"]!=null && dt.Rows[n]["DistrictName2"].ToString()!="")
					{
					model.DistrictName2=dt.Rows[n]["DistrictName2"].ToString();
					}
					if(dt.Rows[n]["DistrictName3"]!=null && dt.Rows[n]["DistrictName3"].ToString()!="")
					{
					model.DistrictName3=dt.Rows[n]["DistrictName3"].ToString();
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

