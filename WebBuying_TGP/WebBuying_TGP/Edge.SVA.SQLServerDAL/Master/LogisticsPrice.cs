using System;
using System.Collections.Generic;
using System.Text;
using Edge.DBUtility;
using System.Data.SqlClient;
using System.Data;
using Edge.SVA.IDAL;

namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 物流价格设置表。 按省份，按供应商，设置报价
    /// 创建人：Lisa
    /// 创建时间：2015-12-31
    /// </summary>
    public partial class LogisticsPrice : ILogisticsPrice
    {
        public LogisticsPrice() { }

        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("KeyID", "LogisticsPrice");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int KeyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LogisticsPrice");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.LogisticsPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LogisticsPrice(");
            strSql.Append("LogisticsProviderID,ProvinceCode,StartPrice,StartWeight,OverflowPricePerKG)");
            strSql.Append(" values (");
            strSql.Append("@LogisticsProviderID,@ProvinceCode,@StartPrice,@StartWeight,@OverflowPricePerKG)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartPrice", SqlDbType.Money,8),
					new SqlParameter("@StartWeight", SqlDbType.Decimal,9),
					new SqlParameter("@OverflowPricePerKG", SqlDbType.Money,8)};
            parameters[0].Value = model.LogisticsProviderID;
            parameters[1].Value = model.ProvinceCode;
            parameters[2].Value = model.StartPrice;
            parameters[3].Value = model.StartWeight;
            parameters[4].Value = model.OverflowPricePerKG;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.LogisticsPrice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LogisticsPrice set ");
            strSql.Append("LogisticsProviderID=@LogisticsProviderID,");
            strSql.Append("ProvinceCode=@ProvinceCode,");
            strSql.Append("StartPrice=@StartPrice,");
            strSql.Append("StartWeight=@StartWeight,");
            strSql.Append("OverflowPricePerKG=@OverflowPricePerKG");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4),
					new SqlParameter("@ProvinceCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartPrice", SqlDbType.Money,8),
					new SqlParameter("@StartWeight", SqlDbType.Decimal,9),
					new SqlParameter("@OverflowPricePerKG", SqlDbType.Money,8),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
            parameters[0].Value = model.LogisticsProviderID;
            parameters[1].Value = model.ProvinceCode;
            parameters[2].Value = model.StartPrice;
            parameters[3].Value = model.StartWeight;
            parameters[4].Value = model.OverflowPricePerKG;
            parameters[5].Value = model.KeyID;

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
        public bool Delete(int KeyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LogisticsPrice ");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

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
        public bool DeleteList(string KeyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LogisticsPrice ");
            strSql.Append(" where KeyID in (" + KeyIDlist + ")  ");
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
        public Edge.SVA.Model.LogisticsPrice GetModel(int KeyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KeyID,LogisticsProviderID,ProvinceCode,StartPrice,StartWeight,OverflowPricePerKG from LogisticsPrice ");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

            Edge.SVA.Model.LogisticsPrice model = new Edge.SVA.Model.LogisticsPrice();
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
        public Edge.SVA.Model.LogisticsPrice DataRowToModel(DataRow row)
        {
            Edge.SVA.Model.LogisticsPrice model = new Edge.SVA.Model.LogisticsPrice();
            if (row != null)
            {
                if (row["KeyID"] != null && row["KeyID"].ToString() != "")
                {
                    model.KeyID = int.Parse(row["KeyID"].ToString());
                }
                if (row["LogisticsProviderID"] != null && row["LogisticsProviderID"].ToString() != "")
                {
                    model.LogisticsProviderID = int.Parse(row["LogisticsProviderID"].ToString());
                }
                if (row["ProvinceCode"] != null)
                {
                    model.ProvinceCode = row["ProvinceCode"].ToString();
                }
                if (row["StartPrice"] != null && row["StartPrice"].ToString() != "")
                {
                    model.StartPrice = decimal.Parse(row["StartPrice"].ToString());
                }
                if (row["StartWeight"] != null && row["StartWeight"].ToString() != "")
                {
                    model.StartWeight = decimal.Parse(row["StartWeight"].ToString());
                }
                if (row["OverflowPricePerKG"] != null && row["OverflowPricePerKG"].ToString() != "")
                {
                    model.OverflowPricePerKG = decimal.Parse(row["OverflowPricePerKG"].ToString());
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
            strSql.Append("select KeyID,LogisticsProviderID,ProvinceCode,StartPrice,StartWeight,OverflowPricePerKG ");
            strSql.Append(" FROM LogisticsPrice ");
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
            strSql.Append(" KeyID,LogisticsProviderID,ProvinceCode,StartPrice,StartWeight,OverflowPricePerKG ");
            strSql.Append(" FROM LogisticsPrice ");
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
            strSql.Append("select count(1) FROM LogisticsPrice ");
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
                strSql.Append("order by T.KeyID desc");
            }
            strSql.Append(")AS Row, T.*  from LogisticsPrice T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
    }
}
