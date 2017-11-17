using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Edge.DBUtility;
using System.Data;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_ImportCouponUID_H : BaseDAL
    {
        public bool ExistCouponUID(List<string> couponUIDS)
        {
            if (couponUIDS == null || couponUIDS.Count <= 0) return false;
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(1) from CouponUIDMap ");
            sql.AppendFormat("where CouponUID in ('{0}'", couponUIDS[0]);
            for (int i = 1; i < couponUIDS.Count; i++)
            {
                sql.AppendFormat(",'{0}'", couponUIDS[i]);
               
            }
            sql.Append(")");

            return DBUtility.DbHelperSQL.Exists(sql.ToString());
        }

        public bool ExistCouponUID(string beginUID, string endUID, bool isCheckdigit)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(1) from CouponUIDMap ");

            if (isCheckdigit)
            {
                sql.Append("where SUBSTRING(CouponUID,0,len(CouponUID)) between @BeginUID and @EndUID");
            }
            else
            {
                sql.Append("where SUBSTRING(CouponUID,0,len(CouponUID)) between @BeginUID and @EndUID");
            }

            SqlParameter[] parameters = {
                                            new SqlParameter("@BeginUID",System.Data.SqlDbType.BigInt){Value=beginUID},
                                            new SqlParameter("@EndUID",System.Data.SqlDbType.BigInt){Value=endUID}
                                        };

            return DBUtility.DbHelperSQL.Exists(sql.ToString(), parameters);
        }

        public bool Update(Model.Ord_ImportCouponUID_H model, int times)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ord_ImportCouponUID_H set ");
            strSql.Append("ImportCouponDesc1=@ImportCouponDesc1,");
            strSql.Append("ImportCouponDesc2=@ImportCouponDesc2,");
            strSql.Append("ImportCouponDesc3=@ImportCouponDesc3,");
            strSql.Append("NeedActive=@NeedActive,");
            strSql.Append("NeedNewBatch=@NeedNewBatch,");
            strSql.Append("CouponCount=@CouponCount,");
            strSql.Append("ApproveStatus=@ApproveStatus,");
            strSql.Append("ApproveOn=@ApproveOn,");
            strSql.Append("ApproveBy=@ApproveBy,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("CreatedBusDate=@CreatedBusDate,");
            strSql.Append("ApproveBusDate=@ApproveBusDate,");
            strSql.Append("ApprovalCode=@ApprovalCode");
            strSql.Append(" where ImportCouponNumber=@ImportCouponNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ImportCouponDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ImportCouponDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@NeedActive", SqlDbType.Int,4),
					new SqlParameter("@NeedNewBatch", SqlDbType.Int,4),
					new SqlParameter("@CouponCount", SqlDbType.Int,4),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512),
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512)};
            parameters[0].Value = model.ImportCouponDesc1;
            parameters[1].Value = model.ImportCouponDesc2;
            parameters[2].Value = model.ImportCouponDesc3;
            parameters[3].Value = model.NeedActive;
            parameters[4].Value = model.NeedNewBatch;
            parameters[5].Value = model.CouponCount;
            parameters[6].Value = model.ApproveStatus;
            parameters[7].Value = model.ApproveOn;
            parameters[8].Value = model.ApproveBy;
            parameters[9].Value = model.CreatedOn;
            parameters[10].Value = model.CreatedBy;
            parameters[11].Value = model.UpdatedOn;
            parameters[12].Value = model.UpdatedBy;
            parameters[13].Value = model.CreatedBusDate;
            parameters[14].Value = model.ApproveBusDate;
            parameters[15].Value = model.ApprovalCode;
            parameters[16].Value = model.ImportCouponNumber;

            int rows = DbHelperSQL.ExecuteSqlByTime(strSql.ToString(), times, parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ExportCSV(string importCouponNumber, int couponCount)
        {
            string fileName = this.GetFileName(importCouponNumber);

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
            sql.Append("select CouponNumber ,CouponUID from CouponUIDMap where ImportCouponNumber = 	@ImportCouponNumber");

            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[1]
            {
                new System.Data.SqlClient.SqlParameter("@ImportCouponNumber",importCouponNumber)
            };

            System.IO.FileStream fs = null;
            System.Data.IDataReader reader = null;

            try
            {
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                reader = Edge.DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), 120, parameters);

                StringBuilder text = new StringBuilder(1000);
                text.Append("\tCouponNumber,\tCouponUID\r\n");

                #region Write To File
                int total = 0;
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

                if (total != couponCount)
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

        private string GetFileName(string importCouponNumber)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath);
            if (!path.EndsWith("\\")) path += "\\Export\\";
            else path += "Export\\";
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

            string fileName = string.Format("ExportImportCoupon_{0}.csv", importCouponNumber);
            string fullName = path + fileName;

            return fullName;
        }

        protected override string TableName
        {
            get { return "Ord_ImportCouponUID_H"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_ImportCouponUID_H.ImportCouponNumber";
        }
    }
}
