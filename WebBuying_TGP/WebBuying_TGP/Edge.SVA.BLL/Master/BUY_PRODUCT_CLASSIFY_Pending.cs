﻿using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 货品划分。（辅助表。 货品和其他表配合)
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCT_CLASSIFY_Pending
	{
		private readonly IBUY_PRODUCT_CLASSIFY_Pending dal=DataAccess.CreateBUY_PRODUCT_CLASSIFY_Pending();
		public BUY_PRODUCT_CLASSIFY_Pending()
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
		public bool Exists(string ProdCode,int ForeignkeyID,string ForeignTable)
		{
			return dal.Exists(ProdCode,ForeignkeyID,ForeignTable);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending model)
		{
			return dal.Add(model);
		}
        public bool Add(string ProdCode)
        {
            return dal.Add(ProdCode);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdCode,int ForeignkeyID,string ForeignTable)
		{
			
			return dal.Delete(ProdCode,ForeignkeyID,ForeignTable);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ProdCode)
        {

            return dal.Delete(ProdCode);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending GetModel(string ProdCode,int ForeignkeyID,string ForeignTable)
		{
			
			return dal.GetModel(ProdCode,ForeignkeyID,ForeignTable);
		}
         /// <summary>
        /// 查询对象
        /// 创建人：Lisa
        /// 创建时间：2016-08-08
        /// </summary>
        /// <param name="ProdCode"></param>
        /// <param name="ForeignTable"></param>
        /// <returns></returns>
        public Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending GetPRODUCT_CLASSIFY(string ProdCode, string ForeignTable)
        {
            return dal.GetPRODUCT_CLASSIFY(ProdCode, ForeignTable);
        }

        public Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending GetPRODUCT_CLASSIFY(string ProdCode)
        {
            return dal.GetPRODUCT_CLASSIFY(ProdCode);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending GetModelByCache(string ProdCode,int ForeignkeyID,string ForeignTable)
		{
			
			string CacheKey = "BUY_PRODUCT_CLASSIFY_PendingModel-" + ProdCode+ForeignkeyID+ForeignTable;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProdCode,ForeignkeyID,ForeignTable);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending)objModel;
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
		public List<Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending> modelList = new List<Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PRODUCT_CLASSIFY_Pending();
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["ForeignkeyID"]!=null && dt.Rows[n]["ForeignkeyID"].ToString()!="")
					{
						model.ForeignkeyID=int.Parse(dt.Rows[n]["ForeignkeyID"].ToString());
					}
					if(dt.Rows[n]["ForeignTable"]!=null && dt.Rows[n]["ForeignTable"].ToString()!="")
					{
					model.ForeignTable=dt.Rows[n]["ForeignTable"].ToString();
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

