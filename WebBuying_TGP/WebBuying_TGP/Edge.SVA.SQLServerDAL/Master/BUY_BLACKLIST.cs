using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:BUY_BLACKLIST
    /// </summary>
    public partial class BUY_BLACKLIST : IBUY_BLACKLIST
    {
        public BUY_BLACKLIST()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("BlackID", "BUY_BLACKLIST");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BlackID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BUY_BLACKLIST");
            strSql.Append(" where BlackID=@BlackID");
            SqlParameter[] parameters = {
					new SqlParameter("@BlackID", SqlDbType.Int,4)
			};
            parameters[0].Value = BlackID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Edge.SVA.Model.BUY_BLACKLIST model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BUY_BLACKLIST(");
            strSql.Append("AccountCode,CustomerName,CustomerCode,ExtgServiceNo,DeliveryAddress,CustomerContact,CustomerContact1,CreditCardNo,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,NickName,MobileNo)");
            strSql.Append(" values (");
            strSql.Append("@AccountCode,@CustomerName,@CustomerCode,@ExtgServiceNo,@DeliveryAddress,@CustomerContact,@CustomerContact1,@CreditCardNo,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@NickName,@MobileNo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AccountCode", SqlDbType.VarChar,64),
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,512),
					new SqlParameter("@CustomerCode", SqlDbType.NVarChar,512),
					new SqlParameter("@ExtgServiceNo", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@CustomerContact", SqlDbType.NVarChar,512),
					new SqlParameter("@CustomerContact1", SqlDbType.NVarChar,512),
					new SqlParameter("@CreditCardNo", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@NickName", SqlDbType.VarChar,64),
                    new SqlParameter("@MobileNo", SqlDbType.VarChar,64)
                                        };
            parameters[0].Value = model.AccountCode;
            parameters[1].Value = model.CustomerName;
            parameters[2].Value = model.CustomerCode;
            parameters[3].Value = model.ExtgServiceNo;
            parameters[4].Value = model.DeliveryAddress;
            parameters[5].Value = model.CustomerContact;
            parameters[6].Value = model.CustomerContact1;
            parameters[7].Value = model.CreditCardNo;
            parameters[8].Value = model.CreatedOn;
            parameters[9].Value = model.CreatedBy;
            parameters[10].Value = model.UpdatedOn;
            parameters[11].Value = model.UpdatedBy;
            parameters[12].Value = model.NickName; 
            parameters[13].Value = model.MobileNo;
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
        public bool Update(Edge.SVA.Model.BUY_BLACKLIST model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BUY_BLACKLIST set ");
            strSql.Append("AccountCode=@AccountCode,");
            strSql.Append("CustomerName=@CustomerName,");
            strSql.Append("CustomerCode=@CustomerCode,");
            strSql.Append("ExtgServiceNo=@ExtgServiceNo,");
            strSql.Append("DeliveryAddress=@DeliveryAddress,");
            strSql.Append("CustomerContact=@CustomerContact,");
            strSql.Append("CustomerContact1=@CustomerContact1,");
            strSql.Append("CreditCardNo=@CreditCardNo,");
            strSql.Append("CreatedOn=@CreatedOn,");
            strSql.Append("CreatedBy=@CreatedBy,");
            strSql.Append("UpdatedOn=@UpdatedOn,");
            strSql.Append("UpdatedBy=@UpdatedBy,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("MobileNo=@MobileNo");
            strSql.Append(" where BlackID=@BlackID");
            SqlParameter[] parameters = {
					new SqlParameter("@AccountCode", SqlDbType.VarChar,64),
					new SqlParameter("@CustomerName", SqlDbType.NVarChar,512),
					new SqlParameter("@CustomerCode", SqlDbType.NVarChar,512),
					new SqlParameter("@ExtgServiceNo", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@CustomerContact", SqlDbType.NVarChar,512),
					new SqlParameter("@CustomerContact1", SqlDbType.NVarChar,512),
					new SqlParameter("@CreditCardNo", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
                    new SqlParameter("@NickName", SqlDbType.VarChar,64),
                    new SqlParameter("@MobileNo", SqlDbType.VarChar,64),
					new SqlParameter("@BlackID", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.AccountCode;
            parameters[1].Value = model.CustomerName;
            parameters[2].Value = model.CustomerCode;
            parameters[3].Value = model.ExtgServiceNo;
            parameters[4].Value = model.DeliveryAddress;
            parameters[5].Value = model.CustomerContact;
            parameters[6].Value = model.CustomerContact1;
            parameters[7].Value = model.CreditCardNo;
            parameters[8].Value = model.CreatedOn;
            parameters[9].Value = model.CreatedBy;
            parameters[10].Value = model.UpdatedOn;
            parameters[11].Value = model.UpdatedBy;
            parameters[12].Value = model.NickName;
            parameters[13].Value = model.MobileNo;
            parameters[14].Value = model.BlackID;

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
        public bool Delete(int BlackID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_BLACKLIST ");
            strSql.Append(" where BlackID=@BlackID");
            SqlParameter[] parameters = {
					new SqlParameter("@BlackID", SqlDbType.Int,4)
			};
            parameters[0].Value = BlackID;

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
        public bool DeleteList(string BlackIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_BLACKLIST ");
            strSql.Append(" where BlackID in (" + BlackIDlist + ")  ");
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
        public Edge.SVA.Model.BUY_BLACKLIST GetModel(int BlackID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BlackID,AccountCode,CustomerName,CustomerCode,ExtgServiceNo,DeliveryAddress,CustomerContact,");
            strSql.Append("CustomerContact1,CreditCardNo,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,NickName,MobileNo from BUY_BLACKLIST ");
            strSql.Append(" where BlackID=@BlackID");
            SqlParameter[] parameters = {
					new SqlParameter("@BlackID", SqlDbType.Int,4)
			};
            parameters[0].Value = BlackID;

            Edge.SVA.Model.BUY_BLACKLIST model = new Edge.SVA.Model.BUY_BLACKLIST();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["BlackID"] != null && ds.Tables[0].Rows[0]["BlackID"].ToString() != "")
                {
                    model.BlackID = int.Parse(ds.Tables[0].Rows[0]["BlackID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AccountCode"] != null && ds.Tables[0].Rows[0]["AccountCode"].ToString() != "")
                {
                    model.AccountCode = ds.Tables[0].Rows[0]["AccountCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerName"] != null && ds.Tables[0].Rows[0]["CustomerName"].ToString() != "")
                {
                    model.CustomerName = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerCode"] != null && ds.Tables[0].Rows[0]["CustomerCode"].ToString() != "")
                {
                    model.CustomerCode = ds.Tables[0].Rows[0]["CustomerCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ExtgServiceNo"] != null && ds.Tables[0].Rows[0]["ExtgServiceNo"].ToString() != "")
                {
                    model.ExtgServiceNo = ds.Tables[0].Rows[0]["ExtgServiceNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DeliveryAddress"] != null && ds.Tables[0].Rows[0]["DeliveryAddress"].ToString() != "")
                {
                    model.DeliveryAddress = ds.Tables[0].Rows[0]["DeliveryAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerContact"] != null && ds.Tables[0].Rows[0]["CustomerContact"].ToString() != "")
                {
                    model.CustomerContact = ds.Tables[0].Rows[0]["CustomerContact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomerContact1"] != null && ds.Tables[0].Rows[0]["CustomerContact1"].ToString() != "")
                {
                    model.CustomerContact1 = ds.Tables[0].Rows[0]["CustomerContact1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreditCardNo"] != null && ds.Tables[0].Rows[0]["CreditCardNo"].ToString() != "")
                {
                    model.CreditCardNo = ds.Tables[0].Rows[0]["CreditCardNo"].ToString();
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
                if (ds.Tables[0].Rows[0]["NickName"] != null && ds.Tables[0].Rows[0]["NickName"].ToString() != "")
                {
                    model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MobileNo"] != null && ds.Tables[0].Rows[0]["MobileNo"].ToString() != "")
                {
                    model.MobileNo = ds.Tables[0].Rows[0]["MobileNo"].ToString();
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
            strSql.Append("select BlackID,AccountCode,CustomerName,CustomerCode,ExtgServiceNo,DeliveryAddress,CustomerContact,");
            strSql.Append("CustomerContact1,CreditCardNo,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,NickName,MobileNo ");
            strSql.Append(" FROM BUY_BLACKLIST ");
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
            strSql.Append(" BlackID,AccountCode,CustomerName,CustomerCode,ExtgServiceNo,DeliveryAddress,CustomerContact,");
            strSql.Append("CustomerContact1,CreditCardNo,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,NickName,MobileNo ");
            strSql.Append(" FROM BUY_BLACKLIST ");
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
            strSql.Append("select count(1) FROM BUY_BLACKLIST ");
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
                strSql.Append("order by T.BlackID desc");
            }
            strSql.Append(")AS Row, T.*  from BUY_BLACKLIST T ");
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
            parameters[0].Value = "BUY_BLACKLIST";
            parameters[1].Value = "BlackID";
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

