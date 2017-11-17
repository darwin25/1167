using System;
using System.Collections.Generic;
using System.Web;
using Edge.Security.Manager;
using System.Web.Caching;
using Edge.Common;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using Edge.Web.Controllers;
using System.Text;
using Edge.Utils;
using Edge.SVA.Model.Domain.WebService.Request;
using Edge.SVA.Model.Domain.WebService.Response;
using Edge.SVA.Model.Domain.Surpport;

namespace Edge.Web.Tools
{
    /// <summary>
    /// 数据访问工具
    /// </summary>
    public class DALTool
    {
        #region 根据ID，获取名称

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public static string GetUserName(int userId)
        {
            System.Data.DataRow user = new Edge.Security.Data.User().Retrieve(userId);

            return user == null ? "" : user["UserName"].ToString();
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public static string GetUserName(int userId, Dictionary<int, string> cache)
        {
            if (userId == int.MinValue) return "";

            if (cache != null && cache.ContainsKey(userId)) return cache[userId];

            System.Data.DataRow user = new Edge.Security.Data.User().Retrieve(userId);
            string result = user == null ? "" : user["UserName"].ToString();

            if (cache != null) cache.Add(userId, result);

            return result;
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <param name="siteLanguage"></param>
        /// <returns></returns>
        public static User GetCurrentUser()
        {
            Edge.Security.Model.WebSet set = HttpContext.Current.Cache["Cache_Webset"] as Edge.Security.Model.WebSet;
            if (set == null)
            {
                set = new Edge.Security.Manager.WebSet().loadConfig(Edge.Common.Utils.GetXmlMapPath("Configpath"));
            }

            if (SVASessionInfo.CurrentUser != null)
            {
                return SVASessionInfo.CurrentUser;
            }
            else
            {
                AccountsPrincipal user = new AccountsPrincipal(HttpContext.Current.User.Identity.Name, SVASessionInfo.SiteLanguage);//todo: 修改成多语言。
                User currentUser = new Edge.Security.Manager.User(user);

                return currentUser;            
            }
        }

        public static string GetApproveStatusString(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return string.Empty;
            }
            switch (status.ToUpper())
            {
                case "P": return "PENDING";
                case "A": return "APPROVED";
                case "V": return "VOID";
                default: return "";
            }
        }

        public static string GetDeliveryStatusString(string status)
        {
            if (string.IsNullOrEmpty(status))
            {
                return string.Empty;
            }
            switch (status.ToUpper())
            {
                case "P": return "PENDING";
                case "D": return "DELIVERED";
                default: return "";
            }
        }

        public static string GetOrderPickingApproveStatusString(string status)
        {
            switch (status.ToUpper())
            {
                case "R": return "PENDING";
                case "P": return "PICKED";
                case "A": return "APPROVED";
                case "V": return "VOID";
                default: return "";
            }
        }


        public static string GetProductModifyTempStatusString(string status)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (status)
                    {
                        case "-1": text = "-1：Void"; break;
                        case "0": text = "Pedding"; break;
                        case "1": text = "Approve"; break;
                        case "2": text = "Update"; break;
                    }
                    break;
                case "zh-cn":
                    switch (status)
                    {
                        case "-1": text = "-1：作废"; break;
                        case "0": text = "未审核"; break;
                        case "1": text = "已审核"; break;
                        case "2": text = "已经更新"; break;
                    }
                    break;
                case "zh-hk":
                    switch (status)
                    {
                        case "-1": text = "-1：作廢"; break;
                        case "0": text = "未稽核"; break;
                        case "1": text = "已稽核"; break;
                        case "2": text = "已經更新"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetProductModifyTempIsOnlineSKUString(string status)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (status)
                    {
                        case "0": text = "Disable"; break;
                        case "1": text = "Enable"; break;
                    }
                    break;
                case "zh-cn":
                    switch (status)
                    {
                        case "0": text = "下架"; break;
                        case "1": text = "上架"; break;
                    }
                    break;
                case "zh-hk":
                    switch (status)
                    {
                        case "0": text = "下架"; break;
                        case "1": text = "上架"; break;
                    }
                    break;
            }
            return text;
        }

