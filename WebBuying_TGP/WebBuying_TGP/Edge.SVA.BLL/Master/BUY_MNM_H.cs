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
	/// 混配促销配置表。主表
	/// </summary>
	public partial class BUY_MNM_H
	{
		private readonly IBUY_MNM_H dal=DataAccess.CreateBUY_MNM_H();
		public BUY_MNM_H()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MNMCode)
		{
			return dal.Exists(MNMCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_MNM_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_MNM_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string MNMCode)
		{
			
			return dal.Delete(MNMCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MNMCodelist )
		{
			return dal.DeleteList(MNMCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_MNM_H GetModel(string MNMCode)
		{
			
			return dal.GetModel(MNMCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_MNM_H GetModelByCache(string MNMCode)
		{
			
			string CacheKey = "BUY_MNM_HModel-" + MNMCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MNMCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_MNM_H)objModel;
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
		public List<Edge.SVA.Model.BUY_MNM_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_MNM_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_MNM_H> modelList = new List<Edge.SVA.Model.BUY_MNM_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_MNM_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_MNM_H();
					if(dt.Rows[n]["MNMCode"]!=null && dt.Rows[n]["MNMCode"].ToString()!="")
					{
					model.MNMCode=dt.Rows[n]["MNMCode"].ToString();
					}
					if(dt.Rows[n]["MNMType"]!=null && dt.Rows[n]["MNMType"].ToString()!="")
					{
						model.MNMType=int.Parse(dt.Rows[n]["MNMType"].ToString());
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
					if(dt.Rows[n]["LoyaltyOnly"]!=null && dt.Rows[n]["LoyaltyOnly"].ToString()!="")
					{
						model.LoyaltyOnly=int.Parse(dt.Rows[n]["LoyaltyOnly"].ToString());
					}
					if(dt.Rows[n]["LoyaltyCardTypeCode"]!=null && dt.Rows[n]["LoyaltyCardTypeCode"].ToString()!="")
					{
					model.LoyaltyCardTypeCode=dt.Rows[n]["LoyaltyCardTypeCode"].ToString();
					}
					if(dt.Rows[n]["LoyaltyCardGradeCode"]!=null && dt.Rows[n]["LoyaltyCardGradeCode"].ToString()!="")
					{
					model.LoyaltyCardGradeCode=dt.Rows[n]["LoyaltyCardGradeCode"].ToString();
					}
					if(dt.Rows[n]["LoyaltyThreshold"]!=null && dt.Rows[n]["LoyaltyThreshold"].ToString()!="")
					{
					model.LoyaltyThreshold=dt.Rows[n]["LoyaltyThreshold"].ToString();
					}
					if(dt.Rows[n]["HitType"]!=null && dt.Rows[n]["HitType"].ToString()!="")
					{
						model.HitType=int.Parse(dt.Rows[n]["HitType"].ToString());
					}
					if(dt.Rows[n]["HitOP"]!=null && dt.Rows[n]["HitOP"].ToString()!="")
					{
						model.HitOP=int.Parse(dt.Rows[n]["HitOP"].ToString());
					}
					if(dt.Rows[n]["HitAmount"]!=null && dt.Rows[n]["HitAmount"].ToString()!="")
					{
						model.HitAmount=decimal.Parse(dt.Rows[n]["HitAmount"].ToString());
					}
					if(dt.Rows[n]["HitQty"]!=null && dt.Rows[n]["HitQty"].ToString()!="")
					{
						model.HitQty=int.Parse(dt.Rows[n]["HitQty"].ToString());
					}
					if(dt.Rows[n]["GiftType"]!=null && dt.Rows[n]["GiftType"].ToString()!="")
					{
						model.GiftType=int.Parse(dt.Rows[n]["GiftType"].ToString());
					}
					if(dt.Rows[n]["GiftQty"]!=null && dt.Rows[n]["GiftQty"].ToString()!="")
					{
						model.GiftQty=int.Parse(dt.Rows[n]["GiftQty"].ToString());
					}
					if(dt.Rows[n]["PromotionType"]!=null && dt.Rows[n]["PromotionType"].ToString()!="")
					{
						model.PromotionType=int.Parse(dt.Rows[n]["PromotionType"].ToString());
					}
					if(dt.Rows[n]["PromotionOn"]!=null && dt.Rows[n]["PromotionOn"].ToString()!="")
					{
						model.PromotionOn=int.Parse(dt.Rows[n]["PromotionOn"].ToString());
					}
					if(dt.Rows[n]["AmountType"]!=null && dt.Rows[n]["AmountType"].ToString()!="")
					{
					model.AmountType=dt.Rows[n]["AmountType"].ToString();
					}
					if(dt.Rows[n]["Amount"]!=null && dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
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

