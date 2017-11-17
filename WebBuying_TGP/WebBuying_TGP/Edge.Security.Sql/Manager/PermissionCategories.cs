using System;
using System.Collections.Generic;
using System.Text;
using Edge.Security.Data;
using System.Data;

namespace Edge.Security.Manager
{
    public class PermissionCategories
    {
        // Methods
        public int Create(string description,int parentID,int orderID)
        {
            PermissionCategory category = new PermissionCategory();
            return category.Create(description, parentID,orderID);
        }


        public int Update(int categoryID, string description, int parentID, int orderID)
        {
            PermissionCategory category = new PermissionCategory();
            return category.Update(categoryID,description, parentID, orderID);
        }

        public bool Delete(int pID)
        {
            PermissionCategory category = new PermissionCategory();
            return category.Delete(pID);
        }


        public DataRow GetPermissionCategoriesDetails(int categoryId)
        {
            PermissionCategory category = new PermissionCategory();
            return category.Retrieve(categoryId);
        }
    }
}
