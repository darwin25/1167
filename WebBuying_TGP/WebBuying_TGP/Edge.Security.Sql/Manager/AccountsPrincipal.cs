using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.Security.Principal;
using Edge.Security.Data;

namespace Edge.Security.Manager
{
    public class AccountsPrincipal : IPrincipal
    {
        // Fields
        protected IIdentity identity;
        protected ArrayList permissionList;
        protected ArrayList permissionListid;
        protected ArrayList roleList;

        private IList<int> roleIDList = new List<int>();

        public IList<int> RoleIDList
        {
            get { return roleIDList; }
        }

        //// Methods
        //public AccountsPrincipal(int userID)
        //{
        //    Edge.Security.Data.User user = new Edge.Security.Data.User();
        //    this.identity = new SiteIdentity(userID);
        //    this.permissionList = user.GetEffectivePermissionList(userID);
        //    this.permissionListid = user.GetEffectivePermissionListID(userID);
        //    this.roleList = user.GetUserRoles(userID);
        //}

        //public AccountsPrincipal(string userName)
        //{
        //    Edge.Security.Data.User user = new Edge.Security.Data.User();
        //    this.identity = new SiteIdentity(userName);
        //    this.permissionList = user.GetEffectivePermissionList(((SiteIdentity)this.identity).UserID);
        //    this.permissionListid = user.GetEffectivePermissionListID(((SiteIdentity)this.identity).UserID);
        //    this.roleList = user.GetUserRoles(((SiteIdentity)this.identity).UserID);
        //}

        // Methods
        public AccountsPrincipal(int userID,string lan)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            this.identity = new SiteIdentity(userID);
            this.permissionList = user.GetEffectivePermissionList(userID,lan);
            this.permissionListid = user.GetEffectivePermissionListID(userID);
            this.roleList = user.GetUserRoles(userID,lan);
            this.roleIDList = user.GetUserRoleIDList(userID);
        }

        public AccountsPrincipal(string userName,string lan)
        {
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            this.identity = new SiteIdentity(userName);
            this.permissionList = user.GetEffectivePermissionList(((SiteIdentity)this.identity).UserID,lan);
            this.permissionListid = user.GetEffectivePermissionListID(((SiteIdentity)this.identity).UserID);
            this.roleList = user.GetUserRoles(((SiteIdentity)this.identity).UserID,lan);
            this.roleIDList = user.GetUserRoleIDList(((SiteIdentity)this.identity).UserID);
        }

        public static byte[] EncryptPassword(string password)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(bytes);
        }

        public bool HasPermission(string permission)
        {
            return this.permissionList.Contains(permission);
        }

        public bool HasPermissionID(int permissionid)
        {
            return this.permissionListid.Contains(permissionid);
        }

        public bool IsInRole(string role)
        {
            return this.roleList.Contains(role);
        }

        //public static AccountsPrincipal ValidateLogin(string userName, string password)
        //{
        //    byte[] encPassword = EncryptPassword(password);
        //    Edge.Security.Data.User user = new Edge.Security.Data.User();
        //    int userID = user.ValidateLogin(userName, encPassword);
        //    if (userID > 0)
        //    {
        //        return new AccountsPrincipal(userID);
        //    }
        //    return null;
        //}

        public static AccountsPrincipal ValidateLogin(string userName, string password,string lan)
        {
            byte[] encPassword = EncryptPassword(password);
            Edge.Security.Data.User user = new Edge.Security.Data.User();
            int userID = user.ValidateLogin(userName, encPassword);
            if (userID > 0)
            {
                return new AccountsPrincipal(userID,lan);
            }
            return null;
        }

        // Properties
        public IIdentity Identity
        {
            get
            {
                return this.identity;
            }
            set
            {
                this.identity = value;
            }
        }

        public ArrayList Permissions
        {
            get
            {
                return this.permissionList;
            }
        }

        public ArrayList PermissionsID
        {
            get
            {
                return this.permissionListid;
            }
        }

        public ArrayList Roles
        {
            get
            {
                return this.roleList;
            }
        }
    }
}
