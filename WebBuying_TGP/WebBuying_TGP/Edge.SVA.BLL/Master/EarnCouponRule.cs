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
	/// 获取优惠劵的规则表
	/// </summary>
	public partial class EarnCouponRule
	{
		private readonly IEarnCouponRule dal=DataAccess.CreateEarnCouponRule();
		public EarnCouponRule()
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
		public int  Add(Edge.SVA.Model.EarnCouponRule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.EarnCouponRule model)
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
		public Edge.SVA.Model.EarnCouponRule GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.EarnCouponRule GetModelByCache(int KeyID)
		{
			
			string CacheKey = "EarnCouponRuleModel-" + KeyID;
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
			return (Edge.SVA.Model.EarnCouponRule)objModel;
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
		public List<Edge.SVA.Model.EarnCouponRule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.EarnCouponRule> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.EarnCouponRule> modelList = new List<Edge.SVA.Model.EarnCouponRule>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.EarnCouponRule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.EarnCouponRule();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["CouponTypeID"]!=null && dt.Rows[n]["CouponTypeID"].ToString()!="")
					{
						model.CouponTypeID=int.Parse(dt.Rows[n]["CouponTypeID"].ToString());
					}
					if(dt.Rows[n]["ExchangeType"]!=null && dt.Rows[n]["ExchangeType"].ToString()!="")
					{
						model.ExchangeType=int.Parse(dt.Rows[n]["ExchangeType"].ToString());
					}
					if(dt.Rows[n]["ExchangeRank"]!=null && dt.Rows[n]["ExchangeRank"].ToString()!="")
					{
						model.ExchangeRank=int.Parse(dt.Rows[n]["ExchangeRank"].ToString());
					}
					if(dt.Rows[n]["ExchangeAmount"]!=null && dt.Rows[n]["ExchangeAmount"].ToString()!="")
					{
						model.ExchangeAmount=decimal.Parse(dt.Rows[n]["ExchangeAmount"].ToString());
					}
					if(dt.Rows[n]["ExchangePoint"]!=null && dt.Rows[n]["ExchangePoint"].ToString()!="")
					{
						model.ExchangePoint=int.Parse(dt.Rows[n]["ExchangePoint"].ToString());
					}
					if(dt.Rows[n]["ExchangeCouponTypeID"]!=null && dt.Rows[n]["ExchangeCouponTypeID"].ToString()!="")
					{
						model.ExchangeCouponTypeID=int.Parse(dt.Rows[n]["ExchangeCouponTypeID"].ToString());
					}
					if(dt.Rows[n]["ExchangeCouponCount"]!=null && dt.Rows[n]["ExchangeCouponCount"].ToString()!="")
					{
						model.ExchangeCouponCount=int.Parse(dt.Rows[n]["ExchangeCouponCount"].ToString());
					}
					if(dt.Rows[n]["ExchangeConsumeRuleOper"]!=null && dt.Rows[n]["ExchangeConsumeRuleOper"].ToString()!="")
					{
						model.ExchangeConsumeRuleOper=int.Parse(dt.Rows[n]["ExchangeConsumeRuleOper"].ToString());
					}
					if(dt.Rows[n]["ExchangeConsumeAmount"]!=null && dt.Rows[n]["ExchangeConsumeAmount"].ToString()!="")
					{
						model.ExchangeConsumeAmount=decimal.Parse(dt.Rows[n]["ExchangeConsumeAmount"].ToString());
					}
					if(dt.Rows[n]["CardTypeIDLimit"]!=null && dt.Rows[n]["CardTypeIDLimit"].ToString()!="")
					{
						model.CardTypeIDLimit=int.Parse(dt.Rows[n]["CardTypeIDLimit"].ToString());
					}
					if(dt.Rows[n]["CardGradeIDLimit"]!=null && dt.Rows[n]["CardGradeIDLimit"].ToString()!="")
					{
						model.CardGradeIDLimit=int.Parse(dt.Rows[n]["CardGradeIDLimit"].ToString());
					}
					if(dt.Rows[n]["CardTypeBrandIDLimit"]!=null && dt.Rows[n]["CardTypeBrandIDLimit"].ToString()!="")
					{
						model.CardTypeBrandIDLimit=int.Parse(dt.Rows[n]["CardTypeBrandIDLimit"].ToString());
					}
					if(dt.Rows[n]["StoreBrandIDLimit"]!=null && dt.Rows[n]["StoreBrandIDLimit"].ToString()!="")
					{
						model.StoreBrandIDLimit=int.Parse(dt.Rows[n]["StoreBrandIDLimit"].ToString());
					}
					if(dt.Rows[n]["StoreGroupIDLimit"]!=null && dt.Rows[n]["StoreGroupIDLimit"].ToString()!="")
					{
						model.StoreGroupIDLimit=int.Parse(dt.Rows[n]["StoreGroupIDLimit"].ToString());
					}
					if(dt.Rows[n]["StoreIDLimit"]!=null && dt.Rows[n]["StoreIDLimit"].ToString()!="")
					{
						model.StoreIDLimit=int.Parse(dt.Rows[n]["StoreIDLimit"].ToString());
					}
					if(dt.Rows[n]["MemberBirthdayLimit"]!=null && dt.Rows[n]["MemberBirthdayLimit"].ToString()!="")
					{
						model.MemberBirthdayLimit=int.Parse(dt.Rows[n]["MemberBirthdayLimit"].ToString());
					}
					if(dt.Rows[n]["MemberSexLimit"]!=null && dt.Rows[n]["MemberSexLimit"].ToString()!="")
					{
						model.MemberSexLimit=int.Parse(dt.Rows[n]["MemberSexLimit"].ToString());
					}
					if(dt.Rows[n]["MemberAgeMinLimit"]!=null && dt.Rows[n]["MemberAgeMinLimit"].ToString()!="")
					{
						model.MemberAgeMinLimit=int.Parse(dt.Rows[n]["MemberAgeMinLimit"].ToString());
					}
					if(dt.Rows[n]["MemberAgeMaxLimit"]!=null && dt.Rows[n]["MemberAgeMaxLimit"].ToString()!="")
					{
						model.MemberAgeMaxLimit=int.Parse(dt.Rows[n]["MemberAgeMaxLimit"].ToString());
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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

