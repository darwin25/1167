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
	/// 交友系统类型表
	/// </summary>
	public partial class SNSType
	{
		private readonly ISNSType dal=DataAccess.CreateSNSType();
		public SNSType()
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
		public bool Exists(int SNSTypeID)
		{
			return dal.Exists(SNSTypeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.SNSType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.SNSType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SNSTypeID)
		{
			
			return dal.Delete(SNSTypeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SNSTypeIDlist )
		{
			return dal.DeleteList(SNSTypeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.SNSType GetModel(int SNSTypeID)
		{
			
			return dal.GetModel(SNSTypeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.SNSType GetModelByCache(int SNSTypeID)
		{
			
			string CacheKey = "SNSTypeModel-" + SNSTypeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SNSTypeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.SNSType)objModel;
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
		public List<Edge.SVA.Model.SNSType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.SNSType> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.SNSType> modelList = new List<Edge.SVA.Model.SNSType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.SNSType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.SNSType();
					if(dt.Rows[n]["SNSTypeID"]!=null && dt.Rows[n]["SNSTypeID"].ToString()!="")
					{
						model.SNSTypeID=int.Parse(dt.Rows[n]["SNSTypeID"].ToString());
					}
					if(dt.Rows[n]["SNSTypeName1"]!=null && dt.Rows[n]["SNSTypeName1"].ToString()!="")
					{
					model.SNSTypeName1=dt.Rows[n]["SNSTypeName1"].ToString();
					}
					if(dt.Rows[n]["SNSTypeName2"]!=null && dt.Rows[n]["SNSTypeName2"].ToString()!="")
					{
					model.SNSTypeName2=dt.Rows[n]["SNSTypeName2"].ToString();
					}
					if(dt.Rows[n]["SNSTypeName3"]!=null && dt.Rows[n]["SNSTypeName3"].ToString()!="")
					{
					model.SNSTypeName3=dt.Rows[n]["SNSTypeName3"].ToString();
					}
					if(dt.Rows[n]["SNSTypeURL"]!=null && dt.Rows[n]["SNSTypeURL"].ToString()!="")
					{
					model.SNSTypeURL=dt.Rows[n]["SNSTypeURL"].ToString();
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

