using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_CouponOrderForm_D : BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_CouponOrderForm_D"; }
        }
        protected override void Initialization()
        {
            base.Initialization();
            this.Order = "Ord_CouponOrderForm_D.KeyID";
        }

        public bool DeleteByOrder(string couponOrderFormNumber)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from Ord_CouponOrderForm_D where CouponOrderFormNumber = @CouponOrderFormNumber");

            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new SqlParameter("@CouponOrderFormNumber",SqlDbType.VarChar,64){ Value = couponOrderFormNumber }
            };

            return DBUtility.DbHelperSQL.ExecuteSql(sql.ToString(), parameters) > 0;
        }
    }
}
