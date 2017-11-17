using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_CouponDelivery_D : BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_CouponDelivery_D"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_CouponDelivery_D.KeyID";
        }

        public Dictionary<int, int> GetCouponTypeIndex(string couponDeliveryNumber)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select CouponTypeID from Ord_CouponDelivery_D ");
            sql.Append("where CouponDeliveryNumber = @CouponDeliveryNumber group by CouponTypeID order by CouponTypeID");

            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@CouponDeliveryNumber",System.Data.SqlDbType.NVarChar,64) { Value = couponDeliveryNumber }

            };
            System.Data.IDataReader reader = null;
            try
            {
                reader = DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), parameters);
                int i = 0;
                while (reader.Read())
                {
                    dic.Add(int.Parse(reader["CouponTypeID"].ToString()), ++i);
                }
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            return dic;

        }
    }
}
