using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:IMP_PRODUCT_TEMP
    /// 创建人：lisa
    /// 创建时间：2016-07-08
    /// </summary>
    public partial class IMP_PRODUCT_TEMP : IIMP_PRODUCT_TEMP
    {
        public IMP_PRODUCT_TEMP()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string INTERNAL_PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from IMP_PRODUCT_TEMP");
            strSql.Append(" where INTERNAL_PRODUCT_CODE=@INTERNAL_PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@INTERNAL_PRODUCT_CODE", SqlDbType.VarChar,64)			};
            parameters[0].Value = INTERNAL_PRODUCT_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        public bool Add(Edge.SVA.Model.IMP_PRODUCT_TEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into IMP_PRODUCT_TEMP(");
            strSql.Append("INTERNAL_PRODUCT_CODE,COMPANY_ID,BARCODE,SUPPLIER_PRODUCT_CODE,BRAND,YEAR,SEASON,ARTICLE,SEX,MODEL,COLOR,PSIZE,");
            strSql.Append("CLASS,DESCRIPTION,REORDER_LEVEL,RETIRED,RETIRE_DATE,LAST_UPDATE_DATE,LAST_UPDATE_USER,DESCRIPTION2,SUPPLIER,");
            strSql.Append("STANDARD_COST,SIZE_RANGE,HS_CODE,EXPORT_COST,LOCAL_DESCRIPTION,COO,MATERIAL_1,MATERIAL_2,DESIGNER,BUYER,");
            strSql.Append("MERCHANDISER,SKU,AVG_COST,PRICE,FINAL_DISCOUNT_PRICE,ShortDescription1,ShortDescription2,ShortDescription3,");
            strSql.Append("Material1,Material2,Material3,Detailed1,Detailed2,Detailed3,Design1,Design2,Design3,ProductName1,ProductName2,");
            strSql.Append("ProductName3,IsOnlineSKU,OuterLayerMaterials,InnerLayerMaterials,SizeCategory,Video,[360Photos],Photos1,Photos2,");
            strSql.Append("Photos4,Photos5,Photos6,Photos7,Photos10,Photos8,Photos3,Photos9,SizeM1,SizeM2,SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8)");
            strSql.Append(" values (");
            strSql.Append("@INTERNAL_PRODUCT_CODE,@COMPANY_ID,@BARCODE,@SUPPLIER_PRODUCT_CODE,@BRAND,@YEAR,@SEASON,@ARTICLE,@SEX,@MODEL,@COLOR,");
            strSql.Append("@PSIZE,@CLASS,@DESCRIPTION,@REORDER_LEVEL,@RETIRED,@RETIRE_DATE,@LAST_UPDATE_DATE,@LAST_UPDATE_USER,@DESCRIPTION2,");
            strSql.Append("@SUPPLIER,@STANDARD_COST,@SIZE_RANGE,@HS_CODE,@EXPORT_COST,@LOCAL_DESCRIPTION,@COO,@MATERIAL_1,@MATERIAL_2,@DESIGNER,");
            strSql.Append("@BUYER,@MERCHANDISER,@SKU,@AVG_COST,@PRICE,@FINAL_DISCOUNT_PRICE,@ShortDescription1,@ShortDescription2,@ShortDescription3,");
            strSql.Append("@Material1,@Material2,@Material3,@Detailed1,@Detailed2,@Detailed3,@Design1,@Design2,@Design3,@ProductName1,");
            strSql.Append("@ProductName2,@ProductName3,@IsOnlineSKU,@OuterLayerMaterials,@InnerLayerMaterials,@SizeCategory,@Video,");
            strSql.Append("@360Photos,@Photos1,@Photos2,@Photos4,@Photos5,@Photos6,@Photos7,@Photos10,@Photos8,@Photos3,@Photos9,");
            strSql.Append("@SizeM1,@SizeM2,@SizeM3,@SizeM4,@SizeM5,@SizeM6,@SizeM7,@SizeM8)");
            SqlParameter[] parameters = {
					new SqlParameter("@INTERNAL_PRODUCT_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@COMPANY_ID", SqlDbType.VarChar,64),
					new SqlParameter("@BARCODE", SqlDbType.VarChar,64),
					new SqlParameter("@SUPPLIER_PRODUCT_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@BRAND", SqlDbType.VarChar,64),
					new SqlParameter("@YEAR", SqlDbType.Int,4),
					new SqlParameter("@SEASON", SqlDbType.VarChar,64),
					new SqlParameter("@ARTICLE", SqlDbType.VarChar,64),
					new SqlParameter("@SEX", SqlDbType.Int,4),
					new SqlParameter("@MODEL", SqlDbType.VarChar,64),
					new SqlParameter("@COLOR", SqlDbType.VarChar,64),
					new SqlParameter("@PSIZE", SqlDbType.VarChar,64),
					new SqlParameter("@CLASS", SqlDbType.VarChar,64),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,512),
					new SqlParameter("@REORDER_LEVEL", SqlDbType.VarChar,64),
					new SqlParameter("@RETIRED", SqlDbType.VarChar,64),
					new SqlParameter("@RETIRE_DATE", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_DATE", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,64),
					new SqlParameter("@DESCRIPTION2", SqlDbType.NVarChar,512),
					new SqlParameter("@SUPPLIER", SqlDbType.VarChar,64),
					new SqlParameter("@STANDARD_COST", SqlDbType.Money,8),
					new SqlParameter("@SIZE_RANGE", SqlDbType.VarChar,64),
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@EXPORT_COST", SqlDbType.Money,8),
					new SqlParameter("@LOCAL_DESCRIPTION", SqlDbType.NVarChar,512),
					new SqlParameter("@COO", SqlDbType.VarChar,64),
					new SqlParameter("@MATERIAL_1", SqlDbType.VarChar,64),
					new SqlParameter("@MATERIAL_2", SqlDbType.VarChar,64),
					new SqlParameter("@DESIGNER", SqlDbType.VarChar,64),
					new SqlParameter("@BUYER", SqlDbType.VarChar,64),
					new SqlParameter("@MERCHANDISER", SqlDbType.VarChar,64),
					new SqlParameter("@SKU", SqlDbType.VarChar,64),
					new SqlParameter("@AVG_COST", SqlDbType.Money,8),
					new SqlParameter("@PRICE", SqlDbType.Money,8),
					new SqlParameter("@FINAL_DISCOUNT_PRICE", SqlDbType.Money,8),
					new SqlParameter("@ShortDescription1", SqlDbType.NVarChar,512),
					new SqlParameter("@ShortDescription2", SqlDbType.NVarChar,512),
					new SqlParameter("@ShortDescription3", SqlDbType.NVarChar,512),
					new SqlParameter("@Material1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Material2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Material3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Detailed1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Detailed2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Detailed3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Design1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Design2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Design3", SqlDbType.NVarChar,-1),
					new SqlParameter("@ProductName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductName3", SqlDbType.NVarChar,512),
					new SqlParameter("@IsOnlineSKU", SqlDbType.Int,4),
					new SqlParameter("@OuterLayerMaterials", SqlDbType.VarChar,512),
					new SqlParameter("@InnerLayerMaterials", SqlDbType.VarChar,512),
					new SqlParameter("@SizeCategory", SqlDbType.VarChar,512),
					new SqlParameter("@Video", SqlDbType.VarChar,512),
					new SqlParameter("@360Photos", SqlDbType.VarChar,512),
					new SqlParameter("@Photos1", SqlDbType.VarChar,512),
					new SqlParameter("@Photos2", SqlDbType.VarChar,512),
					new SqlParameter("@Photos4", SqlDbType.VarChar,512),
					new SqlParameter("@Photos5", SqlDbType.VarChar,512),
					new SqlParameter("@Photos6", SqlDbType.VarChar,512),
					new SqlParameter("@Photos7", SqlDbType.VarChar,512),
					new SqlParameter("@Photos10", SqlDbType.VarChar,512),
					new SqlParameter("@Photos8", SqlDbType.VarChar,512),
					new SqlParameter("@Photos3", SqlDbType.VarChar,512),
					new SqlParameter("@Photos9", SqlDbType.VarChar,512),
					new SqlParameter("@SizeM1", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM2", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM3", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM4", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM5", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM6", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM7", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM8", SqlDbType.VarChar,64)};
            parameters[0].Value = model.INTERNAL_PRODUCT_CODE;
            parameters[1].Value = model.COMPANY_ID;
            parameters[2].Value = model.BARCODE;
            parameters[3].Value = model.SUPPLIER_PRODUCT_CODE;
            parameters[4].Value = model.BRAND;
            parameters[5].Value = model.YEAR;
            parameters[6].Value = model.SEASON;
            parameters[7].Value = model.ARTICLE;
            parameters[8].Value = model.SEX;
            parameters[9].Value = model.MODEL;
            parameters[10].Value = model.COLOR;
            parameters[11].Value = model.PSIZE;
            parameters[12].Value = model.CLASS;
            parameters[13].Value = model.DESCRIPTION;
            parameters[14].Value = model.REORDER_LEVEL;
            parameters[15].Value = model.RETIRED;
            parameters[16].Value = model.RETIRE_DATE;
            parameters[17].Value = model.LAST_UPDATE_DATE;
            parameters[18].Value = model.LAST_UPDATE_USER;
            parameters[19].Value = model.DESCRIPTION2;
            parameters[20].Value = model.SUPPLIER;
            parameters[21].Value = model.STANDARD_COST;
            parameters[22].Value = model.SIZE_RANGE;
            parameters[23].Value = model.HS_CODE;
            parameters[24].Value = model.EXPORT_COST;
            parameters[25].Value = model.LOCAL_DESCRIPTION;
            parameters[26].Value = model.COO;
            parameters[27].Value = model.MATERIAL_1;
            parameters[28].Value = model.MATERIAL_2;
            parameters[29].Value = model.DESIGNER;
            parameters[30].Value = model.BUYER;
            parameters[31].Value = model.MERCHANDISER;
            parameters[32].Value = model.SKU;
            parameters[33].Value = model.AVG_COST;
            parameters[34].Value = model.PRICE;
            parameters[35].Value = model.FINAL_DISCOUNT_PRICE;
            parameters[36].Value = model.ShortDescription1;
            parameters[37].Value = model.ShortDescription2;
            parameters[38].Value = model.ShortDescription3;
            parameters[39].Value = model.Material1;
            parameters[40].Value = model.Material2;
            parameters[41].Value = model.Material3;
            parameters[42].Value = model.Detailed1;
            parameters[43].Value = model.Detailed2;
            parameters[44].Value = model.Detailed3;
            parameters[45].Value = model.Design1;
            parameters[46].Value = model.Design2;
            parameters[47].Value = model.Design3;
            parameters[48].Value = model.ProductName1;
            parameters[49].Value = model.ProductName2;
            parameters[50].Value = model.ProductName3;
            parameters[51].Value = model.IsOnlineSKU;
            parameters[52].Value = model.OuterLayerMaterials;
            parameters[53].Value = model.InnerLayerMaterials;
            parameters[54].Value = model.SizeCategory;
            parameters[55].Value = model.Video;
            parameters[56].Value = model._360photos1;
            parameters[57].Value = model.Photos1;
            parameters[58].Value = model.Photos2;
            parameters[59].Value = model.Photos4;
            parameters[60].Value = model.Photos5;
            parameters[61].Value = model.Photos6;
            parameters[62].Value = model.Photos7;
            parameters[63].Value = model.Photos10;
            parameters[64].Value = model.Photos8;
            parameters[65].Value = model.Photos3;
            parameters[66].Value = model.Photos9;
            parameters[67].Value = model.SizeM1;
            parameters[68].Value = model.SizeM2;
            parameters[69].Value = model.SizeM3;
            parameters[70].Value = model.SizeM4;
            parameters[71].Value = model.SizeM5;
            parameters[72].Value = model.SizeM6;
            parameters[73].Value = model.SizeM7;
            parameters[74].Value = model.SizeM8;

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
        public bool Update(Edge.SVA.Model.IMP_PRODUCT_TEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update IMP_PRODUCT_TEMP set ");
            strSql.Append("INTERNAL_PRODUCT_CODE=@INTERNAL_PRODUCT_CODE,");
            strSql.Append("COMPANY_ID=@COMPANY_ID,");
            strSql.Append("SUPPLIER_PRODUCT_CODE=@SUPPLIER_PRODUCT_CODE,");
            strSql.Append("BRAND=@BRAND,");
            strSql.Append("YEAR=@YEAR,");
            strSql.Append("SEASON=@SEASON,");
            strSql.Append("ARTICLE=@ARTICLE,");
            strSql.Append("SEX=@SEX,");
            strSql.Append("MODEL=@MODEL,");
            strSql.Append("COLOR=@COLOR,");
            strSql.Append("PSIZE=@PSIZE,");
            strSql.Append("CLASS=@CLASS,");
            strSql.Append("DESCRIPTION=@DESCRIPTION,");
            strSql.Append("REORDER_LEVEL=@REORDER_LEVEL,");
            strSql.Append("RETIRED=@RETIRED,");
            strSql.Append("RETIRE_DATE=@RETIRE_DATE,");
            strSql.Append("LAST_UPDATE_DATE=@LAST_UPDATE_DATE,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("DESCRIPTION2=@DESCRIPTION2,");
            strSql.Append("SUPPLIER=@SUPPLIER,");
            strSql.Append("STANDARD_COST=@STANDARD_COST,");
            strSql.Append("SIZE_RANGE=@SIZE_RANGE,");
            strSql.Append("HS_CODE=@HS_CODE,");
            strSql.Append("EXPORT_COST=@EXPORT_COST,");
            strSql.Append("LOCAL_DESCRIPTION=@LOCAL_DESCRIPTION,");
            strSql.Append("COO=@COO,");
            strSql.Append("MATERIAL_1=@MATERIAL_1,");
            strSql.Append("MATERIAL_2=@MATERIAL_2,");
            strSql.Append("DESIGNER=@DESIGNER,");
            strSql.Append("BUYER=@BUYER,");
            strSql.Append("MERCHANDISER=@MERCHANDISER,");
            strSql.Append("SKU=@SKU,");
            strSql.Append("AVG_COST=@AVG_COST,");
            strSql.Append("PRICE=@PRICE,");
            strSql.Append("FINAL_DISCOUNT_PRICE=@FINAL_DISCOUNT_PRICE,");
            strSql.Append("ShortDescription1=@ShortDescription1,");
            strSql.Append("ShortDescription2=@ShortDescription2,");
            strSql.Append("ShortDescription3=@ShortDescription3,");
            strSql.Append("Material1=@Material1,");
            strSql.Append("Material2=@Material2,");
            strSql.Append("Material3=@Material3,");
            strSql.Append("Detailed1=@Detailed1,");
            strSql.Append("Detailed2=@Detailed2,");
            strSql.Append("Detailed3=@Detailed3,");
            strSql.Append("Design1=@Design1,");
            strSql.Append("Design2=@Design2,");
            strSql.Append("Design3=@Design3,");
            strSql.Append("ProductName1=@ProductName1,");
            strSql.Append("ProductName2=@ProductName2,");
            strSql.Append("ProductName3=@ProductName3,");
            strSql.Append("IsOnlineSKU=@IsOnlineSKU,");
            strSql.Append("OuterLayerMaterials=@OuterLayerMaterials,");
            strSql.Append("InnerLayerMaterials=@InnerLayerMaterials,");
            strSql.Append("SizeCategory=@SizeCategory,");
            strSql.Append("Video=@Video,");
            strSql.Append("[360Photos]=@360Photos,");
            strSql.Append("Photos1=@Photos1,");
            strSql.Append("Photos2=@Photos2,");
            strSql.Append("Photos4=@Photos4,");
            strSql.Append("Photos5=@Photos5,");
            strSql.Append("Photos6=@Photos6,");
            strSql.Append("Photos7=@Photos7,");
            strSql.Append("Photos10=@Photos10,");
            strSql.Append("Photos8=@Photos8,");
            strSql.Append("Photos3=@Photos3,");
            strSql.Append("Photos9=@Photos9,");
            strSql.Append("SizeM1=@SizeM1,");
            strSql.Append("SizeM2=@SizeM2,");
            strSql.Append("SizeM3=@SizeM3,");
            strSql.Append("SizeM4=@SizeM4,");
            strSql.Append("SizeM5=@SizeM5,");
            strSql.Append("SizeM6=@SizeM6,");
            strSql.Append("SizeM7=@SizeM7,");
            strSql.Append("SizeM8=@SizeM8");
            strSql.Append(" where BARCODE=@BARCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@INTERNAL_PRODUCT_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@COMPANY_ID", SqlDbType.VarChar,64),
					new SqlParameter("@SUPPLIER_PRODUCT_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@BRAND", SqlDbType.VarChar,64),
					new SqlParameter("@YEAR", SqlDbType.Int,4),
					new SqlParameter("@SEASON", SqlDbType.VarChar,64),
					new SqlParameter("@ARTICLE", SqlDbType.VarChar,64),
					new SqlParameter("@SEX", SqlDbType.Int,4),
					new SqlParameter("@MODEL", SqlDbType.VarChar,64),
					new SqlParameter("@COLOR", SqlDbType.VarChar,64),
					new SqlParameter("@PSIZE", SqlDbType.VarChar,64),
					new SqlParameter("@CLASS", SqlDbType.VarChar,64),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,512),
					new SqlParameter("@REORDER_LEVEL", SqlDbType.VarChar,64),
					new SqlParameter("@RETIRED", SqlDbType.VarChar,64),
					new SqlParameter("@RETIRE_DATE", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_DATE", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,64),
					new SqlParameter("@DESCRIPTION2", SqlDbType.NVarChar,512),
					new SqlParameter("@SUPPLIER", SqlDbType.VarChar,64),
					new SqlParameter("@STANDARD_COST", SqlDbType.Money,8),
					new SqlParameter("@SIZE_RANGE", SqlDbType.VarChar,64),
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@EXPORT_COST", SqlDbType.Money,8),
					new SqlParameter("@LOCAL_DESCRIPTION", SqlDbType.NVarChar,512),
					new SqlParameter("@COO", SqlDbType.VarChar,64),
					new SqlParameter("@MATERIAL_1", SqlDbType.VarChar,64),
					new SqlParameter("@MATERIAL_2", SqlDbType.VarChar,64),
					new SqlParameter("@DESIGNER", SqlDbType.VarChar,64),
					new SqlParameter("@BUYER", SqlDbType.VarChar,64),
					new SqlParameter("@MERCHANDISER", SqlDbType.VarChar,64),
					new SqlParameter("@SKU", SqlDbType.VarChar,64),
					new SqlParameter("@AVG_COST", SqlDbType.Money,8),
					new SqlParameter("@PRICE", SqlDbType.Money,8),
					new SqlParameter("@FINAL_DISCOUNT_PRICE", SqlDbType.Money,8),
					new SqlParameter("@ShortDescription1", SqlDbType.NVarChar,512),
					new SqlParameter("@ShortDescription2", SqlDbType.NVarChar,512),
					new SqlParameter("@ShortDescription3", SqlDbType.NVarChar,512),
					new SqlParameter("@Material1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Material2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Material3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Detailed1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Detailed2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Detailed3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Design1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Design2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Design3", SqlDbType.NVarChar,-1),
					new SqlParameter("@ProductName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductName3", SqlDbType.NVarChar,512),
					new SqlParameter("@IsOnlineSKU", SqlDbType.Int,4),
					new SqlParameter("@OuterLayerMaterials", SqlDbType.VarChar,512),
					new SqlParameter("@InnerLayerMaterials", SqlDbType.VarChar,512),
					new SqlParameter("@SizeCategory", SqlDbType.VarChar,512),
					new SqlParameter("@Video", SqlDbType.VarChar,512),
					new SqlParameter("@360Photos", SqlDbType.VarChar,512),
					new SqlParameter("@Photos1", SqlDbType.VarChar,512),
					new SqlParameter("@Photos2", SqlDbType.VarChar,512),
					new SqlParameter("@Photos4", SqlDbType.VarChar,512),
					new SqlParameter("@Photos5", SqlDbType.VarChar,512),
					new SqlParameter("@Photos6", SqlDbType.VarChar,512),
					new SqlParameter("@Photos7", SqlDbType.VarChar,512),
					new SqlParameter("@Photos10", SqlDbType.VarChar,512),
					new SqlParameter("@Photos8", SqlDbType.VarChar,512),
					new SqlParameter("@Photos3", SqlDbType.VarChar,512),
					new SqlParameter("@Photos9", SqlDbType.VarChar,512),
				new SqlParameter("@SizeM1", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM2", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM3", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM4", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM5", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM6", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM7", SqlDbType.VarChar,64),
					new SqlParameter("@SizeM8", SqlDbType.VarChar,64),
					new SqlParameter("@BARCODE", SqlDbType.VarChar,64)};
            parameters[0].Value = model.INTERNAL_PRODUCT_CODE;
            parameters[1].Value = model.COMPANY_ID;
            parameters[2].Value = model.SUPPLIER_PRODUCT_CODE;
            parameters[3].Value = model.BRAND;
            parameters[4].Value = model.YEAR;
            parameters[5].Value = model.SEASON;
            parameters[6].Value = model.ARTICLE;
            parameters[7].Value = model.SEX;
            parameters[8].Value = model.MODEL;
            parameters[9].Value = model.COLOR;
            parameters[10].Value = model.PSIZE;
            parameters[11].Value = model.CLASS;
            parameters[12].Value = model.DESCRIPTION;
            parameters[13].Value = model.REORDER_LEVEL;
            parameters[14].Value = model.RETIRED;
            parameters[15].Value = model.RETIRE_DATE;
            parameters[16].Value = model.LAST_UPDATE_DATE;
            parameters[17].Value = model.LAST_UPDATE_USER;
            parameters[18].Value = model.DESCRIPTION2;
            parameters[19].Value = model.SUPPLIER;
            parameters[20].Value = model.STANDARD_COST;
            parameters[21].Value = model.SIZE_RANGE;
            parameters[22].Value = model.HS_CODE;
            parameters[23].Value = model.EXPORT_COST;
            parameters[24].Value = model.LOCAL_DESCRIPTION;
            parameters[25].Value = model.COO;
            parameters[26].Value = model.MATERIAL_1;
            parameters[27].Value = model.MATERIAL_2;
            parameters[28].Value = model.DESIGNER;
            parameters[29].Value = model.BUYER;
            parameters[30].Value = model.MERCHANDISER;
            parameters[31].Value = model.SKU;
            parameters[32].Value = model.AVG_COST;
            parameters[33].Value = model.PRICE;
            parameters[34].Value = model.FINAL_DISCOUNT_PRICE;
            parameters[35].Value = model.ShortDescription1;
            parameters[36].Value = model.ShortDescription2;
            parameters[37].Value = model.ShortDescription3;
            parameters[38].Value = model.Material1;
            parameters[39].Value = model.Material2;
            parameters[40].Value = model.Material3;
            parameters[41].Value = model.Detailed1;
            parameters[42].Value = model.Detailed2;
            parameters[43].Value = model.Detailed3;
            parameters[44].Value = model.Design1;
            parameters[45].Value = model.Design2;
            parameters[46].Value = model.Design3;
            parameters[47].Value = model.ProductName1;
            parameters[48].Value = model.ProductName2;
            parameters[49].Value = model.ProductName3;
            parameters[50].Value = model.IsOnlineSKU;
            parameters[51].Value = model.OuterLayerMaterials;
            parameters[52].Value = model.InnerLayerMaterials;
            parameters[53].Value = model.SizeCategory;
            parameters[54].Value = model.Video;
            parameters[55].Value = model._360photos1;
            parameters[56].Value = model.Photos1;
            parameters[57].Value = model.Photos2;
            parameters[58].Value = model.Photos4;
            parameters[59].Value = model.Photos5;
            parameters[60].Value = model.Photos6;
            parameters[61].Value = model.Photos7;
            parameters[62].Value = model.Photos10;
            parameters[63].Value = model.Photos8;
            parameters[64].Value = model.Photos3;
            parameters[65].Value = model.Photos9;
            parameters[66].Value = model.SizeM1;
            parameters[67].Value = model.SizeM2;
            parameters[68].Value = model.SizeM3;
            parameters[69].Value = model.SizeM4;
            parameters[70].Value = model.SizeM5;
            parameters[71].Value = model.SizeM6;
            parameters[72].Value = model.SizeM7;
            parameters[73].Value = model.SizeM8;
            parameters[74].Value = model.BARCODE;

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

        public bool UpdateTemp(Edge.SVA.Model.IMP_PRODUCT_TEMP model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update IMP_PRODUCT_TEMP set ");
            strSql.Append("IsOnlineSKU=@IsOnlineSKU,");
            strSql.Append("Video=@Video,");
            strSql.Append("[360Photos]=@360Photos,");
            strSql.Append("Photos1=@Photos1,");
            strSql.Append("Photos2=@Photos2,");
            strSql.Append("Photos4=@Photos4,");
            strSql.Append("Photos5=@Photos5,");
            strSql.Append("Photos6=@Photos6,");
            strSql.Append("Photos7=@Photos7,");
            strSql.Append("Photos10=@Photos10,");
            strSql.Append("Photos8=@Photos8,");
            strSql.Append("Photos3=@Photos3,");
            strSql.Append("Photos9=@Photos9");
            strSql.Append(" where BARCODE=@BARCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@IsOnlineSKU", SqlDbType.Int,4),
					new SqlParameter("@Video", SqlDbType.VarChar,512),
					new SqlParameter("@360Photos", SqlDbType.VarChar,512),
					new SqlParameter("@Photos1", SqlDbType.VarChar,512),
					new SqlParameter("@Photos2", SqlDbType.VarChar,512),
					new SqlParameter("@Photos4", SqlDbType.VarChar,512),
					new SqlParameter("@Photos5", SqlDbType.VarChar,512),
					new SqlParameter("@Photos6", SqlDbType.VarChar,512),
					new SqlParameter("@Photos7", SqlDbType.VarChar,512),
					new SqlParameter("@Photos10", SqlDbType.VarChar,512),
					new SqlParameter("@Photos8", SqlDbType.VarChar,512),
					new SqlParameter("@Photos3", SqlDbType.VarChar,512),
					new SqlParameter("@Photos9", SqlDbType.VarChar,512),
					new SqlParameter("@BARCODE", SqlDbType.VarChar,64)};
            parameters[0].Value = model.IsOnlineSKU;
            parameters[1].Value = model.Video;
            parameters[2].Value = model._360photos1;
            parameters[3].Value = model.Photos1;
            parameters[4].Value = model.Photos2;
            parameters[5].Value = model.Photos4;
            parameters[6].Value = model.Photos5;
            parameters[7].Value = model.Photos6;
            parameters[8].Value = model.Photos7;
            parameters[9].Value = model.Photos10;
            parameters[10].Value = model.Photos8;
            parameters[11].Value = model.Photos3;
            parameters[12].Value = model.Photos9;
            parameters[13].Value = model.BARCODE;

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
        public bool Delete(string INTERNAL_PRODUCT_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IMP_PRODUCT_TEMP ");
            strSql.Append(" where INTERNAL_PRODUCT_CODE=@INTERNAL_PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@INTERNAL_PRODUCT_CODE", SqlDbType.VarChar,64)			};
            parameters[0].Value = INTERNAL_PRODUCT_CODE;

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
        public bool DeleteList(string INTERNAL_PRODUCT_CODElist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from IMP_PRODUCT_TEMP ");
            strSql.Append(" where INTERNAL_PRODUCT_CODE in (" + INTERNAL_PRODUCT_CODElist + ")  ");
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
        public Edge.SVA.Model.IMP_PRODUCT_TEMP GetModel(string BARCODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 INTERNAL_PRODUCT_CODE,COMPANY_ID,BARCODE,SUPPLIER_PRODUCT_CODE,BRAND,YEAR,SEASON,ARTICLE,SEX, ");
            strSql.Append("MODEL,COLOR,PSIZE,CLASS,DESCRIPTION,REORDER_LEVEL,RETIRED,RETIRE_DATE,LAST_UPDATE_DATE,LAST_UPDATE_USER,");
            strSql.Append("DESCRIPTION2,SUPPLIER,STANDARD_COST,SIZE_RANGE,HS_CODE,EXPORT_COST,LOCAL_DESCRIPTION,COO,MATERIAL_1,MATERIAL_2,");
            strSql.Append("DESIGNER,BUYER,MERCHANDISER,SKU,AVG_COST,PRICE,FINAL_DISCOUNT_PRICE,ShortDescription1,ShortDescription2,");
            strSql.Append("ShortDescription3,Material1,Material2,Material3,Detailed1,Detailed2,Detailed3,Design1,Design2,Design3,");
            strSql.Append("ProductName1,ProductName2,ProductName3,IsOnlineSKU,OuterLayerMaterials,InnerLayerMaterials,SizeCategory,");
            strSql.Append("Video,[360Photos],Photos1,Photos2,Photos4,Photos5,Photos6,Photos7,Photos10,Photos8,Photos3,Photos9,SizeM1,");
            strSql.Append("SizeM2,SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8 from IMP_PRODUCT_TEMP");
            strSql.Append(" where BARCODE=@BARCODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@BARCODE", SqlDbType.VarChar,64)			};
            parameters[0].Value = BARCODE;

            Edge.SVA.Model.IMP_PRODUCT_TEMP model = new Edge.SVA.Model.IMP_PRODUCT_TEMP();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.IMP_PRODUCT_TEMP DataRowToModel(DataRow row)
        {
            Edge.SVA.Model.IMP_PRODUCT_TEMP model = new Edge.SVA.Model.IMP_PRODUCT_TEMP();
            if (row != null)
            {
                if (row["INTERNAL_PRODUCT_CODE"] != null)
                {
                    model.INTERNAL_PRODUCT_CODE = row["INTERNAL_PRODUCT_CODE"].ToString();
                }
                if (row["COMPANY_ID"] != null)
                {
                    model.COMPANY_ID = row["COMPANY_ID"].ToString();
                }
                if (row["BARCODE"] != null)
                {
                    model.BARCODE = row["BARCODE"].ToString();
                }
                if (row["SUPPLIER_PRODUCT_CODE"] != null)
                {
                    model.SUPPLIER_PRODUCT_CODE = row["SUPPLIER_PRODUCT_CODE"].ToString();
                }
                if (row["BRAND"] != null)
                {
                    model.BRAND = row["BRAND"].ToString();
                }
                if (row["YEAR"] != null && row["YEAR"].ToString() != "")
                {
                    model.YEAR = int.Parse(row["YEAR"].ToString());
                }
                if (row["SEASON"] != null)
                {
                    model.SEASON = row["SEASON"].ToString();
                }
                if (row["ARTICLE"] != null)
                {
                    model.ARTICLE = row["ARTICLE"].ToString();
                }
                if (row["SEX"] != null && row["SEX"].ToString() != "")
                {
                    model.SEX = int.Parse(row["SEX"].ToString());
                }
                if (row["MODEL"] != null)
                {
                    model.MODEL = row["MODEL"].ToString();
                }
                if (row["COLOR"] != null)
                {
                    model.COLOR = row["COLOR"].ToString();
                }
                if (row["PSIZE"] != null)
                {
                    model.PSIZE = row["PSIZE"].ToString();
                }
                if (row["CLASS"] != null)
                {
                    model.CLASS = row["CLASS"].ToString();
                }
                if (row["DESCRIPTION"] != null)
                {
                    model.DESCRIPTION = row["DESCRIPTION"].ToString();
                }
                if (row["REORDER_LEVEL"] != null)
                {
                    model.REORDER_LEVEL = row["REORDER_LEVEL"].ToString();
                }
                if (row["RETIRED"] != null)
                {
                    model.RETIRED = row["RETIRED"].ToString();
                }
                if (row["RETIRE_DATE"] != null && row["RETIRE_DATE"].ToString() != "")
                {
                    model.RETIRE_DATE = DateTime.Parse(row["RETIRE_DATE"].ToString());
                }
                if (row["LAST_UPDATE_DATE"] != null && row["LAST_UPDATE_DATE"].ToString() != "")
                {
                    model.LAST_UPDATE_DATE = DateTime.Parse(row["LAST_UPDATE_DATE"].ToString());
                }
                if (row["LAST_UPDATE_USER"] != null)
                {
                    model.LAST_UPDATE_USER = row["LAST_UPDATE_USER"].ToString();
                }
                if (row["DESCRIPTION2"] != null)
                {
                    model.DESCRIPTION2 = row["DESCRIPTION2"].ToString();
                }
                if (row["SUPPLIER"] != null)
                {
                    model.SUPPLIER = row["SUPPLIER"].ToString();
                }
                if (row["STANDARD_COST"] != null && row["STANDARD_COST"].ToString() != "")
                {
                    model.STANDARD_COST = decimal.Parse(row["STANDARD_COST"].ToString());
                }
                if (row["SIZE_RANGE"] != null)
                {
                    model.SIZE_RANGE = row["SIZE_RANGE"].ToString();
                }
                if (row["HS_CODE"] != null)
                {
                    model.HS_CODE = row["HS_CODE"].ToString();
                }
                if (row["EXPORT_COST"] != null && row["EXPORT_COST"].ToString() != "")
                {
                    model.EXPORT_COST = decimal.Parse(row["EXPORT_COST"].ToString());
                }
                if (row["LOCAL_DESCRIPTION"] != null)
                {
                    model.LOCAL_DESCRIPTION = row["LOCAL_DESCRIPTION"].ToString();
                }
                if (row["COO"] != null)
                {
                    model.COO = row["COO"].ToString();
                }
                if (row["MATERIAL_1"] != null)
                {
                    model.MATERIAL_1 = row["MATERIAL_1"].ToString();
                }
                if (row["MATERIAL_2"] != null)
                {
                    model.MATERIAL_2 = row["MATERIAL_2"].ToString();
                }
                if (row["DESIGNER"] != null)
                {
                    model.DESIGNER = row["DESIGNER"].ToString();
                }
                if (row["BUYER"] != null)
                {
                    model.BUYER = row["BUYER"].ToString();
                }
                if (row["MERCHANDISER"] != null)
                {
                    model.MERCHANDISER = row["MERCHANDISER"].ToString();
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["AVG_COST"] != null && row["AVG_COST"].ToString() != "")
                {
                    model.AVG_COST = decimal.Parse(row["AVG_COST"].ToString());
                }
                if (row["PRICE"] != null && row["PRICE"].ToString() != "")
                {
                    model.PRICE = decimal.Parse(row["PRICE"].ToString());
                }
                if (row["FINAL_DISCOUNT_PRICE"] != null && row["FINAL_DISCOUNT_PRICE"].ToString() != "")
                {
                    model.FINAL_DISCOUNT_PRICE = decimal.Parse(row["FINAL_DISCOUNT_PRICE"].ToString());
                }
                if (row["ShortDescription1"] != null)
                {
                    model.ShortDescription1 = row["ShortDescription1"].ToString();
                }
                if (row["ShortDescription2"] != null)
                {
                    model.ShortDescription2 = row["ShortDescription2"].ToString();
                }
                if (row["ShortDescription3"] != null)
                {
                    model.ShortDescription3 = row["ShortDescription3"].ToString();
                }
                if (row["Material1"] != null)
                {
                    model.Material1 = row["Material1"].ToString();
                }
                if (row["Material2"] != null)
                {
                    model.Material2 = row["Material2"].ToString();
                }
                if (row["Material3"] != null)
                {
                    model.Material3 = row["Material3"].ToString();
                }
                if (row["Detailed1"] != null)
                {
                    model.Detailed1 = row["Detailed1"].ToString();
                }
                if (row["Detailed2"] != null)
                {
                    model.Detailed2 = row["Detailed2"].ToString();
                }
                if (row["Detailed3"] != null)
                {
                    model.Detailed3 = row["Detailed3"].ToString();
                }
                if (row["Design1"] != null)
                {
                    model.Design1 = row["Design1"].ToString();
                }
                if (row["Design2"] != null)
                {
                    model.Design2 = row["Design2"].ToString();
                }
                if (row["Design3"] != null)
                {
                    model.Design3 = row["Design3"].ToString();
                }
                if (row["ProductName1"] != null)
                {
                    model.ProductName1 = row["ProductName1"].ToString();
                }
                if (row["ProductName2"] != null)
                {
                    model.ProductName2 = row["ProductName2"].ToString();
                }
                if (row["ProductName3"] != null)
                {
                    model.ProductName3 = row["ProductName3"].ToString();
                }
                if (row["IsOnlineSKU"] != null && row["IsOnlineSKU"].ToString() != "")
                {
                    model.IsOnlineSKU = int.Parse(row["IsOnlineSKU"].ToString());
                }
                if (row["OuterLayerMaterials"] != null)
                {
                    model.OuterLayerMaterials = row["OuterLayerMaterials"].ToString();
                }
                if (row["InnerLayerMaterials"] != null)
                {
                    model.InnerLayerMaterials = row["InnerLayerMaterials"].ToString();
                }
                if (row["SizeCategory"] != null)
                {
                    model.SizeCategory = row["SizeCategory"].ToString();
                }
                if (row["Video"] != null)
                {
                    model.Video = row["Video"].ToString();
                }
                if (row["360Photos"] != null)
                {
                    model._360photos1 = row["360Photos"].ToString();
                }
                if (row["Photos1"] != null)
                {
                    model.Photos1 = row["Photos1"].ToString();
                }
                if (row["Photos2"] != null)
                {
                    model.Photos2 = row["Photos2"].ToString();
                }
                if (row["Photos4"] != null)
                {
                    model.Photos4 = row["Photos4"].ToString();
                }
                if (row["Photos5"] != null)
                {
                    model.Photos5 = row["Photos5"].ToString();
                }
                if (row["Photos6"] != null)
                {
                    model.Photos6 = row["Photos6"].ToString();
                }
                if (row["Photos7"] != null)
                {
                    model.Photos7 = row["Photos7"].ToString();
                }
                if (row["Photos10"] != null)
                {
                    model.Photos10 = row["Photos10"].ToString();
                }
                if (row["Photos8"] != null)
                {
                    model.Photos8 = row["Photos8"].ToString();
                }
                if (row["Photos3"] != null)
                {
                    model.Photos3 = row["Photos3"].ToString();
                }
                if (row["Photos9"] != null)
                {
                    model.Photos9 = row["Photos9"].ToString();
                }
                if (row["SizeM1"] != null && row["SizeM1"].ToString() != "")
                {
                    model.SizeM1 = Convert.ToString(row["SizeM1"].ToString());
                }
                if (row["SizeM2"] != null && row["SizeM2"].ToString() != "")
                {
                    model.SizeM2 = Convert.ToString(row["SizeM2"].ToString());
                }
                if (row["SizeM3"] != null && row["SizeM3"].ToString() != "")
                {
                    model.SizeM3 = Convert.ToString(row["SizeM3"].ToString());
                }
                if (row["SizeM4"] != null && row["SizeM4"].ToString() != "")
                {
                    model.SizeM4 = Convert.ToString(row["SizeM4"].ToString());
                }
                if (row["SizeM5"] != null && row["SizeM5"].ToString() != "")
                {
                    model.SizeM5 = Convert.ToString(row["SizeM5"].ToString());
                }
                if (row["SizeM6"] != null && row["SizeM6"].ToString() != "")
                {
                    model.SizeM6 = Convert.ToString(row["SizeM6"].ToString());
                }
                if (row["SizeM7"] != null && row["SizeM7"].ToString() != "")
                {
                    model.SizeM7 = Convert.ToString(row["SizeM7"].ToString());
                }
                if (row["SizeM8"] != null && row["SizeM8"].ToString() != "")
                {
                    model.SizeM8 = Convert.ToString(row["SizeM8"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select INTERNAL_PRODUCT_CODE,COMPANY_ID,BARCODE,SUPPLIER_PRODUCT_CODE,BRAND,YEAR,SEASON,ARTICLE,SEX, ");
            strSql.Append("MODEL,COLOR,PSIZE,CLASS,DESCRIPTION,REORDER_LEVEL,RETIRED,RETIRE_DATE,LAST_UPDATE_DATE,LAST_UPDATE_USER,");
            strSql.Append("DESCRIPTION2,SUPPLIER,STANDARD_COST,SIZE_RANGE,HS_CODE,EXPORT_COST,LOCAL_DESCRIPTION,COO,MATERIAL_1,MATERIAL_2,");
            strSql.Append("DESIGNER,BUYER,MERCHANDISER,SKU,AVG_COST,PRICE,FINAL_DISCOUNT_PRICE,ShortDescription1,ShortDescription2,");
            strSql.Append("ShortDescription3,Material1,Material2,Material3,Detailed1,Detailed2,Detailed3,Design1,Design2,Design3,");
            strSql.Append("ProductName1,ProductName2,ProductName3,IsOnlineSKU,OuterLayerMaterials,InnerLayerMaterials,SizeCategory,");
            strSql.Append("Video,[360Photos],Photos1,Photos2,Photos4,Photos5,Photos6,Photos7,Photos10,Photos8,Photos3,Photos9,SizeM1,");
            strSql.Append("SizeM2,SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8 from IMP_PRODUCT_TEMP");
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
            strSql.Append(" INTERNAL_PRODUCT_CODE,COMPANY_ID,BARCODE,SUPPLIER_PRODUCT_CODE,BRAND,YEAR,SEASON,ARTICLE,SEX, ");
            strSql.Append("MODEL,COLOR,PSIZE,CLASS,DESCRIPTION,REORDER_LEVEL,RETIRED,RETIRE_DATE,LAST_UPDATE_DATE,LAST_UPDATE_USER,");
            strSql.Append("DESCRIPTION2,SUPPLIER,STANDARD_COST,SIZE_RANGE,HS_CODE,EXPORT_COST,LOCAL_DESCRIPTION,COO,MATERIAL_1,MATERIAL_2,");
            strSql.Append("DESIGNER,BUYER,MERCHANDISER,SKU,AVG_COST,PRICE,FINAL_DISCOUNT_PRICE,ShortDescription1,ShortDescription2,");
            strSql.Append("ShortDescription3,Material1,Material2,Material3,Detailed1,Detailed2,Detailed3,Design1,Design2,Design3,");
            strSql.Append("ProductName1,ProductName2,ProductName3,IsOnlineSKU,OuterLayerMaterials,InnerLayerMaterials,SizeCategory,");
            strSql.Append("Video,[360Photos],Photos1,Photos2,Photos4,Photos5,Photos6,Photos7,Photos10,Photos8,Photos3,Photos9,SizeM1,");
            strSql.Append("SizeM2,SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8 from IMP_PRODUCT_TEMP");
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
            strSql.Append("select count(1) FROM IMP_PRODUCT_TEMP ");
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
                strSql.Append("order by T.INTERNAL_PRODUCT_CODE desc");
            }
            strSql.Append(")AS Row, T.*  from IMP_PRODUCT_TEMP T ");
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
            parameters[0].Value = "IMP_PRODUCT_TEMP";
            parameters[1].Value = "INTERNAL_PRODUCT_CODE";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        public bool trunc()
        {
            string strSql = " truncate table IMP_PRODUCT_TEMP";
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
        #endregion  BasicMethod

    }
}

