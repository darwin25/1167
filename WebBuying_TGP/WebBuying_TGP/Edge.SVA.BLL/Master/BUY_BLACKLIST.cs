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
	/// 黑名单表
	/// </summary>
	public partial class BUY_BLACKLIST
	{
		private readonly IBUY_BLACKLIST dal=DataAccess.CreateBUY_BLACKLIST();
		public BUY_BLACKLIST()
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
		public bool Exists(int BlackID)
		{
			return dal.Exists(BlackID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_BLACKLIST model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_BLACKLIST model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BlackID)
		{
			
			return dal.Delete(BlackID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BlackIDlist )
		{
			return dal.DeleteList(BlackIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_BLACKLIST GetModel(int BlackID)
		{
			
			return dal.GetModel(BlackID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_BLACKLIST GetModelByCache(int BlackID)
		{
			
			string CacheKey = "BUY_BLACKLISTModel-" + BlackID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BlackID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_BLACKLIST)objModel;
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
		public List<Edge.SVA.Model.BUY_BLACKLIST> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_BLACKLIST> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_BLACKLIST> modelList = new List<Edge.SVA.Model.BUY_BLACKLIST>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_BLACKLIST model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_BLACKLIST();
					if(dt.Rows[n]["BlackID"]!=null && dt.Rows[n]["BlackID"].ToString()!="")
					{
						model.BlackID=int.Parse(dt.Rows[n]["BlackID"].ToString());
					}
					if(dt.Rows[n]["AccountCode"]!=null && dt.Rows[n]["AccountCode"].ToString()!="")
					{
					model.AccountCode=dt.Rows[n]["AccountCode"].ToString();
					}
					if(dt.Rows[n]["CustomerName"]!=null && dt.Rows[n]["CustomerName"].ToString()!="")
					{
					model.CustomerName=dt.Rows[n]["CustomerName"].ToString();
					}
					if(dt.Rows[n]["CustomerCode"]!=null && dt.Rows[n]["CustomerCode"].ToString()!="")
					{
					model.CustomerCode=dt.Rows[n]["CustomerCode"].ToString();
					}
					if(dt.Rows[n]["ExtgServiceNo"]!=null && dt.Rows[n]["ExtgServiceNo"].ToString()!="")
					{
					model.ExtgServiceNo=dt.Rows[n]["ExtgServiceNo"].ToString();
					}
					if(dt.Rows[n]["DeliveryAddress"]!=null && dt.Rows[n]["DeliveryAddress"].ToString()!="")
					{
					model.DeliveryAddress=dt.Rows[n]["DeliveryAddress"].ToString();
					}
					if(dt.Rows[n]["CustomerContact"]!=null && dt.Rows[n]["CustomerContact"].ToString()!="")
					{
					model.CustomerContact=dt.Rows[n]["CustomerContact"].ToString();
					}
					if(dt.Rows[n]["CustomerContact1"]!=null && dt.Rows[n]["CustomerContact1"].ToString()!="")
					{
					model.CustomerContact1=dt.Rows[n]["CustomerContact1"].ToString();
					}
					if(dt.Rows[n]["CreditCardNo"]!=null && dt.Rows[n]["CreditCardNo"].ToString()!="")
					{
					model.CreditCardNo=dt.Rows[n]["CreditCardNo"].ToString();
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