        /// <summary>
        ///根据ID获取店铺编号，若存入id == int.MinValue 返回空
        /// </summary>
        /// <param name="id">店铺ID</param>
        /// <param name="cache">缓存已经读取的ID</param>
        /// <returns></returns>
        public static string GetStoreCode(int id, Dictionary<int, string> cache)
        {
            if (id == int.MinValue) return "";

            if (cache != null && cache.ContainsKey(id)) return cache[id];

            Edge.SVA.Model.Store model = new Edge.SVA.BLL.Store().GetModel(id);

            string result = model == null ? "" : model.StoreCode;

            if (cache != null) cache.Add(id, result.ToUpper());

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandID"></param>
        /// <param name="storeCode"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static int GetStoreIDByBrandIDAndStoreCode(string brandID,string storeCode, Dictionary<string, int> cache)
        {
            string key = brandID + "_"+storeCode;

            if (cache != null && cache.ContainsKey(key)) return cache[key];

            Edge.SVA.Model.Store model = null;
            List<Edge.SVA.Model.Store> list = new Edge.SVA.BLL.Store().GetModelList(string.Format(" BrandID='{0}' and StoreCode='{1}'", brandID,storeCode));
            if (list.Count>=1)
            {
                model = list[0];
            }
            else
            {
                return 0;
            }
            int result = model == null ? 0 : model.StoreID;

            if (cache != null) cache.Add(key, result);

            return result;
        }

        /// <summary>
        /// 根据StoreCode获取BrandID
        /// </summary>
        /// <param name="storeCode"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static int GetBrandIDByStoreCode(string storeCode, Dictionary<string, int> cache)
        {
            if (string.IsNullOrEmpty(storeCode)) return 0;

            if (cache != null && cache.ContainsKey(storeCode)) return Tools.ConvertTool.ToInt(cache[storeCode].ToString());

            
            List<Edge.SVA.Model.Store> list = new Edge.SVA.BLL.Store().GetModelList(string.Format("StoreCode='{0}'", storeCode));

            Edge.SVA.Model.Store model = null;

            if (list.Count > 0)
            {
                model = list[0];
            }
            else
            {
                return 0;
            }

            int result = model == null ? 0 : model.BrandID.GetValueOrDefault();

            if (cache != null) cache.Add(storeCode, result);

            return result;
        }
      
    
        /// <summary>
        ///根据ID获取区域名称，若存入id == int.MinValue 返回空
        /// </summary>
        /// <param name="id">品牌ID</param>
        /// <param name="cache">缓存已经读取的ID</param>
        /// <returns></returns>
        public static string GetLocationName(int id, Dictionary<int, string> cache)
        {
            if (id == int.MinValue) return "";

            if (cache != null && cache.ContainsKey(id)) return cache[id];

            Edge.SVA.BLL.StoreGroup bll = new Edge.SVA.BLL.StoreGroup();
            Edge.SVA.Model.StoreGroup model = bll.GetModel(id);

            string result = model == null ? "" : GetStringByCulture(model.StoreGroupName1, model.StoreGroupName2, model.StoreGroupName3);

            if (cache != null) cache.Add(id, result);

            return result;
        }
        /// <summary>
        /// 根据Id后获取物流供应名称，若存入id == int.MinValue 返回空
        /// 创建人：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static string GetLogisticsProviderName(int id, Dictionary<int, string> cache)
        {
            if (id == int.MinValue) return "";

            if (cache != null && cache.ContainsKey(id)) return cache[id];

            Edge.SVA.BLL.LogisticsProvider bll = new Edge.SVA.BLL.LogisticsProvider();
            Edge.SVA.Model.LogisticsProvider model = bll.GetModel(id);

            string result = model == null ? "" : GetStringByCulture(model.ProviderName1, model.ProviderName2, model.ProviderName3);

            if (cache != null) cache.Add(id, result);

            return result;
        }

        /// <summary>
        ///根据ID获取Store Name，若存入id == int.MinValue 返回空
        /// </summary>
        /// <param name="id">品牌ID</param>
        /// <param name="cache">缓存已经读取的ID</param>
        /// <returns></returns>
        public static string GetStoreName(int id, Dictionary<int, string> cache)
        {
            if (id == int.MinValue) return "";

            if (cache != null && cache.ContainsKey(id)) return cache[id];

            Edge.SVA.BLL.Store bll = new Edge.SVA.BLL.Store();
            Edge.SVA.Model.Store model = bll.GetModel(id);

            string result = model == null ? "" : GetStringByCulture(model.StoreName1, model.StoreName2, model.StoreName3);

            if (cache != null) cache.Add(id, result);

            return result;
        }

      
        public static string GetMessageTemplateCode(int id, Dictionary<int, string> cache)
        {
            if (id == int.MinValue) return "";

            if (cache != null && cache.ContainsKey(id)) return cache[id];

            Edge.SVA.BLL.MessageTemplate bll = new Edge.SVA.BLL.MessageTemplate();
            Edge.SVA.Model.MessageTemplate model = bll.GetModel(id);

            string result = model == null ? "" : model.MessageTemplateCode;

            if (cache != null) cache.Add(id, result);

            return result;
        }
      
        /// <summary>
        /// 根据联系方式类型ID，获取联系方式名称
        /// </summary>
        /// <param name="id">联系方式类型ID</param>
        /// <param name="cache">缓存已经读取的ID</param>
        /// <returns></returns>
        public static string GetSNSTypeName(int id, Dictionary<int, string> cache)
        {
            if (id == int.MinValue) return "";

            if (cache != null && cache.ContainsKey(id)) return cache[id];

            Edge.SVA.BLL.SNSType bll = new Edge.SVA.BLL.SNSType();
            Edge.SVA.Model.SNSType model = bll.GetModel(id);

            string result = model == null ? "" : GetStringByCulture(model.SNSTypeName1, model.SNSTypeName2, model.SNSTypeName3);

            if (cache != null) cache.Add(id, result);

            return result;
        }

        /// <summary>
        /// 绑定所有公司
        /// 创建人：Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        /// <returns></returns>
        public static List<Edge.SVA.Model.Company> GetAllCompany()
        {
            Edge.SVA.BLL.Company bll = new Edge.SVA.BLL.Company();
            List<Edge.SVA.Model.Company> modelList = bll.GetModelList("");
            foreach (Edge.SVA.Model.Company model in modelList)
            {
                model.CompanyName = model == null ? "" : model.CompanyName;
            }
            return modelList;
        }
        public static string GetPasswordFormatName(int format)
        {
            switch (format)
            {
                case 0: return "No Requirement";
                case 1: return "Numbers";
                case 2: return "Alphabets";
                case 3: return "Numbers + Alphabets";
                case 4: return "Numbers +Alphabets +Symbols";
                default: return "";
                
            }
        }
        #endregion

        #region GetObject Update Add Delete

        public static object GetObject<BLL>(object id) where BLL : new()
        {
            return DALTool.ExecuteMethod<BLL>("GetModel", new object[] { id });
        }

        public static bool Update<BLL>(object obj) where BLL : new()
        {
            if (obj == null) return false;
            object result = ExecuteMethod<BLL>("Update", new object[] { obj });
            if (result is bool) return (bool)result;

            return false;
        }

        public static bool Delete<BLL>(object id) where BLL : new()
        {
            if (id == null) return false;
            object result = ExecuteMethod<BLL>("Delete", new object[] { id });
            if (result is bool) return (bool)result;
            if (result is int) return (int)result > 0 ? true : false;


            return false;
        }

        public static int Add<BLL>(object obj) where BLL : new()
        {
            if (obj == null) return -1;
            object result = ExecuteMethod<BLL>("Add", new object[] { obj });

            if (result is int) return (int)result;
            if (result is bool) return (bool)result ? 1 : -1;
            if (result is Guid) return (Guid)result == Guid.Empty ? -1 : 1;

            return 0;
        }

        #endregion

        #region Common

        private static object ExecuteMethod<T>(string method, object[] parameters) where T : new()
        {

            T obj = new T();
            Type type = typeof(T);
            System.Reflection.MethodInfo mi = null;
            try
            {
                mi = type.GetMethod(method);
            }
            catch
            {
                if (mi == null)
                {
                    Type[] args = GetTypes(parameters);
                    mi = type.GetMethod(method, args);
                }
            }
            if (mi == null) return default(T);


            System.Reflection.ParameterInfo[] pis = mi.GetParameters();

            for (int i = 0; i < pis.Length; i++)
            {
                parameters[i] = Convert.ChangeType(parameters[i], pis[i].ParameterType);
            }
            return mi.Invoke(obj, parameters);
        }

        private static Type[] GetTypes(object[] args)
        {
            if (args == null) return Type.EmptyTypes;
            Type[] types = new Type[args.Length];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = args[i].GetType();
            }
            return types;
        }

