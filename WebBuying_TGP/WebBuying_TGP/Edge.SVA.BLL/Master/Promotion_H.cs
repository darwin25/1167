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
	/// 促销头表。 （包含所有被动促销设置.  促销会根据具体的销售单
	/// </summary>
	public partial class Promotion_H
	{
		private readonly IPromotion_H dal=DataAccess.CreatePromotion_H();
		public Promotion_H()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PromotionCode)
		{
			return dal.Exists(PromotionCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Promotion_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Promotion_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PromotionCode)
		{
			
			return dal.Delete(PromotionCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PromotionCodelist )
		{
			return dal.DeleteList(PromotionCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Promotion_H GetModel(string PromotionCode)
		{
			
			return dal.GetModel(PromotionCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Promotion_H GetModelByCache(string PromotionCode)
		{
			
			string CacheKey = "Promotion_HModel-" + PromotionCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PromotionCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Promotion_H)objModel;
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
		public List<Edge.SVA.Model.Promotion_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Promotion_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Promotion_H> modelList = new List<Edge.SVA.Model.Promotion_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Promotion_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Promotion_H();
					if(dt.Rows[n]["PromotionCode"]!=null && dt.Rows[n]["PromotionCode"].ToString()!="")
					{
					model.PromotionCode=dt.Rows[n]["PromotionCode"].ToString();
					}
					if(dt.Rows[n]["PromotionDesc1"]!=null && dt.Rows[n]["PromotionDesc1"].ToString()!="")
					{
					model.PromotionDesc1=dt.Rows[n]["PromotionDesc1"].ToString();
					}
					if(dt.Rows[n]["PromotionDesc2"]!=null && dt.Rows[n]["PromotionDesc2"].ToString()!="")
					{
					model.PromotionDesc2=dt.Rows[n]["PromotionDesc2"].ToString();
					}
					if(dt.Rows[n]["PromotionDesc3"]!=null && dt.Rows[n]["PromotionDesc3"].ToString()!="")
					{
					model.PromotionDesc3=dt.Rows[n]["PromotionDesc3"].ToString();
					}
					if(dt.Rows[n]["PromotionNote"]!=null && dt.Rows[n]["PromotionNote"].ToString()!="")
					{
					model.PromotionNote=dt.Rows[n]["PromotionNote"].ToString();
					}
					if(dt.Rows[n]["StoreID"]!=null && dt.Rows[n]["StoreID"].ToString()!="")
					{
						model.StoreID=int.Parse(dt.Rows[n]["StoreID"].ToString());
					}
					if(dt.Rows[n]["StoreGroupID"]!=null && dt.Rows[n]["StoreGroupID"].ToString()!="")
					{
						model.StoreGroupID=int.Parse(dt.Rows[n]["StoreGroupID"].ToString());
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["StartTime"]!=null && dt.Rows[n]["StartTime"].ToString()!="")
					{
						model.StartTime=DateTime.Parse(dt.Rows[n]["StartTime"].ToString());
					}
					if(dt.Rows[n]["EndTime"]!=null && dt.Rows[n]["EndTime"].ToString()!="")
					{
						model.EndTime=DateTime.Parse(dt.Rows[n]["EndTime"].ToString());
					}
					if(dt.Rows[n]["DayFlagCode"]!=null && dt.Rows[n]["DayFlagCode"].ToString()!="")
					{
					model.DayFlagCode=dt.Rows[n]["DayFlagCode"].ToString();
					}
					if(dt.Rows[n]["WeekFlagCode"]!=null && dt.Rows[n]["WeekFlagCode"].ToString()!="")
					{
					model.WeekFlagCode=dt.Rows[n]["WeekFlagCode"].ToString();
					}
					if(dt.Rows[n]["MonthFlagCode"]!=null && dt.Rows[n]["MonthFlagCode"].ToString()!="")
					{
					model.MonthFlagCode=dt.Rows[n]["MonthFlagCode"].ToString();
					}
					if(dt.Rows[n]["LoyaltyFlag"]!=null && dt.Rows[n]["LoyaltyFlag"].ToString()!="")
					{
						model.LoyaltyFlag=int.Parse(dt.Rows[n]["LoyaltyFlag"].ToString());
					}
					if(dt.Rows[n]["CreatedBusDate"]!=null && dt.Rows[n]["CreatedBusDate"].ToString()!="")
					{
						model.CreatedBusDate=DateTime.Parse(dt.Rows[n]["CreatedBusDate"].ToString());
					}
					if(dt.Rows[n]["ApproveBusDate"]!=null && dt.Rows[n]["ApproveBusDate"].ToString()!="")
					{
						model.ApproveBusDate=DateTime.Parse(dt.Rows[n]["ApproveBusDate"].ToString());
					}
					if(dt.Rows[n]["ApprovalCode"]!=null && dt.Rows[n]["ApprovalCode"].ToString()!="")
					{
					model.ApprovalCode=dt.Rows[n]["ApprovalCode"].ToString();
					}
					if(dt.Rows[n]["ApproveStatus"]!=null && dt.Rows[n]["ApproveStatus"].ToString()!="")
					{
					model.ApproveStatus=dt.Rows[n]["ApproveStatus"].ToString();
					}
					if(dt.Rows[n]["ApproveOn"]!=null && dt.Rows[n]["ApproveOn"].ToString()!="")
					{
						model.ApproveOn=DateTime.Parse(dt.Rows[n]["ApproveOn"].ToString());
					}
					if(dt.Rows[n]["ApproveBy"]!=null && dt.Rows[n]["ApproveBy"].ToString()!="")
					{
						model.ApproveBy=int.Parse(dt.Rows[n]["ApproveBy"].ToString());
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

