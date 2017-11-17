﻿using System;
using System.Data;
using System.Collections.Generic;

namespace Edge.Security.Manager
{
	/// <summary>
	/// Lan_Accounts_PermissionCategories
	/// </summary>
	public partial class Lan_Accounts_PermissionCategories
	{
        private readonly Edge.Security.Data.Lan_Accounts_PermissionCategories dal = new Edge.Security.Data.Lan_Accounts_PermissionCategories();
		public Lan_Accounts_PermissionCategories()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.Security.Model.Lan_Accounts_PermissionCategories model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.Security.Model.Lan_Accounts_PermissionCategories model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(Edge.Security.Model.Lan_Accounts_PermissionCategories model)
		{
			//该表无主键信息，请自定义主键/条件字段
            return dal.Delete(model);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.Security.Model.Lan_Accounts_PermissionCategories GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.Security.Model.Lan_Accounts_PermissionCategories GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "Lan_Accounts_PermissionCategoriesModel-" ;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.Security.Model.Lan_Accounts_PermissionCategories)objModel;
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
		public List<Edge.Security.Model.Lan_Accounts_PermissionCategories> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.Security.Model.Lan_Accounts_PermissionCategories> DataTableToList(DataTable dt)
		{
			List<Edge.Security.Model.Lan_Accounts_PermissionCategories> modelList = new List<Edge.Security.Model.Lan_Accounts_PermissionCategories>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.Security.Model.Lan_Accounts_PermissionCategories model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.Security.Model.Lan_Accounts_PermissionCategories();
					if(dt.Rows[n]["CategoryID"]!=null && dt.Rows[n]["CategoryID"].ToString()!="")
					{
						model.CategoryID=int.Parse(dt.Rows[n]["CategoryID"].ToString());
					}
					if(dt.Rows[n]["Description"]!=null && dt.Rows[n]["Description"].ToString()!="")
					{
					model.Description=dt.Rows[n]["Description"].ToString();
					}
					if(dt.Rows[n]["Lan"]!=null && dt.Rows[n]["Lan"].ToString()!="")
					{
					model.Lan=dt.Rows[n]["Lan"].ToString();
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
        /// 获取分页总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

