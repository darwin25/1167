using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Edge.Security
{
    public abstract class DbObjects
    {
        // Fields
        protected SqlConnection Connection;
        public static string connectionString = PubConstant.ConnectionString;

        // Methods
        public DbObjects(string newConnectionString)
        {
            connectionString = newConnectionString;
            this.Connection = new SqlConnection(connectionString);
        }

        private SqlCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = this.BuildQueryCommand(storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        private SqlCommand BuildQueryCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, this.Connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        protected SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            this.Connection.Open();
            SqlCommand command = this.BuildQueryCommand(storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();
        }

        protected int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            this.Connection.Open();
            SqlCommand command = this.BuildIntCommand(storedProcName, parameters);
            rowsAffected = command.ExecuteNonQuery();
            int num = (int)command.Parameters["ReturnValue"].Value;
            this.Connection.Close();
            return num;
        }

        protected DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            this.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildQueryCommand(storedProcName, parameters);
            adapter.Fill(dataSet, tableName);
            this.Connection.Close();
            return dataSet;
        }
      

        protected void RunProcedure(string storedProcName, IDataParameter[] parameters, DataSet dataSet, string tableName)
        {
            this.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = this.BuildIntCommand(storedProcName, parameters);
            adapter.Fill(dataSet, tableName);
            this.Connection.Close();
        }

        // Properties
        protected string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
