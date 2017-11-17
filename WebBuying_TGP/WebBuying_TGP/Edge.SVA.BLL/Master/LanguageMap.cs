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
	/// kiosk调用
	/// </summary>
	public partial class LanguageMap
	{
		private readonly ILanguageMap dal=DataAccess.CreateLanguageMap();
		public LanguageMap()
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
		public int  Add(Edge.SVA.Model.LanguageMap model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.LanguageMap model)
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
		public Edge.SVA.Model.LanguageMap GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}
         /// <summary>
        /// 根据语言名称查询
        /// 创建者：Lisa
        /// 创建时间：2016-02-29
        /// </summary>
        /// <param name="LanguageDesc"></param>
        /// <returns></returns>
        public Edge.SVA.Model.LanguageMap GetEntityByLanguageDesc(string LanguageDesc)
        {
            return dal.GetEntityByLanguageDesc(LanguageDesc);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.LanguageMap GetModelByCache(int KeyID)
		{
			
			string CacheKey = "LanguageMapModel-" + KeyID;
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
			return (Edge.SVA.Model.LanguageMap)objModel;
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
		public List<Edge.SVA.Model.LanguageMap> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.LanguageMap> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.LanguageMap> modelList = new List<Edge.SVA.Model.LanguageMap>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.LanguageMap model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.LanguageMap();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["LanguageAbbr"]!=null && dt.Rows[n]["LanguageAbbr"].ToString()!="")
					{
					model.LanguageAbbr=dt.Rows[n]["LanguageAbbr"].ToString();
					}
					if(dt.Rows[n]["DescFieldNo"]!=null && dt.Rows[n]["DescFieldNo"].ToString()!="")
					{
						model.DescFieldNo=int.Parse(dt.Rows[n]["DescFieldNo"].ToString());
					}
					if(dt.Rows[n]["LanguageDesc"]!=null && dt.Rows[n]["LanguageDesc"].ToString()!="")
					{
					model.LanguageDesc=dt.Rows[n]["LanguageDesc"].ToString();
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder);
        }
        ///<summary>
        ///获取分页总数
        ///</summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

