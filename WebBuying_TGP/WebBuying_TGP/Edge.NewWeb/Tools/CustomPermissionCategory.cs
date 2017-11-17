using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.Security.Manager;

namespace Edge.Web.Tools
{
    public class CustomPermissionCategory : CustomTree
    {
        private int orderID;
        private string description;


        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}