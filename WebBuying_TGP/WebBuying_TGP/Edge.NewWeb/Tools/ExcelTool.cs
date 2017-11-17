using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace Edge.Web.Tools
{
    public class ExcelTool
    {
        private static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ExcelConnectionString"];

                return _connectionString;
            }
        }

        public static DataTable GetFirstSheet(string filename)
        {
            string[] sheets = GetExcelSheets(filename);
            DataTable dt = null;

            if (sheets != null && sheets.Length > 0)
            {
                dt = ExcelTool.GetAllRows(filename, sheets[0]);
            }
            return dt;
        }


        public static DataTable GetFirstSheet_New(string filename)
        {
            string[] sheets = GetExcelSheets(filename);
            DataTable dt = null;

            if (sheets != null && sheets.Length > 0)
            {
                dt = ExcelTool.GetAllRows_New(filename, sheets[0]);
            }
            return dt;
        }

        private static OleDbConnection GetConnection(string filename)
        {
            string conString = string.Format(ExcelTool.ConnectionString, filename);

            OleDbConnection objConn = new OleDbConnection(conString);

            return objConn;
        }

        private static DataTable GetAllRows(string filename, string table)
        {
            OleDbConnection conn = null;
            OleDbDataAdapter adapter = null;

            try
            {
                conn = GetConnection(filename);
                conn.Open();

                string strExcel = string.Format("select * from [{0}] ", Edge.Common.WebCommon.No_SqlHack(table));

                adapter = new OleDbDataAdapter(strExcel, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt != null && dt.Columns.Count <= 1) return null;

                return dt;
            }
            catch (Exception ex)
            {
                Tools.Logger.Instance.WriteErrorLog("[ExcelTool].GetAllRows()", "", ex);
                return null;
            }
            finally
            {
                Close(conn, adapter);
            }

        }


        private static DataTable GetAllRows_New(string filename, string table)
        {
            OleDbConnection conn = null;
            OleDbDataAdapter adapter = null;

            try
            {
                conn = GetConnection(filename);
                conn.Open();
                string strExcel = string.Format("select * from [{0}] ", Edge.Common.WebCommon.No_SqlHack(table));  
                adapter = new OleDbDataAdapter(strExcel, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt == null && dt.Columns.Count <= 0) return null;

                return dt;
            }
            catch (Exception ex)
            {
                Tools.Logger.Instance.WriteErrorLog("[ExcelTool].GetAllRows()", "", ex);
                return null;
            }
            finally
            {
                Close(conn, adapter);
            }

        }


        private static String[] GetExcelSheets(string filename)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;
            try
            {
                objConn = ExcelTool.GetConnection(filename);
                objConn.Open();

                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dt == null) return null;

                String[] excelSheets = new String[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    excelSheets[i] = dt.Rows[i]["TABLE_NAME"].ToString();
                }
                return excelSheets;
            }
            catch (Exception ex)
            {
                Tools.Logger.Instance.WriteErrorLog("[ExcelTool].GetExcelSheets()", "", ex);
                return null;
            }
            finally
            {
                Close(objConn, null);
            }
        }

        private static void Close(OleDbConnection conn, OleDbDataAdapter adapter)
        {
            if (adapter != null)
            {
                adapter.Dispose();
            }
            if ((conn != null) && (conn.State == ConnectionState.Open))
            {
                conn.Close();
            }
        }

    }

    public class ExcelModel
    {
        public string CouponCode { get; set; }
        public long BeginSeriesNo { get; set; }
        public long EndingSeriesNo { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string BatchID { get; set; }
        public decimal Denomination { get; set; }

    }
}
