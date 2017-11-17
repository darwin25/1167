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
   public partial class Promotion_Member
    {
        public List<PromotionMemberViewModel> GetNewModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return NewDataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PromotionMemberViewModel> NewDataTableToList(DataTable dt)
        {
            List<PromotionMemberViewModel> modelList = new List<PromotionMemberViewModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PromotionMemberViewModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new PromotionMemberViewModel();
                    if (dt.Rows[n]["KeyID"] != null && dt.Rows[n]["KeyID"].ToString() != "")
                    {
                        model.KeyID = int.Parse(dt.Rows[n]["KeyID"].ToString());
                    }
                    if (dt.Rows[n]["PromotionCode"] != null && dt.Rows[n]["PromotionCode"].ToString() != "")
                    {
                        model.PromotionCode = dt.Rows[n]["PromotionCode"].ToString();
                    }
                    if (dt.Rows[n]["LoyaltyCardTypeID"] != null && dt.Rows[n]["LoyaltyCardTypeID"].ToString() != "")
                    {
                        model.LoyaltyCardTypeID = int.Parse(dt.Rows[n]["LoyaltyCardTypeID"].ToString());
                    }
                    if (dt.Rows[n]["LoyaltyCardGradeID"] != null && dt.Rows[n]["LoyaltyCardGradeID"].ToString() != "")
                    {
                        model.LoyaltyCardGradeID = int.Parse(dt.Rows[n]["LoyaltyCardGradeID"].ToString());
                    }
                    if (dt.Rows[n]["LoyaltyThreshold"] != null && dt.Rows[n]["LoyaltyThreshold"].ToString() != "")
                    {
                        model.LoyaltyThreshold = int.Parse(dt.Rows[n]["LoyaltyThreshold"].ToString());
                    }
                    if (dt.Rows[n]["LoyaltyBirthdayFlag"] != null && dt.Rows[n]["LoyaltyBirthdayFlag"].ToString() != "")
                    {
                        model.LoyaltyBirthdayFlag = int.Parse(dt.Rows[n]["LoyaltyBirthdayFlag"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public bool DeleteData(string PromotionCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Promotion_Member ");
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
    }
}
