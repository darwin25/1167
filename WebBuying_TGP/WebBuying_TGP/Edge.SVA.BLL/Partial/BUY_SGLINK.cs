using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Edge.DBUtility;
using System.Data;

namespace Edge.SVA.BLL
{
   public partial class BUY_SGLINK
    {
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(string StoreGroupCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_SGLINK ");
            strSql.Append(" where StoreGroupCode=@StoreGroupCode");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64)};
            parameters[0].Value = StoreGroupCode;

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
    }
}
