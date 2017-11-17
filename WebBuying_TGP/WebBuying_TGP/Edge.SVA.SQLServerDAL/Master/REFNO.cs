using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:REFNO
	/// </summary>
	public partial class REFNO:IREFNO
	{
		public REFNO()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from REFNO");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6)};
			parameters[0].Value = Code;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.REFNO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into REFNO(");
			strSql.Append("Code,RefDesc,Header,Seq,Length,Auto)");
			strSql.Append(" values (");
			strSql.Append("@Code,@RefDesc,@Header,@Seq,@Length,@Auto)");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6),
					new SqlParameter("@RefDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Header", SqlDbType.VarChar,6),
					new SqlParameter("@Seq", SqlDbType.Int,4),
					new SqlParameter("@Length", SqlDbType.Int,4),
					new SqlParameter("@Auto", SqlDbType.Char,1)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.RefDesc;
			parameters[2].Value = model.Header;
			parameters[3].Value = model.Seq;
			parameters[4].Value = model.Length;
			parameters[5].Value = model.Auto;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            return rows;

            //if (rows > 0)
            //{
            //    return rows;
            //}
            //else
            //{
            //    return rows;
            //}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.REFNO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update REFNO set ");
			strSql.Append("RefDesc=@RefDesc,");
			strSql.Append("Header=@Header,");
			strSql.Append("Seq=@Seq,");
			strSql.Append("Length=@Length,");
			strSql.Append("Auto=@Auto");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@RefDesc", SqlDbType.VarChar,512),
					new SqlParameter("@Header", SqlDbType.VarChar,6),
					new SqlParameter("@Seq", SqlDbType.Int,4),
					new SqlParameter("@Length", SqlDbType.Int,4),
					new SqlParameter("@Auto", SqlDbType.Char,1),
					new SqlParameter("@Code", SqlDbType.VarChar,6)};
			parameters[0].Value = model.RefDesc;
			parameters[1].Value = model.Header;
			parameters[2].Value = model.Seq;
			parameters[3].Value = model.Length;
			parameters[4].Value = model.Auto;
			parameters[5].Value = model.Code;

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
		public bool Delete(string Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from REFNO ");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6)};
			parameters[0].Value = Code;

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
		public bool DeleteList(string Codelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from REFNO ");
			strSql.Append(" where Code in ("+Codelist + ")  ");
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
		public Edge.SVA.Model.REFNO GetModel(string Code)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Code,RefDesc,Header,Seq,Length,Auto from REFNO ");
			strSql.Append(" where Code=@Code ");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,6)};
			parameters[0].Value = Code;

			Edge.SVA.Model.REFNO model=new Edge.SVA.Model.REFNO();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RefDesc"]!=null && ds.Tables[0].Rows[0]["RefDesc"].ToString()!="")
				{
					model.RefDesc=ds.Tables[0].Rows[0]["RefDesc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Header"]!=null && ds.Tables[0].Rows[0]["Header"].ToString()!="")
				{
					model.Header=ds.Tables[0].Rows[0]["Header"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Seq"]!=null && ds.Tables[0].Rows[0]["Seq"].ToString()!="")
				{
					model.Seq=int.Parse(ds.Tables[0].Rows[0]["Seq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Length"]!=null && ds.Tables[0].Rows[0]["Length"].ToString()!="")
				{
					model.Length=int.Parse(ds.Tables[0].Rows[0]["Length"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Auto"]!=null && ds.Tables[0].Rows[0]["Auto"].ToString()!="")
				{
					model.Auto=ds.Tables[0].Rows[0]["Auto"].ToString();
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
			strSql.Append("select Code,RefDesc,Header,Seq,Length,Auto ");
			strSql.Append(" FROM REFNO ");
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
			strSql.Append(" Code,RefDesc,Header,Seq,Length,Auto ");
			strSql.Append(" FROM REFNO ");
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
            parameters[0].Value = "REFNO";
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
            sql.Append("select count(*) from REFNO ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

