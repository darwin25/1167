using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.IDAL;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_CouponBatchCreate : BaseDAL
    {
        public string ExportCSV(Edge.SVA.Model.Ord_CouponBatchCreate model)
        {
            if (model == null) return "";

            string fileName = this.GetFileName(model.CouponCreateNumber);
            if (System.IO.File.Exists(fileName))
            {
                return fileName;
            } 
            object sync = typeof(Ord_CardBatchCreate);
            System.Threading.Monitor.Enter(sync);
            if (System.IO.File.Exists(fileName))
            {
                System.Threading.Monitor.Exit(sync);
                return fileName;
            } 

            StringBuilder sql = new StringBuilder(200);
            sql.Append("select Coupon.CouponNumber,CouponUIDMap.CouponUID from Coupon ");
            sql.Append("left join CouponUIDMap on Coupon.CouponNumber = CouponUIDMap.CouponNumber  ");
            sql.Append("where Coupon.BatchCouponID = @BatchCouponID");

            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@BatchCouponID",model.BatchCouponID)
            };

            System.IO.FileStream fs = null;
            System.Data.IDataReader reader = null;
            int total = 0;
            try
            {
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                reader = Edge.DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), 120, parameters);
                
                StringBuilder text = new StringBuilder(1000);
                text.Append("\tCouponNumber,\tCouponUID\r\n");

                #region Write to File
                while (reader.Read())
                {
                    total++;
                    text.AppendFormat("\t{0},\t{1}\r\n", reader["CouponNumber"].ToString(), reader["CouponUID"].ToString());

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

                if (total != model.CouponCount)
                {
                    fs.Close();
                    if (System.IO.File.Exists(fileName)) System.IO.File.Delete(fileName);
                    throw new Exception("The Coupon count not match");
                }
               
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

        private string GetFileName(string CouponCreateNumber)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath);
            if (!path.EndsWith("\\")) path += "\\Export\\";
            else path += "Export\\";
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

            string fileName = string.Format("ExportBatchCouponCreated_{0}.csv", CouponCreateNumber);
            string fullName = path + fileName;

            return fullName;
        }


        protected override string TableName
        {
            get { return "Ord_CouponBatchCreate"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_CouponBatchCreate.CouponCreateNumber";
        }

    }
}
