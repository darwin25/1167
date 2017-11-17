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
	/// 货币支付表
	/// </summary>
	public partial class BUY_CURRENCY
	{
		private readonly IBUY_CURRENCY dal=DataAccess.CreateBUY_CURRENCY();
		public BUY_CURRENCY()
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
		public bool Exists(string CurrencyCode,int CurrencyID)
		{
			return dal.Exists(CurrencyCode,CurrencyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_CURRENCY model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_CURRENCY model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CurrencyID)
		{
			
			return dal.Delete(CurrencyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CurrencyCode,int CurrencyID)
		{
			
			return dal.Delete(CurrencyCode,CurrencyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CurrencyIDlist )
		{
			return dal.DeleteList(CurrencyIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_CURRENCY GetModel(int CurrencyID)
		{
			
			return dal.GetModel(CurrencyID);
		}

        public Edge.SVA.Model.BUY_CURRENCY GetCurrencyByType(int Type)
        {
            return dal.GetCurrencyByType(Type);
        }
		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_CURRENCY GetModelByCache(int CurrencyID)
		{
			
			string CacheKey = "BUY_CURRENCYModel-" + CurrencyID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CurrencyID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_CURRENCY)objModel;
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
		public List<Edge.SVA.Model.BUY_CURRENCY> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_CURRENCY> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_CURRENCY> modelList = new List<Edge.SVA.Model.BUY_CURRENCY>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_CURRENCY model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_CURRENCY();
					if(dt.Rows[n]["CurrencyID"]!=null && dt.Rows[n]["CurrencyID"].ToString()!="")
					{
						model.CurrencyID=int.Parse(dt.Rows[n]["CurrencyID"].ToString());
					}
					if(dt.Rows[n]["CurrencyCode"]!=null && dt.Rows[n]["CurrencyCode"].ToString()!="")
					{
					model.CurrencyCode=dt.Rows[n]["CurrencyCode"].ToString();
					}
					if(dt.Rows[n]["CurrencyName1"]!=null && dt.Rows[n]["CurrencyName1"].ToString()!="")
					{
					model.CurrencyName1=dt.Rows[n]["CurrencyName1"].ToString();
					}
					if(dt.Rows[n]["CurrencyName2"]!=null && dt.Rows[n]["CurrencyName2"].ToString()!="")
					{
					model.CurrencyName2=dt.Rows[n]["CurrencyName2"].ToString();
					}
					if(dt.Rows[n]["CurrencyName3"]!=null && dt.Rows[n]["CurrencyName3"].ToString()!="")
					{
					model.CurrencyName3=dt.Rows[n]["CurrencyName3"].ToString();
					}
					if(dt.Rows[n]["Rate"]!=null && dt.Rows[n]["Rate"].ToString()!="")
					{
						model.Rate=decimal.Parse(dt.Rows[n]["Rate"].ToString());
					}
					if(dt.Rows[n]["TenderType"]!=null && dt.Rows[n]["TenderType"].ToString()!="")
					{
						model.TenderType=int.Parse(dt.Rows[n]["TenderType"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["CashSale"]!=null && dt.Rows[n]["CashSale"].ToString()!="")
					{
						model.CashSale=int.Parse(dt.Rows[n]["CashSale"].ToString());
					}
					if(dt.Rows[n]["CouponValue"]!=null && dt.Rows[n]["CouponValue"].ToString()!="")
					{
						model.CouponValue=int.Parse(dt.Rows[n]["CouponValue"].ToString());
					}
					if(dt.Rows[n]["Base"]!=null && dt.Rows[n]["Base"].ToString()!="")
					{
						model.Base=decimal.Parse(dt.Rows[n]["Base"].ToString());
					}
					if(dt.Rows[n]["MinAmt"]!=null && dt.Rows[n]["MinAmt"].ToString()!="")
					{
						model.MinAmt=decimal.Parse(dt.Rows[n]["MinAmt"].ToString());
					}
					if(dt.Rows[n]["MaxAmt"]!=null && dt.Rows[n]["MaxAmt"].ToString()!="")
					{
						model.MaxAmt=decimal.Parse(dt.Rows[n]["MaxAmt"].ToString());
					}
					if(dt.Rows[n]["CardType"]!=null && dt.Rows[n]["CardType"].ToString()!="")
					{
					model.CardType=dt.Rows[n]["CardType"].ToString();
					}
					if(dt.Rows[n]["CardBegin"]!=null && dt.Rows[n]["CardBegin"].ToString()!="")
					{
					model.CardBegin=dt.Rows[n]["CardBegin"].ToString();
					}
					if(dt.Rows[n]["CardEnd"]!=null && dt.Rows[n]["CardEnd"].ToString()!="")
					{
					model.CardEnd=dt.Rows[n]["CardEnd"].ToString();
					}
					if(dt.Rows[n]["CardLen"]!=null && dt.Rows[n]["CardLen"].ToString()!="")
					{
						model.CardLen=int.Parse(dt.Rows[n]["CardLen"].ToString());
					}
					if(dt.Rows[n]["AccountCode"]!=null && dt.Rows[n]["AccountCode"].ToString()!="")
					{
					model.AccountCode=dt.Rows[n]["AccountCode"].ToString();
					}
					if(dt.Rows[n]["ContraCode"]!=null && dt.Rows[n]["ContraCode"].ToString()!="")
					{
					model.ContraCode=dt.Rows[n]["ContraCode"].ToString();
					}
					if(dt.Rows[n]["PayTransfer"]!=null && dt.Rows[n]["PayTransfer"].ToString()!="")
					{
						model.PayTransfer=int.Parse(dt.Rows[n]["PayTransfer"].ToString());
					}
					if(dt.Rows[n]["Refund_Type"]!=null && dt.Rows[n]["Refund_Type"].ToString()!="")
					{
						model.Refund_Type=int.Parse(dt.Rows[n]["Refund_Type"].ToString());
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

