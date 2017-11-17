using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.SQLServerDAL
{
    public abstract class BaseDAL : IDAL.IBaseDAL
    {
        protected abstract string TableName { get; }

        protected bool IsReCount { get; set; }

        public string Order { get; set; }
        public string Fields { get; set; }
        public int Timeout { get; set; }
        public bool Ascending { get; set; }
        public string StrWhere { get; set; }

        public BaseDAL()
        {
            Initialization();
        }

        /// <summary>
        /// 获取分页数据，并在ds.Tables[1].Rows[0]["Total"]返回记录
        /// </summary>
        /// <param name="PageSize">分页大小</param>
        /// <param name="PageIndex">分页索引(从0开始)</param>
        /// <param name="strWhere">过滤条件</param>
        /// <param name="filedOrder">排序字段</param>
        /// <param name="fields">搜索的字段</param>
        /// <param name="times">Timeout时间</param>
        /// <returns></returns>
        public DataSet GetList(int pageSize, int pageIndex)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 512),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,512),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = this.TableName;
            parameters[1].Value = this.Fields;
            parameters[2].Value = this.Order;
            parameters[3].Value = "";
            parameters[4].Value = pageSize;
            parameters[5].Value = pageIndex;
            parameters[6].Value = this.IsReCount ? 1 : 0;
            parameters[7].Value = this.Ascending ? 0 : 1;
            parameters[8].Value = this.StrWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds", this.Timeout);
        }

        public DataSet GetList(int pageSize, int pageIndex, out int recordCount)
        {
            recordCount = 0;
            this.IsReCount = true;
            DataSet ds = this.GetList(pageSize, pageIndex);
            if (ds == null || ds.Tables.Count < 1) return ds;

            recordCount = int.TryParse(ds.Tables[1].Rows[0]["Total"].ToString(), out recordCount) ? recordCount : 0;

            return ds;
        }

        protected virtual void Initialization()
        {
            this.Fields = "*";
            this.Timeout = 15;
            this.Ascending = true;
            this.IsReCount = false;
        }

    }

}
