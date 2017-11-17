using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_ImportCouponUID_D
    {
        public bool FastAdd(Model.Ord_ImportCouponUID_D model, ref SqlConnection connection)
        {
            return true;
        }

        public DataSet GetListForTotal(int PageSize, int PageIndex, string strWhere, string filedOrder, string fields, int times)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "Ord_ImportCouponUID_D";
            parameters[1].Value = fields;
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 1;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds", times);
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder, string fields, int times)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "Ord_ImportCouponUID_D";
            parameters[1].Value = fields;
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds", times);
        }

        public int GetCount(string importCouponNumber, int times)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select COUNT(ImportCouponNumber) as CouponCount  from Ord_ImportCouponUID_D where ImportCouponNumber = @ImportCouponNumber");
            System.Data.SqlClient.SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ImportCouponNumber",importCouponNumber)
            };
            System.Data.IDataReader reader = null;
            try
            {
                reader = Edge.DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), times, parameters);

                if (reader.Read())
                {
                    object obj = reader["CouponCount"];

                    if (obj is int) return (int)obj;
                }
                return 0;
            }
            finally
            {
                if (reader != null) reader.Close();
            }

        }

        public decimal GetAllDenomination(string importCouponNumber)
        {
            Edge.SVA.Model.Ord_ImportCouponUID_H model = new Edge.SVA.SQLServerDAL.Ord_ImportCouponUID_H().GetModel(importCouponNumber);
            if (model == null) throw new Exception("Not Exist This Traction");

            StringBuilder sql = new StringBuilder(100);
            if (model.ApproveStatus == "A")
            {
                sql.Append("select sum(CouponAmount) as Denomination from CouponUIDMap as map ");
                sql.Append("left join Coupon as cou on map.CouponUID = cou.CouponNumber ");
                sql.Append("where map.ImportCouponNumber = @ImportCouponNumber");
            }
            else
            {
                sql.Append("select sum(CASE ");
                sql.Append("when ct.CoupontypeFixedAmount = 1 then ct.CouponTypeAmount ");
                sql.Append("when ct.CoupontypeFixedAmount = 0 then 0.0 ");
                sql.Append("end) as Denomination  ");
                sql.Append("from Ord_ImportCouponUID_D as ord ");
                sql.Append("left join CouponType as ct on ord.CouponTypeID = ct.CouponTypeID ");
                sql.Append("where ord.ImportCouponNumber = @ImportCouponNumber");
            }

            System.Data.SqlClient.SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ImportCouponNumber",SqlDbType.VarChar,512) { Value = importCouponNumber }
            };


            using (System.Data.IDataReader reader = DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), 60, parameters))
            {
                if (!reader.Read()) throw new Exception("No Data");

                object result = reader["Denomination"];

                if (result == DBNull.Value) return 0.0m;

                decimal denomination = 0.0m;

                return decimal.TryParse(result.ToString(), out denomination) ? denomination : 0.0m;
            }
        


        }
    }
}
