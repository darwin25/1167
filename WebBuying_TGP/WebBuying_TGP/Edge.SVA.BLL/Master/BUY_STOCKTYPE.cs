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
	/// 库存类型表
	/// </summary>
	public partial class BUY_STOCKTYPE
	{
		private readonly IBUY_STOCKTYPE dal=DataAccess.CreateBUY_STOCKTYPE();
		public BUY_STOCKTYPE()
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
		public bool Exists(string StockTypeCode,int StockTypeID)
		{
			return dal.Exists(StockTypeCode,StockTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_STOCKTYPE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_STOCKTYPE model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StockTypeID)
		{
			
			return dal.Delete(StockTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StockTypeCode,int StockTypeID)
		{
			
			return dal.Delete(StockTypeCode,StockTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StockTypeIDlist )
		{
			return dal.DeleteList(StockTypeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_STOCKTYPE GetModel(int StockTypeID)
		{
			
			return dal.GetModel(StockTypeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_STOCKTYPE GetModelByCache(int StockTypeID)
		{
			
			string CacheKey = "BUY_STOCKTYPEModel-" + StockTypeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StockTypeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_STOCKTYPE)objModel;
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
		public List<Edge.SVA.Model.BUY_STOCKTYPE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_STOCKTYPE> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_STOCKTYPE> modelList = new List<Edge.SVA.Model.BUY_STOCKTYPE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_STOCKTYPE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_STOCKTYPE();
					if(dt.Rows[n]["StockTypeID"]!=null && dt.Rows[n]["StockTypeID"].ToString()!="")
					{
						model.StockTypeID=int.Parse(dt.Rows[n]["StockTypeID"].ToString());
					}
					if(dt.Rows[n]["StockTypeCode"]!=null && dt.Rows[n]["StockTypeCode"].ToString()!="")
					{
					model.StockTypeCode=dt.Rows[n]["StockTypeCode"].ToString();
					}
					if(dt.Rows[n]["StockTypeName1"]!=null && dt.Rows[n]["StockTypeName1"].ToString()!="")
					{
					model.StockTypeName1=dt.Rows[n]["StockTypeName1"].ToString();
					}
					if(dt.Rows[n]["StockTypeName2"]!=null && dt.Rows[n]["StockTypeName2"].ToString()!="")
					{
					model.StockTypeName2=dt.Rows[n]["StockTypeName2"].ToString();
					}
					if(dt.Rows[n]["StockTypeName3"]!=null && dt.Rows[n]["StockTypeName3"].ToString()!="")
					{
					model.StockTypeName3=dt.Rows[n]["StockTypeName3"].ToString();
					}
					if(dt.Rows[n]["NeedSerialno"]!=null && dt.Rows[n]["NeedSerialno"].ToString()!="")
					{
						model.NeedSerialno=int.Parse(dt.Rows[n]["NeedSerialno"].ToString());
					}
					if(dt.Rows[n]["SubInvSuffix"]!=null && dt.Rows[n]["SubInvSuffix"].ToString()!="")
					{
					model.SubInvSuffix=dt.Rows[n]["SubInvSuffix"].ToString();
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

