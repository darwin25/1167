using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.SVA.Model.Domain;

namespace Edge.Security.Data
{
    public class Role
    {
        public Role()
        {
        }

        public void AddPermission(int roleId, int permissionId)
        {
            //int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = roleId;
            parameters[1].Value = permissionId;

            DbHelperSQL.ExecuteSql(GlobalSql.AddPermissionToRole, parameters);

        }

        public void ClearPermissions(int roleId)
        {
            //int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = roleId;
            DbHelperSQL.ExecuteSql(GlobalSql.ClearPermissionsFromRole, parameters);
        }

        #region Len修改于2013-12-12
        public int Create(string description)
        {
            //int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = description;

            return Convert.ToInt32(DbHelperSQL.GetSingle(GlobalSql.CreateRole, parameters));

        }        
        //public int Create(string description)
        //{
        //    string sql = "select max(RoleID)+1 as RoleID from Accounts_Roles";
        //    int roleid = Convert.ToInt32(DbHelperSQL.Query(sql).Tables[0].Rows[0]["RoleID"].ToString());
        //    SqlParameter[] parameters = new SqlParameter[] { 
        //        new SqlParameter("@RoleID", SqlDbType.Int),
        //        new SqlParameter("@Description", SqlDbType.VarChar, 50) };
        //    parameters[0].Value = roleid;
        //    parameters[1].Value = description;
        //    return Convert.ToInt32(DbHelperSQL.GetSingle("INSERT INTO Accounts_Roles(RoleID,Description) VALUES(@RoleID,@Description)", parameters));
        //}
        #endregion

        public bool Delete(int roleId)
        {
            //int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = roleId;

            return DbHelperSQL.ExecuteSqlTran(GlobalSql.DeleteRole, parameters);


        }

        public bool Update(int roleId, string description)
        {
            //int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = roleId;
            parameters[1].Value = description;

            return DbHelperSQL.ExecuteSql(GlobalSql.UpdateRole, parameters) > 0;

        }

        public bool HasRole(string roleName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleName", SqlDbType.VarChar, 50) };
            parameters[0].Value = roleName;


            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetRoleDetailsByRoleName, "Roles", parameters))
            {
                if (set.Tables[0].Rows.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }

        public DataSet GetRoleList()
        {
            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetAllRoles, "Roles", null))
            {
                return set;
            }
        }

        public DataSet GetRoleList(string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = lan;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetAllRolesByLan, "Roles", parameters))
            {
                return set;
            }
        }
        public DataSet GetRoleList(string lan, Edge.Security.Manager.User user)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = lan;

            if (user.UserName.Equals(ConstParam.SystemAdminName))
            {
                using (DataSet set = DbHelperSQL.Query(GlobalSql.GetAllRolesByLan, "Roles", parameters))
                {
                    return set;
                }
            }
            else
            {
                using (DataSet set = DbHelperSQL.Query(string.Format(GlobalSql.GetAllRolesByLanUserID,user.UserID), "Roles", parameters))
                {
                    return set;
                }
            }
        }


        public void RemovePermission(int roleId, int permissionId)
        {
            //int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = roleId;
            parameters[1].Value = permissionId;

            DbHelperSQL.ExecuteSql(GlobalSql.RemovePermissionFromRole, parameters);
        }

        public DataRow Retrieve(int roleId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = roleId;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetRoleDetails, "Roles", parameters))
            {
                return set.Tables[0].Rows[0];
            }
        }


        public DataRow Retrieve(int roleId, string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = roleId;
            parameters[1].Value = lan;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetRoleDetailsByLan, "Roles", parameters))
            {
                return set.Tables[0].Rows[0];
            }
        }

    }
}
