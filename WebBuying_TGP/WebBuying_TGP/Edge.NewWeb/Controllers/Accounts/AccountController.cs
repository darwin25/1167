using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edge.Security.Manager;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.DBUtility;
using System.Text;
using Edge.SVA.Model.Domain.SVA;
using Edge.Web.Tools;
using System.Data;
using Edge.SVA.Model;
using Edge.SVA.Model.Domain;

namespace Edge.Web.Controllers.Accounts
{
    public class AccountController
    {
        Edge.Security.Data.User bll = new Edge.Security.Data.User();
        public int GetUserListCount(User user)
        {
            if (user == null)
            {
                return 0;
            }
            int rtn = 0;
            if (user.UserName.Equals(ConstParam.SystemAdminName))
            {
                rtn = bll.GetCount(string.Empty);
            }
            else
            {
                if (user.Style == 1)//品牌用户
                {
                    rtn = bll.GetCount(@"  EXISTS
                          (SELECT     1 AS Expr1
                            FROM          (SELECT DISTINCT dbo.RelationUserStore.UserName
                                                    FROM          dbo.Store INNER JOIN
                                                                           dbo.RelationRoleBrand ON dbo.Store.BrandID = dbo.RelationRoleBrand.BrandID INNER JOIN
                                                                           dbo.RelationUserStore ON dbo.Store.StoreID = dbo.RelationUserStore.StoreID
                                                    WHERE      (dbo.RelationRoleBrand.RoleID = " + user.UserID.ToString() + @")
                                                    UNION
                                                    SELECT     UserName
FROM         dbo.Accounts_Users
WHERE     (UserID IN
                          (SELECT DISTINCT RoleID
                            FROM          dbo.RelationRoleBrand
                            WHERE      (RoleID NOT IN
                                                       (SELECT DISTINCT RoleID
                                                         FROM          dbo.RelationRoleBrand AS RelationRoleBrand_2
                                                         WHERE      (BrandID NOT IN
                                                                                    (SELECT     BrandID
                                                                                      FROM          dbo.RelationRoleBrand AS RelationRoleBrand_1
                                                                                      WHERE      (RoleID = "+user.UserID.ToString()+@")))))))) AS derivedtbl_1
                            WHERE      (UserName = Accounts_Users.UserName))");
                }
                else
                {
                    rtn = bll.GetCount(@" UserName NOT IN (SELECT  distinct   UserName FROM dbo.RelationUserStore WHERE (StoreID NOT IN (SELECT StoreID FROM dbo.RelationUserStore AS RelationUserStore_1 WHERE (UserName = '" + user.UserName + "')))) ");
                }
            }

            return rtn;
        }
        public DataSet GetUserListPerPage(User user, int pageSize, int currentPage)
        {
            bll = new Edge.Security.Data.User();
            DataSet ds = null;
            if (user.UserName.Equals(ConstParam.SystemAdminName))
            {
                ds = bll.GetPageList(pageSize, currentPage, string.Empty, " UserName Asc");
            }
            else
            {
                if (user.Style == 1)//品牌用户
                {
                    ds = bll.GetPageList(pageSize, currentPage, @"  EXISTS
                          (SELECT     1 AS Expr1
                            FROM          (SELECT DISTINCT dbo.RelationUserStore.UserName
                                                    FROM          dbo.Store INNER JOIN
                                                                           dbo.RelationRoleBrand ON dbo.Store.BrandID = dbo.RelationRoleBrand.BrandID INNER JOIN
                                                                           dbo.RelationUserStore ON dbo.Store.StoreID = dbo.RelationUserStore.StoreID
                                                    WHERE      (dbo.RelationRoleBrand.RoleID = " + user.UserID.ToString() + @")
                                                    UNION
                                                    SELECT     UserName
FROM         dbo.Accounts_Users
WHERE     (UserID IN
                          (SELECT DISTINCT RoleID
                            FROM          dbo.RelationRoleBrand
                            WHERE      (RoleID NOT IN
                                                       (SELECT DISTINCT RoleID
                                                         FROM          dbo.RelationRoleBrand AS RelationRoleBrand_2
                                                         WHERE      (BrandID NOT IN
                                                                                    (SELECT     BrandID
                                                                                      FROM          dbo.RelationRoleBrand AS RelationRoleBrand_1
                                                                                      WHERE      (RoleID ="+user.UserID.ToString()+@")))))))) AS derivedtbl_1
                            WHERE      (UserName = Accounts_Users.UserName))", " UserName Asc");
                }
                else
                {
                    ds = bll.GetPageList(pageSize, currentPage, @" UserName NOT IN (SELECT  distinct   UserName FROM dbo.RelationUserStore WHERE (StoreID NOT IN (SELECT StoreID FROM dbo.RelationUserStore AS RelationUserStore_1 WHERE (UserName = '" + user.UserName + "')))) ", " UserName Asc");
                }
            }
            DataTool.AddSex(ds, "SexName", "Sex");
            return ds;
        }
        public User GetUserByName(string username, string lan)
        {
            User user = new User(username);
            //todo:如果需要用户类别 那么再恢复
            //if (user.Style == 1)//品牌用户
            //{
            //    user.BrandInfoList = PublicInfoReostory.Singleton.GetBrandInfoListByBrandUserID(user.UserID, lan);
            //}
            //else //店铺用户
            //{
            //    user.BrandInfoList = PublicInfoReostory.Singleton.GetBrandInfoList(username, lan);
            //}
            user.EmployeeList = PublicInfoReostory.Singleton.GetEmployeeList(user.UserID); //Add By Robin 2015-08-06
            return user;
        }
        public void UpdateRelation(User user)
        {
            List<string> listSql = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (user.Style == 1)
            {
                sb.Append("delete RelationUserStore where UserName='");
                sb.Append(user.UserName);
                sb.Append("'");
                listSql.Add(sb.ToString());

                sb.Remove(0, sb.Length);
                sb.Append("delete RelationRoleBrand where RoleID='");
                sb.Append(user.UserID);
                sb.Append("'");
                listSql.Add(sb.ToString());
                foreach (BrandInfo item in user.BrandInfoList)
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("insert RelationRoleBrand ([BrandID],[RoleID]) VALUES(");
                    sb.Append(item.Key);
                    sb.Append(",'");
                    sb.Append(user.UserID);
                    sb.Append("')");
                    listSql.Add(sb.ToString());
                }
            }
            else
            {
                sb.Append("delete RelationRoleBrand where RoleID='");
                sb.Append(user.UserID);
                sb.Append("'");
                listSql.Add(sb.ToString());
                sb.Remove(0, sb.Length);
                sb.Append("delete RelationUserStore where UserName='");
                sb.Append(user.UserName);
                sb.Append("'");
                listSql.Add(sb.ToString());
                foreach (BrandInfo item in user.BrandInfoList)
                {
                    foreach (StoreInfo item1 in item.StoreInfos)
                    {
                        sb.Remove(0, sb.Length);
                        sb.Append("insert RelationUserStore ([StoreID],[UserName]) VALUES(");
                        sb.Append(item1.Key);
                        sb.Append(",'");
                        sb.Append(user.UserName);
                        sb.Append("')");
                        listSql.Add(sb.ToString());
                    }
                }
            }


            DbHelperSQL.ExecuteSqlTran(listSql);
            if (SVASessionInfo.CurrentUser.UserID == user.UserID)
            {
                SVASessionInfo.CurrentUser = GetUserByName(user.UserName, SVASessionInfo.SiteLanguage);
                SessionInfo.BrandIDsStr = SVASessionInfo.CurrentUser.SqlConditionBrandIDs;
            }
        }

        public void UpdateRolePermission(string roleID, List<string> nodeids)
        {
            List<string> listSql = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Accounts_RolePermissions where RoleID=");
            sb.Append(roleID);
            listSql.Add(sb.ToString());
            foreach (string item in nodeids)
            {
                string[] ids = item.Split('_');
                if (ids.Length >= 2)
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("insert Accounts_RolePermissions values(");
                    sb.Append(roleID);
                    sb.Append(",");
                    sb.Append(ids[1]);
                    sb.Append(")");
                    listSql.Add(sb.ToString());
                }
            }
            DbHelperSQL.ExecuteSqlTran(listSql);
        }

        public DataSet GetAllUserList()
        {
            bll = new Edge.Security.Data.User();
            DataSet ds = null;
            ds = bll.GetUserList();
            return ds;
        }

        public void UpdateSubUser(string UserID, List<string> nodeids)
        {
            List<string> listSql = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from Accounts_UsersRelation where UserID=");
            sb.Append(UserID);
            listSql.Add(sb.ToString());
            foreach (string item in nodeids)
            {
                //string[] ids = item.Split('_');
                //if (ids.Length >= 2)
                {
                    sb.Remove(0, sb.Length);
                    sb.Append("insert Accounts_UsersRelation values(");
                    sb.Append(UserID);
                    sb.Append(",");
                    sb.Append(item);
                    sb.Append(")");
                    listSql.Add(sb.ToString());
                }
            }
            DbHelperSQL.ExecuteSqlTran(listSql);
        }
    }
}