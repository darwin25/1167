using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_ImportCouponUID_D
	/// </summary>
	public partial class Ord_ImportCouponUID_D:IOrd_ImportCouponUID_D
	{
		public Ord_ImportCouponUID_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "Ord_ImportCouponUID_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_ImportCouponUID_D");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Ord_ImportCouponUID_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_ImportCouponUID_D(");
			strSql.Append("ImportCouponNumber,CouponTypeID,CouponUID,ExpiryDate,BatchID,Denomination)");
			strSql.Append(" values (");
			strSql.Append("@ImportCouponNumber,@CouponTypeID,@CouponUID,@ExpiryDate,@BatchID,@Denomination)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@CouponUID", SqlDbType.VarChar,512),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@BatchID", SqlDbType.VarChar,512),
					new SqlParameter("@Denomination", SqlDbType.Money,8)};
			parameters[0].Value = model.ImportCouponNumber;
			parameters[1].Value = model.CouponTypeID;
			parameters[2].Value = model.CouponUID;
			parameters[3].Value = model.ExpiryDate;
			parameters[4].Value = model.BatchID;
			parameters[5].Value = model.Denomination;

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
		public bool Update(Edge.SVA.Model.Ord_ImportCouponUID_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_ImportCouponUID_D set ");
			strSql.Append("ImportCouponNumber=@ImportCouponNumber,");
			strSql.Append("CouponTypeID=@CouponTypeID,");
			strSql.Append("CouponUID=@CouponUID,");
			strSql.Append("ExpiryDate=@ExpiryDate,");
			strSql.Append("BatchID=@BatchID,");
			strSql.Append("Denomination=@Denomination");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512),
					new SqlParameter("@CouponTypeID", SqlDbType.Int,4),
					new SqlParameter("@CouponUID", SqlDbType.VarChar,512),
					new SqlParameter("@ExpiryDate", SqlDbType.DateTime),
					new SqlParameter("@BatchID", SqlDbType.VarChar,512),
					new SqlParameter("@Denomination", SqlDbType.Money,8),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.ImportCouponNumber;
			parameters[1].Value = model.CouponTypeID;
			parameters[2].Value = model.CouponUID;
			parameters[3].Value = model.ExpiryDate;
			parameters[4].Value = model.BatchID;
			parameters[5].Value = model.Denomination;
			parameters[6].Value = model.KeyID;

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
			strSql.Append("delete from Ord_ImportCouponUID_D ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string KeyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_ImportCouponUID_D ");
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
		public Edge.SVA.Model.Ord_ImportCouponUID_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,ImportCouponNumber,CouponTypeID,CouponUID,ExpiryDate,BatchID,Denomination from Ord_ImportCouponUID_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Ord_ImportCouponUID_D model=new Edge.SVA.Model.Ord_ImportCouponUID_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ImportCouponNumber"]!=null && ds.Tables[0].Rows[0]["ImportCouponNumber"].ToString()!="")
				{
					model.ImportCouponNumber=ds.Tables[0].Rows[0]["ImportCouponNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CouponTypeID"]!=null && ds.Tables[0].Rows[0]["CouponTypeID"].ToString()!="")
				{
					model.CouponTypeID=int.Parse(ds.Tables[0].Rows[0]["CouponTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponUID"]!=null && ds.Tables[0].Rows[0]["CouponUID"].ToString()!="")
				{
					model.CouponUID=ds.Tables[0].Rows[0]["CouponUID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ExpiryDate"]!=null && ds.Tables[0].Rows[0]["ExpiryDate"].ToString()!="")
				{
					model.ExpiryDate=DateTime.Parse(ds.Tables[0].Rows[0]["ExpiryDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BatchID"]!=null && ds.Tables[0].Rows[0]["BatchID"].ToString()!="")
				{
					model.BatchID=ds.Tables[0].Rows[0]["BatchID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Denomination"]!=null && ds.Tables[0].Rows[0]["Denomination"].ToString()!="")
				{
					model.Denomination=decimal.Parse(ds.Tables[0].Rows[0]["Denomination"].ToString());
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
			strSql.Append("select KeyID,ImportCouponNumber,CouponTypeID,CouponUID,ExpiryDate,BatchID,Denomination ");
			strSql.Append(" FROM Ord_ImportCouponUID_D ");
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
			strSql.Append(" KeyID,ImportCouponNumber,CouponTypeID,CouponUID,ExpiryDate,BatchID,Denomination ");
			strSql.Append(" FROM Ord_ImportCouponUID_D ");
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
            parameters[0].Value = "Ord_ImportCouponUID_D";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Ord_ImportCouponUID_D ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

