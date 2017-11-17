using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Promotion_Hit
	/// </summary>
	public partial class Promotion_Hit:IPromotion_Hit
	{
		public Promotion_Hit()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("HitSeq", "Promotion_Hit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PromotionCode,int HitSeq)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Promotion_Hit");
			strSql.Append(" where PromotionCode=@PromotionCode and HitSeq=@HitSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@HitSeq", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionCode;
			parameters[1].Value = HitSeq;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Promotion_Hit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Promotion_Hit(");
			strSql.Append("PromotionCode,HitSeq,HitLogicalOpr,HitType,HitValue,HitOP,HitItem)");
			strSql.Append(" values (");
			strSql.Append("@PromotionCode,@HitSeq,@HitLogicalOpr,@HitType,@HitValue,@HitOP,@HitItem)");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@HitSeq", SqlDbType.Int,4),
					new SqlParameter("@HitLogicalOpr", SqlDbType.Int,4),
					new SqlParameter("@HitType", SqlDbType.Int,4),
					new SqlParameter("@HitValue", SqlDbType.Int,4),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@HitItem", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.HitSeq;
			parameters[2].Value = model.HitLogicalOpr;
			parameters[3].Value = model.HitType;
			parameters[4].Value = model.HitValue;
			parameters[5].Value = model.HitOP;
			parameters[6].Value = model.HitItem;

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
		public bool Update(Edge.SVA.Model.Promotion_Hit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Promotion_Hit set ");
			strSql.Append("HitLogicalOpr=@HitLogicalOpr,");
			strSql.Append("HitType=@HitType,");
			strSql.Append("HitValue=@HitValue,");
			strSql.Append("HitOP=@HitOP,");
			strSql.Append("HitItem=@HitItem");
			strSql.Append(" where PromotionCode=@PromotionCode and HitSeq=@HitSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@HitLogicalOpr", SqlDbType.Int,4),
					new SqlParameter("@HitType", SqlDbType.Int,4),
					new SqlParameter("@HitValue", SqlDbType.Int,4),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@HitItem", SqlDbType.Int,4),
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@HitSeq", SqlDbType.Int,4)};
			parameters[0].Value = model.HitLogicalOpr;
			parameters[1].Value = model.HitType;
			parameters[2].Value = model.HitValue;
			parameters[3].Value = model.HitOP;
			parameters[4].Value = model.HitItem;
			parameters[5].Value = model.PromotionCode;
			parameters[6].Value = model.HitSeq;

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
		public bool Delete(string PromotionCode,int HitSeq)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Promotion_Hit ");
			strSql.Append(" where PromotionCode=@PromotionCode and HitSeq=@HitSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@HitSeq", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionCode;
			parameters[1].Value = HitSeq;

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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Promotion_Hit GetModel(string PromotionCode,int HitSeq)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PromotionCode,HitSeq,HitLogicalOpr,HitType,HitValue,HitOP,HitItem from Promotion_Hit ");
			strSql.Append(" where PromotionCode=@PromotionCode and HitSeq=@HitSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@HitSeq", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionCode;
			parameters[1].Value = HitSeq;

			Edge.SVA.Model.Promotion_Hit model=new Edge.SVA.Model.Promotion_Hit();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PromotionCode"]!=null && ds.Tables[0].Rows[0]["PromotionCode"].ToString()!="")
				{
					model.PromotionCode=ds.Tables[0].Rows[0]["PromotionCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["HitSeq"]!=null && ds.Tables[0].Rows[0]["HitSeq"].ToString()!="")
				{
					model.HitSeq=int.Parse(ds.Tables[0].Rows[0]["HitSeq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitLogicalOpr"]!=null && ds.Tables[0].Rows[0]["HitLogicalOpr"].ToString()!="")
				{
					model.HitLogicalOpr=int.Parse(ds.Tables[0].Rows[0]["HitLogicalOpr"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitType"]!=null && ds.Tables[0].Rows[0]["HitType"].ToString()!="")
				{
					model.HitType=int.Parse(ds.Tables[0].Rows[0]["HitType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitValue"]!=null && ds.Tables[0].Rows[0]["HitValue"].ToString()!="")
				{
					model.HitValue=int.Parse(ds.Tables[0].Rows[0]["HitValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitOP"]!=null && ds.Tables[0].Rows[0]["HitOP"].ToString()!="")
				{
					model.HitOP=int.Parse(ds.Tables[0].Rows[0]["HitOP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitItem"]!=null && ds.Tables[0].Rows[0]["HitItem"].ToString()!="")
				{
					model.HitItem=int.Parse(ds.Tables[0].Rows[0]["HitItem"].ToString());
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
			strSql.Append("select PromotionCode,HitSeq,HitLogicalOpr,HitType,HitValue,HitOP,HitItem ");
			strSql.Append(" FROM Promotion_Hit ");
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
			strSql.Append(" PromotionCode,HitSeq,HitLogicalOpr,HitType,HitValue,HitOP,HitItem ");
			strSql.Append(" FROM Promotion_Hit ");
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
			strSql.Append("select count(1) FROM Promotion_Hit ");
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
				strSql.Append("order by T.HitSeq desc");
			}
			strSql.Append(")AS Row, T.*  from Promotion_Hit T ");
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
			parameters[0].Value = "Promotion_Hit";
			parameters[1].Value = "HitSeq";
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

