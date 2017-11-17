using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.SVA.SQLServerDAL
{
    public partial class Ord_CardBatchCreate : BaseDAL
    {
        public string ExportCSV(int batchCardID,int cardCount)
        {
            string fileName = this.GetFileName(batchCardID);
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
            //sql.Append("select CardNumber from Card ");
            //sql.Append("where Card.BatchCardID = @BatchCardID");

            sql.Append("select Card.CardNumber,CardUIDMap.CardUID from Card ");
            sql.Append("left join CardUIDMap on Card.CardNumber = CardUIDMap.CardNumber  ");
            sql.Append("where Card.BatchCardID = @BatchCardID order by CardUIDMap.CardUID asc");

            System.Data.SqlClient.SqlParameter[] parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@BatchCardID",batchCardID)
            };

            System.IO.FileStream fs = null;
            System.Data.IDataReader reader = null;

            try
            {
                StringBuilder text = new StringBuilder(1000);
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                reader = Edge.DBUtility.DbHelperSQL.ExecuteReader(sql.ToString(), 120, parameters);
                //text.Append("\tCardNumber,\tCardUID\r\n");
                //text.Append("CardUID\r\n");

                #region Write To File
                int total = 0;
                while (reader.Read())
                {
                    //total++;
                    //text.AppendFormat("\t{0}\r\n", reader["CardNumber"].ToString());
                    total++;
                    text.AppendFormat("{0}\r\n", reader["CardUID"].ToString());

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

                if (total != cardCount)
                {
                    fs.Close();
                    if (System.IO.File.Exists(fileName)) System.IO.File.Delete(fileName);
                    throw new Exception("The Card count not match");
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

        private string GetFileName(int batchID)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath);
            if (!path.EndsWith("\\")) path += "\\Export\\";
            else path += "Export\\";
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

            string fileName = string.Format("ExportBatchCardCreated_{0}.csv", batchID);
            string fullName = path + fileName;

            return fullName;
        }

        protected override string TableName
        {
            get { return "Ord_CardBatchCreate"; }
        }

        protected override void Initialization()
        {
            base.Initialization();

            this.Order = "Ord_CardBatchCreate.CardCreateNumber";
        }
    }
}
