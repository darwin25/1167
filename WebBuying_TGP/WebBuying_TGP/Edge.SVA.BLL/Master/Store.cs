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
	/// 店铺表
	/// </summary>
	public partial class Store
	{
		private readonly IStore dal=DataAccess.CreateStore();
		public Store()
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
		public bool Exists(int StoreID)
		{
			return dal.Exists(StoreID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Store model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Store model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StoreID)
		{
			
			return dal.Delete(StoreID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StoreIDlist )
		{
			return dal.DeleteList(StoreIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Store GetModel(int StoreID)
		{
			
			return dal.GetModel(StoreID);
		}
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Store GetModelByCache(int StoreID)
		{
			
			string CacheKey = "StoreModel-" + StoreID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Store)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            strWhere = SessionChangeBrandIDsStr(strWhere);
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
        {
            strWhere = SessionChangeBrandIDsStr(strWhere);
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Store> GetModelList(string strWhere)
        {
            strWhere = SessionChangeBrandIDsStr(strWhere);
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Store> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Store> modelList = new List<Edge.SVA.Model.Store>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Store model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Store();
					if(dt.Rows[n]["StoreID"]!=null && dt.Rows[n]["StoreID"].ToString()!="")
					{
						model.StoreID=int.Parse(dt.Rows[n]["StoreID"].ToString());
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["StoreName1"]!=null && dt.Rows[n]["StoreName1"].ToString()!="")
					{
					model.StoreName1=dt.Rows[n]["StoreName1"].ToString();
					}
					if(dt.Rows[n]["StoreName2"]!=null && dt.Rows[n]["StoreName2"].ToString()!="")
					{
					model.StoreName2=dt.Rows[n]["StoreName2"].ToString();
					}
					if(dt.Rows[n]["StoreName3"]!=null && dt.Rows[n]["StoreName3"].ToString()!="")
					{
					model.StoreName3=dt.Rows[n]["StoreName3"].ToString();
					}
					if(dt.Rows[n]["StoreTypeID"]!=null && dt.Rows[n]["StoreTypeID"].ToString()!="")
					{
						model.StoreTypeID=int.Parse(dt.Rows[n]["StoreTypeID"].ToString());
					}
					if(dt.Rows[n]["StoreGroupID"]!=null && dt.Rows[n]["StoreGroupID"].ToString()!="")
					{
						model.StoreGroupID=int.Parse(dt.Rows[n]["StoreGroupID"].ToString());
					}
					if(dt.Rows[n]["BankID"]!=null && dt.Rows[n]["BankID"].ToString()!="")
					{
						model.BankID=int.Parse(dt.Rows[n]["BankID"].ToString());
					}
					if(dt.Rows[n]["StoreCountry"]!=null && dt.Rows[n]["StoreCountry"].ToString()!="")
					{
					model.StoreCountry=dt.Rows[n]["StoreCountry"].ToString();
					}
					if(dt.Rows[n]["StoreProvince"]!=null && dt.Rows[n]["StoreProvince"].ToString()!="")
					{
					model.StoreProvince=dt.Rows[n]["StoreProvince"].ToString();
					}
					if(dt.Rows[n]["StoreCity"]!=null && dt.Rows[n]["StoreCity"].ToString()!="")
					{
					model.StoreCity=dt.Rows[n]["StoreCity"].ToString();
					}
					if(dt.Rows[n]["StoreAddressDetail"]!=null && dt.Rows[n]["StoreAddressDetail"].ToString()!="")
					{
					model.StoreAddressDetail=dt.Rows[n]["StoreAddressDetail"].ToString();
					}
					if(dt.Rows[n]["StoreTel"]!=null && dt.Rows[n]["StoreTel"].ToString()!="")
					{
					model.StoreTel=dt.Rows[n]["StoreTel"].ToString();
					}
					if(dt.Rows[n]["StoreFax"]!=null && dt.Rows[n]["StoreFax"].ToString()!="")
					{
					model.StoreFax=dt.Rows[n]["StoreFax"].ToString();
					}
					if(dt.Rows[n]["StoreLongitude"]!=null && dt.Rows[n]["StoreLongitude"].ToString()!="")
					{
					model.StoreLongitude=dt.Rows[n]["StoreLongitude"].ToString();
					}
					if(dt.Rows[n]["StoreLatitude"]!=null && dt.Rows[n]["StoreLatitude"].ToString()!="")
					{
					model.StoreLatitude=dt.Rows[n]["StoreLatitude"].ToString();
					}
					if(dt.Rows[n]["LocationID"]!=null && dt.Rows[n]["LocationID"].ToString()!="")
					{
						model.LocationID=int.Parse(dt.Rows[n]["LocationID"].ToString());
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
					if(dt.Rows[n]["StoreNote"]!=null && dt.Rows[n]["StoreNote"].ToString()!="")
					{
					model.StoreNote=dt.Rows[n]["StoreNote"].ToString();
					}
					if(dt.Rows[n]["StoreOpenTime"]!=null && dt.Rows[n]["StoreOpenTime"].ToString()!="")
					{
					model.StoreOpenTime=dt.Rows[n]["StoreOpenTime"].ToString();
					}
					if(dt.Rows[n]["StoreCloseTime"]!=null && dt.Rows[n]["StoreCloseTime"].ToString()!="")
					{
					model.StoreCloseTime=dt.Rows[n]["StoreCloseTime"].ToString();
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["StorePicFile"]!=null && dt.Rows[n]["StorePicFile"].ToString()!="")
					{
					model.StorePicFile=dt.Rows[n]["StorePicFile"].ToString();
					}
					if(dt.Rows[n]["MapsPicFile"]!=null && dt.Rows[n]["MapsPicFile"].ToString()!="")
					{
					model.MapsPicFile=dt.Rows[n]["MapsPicFile"].ToString();
					}
					if(dt.Rows[n]["MapsPicShadowFile"]!=null && dt.Rows[n]["MapsPicShadowFile"].ToString()!="")
					{
					model.MapsPicShadowFile=dt.Rows[n]["MapsPicShadowFile"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["Contact"]!=null && dt.Rows[n]["Contact"].ToString()!="")
					{
					model.Contact=dt.Rows[n]["Contact"].ToString();
					}
					if(dt.Rows[n]["ContactPhone"]!=null && dt.Rows[n]["ContactPhone"].ToString()!="")
					{
					model.ContactPhone=dt.Rows[n]["ContactPhone"].ToString();
					}
					if(dt.Rows[n]["StoreDistrict"]!=null && dt.Rows[n]["StoreDistrict"].ToString()!="")
					{
					model.StoreDistrict=dt.Rows[n]["StoreDistrict"].ToString();
					}
					if(dt.Rows[n]["StoreFullDetail"]!=null && dt.Rows[n]["StoreFullDetail"].ToString()!="")
					{
					model.StoreFullDetail=dt.Rows[n]["StoreFullDetail"].ToString();
					}
					if(dt.Rows[n]["StoreAddressDetail2"]!=null && dt.Rows[n]["StoreAddressDetail2"].ToString()!="")
					{
					model.StoreAddressDetail2=dt.Rows[n]["StoreAddressDetail2"].ToString();
					}
					if(dt.Rows[n]["StoreFullDetail2"]!=null && dt.Rows[n]["StoreFullDetail2"].ToString()!="")
					{
					model.StoreFullDetail2=dt.Rows[n]["StoreFullDetail2"].ToString();
					}
					if(dt.Rows[n]["StoreAddressDetail3"]!=null && dt.Rows[n]["StoreAddressDetail3"].ToString()!="")
					{
					model.StoreAddressDetail3=dt.Rows[n]["StoreAddressDetail3"].ToString();
					}
					if(dt.Rows[n]["StoreFullDetail3"]!=null && dt.Rows[n]["StoreFullDetail3"].ToString()!="")
					{
					model.StoreFullDetail3=dt.Rows[n]["StoreFullDetail3"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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
            strWhere = SessionChangeBrandIDsStr(strWhere);
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            strWhere = SessionChangeBrandIDsStr(strWhere);
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

