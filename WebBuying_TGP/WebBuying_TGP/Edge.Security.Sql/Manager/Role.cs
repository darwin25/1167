using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Edge.Security.Data;

namespace Edge.Security.Manager
{
    public class Role
    {
        // Fields
        private string description;
        private DataSet nopermissions;
        private DataSet permissions;
        private int roleId;

        // Methods
        public Role()
        {
        }

        //public Role(int currentRoleId)
        //{
        //    DataRow row = new Edge.Security.Data.Role().Retrieve(currentRoleId);
        //    this.roleId = currentRoleId;
        //    this.description = (string)row["Description"];
        //    Permission permission = new Permission();
        //    this.permissions = permission.GetPermissionList(currentRoleId);
        //    this.nopermissions = permission.GetNoPermissionList(currentRoleId);
        //}

        public Role(int currentRoleId,string lan)
        {
            DataRow row = new Edge.Security.Data.Role().Retrieve(currentRoleId,lan);
            this.roleId = currentRoleId;
            this.description = (string)row["Description"];
            Permission permission = new Permission();
            this.permissions = permission.GetPermissionList(currentRoleId,lan);
            this.nopermissions = permission.GetNoPermissionList(currentRoleId,lan);
        }

        public void AddPermission(int permissionId)
        {
            new Edge.Security.Data.Role().AddPermission(this.roleId, permissionId);
        }

        public void ClearPermissions()
        {
            new Edge.Security.Data.Role().ClearPermissions(this.roleId);
        }

        public int Create()
        {
            this.roleId = new Edge.Security.Data.Role().Create(this.description);
            return this.roleId;
        }

        public bool Delete()
        {
            Edge.Security.Data.Role role = new Edge.Security.Data.Role();
            return role.Delete(this.roleId);
        }

        public void RemovePermission(int permissionId)
        {
            new Edge.Security.Data.Role().RemovePermission(this.roleId, permissionId);
        }

        public bool Update()
        {
            Edge.Security.Data.Role role = new Edge.Security.Data.Role();
            return role.Update(this.roleId, this.description);
        }

        public bool HasRole(string roleName)
        {
            Edge.Security.Data.Role role = new Edge.Security.Data.Role();
            return role.HasRole(roleName);
        }

        // Properties
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public DataSet NoPermissions
        {
            get
            {
                return this.nopermissions;
            }
        }

        public DataSet Permissions
        {
            get
            {
                return this.permissions;
            }
        }

        public int RoleID
        {
            get
            {
                return this.roleId;
            }
        }
    }
}
