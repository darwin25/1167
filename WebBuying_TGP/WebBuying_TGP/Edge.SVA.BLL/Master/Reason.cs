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
	/// 原因列表
	/// </summary>
	public partial class Reason
	{
		private readonly IReason dal=DataAccess.CreateReason();
		public Reason()
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
		public bool Exists(int ReasonID)
		{
			return dal.Exists(ReasonID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Reason model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Reason model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ReasonID)
		{
			
			return dal.Delete(ReasonID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ReasonIDlist )
		{
			return dal.DeleteList(ReasonIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Reason GetModel(int ReasonID)
		{
			
			return dal.GetModel(ReasonID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Reason GetModelByCache(int ReasonID)
		{
			
			string CacheKey = "ReasonModel-" + ReasonID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ReasonID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Reason)objModel;
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
		public List<Edge.SVA.Model.Reason> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Reason> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Reason> modelList = new List<Edge.SVA.Model.Reason>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Reason model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Reason();
					if(dt.Rows[n]["ReasonID"]!=null && dt.Rows[n]["ReasonID"].ToString()!="")
					{
						model.ReasonID=int.Parse(dt.Rows[n]["ReasonID"].ToString());
					}
					if(dt.Rows[n]["ReasonCode"]!=null && dt.Rows[n]["ReasonCode"].ToString()!="")
					{
					model.ReasonCode=dt.Rows[n]["ReasonCode"].ToString();
					}
					if(dt.Rows[n]["ReasonDesc1"]!=null && dt.Rows[n]["ReasonDesc1"].ToString()!="")
					{
					model.ReasonDesc1=dt.Rows[n]["ReasonDesc1"].ToString();
					}
					if(dt.Rows[n]["ReasonDesc2"]!=null && dt.Rows[n]["ReasonDesc2"].ToString()!="")
					{
					model.ReasonDesc2=dt.Rows[n]["ReasonDesc2"].ToString();
					}
					if(dt.Rows[n]["ReasonDesc3"]!=null && dt.Rows[n]["ReasonDesc3"].ToString()!="")
					{
					model.ReasonDesc3=dt.Rows[n]["ReasonDesc3"].ToString();
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
						model.UpdatedBy=int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
						model.CreatedBy=int.Parse(dt.Rows[n]["CreatedBy"].ToString());
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

