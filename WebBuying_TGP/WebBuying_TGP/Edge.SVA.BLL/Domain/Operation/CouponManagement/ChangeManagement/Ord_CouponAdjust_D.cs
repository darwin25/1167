using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.Operation.CouponManagement.ChangeManagement
{
   public class Ord_CouponAdjust_D
    {/// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Edge.SVA.Model.Ord_CouponAdjust_D model,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ord_CouponAdjust_D(");
            strSql.Append("CouponAdjustNumber,CouponNumber,CouponAmount)");
            strSql.Append(" values (");
            strSql.Append("@CouponAdjustNumber,@CouponNumber,@CouponAmount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CouponAdjustNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CouponNumber", SqlDbType.VarChar,512),
                                        new SqlParameter("@CouponAmount",SqlDbType.Money,8)};
            parameters[0].Value = model.CouponAdjustNumber;
            parameters[1].Value = model.CouponNumber;
            parameters[2].Value = model.CouponAmount;

            //将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Edge.SVA.Model.Ord_CouponAdjust_D model,SqlTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ord_CouponAdjust_D set ");
            strSql.Append("CouponAdjustNumber=@CouponAdjustNumber,");
            strSql.Append("CouponNumber=@CouponNumber");
            strSql.Append("CouponAmount=@CouponAmount");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@CouponAdjustNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CouponNumber", SqlDbType.VarChar,512),
                    new SqlParameter("@CouponAmount",SqlDbType.Money,8),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
            parameters[0].Value = model.CouponAdjustNumber;
            parameters[1].Value = model.CouponNumber;
            parameters[2].Value = model.KeyID;

            //将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int KeyID,SqlTransaction trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ord_CouponAdjust_D ");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = { new SqlParameter("@KeyID", SqlDbType.Int, 4) };
            parameters[0].Value = KeyID;

            //将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
        }
    }
}
