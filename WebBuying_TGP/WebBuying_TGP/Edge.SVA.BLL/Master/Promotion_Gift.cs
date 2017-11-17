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
	/// 促销礼品表。
	/// </summary>
	public partial class Promotion_Gift
	{
		private readonly IPromotion_Gift dal=DataAccess.CreatePromotion_Gift();
		public Promotion_Gift()
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
		public bool Exists(string PromotionCode,int GiftSeq)
		{
			return dal.Exists(PromotionCode,GiftSeq);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Promotion_Gift model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Promotion_Gift model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PromotionCode,int GiftSeq)
		{
			
			return dal.Delete(PromotionCode,GiftSeq);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Promotion_Gift GetModel(string PromotionCode,int GiftSeq)
		{
			
			return dal.GetModel(PromotionCode,GiftSeq);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Promotion_Gift GetModelByCache(string PromotionCode,int GiftSeq)
		{
			
			string CacheKey = "Promotion_GiftModel-" + PromotionCode+GiftSeq;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PromotionCode,GiftSeq);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Promotion_Gift)objModel;
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
		public List<Edge.SVA.Model.Promotion_Gift> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Promotion_Gift> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Promotion_Gift> modelList = new List<Edge.SVA.Model.Promotion_Gift>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Promotion_Gift model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Promotion_Gift();
					if(dt.Rows[n]["PromotionCode"]!=null && dt.Rows[n]["PromotionCode"].ToString()!="")
					{
					model.PromotionCode=dt.Rows[n]["PromotionCode"].ToString();
					}
					if(dt.Rows[n]["GiftSeq"]!=null && dt.Rows[n]["GiftSeq"].ToString()!="")
					{
						model.GiftSeq=int.Parse(dt.Rows[n]["GiftSeq"].ToString());
					}
					if(dt.Rows[n]["GiftLogicalOpr"]!=null && dt.Rows[n]["GiftLogicalOpr"].ToString()!="")
					{
						model.GiftLogicalOpr=int.Parse(dt.Rows[n]["GiftLogicalOpr"].ToString());
					}
					if(dt.Rows[n]["PromotionGiftType"]!=null && dt.Rows[n]["PromotionGiftType"].ToString()!="")
					{
						model.PromotionGiftType=int.Parse(dt.Rows[n]["PromotionGiftType"].ToString());
					}
					if(dt.Rows[n]["PromotionDiscountOn"]!=null && dt.Rows[n]["PromotionDiscountOn"].ToString()!="")
					{
						model.PromotionDiscountOn=int.Parse(dt.Rows[n]["PromotionDiscountOn"].ToString());
					}
					if(dt.Rows[n]["PromotionDiscountType"]!=null && dt.Rows[n]["PromotionDiscountType"].ToString()!="")
					{
						model.PromotionDiscountType=int.Parse(dt.Rows[n]["PromotionDiscountType"].ToString());
					}
					if(dt.Rows[n]["PromotionValue"]!=null && dt.Rows[n]["PromotionValue"].ToString()!="")
					{
						model.PromotionValue=decimal.Parse(dt.Rows[n]["PromotionValue"].ToString());
					}
					if(dt.Rows[n]["PromotionGiftQty"]!=null && dt.Rows[n]["PromotionGiftQty"].ToString()!="")
					{
						model.PromotionGiftQty=int.Parse(dt.Rows[n]["PromotionGiftQty"].ToString());
					}
					if(dt.Rows[n]["PromotionGiftItem"]!=null && dt.Rows[n]["PromotionGiftItem"].ToString()!="")
					{
						model.PromotionGiftItem=int.Parse(dt.Rows[n]["PromotionGiftItem"].ToString());
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

