using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_PRODUCT_PIC
    /// </summary>
    public partial class BUY_PRODUCT_PIC : IBUY_PRODUCT_PIC
    {
        public BUY_PRODUCT_PIC()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("KeyID", "BUY_PRODUCT_PIC");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int KeyID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_PRODUCT_PIC");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.BUY_PRODUCT_PIC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_PRODUCT_PIC(");
            strSql.Append("ProdCode,ProductThumbnailsFile,ProductFullPicFile,ProductPicNote1,ProductPicNote2,ProductPicNote3,");
            strSql.Append("IsVideo,Is360Pic,IsSizeCategory)");
            strSql.Append(" values (");
            strSql.Append("@ProdCode,@ProductThumbnailsFile,@ProductFullPicFile,@ProductPicNote1,@ProductPicNote2,@ProductPicNote3,");
            strSql.Append("@IsVideo,@Is360Pic,@IsSizeCategory)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductThumbnailsFile", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductFullPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductPicNote1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductPicNote2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductPicNote3", SqlDbType.NVarChar,512),
                    new SqlParameter("@IsVideo", SqlDbType.Int,4),
                    new SqlParameter("@Is360Pic", SqlDbType.Int,4),
                    new SqlParameter("@IsSizeCategory", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.ProdCode;
            parameters[1].Value = model.ProductThumbnailsFile;
            parameters[2].Value = model.ProductFullPicFile;
            parameters[3].Value = model.ProductPicNote1;
            parameters[4].Value = model.ProductPicNote2;
            parameters[5].Value = model.ProductPicNote3;
            parameters[6].Value = model.IsVideo;
            parameters[7].Value = model.Is360Pic;
            parameters[8].Value = model.IsSizeCategory;
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
        public bool Update(Edge.SVA.Model.BUY_PRODUCT_PIC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_PRODUCT_PIC set ");
            strSql.Append("ProdCode=@ProdCode,");
            strSql.Append("ProductThumbnailsFile=@ProductThumbnailsFile,");
            strSql.Append("ProductFullPicFile=@ProductFullPicFile,");
            strSql.Append("ProductPicNote1=@ProductPicNote1,");
            strSql.Append("ProductPicNote2=@ProductPicNote2,");
            strSql.Append("ProductPicNote3=@ProductPicNote3,");
            strSql.Append("IsVideo=@IsVideo,");
            strSql.Append("Is360Pic=@Is360Pic,");
            strSql.Append("IsSizeCategory=@IsSizeCategory");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProductThumbnailsFile", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductFullPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductPicNote1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductPicNote2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProductPicNote3", SqlDbType.NVarChar,512),
                    new SqlParameter("@IsVideo", SqlDbType.Int,4),
                    new SqlParameter("@Is360Pic", SqlDbType.Int,4),
                    new SqlParameter("@IsSizeCategory", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProdCode;
            parameters[1].Value = model.ProductThumbnailsFile;
            parameters[2].Value = model.ProductFullPicFile;
            parameters[3].Value = model.ProductPicNote1;
            parameters[4].Value = model.ProductPicNote2;
            parameters[5].Value = model.ProductPicNote3;
            parameters[6].Value = model.IsVideo;
            parameters[7].Value = model.Is360Pic;
            parameters[8].Value = model.IsSizeCategory;
            parameters[9].Value = model.KeyID;

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
        public bool Delete(int KeyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_PRODUCT_PIC ");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

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
        public bool DeleteList(string KeyIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_PRODUCT_PIC ");
            strSql.Append(" where KeyID in (" + KeyIDlist + ")  ");
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
        public Edge.SVA.Model.BUY_PRODUCT_PIC GetModel(int KeyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KeyID,ProdCode,ProductThumbnailsFile,ProductFullPicFile,ProductPicNote1,");
            strSql.Append("ProductPicNote2,ProductPicNote3,IsVideo,Is360Pic,IsSizeCategory from BUY_PRODUCT_PIC ");
            strSql.Append(" where KeyID=@KeyID");
            SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
            parameters[0].Value = KeyID;

            Edge.SVA.Model.BUY_PRODUCT_PIC model = new Edge.SVA.Model.BUY_PRODUCT_PIC();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KeyID"] != null && ds.Tables[0].Rows[0]["KeyID"].ToString() != "")
                {
                    model.KeyID = int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProdCode"] != null && ds.Tables[0].Rows[0]["ProdCode"].ToString() != "")
                {
                    model.ProdCode = ds.Tables[0].Rows[0]["ProdCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductThumbnailsFile"] != null && ds.Tables[0].Rows[0]["ProductThumbnailsFile"].ToString() != "")
                {
                    model.ProductThumbnailsFile = ds.Tables[0].Rows[0]["ProductThumbnailsFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductFullPicFile"] != null && ds.Tables[0].Rows[0]["ProductFullPicFile"].ToString() != "")
                {
                    model.ProductFullPicFile = ds.Tables[0].Rows[0]["ProductFullPicFile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductPicNote1"] != null && ds.Tables[0].Rows[0]["ProductPicNote1"].ToString() != "")
                {
                    model.ProductPicNote1 = ds.Tables[0].Rows[0]["ProductPicNote1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductPicNote2"] != null && ds.Tables[0].Rows[0]["ProductPicNote2"].ToString() != "")
                {
                    model.ProductPicNote2 = ds.Tables[0].Rows[0]["ProductPicNote2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ProductPicNote3"] != null && ds.Tables[0].Rows[0]["ProductPicNote3"].ToString() != "")
                {
                    model.ProductPicNote3 = ds.Tables[0].Rows[0]["ProductPicNote3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsVideo"] != null && ds.Tables[0].Rows[0]["IsVideo"].ToString() != "")
                {
                    model.IsVideo = Convert.ToInt32(ds.Tables[0].Rows[0]["IsVideo"]);
                }
                if (ds.Tables[0].Rows[0]["Is360Pic"] != null && ds.Tables[0].Rows[0]["Is360Pic"].ToString() != "")
                {
                    model.Is360Pic = Convert.ToInt32(ds.Tables[0].Rows[0]["Is360Pic"]);
                }
                if (ds.Tables[0].Rows[0]["IsSizeCategory"] != null && ds.Tables[0].Rows[0]["IsSizeCategory"].ToString() != "")
                {
                    model.IsSizeCategory = Convert.ToInt32(ds.Tables[0].Rows[0]["IsSizeCategory"]);
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
            strSql.Append("select KeyID,ProdCode,ProductThumbnailsFile,ProductFullPicFile,ProductPicNote1,");
            strSql.Append("ProductPicNote2,ProductPicNote3,IsVideo,Is360Pic,IsSizeCategory from BUY_PRODUCT_PIC ");
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
            strSql.Append(" KeyID,ProdCode,ProductThumbnailsFile,ProductFullPicFile,ProductPicNote1,");
            strSql.Append("ProductPicNote2,ProductPicNote3,IsVideo,Is360Pic,IsSizeCategory from BUY_PRODUCT_PIC ");
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
            strSql.Append("select count(1) FROM BUY_PRODUCT_PIC ");
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
                strSql.Append("order by T.KeyID desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_PRODUCT_PIC T ");
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
            parameters[0].Value = "BUY_PRODUCT_PIC";
            parameters[1].Value = "KeyID";
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

