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
	/// 会员地址表
	/// </summary>
	public partial class MemberCompanyStore
	{
		private readonly IMemberCompanyStore dal=DataAccess.CreateMemberCompanyStore();
		public MemberCompanyStore()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StoreCode,string CompanyID)
		{
			return dal.Exists(StoreCode,CompanyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.MemberCompanyStore model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.MemberCompanyStore model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StoreCode,string CompanyID)
		{
			
			return dal.Delete(StoreCode,CompanyID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.MemberCompanyStore GetModel(string StoreCode,string CompanyID)
		{
			
			return dal.GetModel(StoreCode,CompanyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.MemberCompanyStore GetModelByCache(string StoreCode,string CompanyID)
		{
			
			string CacheKey = "MemberCompanyStoreModel-" + StoreCode+CompanyID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StoreCode,CompanyID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.MemberCompanyStore)objModel;
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
		public List<Edge.SVA.Model.MemberCompanyStore> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.MemberCompanyStore> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.MemberCompanyStore> modelList = new List<Edge.SVA.Model.MemberCompanyStore>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.MemberCompanyStore model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.MemberCompanyStore();
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["StoreName"]!=null && dt.Rows[n]["StoreName"].ToString()!="")
					{
					model.StoreName=dt.Rows[n]["StoreName"].ToString();
					}
					if(dt.Rows[n]["CompanyID"]!=null && dt.Rows[n]["CompanyID"].ToString()!="")
					{
					model.CompanyID=dt.Rows[n]["CompanyID"].ToString();
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
					model.CreatedBy=dt.Rows[n]["CreatedBy"].ToString();
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

