using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Edge.DBUtility;
using System.Data;

namespace Edge.SVA.BLL
{
   public partial class STAFFSTOREMAP
    {
        /// <summary>
        /// É¾³ýÊý¾Ý
        /// </summary>
        public bool Delete(int StaffID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from STAFFSTOREMAP ");
            strSql.Append(" where StaffID=@StaffID");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)};
            parameters[0].Value = StaffID;

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
