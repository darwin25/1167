using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_DEPARTMENT
    /// </summary>
    public partial class BUY_DEPARTMENT : IBUY_DEPARTMENT
    {
        public BUY_DEPARTMENT()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DepartCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_DEPARTMENT");
            strSql.Append(" where DepartCode=@DepartCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = DepartCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.BUY_DEPARTMENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_DEPARTMENT(");
            strSql.Append("DepartCode,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartPicFile2,DepartPicFile3,DepartNote,ReplenFormulaCode,");
            strSql.Append("FulfillmentHouseCode,CostCCC,CostWO,RevenueCCC,RevenueWO,NonOrder,NonSale,Consignment,WeightItem,DiscAllow,CouponAllow,");
            strSql.Append("VisuaItem,CouponSKU,BOM,MutexFlag,DiscountLimit,OnAccount,WarehouseCode,DefaultPickupStoreCode,Additional,");
            strSql.Append("Flag1,Flag2,Flag3,Flag4,Flag5,Flag6,Flag7,Flag8,Flag9,Flag10,");
            strSql.Append("Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,Memo7,Memo8,Memo9,Memo10,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode)");
            strSql.Append(" values (");
            strSql.Append("@DepartCode,@DepartName1,@DepartName2,@DepartName3,@DepartPicFile,@DepartPicFile2,@DepartPicFile3,@DepartNote,@ReplenFormulaCode,");
            strSql.Append("@FulfillmentHouseCode,@CostCCC,@CostWO,@RevenueCCC,@RevenueWO,@NonOrder,@NonSale,@Consignment,@WeightItem,@DiscAllow,@CouponAllow,");
            strSql.Append("@VisuaItem,@CouponSKU,@BOM,@MutexFlag,@DiscountLimit,@OnAccount,@WarehouseCode,@DefaultPickupStoreCode,@Additional,");
            strSql.Append("@Flag1,@Flag2,@Flag3,@Flag4,@Flag5,@Flag6,@Flag7,@Flag8,@Flag9,@Flag10,");
            strSql.Append("@Memo1,@Memo2,@Memo3,@Memo4,@Memo5,@Memo6,@Memo7,@Memo8,@Memo9,@Memo10,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@StoreBrandCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartName1", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartNote", SqlDbType.NVarChar,512),
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64),
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@CostCCC", SqlDbType.VarChar,64),
					new SqlParameter("@CostWO", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueCCC", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueWO", SqlDbType.VarChar,64),
					new SqlParameter("@NonOrder", SqlDbType.Int,4),
					new SqlParameter("@NonSale", SqlDbType.Int,4),
					new SqlParameter("@Consignment", SqlDbType.Int,4),
					new SqlParameter("@WeightItem", SqlDbType.Int,4),
					new SqlParameter("@DiscAllow", SqlDbType.Int,4),
					new SqlParameter("@CouponAllow", SqlDbType.Int,4),
					new SqlParameter("@VisuaItem", SqlDbType.Int,4),
					new SqlParameter("@CouponSKU", SqlDbType.Int,4),
					new SqlParameter("@BOM", SqlDbType.Int,4),
					new SqlParameter("@MutexFlag", SqlDbType.Int,4),
					new SqlParameter("@DiscountLimit", SqlDbType.Decimal,9),
					new SqlParameter("@OnAccount", SqlDbType.Int,4),
					new SqlParameter("@WarehouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@DefaultPickupStoreCode", SqlDbType.VarChar,64),
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
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64)                 
                                        };
            parameters[0].Value = model.DepartCode;
            parameters[1].Value = model.DepartName1;
            parameters[2].Value = model.DepartName2;
            parameters[3].Value = model.DepartName3;
            parameters[4].Value = model.DepartPicFile;
            parameters[5].Value = model.DepartPicFile2;
            parameters[6].Value = model.DepartPicFile3;
            parameters[7].Value = model.DepartNote;
            parameters[8].Value = model.ReplenFormulaCode;
            parameters[9].Value = model.FulfillmentHouseCode;
            parameters[10].Value = model.CostCCC;
            parameters[11].Value = model.CostWO;
            parameters[12].Value = model.RevenueCCC;
            parameters[13].Value = model.RevenueWO;
            parameters[14].Value = model.NonOrder;
            parameters[15].Value = model.NonSale;
            parameters[16].Value = model.Consignment;
            parameters[17].Value = model.WeightItem;
            parameters[18].Value = model.DiscAllow;
            parameters[19].Value = model.CouponAllow;
            parameters[20].Value = model.VisuaItem;
            parameters[21].Value = model.CouponSKU;
            parameters[22].Value = model.BOM;
            parameters[23].Value = model.MutexFlag;
            parameters[24].Value = model.DiscountLimit;
            parameters[25].Value = model.OnAccount;
            parameters[26].Value = model.WarehouseCode;
            parameters[27].Value = model.DefaultPickupStoreCode;
            parameters[28].Value = model.Additional;
            parameters[29].Value = model.Flag1;
            parameters[30].Value = model.Flag2;
            parameters[31].Value = model.Flag3;
            parameters[32].Value = model.Flag4;
            parameters[33].Value = model.Flag5;
            parameters[34].Value = model.Flag6;
            parameters[35].Value = model.Flag7;
            parameters[36].Value = model.Flag8;
            parameters[37].Value = model.Flag9;
            parameters[38].Value = model.Flag10;
            parameters[39].Value = model.Memo1;
            parameters[40].Value = model.Memo2;
            parameters[41].Value = model.Memo3;
            parameters[42].Value = model.Memo4;
            parameters[43].Value = model.Memo5;
            parameters[44].Value = model.Memo6;
            parameters[45].Value = model.Memo7;
            parameters[46].Value = model.Memo8;
            parameters[47].Value = model.Memo9;
            parameters[48].Value = model.Memo10;
            parameters[49].Value = model.CreatedOn;
            parameters[50].Value = model.CreatedBy;
            parameters[51].Value = model.UpdatedOn;
            parameters[52].Value = model.UpdatedBy;
            parameters[53].Value = model.StoreBrandCode;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Edge.SVA.Model.BUY_DEPARTMENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_DEPARTMENT set ");
            strSql.Append("DepartName1=@DepartName1,");
            strSql.Append("DepartName2=@DepartName2,");
            strSql.Append("DepartName3=@DepartName3,");
            strSql.Append("DepartPicFile=@DepartPicFile,");
            strSql.Append("DepartPicFile2=@DepartPicFile2,");
            strSql.Append("DepartPicFile3=@DepartPicFile3,");
            strSql.Append("DepartNote=@DepartNote,");
            strSql.Append("ReplenFormulaCode=@ReplenFormulaCode,");
            strSql.Append("FulfillmentHouseCode=@FulfillmentHouseCode,");
            strSql.Append("CostCCC=@CostCCC,");
            strSql.Append("CostWO=@CostWO,");
            strSql.Append("RevenueCCC=@RevenueCCC,");
            strSql.Append("RevenueWO=@RevenueWO,");
            strSql.Append("NonOrder=@NonOrder,");
            strSql.Append("NonSale=@NonSale,");
            strSql.Append("Consignment=@Consignment,");
            strSql.Append("WeightItem=@WeightItem,");
            strSql.Append("DiscAllow=@DiscAllow,");
            strSql.Append("CouponAllow=@CouponAllow,");
            strSql.Append("VisuaItem=@VisuaItem,");
            strSql.Append("CouponSKU=@CouponSKU,");
            strSql.Append("BOM=@BOM,");
            strSql.Append("MutexFlag=@MutexFlag,");
            strSql.Append("DiscountLimit=@DiscountLimit,");
            strSql.Append("OnAccount=@OnAccount,");
            strSql.Append("WarehouseCode=@WarehouseCode,");
            strSql.Append("DefaultPickupStoreCode=@DefaultPickupStoreCode,");
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
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("StoreBrandCode=@StoreBrandCode ");
            strSql.Append(" where DepartCode=@DepartCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartName1", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartName3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile2", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartPicFile3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartNote", SqlDbType.NVarChar,512),
					new SqlParameter("@ReplenFormulaCode", SqlDbType.VarChar,64),
					new SqlParameter("@FulfillmentHouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@CostCCC", SqlDbType.VarChar,64),
					new SqlParameter("@CostWO", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueCCC", SqlDbType.VarChar,64),
					new SqlParameter("@RevenueWO", SqlDbType.VarChar,64),
					new SqlParameter("@NonOrder", SqlDbType.Int,4),
					new SqlParameter("@NonSale", SqlDbType.Int,4),
					new SqlParameter("@Consignment", SqlDbType.Int,4),
					new SqlParameter("@WeightItem", SqlDbType.Int,4),
					new SqlParameter("@DiscAllow", SqlDbType.Int,4),
					new SqlParameter("@CouponAllow", SqlDbType.Int,4),
					new SqlParameter("@VisuaItem", SqlDbType.Int,4),
					new SqlParameter("@CouponSKU", SqlDbType.Int,4),
					new SqlParameter("@BOM", SqlDbType.Int,4),
					new SqlParameter("@MutexFlag", SqlDbType.Int,4),
					new SqlParameter("@DiscountLimit", SqlDbType.Decimal,9),
					new SqlParameter("@OnAccount", SqlDbType.Int,4),
					new SqlParameter("@WarehouseCode", SqlDbType.VarChar,64),
					new SqlParameter("@DefaultPickupStoreCode", SqlDbType.VarChar,64),
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
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@StoreBrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)};
            parameters[0].Value = model.DepartName1;
            parameters[1].Value = model.DepartName2;
            parameters[2].Value = model.DepartName3;
            parameters[3].Value = model.DepartPicFile;
            parameters[4].Value = model.DepartPicFile2;
            parameters[5].Value = model.DepartPicFile3;
            parameters[6].Value = model.DepartNote;
            parameters[7].Value = model.ReplenFormulaCode;
            parameters[8].Value = model.FulfillmentHouseCode;
            parameters[9].Value = model.CostCCC;
            parameters[10].Value = model.CostWO;
            parameters[11].Value = model.RevenueCCC;
            parameters[12].Value = model.RevenueWO;
            parameters[13].Value = model.NonOrder;
            parameters[14].Value = model.NonSale;
            parameters[15].Value = model.Consignment;
            parameters[16].Value = model.WeightItem;
            parameters[17].Value = model.DiscAllow;
            parameters[18].Value = model.CouponAllow;
            parameters[19].Value = model.VisuaItem;
            parameters[20].Value = model.CouponSKU;
            parameters[21].Value = model.BOM;
            parameters[22].Value = model.MutexFlag;
            parameters[23].Value = model.DiscountLimit;
            parameters[24].Value = model.OnAccount;
            parameters[25].Value = model.WarehouseCode;
            parameters[26].Value = model.DefaultPickupStoreCode;
            parameters[27].Value = model.Additional;
            parameters[28].Value = model.Flag1;
            parameters[29].Value = model.Flag2;
            parameters[30].Value = model.Flag3;
            parameters[31].Value = model.Flag4;
            parameters[32].Value = model.Flag5;
            parameters[33].Value = model.Flag6;
            parameters[34].Value = model.Flag7;
            parameters[35].Value = model.Flag8;
            parameters[36].Value = model.Flag9;
            parameters[37].Value = model.Flag10;
            parameters[38].Value = model.Memo1;
            parameters[39].Value = model.Memo2;
            parameters[40].Value = model.Memo3;
            parameters[41].Value = model.Memo4;
            parameters[42].Value = model.Memo5;
            parameters[43].Value = model.Memo6;
            parameters[44].Value = model.Memo7;
            parameters[45].Value = model.Memo8;
            parameters[46].Value = model.Memo9;
            parameters[47].Value = model.Memo10;
            parameters[48].Value = model.CreatedOn;
            parameters[49].Value = model.CreatedBy;
            parameters[50].Value = model.UpdatedOn;
            parameters[51].Value = model.UpdatedBy;
            parameters[52].Value = model.StoreBrandCode;
            parameters[53].Value = model.DepartCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string DepartCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_DEPARTMENT ");
            strSql.Append(" where DepartCode=@DepartCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = DepartCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string DepartCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_DEPARTMENT ");
            strSql.Append(" where DepartCode in (" + DepartCodelist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.BUY_DEPARTMENT GetModel(string DepartCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 DepartCode,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartPicFile2,DepartPicFile3,DepartNote,ReplenFormulaCode,");
            strSql.Append("FulfillmentHouseCode,CostCCC,CostWO,RevenueCCC,RevenueWO,NonOrder,NonSale,Consignment,WeightItem,DiscAllow,CouponAllow,");
            strSql.Append("VisuaItem,CouponSKU,BOM,MutexFlag,DiscountLimit,OnAccount,WarehouseCode,DefaultPickupStoreCode,Additional,");
            strSql.Append("Flag1,Flag2, Flag3,Flag4,Flag5,Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,");
            strSql.Append("Memo6,Memo7,Memo8,Memo9,Memo10,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode from BUY_DEPARTMENT");
            strSql.Append(" where DepartCode=@DepartCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@DepartCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = DepartCode;

            Edge.SVA.Model.BUY_DEPARTMENT model = new Edge.SVA.Model.BUY_DEPARTMENT();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["DepartCode"] != null && ds.Tables[0].Rows[0]["DepartCode"].ToString() != "")
                {
                    model.DepartCode = ds.Tables[0].Rows[0]["DepartCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepartName1"] != null && ds.Tables[0].Rows[0]["DepartName1"].ToString() != "")
                {
                    model.DepartName1 = ds.Tables[0].Rows[0]["DepartName1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepartName2"] != null && ds.Tables[0].Rows[0]["DepartName2"].ToString() != "")
                {
                    model.DepartName2 = ds.Tables[0].Rows[0]["DepartName2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepartName3"] != null && ds.Tables[0].Rows[0]["DepartName3"].ToString() != "")
                {
                    model.DepartName3 = ds.Tables[0].Rows[0]["DepartName3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepartPicFile"] != null && ds.Tables[0].Rows[0]["DepartPicFile"].ToString() != "")
                {
                    model.DepartPicFile = ds.Tables[0].Rows[0]["DepartPicFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepartPicFile2"] != null && ds.Tables[0].Rows[0]["DepartPicFile2"].ToString() != "")
                {
                    model.DepartPicFile2 = ds.Tables[0].Rows[0]["DepartPicFile2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepartPicFile3"] != null && ds.Tables[0].Rows[0]["DepartPicFile3"].ToString() != "")
                {
                    model.DepartPicFile3 = ds.Tables[0].Rows[0]["DepartPicFile3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepartNote"] != null && ds.Tables[0].Rows[0]["DepartNote"].ToString() != "")
                {
                    model.DepartNote = ds.Tables[0].Rows[0]["DepartNote"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ReplenFormulaCode"] != null && ds.Tables[0].Rows[0]["ReplenFormulaCode"].ToString() != "")
                {
                    model.ReplenFormulaCode = ds.Tables[0].Rows[0]["ReplenFormulaCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FulfillmentHouseCode"] != null && ds.Tables[0].Rows[0]["FulfillmentHouseCode"].ToString() != "")
                {
                    model.FulfillmentHouseCode = ds.Tables[0].Rows[0]["FulfillmentHouseCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CostCCC"] != null && ds.Tables[0].Rows[0]["CostCCC"].ToString() != "")
                {
                    model.CostCCC = ds.Tables[0].Rows[0]["CostCCC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CostWO"] != null && ds.Tables[0].Rows[0]["CostWO"].ToString() != "")
                {
                    model.CostWO = ds.Tables[0].Rows[0]["CostWO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RevenueCCC"] != null && ds.Tables[0].Rows[0]["RevenueCCC"].ToString() != "")
                {
                    model.RevenueCCC = ds.Tables[0].Rows[0]["RevenueCCC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RevenueWO"] != null && ds.Tables[0].Rows[0]["RevenueWO"].ToString() != "")
                {
                    model.RevenueWO = ds.Tables[0].Rows[0]["RevenueWO"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NonOrder"] != null && ds.Tables[0].Rows[0]["NonOrder"].ToString() != "")
                {
                    model.NonOrder = int.Parse(ds.Tables[0].Rows[0]["NonOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NonSale"] != null && ds.Tables[0].Rows[0]["NonSale"].ToString() != "")
                {
                    model.NonSale = int.Parse(ds.Tables[0].Rows[0]["NonSale"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Consignment"] != null && ds.Tables[0].Rows[0]["Consignment"].ToString() != "")
                {
                    model.Consignment = int.Parse(ds.Tables[0].Rows[0]["Consignment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WeightItem"] != null && ds.Tables[0].Rows[0]["WeightItem"].ToString() != "")
                {
                    model.WeightItem = int.Parse(ds.Tables[0].Rows[0]["WeightItem"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DiscAllow"] != null && ds.Tables[0].Rows[0]["DiscAllow"].ToString() != "")
                {
                    model.DiscAllow = int.Parse(ds.Tables[0].Rows[0]["DiscAllow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CouponAllow"] != null && ds.Tables[0].Rows[0]["CouponAllow"].ToString() != "")
                {
                    model.CouponAllow = int.Parse(ds.Tables[0].Rows[0]["CouponAllow"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VisuaItem"] != null && ds.Tables[0].Rows[0]["VisuaItem"].ToString() != "")
                {
                    model.VisuaItem = int.Parse(ds.Tables[0].Rows[0]["VisuaItem"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CouponSKU"] != null && ds.Tables[0].Rows[0]["CouponSKU"].ToString() != "")
                {
                    model.CouponSKU = int.Parse(ds.Tables[0].Rows[0]["CouponSKU"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BOM"] != null && ds.Tables[0].Rows[0]["BOM"].ToString() != "")
                {
                    model.BOM = int.Parse(ds.Tables[0].Rows[0]["BOM"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MutexFlag"] != null && ds.Tables[0].Rows[0]["MutexFlag"].ToString() != "")
                {
                    model.MutexFlag = int.Parse(ds.Tables[0].Rows[0]["MutexFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DiscountLimit"] != null && ds.Tables[0].Rows[0]["DiscountLimit"].ToString() != "")
                {
                    model.DiscountLimit = decimal.Parse(ds.Tables[0].Rows[0]["DiscountLimit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OnAccount"] != null && ds.Tables[0].Rows[0]["OnAccount"].ToString() != "")
                {
                    model.OnAccount = int.Parse(ds.Tables[0].Rows[0]["OnAccount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WarehouseCode"] != null && ds.Tables[0].Rows[0]["WarehouseCode"].ToString() != "")
                {
                    model.WarehouseCode = ds.Tables[0].Rows[0]["WarehouseCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DefaultPickupStoreCode"] != null && ds.Tables[0].Rows[0]["DefaultPickupStoreCode"].ToString() != "")
                {
                    model.DefaultPickupStoreCode = ds.Tables[0].Rows[0]["DefaultPickupStoreCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Additional"] != null && ds.Tables[0].Rows[0]["Additional"].ToString() != "")
                {
                    model.Additional = ds.Tables[0].Rows[0]["Additional"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Flag1"] != null && ds.Tables[0].Rows[0]["Flag1"].ToString() != "")
                {
                    model.Flag1 = int.Parse(ds.Tables[0].Rows[0]["Flag1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag2"] != null && ds.Tables[0].Rows[0]["Flag2"].ToString() != "")
                {
                    model.Flag2 = int.Parse(ds.Tables[0].Rows[0]["Flag2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag3"] != null && ds.Tables[0].Rows[0]["Flag3"].ToString() != "")
                {
                    model.Flag3 = int.Parse(ds.Tables[0].Rows[0]["Flag3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag4"] != null && ds.Tables[0].Rows[0]["Flag4"].ToString() != "")
                {
                    model.Flag4 = int.Parse(ds.Tables[0].Rows[0]["Flag4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag5"] != null && ds.Tables[0].Rows[0]["Flag5"].ToString() != "")
                {
                    model.Flag5 = int.Parse(ds.Tables[0].Rows[0]["Flag5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag6"] != null && ds.Tables[0].Rows[0]["Flag6"].ToString() != "")
                {
                    model.Flag6 = int.Parse(ds.Tables[0].Rows[0]["Flag6"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag7"] != null && ds.Tables[0].Rows[0]["Flag7"].ToString() != "")
                {
                    model.Flag7 = int.Parse(ds.Tables[0].Rows[0]["Flag7"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag8"] != null && ds.Tables[0].Rows[0]["Flag8"].ToString() != "")
                {
                    model.Flag8 = int.Parse(ds.Tables[0].Rows[0]["Flag8"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag9"] != null && ds.Tables[0].Rows[0]["Flag9"].ToString() != "")
                {
                    model.Flag9 = int.Parse(ds.Tables[0].Rows[0]["Flag9"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag10"] != null && ds.Tables[0].Rows[0]["Flag10"].ToString() != "")
                {
                    model.Flag10 = int.Parse(ds.Tables[0].Rows[0]["Flag10"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Memo1"] != null && ds.Tables[0].Rows[0]["Memo1"].ToString() != "")
                {
                    model.Memo1 = ds.Tables[0].Rows[0]["Memo1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo2"] != null && ds.Tables[0].Rows[0]["Memo2"].ToString() != "")
                {
                    model.Memo2 = ds.Tables[0].Rows[0]["Memo2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo3"] != null && ds.Tables[0].Rows[0]["Memo3"].ToString() != "")
                {
                    model.Memo3 = ds.Tables[0].Rows[0]["Memo3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo4"] != null && ds.Tables[0].Rows[0]["Memo4"].ToString() != "")
                {
                    model.Memo4 = ds.Tables[0].Rows[0]["Memo4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo5"] != null && ds.Tables[0].Rows[0]["Memo5"].ToString() != "")
                {
                    model.Memo5 = ds.Tables[0].Rows[0]["Memo5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo6"] != null && ds.Tables[0].Rows[0]["Memo6"].ToString() != "")
                {
                    model.Memo6 = ds.Tables[0].Rows[0]["Memo6"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo7"] != null && ds.Tables[0].Rows[0]["Memo7"].ToString() != "")
                {
                    model.Memo7 = ds.Tables[0].Rows[0]["Memo7"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo8"] != null && ds.Tables[0].Rows[0]["Memo8"].ToString() != "")
                {
                    model.Memo8 = ds.Tables[0].Rows[0]["Memo8"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo9"] != null && ds.Tables[0].Rows[0]["Memo9"].ToString() != "")
                {
                    model.Memo9 = ds.Tables[0].Rows[0]["Memo9"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Memo10"] != null && ds.Tables[0].Rows[0]["Memo10"].ToString() != "")
                {
                    model.Memo10 = ds.Tables[0].Rows[0]["Memo10"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedOn"] != null && ds.Tables[0].Rows[0]["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedBy"] != null && ds.Tables[0].Rows[0]["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedOn"] != null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedBy"] != null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DepartCode,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartPicFile2,DepartPicFile3,DepartNote,ReplenFormulaCode,");
            strSql.Append("FulfillmentHouseCode,CostCCC,CostWO,RevenueCCC,RevenueWO,NonOrder,NonSale,Consignment,WeightItem,DiscAllow,CouponAllow,");
            strSql.Append("VisuaItem,CouponSKU,BOM,MutexFlag,DiscountLimit,OnAccount,WarehouseCode,DefaultPickupStoreCode,Additional,");
            strSql.Append("Flag1,Flag2, Flag3,Flag4,Flag5,Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,");
            strSql.Append("Memo6,Memo7,Memo8,Memo9,Memo10,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode from BUY_DEPARTMENT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("select DepartCode,DepartName1,DepartName2,DepartName3,DepartPicFile,DepartPicFile2,DepartPicFile3,DepartNote,ReplenFormulaCode,");
            strSql.Append("FulfillmentHouseCode,CostCCC,CostWO,RevenueCCC,RevenueWO,NonOrder,NonSale,Consignment,WeightItem,DiscAllow,CouponAllow,");
            strSql.Append("VisuaItem,CouponSKU,BOM,MutexFlag,DiscountLimit,OnAccount,WarehouseCode,DefaultPickupStoreCode,Additional,");
            strSql.Append("Flag1,Flag2, Flag3,Flag4,Flag5,Flag6,Flag7,Flag8,Flag9,Flag10,Memo1,Memo2,Memo3,Memo4,Memo5,");
            strSql.Append("Memo6,Memo7,Memo8,Memo9,Memo10,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,StoreBrandCode from BUY_DEPARTMENT");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM BUY_DEPARTMENT ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.DepartCode desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_DEPARTMENT T ");
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
            parameters[0].Value = "BUY_DEPARTMENT";
            parameters[1].Value = "DepartCode";
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

