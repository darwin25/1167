using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
    /// <summary>
    /// 品牌表
    /// </summary>
    public partial class Brand
    {
        private string SessionChangeCardIssuersStr(string strWhere)
        {
            //SessionInfo si = new SessionInfo();
            string str = SessionInfo.CardIssuersStr;
            if (!String.IsNullOrEmpty(str))
            {
                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere = " CardIssuerID in " + str;
                }
                else
                {
                    string[] strs=SqlWhereUtil.SplitStringByOrderBy(strWhere);
                    if (strs.Length<=1)
                    {
                        strWhere = strWhere + " and CardIssuerID in " + str;
                    } 
                    else 
                    {
                        strWhere = strs[0] + " and CardIssuerID in " + str + strs[1];
                    }
                    
                }
            }
            return strWhere;
        }

        private string SessionChangeBrandIDsStr(string strWhere)
        {
            string str = SessionInfo.BrandIDsStr;
            if (!String.IsNullOrEmpty(str))
            {
                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere = " BrandID in " + str;
                }
                else
                {
                    string[] strs = SqlWhereUtil.SplitStringByOrderBy(strWhere);
                    if (strs.Length <= 1)
                    {
                        strWhere = strWhere + " and BrandID in " + str;
                    }
                    else
                    {
                        strWhere = strs[0] + " and BrandID in " + str+strs[1];
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(strWhere))
                {
                    strWhere = " 1=1 ";
                }
                else
                {
                    string[] strs = SqlWhereUtil.SplitStringByOrderBy(strWhere);
                    if (strs.Length <= 1)
                    {
                        strWhere = strWhere + " and 1=1 ";
                    }
                    else
                    {
                        strWhere = strs[0] + " and 1=1 "+strs[1];
                    }
                }
            }
            return strWhere;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllRecordList()
        {
            return dal.GetList(" 1 = 1 order by BrandCode ");
        }


        /// <summary>
        /// 获取总页数不加权限
        /// </summary>
        public int GetCountUnlimited(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public Edge.SVA.Model.Brand GetModelByCode(string brandCode)
        {
            List<SVA.Model.Brand> brands = new Edge.SVA.BLL.Brand().GetModelList(string.Format("BrandCode='{0}'", Common.WebCommon.No_SqlHack(brandCode)));
            if (brands == null || brands.Count <= 0) return null;

            return brands[0];
        }

        /// <summary>
        /// 根据BrandName1判断是否存在此Brand,存在则返回BrandID
        /// </summary>
        public int ExistsBrand(string brandname)
        {
            if (!string.IsNullOrEmpty(brandname))
            {
                Brand bll = new Brand();
                DataTable dt = bll.GetList("BrandName1='" + brandname + "'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["BrandID"]);
                }
            }
            return 0;
        }
    }
}

