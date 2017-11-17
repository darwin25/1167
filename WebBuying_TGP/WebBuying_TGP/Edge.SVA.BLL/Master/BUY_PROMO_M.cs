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
	/// 促销主档表。
	/// </summary>
	public partial class BUY_PROMO_M
	{
		private readonly IBUY_PROMO_M dal=DataAccess.CreateBUY_PROMO_M();
		public BUY_PROMO_M()
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
		public int  Add(Edge.SVA.Model.BUY_PROMO_M model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PROMO_M model)
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
		public Edge.SVA.Model.BUY_PROMO_M GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PROMO_M GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_PROMO_MModel-" + KeyID;
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
			return (Edge.SVA.Model.BUY_PROMO_M)objModel;
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
		public List<Edge.SVA.Model.BUY_PROMO_M> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PROMO_M> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PROMO_M> modelList = new List<Edge.SVA.Model.BUY_PROMO_M>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PROMO_M model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PROMO_M();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["PromotionCode"]!=null && dt.Rows[n]["PromotionCode"].ToString()!="")
					{
					model.PromotionCode=dt.Rows[n]["PromotionCode"].ToString();
					}
					if(dt.Rows[n]["Description1"]!=null && dt.Rows[n]["Description1"].ToString()!="")
					{
					model.Description1=dt.Rows[n]["Description1"].ToString();
					}
					if(dt.Rows[n]["Description2"]!=null && dt.Rows[n]["Description2"].ToString()!="")
					{
					model.Description2=dt.Rows[n]["Description2"].ToString();
					}
					if(dt.Rows[n]["Description3"]!=null && dt.Rows[n]["Description3"].ToString()!="")
					{
					model.Description3=dt.Rows[n]["Description3"].ToString();
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["StoreGroupCode"]!=null && dt.Rows[n]["StoreGroupCode"].ToString()!="")
					{
					model.StoreGroupCode=dt.Rows[n]["StoreGroupCode"].ToString();
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
					if(dt.Rows[n]["EntityNum"]!=null && dt.Rows[n]["EntityNum"].ToString()!="")
					{
					model.EntityNum=dt.Rows[n]["EntityNum"].ToString();
					}
					if(dt.Rows[n]["EntityType"]!=null && dt.Rows[n]["EntityType"].ToString()!="")
					{
						model.EntityType=int.Parse(dt.Rows[n]["EntityType"].ToString());
					}
					if(dt.Rows[n]["HitAmount"]!=null && dt.Rows[n]["HitAmount"].ToString()!="")
					{
						model.HitAmount=decimal.Parse(dt.Rows[n]["HitAmount"].ToString());
					}
					if(dt.Rows[n]["HitOP"]!=null && dt.Rows[n]["HitOP"].ToString()!="")
					{
						model.HitOP=int.Parse(dt.Rows[n]["HitOP"].ToString());
					}
					if(dt.Rows[n]["DiscPrice"]!=null && dt.Rows[n]["DiscPrice"].ToString()!="")
					{
						model.DiscPrice=decimal.Parse(dt.Rows[n]["DiscPrice"].ToString());
					}
					if(dt.Rows[n]["DiscType"]!=null && dt.Rows[n]["DiscType"].ToString()!="")
					{
						model.DiscType=int.Parse(dt.Rows[n]["DiscType"].ToString());
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
					if(dt.Rows[n]["LoyaltyCardTypeCode"]!=null && dt.Rows[n]["LoyaltyCardTypeCode"].ToString()!="")
					{
					model.LoyaltyCardTypeCode=dt.Rows[n]["LoyaltyCardTypeCode"].ToString();
					}
					if(dt.Rows[n]["LoyaltyCardGradeCode"]!=null && dt.Rows[n]["LoyaltyCardGradeCode"].ToString()!="")
					{
					model.LoyaltyCardGradeCode=dt.Rows[n]["LoyaltyCardGradeCode"].ToString();
					}
					if(dt.Rows[n]["BirthdayFlag"]!=null && dt.Rows[n]["BirthdayFlag"].ToString()!="")
					{
						model.BirthdayFlag=int.Parse(dt.Rows[n]["BirthdayFlag"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["ApproveOn"]!=null && dt.Rows[n]["ApproveOn"].ToString()!="")
					{
						model.ApproveOn=DateTime.Parse(dt.Rows[n]["ApproveOn"].ToString());
					}
					if(dt.Rows[n]["ApproveBy"]!=null && dt.Rows[n]["ApproveBy"].ToString()!="")
					{
						model.ApproveBy=int.Parse(dt.Rows[n]["ApproveBy"].ToString());
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

