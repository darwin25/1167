using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_CouponPicking_D : BaseDAL
    {
        protected override string TableName
        {
            get { return "Ord_CouponPicking_D"; }
        }
        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_CouponPicking_D.KeyID";
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListGroupByCouponType(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CouponTypeID,MAX(OrderQTY) as OrderQTY,Sum(PickQTY) as PickQTY FROM [Ord_CouponPicking_D] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by CouponTypeID");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public Dictionary<int, int> GetCouponTypeIndex(string couponPickingNumber)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select CouponTypeID from Ord_CouponPicking_D ");
            sql.Append("where CouponPickingNumber = @CouponPickingNumber group by CouponTypeID order by CouponTypeID");
            
            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@CouponPickingNumber",SqlDbType.NVarChar,64) { Value = couponPickingNumber }

            };
            System.Data.IDataReader reader = null;
            try
            {
                reader = DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(),parameters);
                int i = 0;
                while (reader.Read())
                {
                    dic.Add(int.Parse(reader["CouponTypeID"].ToString()), ++i);
                }
            }
            finally
            {
                if(reader != null) reader.Close();
            }

            return dic;

        }

    }
}
