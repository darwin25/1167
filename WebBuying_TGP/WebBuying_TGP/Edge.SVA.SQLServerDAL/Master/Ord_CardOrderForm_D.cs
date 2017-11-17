using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_CardOrderForm_D
	/// </summary>
	public partial class Ord_CardOrderForm_D:IOrd_CardOrderForm_D
	{
		public Ord_CardOrderForm_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CardGradeID", "Ord_CardOrderForm_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CardGradeID,int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_CardOrderForm_D");
			strSql.Append(" where CardGradeID=@CardGradeID and KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardGradeID", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = CardGradeID;
			parameters[1].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Ord_CardOrderForm_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CardOrderForm_D(");
			strSql.Append("CardOrderFormNumber,BrandID,CardTypeID,CardGradeID,CardQty)");
			strSql.Append(" values (");
			strSql.Append("@CardOrderFormNumber,@BrandID,@CardTypeID,@CardGradeID,@CardQty)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CardOrderFormNumber", SqlDbType.VarChar,64),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@CardTypeID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4),
					new SqlParameter("@CardQty", SqlDbType.Int,4)};
			parameters[0].Value = model.CardOrderFormNumber;
			parameters[1].Value = model.BrandID;
			parameters[2].Value = model.CardTypeID;
			parameters[3].Value = model.CardGradeID;
			parameters[4].Value = model.CardQty;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Edge.SVA.Model.Ord_CardOrderForm_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CardOrderForm_D set ");
			strSql.Append("CardOrderFormNumber=@CardOrderFormNumber,");
			strSql.Append("BrandID=@BrandID,");
			strSql.Append("CardTypeID=@CardTypeID,");
			strSql.Append("CardQty=@CardQty");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@CardOrderFormNumber", SqlDbType.VarChar,64),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@CardTypeID", SqlDbType.Int,4),
					new SqlParameter("@CardQty", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4),
					new SqlParameter("@CardGradeID", SqlDbType.Int,4)};
			parameters[0].Value = model.CardOrderFormNumber;
			parameters[1].Value = model.BrandID;
			parameters[2].Value = model.CardTypeID;
			parameters[3].Value = model.CardQty;
			parameters[4].Value = model.KeyID;
			parameters[5].Value = model.CardGradeID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CardOrderForm_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int CardGradeID,int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CardOrderForm_D ");
			strSql.Append(" where CardGradeID=@CardGradeID and KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CardGradeID", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = CardGradeID;
			parameters[1].Value = KeyID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string KeyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CardOrderForm_D ");
			strSql.Append(" where KeyID in ("+KeyIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Edge.SVA.Model.Ord_CardOrderForm_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,CardOrderFormNumber,BrandID,CardTypeID,CardGradeID,CardQty from Ord_CardOrderForm_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Ord_CardOrderForm_D model=new Edge.SVA.Model.Ord_CardOrderForm_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardOrderFormNumber"]!=null && ds.Tables[0].Rows[0]["CardOrderFormNumber"].ToString()!="")
				{
					model.CardOrderFormNumber=ds.Tables[0].Rows[0]["CardOrderFormNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardTypeID"]!=null && ds.Tables[0].Rows[0]["CardTypeID"].ToString()!="")
				{
					model.CardTypeID=int.Parse(ds.Tables[0].Rows[0]["CardTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardGradeID"]!=null && ds.Tables[0].Rows[0]["CardGradeID"].ToString()!="")
				{
					model.CardGradeID=int.Parse(ds.Tables[0].Rows[0]["CardGradeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CardQty"]!=null && ds.Tables[0].Rows[0]["CardQty"].ToString()!="")
				{
					model.CardQty=int.Parse(ds.Tables[0].Rows[0]["CardQty"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select KeyID,CardOrderFormNumber,BrandID,CardTypeID,CardGradeID,CardQty ");
			strSql.Append(" FROM Ord_CardOrderForm_D ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" KeyID,CardOrderFormNumber,BrandID,CardTypeID,CardGradeID,CardQty ");
			strSql.Append(" FROM Ord_CardOrderForm_D ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@StatfldName",SqlDbType.VarChar,255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.NText),
					};
            parameters[0].Value = "Ord_CardOrderForm_D";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 1;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Ord_CardOrderForm_D ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

