using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Product
	/// </summary>
	public partial class Product:IProduct
	{
		public Product()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Product");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,512)};
			parameters[0].Value = ProdCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Product(");
			strSql.Append("ProdCode,ProdName1,ProdName2,ProdName3,DepartCode,NonSale,ProdPicFile,BrandID,ProdType,ProdNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ProdCode,@ProdName1,@ProdName2,@ProdName3,@DepartCode,@NonSale,@ProdPicFile,@BrandID,@ProdType,@ProdNote,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,512),
					new SqlParameter("@ProdName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdName3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,512),
					new SqlParameter("@NonSale", SqlDbType.Int,4),
					new SqlParameter("@ProdPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@ProdType", SqlDbType.Int,4),
					new SqlParameter("@ProdNote", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.ProdName1;
			parameters[2].Value = model.ProdName2;
			parameters[3].Value = model.ProdName3;
			parameters[4].Value = model.DepartCode;
			parameters[5].Value = model.NonSale;
			parameters[6].Value = model.ProdPicFile;
			parameters[7].Value = model.BrandID;
			parameters[8].Value = model.ProdType;
			parameters[9].Value = model.ProdNote;
			parameters[10].Value = model.CreatedOn;
			parameters[11].Value = model.CreatedBy;
			parameters[12].Value = model.UpdatedOn;
			parameters[13].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Product set ");
			strSql.Append("ProdName1=@ProdName1,");
			strSql.Append("ProdName2=@ProdName2,");
			strSql.Append("ProdName3=@ProdName3,");
			strSql.Append("DepartCode=@DepartCode,");
			strSql.Append("NonSale=@NonSale,");
			strSql.Append("ProdPicFile=@ProdPicFile,");
			strSql.Append("BrandID=@BrandID,");
			strSql.Append("ProdType=@ProdType,");
			strSql.Append("ProdNote=@ProdNote,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdName1", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdName2", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdName3", SqlDbType.NVarChar,512),
					new SqlParameter("@DepartCode", SqlDbType.VarChar,512),
					new SqlParameter("@NonSale", SqlDbType.Int,4),
					new SqlParameter("@ProdPicFile", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@ProdType", SqlDbType.Int,4),
					new SqlParameter("@ProdNote", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ProdName1;
			parameters[1].Value = model.ProdName2;
			parameters[2].Value = model.ProdName3;
			parameters[3].Value = model.DepartCode;
			parameters[4].Value = model.NonSale;
			parameters[5].Value = model.ProdPicFile;
			parameters[6].Value = model.BrandID;
			parameters[7].Value = model.ProdType;
			parameters[8].Value = model.ProdNote;
			parameters[9].Value = model.CreatedOn;
			parameters[10].Value = model.CreatedBy;
			parameters[11].Value = model.UpdatedOn;
			parameters[12].Value = model.UpdatedBy;
			parameters[13].Value = model.ProdCode;

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
		public bool Delete(string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product ");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,512)};
			parameters[0].Value = ProdCode;

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
		public bool DeleteList(string ProdCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Product ");
			strSql.Append(" where ProdCode in ("+ProdCodelist + ")  ");
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
		public Edge.SVA.Model.Product GetModel(string ProdCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProdCode,ProdName1,ProdName2,ProdName3,DepartCode,NonSale,ProdPicFile,BrandID,ProdType,ProdNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Product ");
			strSql.Append(" where ProdCode=@ProdCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,512)};
			parameters[0].Value = ProdCode;

			Edge.SVA.Model.Product model=new Edge.SVA.Model.Product();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdName1"]!=null && ds.Tables[0].Rows[0]["ProdName1"].ToString()!="")
				{
					model.ProdName1=ds.Tables[0].Rows[0]["ProdName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdName2"]!=null && ds.Tables[0].Rows[0]["ProdName2"].ToString()!="")
				{
					model.ProdName2=ds.Tables[0].Rows[0]["ProdName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdName3"]!=null && ds.Tables[0].Rows[0]["ProdName3"].ToString()!="")
				{
					model.ProdName3=ds.Tables[0].Rows[0]["ProdName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepartCode"]!=null && ds.Tables[0].Rows[0]["DepartCode"].ToString()!="")
				{
					model.DepartCode=ds.Tables[0].Rows[0]["DepartCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NonSale"]!=null && ds.Tables[0].Rows[0]["NonSale"].ToString()!="")
				{
					model.NonSale=int.Parse(ds.Tables[0].Rows[0]["NonSale"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdPicFile"]!=null && ds.Tables[0].Rows[0]["ProdPicFile"].ToString()!="")
				{
					model.ProdPicFile=ds.Tables[0].Rows[0]["ProdPicFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdType"]!=null && ds.Tables[0].Rows[0]["ProdType"].ToString()!="")
				{
					model.ProdType=int.Parse(ds.Tables[0].Rows[0]["ProdType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdNote"]!=null && ds.Tables[0].Rows[0]["ProdNote"].ToString()!="")
				{
					model.ProdNote=ds.Tables[0].Rows[0]["ProdNote"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
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
			strSql.Append("select ProdCode,ProdName1,ProdName2,ProdName3,DepartCode,NonSale,ProdPicFile,BrandID,ProdType,ProdNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Product ");
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
			strSql.Append(" ProdCode,ProdName1,ProdName2,ProdName3,DepartCode,NonSale,ProdPicFile,BrandID,ProdType,ProdNote,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Product ");
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
            parameters[0].Value = "Product";
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
            sql.Append("select count(*) from Product ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

