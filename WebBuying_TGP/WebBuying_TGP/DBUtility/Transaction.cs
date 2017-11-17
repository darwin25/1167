using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Edge.DBUtility
{
    public class Transaction
    {
        private SqlTransaction trans;

        public SqlTransaction Trans
        {
            get { return trans; }
            set { trans = value; }
        }

        private SqlConnection conn = new SqlConnection(PubConstant.ConnectionString);

        public SqlConnection Conn
        {
            get { return conn; }
        }


        public void OpenConnSVAWithTrans()
        {
            Conn.Open();
            this.Trans = Conn.BeginTransaction();
        }

        public void CloseConn()
        {
            if (Conn.State != ConnectionState.Closed)
            {
                Conn.Close();
                this.Trans = null;
            }
        }
    }
}
