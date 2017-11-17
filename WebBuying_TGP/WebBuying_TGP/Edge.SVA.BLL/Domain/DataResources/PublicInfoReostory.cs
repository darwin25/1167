using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model.Domain.SVA;
using System.Data;
using Edge.SVA.Model.Domain;

namespace Edge.SVA.BLL.Domain.DataResources
{
    public class PublicInfoReostory
    {
        private static readonly object syncObj = new object();
        private static readonly PublicInfoReostory instance = new PublicInfoReostory();
        private PublicInfoReostory()
        {
            //LoadDataFromDB();
        }
        public static PublicInfoReostory Singleton
        {
            get
            {
                return instance;
            }
        }
        private List<BrandInfo> brandList_en_us = new List<BrandInfo>();
        private List<BrandInfo> brandList_zh_cn = new List<BrandInfo>();
        private List<BrandInfo> brandList_zh_hk = new List<BrandInfo>();



        public List<BrandInfo> GetBrandInfoList(string lan)
        {
            List<BrandInfo> list = new List<BrandInfo>();
            switch (lan.ToLower())
            {
                case "en-us":
                    list = brandList_en_us;
                    break;
                case "zh-cn":
                    list = brandList_zh_cn;
                    break;
                case "zh-hk":
                    list = brandList_zh_hk;
                    break;
                default:
                    list = brandList_en_us;
                    break;
            }
            return list;
        }
        public List<BrandInfo> GetBrandInfoList(string username, string lan)
        {
            List<BrandInfo> brandInfoList = new List<BrandInfo>();
            //            DataSet ds = DBUtility.DbHelperSQL.Query(@"SELECT     isNull(Buy_Brand.BrandID,0) BrandID, Buy_Brand.BrandCode, Buy_Brand.BrandName1, Buy_Brand.BrandName2, Buy_Brand.BrandName3, Buy_Store.StoreID, Buy_Store.StoreCode, 
            //                        Buy_Store.StoreName1, Buy_Store.StoreName2, Buy_Store.StoreName3
            //                        FROM         Buy_Store INNER JOIN
            //                        RelationUserStore ON Buy_Store.StoreID = RelationUserStore.StoreID FULL JOIN
            //                        Buy_Brand ON Buy_Store.BrandCode = Buy_Brand.BrandCode where RelationUserStore.UserName='" + username + "' order by Buy_Brand.BrandCode asc,Buy_Store.StoreCode asc");
            DataSet ds = DBUtility.DbHelperSQL.Query(@"SELECT isNull(Buy_Brand.BrandID,0) BrandID, Buy_Brand.BrandCode, Buy_Brand.BrandName1, Buy_Brand.BrandName2, Buy_Brand.BrandName3, Buy_Store.StoreID, Buy_Store.StoreCode, 
                        Buy_Store.StoreName1, Buy_Store.StoreName2, Buy_Store.StoreName3
                        FROM         Buy_Store INNER JOIN
                        RelationUserStore ON Buy_Store.StoreID = RelationUserStore.StoreID ,Buy_Brand 
                        where RelationUserStore.UserName='" + username + "' order by Buy_Brand.BrandCode asc,Buy_Store.StoreCode asc");
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                switch (lan.ToLower())
                {
                    case "zh-cn":
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "BrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "BrandCode") + "-" + GetColumnValue(item, "BrandName2");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName2");
                            bi.StoreInfos.Add(si);
                        }
                        break;
                    case "zh-hk":
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "BrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "BrandCode") + "-" + GetColumnValue(item, "BrandName3");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName3");
                            bi.StoreInfos.Add(si);
                        }
                        break;
                    case "en-us":
                    default:
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "BrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "BrandCode") + "-" + GetColumnValue(item, "BrandName1");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName1");
                            bi.StoreInfos.Add(si);
                        }
                        break;
                }

            }
            return brandInfoList;
        }
        public List<BrandInfo> GetAllBrandInfoList(string lan)
        {
            List<BrandInfo> brandInfoList = new List<BrandInfo>();
            //            DataSet ds = DBUtility.DbHelperSQL.Query(@"SELECT distinct * FROM (SELECT TOP (100) PERCENT isnull(dbo.BUY_BRAND.BrandID,0) BrandID, isnull(dbo.BUY_BRAND.BrandCode,'') BrandCode, isnull(dbo.BUY_BRAND.BrandName1,'') BrandName1, isnull(dbo.BUY_BRAND.BrandName2,'') BrandName2, isnull(dbo.BUY_BRAND.BrandName3,'') BrandName3, dbo.BUY_STORE.StoreID, 
            //                        dbo.BUY_STORE.StoreCode, dbo.BUY_STORE.StoreName1, dbo.BUY_STORE.StoreName2, dbo.BUY_STORE.StoreName3
            //                        FROM         dbo.BUY_BRAND, dbo.BUY_STORE 
            //                        ORDER BY dbo.BUY_BRAND.BrandCode, dbo.BUY_STORE.StoreCode) Temp");
            DataSet ds = DBUtility.DbHelperSQL.Query(@"SELECT distinct * FROM (SELECT TOP (100) PERCENT isnull(dbo.Brand.StoreBrandID,0) BrandID, isnull(dbo.Brand.StoreBrandCode,'') BrandCode, 
isnull(dbo.Brand.StoreBrandName1,'') BrandName1, 
isnull(dbo.Brand.StoreBrandName2,'') BrandName2, isnull(dbo.Brand.StoreBrandName3,'') BrandName3, dbo.BUY_STORE.StoreID, 
dbo.BUY_STORE.StoreCode, dbo.BUY_STORE.StoreName1, dbo.BUY_STORE.StoreName2, dbo.BUY_STORE.StoreName3
FROM         dbo.brand, dbo.BUY_STORE 
ORDER BY dbo.brand.StoreBrandCode, dbo.BUY_STORE.StoreCode) Temp");
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                switch (lan.ToLower())
                {
                    case "zh-cn":
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "BrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "BrandCode") + "-" + GetColumnValue(item, "BrandName2");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            if (si.Key.Length > 0)
                            {
                                si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName2");
                                bi.StoreInfos.Add(si);
                            }
                        }
                        break;
                    case "zh-hk":
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "BrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "BrandCode") + "-" + GetColumnValue(item, "BrandName3");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            if (si.Key.Length > 0)
                            {
                                si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName3");
                                bi.StoreInfos.Add(si);
                            }

                        }
                        break;
                    case "en-us":
                    default:
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "BrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "BrandCode") + "-" + GetColumnValue(item, "BrandName1");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            if (si.Key.Length > 0)
                            {
                                si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName1");
                                bi.StoreInfos.Add(si);
                            }
                        }
                        break;
                }

            }
            return brandInfoList;
        }

        public List<BrandInfo> GetBrandInfoListByBrandUserID(int userid, string lan)
        {
         

            List<BrandInfo> brandInfoList = new List<BrandInfo>();
//            DataSet ds = DBUtility.DbHelperSQL.Query(@"SELECT distinct * FROM (SELECT TOP (100) PERCENT dbo.Buy_Brand.BrandID, dbo.Buy_Brand.BrandCode, dbo.Buy_Brand.BrandName1, dbo.Buy_Brand.BrandName2, dbo.Buy_Brand.BrandName3, dbo.Buy_Store.StoreID, 
//                        dbo.Buy_Store.StoreCode, dbo.Buy_Store.StoreName1, dbo.Buy_Store.StoreName2, dbo.Buy_Store.StoreName3
//                        FROM         dbo.Buy_Brand INNER JOIN
//                        dbo.RelationRoleBrand ON dbo.Buy_Brand.BrandID = dbo.RelationRoleBrand.BrandID, Buy_Store 
//                        WHERE     (dbo.RelationRoleBrand.RoleID = " + userid.ToString() + @")
//                        ORDER BY dbo.Buy_Brand.BrandCode, dbo.Buy_Store.StoreCode)TEMP");

            DataSet ds = DBUtility.DbHelperSQL.Query(@"SELECT distinct * FROM (SELECT TOP (100) PERCENT dbo.Brand.StoreBrandID, dbo.Brand.StoreBrandCode, dbo.Brand.StoreBrandName1, dbo.Brand.StoreBrandName2, dbo.Brand.StoreBrandName3, dbo.Buy_Store.StoreID, 
                        dbo.Buy_Store.StoreCode, dbo.Buy_Store.StoreName1, dbo.Buy_Store.StoreName2, dbo.Buy_Store.StoreName3
                        FROM         dbo.Brand INNER JOIN
                        dbo.RelationRoleBrand ON dbo.Brand.StoreBrandID = dbo.RelationRoleBrand.BrandID, Buy_Store 
                        WHERE     (dbo.RelationRoleBrand.RoleID = " + userid.ToString() + @")
                        ORDER BY dbo.Brand.StoreBrandCode, dbo.Buy_Store.StoreCode)TEMP");
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                switch (lan.ToLower())
                {
                    case "zh-cn":
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "StoreBrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "StoreBrandCode") + "-" + GetColumnValue(item, "StoreBrandName2");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            if (si.Key.Length > 0)
                            {
                                si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName2");
                                bi.StoreInfos.Add(si);
                            }
                        }
                        break;
                    case "zh-hk":
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "StoreBrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "StoreBrandCode") + "-" + GetColumnValue(item, "StoreBrandName3");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreBrandID");
                            if (si.Key.Length > 0)
                            {
                                si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName3");
                                bi.StoreInfos.Add(si);
                            }

                        }
                        break;
                    case "en-us":
                    default:
                        foreach (DataRow item in dt.Rows)
                        {
                            string brandid = GetColumnValue(item, "StoreBrandID");

                            BrandInfo bi = brandInfoList.Find(m => m.Key == brandid);
                            if (bi == null)
                            {
                                bi = new BrandInfo();
                                bi.Key = brandid;
                                bi.Value = GetColumnValue(item, "StoreBrandCode") + "-" + GetColumnValue(item, "StoreBrandName1");
                                brandInfoList.Add(bi);
                            }
                            StoreInfo si = new StoreInfo();
                            si.Key = GetColumnValue(item, "StoreID");
                            if (si.Key.Length > 0)
                            {
                                si.Value = GetColumnValue(item, "StoreCode") + "-" + GetColumnValue(item, "StoreName1");
                                bi.StoreInfos.Add(si);
                            }
                        }
                        break;
                }

            }
            return brandInfoList;
        }




        //Add By Robin 2015-08-06
        public List<string> GetEmployeeList(int userid)
        {
            List<string> employeeList = new List<string>();
            DataSet ds = DBUtility.DbHelperSQL.Query(@"SELECT SubUserID  FROM Accounts_UsersRelation where UserID=" + userid);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    employeeList.Add(item["SubUserID"].ToString());
                }
            }
            return employeeList;
        }
        //

        private static string GetColumnValue(DataRow item, string name)
        {
            if (item[name] == null)
            {
                return string.Empty;
            }
            return item[name].ToString();
        }
        public void Refresh()
        {
            //LoadDataFromDB();
        }
    }
}
