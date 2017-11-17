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
	/// 店铺表。
	/// </summary>
	public partial class BUY_STORE
	{
		private readonly IBUY_STORE dal=DataAccess.CreateBUY_STORE();
		public BUY_STORE()
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
		public bool Exists(string StoreCode,int StoreID)
		{
			return dal.Exists(StoreCode,StoreID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_STORE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_STORE model)
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
		public bool Delete(string StoreCode,int StoreID)
		{
			
			return dal.Delete(StoreCode,StoreID);
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
		public Edge.SVA.Model.BUY_STORE GetModel(int StoreID)
		{
			
			return dal.GetModel(StoreID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_STORE GetModelByCache(int StoreID)
		{
			
			string CacheKey = "BUY_STOREModel-" + StoreID;
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
			return (Edge.SVA.Model.BUY_STORE)objModel;
		}
         /// <summary>
        /// 根据编号得到名字
        /// 创建人:LISA
        /// 创建时间：201-06-02
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Edge.SVA.Model.BUY_STORE GetStoreByCode(string code)
        {
            return dal.GetStoreByCode(code);
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
		public List<Edge.SVA.Model.BUY_STORE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        public int GetStoreIDByUser(string UserName)
        {
            return dal.GetStoreIDByUser(UserName);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_STORE> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_STORE> modelList = new List<Edge.SVA.Model.BUY_STORE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_STORE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_STORE();
					if(dt.Rows[n]["StoreID"]!=null && dt.Rows[n]["StoreID"].ToString()!="")
					{
						model.StoreID=int.Parse(dt.Rows[n]["StoreID"].ToString());
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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
					if(dt.Rows[n]["BankCode"]!=null && dt.Rows[n]["BankCode"].ToString()!="")
					{
					model.BankCode=dt.Rows[n]["BankCode"].ToString();
					}
                    if (dt.Rows[n]["StoreBrandCode"] != null && dt.Rows[n]["StoreBrandCode"].ToString() != "")
					{
                        model.StoreBrandCode = dt.Rows[n]["StoreBrandCode"].ToString();
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
					if(dt.Rows[n]["StoreDistrict"]!=null && dt.Rows[n]["StoreDistrict"].ToString()!="")
					{
					model.StoreDistrict=dt.Rows[n]["StoreDistrict"].ToString();
					}
					if(dt.Rows[n]["StoreAddressDetail1"]!=null && dt.Rows[n]["StoreAddressDetail1"].ToString()!="")
					{
					model.StoreAddressDetail1=dt.Rows[n]["StoreAddressDetail1"].ToString();
					}
					if(dt.Rows[n]["StoreAddressDetail2"]!=null && dt.Rows[n]["StoreAddressDetail2"].ToString()!="")
					{
					model.StoreAddressDetail2=dt.Rows[n]["StoreAddressDetail2"].ToString();
					}
					if(dt.Rows[n]["StoreAddressDetail3"]!=null && dt.Rows[n]["StoreAddressDetail3"].ToString()!="")
					{
					model.StoreAddressDetail3=dt.Rows[n]["StoreAddressDetail3"].ToString();
					}
					if(dt.Rows[n]["StoreFullDetail1"]!=null && dt.Rows[n]["StoreFullDetail1"].ToString()!="")
					{
					model.StoreFullDetail1=dt.Rows[n]["StoreFullDetail1"].ToString();
					}
					if(dt.Rows[n]["StoreFullDetail2"]!=null && dt.Rows[n]["StoreFullDetail2"].ToString()!="")
					{
					model.StoreFullDetail2=dt.Rows[n]["StoreFullDetail2"].ToString();
					}
					if(dt.Rows[n]["StoreFullDetail3"]!=null && dt.Rows[n]["StoreFullDetail3"].ToString()!="")
					{
					model.StoreFullDetail3=dt.Rows[n]["StoreFullDetail3"].ToString();
					}
					if(dt.Rows[n]["StoreTel"]!=null && dt.Rows[n]["StoreTel"].ToString()!="")
					{
					model.StoreTel=dt.Rows[n]["StoreTel"].ToString();
					}
					if(dt.Rows[n]["StoreFax"]!=null && dt.Rows[n]["StoreFax"].ToString()!="")
					{
					model.StoreFax=dt.Rows[n]["StoreFax"].ToString();
					}
					if(dt.Rows[n]["StoreEmail"]!=null && dt.Rows[n]["StoreEmail"].ToString()!="")
					{
					model.StoreEmail=dt.Rows[n]["StoreEmail"].ToString();
					}
					if(dt.Rows[n]["Contact"]!=null && dt.Rows[n]["Contact"].ToString()!="")
					{
					model.Contact=dt.Rows[n]["Contact"].ToString();
					}
					if(dt.Rows[n]["ContactPhone"]!=null && dt.Rows[n]["ContactPhone"].ToString()!="")
					{
					model.ContactPhone=dt.Rows[n]["ContactPhone"].ToString();
					}
					if(dt.Rows[n]["StoreLongitude"]!=null && dt.Rows[n]["StoreLongitude"].ToString()!="")
					{
					model.StoreLongitude=dt.Rows[n]["StoreLongitude"].ToString();
					}
					if(dt.Rows[n]["StoreLatitude"]!=null && dt.Rows[n]["StoreLatitude"].ToString()!="")
					{
					model.StoreLatitude=dt.Rows[n]["StoreLatitude"].ToString();
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
					if(dt.Rows[n]["LocationCode"]!=null && dt.Rows[n]["LocationCode"].ToString()!="")
					{
						model.LocationCode=int.Parse(dt.Rows[n]["LocationCode"].ToString());
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
					if(dt.Rows[n]["Comparable"]!=null && dt.Rows[n]["Comparable"].ToString()!="")
					{
						model.Comparable=int.Parse(dt.Rows[n]["Comparable"].ToString());
					}
					if(dt.Rows[n]["GLCode"]!=null && dt.Rows[n]["GLCode"].ToString()!="")
					{
					model.GLCode=dt.Rows[n]["GLCode"].ToString();
					}
					if(dt.Rows[n]["RegionCode"]!=null && dt.Rows[n]["RegionCode"].ToString()!="")
					{
					model.RegionCode=dt.Rows[n]["RegionCode"].ToString();
					}
					if(dt.Rows[n]["OrgCode"]!=null && dt.Rows[n]["OrgCode"].ToString()!="")
					{
					model.OrgCode=dt.Rows[n]["OrgCode"].ToString();
					}
					if(dt.Rows[n]["StoreIP"]!=null && dt.Rows[n]["StoreIP"].ToString()!="")
					{
					model.StoreIP=dt.Rows[n]["StoreIP"].ToString();
					}
					if(dt.Rows[n]["SubInvCode"]!=null && dt.Rows[n]["SubInvCode"].ToString()!="")
					{
					model.SubInvCode=dt.Rows[n]["SubInvCode"].ToString();
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

