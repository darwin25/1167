using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Ord_CouponAdjust_D
    /// </summary>
    public partial class Ord_CouponAdjust_D : IOrd_CouponAdjust_D
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListWithCoupon(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Ord_CouponAdjust_D.KeyID,Ord_CouponAdjust_D.CouponAdjustNumber,Ord_CouponAdjust_D.CouponNumber ,");
            strSql.Append("Coupon.CouponTypeID,Coupon.CouponIssueDate,Coupon.CouponExpiryDate,Coupon.CouponExpiryDate as OrgExpiryDate,Coupon.CouponActiveDate,Coupon.StoreID,");
            strSql.Append("Coupon.BatchCouponID,Coupon.Status,Coupon.CouponPassword,Coupon.CardNumber,Coupon.CreatedOn,Coupon.UpdatedOn,Coupon.CreatedBy,");
            strSql.Append("Coupon.UpdatedBy,Coupon.CouponAmount,Coupon.RedeemStoreID");
            strSql.Append(" FROM Ord_CouponAdjust_D left join Coupon on Ord_CouponAdjust_D.CouponNumber=Coupon.CouponNumber ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());

        }


        public DataSet GetPageListWithCoupon_Movement1(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int startNum = pageSize * currentPage + 1;
            int endNum = pageSize * (currentPage+1);

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select E.* from(
select D.*,ROW_NUMBER() over(order by D.CouponNumber asc) as rowRank from Ord_CouponAdjust_D A inner join
(
select B.*
from Coupon_Movement B 
where B.KeyID=(select max(KeyID) from Coupon_Movement C where OrgStatus<>NewStatus and B.CouponNumber=C.CouponNumber)
) D on A.CouponNumber=D.CouponNumber where " + strWhere + @") E
where E.rowRank between " + startNum + " and " + endNum);
            return DbHelperSQL.Query(strSql.ToString());

        }
        public int GetCountWithCoupon_Movement1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select count(1) from Ord_CouponAdjust_D A where " + strWhere);
            return DbHelperSQL.GetCount(strSql.ToString());

        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public int GetCountWithCoupon(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(1) from Ord_CouponAdjust_D left join Coupon on Ord_CouponAdjust_D.CouponNumber=Coupon.CouponNumber ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetPageListWithCoupon(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int topNum = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top " + pageSize + " Ord_CouponAdjust_D.KeyID,Ord_CouponAdjust_D.CouponAdjustNumber,Ord_CouponAdjust_D.CouponNumber ,");
            strSql.Append("Coupon.CouponTypeID,Coupon.CouponIssueDate,Coupon.CouponExpiryDate,Coupon.CouponExpiryDate as OrgExpiryDate,Coupon.CouponActiveDate,Coupon.StoreID,");
            strSql.Append("Coupon.BatchCouponID,Coupon.Status,Coupon.CouponPassword,Coupon.CardNumber,Coupon.CreatedOn,Coupon.UpdatedOn,Coupon.CreatedBy,");
            strSql.Append("Coupon.UpdatedBy,Ord_CouponAdjust_D.CouponAmount as OrdCouponAmount,Coupon.RedeemStoreID,Coupon.CouponAmount");
            strSql.Append(" FROM Ord_CouponAdjust_D left join Coupon on Ord_CouponAdjust_D.CouponNumber=Coupon.CouponNumber ");
            if (currentPage > 0)
            {
                strSql.Append(" where Ord_CouponAdjust_D.CouponNumber not in(select top " + topNum + " Ord_CouponAdjust_D.CouponNumber FROM Ord_CouponAdjust_D left join Coupon on Ord_CouponAdjust_D.CouponNumber=Coupon.CouponNumber");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder + ")");
            }
            if (strWhere.Trim() != "")
            {
                if (currentPage > 0)
                {
                    strSql.Append(" and " + strWhere);
                }
                else
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            strSql.Append(" order by " + filedOrder);

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public int GetCountWithCoupon_Movement(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(1) from Coupon_Movement ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());

        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetPageListWithCoupon_Movement(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            //SqlParameter[] parameters = {
            //        new SqlParameter("@tblName", SqlDbType.VarChar, 255),
            //        new SqlParameter("@fldName", SqlDbType.VarChar, 255),
            //        new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
            //        new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
            //        new SqlParameter("@PageSize", SqlDbType.Int),
            //        new SqlParameter("@PageIndex", SqlDbType.Int),
            //        new SqlParameter("@IsReCount", SqlDbType.Bit),
            //        new SqlParameter("@OrderType", SqlDbType.Bit),
            //        new SqlParameter("@strWhere", SqlDbType.NText),
            //        };
            //parameters[0].Value = "Coupon_Movement";
            //parameters[1].Value = "CouponNumber,CreatedOn,OrgExpiryDate,NewExpiryDate as CouponExpiryDate,OrgStatus,NewStatus as Status,OpenBal,Amount,CloseBal,CloseBal as CouponAmount";
            //parameters[2].Value = filedOrder;
            //parameters[3].Value = "";
            //parameters[4].Value = PageSize;
            //parameters[5].Value = PageIndex;
            //parameters[6].Value = 0;
            //parameters[7].Value = 0;
            //parameters[8].Value = strWhere;
            //return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");


            int topNum = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top " + pageSize + " Coupon.CreatedOn,");
            strSql.Append("Coupon_Movement.CouponNumber,Coupon_Movement.OrgExpiryDate,Coupon_Movement.NewExpiryDate as CouponExpiryDate,Coupon.CouponTypeID,Coupon.BatchCouponID, ");
            strSql.Append("Coupon_Movement.OrgStatus,Coupon_Movement.NewStatus as Status,Coupon_Movement.OpenBal,Coupon_Movement.Amount,Coupon_Movement.CloseBal,Coupon_Movement.OpenBal as CouponAmount,Coupon_Movement.Amount as OrdCouponAmount ");
            //strSql.Append("Coupon.CouponTypeID,Coupon.CouponIssueDate,Coupon.CouponExpiryDate,Coupon.CouponActiveDate,Coupon.StoreID,");
            //strSql.Append("Coupon.BatchCouponID,Coupon.Status,Coupon.CouponPassword,Coupon.CardNumber,Coupon.CreatedOn,Coupon.UpdatedOn,Coupon.CreatedBy,");
            //strSql.Append("Coupon.UpdatedBy,Ord_CouponAdjust_D.CouponAmount,Coupon.RedeemStoreID");
            strSql.Append(" FROM Coupon_Movement left join Coupon on Coupon_Movement.CouponNumber=Coupon.CouponNumber ");
            if (currentPage > 0)
            {
                strSql.Append(" where Coupon_Movement.CouponNumber not in(select top " + topNum + " Coupon_Movement.CouponNumber FROM Coupon_Movement left join Coupon on Coupon_Movement.CouponNumber=Coupon.CouponNumber");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder + ")");
            }
            if (strWhere.Trim() != "")
            {
                if (currentPage > 0)
                {
                    strSql.Append(" and " + strWhere);
                }
                else
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            strSql.Append(" order by " + filedOrder);

            return DbHelperSQL.Query(strSql.ToString());
        }

        public decimal GetAllDenominationWithCoupon(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select sum(Coupon.CouponAmount) as Denomination ");
            strSql.Append(" FROM Ord_CouponAdjust_D left join Coupon on Ord_CouponAdjust_D.CouponNumber=Coupon.CouponNumber ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            using (System.Data.IDataReader reader = DBUtility.DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (!reader.Read()) throw new Exception("No Data");

                object result = reader["Denomination"];

                if (result == DBNull.Value) return 0.0m;

                decimal denomination = 0.0m;

                return decimal.TryParse(result.ToString(), out denomination) ? denomination : 0.0m;
            }
        }

        public decimal GetAllDenominationWithOrd_CouponAdjust_D(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select sum(Ord_CouponAdjust_D.CouponAmount) as Denomination ");
            strSql.Append(" FROM Ord_CouponAdjust_D left join Coupon on Ord_CouponAdjust_D.CouponNumber=Coupon.CouponNumber ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            using (System.Data.IDataReader reader = DBUtility.DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (!reader.Read()) throw new Exception("No Data");

                object result = reader["Denomination"];

                if (result == DBNull.Value) return 0.0m;

                decimal denomination = 0.0m;

                return decimal.TryParse(result.ToString(), out denomination) ? denomination : 0.0m;
            }
        }

        public decimal GetAllDenominationWithCoupon_Movement(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select sum(Coupon_Movement.CloseBal) as Denomination ");
            strSql.Append(" FROM Coupon_Movement left join Coupon on Coupon_Movement.CouponNumber=Coupon.CouponNumber ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            using (System.Data.IDataReader reader = DBUtility.DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (!reader.Read()) throw new Exception("No Data");

                object result = reader["Denomination"];

                if (result == DBNull.Value) return 0.0m;

                decimal denomination = 0.0m;

                return decimal.TryParse(result.ToString(), out denomination) ? denomination : 0.0m;
            }

        }

        public void GetAllDenominationWithCoupon_Movement(string strWhere, out decimal openBal, out decimal amount, out decimal closeBal)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select sum(Coupon_Movement.OpenBal) as openBal,sum(Coupon_Movement.Amount) as amount,sum(Coupon_Movement.CloseBal) as closeBal ");
            strSql.Append(" FROM Coupon_Movement left join Coupon on Coupon_Movement.CouponNumber=Coupon.CouponNumber ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            using (System.Data.IDataReader reader = DBUtility.DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                if (!reader.Read()) throw new Exception("No Data");

                //object objOpen = reader["openBal"];
                //object objAmount = reader["amount"];
                //object objClose = reader["closeBal"];
                object objOpen = reader["openBal"];
                object objAmount =reader["closeBal"];
                object objClose = reader["amount"];

                //if (objOpen == DBNull.Value) openBal = 0.0m;
                //if (objAmount == DBNull.Value) amount = 0.0m;
                //if (objClose == DBNull.Value) closeBal = 0.0m;

                decimal denomination = 0.0m;

                openBal = decimal.TryParse(objOpen.ToString(), out denomination) ? denomination : 0.0m;
                amount = decimal.TryParse(objAmount.ToString(), out denomination) ? denomination : 0.0m;
                closeBal = decimal.TryParse(objClose.ToString(), out denomination) ? denomination : 0.0m;
            }

        }

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetPageListWithCoupon_Movement(int pageSize, int currentPage, string strWhere, string filedOrder)
        //{
        //    int topNum = pageSize * (currentPage+1);

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select Ord_CouponAdjust_D.*,Coupon_Movement.OrgExpiryDate as CouponExpiryDate,Coupon_Movement.OrgStatus as  Status,Coupon_Movement.CreatedOn");
        //    strSql.Append(" from (select top " + pageSize + " * from (select top " + topNum + " Ord_CouponAdjust_D.KeyID,Ord_CouponAdjust_D.CouponAdjustNumber,Ord_CouponAdjust_D.CouponNumber ");
        //    strSql.Append(" from Ord_CouponAdjust_D where ");
        //    strSql.Append(strWhere);
        //    strSql.Append(" order by ");
        //    strSql.Append(filedOrder);
        //    strSql.Append(") as Ord_CouponAdjust_D order by " + filedOrder + " desc) as Ord_CouponAdjust_D left join Coupon_Movement on Ord_CouponAdjust_D.CouponNumber=Coupon_Movement.CouponNumber");
        //    strSql.Append(" order by ");
        //    strSql.Append(filedOrder);



        //   // strSql.Append("select top " + pageSize + " Ord_CouponAdjust_D.KeyID,Ord_CouponAdjust_D.CouponAdjustNumber,Ord_CouponAdjust_D.CouponNumber ,");
        //   // strSql.Append("Coupon_Movement.OrgExpiryDate,Coupon_Movement.OrgStatus");
        //   // //strSql.Append("Coupon_Movement.BatchCouponID,Coupon.Status,Coupon.CouponPassword,Coupon.CardNumber,Coupon.CreatedOn,Coupon.UpdatedOn,Coupon.CreatedBy,");
        //   //// strSql.Append("Coupon.UpdatedBy,Coupon.CouponAmount,Coupon.RedeemStoreID");
        //   // strSql.Append(" FROM Ord_CouponAdjust_D left join Coupon_Movement on Ord_CouponAdjust_D.CouponNumber=Coupon_Movement.CouponNumber ");
        //   // if (currentPage > 0)
        //   // {
        //   //     strSql.Append(" where Ord_CouponAdjust_D.CouponNumber not in(select top " + topNum + " Ord_CouponAdjust_D.CouponNumber FROM Ord_CouponAdjust_D left join Coupon_Movement on Ord_CouponAdjust_D.CouponNumber=Coupon_Movement.CouponNumber");
        //   //     if (strWhere.Trim() != "")
        //   //     {
        //   //         strSql.Append(" where " + strWhere);
        //   //     }
        //   //     strSql.Append(" order by " + filedOrder + ")");
        //   // }
        //   // if (strWhere.Trim() != "")
        //   // {
        //   //     if (currentPage > 0)
        //   //     {
        //   //         strSql.Append(" and " + strWhere);
        //   //     }
        //   //     else
        //   //     {
        //   //         strSql.Append(" where " + strWhere);
        //   //     }
        //   // }
        //   // strSql.Append(" order by " + filedOrder);

        //    return DbHelperSQL.Query(strSql.ToString());
        //}
    }
}