        /// <summary>
        /// 根据当前语言区域获取各自语言
        /// </summary>
        /// <param name="en">英文</param>
        /// <param name="zhCN">简体中文</param>
        /// <param name="zhHK">繁体中文</param>
        /// <returns></returns>
        public static string GetStringByCulture(string name1, string name2, string name3)
        {
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us": return name1;
                case "zh-cn": return name2;
                case "zh-hk": return name3;
                default: return name1;
            }
        }

        #endregion

        #region Common Function
        public static int ExecSODEOD(int userID,out DateTime dt)
        {
            int rowEffect=0;
            int rtnVal = 0;
            dt = DateTime.Today;

            IDataParameter[] parameters = { 

                 new SqlParameter("@UserID", SqlDbType.Int) , 

                 new SqlParameter("@BusDate", SqlDbType.Date) 

             };
            parameters[0].Value = userID;
            parameters[1].Direction = ParameterDirection.Output;

            rtnVal=DBUtility.DbHelperSQL.RunProcedure("EOD",parameters,out rowEffect);
            if (parameters[1].Value != null)
            {
                DateTime.TryParse(parameters[1].Value.ToString(),out dt);
            }
            return rtnVal;
        }

        public static DataSet GetReceiveOrderHeader(string ShipmentOrderNumber)
        {
            IDataParameter[] parameters = { 

                 new SqlParameter("@ShipmentOrderNumber", SqlDbType.VarChar,64) 

             };
            parameters[0].Value = ShipmentOrderNumber;

            DataSet ds = DBUtility.DbHelperSQL.RunProcedure("GetReceiveOrderHeader", parameters, "ds");
            
            return ds;
        }

        public static string GetReceiveOrderHeaderByStoreOrderNumber(string  StoreOrderNumber)
        {
            string rtn = string.Empty;
            IDataParameter[] parameters = { 

                 new SqlParameter("@StoreOrderNumber", SqlDbType.VarChar,64) ,
                 new SqlParameter("@ReceiveOrderNumber", SqlDbType.VarChar,64) ,

             };
            parameters[0].Value = StoreOrderNumber;
            parameters[1].Direction = ParameterDirection.Output;

            DBUtility.DbHelperSQL.RunProcedure("GetReceiveOrderHeaderByStoreOrderNumber", parameters, "ds");

            if (parameters[1].Value != null)
            {
                rtn = parameters[1].Value.ToString();
            }
            return rtn;
        }

        public static void SODEODSetTime(string timestr)
        {
            int rowEffect = 0;
            int rtnVal = 0;

            IDataParameter[] parameters = { 
                                              
                 new SqlParameter("@jobname", SqlDbType.VarChar,50) , 
                 new SqlParameter("@sql", SqlDbType.NVarChar) , 
                 new SqlParameter("@servername", SqlDbType.NVarChar) , 
                 new SqlParameter("@dbname", SqlDbType.NVarChar) ,
                 new SqlParameter("@freqtype", SqlDbType.NVarChar) ,
                 new SqlParameter("@fsinterval", SqlDbType.Int) , 
                 new SqlParameter("@time", SqlDbType.NVarChar) , 


             };
            parameters[0].Value = "SODEOD ";
            parameters[1].Value = @"USE "+AppConfig.Singleton.DbName+@"
GO
Exec SODEOD ";
            parameters[2].Value = AppConfig.Singleton.ServerName;
            parameters[3].Value = AppConfig.Singleton.DbName;
            parameters[4].Value = "day ";
            parameters[5].Value = 1;
            parameters[6].Value = timestr;

            rtnVal = DBUtility.DbHelperSQL.RunProcedure("[master].[dbo].[CreateScheduleJob]", parameters, out rowEffect);
            //if (parameters[1].Value != null)
            //{
            //    DateTime.TryParse(parameters[1].Value.ToString(), out dt);
            //}
            //return rtnVal;
        }

        public static string GetREFNOCode(string code)
        {
            string rtn = string.Empty;

            IDataParameter[] parameters = { 

                 new SqlParameter("@CODE", SqlDbType.VarChar,6) , 

                 new SqlParameter("@REFNO", SqlDbType.NVarChar,50) 

             };
            parameters[0].Value = code;
            parameters[1].Direction = ParameterDirection.Output;

            DBUtility.DbHelperSQL.RunProcedure("GetRefNoString", parameters, "ds");
            if (parameters[1].Value != null)
            {
                rtn = parameters[1].Value.ToString();
            }
            return rtn;
        }

        public static string GetOrdCouponAdjustApproveCode(string couponAdjustNumber)
        {
            string rtn = string.Empty;

            Edge.SVA.BLL.Ord_CouponAdjust_H bll = new Edge.SVA.BLL.Ord_CouponAdjust_H();

            Edge.SVA.Model.Ord_CouponAdjust_H model = bll.GetModel(couponAdjustNumber);
            if (model != null)
            {
                rtn = model.ApprovalCode;
            }
            return rtn;
        }

        public static string GetBusinessDate()
        {
            string rtn = string.Empty;

            DataSet ds = DBUtility.DbHelperSQL.Query("SELECT TOP 1 BusDate from SODEOD where SOD=1 and EOD=0 ORDER BY BusDate DESC");
            if (ds.Tables.Count > 0)
            {
                try
                {
                    rtn = Convert.ToDateTime(ds.Tables[0].Rows[0]["BusDate"]).ToString("yyyy-MM-dd");
                }
                catch
                {
                    rtn = DateTime.Today.ToString("yyyy-MM-dd");
                }
            }
            else
            {
                rtn = DateTime.Today.ToString("yyyy-MM-dd");
            }
            return rtn;
        }

        public static string GetSystemDate()
        {
            return System.DateTime.Now.ToString("yyyy-MM-dd");

        }

        public static string GetSystemDateTime()
        {
            return System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }
        #endregion

