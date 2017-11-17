using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edge.Web.Tools
{
    public class CustomMenu : CustomTree
    {
        private int orderID;
        private string description;
        private string location;
        private string url;
        private string imageurl;
        private int permissionID;
        private int moduleID;
        private int keShiDM;
        private string keshiPublic;

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

        public string Location
        {
            get{ return location; }
            set { location = value; }      
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Imageurl
        {
            get { return imageurl; }
            set {imageurl=value;}
        
        }

        public int PermissionID
        {
            get { return permissionID; }
            set { permissionID = value; }
        }

        public int ModuleID
        {
            get { return moduleID; }
            set { moduleID = value; }
        
        }

        public int KeShiDM
        {
            get { return keShiDM; }
            set { keShiDM = value; }
        
        }

        public string KeshiPublic
        {
            get { return keshiPublic; }
            set { keshiPublic = value; }

        }
    }
}