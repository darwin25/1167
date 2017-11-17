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
	/// 供货仓库表
	/// </summary>
	public partial class BUY_FULFILLMENTHOUSE
	{
		private readonly IBUY_FULFILLMENTHOUSE dal=DataAccess.CreateBUY_FULFILLMENTHOUSE();
		public BUY_FULFILLMENTHOUSE()
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
		public bool Exists(string FulfillmentHouseCode,int FulfillmentHouseID)
		{
			return dal.Exists(FulfillmentHouseCode,FulfillmentHouseID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_FULFILLMENTHOUSE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_FULFILLMENTHOUSE model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FulfillmentHouseID)
		{
			
			return dal.Delete(FulfillmentHouseID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string FulfillmentHouseCode,int FulfillmentHouseID)
		{
			
			return dal.Delete(FulfillmentHouseCode,FulfillmentHouseID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string FulfillmentHouseIDlist )
		{
			return dal.DeleteList(FulfillmentHouseIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_FULFILLMENTHOUSE GetModel(int FulfillmentHouseID)
		{
			
			return dal.GetModel(FulfillmentHouseID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_FULFILLMENTHOUSE GetModelByCache(int FulfillmentHouseID)
		{
			
			string CacheKey = "BUY_FULFILLMENTHOUSEModel-" + FulfillmentHouseID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(FulfillmentHouseID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_FULFILLMENTHOUSE)objModel;
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
		public List<Edge.SVA.Model.BUY_FULFILLMENTHOUSE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_FULFILLMENTHOUSE> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_FULFILLMENTHOUSE> modelList = new List<Edge.SVA.Model.BUY_FULFILLMENTHOUSE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_FULFILLMENTHOUSE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_FULFILLMENTHOUSE();
					if(dt.Rows[n]["FulfillmentHouseID"]!=null && dt.Rows[n]["FulfillmentHouseID"].ToString()!="")
					{
						model.FulfillmentHouseID=int.Parse(dt.Rows[n]["FulfillmentHouseID"].ToString());
					}
					if(dt.Rows[n]["FulfillmentHouseCode"]!=null && dt.Rows[n]["FulfillmentHouseCode"].ToString()!="")
					{
					model.FulfillmentHouseCode=dt.Rows[n]["FulfillmentHouseCode"].ToString();
					}
					if(dt.Rows[n]["FulfillmentHouseName1"]!=null && dt.Rows[n]["FulfillmentHouseName1"].ToString()!="")
					{
					model.FulfillmentHouseName1=dt.Rows[n]["FulfillmentHouseName1"].ToString();
					}
					if(dt.Rows[n]["FulfillmentHouseName2"]!=null && dt.Rows[n]["FulfillmentHouseName2"].ToString()!="")
					{
					model.FulfillmentHouseName2=dt.Rows[n]["FulfillmentHouseName2"].ToString();
					}
					if(dt.Rows[n]["FulfillmentHouseName3"]!=null && dt.Rows[n]["FulfillmentHouseName3"].ToString()!="")
					{
					model.FulfillmentHouseName3=dt.Rows[n]["FulfillmentHouseName3"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["Priority"]!=null && dt.Rows[n]["Priority"].ToString()!="")
					{
						model.Priority=int.Parse(dt.Rows[n]["Priority"].ToString());
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

