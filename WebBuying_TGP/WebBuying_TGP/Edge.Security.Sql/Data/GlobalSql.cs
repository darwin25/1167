using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Security.Data
{
    public class GlobalSql
    {
        #region Permission 

        public static string CreatePermission
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO Accounts_Permissions(CategoryID,Description) VALUES(@CategoryID,@Description) ");
                sql.Append("Select @@IDENTITY as ReturnValue");
                return sql.ToString();
            }
        }

        public static string DeletePermission
        {
            get
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("DELETE Accounts_Permissions WHERE PermissionID = @PermissionID;");
                sql.Append("DELETE Accounts_RolePermissions WHERE PermissionID = @PermissionID");

                return sql.ToString();
            }
        }

        public static string GetPermissionCategories
        {
            get
            {
                return "SELECT * FROM Accounts_PermissionCategories";
            }
        }


        public static string GetPermissionCategoriesByLan
        {
            get
            {
                return "select  t.CategoryID,t.ParentID,t.OrderID, case when l.Description is not null then l.Description else t.Description end as Description from Accounts_PermissionCategories t left join Lan_Accounts_PermissionCategories l on t.CategoryID =l.CategoryID and l.lan=@Lan ORDER BY t.ParentID,t.OrderID ";
            }
        }

        public static string GetNoPermissionList
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("IF @RoleID IS NULL ");
                sql.Append("SELECT PermissionID, Description, CategoryID FROM Accounts_Permissions ORDER BY Description ");
                sql.Append("ELSE ");
                sql.Append("SELECT PermissionID, Description, CategoryID  ");
                sql.Append("FROM Accounts_Permissions ");
                sql.Append("where PermissionID not in(select PermissionID from Accounts_RolePermissions WHERE RoleID = @RoleID ) ");
                sql.Append("ORDER BY Description ");

                return sql.ToString();
            }
        }


        public static string GetNoPermissionListByLan
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                //sql.Append("IF @RoleID IS NULL ");
                //sql.Append("SELECT PermissionID, Description, CategoryID FROM Accounts_Permissions ORDER BY Description ");
                //sql.Append("ELSE ");
                //sql.Append("SELECT PermissionID, Description, CategoryID  ");
                //sql.Append("FROM Accounts_Permissions ");
                //sql.Append("where PermissionID not in(select PermissionID from Accounts_RolePermissions WHERE RoleID = @RoleID ) ");
                //sql.Append("ORDER BY Description ");
                sql.Append("IF @RoleID IS NULL "); 
                sql.Append("select  t.PermissionID,case when l.Description is not null then l.Description else t.Description end as Description,t.CategoryID ");
                sql.Append("from Accounts_Permissions t left join Lan_Accounts_Permissions l on t.PermissionID =l.PermissionID ");
                sql.Append("and l.lan=@Lan ORDER BY Description ");
                sql.Append("ELSE "); 
                sql.Append("select  t.PermissionID,case when l.Description is not null then l.Description else t.Description end as Description,t.CategoryID ");
                sql.Append("from Accounts_Permissions t left join Lan_Accounts_Permissions l on t.PermissionID =l.PermissionID and l.lan=@Lan ");
                sql.Append("where t.PermissionID not in(select PermissionID from Accounts_RolePermissions WHERE RoleID = @RoleID ) ");
                sql.Append("ORDER BY Description ");

                return sql.ToString();
            }
        }

        public static string GetPermissionList
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("IF @RoleID IS NULL ");
                sql.Append("SELECT PermissionID, Description, CategoryID FROM Accounts_Permissions ORDER BY Description ");
                sql.Append("ELSE ");
                sql.Append("SELECT ap.PermissionID, ap.Description, ap.CategoryID FROM Accounts_Permissions ap INNER JOIN ");
                sql.Append("Accounts_RolePermissions apr ON ap.PermissionID = apr.PermissionID WHERE ");
                sql.Append("apr.RoleID = @RoleID ORDER BY ap.Description ");

                return sql.ToString();
            }      
        }

        public static string GetPermissionListByLan
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                //sql.Append("IF @RoleID IS NULL ");
                //sql.Append("SELECT PermissionID, Description, CategoryID FROM Accounts_Permissions ORDER BY Description ");
                //sql.Append("ELSE ");
                //sql.Append("SELECT ap.PermissionID, ap.Description, ap.CategoryID FROM Accounts_Permissions ap INNER JOIN ");
                //sql.Append("Accounts_RolePermissions apr ON ap.PermissionID = apr.PermissionID WHERE ");
                //sql.Append("apr.RoleID = @RoleID ORDER BY ap.Description ");

                sql.Append(" IF @RoleID IS NULL  ");
                sql.Append("select  t.PermissionID,case when l.Description is not null then l.Description else t.Description end as Description,t.CategoryID ");
                sql.Append("from Accounts_Permissions t left join Lan_Accounts_Permissions l on t.PermissionID =l.PermissionID ");
                sql.Append("and l.lan=@Lan ORDER BY Description ");
                sql.Append("ELSE ");
                sql.Append("select  t.PermissionID,case when l.Description is not null then l.Description else t.Description end as Description,t.CategoryID ");
                sql.Append("from Accounts_Permissions t INNER JOIN Accounts_RolePermissions apr ON t.PermissionID = apr.PermissionID ");
                sql.Append("left join Lan_Accounts_Permissions l on t.PermissionID =l.PermissionID and l.lan=@Lan ");
                sql.Append("WHERE apr.RoleID = @RoleID ORDER BY Description ");

                return sql.ToString();
            }
        }

        public static string GetPermissionDetails
        {
            get
            {
                return "SELECT * FROM Accounts_Permissions WHERE PermissionID = @PermissionID";
            }
        }

        public static string UpdatePermission
        {
            get
            {
                return "UPDATE Accounts_Permissions SET Description = @Description WHERE PermissionID = @PermissionID";
            }
        }

        #endregion

        #region PermissionCategory

        public static string CreatePermissionCategory
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO Accounts_PermissionCategories(Description,ParentID,OrderID) VALUES(@Description,@ParentID,@OrderID) ");
                sql.Append("Select @@IDENTITY As ReturnValue");

                return sql.ToString();
            }
        }

        public static string UpdatePermissionCategory
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE Accounts_PermissionCategories SET Description = @Description ,ParentID = @ParentID,OrderID = @OrderID WHERE CategoryID=@CategoryID ");
                return sql.ToString();
            }
        }

        public static string DeletePermissionCategory
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DELETE Accounts_Permissions WHERE CategoryID = @CategoryID;");
                sql.Append("DELETE Accounts_PermissionCategories WHERE CategoryID = @CategoryID");
                return sql.ToString();
            }
        }

        public static string GetPermissionsInCategory
        {
            get
            {
                return "SELECT * FROM Accounts_Permissions where CategoryID=@CategoryID ORDER BY Description";
            }
        }

        public static string GetPermissionsInCategoryByLan
        {
            get
            {
                return "select  t.PermissionID,case when l.Description is not null then l.Description else t.Description end as Description from Accounts_Permissions t left join Lan_Accounts_Permissions l on t.PermissionID =l.PermissionID and l.lan=@Lan where t.CategoryID=@CategoryID ORDER BY Description";
            }
        }

        public static string GetPermissionCategoryDetails
        {
            get { return "SELECT * FROM Accounts_PermissionCategories WHERE CategoryID = @CategoryID"; }
        }

        #endregion

        #region Role

        public static string AddPermissionToRole
        {

            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DECLARE @Count int ");
                sql.Append("SELECT @Count = Count(PermissionID) FROM Accounts_RolePermissions WHERE ");
                sql.Append("RoleID = @RoleID and PermissionID = @PermissionID ");
                sql.Append("IF @Count = 0 ");
                sql.Append("INSERT INTO Accounts_RolePermissions(RoleID, PermissionID) ");
                sql.Append("VALUES(@RoleID, @PermissionID) ");
                return sql.ToString();
            }
        }

        public static string ClearPermissionsFromRole
        {
            get
            {
                return "DELETE Accounts_RolePermissions WHERE RoleID = @RoleID ";
            }
        }

        public static string CreateRole
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO Accounts_Roles(Description) VALUES(@Description) ");
                sql.Append("Select @@IDENTITY As ReturnValue");
                return sql.ToString();
            }
        }

        public static string DeleteRole
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DELETE Accounts_RolePermissions WHERE RoleID = @RoleID;");
                sql.Append("DELETE Accounts_UserRoles WHERE RoleID = @RoleID;");
                sql.Append("DELETE Accounts_Roles WHERE RoleID = @RoleID");
                return sql.ToString();
            }
        }

        public static string GetRoleDetailsByRoleName
        {
            get
            {
                return "SELECT * FROM Accounts_Roles WHERE Description = @RoleName";
            }

        }

        public static string GetAllRoles
        {
            get
            {
                return "SELECT RoleID, Description FROM Accounts_Roles ORDER BY Description ASC";
            }
        }

        public static string GetAllRolesByLan
        {
            get
            {
                return "SELECT t.RoleID, case when l.Description is not null then l.Description else t.Description end as Description FROM Accounts_Roles t left join Lan_Accounts_Roles l on t.RoleID =l.RoleID and l.lan=@Lan ORDER BY Description ASC";
            }
        }
        public static string GetAllRolesByLanUserID
        {
            get
            {
                return "SELECT t.RoleID, case when l.Description is not null then l.Description else t.Description end as Description FROM Accounts_Roles t left join Lan_Accounts_Roles l on t.RoleID =l.RoleID and l.lan=@Lan INNER JOIN Accounts_UserRoles AU ON t.RoleID = AU.RoleID where AU.UserID={0} ORDER BY Description ASC";
            }
        }
        public static string RemovePermissionFromRole
        {
            get
            {
                return "DELETE Accounts_RolePermissions WHERE RoleID = @RoleID and PermissionID = @PermissionID";
            }
        }

        public static string GetRoleDetails
        {
            get
            {
                return "SELECT RoleID, Description FROM Accounts_Roles WHERE RoleID = @RoleID";
            }
        }


        public static string GetRoleDetailsByLan
        {
            get
            {
                return "SELECT t.RoleID, case when l.Description is not null then l.Description else t.Description end as Description FROM Accounts_Roles t left join Lan_Accounts_Roles l on t.RoleID =l.RoleID and l.lan=@Lan where t.RoleID = @RoleID ORDER BY Description ASC ";
            }
        }

        public static string UpdateRole
        {
            get
            {
                return "UPDATE Accounts_Roles SET Description = @Description WHERE RoleID = @RoleID";
            }
        }

        #endregion

        #region User

        public static string AddUserToRole
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DECLARE @Count int ");
                sql.Append("SELECT @Count = Count(UserID) FROM Accounts_UserRoles ");
                sql.Append("WHERE RoleID = @RoleID AND UserID = @UserID ");
                sql.Append("IF @Count = 0 ");
                sql.Append("INSERT INTO Accounts_UserRoles(UserID, RoleID) VALUES(@UserID, @RoleID)");
                return sql.ToString();
            }
        }

        #region Len修改于2013-12-12
        public static string CreateUser
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO Accounts_Users(UserName, Password, TrueName,Description, Sex, Phone, Email,");
                sql.Append("EmployeeID, DepartmentID, Activity, UserType,Style) ");
                sql.Append("VALUES(@UserName, @Password, @TrueName,@Description, @Sex, @Phone, @Email,");
                sql.Append("@EmployeeID, @DepartmentID, @Activity, @UserType,@Style) ");
                sql.Append("Select @@IDENTITY As ReturnValue");

                return sql.ToString();

            }
        }
        //public static string CreateUser
        //{
        //    get
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.Append("INSERT INTO Accounts_Users(UserID,UserName, Password, TrueName,Description, Sex, Phone, Email,");
        //        sql.Append("EmployeeID, DepartmentID, Activity, UserType,Style) ");
        //        sql.Append("VALUES(@UserID,@UserName, @Password, @TrueName,@Description, @Sex, @Phone, @Email,");
        //        sql.Append("@EmployeeID, @DepartmentID, @Activity, @UserType,@Style) ");
        //        return sql.ToString();

        //    }
        //}

        public static string GetMaxUserID
        {
            get
            {
                string sql = "select Max(UserID)+1 as UserID from Accounts_Users";
                return sql;
            }
        }
        #endregion


        public static string DeleteUser
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DELETE Accounts_UserRoles WHERE UserId = @UserId ");
                sql.Append("DELETE ACcounts_Users WHERE UserId = @UserId ");
                return sql.ToString();
            }
        }

        public static string GetUsersByTrueName
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM Accounts_Users where TrueName like '%'+@key+'%' order by UserID ");
                return sql.ToString();
            }
        }

        public static string GetUsers
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM Accounts_Users order by UserID ");
                return sql.ToString();
            }
        }

        public static string GetEffectivePermissionList
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT DISTINCT Accounts_Permissions.Description FROM Accounts_RolePermissions ");
                sql.Append("inner join Accounts_Permissions on ");
                sql.Append("Accounts_RolePermissions.PermissionID=Accounts_Permissions.PermissionID WHERE RoleID IN ");
                sql.Append("(SELECT RoleID FROM Accounts_UserRoles WHERE UserID = @UserID) ");

                return sql.ToString();
            }
        }

        public static string GetEffectivePermissionListID
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT DISTINCT Accounts_Permissions.PermissionID FROM Accounts_RolePermissions ");
                sql.Append("inner join Accounts_Permissions on ");
                sql.Append("Accounts_RolePermissions.PermissionID=Accounts_Permissions.PermissionID WHERE RoleID IN ");
                sql.Append("(SELECT RoleID FROM Accounts_UserRoles WHERE UserID = @UserID) ");

                return sql.ToString();
            }
        }


        public static string GetEffectivePermissionListByLan
        {
            get
            {
                StringBuilder sql = new StringBuilder();
               sql.Append(" SELECT DISTINCT case when Lan_Accounts_Permissions.Description is not null then Lan_Accounts_Permissions.Description else Accounts_Permissions.Description end as Description FROM Accounts_RolePermissions ");
               sql.Append(" inner join Accounts_Permissions on Accounts_RolePermissions.PermissionID=Accounts_Permissions.PermissionID ");
               sql.Append(" left join Lan_Accounts_Permissions on Accounts_Permissions.PermissionID =Lan_Accounts_Permissions.PermissionID and Lan_Accounts_Permissions.Lan=@Lan ");
               sql.Append(" WHERE RoleID IN (SELECT RoleID FROM Accounts_UserRoles WHERE UserID = @UserID) ");

                return sql.ToString();
            }
        }

        public static string GetUserRoles
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT ur.RoleID, r.Description FROM Accounts_UserRoles ur ");
                sql.Append("INNER JOIN Accounts_Roles r ON ur.RoleID = r.RoleID  WHERE ur.UserID = @UserID");

                return sql.ToString();
            }
        }




        public static string GetUserRolesByLan
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT ur.RoleID, case when l.Description is not null then l.Description else r.Description end as Description FROM Accounts_UserRoles ur ");
                sql.Append("INNER JOIN Accounts_Roles r ON ur.RoleID = r.RoleID left join Lan_Accounts_Roles l on r.RoleID =l.RoleID and l.lan=@Lan  WHERE ur.UserID = @UserID");

                return sql.ToString();
            }
        }

        public static string GetUsersByDepart
        {
            get
            {
                return "SELECT * FROM Accounts_Users where DepartmentID = ''+@DepartmentID+'' order by UserID";
            }
        }

        public static string GetUsersByType
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM Accounts_Users where UserType = ''+@UserType+'' ");
                sql.Append("and (UserName like '%'+@key+'%' or TrueName like '%'+@key+'%') order by UserID");

                return sql.ToString();
            }

        }

        public static string GetUserDetailsByUserName
        {
            get
            {
                return "SELECT * FROM Accounts_Users WHERE UserName = @UserName";
            }

        }

        public static string RemoveUserFromRole
        {
            get
            {
                return "DELETE Accounts_UserRoles WHERE UserID = @UserID AND RoleID = @RoleID";
            }
        }

        public static string GetUserDetails
        {
            get
            {
                return "SELECT * FROM Accounts_Users WHERE UserID = @UserID";
            }
        }

        public static string SetPassword
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE Accounts_Users SET Password = @EncryptedPassword ");
                sql.Append("WHERE UserName = @UserName ");
                return sql.ToString();
            }

        }

        public static string TestPassword
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("DECLARE @TempID int ");
                sql.Append("SELECT @TempID = UserID FROM Accounts_Users WHERE UserID = @UserID AND ");
                sql.Append("Password = @EncryptedPassword ");
                sql.Append("IF @TempID IS NULL ");
                sql.Append("Select 0 As ReturnValue");
                sql.Append("ELSE ");
                sql.Append("Select 1 As ReturnValue");

                return sql.ToString();
            }
        }

        public static string UpdateUser
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE Accounts_Users SET ");
                sql.Append("UserName = @UserName,");
                sql.Append("Password = @Password,");
                sql.Append("TrueName = @TrueName,");
                sql.Append("Sex = @Sex,Phone = @Phone,Email = @Email,");
                sql.Append("EmployeeID = @EmployeeID,DepartmentID = @DepartmentID,");
                sql.Append("Activity = @Activity,UserType = @UserType,");
                sql.Append("Style=@Style, ");
                sql.Append("Description = @Description ");
                sql.Append("WHERE UserID = @UserID");

                return sql.ToString();
            }
        }

        public static string ValidateLogin
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("declare @UserID int ");
                sql.Append("select @UserID = UserID FROM Accounts_Users WHERE UserName = @UserName ");
                sql.Append("AND Password = @EncryptedPassword ");
                sql.Append("IF @UserID = NULL ");
                sql.Append("Select -1 As ReturnValue ");
                sql.Append("ELSE ");
                sql.Append("Select @UserID As ReturnValue ");

                return sql.ToString();
            }
        }

        #endregion
    }
}
