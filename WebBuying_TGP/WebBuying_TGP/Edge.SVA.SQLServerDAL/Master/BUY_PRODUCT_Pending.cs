﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_PRODUCT_Pending
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCT_Pending:IBUY_PRODUCT_Pending
	{
		public BUY_PRODUCT_Pending()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_PRODUCT_Pending");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_PRODUCT_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_PRODUCT_Pending(");
            strSql.Append("ProdCode,ProdDesc1,ProdDesc2,ProdDesc3,ProdPicFile,ScanDesc1,ScanDesc2,ScanDesc3,BrandCode,PackageSizeCode,DepartCode,");
            strSql.Append("StoreCode,MinOrderQty,OrderType,WarehouseCode,ProdClassCode,GapProdCode,ShelfLife,ProdSpec,ProdLength,ProdWidth,ProdHeight,");
            strSql.Append("RefGP,NonOrder,NonSale,Consignment,WeightItem,DiscAllow,CouponAllow,VisuaItem,TaxRate,ImportTax,Insurance,Freight,OthersExpense,");
            strSql.Append("OriginCountryCode,ProductType,Modifier,BOM,MutexFlag,OnAccount,FulfillmentHouseCode,ReplenFormulaCode,DiscountLimit,CostCCC,");
            strSql.Append("CostWO,RevenueCCC,RevenueWO,QuotaPerShopPeriod,CouponSKU,StartDate,EndDate,DefaultPickupStoreCode,ColorCode,ProductSizeCode,");
            strSql.Append("AddPointFlag,AddPointValue,InTax,Additional,Flag1,Flag2,Flag3,Flag4,Flag5,Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,");
            strSql.Append("Memo5,Memo6,Memo7,Memo8,Memo9,Memo10,isOnlineSKU,SKUWeight,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,Status,ApprovedBy,ApprovedOn,StoreBrandCode)");
			strSql.Append(" values (");
            strSql.Append("@ProdCode,@ProdDesc1,@ProdDesc2,@ProdDesc3,@ProdPicFile,@ScanDesc1,@ScanDesc2,@ScanDesc3,@BrandCode,@PackageSizeCode,@DepartCode,");
            strSql.Append("@StoreCode,@MinOrderQty,@OrderType,@WarehouseCode,@ProdClassCode,@GapProdCode,@ShelfLife,@ProdSpec,@ProdLength,@ProdWidth,@ProdHeight,@RefGP,");
            strSql.Append("@NonOrder,@NonSale,@Consignment,@WeightItem,@DiscAllow,@CouponAllow,@VisuaItem,@TaxRate,@ImportTax,@Insurance,@Freight,@OthersExpense,");
            strSql.Append("@OriginCountryCode,@ProductType,@Modifier,@BOM,@MutexFlag,@OnAccount,@FulfillmentHouseCode,@ReplenFormulaCode,@DiscountLimit,@CostCCC,@CostWO,");
            strSql.Append("@RevenueCCC,@RevenueWO,@QuotaPerShopPeriod,@CouponSKU,@StartDate,@EndDate,@DefaultPickupStoreCode,@ColorCode,@ProductSizeCode,@AddPointFlag,");
            strSql.Append("@AddPointValue,@InTax,@Additional,@Flag1,@Flag2,@Flag3,@Flag4,@Flag5,@Flag6,@Flag7,@Flag8,@Flag9,@Flag10,@Memo1,@Memo2,@Memo3,@Memo4,@Memo5,@Memo6,");
            strSql.Append("@Memo7,@Memo8,@Memo9,@Memo10,@isOnlineSKU,@SKUWeight,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@Status,@ApprovedBy,@ApprovedOn,@StoreBrandCode)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@ScanDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ScanDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ScanDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@PackageSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@MinOrderQty", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@WarehouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdClassCode", SqlDbType.VarChar,64),
					new SqlParameter("@GapProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ShelfLife", SqlDbType.Int,4),
					new SqlParameter("@ProdSpec", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdLength", SqlDbType.Decimal,9),
					new SqlParameter("@ProdWidth", SqlDbType.Decimal,9),
					new SqlParameter("@ProdHeight", SqlDbType.Decimal,9),
					new SqlParameter("@RefGP", SqlDbType.Decimal,9),
					new SqlParameter("@NonOrder", SqlDbType.Int,4),
					new SqlParameter("@NonSale", SqlDbType.Int,4),
					new SqlParameter("@Consignment", SqlDbType.Int,4),
					new SqlParameter("@WeightItem", SqlDbType.Int,4),
					new SqlParameter("@DiscAllow", SqlDbType.Int,4),
					new SqlParameter("@CouponAllow", SqlDbType.Int,4),
					new SqlParameter("@VisuaItem", SqlDbType.Int,4),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@ImportTax", SqlDbType.Decimal,9),
					new SqlParameter("@Insurance", SqlDbType.Decimal,9),
					new SqlParameter("@Freight", SqlDbType.Decimal,9),
					new SqlParameter("@OthersExpense", SqlDbType.Decimal,9),
					new SqlParameter("@OriginCountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductType", SqlDbType.Int,4),
					new SqlParameter("@Modifier", SqlDbType.Int,4),
					new SqlParameter("@BOM", SqlDbType.Int,4),
					new SqlParameter("@MutexFlag", SqlDbType.Int,4),
					new SqlParameter("@OnAccount", SqlDbType.Int,4),
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64),
					new SqlParameter("@DiscountLimit", SqlDbType.Decimal,9),
					new SqlParameter("@CostCCC", SqlDbType.VarChar,64),
					new SqlParameter("@CostWO", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueCCC", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueWO", SqlDbType.VarChar,64),
					new SqlParameter("@QuotaPerShopPeriod", SqlDbType.Int,4),
					new SqlParameter("@CouponSKU", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@DefaultPickupStoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@ColorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@AddPointFlag", SqlDbType.Int,4),
					new SqlParameter("@AddPointValue", SqlDbType.Int,4),
					new SqlParameter("@InTax", SqlDbType.Int,4),
					new SqlParameter("@Additional", SqlDbType.NVarChar,512),
					new SqlParameter("@Flag1", SqlDbType.Int,4),
					new SqlParameter("@Flag2", SqlDbType.Int,4),
					new SqlParameter("@Flag3", SqlDbType.Int,4),
					new SqlParameter("@Flag4", SqlDbType.Int,4),
					new SqlParameter("@Flag5", SqlDbType.Int,4),
					new SqlParameter("@Flag6", SqlDbType.Int,4),
					new SqlParameter("@Flag7", SqlDbType.Int,4),
					new SqlParameter("@Flag8", SqlDbType.Int,4),
					new SqlParameter("@Flag9", SqlDbType.Int,4),
					new SqlParameter("@Flag10", SqlDbType.Int,4),
					new SqlParameter("@Memo1", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo2", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo3", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo4", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo5", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo6", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo7", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo8", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo9", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo10", SqlDbType.NVarChar,512),
					new SqlParameter("@isOnlineSKU", SqlDbType.Int,4),
					new SqlParameter("@SKUWeight", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApprovedBy", SqlDbType.Int,4),
					new SqlParameter("@ApprovedOn", SqlDbType.DateTime),
                    new SqlParameter("@StoreBrandCode",SqlDbType.VarChar,64)
                                        };
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.ProdDesc1;
			parameters[2].Value = model.ProdDesc2;
			parameters[3].Value = model.ProdDesc3;
			parameters[4].Value = model.ProdPicFile;
			parameters[5].Value = model.ScanDesc1;
			parameters[6].Value = model.ScanDesc2;
			parameters[7].Value = model.ScanDesc3;
			parameters[8].Value = model.BrandCode;
			parameters[9].Value = model.PackageSizeCode;
			parameters[10].Value = model.DepartCode;
			parameters[11].Value = model.StoreCode;
			parameters[12].Value = model.MinOrderQty;
			parameters[13].Value = model.OrderType;
			parameters[14].Value = model.WarehouseCode;
			parameters[15].Value = model.ProdClassCode;
			parameters[16].Value = model.GapProdCode;
			parameters[17].Value = model.ShelfLife;
			parameters[18].Value = model.ProdSpec;
			parameters[19].Value = model.ProdLength;
			parameters[20].Value = model.ProdWidth;
			parameters[21].Value = model.ProdHeight;
			parameters[22].Value = model.RefGP;
			parameters[23].Value = model.NonOrder;
			parameters[24].Value = model.NonSale;
			parameters[25].Value = model.Consignment;
			parameters[26].Value = model.WeightItem;
			parameters[27].Value = model.DiscAllow;
			parameters[28].Value = model.CouponAllow;
			parameters[29].Value = model.VisuaItem;
			parameters[30].Value = model.TaxRate;
			parameters[31].Value = model.ImportTax;
			parameters[32].Value = model.Insurance;
			parameters[33].Value = model.Freight;
			parameters[34].Value = model.OthersExpense;
			parameters[35].Value = model.OriginCountryCode;
			parameters[36].Value = model.ProductType;
			parameters[37].Value = model.Modifier;
			parameters[38].Value = model.BOM;
			parameters[39].Value = model.MutexFlag;
			parameters[40].Value = model.OnAccount;
			parameters[41].Value = model.FulfillmentHouseCode;
			parameters[42].Value = model.ReplenFormulaCode;
			parameters[43].Value = model.DiscountLimit;
			parameters[44].Value = model.CostCCC;
			parameters[45].Value = model.CostWO;
			parameters[46].Value = model.RevenueCCC;
			parameters[47].Value = model.RevenueWO;
			parameters[48].Value = model.QuotaPerShopPeriod;
			parameters[49].Value = model.CouponSKU;
			parameters[50].Value = model.StartDate;
			parameters[51].Value = model.EndDate;
			parameters[52].Value = model.DefaultPickupStoreCode;
			parameters[53].Value = model.ColorCode;
			parameters[54].Value = model.ProductSizeCode;
			parameters[55].Value = model.AddPointFlag;
			parameters[56].Value = model.AddPointValue;
			parameters[57].Value = model.InTax;
			parameters[58].Value = model.Additional;
			parameters[59].Value = model.Flag1;
			parameters[60].Value = model.Flag2;
			parameters[61].Value = model.Flag3;
			parameters[62].Value = model.Flag4;
			parameters[63].Value = model.Flag5;
			parameters[64].Value = model.Flag6;
			parameters[65].Value = model.Flag7;
			parameters[66].Value = model.Flag8;
			parameters[67].Value = model.Flag9;
			parameters[68].Value = model.Flag10;
			parameters[69].Value = model.Memo1;
			parameters[70].Value = model.Memo2;
			parameters[71].Value = model.Memo3;
			parameters[72].Value = model.Memo4;
			parameters[73].Value = model.Memo5;
			parameters[74].Value = model.Memo6;
			parameters[75].Value = model.Memo7;
			parameters[76].Value = model.Memo8;
			parameters[77].Value = model.Memo9;
			parameters[78].Value = model.Memo10;
			parameters[79].Value = model.isOnlineSKU;
			parameters[80].Value = model.SKUWeight;
			parameters[81].Value = model.CreatedOn;
			parameters[82].Value = model.CreatedBy;
			parameters[83].Value = model.UpdatedOn;
			parameters[84].Value = model.UpdatedBy;
			parameters[85].Value = model.Status;
			parameters[86].Value = model.ApprovedBy;
			parameters[87].Value = model.ApprovedOn;
            parameters[88].Value = model.StoreBrandCode;
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        public bool Add(string prodCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_PRODUCT_Pending(ProdCode,ProdDesc1,ProdDesc2, ");
            strSql.Append("ProdDesc3,ProdPicFile,ScanDesc1,ScanDesc2,ScanDesc3,BrandCode,PackageSizeCode,");
            strSql.Append("DepartCode,StoreCode,MinOrderQty,OrderType,WarehouseCode,ProdClassCode,GapProdCode,");
            strSql.Append("ShelfLife,ProdSpec,ProdLength,ProdWidth,ProdHeight,RefGP,NonOrder,NonSale,Consignment,");
            strSql.Append("WeightItem,DiscAllow,CouponAllow,VisuaItem,TaxRate,ImportTax,Insurance,");
            strSql.Append("Freight,OthersExpense,OriginCountryCode,ProductType,Modifier,BOM,MutexFlag,OnAccount,");
            strSql.Append("FulfillmentHouseCode,ReplenFormulaCode,DiscountLimit,CostCCC,CostWO,RevenueCCC,RevenueWO,");
            strSql.Append("QuotaPerShopPeriod,CouponSKU,StartDate,EndDate,DefaultPickupStoreCode,ColorCode,ProductSizeCode,");
            strSql.Append("AddPointFlag,AddPointValue,InTax,Additional,Flag1,Flag2,Flag3,Flag4,Flag5,Flag6,Flag7,Flag8,Flag9,");
            strSql.Append("Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,Memo7,Memo8,Memo9,Memo10,isOnlineSKU,SKUWeight,");
            strSql.Append("CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,ApprovedBy,ApprovedOn,StoreBrandCode )");
            strSql.Append("select ProdCode,ProdDesc1,ProdDesc2,ProdDesc3,ProdPicFile,ScanDesc1,ScanDesc2,ScanDesc3,");
            strSql.Append("BrandCode,PackageSizeCode,DepartCode,StoreCode,MinOrderQty,OrderType,WarehouseCode,ProdClassCode,");
            strSql.Append("GapProdCode,ShelfLife,ProdSpec,ProdLength,ProdWidth,ProdHeight,RefGP,NonOrder,NonSale,Consignment,");
            strSql.Append("WeightItem,DiscAllow,CouponAllow,VisuaItem,TaxRate,ImportTax,Insurance,Freight,OthersExpense,");
            strSql.Append("OriginCountryCode,ProductType,Modifier,BOM,MutexFlag,OnAccount,FulfillmentHouseCode,ReplenFormulaCode,");
            strSql.Append("DiscountLimit,CostCCC,CostWO,RevenueCCC,RevenueWO,QuotaPerShopPeriod,CouponSKU,StartDate,EndDate,");
            strSql.Append("DefaultPickupStoreCode,ColorCode,ProductSizeCode,AddPointFlag,AddPointValue,InTax,Additional,Flag1,");
            strSql.Append("Flag2,Flag3,Flag4,Flag5,Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,");
            strSql.Append("Memo7,Memo8,Memo9,Memo10,isOnlineSKU,SKUWeight,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,ApprovedBy,ApprovedOn,StoreBrandCode ");
            strSql.AppendFormat("from BUY_PRODUCT where ProdCode='{0}'",prodCode);
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCT_Pending model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_PRODUCT_Pending set ");
			strSql.Append("ProdDesc1=@ProdDesc1,");
			strSql.Append("ProdDesc2=@ProdDesc2,");
			strSql.Append("ProdDesc3=@ProdDesc3,");
			strSql.Append("ProdPicFile=@ProdPicFile,");
			strSql.Append("ScanDesc1=@ScanDesc1,");
			strSql.Append("ScanDesc2=@ScanDesc2,");
			strSql.Append("ScanDesc3=@ScanDesc3,");
			strSql.Append("BrandCode=@BrandCode,");
			strSql.Append("PackageSizeCode=@PackageSizeCode,");
			strSql.Append("DepartCode=@DepartCode,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("MinOrderQty=@MinOrderQty,");
			strSql.Append("OrderType=@OrderType,");
			strSql.Append("WarehouseCode=@WarehouseCode,");
			strSql.Append("ProdClassCode=@ProdClassCode,");
			strSql.Append("GapProdCode=@GapProdCode,");
			strSql.Append("ShelfLife=@ShelfLife,");
			strSql.Append("ProdSpec=@ProdSpec,");
			strSql.Append("ProdLength=@ProdLength,");
			strSql.Append("ProdWidth=@ProdWidth,");
			strSql.Append("ProdHeight=@ProdHeight,");
			strSql.Append("RefGP=@RefGP,");
			strSql.Append("NonOrder=@NonOrder,");
			strSql.Append("NonSale=@NonSale,");
			strSql.Append("Consignment=@Consignment,");
			strSql.Append("WeightItem=@WeightItem,");
			strSql.Append("DiscAllow=@DiscAllow,");
			strSql.Append("CouponAllow=@CouponAllow,");
			strSql.Append("VisuaItem=@VisuaItem,");
			strSql.Append("TaxRate=@TaxRate,");
			strSql.Append("ImportTax=@ImportTax,");
			strSql.Append("Insurance=@Insurance,");
			strSql.Append("Freight=@Freight,");
			strSql.Append("OthersExpense=@OthersExpense,");
			strSql.Append("OriginCountryCode=@OriginCountryCode,");
			strSql.Append("ProductType=@ProductType,");
			strSql.Append("Modifier=@Modifier,");
			strSql.Append("BOM=@BOM,");
			strSql.Append("MutexFlag=@MutexFlag,");
			strSql.Append("OnAccount=@OnAccount,");
			strSql.Append("FulfillmentHouseCode=@FulfillmentHouseCode,");
			strSql.Append("ReplenFormulaCode=@ReplenFormulaCode,");
			strSql.Append("DiscountLimit=@DiscountLimit,");
			strSql.Append("CostCCC=@CostCCC,");
			strSql.Append("CostWO=@CostWO,");
			strSql.Append("RevenueCCC=@RevenueCCC,");
			strSql.Append("RevenueWO=@RevenueWO,");
			strSql.Append("QuotaPerShopPeriod=@QuotaPerShopPeriod,");
			strSql.Append("CouponSKU=@CouponSKU,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("DefaultPickupStoreCode=@DefaultPickupStoreCode,");
			strSql.Append("ColorCode=@ColorCode,");
			strSql.Append("ProductSizeCode=@ProductSizeCode,");
			strSql.Append("AddPointFlag=@AddPointFlag,");
			strSql.Append("AddPointValue=@AddPointValue,");
			strSql.Append("InTax=@InTax,");
			strSql.Append("Additional=@Additional,");
			strSql.Append("Flag1=@Flag1,");
			strSql.Append("Flag2=@Flag2,");
			strSql.Append("Flag3=@Flag3,");
			strSql.Append("Flag4=@Flag4,");
			strSql.Append("Flag5=@Flag5,");
			strSql.Append("Flag6=@Flag6,");
			strSql.Append("Flag7=@Flag7,");
			strSql.Append("Flag8=@Flag8,");
			strSql.Append("Flag9=@Flag9,");
			strSql.Append("Flag10=@Flag10,");
			strSql.Append("Memo1=@Memo1,");
			strSql.Append("Memo2=@Memo2,");
			strSql.Append("Memo3=@Memo3,");
			strSql.Append("Memo4=@Memo4,");
			strSql.Append("Memo5=@Memo5,");
			strSql.Append("Memo6=@Memo6,");
			strSql.Append("Memo7=@Memo7,");
			strSql.Append("Memo8=@Memo8,");
			strSql.Append("Memo9=@Memo9,");
			strSql.Append("Memo10=@Memo10,");
			strSql.Append("isOnlineSKU=@isOnlineSKU,");
			strSql.Append("SKUWeight=@SKUWeight,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("Status=@Status,");
			strSql.Append("ApprovedBy=@ApprovedBy,");
			strSql.Append("ApprovedOn=@ApprovedOn,");
            strSql.Append("StoreBrandCode=@StoreBrandCode");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@ScanDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ScanDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ScanDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@PackageSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@MinOrderQty", SqlDbType.Decimal,9),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@WarehouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdClassCode", SqlDbType.VarChar,64),
					new SqlParameter("@GapProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ShelfLife", SqlDbType.Int,4),
					new SqlParameter("@ProdSpec", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdLength", SqlDbType.Decimal,9),
					new SqlParameter("@ProdWidth", SqlDbType.Decimal,9),
					new SqlParameter("@ProdHeight", SqlDbType.Decimal,9),
					new SqlParameter("@RefGP", SqlDbType.Decimal,9),
					new SqlParameter("@NonOrder", SqlDbType.Int,4),
					new SqlParameter("@NonSale", SqlDbType.Int,4),
					new SqlParameter("@Consignment", SqlDbType.Int,4),
					new SqlParameter("@WeightItem", SqlDbType.Int,4),
					new SqlParameter("@DiscAllow", SqlDbType.Int,4),
					new SqlParameter("@CouponAllow", SqlDbType.Int,4),
					new SqlParameter("@VisuaItem", SqlDbType.Int,4),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@ImportTax", SqlDbType.Decimal,9),
					new SqlParameter("@Insurance", SqlDbType.Decimal,9),
					new SqlParameter("@Freight", SqlDbType.Decimal,9),
					new SqlParameter("@OthersExpense", SqlDbType.Decimal,9),
					new SqlParameter("@OriginCountryCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductType", SqlDbType.Int,4),
					new SqlParameter("@Modifier", SqlDbType.Int,4),
					new SqlParameter("@BOM", SqlDbType.Int,4),
					new SqlParameter("@MutexFlag", SqlDbType.Int,4),
					new SqlParameter("@OnAccount", SqlDbType.Int,4),
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64),
					new SqlParameter("@DiscountLimit", SqlDbType.Decimal,9),
					new SqlParameter("@CostCCC", SqlDbType.VarChar,64),
					new SqlParameter("@CostWO", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueCCC", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueWO", SqlDbType.VarChar,64),
					new SqlParameter("@QuotaPerShopPeriod", SqlDbType.Int,4),
					new SqlParameter("@CouponSKU", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@DefaultPickupStoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@ColorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductSizeCode", SqlDbType.VarChar,64),
					new SqlParameter("@AddPointFlag", SqlDbType.Int,4),
					new SqlParameter("@AddPointValue", SqlDbType.Int,4),
					new SqlParameter("@InTax", SqlDbType.Int,4),
					new SqlParameter("@Additional", SqlDbType.NVarChar,512),
					new SqlParameter("@Flag1", SqlDbType.Int,4),
					new SqlParameter("@Flag2", SqlDbType.Int,4),
					new SqlParameter("@Flag3", SqlDbType.Int,4),
					new SqlParameter("@Flag4", SqlDbType.Int,4),
					new SqlParameter("@Flag5", SqlDbType.Int,4),
					new SqlParameter("@Flag6", SqlDbType.Int,4),
					new SqlParameter("@Flag7", SqlDbType.Int,4),
					new SqlParameter("@Flag8", SqlDbType.Int,4),
					new SqlParameter("@Flag9", SqlDbType.Int,4),
					new SqlParameter("@Flag10", SqlDbType.Int,4),
					new SqlParameter("@Memo1", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo2", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo3", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo4", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo5", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo6", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo7", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo8", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo9", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo10", SqlDbType.NVarChar,512),
					new SqlParameter("@isOnlineSKU", SqlDbType.Int,4),
					new SqlParameter("@SKUWeight", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApprovedBy", SqlDbType.Int,4),
					new SqlParameter("@ApprovedOn", SqlDbType.DateTime),
                    new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ProdDesc1;
			parameters[1].Value = model.ProdDesc2;
			parameters[2].Value = model.ProdDesc3;
			parameters[3].Value = model.ProdPicFile;
			parameters[4].Value = model.ScanDesc1;
			parameters[5].Value = model.ScanDesc2;
			parameters[6].Value = model.ScanDesc3;
			parameters[7].Value = model.BrandCode;
			parameters[8].Value = model.PackageSizeCode;
			parameters[9].Value = model.DepartCode;
			parameters[10].Value = model.StoreCode;
			parameters[11].Value = model.MinOrderQty;
			parameters[12].Value = model.OrderType;
			parameters[13].Value = model.WarehouseCode;
			parameters[14].Value = model.ProdClassCode;
			parameters[15].Value = model.GapProdCode;
			parameters[16].Value = model.ShelfLife;
			parameters[17].Value = model.ProdSpec;
			parameters[18].Value = model.ProdLength;
			parameters[19].Value = model.ProdWidth;
			parameters[20].Value = model.ProdHeight;
			parameters[21].Value = model.RefGP;
			parameters[22].Value = model.NonOrder;
			parameters[23].Value = model.NonSale;
			parameters[24].Value = model.Consignment;
			parameters[25].Value = model.WeightItem;
			parameters[26].Value = model.DiscAllow;
			parameters[27].Value = model.CouponAllow;
			parameters[28].Value = model.VisuaItem;
			parameters[29].Value = model.TaxRate;
			parameters[30].Value = model.ImportTax;
			parameters[31].Value = model.Insurance;
			parameters[32].Value = model.Freight;
			parameters[33].Value = model.OthersExpense;
			parameters[34].Value = model.OriginCountryCode;
			parameters[35].Value = model.ProductType;
			parameters[36].Value = model.Modifier;
			parameters[37].Value = model.BOM;
			parameters[38].Value = model.MutexFlag;
			parameters[39].Value = model.OnAccount;
			parameters[40].Value = model.FulfillmentHouseCode;
			parameters[41].Value = model.ReplenFormulaCode;
			parameters[42].Value = model.DiscountLimit;
			parameters[43].Value = model.CostCCC;
			parameters[44].Value = model.CostWO;
			parameters[45].Value = model.RevenueCCC;
			parameters[46].Value = model.RevenueWO;
			parameters[47].Value = model.QuotaPerShopPeriod;
			parameters[48].Value = model.CouponSKU;
			parameters[49].Value = model.StartDate;
			parameters[50].Value = model.EndDate;
			parameters[51].Value = model.DefaultPickupStoreCode;
			parameters[52].Value = model.ColorCode;
			parameters[53].Value = model.ProductSizeCode;
			parameters[54].Value = model.AddPointFlag;
			parameters[55].Value = model.AddPointValue;
			parameters[56].Value = model.InTax;
			parameters[57].Value = model.Additional;
			parameters[58].Value = model.Flag1;
			parameters[59].Value = model.Flag2;
			parameters[60].Value = model.Flag3;
			parameters[61].Value = model.Flag4;
			parameters[62].Value = model.Flag5;
			parameters[63].Value = model.Flag6;
			parameters[64].Value = model.Flag7;
			parameters[65].Value = model.Flag8;
			parameters[66].Value = model.Flag9;
			parameters[67].Value = model.Flag10;
			parameters[68].Value = model.Memo1;
			parameters[69].Value = model.Memo2;
			parameters[70].Value = model.Memo3;
			parameters[71].Value = model.Memo4;
			parameters[72].Value = model.Memo5;
			parameters[73].Value = model.Memo6;
			parameters[74].Value = model.Memo7;
			parameters[75].Value = model.Memo8;
			parameters[76].Value = model.Memo9;
			parameters[77].Value = model.Memo10;
			parameters[78].Value = model.isOnlineSKU;
			parameters[79].Value = model.SKUWeight;
			parameters[80].Value = model.CreatedOn;
			parameters[81].Value = model.CreatedBy;
			parameters[82].Value = model.UpdatedOn;
			parameters[83].Value = model.UpdatedBy;
			parameters[84].Value = model.Status;
			parameters[85].Value = model.ApprovedBy;
			parameters[86].Value = model.ApprovedOn;
            parameters[87].Value = model.StoreBrandCode;
			parameters[88].Value = model.ProdCode;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCT_Pending ");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ProdCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_PRODUCT_Pending ");
			strSql.Append(" where ProdCode in ("+ProdCodelist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_Pending GetModel(string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 ProdCode,ProdDesc1,ProdDesc2,ProdDesc3,ProdPicFile,ScanDesc1,ScanDesc2,ScanDesc3,BrandCode,PackageSizeCode,DepartCode,StoreCode,");
            strSql.Append("MinOrderQty,OrderType,WarehouseCode,ProdClassCode,GapProdCode,ShelfLife,ProdSpec,ProdLength,ProdWidth,ProdHeight,RefGP,NonOrder,NonSale,");
            strSql.Append("Consignment,WeightItem,DiscAllow,CouponAllow,VisuaItem,TaxRate,ImportTax,Insurance,Freight,OthersExpense,OriginCountryCode,ProductType,Modifier,");
            strSql.Append("BOM,MutexFlag,OnAccount,FulfillmentHouseCode,ReplenFormulaCode,DiscountLimit,CostCCC,CostWO,RevenueCCC,RevenueWO,QuotaPerShopPeriod,CouponSKU,");
            strSql.Append("StartDate,EndDate,DefaultPickupStoreCode,ColorCode,ProductSizeCode,AddPointFlag,AddPointValue,InTax,Additional,Flag1,Flag2,Flag3,Flag4,Flag5,");
            strSql.Append("Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,Memo7,Memo8,Memo9,Memo10,isOnlineSKU,SKUWeight,CreatedOn,CreatedBy,");
            strSql.Append("UpdatedOn,UpdatedBy,Status,ApprovedBy,ApprovedOn,StoreBrandCode from BUY_PRODUCT_Pending ");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = ProdCode;

			Edge.SVA.Model.BUY_PRODUCT_Pending model=new Edge.SVA.Model.BUY_PRODUCT_Pending();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdDesc1"]!=null && ds.Tables[0].Rows[0]["ProdDesc1"].ToString()!="")
				{
					model.ProdDesc1=ds.Tables[0].Rows[0]["ProdDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdDesc2"]!=null && ds.Tables[0].Rows[0]["ProdDesc2"].ToString()!="")
				{
					model.ProdDesc2=ds.Tables[0].Rows[0]["ProdDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdDesc3"]!=null && ds.Tables[0].Rows[0]["ProdDesc3"].ToString()!="")
				{
					model.ProdDesc3=ds.Tables[0].Rows[0]["ProdDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdPicFile"]!=null && ds.Tables[0].Rows[0]["ProdPicFile"].ToString()!="")
				{
					model.ProdPicFile=ds.Tables[0].Rows[0]["ProdPicFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ScanDesc1"]!=null && ds.Tables[0].Rows[0]["ScanDesc1"].ToString()!="")
				{
					model.ScanDesc1=ds.Tables[0].Rows[0]["ScanDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ScanDesc2"]!=null && ds.Tables[0].Rows[0]["ScanDesc2"].ToString()!="")
				{
					model.ScanDesc2=ds.Tables[0].Rows[0]["ScanDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ScanDesc3"]!=null && ds.Tables[0].Rows[0]["ScanDesc3"].ToString()!="")
				{
					model.ScanDesc3=ds.Tables[0].Rows[0]["ScanDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandCode"]!=null && ds.Tables[0].Rows[0]["BrandCode"].ToString()!="")
				{
					model.BrandCode=ds.Tables[0].Rows[0]["BrandCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackageSizeCode"]!=null && ds.Tables[0].Rows[0]["PackageSizeCode"].ToString()!="")
				{
					model.PackageSizeCode=ds.Tables[0].Rows[0]["PackageSizeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepartCode"]!=null && ds.Tables[0].Rows[0]["DepartCode"].ToString()!="")
				{
					model.DepartCode=ds.Tables[0].Rows[0]["DepartCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MinOrderQty"]!=null && ds.Tables[0].Rows[0]["MinOrderQty"].ToString()!="")
				{
					model.MinOrderQty=decimal.Parse(ds.Tables[0].Rows[0]["MinOrderQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderType"]!=null && ds.Tables[0].Rows[0]["OrderType"].ToString()!="")
				{
					model.OrderType=int.Parse(ds.Tables[0].Rows[0]["OrderType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WarehouseCode"]!=null && ds.Tables[0].Rows[0]["WarehouseCode"].ToString()!="")
				{
					model.WarehouseCode=ds.Tables[0].Rows[0]["WarehouseCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdClassCode"]!=null && ds.Tables[0].Rows[0]["ProdClassCode"].ToString()!="")
				{
					model.ProdClassCode=ds.Tables[0].Rows[0]["ProdClassCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["GapProdCode"]!=null && ds.Tables[0].Rows[0]["GapProdCode"].ToString()!="")
				{
					model.GapProdCode=ds.Tables[0].Rows[0]["GapProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ShelfLife"]!=null && ds.Tables[0].Rows[0]["ShelfLife"].ToString()!="")
				{
					model.ShelfLife=int.Parse(ds.Tables[0].Rows[0]["ShelfLife"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdSpec"]!=null && ds.Tables[0].Rows[0]["ProdSpec"].ToString()!="")
				{
					model.ProdSpec=ds.Tables[0].Rows[0]["ProdSpec"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdLength"]!=null && ds.Tables[0].Rows[0]["ProdLength"].ToString()!="")
				{
					model.ProdLength=decimal.Parse(ds.Tables[0].Rows[0]["ProdLength"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdWidth"]!=null && ds.Tables[0].Rows[0]["ProdWidth"].ToString()!="")
				{
					model.ProdWidth=decimal.Parse(ds.Tables[0].Rows[0]["ProdWidth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdHeight"]!=null && ds.Tables[0].Rows[0]["ProdHeight"].ToString()!="")
				{
					model.ProdHeight=decimal.Parse(ds.Tables[0].Rows[0]["ProdHeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RefGP"]!=null && ds.Tables[0].Rows[0]["RefGP"].ToString()!="")
				{
					model.RefGP=decimal.Parse(ds.Tables[0].Rows[0]["RefGP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NonOrder"]!=null && ds.Tables[0].Rows[0]["NonOrder"].ToString()!="")
				{
					model.NonOrder=int.Parse(ds.Tables[0].Rows[0]["NonOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NonSale"]!=null && ds.Tables[0].Rows[0]["NonSale"].ToString()!="")
				{
					model.NonSale=int.Parse(ds.Tables[0].Rows[0]["NonSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Consignment"]!=null && ds.Tables[0].Rows[0]["Consignment"].ToString()!="")
				{
					model.Consignment=int.Parse(ds.Tables[0].Rows[0]["Consignment"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WeightItem"]!=null && ds.Tables[0].Rows[0]["WeightItem"].ToString()!="")
				{
					model.WeightItem=int.Parse(ds.Tables[0].Rows[0]["WeightItem"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiscAllow"]!=null && ds.Tables[0].Rows[0]["DiscAllow"].ToString()!="")
				{
					model.DiscAllow=int.Parse(ds.Tables[0].Rows[0]["DiscAllow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponAllow"]!=null && ds.Tables[0].Rows[0]["CouponAllow"].ToString()!="")
				{
					model.CouponAllow=int.Parse(ds.Tables[0].Rows[0]["CouponAllow"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VisuaItem"]!=null && ds.Tables[0].Rows[0]["VisuaItem"].ToString()!="")
				{
					model.VisuaItem=int.Parse(ds.Tables[0].Rows[0]["VisuaItem"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"]!=null && ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImportTax"]!=null && ds.Tables[0].Rows[0]["ImportTax"].ToString()!="")
				{
					model.ImportTax=decimal.Parse(ds.Tables[0].Rows[0]["ImportTax"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Insurance"]!=null && ds.Tables[0].Rows[0]["Insurance"].ToString()!="")
				{
					model.Insurance=decimal.Parse(ds.Tables[0].Rows[0]["Insurance"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Freight"]!=null && ds.Tables[0].Rows[0]["Freight"].ToString()!="")
				{
					model.Freight=decimal.Parse(ds.Tables[0].Rows[0]["Freight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OthersExpense"]!=null && ds.Tables[0].Rows[0]["OthersExpense"].ToString()!="")
				{
					model.OthersExpense=decimal.Parse(ds.Tables[0].Rows[0]["OthersExpense"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OriginCountryCode"]!=null && ds.Tables[0].Rows[0]["OriginCountryCode"].ToString()!="")
				{
					model.OriginCountryCode=ds.Tables[0].Rows[0]["OriginCountryCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductType"]!=null && ds.Tables[0].Rows[0]["ProductType"].ToString()!="")
				{
					model.ProductType=int.Parse(ds.Tables[0].Rows[0]["ProductType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Modifier"]!=null && ds.Tables[0].Rows[0]["Modifier"].ToString()!="")
				{
					model.Modifier=int.Parse(ds.Tables[0].Rows[0]["Modifier"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BOM"]!=null && ds.Tables[0].Rows[0]["BOM"].ToString()!="")
				{
					model.BOM=int.Parse(ds.Tables[0].Rows[0]["BOM"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MutexFlag"]!=null && ds.Tables[0].Rows[0]["MutexFlag"].ToString()!="")
				{
					model.MutexFlag=int.Parse(ds.Tables[0].Rows[0]["MutexFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OnAccount"]!=null && ds.Tables[0].Rows[0]["OnAccount"].ToString()!="")
				{
					model.OnAccount=int.Parse(ds.Tables[0].Rows[0]["OnAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FulfillmentHouseCode"]!=null && ds.Tables[0].Rows[0]["FulfillmentHouseCode"].ToString()!="")
				{
					model.FulfillmentHouseCode=ds.Tables[0].Rows[0]["FulfillmentHouseCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReplenFormulaCode"]!=null && ds.Tables[0].Rows[0]["ReplenFormulaCode"].ToString()!="")
				{
					model.ReplenFormulaCode=ds.Tables[0].Rows[0]["ReplenFormulaCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DiscountLimit"]!=null && ds.Tables[0].Rows[0]["DiscountLimit"].ToString()!="")
				{
					model.DiscountLimit=decimal.Parse(ds.Tables[0].Rows[0]["DiscountLimit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CostCCC"]!=null && ds.Tables[0].Rows[0]["CostCCC"].ToString()!="")
				{
					model.CostCCC=ds.Tables[0].Rows[0]["CostCCC"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CostWO"]!=null && ds.Tables[0].Rows[0]["CostWO"].ToString()!="")
				{
					model.CostWO=ds.Tables[0].Rows[0]["CostWO"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RevenueCCC"]!=null && ds.Tables[0].Rows[0]["RevenueCCC"].ToString()!="")
				{
					model.RevenueCCC=ds.Tables[0].Rows[0]["RevenueCCC"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RevenueWO"]!=null && ds.Tables[0].Rows[0]["RevenueWO"].ToString()!="")
				{
					model.RevenueWO=ds.Tables[0].Rows[0]["RevenueWO"].ToString();
				}
				if(ds.Tables[0].Rows[0]["QuotaPerShopPeriod"]!=null && ds.Tables[0].Rows[0]["QuotaPerShopPeriod"].ToString()!="")
				{
					model.QuotaPerShopPeriod=int.Parse(ds.Tables[0].Rows[0]["QuotaPerShopPeriod"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponSKU"]!=null && ds.Tables[0].Rows[0]["CouponSKU"].ToString()!="")
				{
					model.CouponSKU=int.Parse(ds.Tables[0].Rows[0]["CouponSKU"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DefaultPickupStoreCode"]!=null && ds.Tables[0].Rows[0]["DefaultPickupStoreCode"].ToString()!="")
				{
					model.DefaultPickupStoreCode=ds.Tables[0].Rows[0]["DefaultPickupStoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ColorCode"]!=null && ds.Tables[0].Rows[0]["ColorCode"].ToString()!="")
				{
					model.ColorCode=ds.Tables[0].Rows[0]["ColorCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProductSizeCode"]!=null && ds.Tables[0].Rows[0]["ProductSizeCode"].ToString()!="")
				{
					model.ProductSizeCode=ds.Tables[0].Rows[0]["ProductSizeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddPointFlag"]!=null && ds.Tables[0].Rows[0]["AddPointFlag"].ToString()!="")
				{
					model.AddPointFlag=int.Parse(ds.Tables[0].Rows[0]["AddPointFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddPointValue"]!=null && ds.Tables[0].Rows[0]["AddPointValue"].ToString()!="")
				{
					model.AddPointValue=int.Parse(ds.Tables[0].Rows[0]["AddPointValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InTax"]!=null && ds.Tables[0].Rows[0]["InTax"].ToString()!="")
				{
					model.InTax=int.Parse(ds.Tables[0].Rows[0]["InTax"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Additional"]!=null && ds.Tables[0].Rows[0]["Additional"].ToString()!="")
				{
					model.Additional=ds.Tables[0].Rows[0]["Additional"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Flag1"]!=null && ds.Tables[0].Rows[0]["Flag1"].ToString()!="")
				{
					model.Flag1=int.Parse(ds.Tables[0].Rows[0]["Flag1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag2"]!=null && ds.Tables[0].Rows[0]["Flag2"].ToString()!="")
				{
					model.Flag2=int.Parse(ds.Tables[0].Rows[0]["Flag2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag3"]!=null && ds.Tables[0].Rows[0]["Flag3"].ToString()!="")
				{
					model.Flag3=int.Parse(ds.Tables[0].Rows[0]["Flag3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag4"]!=null && ds.Tables[0].Rows[0]["Flag4"].ToString()!="")
				{
					model.Flag4=int.Parse(ds.Tables[0].Rows[0]["Flag4"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag5"]!=null && ds.Tables[0].Rows[0]["Flag5"].ToString()!="")
				{
					model.Flag5=int.Parse(ds.Tables[0].Rows[0]["Flag5"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag6"]!=null && ds.Tables[0].Rows[0]["Flag6"].ToString()!="")
				{
					model.Flag6=int.Parse(ds.Tables[0].Rows[0]["Flag6"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag7"]!=null && ds.Tables[0].Rows[0]["Flag7"].ToString()!="")
				{
					model.Flag7=int.Parse(ds.Tables[0].Rows[0]["Flag7"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag8"]!=null && ds.Tables[0].Rows[0]["Flag8"].ToString()!="")
				{
					model.Flag8=int.Parse(ds.Tables[0].Rows[0]["Flag8"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag9"]!=null && ds.Tables[0].Rows[0]["Flag9"].ToString()!="")
				{
					model.Flag9=int.Parse(ds.Tables[0].Rows[0]["Flag9"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Flag10"]!=null && ds.Tables[0].Rows[0]["Flag10"].ToString()!="")
				{
					model.Flag10=int.Parse(ds.Tables[0].Rows[0]["Flag10"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Memo1"]!=null && ds.Tables[0].Rows[0]["Memo1"].ToString()!="")
				{
					model.Memo1=ds.Tables[0].Rows[0]["Memo1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo2"]!=null && ds.Tables[0].Rows[0]["Memo2"].ToString()!="")
				{
					model.Memo2=ds.Tables[0].Rows[0]["Memo2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo3"]!=null && ds.Tables[0].Rows[0]["Memo3"].ToString()!="")
				{
					model.Memo3=ds.Tables[0].Rows[0]["Memo3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo4"]!=null && ds.Tables[0].Rows[0]["Memo4"].ToString()!="")
				{
					model.Memo4=ds.Tables[0].Rows[0]["Memo4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo5"]!=null && ds.Tables[0].Rows[0]["Memo5"].ToString()!="")
				{
					model.Memo5=ds.Tables[0].Rows[0]["Memo5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo6"]!=null && ds.Tables[0].Rows[0]["Memo6"].ToString()!="")
				{
					model.Memo6=ds.Tables[0].Rows[0]["Memo6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo7"]!=null && ds.Tables[0].Rows[0]["Memo7"].ToString()!="")
				{
					model.Memo7=ds.Tables[0].Rows[0]["Memo7"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo8"]!=null && ds.Tables[0].Rows[0]["Memo8"].ToString()!="")
				{
					model.Memo8=ds.Tables[0].Rows[0]["Memo8"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo9"]!=null && ds.Tables[0].Rows[0]["Memo9"].ToString()!="")
				{
					model.Memo9=ds.Tables[0].Rows[0]["Memo9"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo10"]!=null && ds.Tables[0].Rows[0]["Memo10"].ToString()!="")
				{
					model.Memo10=ds.Tables[0].Rows[0]["Memo10"].ToString();
				}
				if(ds.Tables[0].Rows[0]["isOnlineSKU"]!=null && ds.Tables[0].Rows[0]["isOnlineSKU"].ToString()!="")
				{
					model.isOnlineSKU=int.Parse(ds.Tables[0].Rows[0]["isOnlineSKU"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SKUWeight"]!=null && ds.Tables[0].Rows[0]["SKUWeight"].ToString()!="")
				{
					model.SKUWeight=decimal.Parse(ds.Tables[0].Rows[0]["SKUWeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApprovedBy"]!=null && ds.Tables[0].Rows[0]["ApprovedBy"].ToString()!="")
				{
					model.ApprovedBy=int.Parse(ds.Tables[0].Rows[0]["ApprovedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApprovedOn"]!=null && ds.Tables[0].Rows[0]["ApprovedOn"].ToString()!="")
				{
					model.ApprovedOn=DateTime.Parse(ds.Tables[0].Rows[0]["ApprovedOn"].ToString());
				}
                if (ds.Tables[0].Rows[0]["StoreBrandCode"] != null && ds.Tables[0].Rows[0]["StoreBrandCode"].ToString() != "")
                {
                    model.StoreBrandCode = ds.Tables[0].Rows[0]["StoreBrandCode"].ToString();
                }
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  ProdCode,ProdDesc1,ProdDesc2,ProdDesc3,ProdPicFile,ScanDesc1,ScanDesc2,ScanDesc3,BrandCode,PackageSizeCode,DepartCode,StoreCode,");
            strSql.Append("MinOrderQty,OrderType,WarehouseCode,ProdClassCode,GapProdCode,ShelfLife,ProdSpec,ProdLength,ProdWidth,ProdHeight,RefGP,NonOrder,NonSale,");
            strSql.Append("Consignment,WeightItem,DiscAllow,CouponAllow,VisuaItem,TaxRate,ImportTax,Insurance,Freight,OthersExpense,OriginCountryCode,ProductType,Modifier,");
            strSql.Append("BOM,MutexFlag,OnAccount,FulfillmentHouseCode,ReplenFormulaCode,DiscountLimit,CostCCC,CostWO,RevenueCCC,RevenueWO,QuotaPerShopPeriod,CouponSKU,");
            strSql.Append("StartDate,EndDate,DefaultPickupStoreCode,ColorCode,ProductSizeCode,AddPointFlag,AddPointValue,InTax,Additional,Flag1,Flag2,Flag3,Flag4,Flag5,");
            strSql.Append("Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,Memo7,Memo8,Memo9,Memo10,isOnlineSKU,SKUWeight,CreatedOn,CreatedBy,");
            strSql.Append("UpdatedOn,UpdatedBy,Status,ApprovedBy,ApprovedOn,StoreBrandCode from BUY_PRODUCT_Pending ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" ProdCode,ProdDesc1,ProdDesc2,ProdDesc3,ProdPicFile,ScanDesc1,ScanDesc2,ScanDesc3,BrandCode,PackageSizeCode,DepartCode,StoreCode,");
            strSql.Append("MinOrderQty,OrderType,WarehouseCode,ProdClassCode,GapProdCode,ShelfLife,ProdSpec,ProdLength,ProdWidth,ProdHeight,RefGP,NonOrder,NonSale,");
            strSql.Append("Consignment,WeightItem,DiscAllow,CouponAllow,VisuaItem,TaxRate,ImportTax,Insurance,Freight,OthersExpense,OriginCountryCode,ProductType,Modifier,");
            strSql.Append("BOM,MutexFlag,OnAccount,FulfillmentHouseCode,ReplenFormulaCode,DiscountLimit,CostCCC,CostWO,RevenueCCC,RevenueWO,QuotaPerShopPeriod,CouponSKU,");
            strSql.Append("StartDate,EndDate,DefaultPickupStoreCode,ColorCode,ProductSizeCode,AddPointFlag,AddPointValue,InTax,Additional,Flag1,Flag2,Flag3,Flag4,Flag5,");
            strSql.Append("Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,Memo7,Memo8,Memo9,Memo10,isOnlineSKU,SKUWeight,CreatedOn,CreatedBy,");
            strSql.Append("UpdatedOn,UpdatedBy,Status,ApprovedBy,ApprovedOn,StoreBrandCode from BUY_PRODUCT_Pending ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BUY_PRODUCT_Pending ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ProdCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_PRODUCT_Pending T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "BUY_PRODUCT_Pending";
			parameters[1].Value = "ProdCode";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

