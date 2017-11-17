using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Edge.Utils
{
    public class AppConfig
    {
        private static AppConfig instance = new AppConfig();
        private AppConfig()
        {
            string connstr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connstr);
            dbServer = conn.DataSource;
            databaseName = conn.Database;
            conn = null;
        }
        public static AppConfig Singleton
        {
            get { return instance; }
        }
        private string dbServer;

        public string ServerName
        {
            get { return dbServer; }
        }
        private string databaseName;

        public string DbName
        {
            get { return databaseName; }
        }


    }
}