        #region Checking Function
        public static bool isHasStoreCodeWithBrandID(string storecode, int brandID, int storeID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("StoreCode='" + storecode + "' and BrandID=" + brandID);
            if (storeID > 0)
            {
                sbWhere.Append(" and StoreID <> " + storeID);
            }
            int count = new Edge.SVA.BLL.Store().GetCountUnlimited(sbWhere.ToString());
            return count > 0;
        }

 
      
        /// <summary>
        /// 检查BrandCode是否存在，当brandID=0时是新增时用。
        /// </summary>
        /// <param name="brandCode"></param>
        /// <param name="brandID"></param>
        /// <returns></returns>
        public static bool isHasBrandCode(string brandCode, int brandID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append(" StoreBrandCode='" + brandCode + "' ");
            if (brandID > 0)
            {
                sbWhere.Append(" and StoreBrandID <> " + brandID);
            }
            int count = new Edge.SVA.BLL.Brand().GetRecordCount(sbWhere.ToString());
            return count > 0;
        }
        /// <summary>
        ///  检查EducationCode是否存在，当educationID=0时是新增时用。
        /// </summary>
        /// <param name="educationCode"></param>
        /// <param name="educationID"></param>
        /// <returns></returns>
        public static bool isHasEducationCode(string educationCode, int educationID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("EducationCode='" + educationCode + "'");
            if (educationID > 0)
            {
                sbWhere.Append(" and EducationID <> " + educationID);
            }

            int count = new Edge.SVA.BLL.Education().GetCount(sbWhere.ToString());
            return count > 0;
        }

        /// <summary>
        /// 检查NationCode是否存在，当nationID=0时是新增时用。
        /// </summary>
        /// <param name="nationCode"></param>
        /// <param name="nationID"></param>
        /// <returns></returns>
        public static bool isHasNationCode(string nationCode, int nationID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("NationCode='" + nationCode + "'");
            if (nationID >0)
            {
                sbWhere.Append(" and NationID <> " + nationID);
            }

            int count = new Edge.SVA.BLL.Nation().GetCount(sbWhere.ToString());
            return count > 0;
        }

        /// <summary>
        ///  检查ProfessionCode是否存在，当professionID=0时是新增时用。
        /// </summary>
        /// <param name="professionCode"></param>
        /// <param name="professionID"></param>
        /// <returns></returns>
        public static bool isHasProfessionCode(string professionCode, int professionID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("ProfessionCode='" + professionCode + "'");
            if (professionID >0)
            {
                sbWhere.Append(" and ProfessionID <> " + professionID);
            }

            int count = new Edge.SVA.BLL.Profession().GetCount(sbWhere.ToString());
            return count > 0;
        }

       
        /// <summary>
        ///  检查StoreTypeCode是否存在，当industryID=0时是新增时用。
        /// </summary>
        /// <param name="industryCode"></param>
        /// <param name="industryID"></param>
        /// <returns></returns>
        public static bool isHasStoreTypeCode(string storeTypeCode, int storeTypeID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("StoreTypeCode='" + storeTypeCode + "'");
            if (storeTypeID > 0)
            {
                sbWhere.Append(" and StoreTypeID <> " + storeTypeID);
            }

            int count = new Edge.SVA.BLL.StoreType().GetCount(sbWhere.ToString());
            return count > 0;
        }
      
        /// <summary>
        ///  检查PasswordSettingCode是否存在，当industryID=0时是新增时用。
        /// </summary>
        /// <param name="industryCode"></param>
        /// <param name="industryID"></param>
        /// <returns></returns>
        public static bool isHasPasswordRuleCode(string passwordRuleCode, int passwordRuleID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("PasswordRuleCode='" + passwordRuleCode + "'");
            if (passwordRuleID > 0)
            {
                sbWhere.Append(" and PasswordRuleID <> " + passwordRuleID);
            }

            int count = new Edge.SVA.BLL.PasswordRule().GetCount(sbWhere.ToString());
            return count > 0;
        }

        /// <summary>
        ///  检查ReasonCode是否存在，当reasonID=0时是新增时用。
        /// </summary>
        /// <param name="industryCode"></param>
        /// <param name="industryID"></param>
        /// <returns></returns>
        public static bool isHasReasonCode(string reasonCode, int reasonID)
        {
            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("ReasonCode='" + reasonCode + "'");
            if (reasonID > 0)
            {
                sbWhere.Append(" and ReasonID <> " + reasonID);
            }

            int count = new Edge.SVA.BLL.Reason().GetCount(sbWhere.ToString());
            return count > 0;
        }

     
        public static bool ExistsMsgTemplateCode(string code)
        {
            bool rtn = true;
            StringBuilder sb = new StringBuilder();
            sb.Append(" MessageTemplateCode='");
            sb.Append(code);
            sb.Append("'");
            int count = new Edge.SVA.BLL.MessageTemplate().GetRecordCount(sb.ToString());
            if (count>=1)
            {
                rtn = true;
            } 
            else
            {
                rtn = false;
            }
            return rtn;
        }
        /// <summary>
        /// 检查DistributeTemplateCode是否存在，当customerID=0时是新增时用。
        /// </summary>
        /// <param name="customerCode"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static bool isHasDistributeCode(string distributeCode, int distributeID)
        {

            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("DistributionCode='" + distributeCode + "'");
            if (distributeID > 0)
            {
                sbWhere.Append(" and DistributionID <> " + distributeID);
            }

            int count = new Edge.SVA.BLL.DistributeTemplate().GetCount(sbWhere.ToString());
            return count > 0;
        }



