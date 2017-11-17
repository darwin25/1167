using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:USEFULEXPRESSIONS
    /// </summary>
    public partial class USEFULEXPRESSIONS : IUSEFULEXPRESSIONS
    {
        public USEFULEXPRESSIONS()
        { }
        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("USEFULEXPRESSIONSID", "USEFULEXPRESSIONS");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int USEFULEXPRESSIONSID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from USEFULEXPRESSIONS");
            strSql.Append(" where USEFULEXPRESSIONSID=@USEFULEXPRESSIONSID");
            SqlParameter[] parameters = {
					new SqlParameter("@USEFULEXPRESSIONSID", SqlDbType.Int,4)
			};
            parameters[0].Value = USEFULEXPRESSIONSID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.USEFULEXPRESSIONS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into USEFULEXPRESSIONS(");
            strSql.Append("PhraseTitle1,PhraseTitle2,PhraseTitle3,PhraseContent1,PhraseContent2,PhraseContent3,CampaignID,PhrasePicFile,Code)");
            strSql.Append(" values (");
            strSql.Append("@PhraseTitle1,@PhraseTitle2,@PhraseTitle3,@PhraseContent1,@PhraseContent2,@PhraseContent3,@CampaignID,@PhrasePicFile,@Code)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PhraseTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseContent1", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseContent2", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseContent3", SqlDbType.NVarChar,512),
					new SqlParameter("@CampaignID", SqlDbType.Int,4),
					new SqlParameter("@PhrasePicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Code", SqlDbType.VarChar,64)};
            parameters[0].Value = model.PhraseTitle1;
            parameters[1].Value = model.PhraseTitle2;
            parameters[2].Value = model.PhraseTitle3;
            parameters[3].Value = model.PhraseContent1;
            parameters[4].Value = model.PhraseContent2;
            parameters[5].Value = model.PhraseContent3;
            parameters[6].Value = model.CampaignID;
            parameters[7].Value = model.PhrasePicFile;
            parameters[8].Value = model.Code;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Edge.SVA.Model.USEFULEXPRESSIONS model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update USEFULEXPRESSIONS set ");
            strSql.Append("PhraseTitle1=@PhraseTitle1,");
            strSql.Append("PhraseTitle2=@PhraseTitle2,");
            strSql.Append("PhraseTitle3=@PhraseTitle3,");
            strSql.Append("PhraseContent1=@PhraseContent1,");
            strSql.Append("PhraseContent2=@PhraseContent2,");
            strSql.Append("PhraseContent3=@PhraseContent3,");
            strSql.Append("CampaignID=@CampaignID,");
            strSql.Append("PhrasePicFile=@PhrasePicFile,");
            strSql.Append("Code=@Code");
            strSql.Append(" where USEFULEXPRESSIONSID=@USEFULEXPRESSIONSID");
            SqlParameter[] parameters = {
					new SqlParameter("@PhraseTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseContent1", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseContent2", SqlDbType.NVarChar,512),
					new SqlParameter("@PhraseContent3", SqlDbType.NVarChar,512),
					new SqlParameter("@CampaignID", SqlDbType.Int,4),
					new SqlParameter("@PhrasePicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Code", SqlDbType.VarChar,64),
					new SqlParameter("@USEFULEXPRESSIONSID", SqlDbType.Int,4)};
            parameters[0].Value = model.PhraseTitle1;
            parameters[1].Value = model.PhraseTitle2;
            parameters[2].Value = model.PhraseTitle3;
            parameters[3].Value = model.PhraseContent1;
            parameters[4].Value = model.PhraseContent2;
            parameters[5].Value = model.PhraseContent3;
            parameters[6].Value = model.CampaignID;
            parameters[7].Value = model.PhrasePicFile;
            parameters[8].Value = model.Code;
            parameters[9].Value = model.USEFULEXPRESSIONSID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int USEFULEXPRESSIONSID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from USEFULEXPRESSIONS ");
            strSql.Append(" where USEFULEXPRESSIONSID=@USEFULEXPRESSIONSID");
            SqlParameter[] parameters = {
					new SqlParameter("@USEFULEXPRESSIONSID", SqlDbType.Int,4)
			};
            parameters[0].Value = USEFULEXPRESSIONSID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string USEFULEXPRESSIONSIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from USEFULEXPRESSIONS ");
            strSql.Append(" where USEFULEXPRESSIONSID in (" + USEFULEXPRESSIONSIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.USEFULEXPRESSIONS GetModel(int USEFULEXPRESSIONSID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 USEFULEXPRESSIONSID,PhraseTitle1,PhraseTitle2,PhraseTitle3,PhraseContent1,PhraseContent2,PhraseContent3,CampaignID,PhrasePicFile,Code from USEFULEXPRESSIONS ");
            strSql.Append(" where USEFULEXPRESSIONSID=@USEFULEXPRESSIONSID");
            SqlParameter[] parameters = {
					new SqlParameter("@USEFULEXPRESSIONSID", SqlDbType.Int,4)
			};
            parameters[0].Value = USEFULEXPRESSIONSID;

            Edge.SVA.Model.USEFULEXPRESSIONS model = new Edge.SVA.Model.USEFULEXPRESSIONS();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["USEFULEXPRESSIONSID"] != null && ds.Tables[0].Rows[0]["USEFULEXPRESSIONSID"].ToString() != "")
                {
                    model.USEFULEXPRESSIONSID = int.Parse(ds.Tables[0].Rows[0]["USEFULEXPRESSIONSID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PhraseTitle1"] != null && ds.Tables[0].Rows[0]["PhraseTitle1"].ToString() != "")
                {
                    model.PhraseTitle1 = ds.Tables[0].Rows[0]["PhraseTitle1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhraseTitle2"] != null && ds.Tables[0].Rows[0]["PhraseTitle2"].ToString() != "")
                {
                    model.PhraseTitle2 = ds.Tables[0].Rows[0]["PhraseTitle2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhraseTitle3"] != null && ds.Tables[0].Rows[0]["PhraseTitle3"].ToString() != "")
                {
                    model.PhraseTitle3 = ds.Tables[0].Rows[0]["PhraseTitle3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhraseContent1"] != null && ds.Tables[0].Rows[0]["PhraseContent1"].ToString() != "")
                {
                    model.PhraseContent1 = ds.Tables[0].Rows[0]["PhraseContent1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhraseContent2"] != null && ds.Tables[0].Rows[0]["PhraseContent2"].ToString() != "")
                {
                    model.PhraseContent2 = ds.Tables[0].Rows[0]["PhraseContent2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PhraseContent3"] != null && ds.Tables[0].Rows[0]["PhraseContent3"].ToString() != "")
                {
                    model.PhraseContent3 = ds.Tables[0].Rows[0]["PhraseContent3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CampaignID"] != null && ds.Tables[0].Rows[0]["CampaignID"].ToString() != "")
                {
                    model.CampaignID = int.Parse(ds.Tables[0].Rows[0]["CampaignID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PhrasePicFile"] != null && ds.Tables[0].Rows[0]["PhrasePicFile"].ToString() != "")
                {
                    model.PhrasePicFile = ds.Tables[0].Rows[0]["PhrasePicFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Code"] != null && ds.Tables[0].Rows[0]["Code"].ToString() != "")
                {
                    model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select USEFULEXPRESSIONSID,PhraseTitle1,PhraseTitle2,PhraseTitle3,PhraseContent1,PhraseContent2,PhraseContent3,CampaignID,PhrasePicFile,Code ");
            strSql.Append(" FROM USEFULEXPRESSIONS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" USEFULEXPRESSIONSID,PhraseTitle1,PhraseTitle2,PhraseTitle3,PhraseContent1,PhraseContent2,PhraseContent3,CampaignID,PhrasePicFile,Code ");
            strSql.Append(" FROM USEFULEXPRESSIONS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM USEFULEXPRESSIONS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.USEFULEXPRESSIONSID desc");
            }
            strSql.Append(")AS Row, T.*  from USEFULEXPRESSIONS T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "USEFULEXPRESSIONS";
            parameters[1].Value = "USEFULEXPRESSIONSID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}

