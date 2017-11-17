using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Edge.Security.Data
{
    public class PermissionCategory
    {
        public PermissionCategory()
        {
        }

        public int Create(string description, int parentID, int orderID)
        {

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Description", SqlDbType.VarChar, 50),
            new SqlParameter("@ParentID", SqlDbType.Int) ,
            new SqlParameter("@OrderID", SqlDbType.Int) };
            parameters[0].Value = description;
            parameters[1].Value = parentID;
            parameters[2].Value = orderID;

            return Convert.ToInt32(DbHelperSQL.GetSingle(GlobalSql.CreatePermissionCategory, parameters));

        }

        public int Update(int categoryID,string description, int parentID, int orderID)
        {

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Description", SqlDbType.VarChar, 50),
            new SqlParameter("@ParentID", SqlDbType.Int) ,
            new SqlParameter("@OrderID", SqlDbType.Int),
             new SqlParameter("@CategoryID", SqlDbType.Int)};
            parameters[0].Value = description;
            parameters[1].Value = parentID;
            parameters[2].Value = orderID;
            parameters[3].Value = categoryID;
            return Convert.ToInt32(DbHelperSQL.ExecuteSql(GlobalSql.UpdatePermissionCategory, parameters));

        }

        public bool Delete(int id)
        {
            int num;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = id;

            return DbHelperSQL.ExecuteSqlTran(GlobalSql.DeletePermissionCategory, parameters);
           
        }

        public DataSet GetCategoryList()
        {
            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategories, "Categories", null))
            {
                return set;
            }
        }

        public DataSet GetCategoryList(string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = lan;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategoriesByLan, "Categories", parameters))
            {
                return set;
            }
        }

        public DataSet GetPermissionsInCategory(int categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = categoryId;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionsInCategory, "Categories", parameters))
            {
                return set;
            }
        }

        public DataSet GetPermissionsInCategory(int categoryId,string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4), new SqlParameter("@Lan", SqlDbType.NVarChar, 50) };
            parameters[0].Value = categoryId;
            parameters[1].Value = lan;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionsInCategoryByLan, "Categories", parameters))
            {
                return set;
            }
        }

        public int GetPermissionsInCategoryCount(int categoryId, string lan)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" select count(*) from Accounts_Permissions left join Lan_Accounts_Permissions on Accounts_Permissions.PermissionID =Lan_Accounts_Permissions.PermissionID and Lan_Accounts_Permissions.lan='" + lan + "' where Accounts_Permissions.CategoryID=" + categoryId);

            return DbHelperSQL.GetCount(sql.ToString());

        }


        public DataSet GetPermissionsInCategory(int categoryId, string lan,int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            SqlParameter[] parameters = new SqlParameter[] 
            { new SqlParameter("@CategoryID", SqlDbType.Int, 4),
                new SqlParameter("@Lan", SqlDbType.NVarChar, 50)};
            parameters[0].Value = categoryId;
            parameters[1].Value = lan;
        
            int topSize = pageSize * currentPage;
  
             StringBuilder strSql = new StringBuilder();
             strSql.Append("select top " + pageSize + " Accounts_Permissions.PermissionID,case when Lan_Accounts_Permissions.Description is not null then Lan_Accounts_Permissions.Description else Accounts_Permissions.Description end as Description ");
             strSql.Append(" from Accounts_Permissions left join Lan_Accounts_Permissions on Accounts_Permissions.PermissionID =Lan_Accounts_Permissions.PermissionID and Lan_Accounts_Permissions.lan=@Lan");
             strSql.Append(" where Accounts_Permissions.PermissionID not in(select top " + topSize + " Accounts_Permissions.PermissionID from Accounts_Permissions");
             strSql.Append(" left join Lan_Accounts_Permissions on Accounts_Permissions.PermissionID =Lan_Accounts_Permissions.PermissionID and Lan_Accounts_Permissions.lan=@Lan where Accounts_Permissions.CategoryID=@CategoryID");
             if (strWhere.Trim() != "")
             {
                 strSql.Append(" and " + strWhere);
             }
             strSql.Append(" order by " + filedOrder + ")");
             strSql.Append(" and Accounts_Permissions.CategoryID=@CategoryID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);

            using (DataSet set = DbHelperSQL.Query(strSql.ToString(), "Categories", parameters))
            {
                return set;
            }
        }


        public DataRow Retrieve(int categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = categoryId;

            using (DataSet set = DbHelperSQL.Query(GlobalSql.GetPermissionCategoryDetails, "Categories", parameters))
            {
                return set.Tables[0].Rows[0];
            }
        }

    }
}
