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
	/// 品牌表
	/// </summary>
	public partial class BUY_BRAND
	{
		private readonly IBUY_BRAND dal=DataAccess.CreateBUY_BRAND();
		public BUY_BRAND()
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
		public bool Exists(string BrandCode,int BrandID)
		{
			return dal.Exists(BrandCode,BrandID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_BRAND model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_BRAND model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BrandID)
		{
			
			return dal.Delete(BrandID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string BrandCode,int BrandID)
		{
			
			return dal.Delete(BrandCode,BrandID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BrandIDlist )
		{
			return dal.DeleteList(BrandIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_BRAND GetModel(int BrandID)
		{
			
			return dal.GetModel(BrandID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_BRAND GetModelByCache(int BrandID)
		{
			
			string CacheKey = "BUY_BRANDModel-" + BrandID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BrandID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_BRAND)objModel;
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
		public List<Edge.SVA.Model.BUY_BRAND> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_BRAND> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_BRAND> modelList = new List<Edge.SVA.Model.BUY_BRAND>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_BRAND model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_BRAND();
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["BrandCode"]!=null && dt.Rows[n]["BrandCode"].ToString()!="")
					{
					model.BrandCode=dt.Rows[n]["BrandCode"].ToString();
					}
					if(dt.Rows[n]["BrandName1"]!=null && dt.Rows[n]["BrandName1"].ToString()!="")
					{
					model.BrandName1=dt.Rows[n]["BrandName1"].ToString();
					}
					if(dt.Rows[n]["BrandName2"]!=null && dt.Rows[n]["BrandName2"].ToString()!="")
					{
					model.BrandName2=dt.Rows[n]["BrandName2"].ToString();
					}
					if(dt.Rows[n]["BrandName3"]!=null && dt.Rows[n]["BrandName3"].ToString()!="")
					{
					model.BrandName3=dt.Rows[n]["BrandName3"].ToString();
					}
					if(dt.Rows[n]["BrandDesc1"]!=null && dt.Rows[n]["BrandDesc1"].ToString()!="")
					{
					model.BrandDesc1=dt.Rows[n]["BrandDesc1"].ToString();
					}
					if(dt.Rows[n]["BrandDesc2"]!=null && dt.Rows[n]["BrandDesc2"].ToString()!="")
					{
					model.BrandDesc2=dt.Rows[n]["BrandDesc2"].ToString();
					}
					if(dt.Rows[n]["BrandDesc3"]!=null && dt.Rows[n]["BrandDesc3"].ToString()!="")
					{
					model.BrandDesc3=dt.Rows[n]["BrandDesc3"].ToString();
					}
					if(dt.Rows[n]["BrandPicSFile"]!=null && dt.Rows[n]["BrandPicSFile"].ToString()!="")
					{
					model.BrandPicSFile=dt.Rows[n]["BrandPicSFile"].ToString();
					}
					if(dt.Rows[n]["BrandPicMFile"]!=null && dt.Rows[n]["BrandPicMFile"].ToString()!="")
					{
					model.BrandPicMFile=dt.Rows[n]["BrandPicMFile"].ToString();
					}
					if(dt.Rows[n]["BrandPicGFile"]!=null && dt.Rows[n]["BrandPicGFile"].ToString()!="")
					{
					model.BrandPicGFile=dt.Rows[n]["BrandPicGFile"].ToString();
					}
					if(dt.Rows[n]["CardIssuerID"]!=null && dt.Rows[n]["CardIssuerID"].ToString()!="")
					{
						model.CardIssuerID=int.Parse(dt.Rows[n]["CardIssuerID"].ToString());
					}
					if(dt.Rows[n]["IndustryID"]!=null && dt.Rows[n]["IndustryID"].ToString()!="")
					{
						model.IndustryID=int.Parse(dt.Rows[n]["IndustryID"].ToString());
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

