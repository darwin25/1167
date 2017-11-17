using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Member
    {
        public List<int> GetMembers(string mobileNumber)
        {
            List<int> members = new List<int>();

            StringBuilder sql = new StringBuilder(100);
            sql.Append("select MemberID from Member ");
            sql.Append("where MemberRegisterMobile = @MemberRegisterMobile");

            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@MemberRegisterMobile", System.Data.SqlDbType.VarChar) { Value = mobileNumber }
            };
            System.Data.IDataReader reader = null;
            try
            {
                reader = DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), parameters);
                while (reader.Read())
                {
                    members.Add(int.Parse(reader["MemberID"].ToString()));
                }
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return members;
        }
    }
}
