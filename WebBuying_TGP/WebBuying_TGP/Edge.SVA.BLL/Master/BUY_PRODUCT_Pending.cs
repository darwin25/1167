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
	/// 货品表 (待审核表)
	/// </summary>
	public partial class BUY_PRODUCT_Pending
	{
		private readonly IBUY_PRODUCT_Pending dal=DataAccess.CreateBUY_PRODUCT_Pending();
		public BUY_PRODUCT_Pending()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode)
		{
			return dal.Exists(ProdCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_PRODUCT_Pending model)
		{
			return dal.Add(model);
		}
        public bool Add(string prodCode)
        {
            return dal.Add(prodCode);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCT_Pending model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdCode)
		{
			
			return dal.Delete(ProdCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProdCodelist )
		{
			return dal.DeleteList(ProdCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_Pending GetModel(string ProdCode)
		{
			
			return dal.GetModel(ProdCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_Pending GetModelByCache(string ProdCode)
		{
			
			string CacheKey = "BUY_PRODUCT_PendingModel-" + ProdCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProdCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_PRODUCT_Pending)objModel;
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
		public List<Edge.SVA.Model.BUY_PRODUCT_Pending> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PRODUCT_Pending> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PRODUCT_Pending> modelList = new List<Edge.SVA.Model.BUY_PRODUCT_Pending>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PRODUCT_Pending model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PRODUCT_Pending();
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["ProdDesc1"]!=null && dt.Rows[n]["ProdDesc1"].ToString()!="")
					{
					model.ProdDesc1=dt.Rows[n]["ProdDesc1"].ToString();
					}
					if(dt.Rows[n]["ProdDesc2"]!=null && dt.Rows[n]["ProdDesc2"].ToString()!="")
					{
					model.ProdDesc2=dt.Rows[n]["ProdDesc2"].ToString();
					}
					if(dt.Rows[n]["ProdDesc3"]!=null && dt.Rows[n]["ProdDesc3"].ToString()!="")
					{
					model.ProdDesc3=dt.Rows[n]["ProdDesc3"].ToString();
					}
					if(dt.Rows[n]["ProdPicFile"]!=null && dt.Rows[n]["ProdPicFile"].ToString()!="")
					{
					model.ProdPicFile=dt.Rows[n]["ProdPicFile"].ToString();
					}
					if(dt.Rows[n]["ScanDesc1"]!=null && dt.Rows[n]["ScanDesc1"].ToString()!="")
					{
					model.ScanDesc1=dt.Rows[n]["ScanDesc1"].ToString();
					}
					if(dt.Rows[n]["ScanDesc2"]!=null && dt.Rows[n]["ScanDesc2"].ToString()!="")
					{
					model.ScanDesc2=dt.Rows[n]["ScanDesc2"].ToString();
					}
					if(dt.Rows[n]["ScanDesc3"]!=null && dt.Rows[n]["ScanDesc3"].ToString()!="")
					{
					model.ScanDesc3=dt.Rows[n]["ScanDesc3"].ToString();
					}
					if(dt.Rows[n]["BrandCode"]!=null && dt.Rows[n]["BrandCode"].ToString()!="")
					{
					model.BrandCode=dt.Rows[n]["BrandCode"].ToString();
					}
					if(dt.Rows[n]["PackageSizeCode"]!=null && dt.Rows[n]["PackageSizeCode"].ToString()!="")
					{
					model.PackageSizeCode=dt.Rows[n]["PackageSizeCode"].ToString();
					}
					if(dt.Rows[n]["DepartCode"]!=null && dt.Rows[n]["DepartCode"].ToString()!="")
					{
					model.DepartCode=dt.Rows[n]["DepartCode"].ToString();
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["MinOrderQty"]!=null && dt.Rows[n]["MinOrderQty"].ToString()!="")
					{
						model.MinOrderQty=decimal.Parse(dt.Rows[n]["MinOrderQty"].ToString());
					}
					if(dt.Rows[n]["OrderType"]!=null && dt.Rows[n]["OrderType"].ToString()!="")
					{
						model.OrderType=int.Parse(dt.Rows[n]["OrderType"].ToString());
					}
					if(dt.Rows[n]["WarehouseCode"]!=null && dt.Rows[n]["WarehouseCode"].ToString()!="")
					{
					model.WarehouseCode=dt.Rows[n]["WarehouseCode"].ToString();
					}
					if(dt.Rows[n]["ProdClassCode"]!=null && dt.Rows[n]["ProdClassCode"].ToString()!="")
					{
					model.ProdClassCode=dt.Rows[n]["ProdClassCode"].ToString();
					}
					if(dt.Rows[n]["GapProdCode"]!=null && dt.Rows[n]["GapProdCode"].ToString()!="")
					{
					model.GapProdCode=dt.Rows[n]["GapProdCode"].ToString();
					}
					if(dt.Rows[n]["ShelfLife"]!=null && dt.Rows[n]["ShelfLife"].ToString()!="")
					{
						model.ShelfLife=int.Parse(dt.Rows[n]["ShelfLife"].ToString());
					}
					if(dt.Rows[n]["ProdSpec"]!=null && dt.Rows[n]["ProdSpec"].ToString()!="")
					{
					model.ProdSpec=dt.Rows[n]["ProdSpec"].ToString();
					}
					if(dt.Rows[n]["ProdLength"]!=null && dt.Rows[n]["ProdLength"].ToString()!="")
					{
						model.ProdLength=decimal.Parse(dt.Rows[n]["ProdLength"].ToString());
					}
					if(dt.Rows[n]["ProdWidth"]!=null && dt.Rows[n]["ProdWidth"].ToString()!="")
					{
						model.ProdWidth=decimal.Parse(dt.Rows[n]["ProdWidth"].ToString());
					}
					if(dt.Rows[n]["ProdHeight"]!=null && dt.Rows[n]["ProdHeight"].ToString()!="")
					{
						model.ProdHeight=decimal.Parse(dt.Rows[n]["ProdHeight"].ToString());
					}
					if(dt.Rows[n]["RefGP"]!=null && dt.Rows[n]["RefGP"].ToString()!="")
					{
						model.RefGP=decimal.Parse(dt.Rows[n]["RefGP"].ToString());
					}
					if(dt.Rows[n]["NonOrder"]!=null && dt.Rows[n]["NonOrder"].ToString()!="")
					{
						model.NonOrder=int.Parse(dt.Rows[n]["NonOrder"].ToString());
					}
					if(dt.Rows[n]["NonSale"]!=null && dt.Rows[n]["NonSale"].ToString()!="")
					{
						model.NonSale=int.Parse(dt.Rows[n]["NonSale"].ToString());
					}
					if(dt.Rows[n]["Consignment"]!=null && dt.Rows[n]["Consignment"].ToString()!="")
					{
						model.Consignment=int.Parse(dt.Rows[n]["Consignment"].ToString());
					}
					if(dt.Rows[n]["WeightItem"]!=null && dt.Rows[n]["WeightItem"].ToString()!="")
					{
						model.WeightItem=int.Parse(dt.Rows[n]["WeightItem"].ToString());
					}
					if(dt.Rows[n]["DiscAllow"]!=null && dt.Rows[n]["DiscAllow"].ToString()!="")
					{
						model.DiscAllow=int.Parse(dt.Rows[n]["DiscAllow"].ToString());
					}
					if(dt.Rows[n]["CouponAllow"]!=null && dt.Rows[n]["CouponAllow"].ToString()!="")
					{
						model.CouponAllow=int.Parse(dt.Rows[n]["CouponAllow"].ToString());
					}
					if(dt.Rows[n]["VisuaItem"]!=null && dt.Rows[n]["VisuaItem"].ToString()!="")
					{
						model.VisuaItem=int.Parse(dt.Rows[n]["VisuaItem"].ToString());
					}
					if(dt.Rows[n]["TaxRate"]!=null && dt.Rows[n]["TaxRate"].ToString()!="")
					{
						model.TaxRate=decimal.Parse(dt.Rows[n]["TaxRate"].ToString());
					}
					if(dt.Rows[n]["ImportTax"]!=null && dt.Rows[n]["ImportTax"].ToString()!="")
					{
						model.ImportTax=decimal.Parse(dt.Rows[n]["ImportTax"].ToString());
					}
					if(dt.Rows[n]["Insurance"]!=null && dt.Rows[n]["Insurance"].ToString()!="")
					{
						model.Insurance=decimal.Parse(dt.Rows[n]["Insurance"].ToString());
					}
					if(dt.Rows[n]["Freight"]!=null && dt.Rows[n]["Freight"].ToString()!="")
					{
						model.Freight=decimal.Parse(dt.Rows[n]["Freight"].ToString());
					}
					if(dt.Rows[n]["OthersExpense"]!=null && dt.Rows[n]["OthersExpense"].ToString()!="")
					{
						model.OthersExpense=decimal.Parse(dt.Rows[n]["OthersExpense"].ToString());
					}
					if(dt.Rows[n]["OriginCountryCode"]!=null && dt.Rows[n]["OriginCountryCode"].ToString()!="")
					{
					model.OriginCountryCode=dt.Rows[n]["OriginCountryCode"].ToString();
					}
					if(dt.Rows[n]["ProductType"]!=null && dt.Rows[n]["ProductType"].ToString()!="")
					{
						model.ProductType=int.Parse(dt.Rows[n]["ProductType"].ToString());
					}
					if(dt.Rows[n]["Modifier"]!=null && dt.Rows[n]["Modifier"].ToString()!="")
					{
						model.Modifier=int.Parse(dt.Rows[n]["Modifier"].ToString());
					}
					if(dt.Rows[n]["BOM"]!=null && dt.Rows[n]["BOM"].ToString()!="")
					{
						model.BOM=int.Parse(dt.Rows[n]["BOM"].ToString());
					}
					if(dt.Rows[n]["MutexFlag"]!=null && dt.Rows[n]["MutexFlag"].ToString()!="")
					{
						model.MutexFlag=int.Parse(dt.Rows[n]["MutexFlag"].ToString());
					}
					if(dt.Rows[n]["OnAccount"]!=null && dt.Rows[n]["OnAccount"].ToString()!="")
					{
						model.OnAccount=int.Parse(dt.Rows[n]["OnAccount"].ToString());
					}
					if(dt.Rows[n]["FulfillmentHouseCode"]!=null && dt.Rows[n]["FulfillmentHouseCode"].ToString()!="")
					{
					model.FulfillmentHouseCode=dt.Rows[n]["FulfillmentHouseCode"].ToString();
					}
					if(dt.Rows[n]["ReplenFormulaCode"]!=null && dt.Rows[n]["ReplenFormulaCode"].ToString()!="")
					{
					model.ReplenFormulaCode=dt.Rows[n]["ReplenFormulaCode"].ToString();
					}
					if(dt.Rows[n]["DiscountLimit"]!=null && dt.Rows[n]["DiscountLimit"].ToString()!="")
					{
						model.DiscountLimit=decimal.Parse(dt.Rows[n]["DiscountLimit"].ToString());
					}
					if(dt.Rows[n]["CostCCC"]!=null && dt.Rows[n]["CostCCC"].ToString()!="")
					{
					model.CostCCC=dt.Rows[n]["CostCCC"].ToString();
					}
					if(dt.Rows[n]["CostWO"]!=null && dt.Rows[n]["CostWO"].ToString()!="")
					{
					model.CostWO=dt.Rows[n]["CostWO"].ToString();
					}
					if(dt.Rows[n]["RevenueCCC"]!=null && dt.Rows[n]["RevenueCCC"].ToString()!="")
					{
					model.RevenueCCC=dt.Rows[n]["RevenueCCC"].ToString();
					}
					if(dt.Rows[n]["RevenueWO"]!=null && dt.Rows[n]["RevenueWO"].ToString()!="")
					{
					model.RevenueWO=dt.Rows[n]["RevenueWO"].ToString();
					}
					if(dt.Rows[n]["QuotaPerShopPeriod"]!=null && dt.Rows[n]["QuotaPerShopPeriod"].ToString()!="")
					{
						model.QuotaPerShopPeriod=int.Parse(dt.Rows[n]["QuotaPerShopPeriod"].ToString());
					}
					if(dt.Rows[n]["CouponSKU"]!=null && dt.Rows[n]["CouponSKU"].ToString()!="")
					{
						model.CouponSKU=int.Parse(dt.Rows[n]["CouponSKU"].ToString());
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["DefaultPickupStoreCode"]!=null && dt.Rows[n]["DefaultPickupStoreCode"].ToString()!="")
					{
					model.DefaultPickupStoreCode=dt.Rows[n]["DefaultPickupStoreCode"].ToString();
					}
					if(dt.Rows[n]["ColorCode"]!=null && dt.Rows[n]["ColorCode"].ToString()!="")
					{
					model.ColorCode=dt.Rows[n]["ColorCode"].ToString();
					}
					if(dt.Rows[n]["ProductSizeCode"]!=null && dt.Rows[n]["ProductSizeCode"].ToString()!="")
					{
					model.ProductSizeCode=dt.Rows[n]["ProductSizeCode"].ToString();
					}
					if(dt.Rows[n]["AddPointFlag"]!=null && dt.Rows[n]["AddPointFlag"].ToString()!="")
					{
						model.AddPointFlag=int.Parse(dt.Rows[n]["AddPointFlag"].ToString());
					}
					if(dt.Rows[n]["AddPointValue"]!=null && dt.Rows[n]["AddPointValue"].ToString()!="")
					{
						model.AddPointValue=int.Parse(dt.Rows[n]["AddPointValue"].ToString());
					}
					if(dt.Rows[n]["InTax"]!=null && dt.Rows[n]["InTax"].ToString()!="")
					{
						model.InTax=int.Parse(dt.Rows[n]["InTax"].ToString());
					}
					if(dt.Rows[n]["Additional"]!=null && dt.Rows[n]["Additional"].ToString()!="")
					{
					model.Additional=dt.Rows[n]["Additional"].ToString();
					}
					if(dt.Rows[n]["Flag1"]!=null && dt.Rows[n]["Flag1"].ToString()!="")
					{
						model.Flag1=int.Parse(dt.Rows[n]["Flag1"].ToString());
					}
					if(dt.Rows[n]["Flag2"]!=null && dt.Rows[n]["Flag2"].ToString()!="")
					{
						model.Flag2=int.Parse(dt.Rows[n]["Flag2"].ToString());
					}
					if(dt.Rows[n]["Flag3"]!=null && dt.Rows[n]["Flag3"].ToString()!="")
					{
						model.Flag3=int.Parse(dt.Rows[n]["Flag3"].ToString());
					}
					if(dt.Rows[n]["Flag4"]!=null && dt.Rows[n]["Flag4"].ToString()!="")
					{
						model.Flag4=int.Parse(dt.Rows[n]["Flag4"].ToString());
					}
					if(dt.Rows[n]["Flag5"]!=null && dt.Rows[n]["Flag5"].ToString()!="")
					{
						model.Flag5=int.Parse(dt.Rows[n]["Flag5"].ToString());
					}
					if(dt.Rows[n]["Flag6"]!=null && dt.Rows[n]["Flag6"].ToString()!="")
					{
						model.Flag6=int.Parse(dt.Rows[n]["Flag6"].ToString());
					}
					if(dt.Rows[n]["Flag7"]!=null && dt.Rows[n]["Flag7"].ToString()!="")
					{
						model.Flag7=int.Parse(dt.Rows[n]["Flag7"].ToString());
					}
					if(dt.Rows[n]["Flag8"]!=null && dt.Rows[n]["Flag8"].ToString()!="")
					{
						model.Flag8=int.Parse(dt.Rows[n]["Flag8"].ToString());
					}
					if(dt.Rows[n]["Flag9"]!=null && dt.Rows[n]["Flag9"].ToString()!="")
					{
						model.Flag9=int.Parse(dt.Rows[n]["Flag9"].ToString());
					}
					if(dt.Rows[n]["Flag10"]!=null && dt.Rows[n]["Flag10"].ToString()!="")
					{
						model.Flag10=int.Parse(dt.Rows[n]["Flag10"].ToString());
					}
					if(dt.Rows[n]["Memo1"]!=null && dt.Rows[n]["Memo1"].ToString()!="")
					{
					model.Memo1=dt.Rows[n]["Memo1"].ToString();
					}
					if(dt.Rows[n]["Memo2"]!=null && dt.Rows[n]["Memo2"].ToString()!="")
					{
					model.Memo2=dt.Rows[n]["Memo2"].ToString();
					}
					if(dt.Rows[n]["Memo3"]!=null && dt.Rows[n]["Memo3"].ToString()!="")
					{
					model.Memo3=dt.Rows[n]["Memo3"].ToString();
					}
					if(dt.Rows[n]["Memo4"]!=null && dt.Rows[n]["Memo4"].ToString()!="")
					{
					model.Memo4=dt.Rows[n]["Memo4"].ToString();
					}
					if(dt.Rows[n]["Memo5"]!=null && dt.Rows[n]["Memo5"].ToString()!="")
					{
					model.Memo5=dt.Rows[n]["Memo5"].ToString();
					}
					if(dt.Rows[n]["Memo6"]!=null && dt.Rows[n]["Memo6"].ToString()!="")
					{
					model.Memo6=dt.Rows[n]["Memo6"].ToString();
					}
					if(dt.Rows[n]["Memo7"]!=null && dt.Rows[n]["Memo7"].ToString()!="")
					{
					model.Memo7=dt.Rows[n]["Memo7"].ToString();
					}
					if(dt.Rows[n]["Memo8"]!=null && dt.Rows[n]["Memo8"].ToString()!="")
					{
					model.Memo8=dt.Rows[n]["Memo8"].ToString();
					}
					if(dt.Rows[n]["Memo9"]!=null && dt.Rows[n]["Memo9"].ToString()!="")
					{
					model.Memo9=dt.Rows[n]["Memo9"].ToString();
					}
					if(dt.Rows[n]["Memo10"]!=null && dt.Rows[n]["Memo10"].ToString()!="")
					{
					model.Memo10=dt.Rows[n]["Memo10"].ToString();
					}
					if(dt.Rows[n]["isOnlineSKU"]!=null && dt.Rows[n]["isOnlineSKU"].ToString()!="")
					{
						model.isOnlineSKU=int.Parse(dt.Rows[n]["isOnlineSKU"].ToString());
					}
					if(dt.Rows[n]["SKUWeight"]!=null && dt.Rows[n]["SKUWeight"].ToString()!="")
					{
						model.SKUWeight=decimal.Parse(dt.Rows[n]["SKUWeight"].ToString());
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
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["ApprovedBy"]!=null && dt.Rows[n]["ApprovedBy"].ToString()!="")
					{
						model.ApprovedBy=int.Parse(dt.Rows[n]["ApprovedBy"].ToString());
					}
					if(dt.Rows[n]["ApprovedOn"]!=null && dt.Rows[n]["ApprovedOn"].ToString()!="")
					{
						model.ApprovedOn=DateTime.Parse(dt.Rows[n]["ApprovedOn"].ToString());
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

