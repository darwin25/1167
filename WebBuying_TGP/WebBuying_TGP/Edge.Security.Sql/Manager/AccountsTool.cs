using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Edge.Security.Data;

namespace Edge.Security.Manager
{
    public class AccountsTool
    {
        // Methods
        //public static DataSet GetAllCategories()
        //{
        //    PermissionCategory category = new PermissionCategory();
        //    return category.GetCategoryList();
        //}

        //public static DataSet GetAllPermissions()
        //{
        //    Permission permission = new Permission();
        //    return permission.GetPermissionList();
        //}

        //public static DataSet GetPermissionsByCategory(int categoryID)
        //{
        //    PermissionCategory category = new PermissionCategory();
        //    return category.GetPermissionsInCategory(categoryID);
        //}

        //public static DataSet GetRoleList()
        //{
        //    Edge.Security.Data.Role role = new Edge.Security.Data.Role();
        //    return role.GetRoleList();
        //}


        public static DataSet GetAllCategories(string lan)
        {
            PermissionCategory category = new PermissionCategory();
            return category.GetCategoryList(lan);
        }

        public static DataSet GetAllPermissions(string lan)
        {
            Permission permission = new Permission();
            return permission.GetPermissionList(lan);
        }

        public static DataSet GetPermissionsByCategory(int categoryID,string lan)
        {
            PermissionCategory category = new PermissionCategory();
            return category.GetPermissionsInCategory(categoryID,lan);
        }

        public static int GetPermissionsInCategoryCount(int categoryID, string lan)
        {
            PermissionCategory category = new PermissionCategory();
            return category.GetPermissionsInCategoryCount(categoryID, lan);
        }

        public static DataSet GetPermissionsByCategory(int categoryID, string lan, int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            PermissionCategory category = new PermissionCategory();
            return category.GetPermissionsInCategory(categoryID, lan, pageSize, currentPage, strWhere, filedOrder);
        }

        public static DataSet GetRoleList(string lan)
        {
            Edge.Security.Data.Role role = new Edge.Security.Data.Role();
            return role.GetRoleList(lan);
        }
        public static DataSet GetRoleList(string lan,User user)
        {
            Edge.Security.Data.Role role = new Edge.Security.Data.Role();
            return role.GetRoleList(lan,user);
        }

        public static DataRow GetPermission(int permissionID)
        {
            Permission permission = new Permission();

            try
            {
               return permission.Retrieve(permissionID);
            }
            catch { 
              return null;
            }
        }
        public static DataTable GetAllPermission(string lan)
        {
            DataSet ds = DBUtility.DbHelperSQL.Query("SELECT TOP (100) PERCENT CASE WHEN dbo.Lan_Accounts_Permissions.Description IS NULL THEN dbo.Accounts_Permissions.Description ELSE dbo.Lan_Accounts_Permissions.Description END AS Description, CAST(dbo.Accounts_Permissions.CategoryID AS varchar) + '_' + CAST(dbo.Accounts_Permissions.PermissionID AS varchar) AS KeyID, dbo.Accounts_Permissions.CategoryID FROM dbo.Lan_Accounts_Permissions RIGHT OUTER JOIN dbo.Accounts_Permissions ON dbo.Lan_Accounts_Permissions.PermissionID = dbo.Accounts_Permissions.PermissionID AND dbo.Lan_Accounts_Permissions.Lan = '"+lan+"' ORDER BY dbo.Accounts_Permissions.PermissionID");
            return ds.Tables[0];
        }
        public static DataTable GetAllPermissionChecked(string roleID)
        {
            DataSet ds = DBUtility.DbHelperSQL.Query("select * from Accounts_RolePermissions where roleid="+roleID);
            return ds.Tables[0];
        }
    }
}
