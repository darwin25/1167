using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Edge.DBUtility;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_ImportCouponDispense_H : BaseDAL
    {
        protected override string TableName
        {
            get
            {
                return "Ord_ImportCouponDispense_H";
            }

        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_ImportCouponDispense_H.CouponDispenseNumber";
        }

        public List<string> GetCardNumbers(List<int> cardTypes, List<int> members)
        {
            List<string> list = new List<string>();
            if (cardTypes == null || cardTypes.Count <= 0) return list;
            if (members == null || members.Count <= 0) return list;

            StringBuilder sql = new StringBuilder(200);
            sql.Append("select CardNumber from Card ");

            sql.AppendFormat("where MemberID in ( {0} ", members[0]);
            for (int i = 1; i < members.Count; i++)
            {
                sql.AppendFormat(",{0}", members[i]);
            }
            sql.AppendFormat(" ) and CardTypeID in ( {0}", cardTypes[0]);

            for (int i = 1; i < cardTypes.Count; i++)
            {
                sql.AppendFormat(",{0}", cardTypes[i]);
            }
            sql.Append(")");
            sql.Append(" and Status in (1,2,3,4)");

            System.Data.IDataReader reader = null;
            try
            {
                reader = DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), 120);
                while (reader.Read())
                {
                    list.Add(reader["CardNumber"].ToString());
                }
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return list;
        }

        public string ExportCSV(Edge.SVA.Model.Ord_ImportCouponDispense_H model)
        {
            if (model == null) return "";

            string fileName = this.GetFileName(model.CouponDispenseNumber);

            object sync = typeof(Ord_ImportCouponDispense_H);
            System.Threading.Monitor.Enter(sync);
            if (System.IO.File.Exists(fileName)) return fileName;

            StringBuilder sql = new StringBuilder(200);
            sql.Append("select CouponNumber,CardNumber from Coupon_Movement ");
            sql.Append("where RefTxnNo = @CouponDispenseNumber and OprID = 32 ");

            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@CouponDispenseNumber",model.CouponDispenseNumber)
            };

            System.IO.FileStream fs = null;
            System.Data.IDataReader reader = null;
            try
            {
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                reader = Edge.DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), 120, parameters);

                StringBuilder text = new StringBuilder(1000);
                text.Append("\tCouponNumber,\tCardNumber\r\n");

                #region Write to File
                while (reader.Read())
                {
                    text.AppendFormat("\t{0},\t{1}\r\n", reader["CouponNumber"].ToString(), reader["CardNumber"].ToString());

                    if (text.Length >= 10000)
                    {
                        byte[] buffer = System.Text.Encoding.Default.GetBytes(text.ToString());
                        fs.Write(buffer, 0, buffer.Length);
                        text.Remove(0, text.Length);
                    }
                }
                if (text.Length > 0)
                {
                    byte[] buffer = System.Text.Encoding.Default.GetBytes(text.ToString());
                    fs.Write(buffer, 0, buffer.Length);
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
                if (reader != null) reader.Close();
                System.Threading.Monitor.Exit(sync);
            }
            return fileName;

        }

        private string GetFileName(string CouponDispenseNumber)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath);
            if (!path.EndsWith("\\")) path += "\\Export\\";
            else path += "Export\\";
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

            string fileName = string.Format("ExportBICoupons_{0}.csv", CouponDispenseNumber);
            string fullName = path + fileName;

            return fullName;
        }
    }
}
