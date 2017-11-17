using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
using Edge.SVA.Model.Domain.WebBuying;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 店铺补货设置。从表
    /// 创建人:Lisa
    /// 创建时间：2016-07-13
	/// </summary>
	public partial class BUY_REPLEN_D
	{
		private readonly IBUY_REPLEN_D dal=DataAccess.CreateBUY_REPLEN_D();
		public BUY_REPLEN_D()
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
		public bool Exists(int KeyID)
		{
			return dal.Exists(KeyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_REPLEN_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_REPLEN_D model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int KeyID)
		{
			
			return dal.Delete(KeyID);
		}

        public bool Delete(string ReplenCode)
        {
            return dal.Delete(ReplenCode);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string KeyIDlist )
		{
			return dal.DeleteList(KeyIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_REPLEN_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_REPLEN_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_REPLEN_DModel-" + KeyID;
            object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(KeyID);
					if (objModel != null)
					{
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_REPLEN_D)objModel;
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
		public List<Edge.SVA.Model.BUY_REPLEN_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_REPLEN_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_REPLEN_D> modelList = new List<Edge.SVA.Model.BUY_REPLEN_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_REPLEN_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_REPLEN_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["ReplenCode"]!=null && dt.Rows[n]["ReplenCode"].ToString()!="")
					{
					model.ReplenCode=dt.Rows[n]["ReplenCode"].ToString();
					}
					if(dt.Rows[n]["EntityType"]!=null && dt.Rows[n]["EntityType"].ToString()!="")
					{
						model.EntityType=int.Parse(dt.Rows[n]["EntityType"].ToString());
					}
					if(dt.Rows[n]["EntityCode"]!=null && dt.Rows[n]["EntityCode"].ToString()!="")
					{
					model.EntityCode=dt.Rows[n]["EntityCode"].ToString();
					}
					if(dt.Rows[n]["MinStockQty"]!=null && dt.Rows[n]["MinStockQty"].ToString()!="")
					{
						model.MinStockQty=int.Parse(dt.Rows[n]["MinStockQty"].ToString());
					}
					if(dt.Rows[n]["RunningStockQty"]!=null && dt.Rows[n]["RunningStockQty"].ToString()!="")
					{
						model.RunningStockQty=int.Parse(dt.Rows[n]["RunningStockQty"].ToString());
					}
					if(dt.Rows[n]["OrderRoundUpQty"]!=null && dt.Rows[n]["OrderRoundUpQty"].ToString()!="")
					{
						model.OrderRoundUpQty=int.Parse(dt.Rows[n]["OrderRoundUpQty"].ToString());
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

