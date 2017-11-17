using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.Security.Data;

namespace Edge.Security.Data
{
    public class Permission 
    {

        public Permission() 
        {
        }

        public int Create(int categoryID, string description)
        {
            
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 8), new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = categoryID;
            parameters[1].Value = description;

            return Convert.ToInt32(DbHelperSQL.GetSingle(GlobalSql.CreatePermission, parameters));
        }

        public bool Delete(int id)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = id;

            return DbHelperSQL.ExecuteSqlTran(GlobalSql.DeletePermission, parameters);

        }

        public bool Update(int PermissionID, string description)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PermissionID", SqlDbType.Int, 8), new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = PermissionID;
            parameters[1].Value = description;

            num = DbHelperSQL.ExecuteSql(GlobalSql.UpdatePermission, parameters);
            return (num == 1);
        }

        public DataSet GetNoPermissionList(int roleId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.VarChar, 4) };
            parameters[0].Value = roleId;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategories, "Categories", null))
            {
                DbHelperSQL.Query(GlobalSql.GetNoPermissionList, "Permissions", parameters, set);
                
                DataRelation relation = new DataRelation("PermissionCategories", set.Tables["Categories"].Columns["CategoryID"], set.Tables["Permissions"].Columns["CategoryID"], true);
                set.Relations.Add(relation);
                DataColumn[] columnArray = new DataColumn[] { set.Tables["Categories"].Columns["CategoryID"] };
                DataColumn[] columnArray2 = new DataColumn[] { set.Tables["Permissions"].Columns["PermissionID"] };
                set.Tables["Categories"].PrimaryKey = columnArray;
                set.Tables["Permissions"].PrimaryKey = columnArray2;
                return set;
            }
        }

        public DataSet GetPermissionList()
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.VarChar, 4) { Value = DBNull.Value } };

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategories, "Categories",null))
            {
                DbHelperSQL.Query(GlobalSql.GetPermissionList, "Permissions", parameters, set);
                DataRelation relation = new DataRelation("PermissionCategories", set.Tables["Categories"].Columns["CategoryID"], set.Tables["Permissions"].Columns["CategoryID"], true);
                set.Relations.Add(relation);
                DataColumn[] columnArray = new DataColumn[] { set.Tables["Categories"].Columns["CategoryID"] };
                DataColumn[] columnArray2 = new DataColumn[] { set.Tables["Permissions"].Columns["PermissionID"] };
                set.Tables["Categories"].PrimaryKey = columnArray;
                set.Tables["Permissions"].PrimaryKey = columnArray2;
                return set;
            }

        }

        public DataSet GetPermissionList(int roleId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.VarChar, 4) };
            parameters[0].Value = roleId;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategories, "Categories", null))
            {
                DbHelperSQL.Query(GlobalSql.GetPermissionList, "Permissions", parameters, set);

                DataRelation relation = new DataRelation("PermissionCategories", set.Tables["Categories"].Columns["CategoryID"], set.Tables["Permissions"].Columns["CategoryID"], true);
                set.Relations.Add(relation);
                DataColumn[] columnArray = new DataColumn[] { set.Tables["Categories"].Columns["CategoryID"] };
                DataColumn[] columnArray2 = new DataColumn[] { set.Tables["Permissions"].Columns["PermissionID"] };
                set.Tables["Categories"].PrimaryKey = columnArray;
                set.Tables["Permissions"].PrimaryKey = columnArray2;
                return set;
            }

        }


        public DataSet GetNoPermissionList(int roleId,string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.VarChar, 4), new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = roleId;
            parameters[1].Value = lan;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategories, "Categories", null))
            {
                DbHelperSQL.Query(GlobalSql.GetNoPermissionListByLan, "Permissions", parameters, set);

                DataRelation relation = new DataRelation("PermissionCategories", set.Tables["Categories"].Columns["CategoryID"], set.Tables["Permissions"].Columns["CategoryID"], true);
                set.Relations.Add(relation);
                DataColumn[] columnArray = new DataColumn[] { set.Tables["Categories"].Columns["CategoryID"] };
                DataColumn[] columnArray2 = new DataColumn[] { set.Tables["Permissions"].Columns["PermissionID"] };
                set.Tables["Categories"].PrimaryKey = columnArray;
                set.Tables["Permissions"].PrimaryKey = columnArray2;
                return set;
            }
        }

        public DataSet GetPermissionList(string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.VarChar, 4),new SqlParameter("@Lan", SqlDbType.NVarChar, 50)};
            parameters[0].Value = DBNull.Value;
            parameters[1].Value = lan;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategories, "Categories", null))
            {
                DbHelperSQL.Query(GlobalSql.GetPermissionListByLan, "Permissions", parameters, set);
                DataRelation relation = new DataRelation("PermissionCategories", set.Tables["Categories"].Columns["CategoryID"], set.Tables["Permissions"].Columns["CategoryID"], true);
                set.Relations.Add(relation);
                DataColumn[] columnArray = new DataColumn[] { set.Tables["Categories"].Columns["CategoryID"] };
                DataColumn[] columnArray2 = new DataColumn[] { set.Tables["Permissions"].Columns["PermissionID"] };
                set.Tables["Categories"].PrimaryKey = columnArray;
                set.Tables["Permissions"].PrimaryKey = columnArray2;
                return set;
            }

        }

        public DataSet GetPermissionList(int roleId,string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.VarChar, 4), new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = roleId;
            parameters[1].Value = lan;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategories, "Categories", null))
            {
                DbHelperSQL.Query(GlobalSql.GetPermissionListByLan, "Permissions", parameters, set);

                DataRelation relation = new DataRelation("PermissionCategories", set.Tables["Categories"].Columns["CategoryID"], set.Tables["Permissions"].Columns["CategoryID"], true);
                set.Relations.Add(relation);
                DataColumn[] columnArray = new DataColumn[] { set.Tables["Categories"].Columns["CategoryID"] };
                DataColumn[] columnArray2 = new DataColumn[] { set.Tables["Permissions"].Columns["PermissionID"] };
                set.Tables["Categories"].PrimaryKey = columnArray;
                set.Tables["Permissions"].PrimaryKey = columnArray2;
                return set;
            }

        }

        public DataRow Retrieve(int permissionId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = permissionId;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionDetails, "Permissions", parameters))
            {
                if (set.Tables[0].Rows.Count == 0)
                {
                   // return null;
                    throw new Exception("Permissions can not find （" + permissionId + "）");
                }
                return set.Tables[0].Rows[0];
            }
        }

        
    }
}
