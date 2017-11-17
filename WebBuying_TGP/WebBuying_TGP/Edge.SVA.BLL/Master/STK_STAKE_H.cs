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
	/// 盘点注册
	/// </summary>
	public partial class STK_STake_H
	{
		private readonly ISTK_STake_H dal=DataAccess.CreateSTK_STake_H();
		public STK_STake_H()
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
		public bool Exists(string StockTakeNumber,int StockTakeID)
		{
			return dal.Exists(StockTakeNumber,StockTakeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.STK_STake_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.STK_STake_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StockTakeID)
		{
			
			return dal.Delete(StockTakeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string StockTakeNumber,int StockTakeID)
		{
			
			return dal.Delete(StockTakeNumber,StockTakeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StockTakeIDlist )
		{
			return dal.DeleteList(StockTakeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.STK_STake_H GetModel(int StockTakeID)
		{
			
			return dal.GetModel(StockTakeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.STK_STake_H GetModelByCache(int StockTakeID)
		{
			
			string CacheKey = "STK_STake_HModel-" + StockTakeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(StockTakeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.STK_STake_H)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 根据条件查询列表
        /// 创建人：王丽
        /// 创建时间：2015-12-20
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="filedOrder"></param>
        /// <returns></returns>
        public DataSet GetListByParm(string strWhere, string filedOrder, string webSiteName, string type)
        {
            return dal.GetListByParm(strWhere, filedOrder, webSiteName,type);
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
		public List<Edge.SVA.Model.STK_STake_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.STK_STake_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.STK_STake_H> modelList = new List<Edge.SVA.Model.STK_STake_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.STK_STake_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.STK_STake_H();
					if(dt.Rows[n]["StockTakeID"]!=null && dt.Rows[n]["StockTakeID"].ToString()!="")
					{
						model.StockTakeID=int.Parse(dt.Rows[n]["StockTakeID"].ToString());
					}
					if(dt.Rows[n]["StockTakeNumber"]!=null && dt.Rows[n]["StockTakeNumber"].ToString()!="")
					{
					    model.StockTakeNumber=dt.Rows[n]["StockTakeNumber"].ToString();
					}
                    if (dt.Rows[n]["StockTakeDate"] != null && dt.Rows[n]["StockTakeDate"].ToString() != "")
                    {
                        model.StockTakeDate = DateTime.Parse(dt.Rows[n]["StockTakeDate"].ToString());
                    }
                    if (dt.Rows[n]["StoreID"] != null && dt.Rows[n]["StoreID"].ToString() != "")
                    {
                        model.StoreID = int.Parse(dt.Rows[n]["StoreID"].ToString());
                    }
                    if (dt.Rows[n]["Status"] != null && dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["StockTakeType"] != null && dt.Rows[n]["StockTakeType"].ToString() != "")
                    {
                        model.StockTakeType = int.Parse(dt.Rows[n]["StockTakeType"].ToString());
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
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

