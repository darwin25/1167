using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Edge.Messages.Data
{
    public class Message
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string project,string product,string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Project", SqlDbType.NVarChar, 512),
                new SqlParameter("@Product", SqlDbType.NVarChar, 512),
                new SqlParameter("@Lan", SqlDbType.NVarChar, 512) };
            parameters[0].Value = project;
            parameters[1].Value = product;
            parameters[2].Value = lan;

            StringBuilder sql = new StringBuilder();

            sql.Append("select t.TAPCode,t.OriginalCode,t.Project,t.Product,t.ModifiedBy,t.AddDate,t.MessageIconDisplay,t.ButtonDisplay,  ");
            sql.Append(" case when l.Message is not null then l.Message else t.Message end as Message ");
            sql.Append("from DialogMessage t left join DialogMessage_Lan l on t.TAPCode =l.TAPCode  ");
            sql.Append(" and l.lan=@Lan where t.Project=@Project and t.Product=@Product ORDER BY Message ");

            return DbHelperSQL.Query(sql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string product, string lan)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Product", SqlDbType.NVarChar, 512),
                new SqlParameter("@Lan", SqlDbType.NVarChar, 512) };
            parameters[0].Value = product;
            parameters[1].Value = lan;

            StringBuilder sql = new StringBuilder();

            sql.Append("select t.TAPCode,t.OriginalCode,t.Project,t.Product,t.ModifiedBy,t.AddDate,t.MessageIconDisplay,t.ButtonDisplay,  ");
            sql.Append(" case when l.Message is not null then l.Message else t.Message end as Message ");
            sql.Append("from DialogMessage t left join DialogMessage_Lan l on t.TAPCode =l.TAPCode  ");
            sql.Append(" and l.lan=@Lan where t.Product=@Product ORDER BY Message ");

            return DbHelperSQL.Query(sql.ToString(), parameters);
        }
    }
}
