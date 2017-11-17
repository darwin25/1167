using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_COLOR
    /// </summary>
    public partial class BUY_COLOR : IBUY_COLOR
    {
        public BUY_COLOR()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ColorID", "BUY_COLOR");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ColorCode, int ColorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_COLOR");
            strSql.Append(" where ColorCode=@ColorCode and ColorID=@ColorID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ColorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ColorID", SqlDbType.Int,4)			};
            parameters[0].Value = ColorCode;
            parameters[1].Value = ColorID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.BUY_COLOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_COLOR(");
            strSql.Append("ColorCode,ColorName1,ColorName2,ColorName3,ColorPicFile,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,RGB)");
            strSql.Append(" values (");
            strSql.Append("@ColorCode,@ColorName1,@ColorName2,@ColorName3,@ColorPicFile,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@RGB)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ColorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ColorName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ColorName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ColorName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ColorPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@RGB", SqlDbType.VarChar,64)
                                        };
            parameters[0].Value = model.ColorCode;
            parameters[1].Value = model.ColorName1;
            parameters[2].Value = model.ColorName2;
            parameters[3].Value = model.ColorName3;
            parameters[4].Value = model.ColorPicFile;
            parameters[5].Value = model.CreatedOn;
            parameters[6].Value = model.CreatedBy;
            parameters[7].Value = model.UpdatedOn;
            parameters[8].Value = model.UpdatedBy;
            parameters[9].Value = model.RGB;
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
        public bool Update(Edge.SVA.Model.BUY_COLOR model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_COLOR set ");
            strSql.Append("ColorCode=@ColorCode,");
            strSql.Append("ColorName1=@ColorName1,");
            strSql.Append("ColorName2=@ColorName2,");
            strSql.Append("ColorName3=@ColorName3,");
            strSql.Append("ColorPicFile=@ColorPicFile,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("RGB=@RGB");
            strSql.Append(" where ColorID=@ColorID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ColorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ColorName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ColorName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ColorName3", SqlDbType.NVarChar,512),
					new SqlParameter("@ColorPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@RGB", SqlDbType.VarChar,64),
					new SqlParameter("@ColorID", SqlDbType.Int,4)
					};
            parameters[0].Value = model.ColorCode;
            parameters[1].Value = model.ColorName1;
            parameters[2].Value = model.ColorName2;
            parameters[3].Value = model.ColorName3;
            parameters[4].Value = model.ColorPicFile;
            parameters[5].Value = model.CreatedOn;
            parameters[6].Value = model.CreatedBy;
            parameters[7].Value = model.UpdatedOn;
            parameters[8].Value = model.UpdatedBy;
            parameters[9].Value = model.RGB;
            parameters[10].Value = model.ColorID;


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
        public bool Delete(int ColorID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_COLOR ");
            strSql.Append(" where ColorID=@ColorID");
            SqlParameter[] parameters = {
					new SqlParameter("@ColorID", SqlDbType.Int,4)
			};
            parameters[0].Value = ColorID;

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
        public bool Delete(string ColorCode, int ColorID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_COLOR ");
            strSql.Append(" where ColorCode=@ColorCode and ColorID=@ColorID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ColorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ColorID", SqlDbType.Int,4)			};
            parameters[0].Value = ColorCode;
            parameters[1].Value = ColorID;

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
        public bool DeleteList(string ColorIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_COLOR ");
            strSql.Append(" where ColorID in (" + ColorIDlist + ")  ");
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
        public Edge.SVA.Model.BUY_COLOR GetModel(int ColorID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ColorID,ColorCode,ColorName1,ColorName2,ColorName3,ColorPicFile,CreatedOn,CreatedBy,");
            strSql.Append("UpdatedOn,UpdatedBy,RGB from BUY_COLOR ");
            strSql.Append(" where ColorID=@ColorID");
            SqlParameter[] parameters = {
					new SqlParameter("@ColorID", SqlDbType.Int,4)
			};
            parameters[0].Value = ColorID;

            Edge.SVA.Model.BUY_COLOR model = new Edge.SVA.Model.BUY_COLOR();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ColorID"] != null && ds.Tables[0].Rows[0]["ColorID"].ToString() != "")
                {
                    model.ColorID = int.Parse(ds.Tables[0].Rows[0]["ColorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ColorCode"] != null && ds.Tables[0].Rows[0]["ColorCode"].ToString() != "")
                {
                    model.ColorCode = ds.Tables[0].Rows[0]["ColorCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ColorName1"] != null && ds.Tables[0].Rows[0]["ColorName1"].ToString() != "")
                {
                    model.ColorName1 = ds.Tables[0].Rows[0]["ColorName1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ColorName2"] != null && ds.Tables[0].Rows[0]["ColorName2"].ToString() != "")
                {
                    model.ColorName2 = ds.Tables[0].Rows[0]["ColorName2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ColorName3"] != null && ds.Tables[0].Rows[0]["ColorName3"].ToString() != "")
                {
                    model.ColorName3 = ds.Tables[0].Rows[0]["ColorName3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ColorPicFile"] != null && ds.Tables[0].Rows[0]["ColorPicFile"].ToString() != "")
                {
                    model.ColorPicFile = ds.Tables[0].Rows[0]["ColorPicFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedOn"] != null && ds.Tables[0].Rows[0]["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedBy"] != null && ds.Tables[0].Rows[0]["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedOn"] != null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedBy"] != null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RGB"] != null && ds.Tables[0].Rows[0]["RGB"].ToString() != "")
                {
                    model.RGB = ds.Tables[0].Rows[0]["RGB"].ToString();
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
            strSql.Append("select ColorID,ColorCode,ColorName1,ColorName2,ColorName3,ColorPicFile,CreatedOn,CreatedBy,");
            strSql.Append("UpdatedOn,UpdatedBy,RGB from BUY_COLOR ");
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
            strSql.Append(" ColorID,ColorCode,ColorName1,ColorName2,ColorName3,ColorPicFile,CreatedOn,CreatedBy,");
            strSql.Append("UpdatedOn,UpdatedBy,RGB from BUY_COLOR ");
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
            strSql.Append("select count(1) FROM BUY_COLOR ");
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
                strSql.Append("order by T.ColorID desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_COLOR T ");
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
            parameters[0].Value = "BUY_COLOR";
            parameters[1].Value = "ColorID";
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

