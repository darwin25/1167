using System;
using System.Collections.Generic;
using System.Text;
using Edge.Security.Data;

namespace Edge.Security.Manager
{
    public class Permissions
    {
        // Methods
        public int Create(int pcID, string description)
        {
            Permission permission = new Permission();
            return permission.Create(pcID, description);
        }

        public bool Delete(int pID)
        {
            Permission permission = new Permission();
            return permission.Delete(pID);
        }

        public string GetPermissionName(int pID)
        {
            Permission permission = new Permission();
            return permission.Retrieve(pID)["Description"].ToString();
        }

        public bool Update(int pcID, string description)
        {
            Permission permission = new Permission();
            return permission.Update(pcID, description);
        }
    }
}
