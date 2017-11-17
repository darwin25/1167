using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

namespace Edge.Security.Data
{
    public class User
    {

        // Methods
        public User()
        {
        }

        public bool AddRole(int userId, int roleId)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = userId;
            parameters[1].Value = roleId;

            return DbHelperSQL.ExecuteSql(GlobalSql.AddUserToRole, parameters) > 0;

        }
        #region Len注释修改于2013-12-12
        public int Create(string userName, byte[] password, string trueName, string sex, string phone, string email, int employeeID, string departmentID, bool activity, string userType, int style,string description)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50), new SqlParameter("@Password", SqlDbType.Binary, 20), new SqlParameter("@TrueName", SqlDbType.VarChar, 50), new SqlParameter("@Sex", SqlDbType.Char, 1), new SqlParameter("@Phone", SqlDbType.VarChar, 20), new SqlParameter("@Email", SqlDbType.VarChar, 100), new SqlParameter("@EmployeeID", SqlDbType.Int, 4), new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15), new SqlParameter("@Activity", SqlDbType.Bit, 1), new SqlParameter("@UserType", SqlDbType.Char, 2), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@Style", SqlDbType.Int, 4), new SqlParameter("@Description", SqlDbType.NVarChar, 200) };
            parameters[0].Value = userName;
            parameters[1].Value = password;
            parameters[2].Value = trueName;
            parameters[3].Value = sex;
            parameters[4].Value = phone;
            parameters[5].Value = email;
            parameters[6].Value = employeeID;
            parameters[7].Value = departmentID;
            parameters[8].Value = activity ? 1 : 0;
            parameters[9].Value = userType;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Value = style;
            parameters[12].Value = description;
            int num = 0;
            try
            {

                num = Convert.ToInt32(DbHelperSQL.GetSingle(GlobalSql.CreateUser, parameters));
            }
            catch (SqlException exception)
            {
                if (exception.Number == 0xa29)
                {
                    return -100;
                }
            }
            return num;


        }
        //public int Create(string userName, byte[] password, string trueName, string sex, string phone, string email, int employeeID, string departmentID, bool activity, string userType, int style, string description)
        //{
        //    int UserID = Convert.ToInt32(DbHelperSQL.Query(GlobalSql.GetMaxUserID).Tables[0].Rows[0]["UserID"].ToString());
        //    SqlParameter[] parameters = new SqlParameter[] {
        //        new SqlParameter("@UserID", SqlDbType.Int), 
        //        new SqlParameter("@UserName", SqlDbType.VarChar, 50), 
        //        new SqlParameter("@Password", SqlDbType.Binary, 20), 
        //        new SqlParameter("@TrueName", SqlDbType.VarChar, 50), 
        //        new SqlParameter("@Sex", SqlDbType.Char, 1), 
        //        new SqlParameter("@Phone", SqlDbType.VarChar, 20), 
        //        new SqlParameter("@Email", SqlDbType.VarChar, 100), 
        //        new SqlParameter("@EmployeeID", SqlDbType.Int, 4), 
        //        new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15), 
        //        new SqlParameter("@Activity", SqlDbType.Bit, 1), 
        //        new SqlParameter("@UserType", SqlDbType.Char, 2), 
        //        //new SqlParameter("@UserID", SqlDbType.Int, 4), 
        //        new SqlParameter("@Style", SqlDbType.Int, 4), 
        //        new SqlParameter("@Description", SqlDbType.NVarChar, 200) };
        //    parameters[0].Value = UserID;
        //    parameters[1].Value = userName;
        //    parameters[2].Value = password;
        //    parameters[3].Value = trueName;
        //    parameters[4].Value = sex;
        //    parameters[5].Value = phone;
        //    parameters[6].Value = email;
        //    parameters[7].Value = employeeID;
        //    parameters[8].Value = departmentID;
        //    parameters[9].Value = activity ? 1 : 0;
        //    parameters[10].Value = userType;
        //    //parameters[11].Direction = ParameterDirection.Output;
        //    parameters[11].Value = style;
        //    parameters[12].Value = description;
        //    int num = 0;
        //    try
        //    {
        //        num = Convert.ToInt32(DbHelperSQL.GetSingle(GlobalSql.CreateUser, parameters));
        //    }
        //    catch (SqlException exception)
        //    {
        //        if (exception.Number == 0xa29)
        //        {
        //            return -100;
        //        }
        //    }
        //    return UserID;


        //}
        #endregion

        public bool Delete(int userID)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;


            return DbHelperSQL.ExecuteSql(GlobalSql.DeleteUser, parameters) > 0;
        }

        public DataSet GetAllUsers(string key)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@key", SqlDbType.VarChar, 50) };
            parameters[0].Value = key;

            return DbHelperSQL.Query(GlobalSql.GetUsersByTrueName, "Users", parameters);

        }

        //public ArrayList GetEffectivePermissionList(int userID)
        //{
        //    ArrayList list = new ArrayList();
        //    SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
        //    parameters[0].Value = userID;
        //    SqlDataReader reader = DbHelperSQL.ExecuteReader(GlobalSql.GetEffectivePermissionList, parameters);
        //    while (reader.Read())
        //    {
        //        list.Add(reader.GetString(0));
        //    }
        //    reader.Close();
        //    reader = null;
        //    return list;
        //}

        public ArrayList GetEffectivePermissionListID(int userID)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(GlobalSql.GetEffectivePermissionListID, parameters);
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0));
            }
            reader.Close();
            reader = null;
            return list;
        }

        public ArrayList GetEffectivePermissionList(int userID,string lan)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = userID;
            parameters[1].Value = lan;

            SqlDataReader reader = DbHelperSQL.ExecuteReader(GlobalSql.GetEffectivePermissionListByLan, parameters);
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            reader.Close();
            reader = null;
            return list;
        }

        public DataSet GetUserList()
        {
            return DbHelperSQL.Query(GlobalSql.GetUsers, "Users", null);
        }

        public ArrayList GetUserRoles(int userID)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(GlobalSql.GetUserRoles, parameters);
            while (reader.Read())
            {
                list.Add(reader.GetString(1));
            }
            reader.Close();
            reader = null;
            return list;
        }


        public ArrayList GetUserRoles(int userID, string lan)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = userID;
            parameters[1].Value = lan;

            SqlDataReader reader = DbHelperSQL.ExecuteReader(GlobalSql.GetUserRolesByLan, parameters);
            while (reader.Read())
            {
                list.Add(reader.GetString(1));
            }
            reader.Close();
            reader = null;
            return list;
        }


        public IList<int> GetUserRoleIDList(int userID)
        {
            List<int> list = new List<int>();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(GlobalSql.GetUserRoles, parameters);
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0));
            }
            reader.Close();
            reader = null;
            return list;
        }

        public DataSet GetUsers(string DepartmentID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15) };
            parameters[0].Value = DepartmentID;

            return DbHelperSQL.Query(GlobalSql.GetUsersByDepart, "Users", parameters);
        }

        public DataSet GetUsersByType(string usertype, string key)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserType", SqlDbType.VarChar, 2), new SqlParameter("@key", SqlDbType.VarChar, 50) };
            parameters[0].Value = usertype;
            parameters[1].Value = key;

            return DbHelperSQL.Query(GlobalSql.GetUsersByType, "Users", parameters);
        }

        public bool HasUser(string userName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parameters[0].Value = userName;


            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetUserDetailsByUserName, "Users", parameters))
            {
                if (set.Tables[0].Rows.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public bool RemoveRole(int userId, int roleId)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = userId;
            parameters[1].Value = roleId;
            return DbHelperSQL.ExecuteSql(GlobalSql.RemoveUserFromRole, parameters) > 0;
        
        }

        public DataRow Retrieve(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = userID;
           
            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetUserDetails, "Users", parameters))
            {
                if (set.Tables[0].Rows.Count > 0)
                {
                    return set.Tables[0].Rows[0];
                }
                return null;
            }
        }

        public DataRow Retrieve(string userName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parameters[0].Value = userName;
          
            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetUserDetailsByUserName, "Users", parameters))
            {
                if (set.Tables[0].Rows.Count == 0)
                {
                    return null;
                    //throw new Exception("No such user or the user has expired: " + userName);
                }
                return set.Tables[0].Rows[0];
            }
        }

        public bool SetPassword(string UserName, byte[] encPassword)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar), new SqlParameter("@EncryptedPassword", SqlDbType.Binary, 20) };
            parameters[0].Value = UserName;
            parameters[1].Value = encPassword;

            return DbHelperSQL.ExecuteSql(GlobalSql.SetPassword, parameters) > 0;
            
        }

        public int TestPassword(int userID, byte[] encPassword)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@EncryptedPassword", SqlDbType.Binary, 20) };
            parameters[0].Value = userID;
            parameters[1].Value = encPassword;

            return Convert.ToInt32(DbHelperSQL.GetSingle(GlobalSql.TestPassword, parameters));
        }

        public bool Update(int userID, string userName, byte[] password, string trueName, string sex, string phone, string email, int employeeID, string departmentID, bool activity, string userType, int style,string description)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50), new SqlParameter("@Password", SqlDbType.Binary, 20), new SqlParameter("@TrueName", SqlDbType.VarChar, 50), new SqlParameter("@Sex", SqlDbType.Char, 2), new SqlParameter("@Phone", SqlDbType.VarChar, 20), new SqlParameter("@Email", SqlDbType.VarChar, 100), new SqlParameter("@EmployeeID", SqlDbType.Int, 4), new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15), new SqlParameter("@Activity", SqlDbType.Bit, 1), new SqlParameter("@UserType", SqlDbType.Char, 2), new SqlParameter("@UserID", SqlDbType.BigInt, 8), new SqlParameter("@Style", SqlDbType.BigInt, 8), new SqlParameter("@Description", SqlDbType.NVarChar, 200) };
            parameters[0].Value = userName;
            parameters[1].Value = password;
            parameters[2].Value = trueName;
            parameters[3].Value = sex;
            parameters[4].Value = phone;
            parameters[5].Value = email;
            parameters[6].Value = employeeID;
            parameters[7].Value = departmentID;
            parameters[8].Value = activity;
            parameters[9].Value = userType;
            parameters[10].Value = userID;
            parameters[11].Value = style;
            parameters[12].Value = description;


            return DbHelperSQL.ExecuteSql(GlobalSql.UpdateUser, parameters) > 0;
        }

        public int ValidateLogin(string userName, byte[] encPassword)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50){Value=userName}, 
                                                             new SqlParameter("@EncryptedPassword", SqlDbType.Binary, 20) {Value=encPassword}
                                                            };
                                        

            return Convert.ToInt32(DbHelperSQL.GetSingle(GlobalSql.ValidateLogin, parameters));
        }


        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from Accounts_Users ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }
            return Convert.ToInt32(DbHelperSQL.GetCount(strSql.ToString()));
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int topNum = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top " + pageSize + " UserID,UserName,Password,TrueName,Description,Sex,Phone,Email,EmployeeID,DepartmentID,Activity,UserType,Style FROM Accounts_Users ");
            if (currentPage > 0)
            {
                strSql.Append(" where UserID not in(select top " + topNum + " UserID from Accounts_Users");
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
    }
}
