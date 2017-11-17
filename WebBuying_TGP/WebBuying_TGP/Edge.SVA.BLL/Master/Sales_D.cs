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
	/// 业务逻辑类:Sales_D
    /// 创建人：Lisa
    /// 创建时间：2016-1-2
	/// </summary>
	public partial class Sales_D
	{
		private readonly ISales_D dal=DataAccess.CreateSales_D();
		public Sales_D(){}
		
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SeqNo,string TransNum)
		{
			return dal.Exists(SeqNo,TransNum);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Sales_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Sales_D model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SeqNo,string TransNum)
		{
			
			return dal.Delete(SeqNo,TransNum);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Sales_D GetModel(string SeqNo,string TransNum)
		{
			
			return dal.GetModel(SeqNo,TransNum);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Sales_D GetModelByCache(string SeqNo,string TransNum)
		{
			
			string CacheKey = "Sales_DModel-" + SeqNo+TransNum;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SeqNo,TransNum);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.Sales_D)objModel;
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
		public List<Edge.SVA.Model.Sales_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Sales_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Sales_D> modelList = new List<Edge.SVA.Model.Sales_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Sales_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Sales_D();
					
					if(dt.Rows[n]["SeqNo"]!=null)
				{
					model.SeqNo=dt.Rows[n]["SeqNo"].ToString();
				}
				if(dt.Rows[n]["TransNum"]!=null)
				{
					model.TransNum=dt.Rows[n]["TransNum"].ToString();
				}
				if(dt.Rows[n]["TransType"]!=null && dt.Rows[n]["TransType"].ToString()!="")
				{
					model.TransType=int.Parse(dt.Rows[n]["TransType"].ToString());
				}
				if(dt.Rows[n]["StoreCode"]!=null)
				{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
				}
				if(dt.Rows[n]["RegisterCode"]!=null)
				{
					model.RegisterCode=dt.Rows[n]["RegisterCode"].ToString();
				}
				if(dt.Rows[n]["BusDate"]!=null && dt.Rows[n]["BusDate"].ToString()!="")
				{
					model.BusDate=DateTime.Parse(dt.Rows[n]["BusDate"].ToString());
				}
				if(dt.Rows[n]["TxnDate"]!=null && dt.Rows[n]["TxnDate"].ToString()!="")
				{
					model.TxnDate=DateTime.Parse(dt.Rows[n]["TxnDate"].ToString());
				}
				if(dt.Rows[n]["ProdCode"]!=null)
				{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
				}
				if(dt.Rows[n]["ProdDesc"]!=null)
				{
					model.ProdDesc=dt.Rows[n]["ProdDesc"].ToString();
				}
				if(dt.Rows[n]["DepartCode"]!=null)
				{
					model.DepartCode=dt.Rows[n]["DepartCode"].ToString();
				}
				if(dt.Rows[n]["Qty"]!=null && dt.Rows[n]["Qty"].ToString()!="")
				{
					model.Qty=decimal.Parse(dt.Rows[n]["Qty"].ToString());
				}
				if(dt.Rows[n]["OrgPrice"]!=null && dt.Rows[n]["OrgPrice"].ToString()!="")
				{
					model.OrgPrice=decimal.Parse(dt.Rows[n]["OrgPrice"].ToString());
				}
				if(dt.Rows[n]["UnitPrice"]!=null && dt.Rows[n]["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
				}
				if(dt.Rows[n]["NetPrice"]!=null && dt.Rows[n]["NetPrice"].ToString()!="")
				{
					model.NetPrice=decimal.Parse(dt.Rows[n]["NetPrice"].ToString());
				}
				if(dt.Rows[n]["OrgAmount"]!=null && dt.Rows[n]["OrgAmount"].ToString()!="")
				{
					model.OrgAmount=decimal.Parse(dt.Rows[n]["OrgAmount"].ToString());
				}
				if(dt.Rows[n]["UnitAmount"]!=null && dt.Rows[n]["UnitAmount"].ToString()!="")
				{
					model.UnitAmount=decimal.Parse(dt.Rows[n]["UnitAmount"].ToString());
				}
				if(dt.Rows[n]["NetAmount"]!=null && dt.Rows[n]["NetAmount"].ToString()!="")
				{
					model.NetAmount=decimal.Parse(dt.Rows[n]["NetAmount"].ToString());
				}
				if(dt.Rows[n]["TotalQty"]!=null && dt.Rows[n]["TotalQty"].ToString()!="")
				{
					model.TotalQty=decimal.Parse(dt.Rows[n]["TotalQty"].ToString());
				}
				if(dt.Rows[n]["DiscountPrice"]!=null && dt.Rows[n]["DiscountPrice"].ToString()!="")
				{
					model.DiscountPrice=decimal.Parse(dt.Rows[n]["DiscountPrice"].ToString());
				}
				if(dt.Rows[n]["DiscountAmount"]!=null && dt.Rows[n]["DiscountAmount"].ToString()!="")
				{
					model.DiscountAmount=decimal.Parse(dt.Rows[n]["DiscountAmount"].ToString());
				}
				if(dt.Rows[n]["POPrice"]!=null && dt.Rows[n]["POPrice"].ToString()!="")
				{
					model.POPrice=decimal.Parse(dt.Rows[n]["POPrice"].ToString());
				}
				if(dt.Rows[n]["ExtraPrice"]!=null && dt.Rows[n]["ExtraPrice"].ToString()!="")
				{
					model.ExtraPrice=decimal.Parse(dt.Rows[n]["ExtraPrice"].ToString());
				}
				if(dt.Rows[n]["POReasonCode"]!=null)
				{
					model.POReasonCode=dt.Rows[n]["POReasonCode"].ToString();
				}
				if(dt.Rows[n]["Additional1"]!=null)
				{
					model.Additional1=dt.Rows[n]["Additional1"].ToString();
				}
				if(dt.Rows[n]["Additional2"]!=null)
				{
					model.Additional2=dt.Rows[n]["Additional2"].ToString();
				}
				if(dt.Rows[n]["Additional3"]!=null)
				{
					model.Additional3=dt.Rows[n]["Additional3"].ToString();
				}
				if(dt.Rows[n]["RPriceTypeCode"]!=null)
				{
					model.RPriceTypeCode=dt.Rows[n]["RPriceTypeCode"].ToString();
				}
				if(dt.Rows[n]["IsBOM"]!=null && dt.Rows[n]["IsBOM"].ToString()!="")
				{
					model.IsBOM=int.Parse(dt.Rows[n]["IsBOM"].ToString());
				}
				if(dt.Rows[n]["IsCoupon"]!=null && dt.Rows[n]["IsCoupon"].ToString()!="")
				{
					model.IsCoupon=int.Parse(dt.Rows[n]["IsCoupon"].ToString());
				}
				if(dt.Rows[n]["IsBuyBack"]!=null && dt.Rows[n]["IsBuyBack"].ToString()!="")
				{
					model.IsBuyBack=int.Parse(dt.Rows[n]["IsBuyBack"].ToString());
				}
				if(dt.Rows[n]["IsService"]!=null && dt.Rows[n]["IsService"].ToString()!="")
				{
					model.IsService=int.Parse(dt.Rows[n]["IsService"].ToString());
				}
				if(dt.Rows[n]["SerialNoStockFlag"]!=null && dt.Rows[n]["SerialNoStockFlag"].ToString()!="")
				{
					model.SerialNoStockFlag=int.Parse(dt.Rows[n]["SerialNoStockFlag"].ToString());
				}
				if(dt.Rows[n]["SerialNoType"]!=null && dt.Rows[n]["SerialNoType"].ToString()!="")
				{
					model.SerialNoType=int.Parse(dt.Rows[n]["SerialNoType"].ToString());
				}
				if(dt.Rows[n]["SerialNo"]!=null)
				{
					model.SerialNo=dt.Rows[n]["SerialNo"].ToString();
				}
				if(dt.Rows[n]["IMEI"]!=null)
				{
					model.IMEI=dt.Rows[n]["IMEI"].ToString();
				}
				if(dt.Rows[n]["StockTypeCode"]!=null)
				{
					model.StockTypeCode=dt.Rows[n]["StockTypeCode"].ToString();
				}
				if(dt.Rows[n]["Collected"]!=null && dt.Rows[n]["Collected"].ToString()!="")
				{
					model.Collected=int.Parse(dt.Rows[n]["Collected"].ToString());
				}
				if(dt.Rows[n]["ReservedDate"]!=null && dt.Rows[n]["ReservedDate"].ToString()!="")
				{
					model.ReservedDate=DateTime.Parse(dt.Rows[n]["ReservedDate"].ToString());
				}
				if(dt.Rows[n]["PickupLocation"]!=null)
				{
					model.PickupLocation=dt.Rows[n]["PickupLocation"].ToString();
				}
				if(dt.Rows[n]["PickupStaff"]!=null)
				{
					model.PickupStaff=dt.Rows[n]["PickupStaff"].ToString();
				}
				if(dt.Rows[n]["PickupDate"]!=null && dt.Rows[n]["PickupDate"].ToString()!="")
				{
					model.PickupDate=DateTime.Parse(dt.Rows[n]["PickupDate"].ToString());
				}
				if(dt.Rows[n]["DeliveryDate"]!=null && dt.Rows[n]["DeliveryDate"].ToString()!="")
				{
					model.DeliveryDate=DateTime.Parse(dt.Rows[n]["DeliveryDate"].ToString());
				}
				if(dt.Rows[n]["DeliveryBy"]!=null && dt.Rows[n]["DeliveryBy"].ToString()!="")
				{
					model.DeliveryBy=int.Parse(dt.Rows[n]["DeliveryBy"].ToString());
				}
				if(dt.Rows[n]["ActPrice"]!=null && dt.Rows[n]["ActPrice"].ToString()!="")
				{
					model.ActPrice=decimal.Parse(dt.Rows[n]["ActPrice"].ToString());
				}
				if(dt.Rows[n]["ActAmount"]!=null && dt.Rows[n]["ActAmount"].ToString()!="")
				{
					model.ActAmount=decimal.Parse(dt.Rows[n]["ActAmount"].ToString());
				}
				if(dt.Rows[n]["OrgTransNum"]!=null)
				{
					model.OrgTransNum=dt.Rows[n]["OrgTransNum"].ToString();
				}
				if(dt.Rows[n]["OrgSeqNo"]!=null)
				{
					model.OrgSeqNo=dt.Rows[n]["OrgSeqNo"].ToString();
				}
				if(dt.Rows[n]["Remark"]!=null)
				{
					model.Remark=dt.Rows[n]["Remark"].ToString();
				}
				if(dt.Rows[n]["RefGUID"]!=null)
				{
					model.RefGUID=dt.Rows[n]["RefGUID"].ToString();
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

         /// <summary>
        /// 求总库存数量
        /// 创建人：Lisa
        /// 创建时间：2016-03-28
        /// </summary>
        /// <returns></returns>
        public DataSet GetSummary(string strWhere)
        {
            return dal.GetSummary(strWhere);
        }

		#endregion  BasicMethod
	}
}

