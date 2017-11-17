using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_SUPPROD
    /// 创建人：Lisa
    /// 创建时间：2016-02-26
	/// </summary>
	public partial class BUY_SUPPROD:IBUY_SUPPROD
	{
		public BUY_SUPPROD()
		{}
		#region Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string VendorCode,string ProdCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_SUPPROD");
			strSql.Append(" where VendorCode=@VendorCode and ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = VendorCode;
			parameters[1].Value = ProdCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_SUPPROD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_SUPPROD(");
			strSql.Append("VendorCode,ProdCode,SUPPLIER_PRODUCT_CODE,in_tax,Prefer,IsDefault)");
			strSql.Append(" values (");
			strSql.Append("@VendorCode,@ProdCode,@SUPPLIER_PRODUCT_CODE,@in_tax,@Prefer,@IsDefault)");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@SUPPLIER_PRODUCT_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@in_tax", SqlDbType.Money,8),
					new SqlParameter("@Prefer", SqlDbType.Int,4),
					new SqlParameter("@IsDefault", SqlDbType.Int,4)};
			parameters[0].Value = model.VendorCode;
			parameters[1].Value = model.ProdCode;
			parameters[2].Value = model.SUPPLIER_PRODUCT_CODE;
			parameters[3].Value = model.in_tax;
			parameters[4].Value = model.Prefer;
			parameters[5].Value = model.IsDefault;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_SUPPROD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_SUPPROD set ");
			strSql.Append("SUPPLIER_PRODUCT_CODE=@SUPPLIER_PRODUCT_CODE,");
			strSql.Append("in_tax=@in_tax,");
			strSql.Append("Prefer=@Prefer,");
			strSql.Append("IsDefault=@IsDefault");
			strSql.Append(" where VendorCode=@VendorCode and ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_PRODUCT_CODE", SqlDbType.VarChar,64),
					new SqlParameter("@in_tax", SqlDbType.Money,8),
					new SqlParameter("@Prefer", SqlDbType.Int,4),
					new SqlParameter("@IsDefault", SqlDbType.Int,4),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.SUPPLIER_PRODUCT_CODE;
			parameters[1].Value = model.in_tax;
			parameters[2].Value = model.Prefer;
			parameters[3].Value = model.IsDefault;
			parameters[4].Value = model.VendorCode;
			parameters[5].Value = model.ProdCode;

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
		public bool Delete(string VendorCode,string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_SUPPROD ");
			strSql.Append(" where VendorCode=@VendorCode and ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = VendorCode;
			parameters[1].Value = ProdCode;

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
        public bool Delete(string ProdCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BUY_SUPPROD ");
            strSql.Append(" where  ProdCode=@ProdCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)		
                                        };
            parameters[0].Value = ProdCode;

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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_SUPPROD GetModel(string VendorCode,string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VendorCode,ProdCode,SUPPLIER_PRODUCT_CODE,in_tax,Prefer,IsDefault from BUY_SUPPROD ");
			strSql.Append(" where VendorCode=@VendorCode and ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = VendorCode;
			parameters[1].Value = ProdCode;

			Edge.SVA.Model.BUY_SUPPROD model=new Edge.SVA.Model.BUY_SUPPROD();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_SUPPROD DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.BUY_SUPPROD model=new Edge.SVA.Model.BUY_SUPPROD();
			if (row != null)
			{
				if(row["VendorCode"]!=null)
				{
					model.VendorCode=row["VendorCode"].ToString();
				}
				if(row["ProdCode"]!=null)
				{
					model.ProdCode=row["ProdCode"].ToString();
				}
				if(row["SUPPLIER_PRODUCT_CODE"]!=null)
				{
					model.SUPPLIER_PRODUCT_CODE=row["SUPPLIER_PRODUCT_CODE"].ToString();
				}
				if(row["in_tax"]!=null && row["in_tax"].ToString()!="")
				{
					model.in_tax=decimal.Parse(row["in_tax"].ToString());
				}
				if(row["Prefer"]!=null && row["Prefer"].ToString()!="")
				{
					model.Prefer=int.Parse(row["Prefer"].ToString());
				}
				if(row["IsDefault"]!=null && row["IsDefault"].ToString()!="")
				{
					model.IsDefault=int.Parse(row["IsDefault"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VendorCode,ProdCode,SUPPLIER_PRODUCT_CODE,in_tax,Prefer,IsDefault ");
			strSql.Append(" FROM BUY_SUPPROD ");
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
			strSql.Append(" VendorCode,ProdCode,SUPPLIER_PRODUCT_CODE,in_tax,Prefer,IsDefault ");
			strSql.Append(" FROM BUY_SUPPROD ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BUY_SUPPROD ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ProdCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_SUPPROD T ");
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
			parameters[0].Value = "BUY_SUPPROD";
			parameters[1].Value = "ProdCode";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		
	}
}

