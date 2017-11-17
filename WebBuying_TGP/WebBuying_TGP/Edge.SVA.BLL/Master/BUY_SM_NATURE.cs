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
	/// 交易类型定义表。
	///
	/// </summary>
	public partial class BUY_SM_NATURE
	{
		private readonly IBUY_SM_NATURE dal=DataAccess.CreateBUY_SM_NATURE();
		public BUY_SM_NATURE()
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
		public bool Exists(int TransType)
		{
			return dal.Exists(TransType);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_SM_NATURE model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_SM_NATURE model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TransType)
		{
			
			return dal.Delete(TransType);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TransTypelist )
		{
			return dal.DeleteList(TransTypelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_SM_NATURE GetModel(int TransType)
		{
			
			return dal.GetModel(TransType);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_SM_NATURE GetModelByCache(int TransType)
		{
			
			string CacheKey = "BUY_SM_NATUREModel-" + TransType;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(TransType);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_SM_NATURE)objModel;
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
		public List<Edge.SVA.Model.BUY_SM_NATURE> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_SM_NATURE> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_SM_NATURE> modelList = new List<Edge.SVA.Model.BUY_SM_NATURE>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_SM_NATURE model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_SM_NATURE();
					if(dt.Rows[n]["TransType"]!=null && dt.Rows[n]["TransType"].ToString()!="")
					{
						model.TransType=int.Parse(dt.Rows[n]["TransType"].ToString());
					}
					if(dt.Rows[n]["TransTypeName1"]!=null && dt.Rows[n]["TransTypeName1"].ToString()!="")
					{
					model.TransTypeName1=dt.Rows[n]["TransTypeName1"].ToString();
					}
					if(dt.Rows[n]["TransTypeName2"]!=null && dt.Rows[n]["TransTypeName2"].ToString()!="")
					{
					model.TransTypeName2=dt.Rows[n]["TransTypeName2"].ToString();
					}
					if(dt.Rows[n]["TransTypeName3"]!=null && dt.Rows[n]["TransTypeName3"].ToString()!="")
					{
					model.TransTypeName3=dt.Rows[n]["TransTypeName3"].ToString();
					}
					if(dt.Rows[n]["Nature"]!=null && dt.Rows[n]["Nature"].ToString()!="")
					{
					model.Nature=dt.Rows[n]["Nature"].ToString();
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

