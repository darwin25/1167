using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edge.SVA.Model.Domain.WebBuying.BasicViewModel;
using System.Data.SqlClient;
using Edge.DBUtility;
using System.Data;

namespace Edge.SVA.BLL
{
   public partial class Promotion_Gift
    {
        public List<PromotionGiftViewModel> GetNewModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return NewDataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PromotionGiftViewModel> NewDataTableToList(DataTable dt)
        {
            List<PromotionGiftViewModel> modelList = new List<PromotionGiftViewModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PromotionGiftViewModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new PromotionGiftViewModel();
                    if (dt.Rows[n]["PromotionCode"] != null && dt.Rows[n]["PromotionCode"].ToString() != "")
                    {
                        model.PromotionCode = dt.Rows[n]["PromotionCode"].ToString();
                    }
                    if (dt.Rows[n]["GiftSeq"] != null && dt.Rows[n]["GiftSeq"].ToString() != "")
                    {
                        model.GiftSeq = int.Parse(dt.Rows[n]["GiftSeq"].ToString());
                    }
                    if (dt.Rows[n]["GiftLogicalOpr"] != null && dt.Rows[n]["GiftLogicalOpr"].ToString() != "")
                    {
                        model.GiftLogicalOpr = int.Parse(dt.Rows[n]["GiftLogicalOpr"].ToString());
                    }
                    if (dt.Rows[n]["PromotionGiftType"] != null && dt.Rows[n]["PromotionGiftType"].ToString() != "")
                    {
                        model.PromotionGiftType = int.Parse(dt.Rows[n]["PromotionGiftType"].ToString());
                    }
                    if (dt.Rows[n]["PromotionDiscountOn"] != null && dt.Rows[n]["PromotionDiscountOn"].ToString() != "")
                    {
                        model.PromotionDiscountOn = int.Parse(dt.Rows[n]["PromotionDiscountOn"].ToString());
                    }
                    if (dt.Rows[n]["PromotionDiscountType"] != null && dt.Rows[n]["PromotionDiscountType"].ToString() != "")
                    {
                        model.PromotionDiscountType = int.Parse(dt.Rows[n]["PromotionDiscountType"].ToString());
                    }
                    if (dt.Rows[n]["PromotionValue"] != null && dt.Rows[n]["PromotionValue"].ToString() != "")
                    {
                        model.PromotionValue = decimal.Parse(dt.Rows[n]["PromotionValue"].ToString());
                    }
                    if (dt.Rows[n]["PromotionGiftQty"] != null && dt.Rows[n]["PromotionGiftQty"].ToString() != "")
                    {
                        model.PromotionGiftQty = int.Parse(dt.Rows[n]["PromotionGiftQty"].ToString());
                    }
                    if (dt.Rows[n]["PromotionGiftItem"] != null && dt.Rows[n]["PromotionGiftItem"].ToString() != "")
                    {
                        model.PromotionGiftItem = int.Parse(dt.Rows[n]["PromotionGiftItem"].ToString());
                    }
                    model.GiftPluTable = GetPLUList(dt.Rows[n]["PromotionCode"].ToString(), Convert.ToInt32(dt.Rows[n]["GiftSeq"]));
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public bool DeleteData(string PromotionCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Promotion_Gift ");
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
        public DataTable GetPLUList(string PromotionCode, int GiftSeq)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from Promotion_Gift_PLU where PromotionCode='" + PromotionCode + "' and GiftSeq=" + GiftSeq;
            dt = DBUtility.DbHelperSQL.Query(sql).Tables.Count <= 0 ? null : DBUtility.DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
    }
}