        /// <summary>
        /// 检查organizationCode是否存在，当customerID=0时是新增时用。
        /// </summary>
        /// <param name="organizationCode"></param>
        /// <param name="organizationID"></param>
        /// <returns></returns>
        public static bool isHasOrganizationCode(string organizationCode, int organizationID)
        {

            StringBuilder sbWhere = new StringBuilder();
            sbWhere.Append("OrganizationCode='" + organizationCode + "'");
            if (organizationID > 0)
            {
                sbWhere.Append(" and OrganizationID <> " + organizationID);
            }

            int count = new Edge.SVA.BLL.Organization().GetCount(sbWhere.ToString());
            return count > 0;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numMask">将要写入的Number Mask</param>
        /// <param name="numPattern">将要写入的Number Pattern</param>
        /// <param name="type">0: CardTypre. 1: Cardgrade 2:CouponType</param>
        /// <param name="typeID">@TypeID内容根据@Type的设置. 新增时，可以填写0</param>
        /// <returns></returns>
        public static bool CheckNumberMask(string numMask, string numPattern, int type, int typeID)
        {
            string rtn = string.Empty;

            IDataParameter[] parameters = { new SqlParameter("@Type", SqlDbType.Int) , // 0: CardTypre. 1: Cardgrade 2:CouponType
                                            new SqlParameter("@TypeID", SqlDbType.Int),// @TypeID内容根据@Type的设置. 新增时，可以填写0
                                            new SqlParameter("@NumMask", SqlDbType.VarChar,512), // 将要写入的Number Mask
                                            new SqlParameter("@NumPattern", SqlDbType.VarChar,512),// 将要写入的Number Pattern
                                             new SqlParameter("@ReturnTypeID", SqlDbType.Int)// 正常返回0，有冲突返回冲突的ID，同样根据@Type区分
                                          };
            parameters[0].Value = type;
            parameters[1].Value = typeID;
            parameters[2].Value = numMask;
            parameters[3].Value = numPattern;
            parameters[4].Direction = ParameterDirection.Output;

            int count = 0;
            int result = DBUtility.DbHelperSQL.RunProcedure("CheckNumberMask", parameters, out count);
            if (parameters[4].Value != null)
            {
                rtn = parameters[4].Value.ToString();
            }
            return rtn=="0";

        }
        #endregion

        

        #region WebBuying公用方法
        public static string GetBuyingStoreName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_STORE bll = new Edge.SVA.BLL.BUY_STORE();
            Edge.SVA.Model.BUY_STORE model = bll.GetModelList("StoreCode='" + code + "'").Count > 0 ? bll.GetModelList("StoreCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.StoreName1, model.StoreName2, model.StoreName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingStoreNameByID(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_STORE bll = new Edge.SVA.BLL.BUY_STORE();
            Edge.SVA.Model.BUY_STORE model = bll.GetModelList("StoreID='" + code + "'").Count > 0 ? bll.GetModelList("StoreID='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.StoreName1, model.StoreName2, model.StoreName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        /// <summary>
        /// 根据编号得到名称
        /// 创建人：Lisa
        /// 创建人：2016-1-2
        /// </summary>
        /// <param name="code"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static string GetBuyingStoreNameByStoreCode(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_STORE bll = new Edge.SVA.BLL.BUY_STORE();
            Edge.SVA.Model.BUY_STORE model = bll.GetModelList("StoreCode='" + code + "'").Count > 0 ? bll.GetModelList("StoreCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.StoreName1, model.StoreName2, model.StoreName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }


        public static string GetBuyingStoreGroupName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_STOREGROUP bll = new Edge.SVA.BLL.BUY_STOREGROUP();
            Edge.SVA.Model.BUY_STOREGROUP model = bll.GetModelList("StoreGroupCode='" + code + "'").Count > 0 ? bll.GetModelList("StoreGroupCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.StoreGroupName1, model.StoreGroupName2, model.StoreGroupName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingStoreGroupNameByID(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_STOREGROUP bll = new Edge.SVA.BLL.BUY_STOREGROUP();
            Edge.SVA.Model.BUY_STOREGROUP model = bll.GetModelList("StoreGroupID='" + code + "'").Count > 0 ? bll.GetModelList("StoreGroupID='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.StoreGroupName1, model.StoreGroupName2, model.StoreGroupName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingCurrencyName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_CURRENCY bll = new Edge.SVA.BLL.BUY_CURRENCY();
            Edge.SVA.Model.BUY_CURRENCY model = bll.GetModelList("CurrencyCode='" + code + "'").Count > 0 ? bll.GetModelList("CurrencyCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.CurrencyName1, model.CurrencyName2, model.CurrencyName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingVendorName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_VENDOR bll = new Edge.SVA.BLL.BUY_VENDOR();
            Edge.SVA.Model.BUY_VENDOR model = bll.GetModelList("VendorCode='" + code + "'").Count > 0 ? bll.GetModelList("VendorCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.VendorName1, model.VendorName2, model.VendorName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingVendorNameByID(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_VENDOR bll = new Edge.SVA.BLL.BUY_VENDOR();
            Edge.SVA.Model.BUY_VENDOR model = bll.GetModelList("VendorID='" + code + "'").Count > 0 ? bll.GetModelList("VendorID='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.VendorName1, model.VendorName2, model.VendorName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingProdName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
            Edge.SVA.Model.BUY_PRODUCT model = bll.GetModelList("ProdCode='" + code + "'").Count > 0 ? bll.GetModelList("ProdCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.ProdDesc1, model.ProdDesc2, model.ProdDesc3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingIMP_ProdName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.IMP_PRODUCT bll = new Edge.SVA.BLL.IMP_PRODUCT();
            Edge.SVA.Model.IMP_PRODUCT model = bll.GetModelList("INTERNAL_PRODUCT_CODE='" + code + "'").Count > 0 ? bll.GetModelList("INTERNAL_PRODUCT_CODE='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.ProductName1, model.ProductName2, model.ProductName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingProdDeptCode(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
            Edge.SVA.Model.BUY_PRODUCT model = bll.GetModelList("ProdCode='" + code + "'").Count > 0 ? bll.GetModelList("ProdCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.DepartCode, model.DepartCode, model.DepartCode);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingDepartName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_DEPARTMENT bll = new Edge.SVA.BLL.BUY_DEPARTMENT();
            Edge.SVA.Model.BUY_DEPARTMENT model = bll.GetModelList("DepartCode='" + code + "'").Count > 0 ? bll.GetModelList("DepartCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.DepartName1, model.DepartName2, model.DepartName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingRPriceTypeName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_RPRICETYPE bll = new Edge.SVA.BLL.BUY_RPRICETYPE();
            Edge.SVA.Model.BUY_RPRICETYPE model = bll.GetModelList("RPriceTypeCode='" + code + "'").Count > 0 ? bll.GetModelList("RPriceTypeCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.RPriceTypeName1, model.RPriceTypeName2, model.RPriceTypeName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }


        public static string GetBrandName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.Brand bll = new Edge.SVA.BLL.Brand();
            Edge.SVA.Model.Brand model = bll.GetModelList("StoreBrandCode='" + code + "'").Count > 0 ? bll.GetModelList("StoreBrandCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.StoreBrandName1, model.StoreBrandName2, model.StoreBrandName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingBrandName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_BRAND bll = new Edge.SVA.BLL.BUY_BRAND();
            Edge.SVA.Model.BUY_BRAND model = bll.GetModelList("BrandCode='" + code + "'").Count > 0 ? bll.GetModelList("BrandCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.BrandName1, model.BrandName2, model.BrandName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingProdTypeSizeName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_PRODUCTSIZE bll = new Edge.SVA.BLL.BUY_PRODUCTSIZE();
            Edge.SVA.Model.BUY_PRODUCTSIZE model = bll.GetModelList("ProductSizeCode='" + code + "'").Count > 0 ? bll.GetModelList("ProductSizeCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.ProductSizeName1, model.ProductSizeName2, model.ProductSizeName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingPickupLocation(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.Ord_SalesPickOrder_H bll = new Edge.SVA.BLL.Ord_SalesPickOrder_H();
            Edge.SVA.Model.Ord_SalesPickOrder_H model = bll.GetModel("SalesPickOrderNumber='" + code + "'");

            string result = model == null ? "" : model.PickupLocation;

            if (cache != null) cache.Add(code, result);

            return result;
        }

        #region Promotion表
        public static string GetHitTypeName(string HitTypeID)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (HitTypeID)
                    {
                        case "0": text = "No Hitting"; break;
                        case "1": text = "Quantity"; break;
                        case "2": text = "Amount"; break;
                    }
                    break;
                case "zh-cn":
                    switch (HitTypeID)
                    {
                        case "0": text = "无条件命中"; break;
                        case "1": text = "数量"; break;
                        case "2": text = "金额"; break;
                    }
                    break;
                case "zh-hk":
                    switch (HitTypeID)
                    {
                        case "0": text = "无条件命中"; break;
                        case "1": text = "数量"; break;
                        case "2": text = "金额"; break;
                    }
                    break;
                default:
                    switch (HitTypeID)
                    {
                        case "0": text = "No Hitting"; break;
                        case "1": text = "Quantity"; break;
                        case "2": text = "Amount"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetHitItemName(string HitItemID)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (HitItemID)
                    {
                        case "0": text = "No specific product, all product are involved in"; break;
                        case "1": text = "Any Product Together"; break;
                        case "2": text = "Any one product must be reach the quantity or amount"; break;
                        case "3": text = "Each product must be reach the quantity or amount"; break;
                        case "4": text = "Payment Type Condition"; break;
                    }
                    break;
                case "zh-cn":
                    switch (HitItemID)
                    {
                        case "0": text = "没有具体的货品条件，全场货品都参与"; break;
                        case "1": text = "任意货品合计"; break;
                        case "2": text = "任意一个单独货品满足数量或者金额"; break;
                        case "3": text = "每一个货品都需要满足数量或者金额"; break;
                        case "4": text = "支付类型条件"; break;
                    }
                    break;
                case "zh-hk":
                    switch (HitItemID)
                    {
                        case "0": text = "没有具体的货品条件，全场货品都参与"; break;
                        case "1": text = "任意货品合计"; break;
                        case "2": text = "任意一个单独货品满足数量或者金额"; break;
                        case "3": text = "每一个货品都需要满足数量或者金额"; break;
                        case "4": text = "支付类型条件"; break;
                    }
                    break;
                default:
                    switch (HitItemID)
                    {
                        case "0": text = "No specific product, all product are involved in"; break;
                        case "1": text = "Any Product Together"; break;
                        case "2": text = "Any one product must be reach the quantity or amount"; break;
                        case "3": text = "Each product must be reach the quantity or amount"; break;
                        case "4": text = "Payment Type Condition"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetLogicalOprName(string LogicalOprID)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (LogicalOprID)
                    {
                        case "0": text = "and"; break;
                        case "1": text = "or"; break;
                    }
                    break;
                case "zh-cn":
                    switch (LogicalOprID)
                    {
                        case "0": text = "和"; break;
                        case "1": text = "或"; break;
                    }
                    break;
                case "zh-hk":
                    switch (LogicalOprID)
                    {
                        case "0": text = "和"; break;
                        case "1": text = "或"; break;
                    }
                    break;
                default:
                    switch (LogicalOprID)
                    {
                        case "0": text = "and"; break;
                        case "1": text = "or"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetPromotionGiftTypeName(string GiftTypeID)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (GiftTypeID)
                    {
                        case "1": text = "Cash Return"; break;
                        case "2": text = "Point Return"; break;
                        case "3": text = "The Real Gift"; break;
                    }
                    break;
                case "zh-cn":
                    switch (GiftTypeID)
                    {
                        case "1": text = "现金返还"; break;
                        case "2": text = "积分返还"; break;
                        case "3": text = "实物赠送"; break;
                    }
                    break;
                case "zh-hk":
                    switch (GiftTypeID)
                    {
                        case "1": text = "現金返還"; break;
                        case "2": text = "積分返還"; break;
                        case "3": text = "實物贈送"; break;
                    }
                    break;
                default:
                    switch (GiftTypeID)
                    {
                        case "1": text = "Cash Return"; break;
                        case "2": text = "Point Return"; break;
                        case "3": text = "The Real Gift"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetPromotionDiscountOnName(string DiscountOnID)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (DiscountOnID)
                    {
                        case "0": text = "The discount of the hitting product or cash deduction"; break;
                        case "1": text = "The discount of the gift product or cash deduction"; break;
                        case "2": text = "All single achieve discounts or cash deduction"; break;
                    }
                    break;
                case "zh-cn":
                    switch (DiscountOnID)
                    {
                        case "0": text = "在命中货品上实现折扣或现金抵扣"; break;
                        case "1": text = "在礼品货品上实现折扣或现金抵扣"; break;
                        case "2": text = "全单实现折扣或现金抵扣"; break;
                    }
                    break;
                case "zh-hk":
                    switch (DiscountOnID)
                    {
                        case "1": text = "在命中貨品上實現折扣或現金抵扣"; break;
                        case "2": text = "在礼品貨品上實現折扣或現金抵扣"; break;
                        case "3": text = "全單實現折扣或現金抵扣"; break;
                    }
                    break;
                default:
                    switch (DiscountOnID)
                    {
                        case "0": text = "The discount of the hitting product or cash deduction"; break;
                        case "1": text = "The discount of the gift product or cash deduction"; break;
                        case "2": text = "All single achieve discounts or cash deduction"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetPromotionDiscountTypeName(string PromotionDiscountTypeID)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "Sales Amount"; break;
                        case "1": text = "Sales Discount"; break;
                        case "2": text = "Amount Which Sales Minus"; break;
                        case "3": text = "Discount Which Sales Minus"; break;
                    }
                    break;
                case "zh-cn":
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "销售金额"; break;
                        case "1": text = "销售折扣"; break;
                        case "2": text = "销售减去的金额"; break;
                        case "3": text = "销售减去的折扣"; break;
                    }
                    break;
                case "zh-hk":
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "銷售金額"; break;
                        case "1": text = "銷售折扣"; break;
                        case "2": text = "銷售減去的金額"; break;
                        case "3": text = "銷售減去的折扣"; break;
                    }
                    break;
                default:
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "Sales Amount"; break;
                        case "1": text = "Sales Discount"; break;
                        case "2": text = "Amount Which Sales Minus"; break;
                        case "3": text = "Discount Which Sales Minus"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetPromotionGiftItemName(string PromotionDiscountTypeID)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "No specific product condition, any product"; break;
                        case "1": text = "Any Product Together"; break;
                        case "2": text = "Either a single product together"; break;
                    }
                    break;
                case "zh-cn":
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "没有具体的货品条件，任何货品"; break;
                        case "1": text = "任意货品合计"; break;
                        case "2": text = "任意一个单独货品合计"; break;
                    }
                    break;
                case "zh-hk":
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "沒有具體的貨品條件，任何貨品"; break;
                        case "1": text = "任意貨品合計"; break;
                        case "2": text = "任意一個單獨貨品合計"; break;
                    }
                    break;
                default:
                    switch (PromotionDiscountTypeID)
                    {
                        case "0": text = "No specific product condition, any product"; break;
                        case "1": text = "Any Product Together"; break;
                        case "2": text = "Either a single product together"; break;
                    }
                    break;
            }
            return text;
        }


        /// <summary>
        /// 获取交易类型的名称
        /// 创建人：Lisa
        /// 创建时间：2016-1-2
        /// </summary>
        /// <param name="TransType"></param>
        /// <returns></returns>
        public static string GetTransTypeName(int TransType)
        {
            string text = "";
            switch (TransType)
            {
                case 0:
                    text = "Normal Sales";
                    break;
                case 1:
                    text = "Advance Sales";
                    break;
                case 2:
                    text = "Deposit Sales";
                    break;
                case 3:
                    text = "Remote Collection";
                    break;
                case 4:
                    text = "Void";
                    break;
                case 5:
                    text = "Refund";
                    break;
                case 6:
                    text = "Exchange";
                    break;

            }
            return text;
        }
        /// <summary>
        /// 根据交易状态ID查询交易名称
        /// 创建者：王丽
        /// 创建时间：2016-1-2
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetStatusName(int status)
        {
            string StatusName = "";
            switch (status)
            {
                case 0:
                    StatusName = "购物车";
                    break;
                case 1:
                    StatusName = "暂存";
                    break;
                case 2:
                    StatusName = "取消";
                    break;
                case 3:
                    StatusName = "未确认支付";
                    break;
                case 4:
                    StatusName = "已付款未提货";
                    break;
                case 5:
                    StatusName = "交易完成";
                    break;
                case 6:
                    StatusName = "交付运送";
                    break;
                case 8:
                    StatusName = "拒收";
                    break;
                case 9:
                    StatusName = "已延迟";
                    break;
            }
            return StatusName;
        }

         /// <summary>
         /// 根据身省份编号获得省份名字
         /// 创建人：Lisa
         /// 创建时间：2015-12-31
         /// </summary>
         /// <param name="code"></param>
         /// <param name="cache"></param>
         /// <returns></returns>
        public static string GetProviceName(string ProvinceCode, Dictionary<string, string> cache)
        {
            if (ProvinceCode == string.Empty) return "";

            if (ProvinceCode == "-1") return "--";

            if (cache != null && cache.ContainsKey(ProvinceCode)) return cache[ProvinceCode];

            Edge.SVA.BLL.Province bll = new Edge.SVA.BLL.Province();
            Edge.SVA.Model.Province model = bll.GetModelList("ProvinceCode='" + ProvinceCode + "'").Count > 0 ? bll.GetModelList("ProvinceCode='" + ProvinceCode + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.ProvinceName1, model.ProvinceName2, model.ProvinceName3);

            if (cache != null) cache.Add(ProvinceCode, result);

            return result;
        }

        public static string GetLoyaltyBirthdayFlagName(string LoyaltyBirthdayFlag)
        {
            string text = "";
            switch (System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower())
            {
                case "en-us":
                    switch (LoyaltyBirthdayFlag)
                    {
                        case "0": text = "Not Birthday Promotion"; break;
                        case "1": text = "Member Birthday"; break;
                        case "2": text = "Member Birthday Week"; break;
                        case "3": text = "Member Birthday Month"; break;
                    }
                    break;
                case "zh-cn":
                    switch (LoyaltyBirthdayFlag)
                    {
                        case "0": text = "不是生日促销"; break;
                        case "1": text = "会员生日当日"; break;
                        case "2": text = "会员生日当周"; break;
                        case "3": text = "会员生日当月"; break;
                    }
                    break;
                case "zh-hk":
                    switch (LoyaltyBirthdayFlag)
                    {
                        case "0": text = "不是生日促销"; break;
                        case "1": text = "会员生日当日"; break;
                        case "2": text = "会员生日当周"; break;
                        case "3": text = "会员生日当月"; break;
                    }
                    break;
                default:
                    switch (LoyaltyBirthdayFlag)
                    {
                        case "0": text = "Not Birthday Promotion"; break;
                        case "1": text = "Member Birthday"; break;
                        case "2": text = "Member Birthday Week"; break;
                        case "3": text = "Member Birthday Month"; break;
                    }
                    break;
            }
            return text;
        }

        public static string GetCardTypeNameFromSVA(string CardTypeID)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            CardTypeInfoRequest request = new CardTypeInfoRequest();
            request.ConditionStr = "CardTypeID='" + CardTypeID + "'";
            CardTypes[] ris = rpu.GetCardTypeInfo(request, SVASessionInfo.SiteLanguage);
            if (ris.Length == 0) return "";
            return ris[0].CardTypeName;
        }

        public static string GetCardGradeNameFromSVA(string CardGradeID)
        {
            ResetPasswordUtil rpu = new ResetPasswordUtil();
            CardGradeInfoRequest request = new CardGradeInfoRequest();
            request.ConditionStr = "CardGradeID='" + CardGradeID + "'";
            CardGrades[] ris = rpu.GetCardGradeInfo(request, SVASessionInfo.SiteLanguage);
            if (ris.Length == 0) return "";
            return ris[0].CardGradeName;
        }
        #endregion


        public static string GetBuyingBankName(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_BANK bll = new Edge.SVA.BLL.BUY_BANK();
            Edge.SVA.Model.BUY_BANK model = bll.GetModelList("BankCode='" + code + "'").Count > 0 ? bll.GetModelList("BankCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.BankName1, model.BankName2, model.BankName3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingProdDesc(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_PRODUCT bll = new Edge.SVA.BLL.BUY_PRODUCT();
            Edge.SVA.Model.BUY_PRODUCT model = bll.GetModelList("ProdCode='" + code + "'").Count > 0 ? bll.GetModelList("ProdCode='" + code + "'")[0] : null;

            string result = model == null ? "" : GetStringByCulture(model.ProdDesc1, model.ProdDesc2, model.ProdDesc3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        public static string GetBuyingReasonDesc(string code, Dictionary<string, string> cache)
        {
            if (code == string.Empty) return "";

            if (code == "-1") return "--";

            if (cache != null && cache.ContainsKey(code)) return cache[code];

            Edge.SVA.BLL.BUY_REASON bll = new Edge.SVA.BLL.BUY_REASON();
            Edge.SVA.Model.BUY_REASON model = bll.GetModelList("ReasonID=" + code).Count > 0 ? bll.GetModelList("ReasonID=" + code)[0] : null;

           string result = model == null ? "" : GetStringByCulture(model.Description1, model.Description2, model.Description3);

            if (cache != null) cache.Add(code, result);

            return result;
        }

        /// <summary>
        /// 绑定所有季节
        /// 创建人：Lisa
        /// 创建时间：2016-02-26
        /// </summary>
        /// <returns></returns>
        public static List<Edge.SVA.Model.SEASON> GetAllSEASON()
        {
            Edge.SVA.BLL.SEASON bll = new Edge.SVA.BLL.SEASON();
            List<Edge.SVA.Model.SEASON> modelList = bll.GetModelList("");
            foreach (Edge.SVA.Model.SEASON model in modelList)
            {
                model.SeasonName1 = model == null ? "" : GetStringByCulture(model.SeasonName1, model.SeasonName2, model.SeasonName3);
            }
            return modelList;
        }

        public static List<Edge.SVA.Model.BUY_VENDOR> GetAllSupplier()
        {
            Edge.SVA.BLL.BUY_VENDOR bll = new Edge.SVA.BLL.BUY_VENDOR();
            List<Edge.SVA.Model.BUY_VENDOR> modelList = bll.GetModelList("");
            foreach (Edge.SVA.Model.BUY_VENDOR model in modelList)
            {
                model.VendorName1 = model == null ? "" : GetStringByCulture(model.VendorName1, model.VendorName2, model.VendorName3);
            }
            return modelList;
        }

        /// <summary>
        /// 物流供应商
        /// 创建人：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        /// <returns></returns>
        public static List<Edge.SVA.Model.LogisticsProvider> GetAllLogisticsProvider()
        {
            Edge.SVA.BLL.LogisticsProvider bll = new Edge.SVA.BLL.LogisticsProvider();
            List<Edge.SVA.Model.LogisticsProvider> modelList = bll.GetModelList("");
            foreach (Edge.SVA.Model.LogisticsProvider model in modelList)
            {
                model.ProviderName1 = model == null ? "" : GetStringByCulture(model.ProviderName1, model.ProviderName2, model.ProviderName3);
            }
            return modelList;
        }

        /// <summary>
        /// 查询所有的省
        /// 创建人：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        /// <returns></returns>
        public static List<Edge.SVA.Model.Province> GetAllProvice()
        {
            Edge.SVA.BLL.Province bll = new Edge.SVA.BLL.Province();
            List<Edge.SVA.Model.Province> modelList = bll.GetModelList("");
            foreach (Edge.SVA.Model.Province model in modelList)
            {
                model.ProvinceName1 = model == null ? "" : GetStringByCulture(model.ProvinceName1, model.ProvinceName2, model.ProvinceName3);
            }
            return modelList;
        }
        /// <summary>
        /// 查询所有的的自动补货公式信息
        /// 创建人：lisa
        /// 创建时间：2016-07-14
        /// </summary>
        /// <returns></returns>
        public static List<Edge.SVA.Model.BUY_REPLENFORMULA> GetAllREPLENFORMULA()
        {
            Edge.SVA.BLL.BUY_REPLENFORMULA bll = new Edge.SVA.BLL.BUY_REPLENFORMULA();
            List<Edge.SVA.Model.BUY_REPLENFORMULA> modelList = bll.GetModelList("");
            foreach (Edge.SVA.Model.BUY_REPLENFORMULA model in modelList)
            {
                model.ReplenFormulaCode = model == null ? "" : model.ReplenFormulaCode;
            }
            return modelList;
        }

        public static int GetPickingOrderQTYByNumberProdCode(string PickingOrderNumber,string ProdCode)
        {
            string strQuery = "select sum(orderqty) orderqty from ord_pickingorder_d where PickingOrderNumber = '" + PickingOrderNumber + "' and ProdCode = '" + ProdCode + " '";

            DataSet ds = Edge.DBUtility.DbHelperSQL.Query(strQuery);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int status = Tools.ConvertTool.ToInt(ds.Tables[0].Rows[0]["orderqty"].ToString());
                return status;
            }
            else
            {
                return 0;
            }
        }

        #endregion



    }
}
