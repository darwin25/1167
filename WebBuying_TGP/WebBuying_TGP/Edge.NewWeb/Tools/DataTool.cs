using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Edge.SVA.Model.Domain;
using Edge.SVA.BLL.Domain.DataResources;
using Edge.SVA.Model.Domain.Surpport;
using Edge.SVA.Model.Domain.SVA;

namespace Edge.Web.Tools
{
    public class DataTool
    {


        internal static void AddMessageType(DataSet ds, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn("MessageTypeDesc", typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row["MessageTypeDesc"] = ((Edge.SVA.Model.Domain.EnumMessageType)id).ToString();
            }
        }
        internal static void AddMessageServiceType(DataSet ds, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn("MessageServiceType", typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row["MessageServiceType"] = ((Edge.SVA.Model.Domain.EnumMessageServiceType)id).ToString();
            }
        }

        /// <summary>
        /// 在DataSet中Table增加品牌描述
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">品牌ID</param>
        internal static void AddBrandInfoDesc(DataSet ds, string name, string refKey)
        {
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            List<BrandInfo> brandInfoList = PublicInfoReostory.Singleton.GetAllBrandInfoList(SVASessionInfo.SiteLanguage);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[refKey] != null)
                {
                    BrandInfo bi = brandInfoList.Find(m => m.Key == row[refKey].ToString());
                    if (bi != null)
                    {
                        row[name] = bi.Value;
                    }
                    else
                    {
                        row[name] = string.Empty;
                    }
                }
                else
                {
                    row[name] = string.Empty;
                }
            }
        }
        /// <summary>
        /// 在DataSet中Table增加交易类型
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">品牌ID</param>
        internal static void AddTransactionTypeDesc(DataSet ds, string name, string refKey)
        {
            string id = string.Empty;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[refKey] != null)
                {
                    id = row[refKey].ToString();
                    KeyValue kv = TransactionTypeRepostory.Singleton.GetTransactionTypeList(SVASessionInfo.SiteLanguage).Find(mm => mm.Key == id.ToString());
                    if (kv != null)
                    {
                        row[name] = kv.Value;
                    }
                    else
                    {
                        row[name] = string.Empty;

                    }
                }
                else
                {
                    row[name] = string.Empty;
                }
            }
        }

        /// <summary>
        /// 在DataSet中Table增加区域名称
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">区域ID</param>
        internal static void AddLocationName(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row[name] = Edge.Web.Tools.DALTool.GetLocationName(id, cache);
            }
        }

        /// <summary>
        /// 在DataSet中Table增加物流名称
        /// 创建人：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <param name="refKey"></param>
        internal static void AddLogisticsProviderName(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row[name] = Edge.Web.Tools.DALTool.GetLogisticsProviderName(id, cache);
            }
        }

        /// <summary>
        /// 在DataSet中Table增加店铺编号
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">店铺ID</param>
        internal static void AddStoreCode(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row[name] = Edge.Web.Tools.DALTool.GetStoreCode(id, cache);
            }
        }

        /// <summary>
        /// 在DataSet中Table增加Store Name
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">品牌ID</param>
        internal static void AddStoreName(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row[name] = Edge.Web.Tools.DALTool.GetStoreName(id, cache);
            }
        }

        internal static void AddMessageTemplateCode(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row[name] = Edge.Web.Tools.DALTool.GetMessageTemplateCode(id, cache);
            }
        }
        /// <summary>
        /// 转换 数字到 EnumFrequencyUnit的说明
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">FrequencyUnit</param>
        internal static void AddFrequencyUnitName(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;

                row[name] = ((EnumFrequencyUnit)id).ToString();
            }
        }
        /// <summary>
        /// 转换0 1 到 否 是
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">优惠劵ID</param>
        internal static void AddBooleanName(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                if (id == 0)
                {
                    row[name] = "No";
                }
                else
                {
                    row[name] = "Yes";
                }
            }
        }

        /// <summary>
        /// 在DataSet中Table增加联系方式类型名称
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">联系方式类型ID</param>
        internal static void AddSNSTypeName(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row[name] = Edge.Web.Tools.DALTool.GetSNSTypeName(id, cache);
            }
        }

        internal static void AddUserName(DataSet ds, string newColumn, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(newColumn, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                row[newColumn] = Edge.Web.Tools.DALTool.GetUserName(id, cache);
            }
        }


        /// <summary>
        /// 在DataSet中Table增加兑换方式类型名称
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">兑换类型ID</param>
        internal static void AddExchangeType(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                switch (id)
                {
                    //case 1: row[name] = "金额兑换"; break;
                    //case 2: row[name] = "积分兑换"; break;
                    //case 3: row[name] = "金额+积分兑换"; break;
                    //case 4: row[name] = "优惠券兑换"; break;
                    //case 5: row[name] = "消费金额兑换"; break;

                    case 1: row[name] = Resources.MessageTips.CashExchange; break;
                    case 2: row[name] = Resources.MessageTips.PointExchange; break;
                    case 3: row[name] = Resources.MessageTips.CashAndPointExchange; break;
                    case 4: row[name] = Resources.MessageTips.CouponExchange; break;
                    case 5: row[name] = Resources.MessageTips.RedeemedAmountExchange; break;
                }

            }
        }


        /// <summary>
        /// 在DataSet中Table增加状态
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <param name="name">列名称</param>
        /// <param name="refKey">状态ID</param>
        internal static void AddStatus(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                switch (id)
                {
                    //case 0: row[name] = "Invalid"; break;
                    //case 1: row[name] = "Valid"; break;

                    case 0: row[name] = Resources.MessageTips.Inactive; break;
                    case 1: row[name] = Resources.MessageTips.Active; break;
                }

            }
        }

        internal static void AddIsActivated(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                switch (id)
                {
                    case 0: row[name] = Resources.MessageTips.Inactivated; break;
                    case 1: row[name] = Resources.MessageTips.Activated; break;
                }

            }
        }


        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <param name="refKey"></param>
        internal static void AddSex(DataSet ds, string name, string refKey)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                switch (id)
                {
                    case 0: row[name] = Resources.MessageTips.Female; break;
                    case 1: row[name] = Resources.MessageTips.Male; break;
                }

            }
        }

        /// <summary>
        /// 加上CouponStatus
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <param name="refKey"></param>
        internal static void AddDateFormat(DataSet ds, string name, string refKey)
        {
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row[name] = Tools.ConvertTool.ConverType<DateTime>(row[refKey].ToString()).ToString("yyyy-MM-dd");
            }
        }
        internal static void AddCouponApproveStatusName(DataSet ds, string newColunm, string approveStatus)
        {
            ds.Tables[0].Columns.Add(new DataColumn(newColunm, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                row[newColunm] = DALTool.GetApproveStatusString(row[approveStatus].ToString());

            }
        }
        internal static void AddDeliveryStatusName(DataSet ds, string newColunm, string deliveryStatus)
        {
            ds.Tables[0].Columns.Add(new DataColumn(newColunm, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                row[newColunm] = DALTool.GetDeliveryStatusString(row[deliveryStatus].ToString());

            }
        }
        internal static void AddOrderPickingApproveStatusName(DataSet ds, string newColunm, string approveStatus)
        {
            ds.Tables[0].Columns.Add(new DataColumn(newColunm, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                row[newColunm] = DALTool.GetOrderPickingApproveStatusString(row[approveStatus].ToString());

            }
        }

        internal static void AddPasswordFormat(DataSet ds, string newFormat, string format)
        {

            ds.Tables[0].Columns.Add(new DataColumn(newFormat, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int i = -1;
                i = int.TryParse(row[format].ToString(), out i) ? i : -1;
                row[newFormat] = DALTool.GetPasswordFormatName(i);

            }
        }
        internal static void AddID(DataSet ds, string newColumn, int size, int page)
        {
            long id = size * page;
            ds.Tables[0].Columns.Add(new DataColumn(newColumn, typeof(long)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row[newColumn] = ++id;
            }
        }

        internal static void AddPendingStatus(DataSet ds, string name, string refKey, string lan)
        {
            int id = 0;
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<int, string> cache = new Dictionary<int, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                id = int.TryParse(row[refKey].ToString(), out id) ? id : int.MinValue;
                switch (lan.ToLower())
                {
                    case "en-us":
                        switch (id)
                        {
                            case 0:
                                row[name] = "Audit";
                                break;
                            case 1:
                                row[name] = "Approve";
                                break;
                        }
                        break;
                    case "zh-cn":
                        switch (id)
                        {
                            case 0:
                                row[name] = "未批核";
                                break;
                            case 1:
                                row[name] = "已批核";
                                break;
                        }
                        break;
                    case "zh-hk":
                        switch (id)
                        {
                            case 0:
                                row[name] = "未稽核";
                                break;
                            case 1:
                                row[name] = "已經稽核";
                                break;
                        }
                        break;
                }
            }
        }
        internal static void AddColumn(DataSet ds, string newColumn, object value)
        {
            Type type = value != null ? value.GetType() : typeof(object);
            ds.Tables[0].Columns.Add(new DataColumn(newColumn, type));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row[newColumn] = value;
            }
        }

        internal static void AddColumn(DataTable dt, string newColumn, object value)
        {
            Type type = value != null ? value.GetType() : typeof(object);
            dt.Columns.Add(new DataColumn(newColumn, type));

            foreach (DataRow row in dt.Rows)
            {
                row[newColumn] = value;
            }
        }

        internal static void AddColumnWithValue(DataSet ds, string newColumn, string value)
        {
            ds.Tables[0].Columns.Add(new DataColumn(newColumn, typeof(object)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row[newColumn] = row[value];
            }
        }

        internal static void Sort(DataSet ds, string newColumn, string sortColumn, Type type)
        {
            ds.Tables[0].Columns.Add(newColumn, type);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i][newColumn] = ConvertTool.ChangeType(type, ds.Tables[0].Rows[i][sortColumn].ToString());
            }
        }

        internal static void ClearEndRow(DataTable dt)
        {
            if (dt == null) return;

            for (int i = dt.Rows.Count - 1; i > 0; i--)
            {
                bool isNull = true;
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    if (dt.Rows[i][col] != null && dt.Rows[i][col].ToString() != "")
                    {
                        isNull = false;
                        break;
                    }
                }
                if (isNull) dt.Rows.Remove(dt.Rows[i]);
                else break;
            }
        }


        #region for card operation
        internal static void AddCardApproveStatusName(DataSet ds, string newColunm, string approveStatus)
        {
            ds.Tables[0].Columns.Add(new DataColumn(newColunm, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                row[newColunm] = DALTool.GetApproveStatusString(row[approveStatus].ToString());

            }
        }
        #endregion

        internal static IEnumerable<DataRow> GetPaggingTable(int index, int pageSize, DataTable source)
        {
            if (source == null) return null;
            var result = (from row in source.AsEnumerable()
                          //select row).Skip(index * pageSize).Take(10); //Modified By Robin 2014-07-17 fixed page size bug
                          //select row).Skip(index * pageSize).Take(pageSize);
                          select row).Skip(index * pageSize).Take(pageSize); //Modified By Robin 2015-05-13 Temporary solution

            return result;
        }

        //Buying系统新增方法(Len)
        internal static string GetDayFlagStatusName(int status, string lan)
        {
            switch (lan.ToLower())
            {
                case "en-us":
                    switch (status)
                    {
                        case 1:
                            return "Active";
                        default:
                            return "Invalid";
                    }
                case "zh-cn":
                    switch (status)
                    {
                        case 1:
                            return "生效";
                        default:
                            return "Invalid";
                    }
                case "zh-hk":
                    return "";
                default:
                    switch (status)
                    {
                        case 1:
                            return "Active";
                        default:
                            return "Invalid";
                    }
            }
        }

        internal static void AddDayFlagName(DataSet ds, string name, string refKey)
        {
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row[name] = GetDayFlagStatusName(ConvertTool.ToInt(row[refKey].ToString()), System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower());
            }
        }

        internal static void AddEntityTypeName(DataTable dt, string name, string refKey)
        {
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in dt.Rows)
            {
                switch (Convert.ToInt32(row[refKey]))
                {
                    case 0:
                        row[name] = "--";
                        break;
                    case 1:
                        row[name] = "Prodcode";
                        break;
                    case 2:
                        row[name] = "DepartCode";
                        break;
                    case 3:
                        row[name] = "TenderCode";
                        break;
                }
            }
        }

        internal static string GetEntityTypeName(int TypeID)
        {
            switch (TypeID)
            {
                case 1:
                    return "Prodcode";
                case 2:
                    return "DepartCode";
                case 3:
                    return "TenderCode";
                default:
                    return "--";
            }
        }

        internal static void AddHitOPName(DataTable dt, string name, string refKey)
        {
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in dt.Rows)
            {
                switch (Convert.ToInt32(row[refKey]))
                {
                    case 0:
                        row[name] = "--";
                        break;
                    case 1:
                        row[name] = "=";
                        break;
                    case 2:
                        row[name] = "<>";
                        break;
                    case 3:
                        row[name] = "<=";
                        break;
                    case 4:
                        row[name] = ">=";
                        break;
                    case 5:
                        row[name] = "<";
                        break;
                    case 6:
                        row[name] = ">";
                        break;
                }
            }
        }

        internal static string GetHitOPName(int HitOpID)
        {
            switch (HitOpID)
            {
                case 1:
                    return "=";
                case 2:
                    return "<>";
                case 3:
                    return "<=";
                case 4:
                    return ">=";
                case 5:
                    return "<";
                case 6:
                    return ">";
                default:
                    return "--";
            }

        }

        internal static void AddDiscTypeName(DataTable dt, string name, string refKey)
        {
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in dt.Rows)
            {
                row[name] = GetDiscTypeName(ConvertTool.ToInt(row[refKey].ToString()), System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower());
            }
        }

        internal static string GetDiscTypeName(int DiscTypeID, string lan)
        {
            switch (lan.ToLower())
            {
                case "en-us":
                    switch (DiscTypeID)
                    {
                        case 1:
                            return "Discount Off $";
                        case 2:
                            return "Discount at $";
                        case 3:
                            return "Discount Off %";
                        case 4:
                            return "Discount at %";
                        default:
                            return "--";
                    }
                case "zh-cn":
                    switch (DiscTypeID)
                    {
                        case 1:
                            return "折扣减去的金额";
                        case 2:
                            return "折扣销售的金额";
                        case 3:
                            return " 折扣减去的百分比";
                        case 4:
                            return " 折扣销售的百分比";
                        default:
                            return "--";
                    }
                case "zh-hk":
                    return "";
                default:
                    switch (DiscTypeID)
                    {
                        case 1:
                            return "Discount Off $";
                        case 2:
                            return "Discount at $";
                        case 3:
                            return "Discount Off %";
                        case 4:
                            return "Discount at %";
                        default:
                            return "--";
                    }
            }
        }

        internal static void AddBuyingStoreName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingStoreName(code, cache);
            }
        }

        internal static void AddBuyingStoreNameByID(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingStoreNameByID(code, cache);
            }
        }

        internal static void GetBuyingStoreNameByStoreCode(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingStoreNameByStoreCode(code, cache);
            }
        }

        /// <summary>
        /// 显示库存数量
        /// 创建人：Lisa
        /// 创建时间：2016-10-19
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <param name="refKey"></param>
        internal static void AddBuyingStockOnhandQty(DataSet ds, string name, string refKey,int storeid)
        {
            string code = "";
            Edge.SVA.BLL.BUY_STORE storeBLL = new SVA.BLL.BUY_STORE();
            Edge.SVA.BLL.STK_StockOnhand stockOnhandBLL = new SVA.BLL.STK_StockOnhand();
            Edge.SVA.Model.STK_StockOnhand StockOnhand = new SVA.Model.STK_StockOnhand();
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                string prodCode = row["ProdCode"].ToString();
                string stockTypeCode = row["StockTypeCode"].ToString();
                string pickupLocation = "";
                if (storeid != 0)
                {
                    pickupLocation = storeid.ToString();
                }
                else
                {
                    Edge.SVA.Model.Ord_SalesPickOrder_H pickOrder = new Edge.SVA.BLL.Ord_SalesPickOrder_H().GetModel(code);
                    if (pickOrder != null)
                    {
                        pickupLocation = pickOrder.PickupLocation;
                    }
                }
                int qty = 0;
                Edge.SVA.Model.Ord_SalesPickOrder_D pickOrderD = new Edge.SVA.BLL.Ord_SalesPickOrder_D().GetModel(Convert.ToInt32(row["KeyID"]));
                if (pickOrderD != null)
                {
                    qty = Convert.ToInt32(pickOrderD.OrderQty);
                }
                int result;
                if (Common.Utils.isNumberic(pickupLocation.ToString(), out result))
                {
                    StockOnhand = stockOnhandBLL.GetModel(Convert.ToInt32(pickupLocation), stockTypeCode, prodCode);
                    if (StockOnhand != null)
                    {
                        row[name] = StockOnhand.OnhandQty + qty;
                    }
                    else
                    {
                        row[name] = 0;
                    }
                }
                else
                {
                    Edge.SVA.BLL.BUY_STORE bll = new SVA.BLL.BUY_STORE();
                    Edge.SVA.Model.BUY_STORE store = bll.GetStoreByCode(pickupLocation.ToString());
                    if (store != null)
                    {
                        Edge.SVA.Model.BUY_STORE stores = storeBLL.GetStoreByCode(pickupLocation);
                        StockOnhand = stockOnhandBLL.GetModel(Convert.ToInt32(stores.StoreID), stockTypeCode, prodCode);
                        if (StockOnhand != null)
                        {
                            row[name] = StockOnhand.OnhandQty + qty;
                        }
                        else
                        {
                            row[name] = 0;
                        }
                    }
                }
            }
        }
        internal static void AddBuyingStoreGroupName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingStoreGroupName(code, cache);
            }
        }

        internal static void AddBuyingStoreGroupNameByID(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingStoreGroupNameByID(code, cache);
            }
        }

        internal static void AddBuyingCurrencyName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingCurrencyName(code, cache);
            }
        }

        internal static void AddBuyingVendorName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingVendorName(code, cache);
            }
        }

        internal static void AddBuyingVendorNameByID(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingVendorNameByID(code, cache);
            }
        }

        internal static void AddBuyingProdName(DataTable dt, string name, string refKey)
        {
            string code = "";
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingProdName(code, cache);
            }

        }
        internal static void AddBuyingIMP_ProdName(DataTable dt, string name, string refKey)
        {
            string code = "";
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingIMP_ProdName(code, cache);
            }

        }
        internal static void AddBuyingProdDeptCode(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingProdDeptCode(code, cache);
            }
        }

        internal static void AddBuyingDepartName(DataTable dt, string name, string refKey)
        {
            string code = "";
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingDepartName(code, cache);
            }

        }

        internal static void AddBuyingRPriceTypeName(DataTable dt, string name, string refKey)
        {
            string code = "";
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingRPriceTypeName(code, cache);
            }

        }
        /// <summary>
        /// 查询店铺品牌
        /// 创建人：Lisa
        /// 创建时间：2016-08-11
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <param name="refKey"></param>
        internal static void AddBrandName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBrandName(code, cache);
            }
        }

        internal static void AddBuyingBrandName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingBrandName(code, cache);
            }
        }

        internal static void AddBuyingProdTypeSizeName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingProdTypeSizeName(code, cache);
            }

        }

        internal static void AddHitTypeName(DataTable dt, string name, string refKey)
        {
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in dt.Rows)
            {
                if (!string.IsNullOrEmpty(row[refKey].ToString()))
                {
                    switch (Convert.ToInt32(row[refKey]))
                    {
                        case 0:
                            row[name] = "Hit";
                            break;
                        case 1:
                            row[name] = "Gift";
                            break;
                        case 2:
                            row[name] = "Hit&Gift";
                            break;
                    }
                }
            }
        }

        #region Promotion表
        internal static void AddPromotionHitTypeName(DataTable dt, string name, string refKey)
        {
            string code = "";
            dt.Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in dt.Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetHitTypeName(code);
            }
        }

        internal static void AddPromotionHitItemName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetHitItemName(code);
            }
        }

        /// <summary>
        /// 根据省编号得到省名称
        /// 创建者：Lisa
        /// 创建时间：2015-12-31
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <param name="refKey"></param>
        internal static void AddProviceName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetProviceName(code, cache);
            }
        }


        #region ProductModifyTemp
        internal static void AddProductModifyTempStatusName(DataSet ds, string newColunm, string Status)
        {
            ds.Tables[0].Columns.Add(new DataColumn(newColunm, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                row[newColunm] = DALTool.GetProductModifyTempStatusString(row[Status].ToString());

            }
        }
        internal static void AddProductModifyTempIsOnlineSKUName(DataSet ds, string newColunm, string Status)
        {
            ds.Tables[0].Columns.Add(new DataColumn(newColunm, typeof(string)));

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                row[newColunm] = DALTool.GetProductModifyTempIsOnlineSKUString(row[Status].ToString());

            }
        }
        #endregion

        internal static void AddLogicalOprName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetLogicalOprName(code);
            }
        }

        internal static void AddPromotionGiftTypeName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetPromotionGiftTypeName(code);
            }
        }

        internal static void AddPromotionDiscountOnName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetPromotionDiscountOnName(code);
            }
        }

        internal static void AddPromotionDiscountTypeName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetPromotionDiscountTypeName(code);
            }
        }

        internal static void AddPromotionGiftItemName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetPromotionGiftItemName(code);
            }
        }
        #endregion

        #region 动态获取当前语言下的列（描述，名称）
        internal static void AddBuyingBankName(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingBankName(code, cache);
            }
        }

        internal static void AddBuyingProdDesc(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingProdDesc(code, cache);
            }
        }

        internal static void AddBuyingReasonDesc(DataSet ds, string name, string refKey)
        {
            string code = "";
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                code = row[refKey].ToString();
                row[name] = Edge.Web.Tools.DALTool.GetBuyingReasonDesc(code, cache);
            }
        }


        #endregion
    }
}
