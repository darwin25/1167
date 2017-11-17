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
	/// 分发模板
	///发布方法
	/// </summary>
	public partial class DistributeTemplate
	{
		private readonly IDistributeTemplate dal=DataAccess.CreateDistributeTemplate();
		public DistributeTemplate()
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
		public bool Exists(string DistributionCode,int DistributionID)
		{
			return dal.Exists(DistributionCode,DistributionID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.DistributeTemplate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.DistributeTemplate model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DistributionID)
		{
			
			return dal.Delete(DistributionID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DistributionCode,int DistributionID)
		{
			
			return dal.Delete(DistributionCode,DistributionID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DistributionIDlist )
		{
			return dal.DeleteList(DistributionIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.DistributeTemplate GetModel(int DistributionID)
		{
			
			return dal.GetModel(DistributionID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.DistributeTemplate GetModelByCache(int DistributionID)
		{
			
			string CacheKey = "DistributeTemplateModel-" + DistributionID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DistributionID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.DistributeTemplate)objModel;
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
		public List<Edge.SVA.Model.DistributeTemplate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.DistributeTemplate> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.DistributeTemplate> modelList = new List<Edge.SVA.Model.DistributeTemplate>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.DistributeTemplate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.DistributeTemplate();
					if(dt.Rows[n]["DistributionID"]!=null && dt.Rows[n]["DistributionID"].ToString()!="")
					{
						model.DistributionID=int.Parse(dt.Rows[n]["DistributionID"].ToString());
					}
					if(dt.Rows[n]["DistributionCode"]!=null && dt.Rows[n]["DistributionCode"].ToString()!="")
					{
					model.DistributionCode=dt.Rows[n]["DistributionCode"].ToString();
					}
					if(dt.Rows[n]["DistributionDesc1"]!=null && dt.Rows[n]["DistributionDesc1"].ToString()!="")
					{
					model.DistributionDesc1=dt.Rows[n]["DistributionDesc1"].ToString();
					}
					if(dt.Rows[n]["DistributionDesc2"]!=null && dt.Rows[n]["DistributionDesc2"].ToString()!="")
					{
					model.DistributionDesc2=dt.Rows[n]["DistributionDesc2"].ToString();
					}
					if(dt.Rows[n]["DistributionDesc3"]!=null && dt.Rows[n]["DistributionDesc3"].ToString()!="")
					{
					model.DistributionDesc3=dt.Rows[n]["DistributionDesc3"].ToString();
					}
					if(dt.Rows[n]["TemplateFile"]!=null && dt.Rows[n]["TemplateFile"].ToString()!="")
					{
					model.TemplateFile=dt.Rows[n]["TemplateFile"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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

