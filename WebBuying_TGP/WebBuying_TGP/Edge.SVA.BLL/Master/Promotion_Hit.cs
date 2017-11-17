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
	/// Promotion_H的子表。 促销命中条件表
	///（多个货品固定搭配的情况
	/// </summary>
	public partial class Promotion_Hit
	{
		private readonly IPromotion_Hit dal=DataAccess.CreatePromotion_Hit();
		public Promotion_Hit()
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
		public bool Exists(string PromotionCode,int HitSeq)
		{
			return dal.Exists(PromotionCode,HitSeq);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Promotion_Hit model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Promotion_Hit model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PromotionCode,int HitSeq)
		{
			
			return dal.Delete(PromotionCode,HitSeq);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Promotion_Hit GetModel(string PromotionCode,int HitSeq)
		{
			
			return dal.GetModel(PromotionCode,HitSeq);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Promotion_Hit GetModelByCache(string PromotionCode,int HitSeq)
		{
			
			string CacheKey = "Promotion_HitModel-" + PromotionCode+HitSeq;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PromotionCode,HitSeq);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Promotion_Hit)objModel;
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
		public List<Edge.SVA.Model.Promotion_Hit> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Promotion_Hit> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Promotion_Hit> modelList = new List<Edge.SVA.Model.Promotion_Hit>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Promotion_Hit model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Promotion_Hit();
					if(dt.Rows[n]["PromotionCode"]!=null && dt.Rows[n]["PromotionCode"].ToString()!="")
					{
					model.PromotionCode=dt.Rows[n]["PromotionCode"].ToString();
					}
					if(dt.Rows[n]["HitSeq"]!=null && dt.Rows[n]["HitSeq"].ToString()!="")
					{
						model.HitSeq=int.Parse(dt.Rows[n]["HitSeq"].ToString());
					}
					if(dt.Rows[n]["HitLogicalOpr"]!=null && dt.Rows[n]["HitLogicalOpr"].ToString()!="")
					{
						model.HitLogicalOpr=int.Parse(dt.Rows[n]["HitLogicalOpr"].ToString());
					}
					if(dt.Rows[n]["HitType"]!=null && dt.Rows[n]["HitType"].ToString()!="")
					{
						model.HitType=int.Parse(dt.Rows[n]["HitType"].ToString());
					}
					if(dt.Rows[n]["HitValue"]!=null && dt.Rows[n]["HitValue"].ToString()!="")
					{
						model.HitValue=int.Parse(dt.Rows[n]["HitValue"].ToString());
					}
					if(dt.Rows[n]["HitOP"]!=null && dt.Rows[n]["HitOP"].ToString()!="")
					{
						model.HitOP=int.Parse(dt.Rows[n]["HitOP"].ToString());
					}
					if(dt.Rows[n]["HitItem"]!=null && dt.Rows[n]["HitItem"].ToString()!="")
					{
						model.HitItem=int.Parse(dt.Rows[n]["HitItem"].ToString());
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

