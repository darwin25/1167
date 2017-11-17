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
	/// 卡消费赚积分规则表
	/// </summary>
	public partial class PointRule
	{
		private readonly IPointRule dal=DataAccess.CreatePointRule();
		public PointRule()
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
		public bool Exists(int PointRuleID)
		{
			return dal.Exists(PointRuleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.PointRule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.PointRule model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PointRuleID)
		{
			
			return dal.Delete(PointRuleID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PointRuleIDlist )
		{
			return dal.DeleteList(PointRuleIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.PointRule GetModel(int PointRuleID)
		{
			
			return dal.GetModel(PointRuleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.PointRule GetModelByCache(int PointRuleID)
		{
			
			string CacheKey = "PointRuleModel-" + PointRuleID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PointRuleID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.PointRule)objModel;
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
		public List<Edge.SVA.Model.PointRule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.PointRule> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.PointRule> modelList = new List<Edge.SVA.Model.PointRule>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.PointRule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.PointRule();
					if(dt.Rows[n]["PointRuleID"]!=null && dt.Rows[n]["PointRuleID"].ToString()!="")
					{
						model.PointRuleID=int.Parse(dt.Rows[n]["PointRuleID"].ToString());
					}
					if(dt.Rows[n]["CardTypeID"]!=null && dt.Rows[n]["CardTypeID"].ToString()!="")
					{
						model.CardTypeID=int.Parse(dt.Rows[n]["CardTypeID"].ToString());
					}
					if(dt.Rows[n]["CardGradeID"]!=null && dt.Rows[n]["CardGradeID"].ToString()!="")
					{
						model.CardGradeID=int.Parse(dt.Rows[n]["CardGradeID"].ToString());
					}
					if(dt.Rows[n]["PointRuleSeqNo"]!=null && dt.Rows[n]["PointRuleSeqNo"].ToString()!="")
					{
						model.PointRuleSeqNo=int.Parse(dt.Rows[n]["PointRuleSeqNo"].ToString());
					}
					if(dt.Rows[n]["PointRuleOper"]!=null && dt.Rows[n]["PointRuleOper"].ToString()!="")
					{
						model.PointRuleOper=int.Parse(dt.Rows[n]["PointRuleOper"].ToString());
					}
					if(dt.Rows[n]["PointRuleAmount"]!=null && dt.Rows[n]["PointRuleAmount"].ToString()!="")
					{
						model.PointRuleAmount=decimal.Parse(dt.Rows[n]["PointRuleAmount"].ToString());
					}
					if(dt.Rows[n]["PointRulePoints"]!=null && dt.Rows[n]["PointRulePoints"].ToString()!="")
					{
						model.PointRulePoints=int.Parse(dt.Rows[n]["PointRulePoints"].ToString());
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
						model.CreatedBy=int.Parse(dt.Rows[n]["CreatedBy"].ToString());
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

