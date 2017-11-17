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
	/// 货品大类
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCTCLASS_Pending
	{
		private readonly IBUY_PRODUCTCLASS_Pending dal=DataAccess.CreateBUY_PRODUCTCLASS_Pending();
		public BUY_PRODUCTCLASS_Pending()
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
		public bool Exists(string ProdClassCode,int ProdClassID)
		{
			return dal.Exists(ProdClassCode,ProdClassID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_PRODUCTCLASS_Pending model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCTCLASS_Pending model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProdClassID)
		{
			
			return dal.Delete(ProdClassID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdClassCode,int ProdClassID)
		{
			
			return dal.Delete(ProdClassCode,ProdClassID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProdClassIDlist )
		{
			return dal.DeleteList(ProdClassIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCTCLASS_Pending GetModel(int ProdClassID)
		{
			
			return dal.GetModel(ProdClassID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCTCLASS_Pending GetModelByCache(int ProdClassID)
		{
			
			string CacheKey = "BUY_PRODUCTCLASS_PendingModel-" + ProdClassID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProdClassID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_PRODUCTCLASS_Pending)objModel;
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
		public List<Edge.SVA.Model.BUY_PRODUCTCLASS_Pending> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PRODUCTCLASS_Pending> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PRODUCTCLASS_Pending> modelList = new List<Edge.SVA.Model.BUY_PRODUCTCLASS_Pending>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PRODUCTCLASS_Pending model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PRODUCTCLASS_Pending();
					if(dt.Rows[n]["ProdClassID"]!=null && dt.Rows[n]["ProdClassID"].ToString()!="")
					{
						model.ProdClassID=int.Parse(dt.Rows[n]["ProdClassID"].ToString());
					}
					if(dt.Rows[n]["ProdClassCode"]!=null && dt.Rows[n]["ProdClassCode"].ToString()!="")
					{
					model.ProdClassCode=dt.Rows[n]["ProdClassCode"].ToString();
					}
					if(dt.Rows[n]["ParentID"]!=null && dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=int.Parse(dt.Rows[n]["ParentID"].ToString());
					}
					if(dt.Rows[n]["ProductSizeType"]!=null && dt.Rows[n]["ProductSizeType"].ToString()!="")
					{
					model.ProductSizeType=dt.Rows[n]["ProductSizeType"].ToString();
					}
					if(dt.Rows[n]["ProdClassDesc1"]!=null && dt.Rows[n]["ProdClassDesc1"].ToString()!="")
					{
					model.ProdClassDesc1=dt.Rows[n]["ProdClassDesc1"].ToString();
					}
					if(dt.Rows[n]["ProdClassDesc2"]!=null && dt.Rows[n]["ProdClassDesc2"].ToString()!="")
					{
					model.ProdClassDesc2=dt.Rows[n]["ProdClassDesc2"].ToString();
					}
					if(dt.Rows[n]["ProdClassDesc3"]!=null && dt.Rows[n]["ProdClassDesc3"].ToString()!="")
					{
					model.ProdClassDesc3=dt.Rows[n]["ProdClassDesc3"].ToString();
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

