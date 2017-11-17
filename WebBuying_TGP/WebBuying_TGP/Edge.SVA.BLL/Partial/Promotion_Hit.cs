using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL
{
    public partial class Promotion_Hit
    {
        public List<PromotionHitViewModel> GetNewModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return NewDataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PromotionHitViewModel> NewDataTableToList(DataTable dt)
        {
            List<PromotionHitViewModel> modelList = new List<PromotionHitViewModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PromotionHitViewModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new PromotionHitViewModel();
                    if (dt.Rows[n]["PromotionCode"] != null && dt.Rows[n]["PromotionCode"].ToString() != "")
                    {
                        model.PromotionCode = dt.Rows[n]["PromotionCode"].ToString();
                    }
                    if (dt.Rows[n]["HitSeq"] != null && dt.Rows[n]["HitSeq"].ToString() != "")
                    {
                        model.HitSeq = int.Parse(dt.Rows[n]["HitSeq"].ToString());
                    }
                    if (dt.Rows[n]["HitLogicalOpr"] != null && dt.Rows[n]["HitLogicalOpr"].ToString() != "")
                    {
                        model.HitLogicalOpr = int.Parse(dt.Rows[n]["HitLogicalOpr"].ToString());
                    }
                    if (dt.Rows[n]["HitType"] != null && dt.Rows[n]["HitType"].ToString() != "")
                    {
                        model.HitType = int.Parse(dt.Rows[n]["HitType"].ToString());
                    }
                    if (dt.Rows[n]["HitValue"] != null && dt.Rows[n]["HitValue"].ToString() != "")
                    {
                        model.HitValue = int.Parse(dt.Rows[n]["HitValue"].ToString());
                    }
                    if (dt.Rows[n]["HitOP"] != null && dt.Rows[n]["HitOP"].ToString() != "")
                    {
                        model.HitOP = int.Parse(dt.Rows[n]["HitOP"].ToString());
                    }
                    if (dt.Rows[n]["HitItem"] != null && dt.Rows[n]["HitItem"].ToString() != "")
                    {
                        model.HitItem = int.Parse(dt.Rows[n]["HitItem"].ToString());
                    }
                    model.HitPluTable = GetPLUList(dt.Rows[n]["PromotionCode"].ToString(), Convert.ToInt32(dt.Rows[n]["HitSeq"]));
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public bool DeleteData(string PromotionCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Promotion_Hit ");
            strSql.Append(" where PromotionCode=@PromotionCode");
            SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64)};
            parameters[0].Value = PromotionCode;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得子表数据
        /// </summary>
        public DataTable GetPLUList(string PromotionCode, int HitSeq)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from Promotion_Hit_PLU where PromotionCode='" + PromotionCode + "' and HitSeq=" + HitSeq;
            dt = DBUtility.DbHelperSQL.Query(sql).Tables.Count <= 0 ? null : DBUtility.DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
    }
}
