using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_ProductAssociated
	/// </summary>
	public partial class BUY_ProductAssociated:IBUY_ProductAssociated
	{
		public BUY_ProductAssociated()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_ProductAssociated"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_ProductAssociated");
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
		public int Add(Edge.SVA.Model.BUY_ProductAssociated model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_ProductAssociated(");
			strSql.Append("ProdCode,SeqNo,AssociatedProdCode,AssociatedProdName,AssociatedProdFile,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@ProdCode,@SeqNo,@AssociatedProdCode,@AssociatedProdName,@AssociatedProdFile,@Note,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@SeqNo", SqlDbType.Int,4),
					new SqlParameter("@AssociatedProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@AssociatedProdName", SqlDbType.NVarChar,512),
					new SqlParameter("@AssociatedProdFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.SeqNo;
			parameters[2].Value = model.AssociatedProdCode;
			parameters[3].Value = model.AssociatedProdName;
			parameters[4].Value = model.AssociatedProdFile;
			parameters[5].Value = model.Note;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_ProductAssociated model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_ProductAssociated set ");
			strSql.Append("ProdCode=@ProdCode,");
			strSql.Append("SeqNo=@SeqNo,");
			strSql.Append("AssociatedProdCode=@AssociatedProdCode,");
			strSql.Append("AssociatedProdName=@AssociatedProdName,");
			strSql.Append("AssociatedProdFile=@AssociatedProdFile,");
			strSql.Append("Note=@Note,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@SeqNo", SqlDbType.Int,4),
					new SqlParameter("@AssociatedProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@AssociatedProdName", SqlDbType.NVarChar,512),
					new SqlParameter("@AssociatedProdFile", SqlDbType.NVarChar,512),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.SeqNo;
			parameters[2].Value = model.AssociatedProdCode;
			parameters[3].Value = model.AssociatedProdName;
			parameters[4].Value = model.AssociatedProdFile;
			parameters[5].Value = model.Note;
			parameters[6].Value = model.CreatedOn;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedOn;
			parameters[9].Value = model.UpdatedBy;
			parameters[10].Value = model.KeyID;

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
			strSql.Append("delete from BUY_ProductAssociated ");
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
			strSql.Append("delete from BUY_ProductAssociated ");
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
		public Edge.SVA.Model.BUY_ProductAssociated GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,ProdCode,SeqNo,AssociatedProdCode,AssociatedProdName,AssociatedProdFile,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_ProductAssociated ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_ProductAssociated model=new Edge.SVA.Model.BUY_ProductAssociated();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SeqNo"]!=null && ds.Tables[0].Rows[0]["SeqNo"].ToString()!="")
				{
					model.SeqNo=int.Parse(ds.Tables[0].Rows[0]["SeqNo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AssociatedProdCode"]!=null && ds.Tables[0].Rows[0]["AssociatedProdCode"].ToString()!="")
				{
					model.AssociatedProdCode=ds.Tables[0].Rows[0]["AssociatedProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AssociatedProdName"]!=null && ds.Tables[0].Rows[0]["AssociatedProdName"].ToString()!="")
				{
					model.AssociatedProdName=ds.Tables[0].Rows[0]["AssociatedProdName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AssociatedProdFile"]!=null && ds.Tables[0].Rows[0]["AssociatedProdFile"].ToString()!="")
				{
					model.AssociatedProdFile=ds.Tables[0].Rows[0]["AssociatedProdFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
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
			strSql.Append("select KeyID,ProdCode,SeqNo,AssociatedProdCode,AssociatedProdName,AssociatedProdFile,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_ProductAssociated ");
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
			strSql.Append(" KeyID,ProdCode,SeqNo,AssociatedProdCode,AssociatedProdName,AssociatedProdFile,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_ProductAssociated ");
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
			strSql.Append("select count(1) FROM BUY_ProductAssociated ");
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
				strSql.Append("order by T.KeyID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_ProductAssociated T ");
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
			parameters[0].Value = "BUY_ProductAssociated";
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

