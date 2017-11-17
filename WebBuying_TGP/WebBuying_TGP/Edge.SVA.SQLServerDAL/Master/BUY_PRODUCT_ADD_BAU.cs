using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_PRODUCT_ADD_BAU
    /// 创建人：Lisa
    /// 创建时间：2016-02-26
    /// </summary>
    public partial class BUY_PRODUCT_ADD_BAU : IBUY_PRODUCT_ADD_BAU
    {
        public BUY_PRODUCT_ADD_BAU()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProdCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_PRODUCT_ADD_BAU");
            strSql.Append(" where ProdCode=@ProdCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = ProdCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Edge.SVA.Model.BUY_PRODUCT_ADD_BAU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_PRODUCT_ADD_BAU(");
            strSql.Append("ProdCode,Standard_Cost,Export_Cost,AVG_Cost,MODEL,SKU,YEAR,REORDER_LEVEL,HS_CODE,COO,SIZE_RANGE,DESIGNER,");
            strSql.Append("BUYER,MERCHANDISER,RETIRE_DATE,CompanyCode,Material,overview,style,fabric_care,SizeM1,SizeM2,SizeM3,SizeM4,");
            strSql.Append("SizeM5,SizeM6,SizeM7,SizeM8)");
            strSql.Append(" values (");
            strSql.Append("@ProdCode,@Standard_Cost,@Export_Cost,@AVG_Cost,@MODEL,@SKU,@YEAR,@REORDER_LEVEL,@HS_CODE,@COO,@SIZE_RANGE,");
            strSql.Append("@DESIGNER,@BUYER,@MERCHANDISER,@RETIRE_DATE,@CompanyCode,@Material,@overview,@style,@fabric_care,@SizeM1,@SizeM2,");
            strSql.Append("@SizeM3,@SizeM4,@SizeM5,@SizeM6,@SizeM7,@SizeM8)");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@Standard_Cost", SqlDbType.Money,8),
					new SqlParameter("@Export_Cost", SqlDbType.Money,8),
					new SqlParameter("@AVG_Cost", SqlDbType.Money,8),
					new SqlParameter("@MODEL", SqlDbType.VarChar,64),
					new SqlParameter("@SKU", SqlDbType.VarChar,64),
					new SqlParameter("@YEAR", SqlDbType.Int,4),
					new SqlParameter("@REORDER_LEVEL", SqlDbType.Int,4),
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@COO", SqlDbType.VarChar,64),
					new SqlParameter("@SIZE_RANGE", SqlDbType.VarChar,64),
					new SqlParameter("@DESIGNER", SqlDbType.VarChar,64),
					new SqlParameter("@BUYER", SqlDbType.VarChar,64),
					new SqlParameter("@MERCHANDISER", SqlDbType.VarChar,64),
					new SqlParameter("@RETIRE_DATE", SqlDbType.DateTime),
					new SqlParameter("@CompanyCode", SqlDbType.VarChar,64),
                    new SqlParameter("@Material", SqlDbType.VarChar,64),
					new SqlParameter("@overview", SqlDbType.VarChar,64),
					new SqlParameter("@style", SqlDbType.VarChar,64),
					new SqlParameter("@fabric_care", SqlDbType.VarChar,64),
                    new SqlParameter("@SizeM1", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM2", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM3", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM4", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM5", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM6", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM7", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM8", SqlDbType.Decimal,10)
                                        };
            parameters[0].Value = model.ProdCode;
            parameters[1].Value = model.Standard_Cost;
            parameters[2].Value = model.Export_Cost;
            parameters[3].Value = model.AVG_Cost;
            parameters[4].Value = model.MODEL;
            parameters[5].Value = model.SKU;
            parameters[6].Value = model.YEAR;
            parameters[7].Value = model.REORDER_LEVEL;
            parameters[8].Value = model.HS_CODE;
            parameters[9].Value = model.COO;
            parameters[10].Value = model.SIZE_RANGE;
            parameters[11].Value = model.DESIGNER;
            parameters[12].Value = model.BUYER;
            parameters[13].Value = model.MERCHANDISER;
            parameters[14].Value = model.RETIRE_DATE;
            parameters[15].Value = model.CompanyCode;
            parameters[16].Value = model.Material;
            parameters[17].Value = model.overview;
            parameters[18].Value = model.style;
            parameters[19].Value = model.fabric_care;
            parameters[20].Value = model.SizeM1;
            parameters[21].Value = model.SizeM2;
            parameters[22].Value = model.SizeM3;
            parameters[23].Value = model.SizeM4;
            parameters[24].Value = model.SizeM5;
            parameters[25].Value = model.SizeM6;
            parameters[26].Value = model.SizeM7;
            parameters[27].Value = model.SizeM8;
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
        public bool Update(Edge.SVA.Model.BUY_PRODUCT_ADD_BAU model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_PRODUCT_ADD_BAU set ");
            strSql.Append("Standard_Cost=@Standard_Cost,");
            strSql.Append("Export_Cost=@Export_Cost,");
            strSql.Append("AVG_Cost=@AVG_Cost,");
            strSql.Append("MODEL=@MODEL,");
            strSql.Append("SKU=@SKU,");
            strSql.Append("YEAR=@YEAR,");
            strSql.Append("REORDER_LEVEL=@REORDER_LEVEL,");
            strSql.Append("HS_CODE=@HS_CODE,");
            strSql.Append("COO=@COO,");
            strSql.Append("SIZE_RANGE=@SIZE_RANGE,");
            strSql.Append("DESIGNER=@DESIGNER,");
            strSql.Append("BUYER=@BUYER,");
            strSql.Append("MERCHANDISER=@MERCHANDISER,");
            strSql.Append("RETIRE_DATE=@RETIRE_DATE,");
            strSql.Append("CompanyCode=@CompanyCode,");
            strSql.Append("Material=@Material,");
            strSql.Append("overview=@overview,");
            strSql.Append("style=@style,");
            strSql.Append("fabric_care=@fabric_care,");
            strSql.Append("SizeM1=@SizeM1,");
            strSql.Append("SizeM2=@SizeM2,");
            strSql.Append("SizeM3=@SizeM3,");
            strSql.Append("SizeM4=@SizeM4,");
            strSql.Append("SizeM5=@SizeM5,");
            strSql.Append("SizeM6=@SizeM6,");
            strSql.Append("SizeM7=@SizeM7,");
            strSql.Append("SizeM8=@SizeM8");
            strSql.Append(" where ProdCode=@ProdCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@Standard_Cost", SqlDbType.Money,8),
					new SqlParameter("@Export_Cost", SqlDbType.Money,8),
					new SqlParameter("@AVG_Cost", SqlDbType.Money,8),
					new SqlParameter("@MODEL", SqlDbType.VarChar,64),
					new SqlParameter("@SKU", SqlDbType.VarChar,64),
					new SqlParameter("@YEAR", SqlDbType.Int,4),
					new SqlParameter("@REORDER_LEVEL", SqlDbType.Int,4),
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@COO", SqlDbType.VarChar,64),
					new SqlParameter("@SIZE_RANGE", SqlDbType.VarChar,64),
					new SqlParameter("@DESIGNER", SqlDbType.VarChar,64),
					new SqlParameter("@BUYER", SqlDbType.VarChar,64),
					new SqlParameter("@MERCHANDISER", SqlDbType.VarChar,64),
					new SqlParameter("@RETIRE_DATE", SqlDbType.DateTime),
					new SqlParameter("@CompanyCode", SqlDbType.VarChar,64),
                    new SqlParameter("@Material", SqlDbType.VarChar,64),
					new SqlParameter("@overview", SqlDbType.VarChar,64),
					new SqlParameter("@style", SqlDbType.VarChar,64),
					new SqlParameter("@fabric_care", SqlDbType.VarChar,64),
                    new SqlParameter("@SizeM1", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM2", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM3", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM4", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM5", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM6", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM7", SqlDbType.Decimal,10),
                    new SqlParameter("@SizeM8", SqlDbType.Decimal,10),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)};
            parameters[0].Value = model.Standard_Cost;
            parameters[1].Value = model.Export_Cost;
            parameters[2].Value = model.AVG_Cost;
            parameters[3].Value = model.MODEL;
            parameters[4].Value = model.SKU;
            parameters[5].Value = model.YEAR;
            parameters[6].Value = model.REORDER_LEVEL;
            parameters[7].Value = model.HS_CODE;
            parameters[8].Value = model.COO;
            parameters[9].Value = model.SIZE_RANGE;
            parameters[10].Value = model.DESIGNER;
            parameters[11].Value = model.BUYER;
            parameters[12].Value = model.MERCHANDISER;
            parameters[13].Value = model.RETIRE_DATE;
            parameters[14].Value = model.CompanyCode;
            parameters[15].Value = model.Material;
            parameters[16].Value = model.overview;
            parameters[17].Value = model.style;
            parameters[18].Value = model.fabric_care;
            parameters[19].Value = model.SizeM1;
            parameters[20].Value = model.SizeM2;
            parameters[21].Value = model.SizeM3;
            parameters[22].Value = model.SizeM4;
            parameters[23].Value = model.SizeM5;
            parameters[24].Value = model.SizeM6;
            parameters[25].Value = model.SizeM7;
            parameters[26].Value = model.SizeM8;
            parameters[27].Value = model.ProdCode;

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
        public bool Delete(string ProdCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_PRODUCT_ADD_BAU ");
            strSql.Append(" where ProdCode=@ProdCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = ProdCode;

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
        public bool DeleteList(string ProdCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_PRODUCT_ADD_BAU ");
            strSql.Append(" where ProdCode in (" + ProdCodelist + ")  ");
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
        public Edge.SVA.Model.BUY_PRODUCT_ADD_BAU GetModel(string ProdCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ProdCode,Standard_Cost,Export_Cost,AVG_Cost,MODEL,SKU,YEAR,REORDER_LEVEL,HS_CODE,COO,SIZE_RANGE, ");
            strSql.Append("DESIGNER,BUYER,MERCHANDISER,RETIRE_DATE,CompanyCode,Material,overview,style,fabric_care,SizeM1,SizeM2,");
            strSql.Append("SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8 ");
            strSql.Append("from BUY_PRODUCT_ADD_BAU");
            strSql.Append(" where ProdCode=@ProdCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
            parameters[0].Value = ProdCode;

            Edge.SVA.Model.BUY_PRODUCT_ADD_BAU model = new Edge.SVA.Model.BUY_PRODUCT_ADD_BAU();
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
        public Edge.SVA.Model.BUY_PRODUCT_ADD_BAU DataRowToModel(DataRow row)
        {
            Edge.SVA.Model.BUY_PRODUCT_ADD_BAU model = new Edge.SVA.Model.BUY_PRODUCT_ADD_BAU();
            if (row != null)
            {
                if (row["ProdCode"] != null)
                {
                    model.ProdCode = row["ProdCode"].ToString();
                }
                if (row["Standard_Cost"] != null && row["Standard_Cost"].ToString() != "")
                {
                    model.Standard_Cost = decimal.Parse(row["Standard_Cost"].ToString());
                }
                if (row["Export_Cost"] != null && row["Export_Cost"].ToString() != "")
                {
                    model.Export_Cost = decimal.Parse(row["Export_Cost"].ToString());
                }
                if (row["AVG_Cost"] != null && row["AVG_Cost"].ToString() != "")
                {
                    model.AVG_Cost = decimal.Parse(row["AVG_Cost"].ToString());
                }
                if (row["MODEL"] != null)
                {
                    model.MODEL = row["MODEL"].ToString();
                }
                if (row["SKU"] != null)
                {
                    model.SKU = row["SKU"].ToString();
                }
                if (row["YEAR"] != null && row["YEAR"].ToString() != "")
                {
                    model.YEAR = int.Parse(row["YEAR"].ToString());
                }
                if (row["REORDER_LEVEL"] != null && row["REORDER_LEVEL"].ToString() != "")
                {
                    model.REORDER_LEVEL = int.Parse(row["REORDER_LEVEL"].ToString());
                }
                if (row["HS_CODE"] != null)
                {
                    model.HS_CODE = row["HS_CODE"].ToString();
                }
                if (row["COO"] != null)
                {
                    model.COO = row["COO"].ToString();
                }
                if (row["SIZE_RANGE"] != null)
                {
                    model.SIZE_RANGE = row["SIZE_RANGE"].ToString();
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
                if (row["RETIRE_DATE"] != null && row["RETIRE_DATE"].ToString() != "")
                {
                    model.RETIRE_DATE = DateTime.Parse(row["RETIRE_DATE"].ToString());
                }
                if (row["CompanyCode"] != null)
                {
                    model.CompanyCode = row["CompanyCode"].ToString();
                }
                if (row["Material"] != null && row["Material"].ToString() != "")
                {
                    model.Material = row["Material"].ToString();
                }
                if (row["overview"] != null && row["overview"].ToString() != "")
                {
                    model.overview = row["overview"].ToString();
                }
                if (row["style"] != null && row["style"].ToString() != "")
                {
                    model.style = row["style"].ToString();
                }
                if (row["fabric_care"] != null && row["fabric_care"].ToString() != "")
                {
                    model.fabric_care = row["fabric_care"].ToString();
                }
                if (row["SizeM1"] != null && row["SizeM1"].ToString() != "")
                {
                    model.SizeM1 = Convert.ToDecimal(row["SizeM1"].ToString());
                }
                if (row["SizeM2"] != null && row["SizeM2"].ToString() != "")
                {
                    model.SizeM2 = Convert.ToDecimal(row["SizeM2"].ToString());
                }
                if (row["SizeM3"] != null && row["SizeM3"].ToString() != "")
                {
                    model.SizeM3 = Convert.ToDecimal(row["SizeM3"].ToString());
                }
                if (row["SizeM4"] != null && row["SizeM4"].ToString() != "")
                {
                    model.SizeM4 = Convert.ToDecimal(row["SizeM4"].ToString());
                }
                if (row["SizeM5"] != null && row["SizeM5"].ToString() != "")
                {
                    model.SizeM5 = Convert.ToDecimal(row["SizeM5"].ToString());
                }
                if (row["SizeM5"] != null && row["SizeM5"].ToString() != "")
                {
                    model.SizeM5 = Convert.ToDecimal(row["SizeM5"].ToString());
                }
                if (row["SizeM6"] != null && row["SizeM6"].ToString() != "")
                {
                    model.SizeM6 = Convert.ToDecimal(row["SizeM6"].ToString());
                }
                if (row["SizeM7"] != null && row["SizeM7"].ToString() != "")
                {
                    model.SizeM7 = Convert.ToDecimal(row["SizeM7"].ToString());
                }
                if (row["SizeM8"] != null && row["SizeM8"].ToString() != "")
                {
                    model.SizeM8 = Convert.ToDecimal(row["SizeM8"].ToString());
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
            strSql.Append("select  ProdCode,Standard_Cost,Export_Cost,AVG_Cost,MODEL,SKU,YEAR,REORDER_LEVEL,HS_CODE,COO,SIZE_RANGE, ");
            strSql.Append("DESIGNER,BUYER,MERCHANDISER,RETIRE_DATE,CompanyCode,Material,overview,style,fabric_care,SizeM1,SizeM2,");
            strSql.Append("SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8 ");
            strSql.Append("from BUY_PRODUCT_ADD_BAU");
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
            strSql.Append(" ProdCode,Standard_Cost,Export_Cost,AVG_Cost,MODEL,SKU,YEAR,REORDER_LEVEL,HS_CODE,COO,SIZE_RANGE, ");
            strSql.Append("DESIGNER,BUYER,MERCHANDISER,RETIRE_DATE,CompanyCode,Material,overview,style,fabric_care,SizeM1,SizeM2,");
            strSql.Append("SizeM3,SizeM4,SizeM5,SizeM6,SizeM7,SizeM8 ");
            strSql.Append("from BUY_PRODUCT_ADD_BAU");
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
            strSql.Append("select count(1) FROM BUY_PRODUCT_ADD_BAU ");
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
                strSql.Append("order by T.ProdCode desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_PRODUCT_ADD_BAU T ");
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
            parameters[0].Value = "BUY_PRODUCT_ADD_BAU";
            parameters[1].Value = "ProdCode";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
    }
}

