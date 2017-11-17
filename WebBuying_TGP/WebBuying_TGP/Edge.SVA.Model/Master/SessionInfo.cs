using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Edge.SVA.Model
{
    public class SessionInfo
    {
        public static string CardIssuersStr
        {
            get
            {
                if (HttpContext.Current.Session["Card__Issuers__Str"] != null)
                {
                    return HttpContext.Current.Session["Card__Issuers__Str"].ToString();
                }
                return string.Empty;
            }
            set { HttpContext.Current.Session["Card__Issuers__Str"] = value; }
        }
        public static string BrandIDsStr
        {
            get
            {
                if (HttpContext.Current.Session["Brand__ID__Str"] != null)
                {
                    return HttpContext.Current.Session["Brand__ID__Str"].ToString();
                }
                return string.Empty;
            }
            set { HttpContext.Current.Session["Brand__ID__Str"] = value; }
        }
        //public static string SiteLanguage
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["SiteLanguage"] != null)
        //        {
        //            return HttpContext.Current.Session["SiteLanguage"].ToString();
        //        }
        //        return "en-us";
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["SiteLanguage"] = value;
        //    }
        //}
        public static bool isStoreAdmin
        {
            get
            {
                if (HttpContext.Current.Session["isStoreAdmin"] != null)
                {
                    return bool.Parse(HttpContext.Current.Session["isStoreAdmin"].ToString());
                }
                return true;
            }
            set
            {
                HttpContext.Current.Session["isStoreAdmin"] = value;
            }
        }
    }
}
