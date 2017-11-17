using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Promotion_Gift
	/// </summary>
	public partial class Promotion_Gift:IPromotion_Gift
	{
		public Promotion_Gift()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("GiftSeq", "Promotion_Gift"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PromotionCode,int GiftSeq)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Promotion_Gift");
			strSql.Append(" where PromotionCode=@PromotionCode and GiftSeq=@GiftSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@GiftSeq", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionCode;
			parameters[1].Value = GiftSeq;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Promotion_Gift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Promotion_Gift(");
			strSql.Append("PromotionCode,GiftSeq,GiftLogicalOpr,PromotionGiftType,PromotionDiscountOn,PromotionDiscountType,PromotionValue,PromotionGiftQty,PromotionGiftItem)");
			strSql.Append(" values (");
			strSql.Append("@PromotionCode,@GiftSeq,@GiftLogicalOpr,@PromotionGiftType,@PromotionDiscountOn,@PromotionDiscountType,@PromotionValue,@PromotionGiftQty,@PromotionGiftItem)");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@GiftSeq", SqlDbType.Int,4),
					new SqlParameter("@GiftLogicalOpr", SqlDbType.Int,4),
					new SqlParameter("@PromotionGiftType", SqlDbType.Int,4),
					new SqlParameter("@PromotionDiscountOn", SqlDbType.Int,4),
					new SqlParameter("@PromotionDiscountType", SqlDbType.Int,4),
					new SqlParameter("@PromotionValue", SqlDbType.Decimal,9),
					new SqlParameter("@PromotionGiftQty", SqlDbType.Int,4),
					new SqlParameter("@PromotionGiftItem", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.GiftSeq;
			parameters[2].Value = model.GiftLogicalOpr;
			parameters[3].Value = model.PromotionGiftType;
			parameters[4].Value = model.PromotionDiscountOn;
			parameters[5].Value = model.PromotionDiscountType;
			parameters[6].Value = model.PromotionValue;
			parameters[7].Value = model.PromotionGiftQty;
			parameters[8].Value = model.PromotionGiftItem;

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
		public bool Update(Edge.SVA.Model.Promotion_Gift model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Promotion_Gift set ");
			strSql.Append("GiftLogicalOpr=@GiftLogicalOpr,");
			strSql.Append("PromotionGiftType=@PromotionGiftType,");
			strSql.Append("PromotionDiscountOn=@PromotionDiscountOn,");
			strSql.Append("PromotionDiscountType=@PromotionDiscountType,");
			strSql.Append("PromotionValue=@PromotionValue,");
			strSql.Append("PromotionGiftQty=@PromotionGiftQty,");
			strSql.Append("PromotionGiftItem=@PromotionGiftItem");
			strSql.Append(" where PromotionCode=@PromotionCode and GiftSeq=@GiftSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@GiftLogicalOpr", SqlDbType.Int,4),
					new SqlParameter("@PromotionGiftType", SqlDbType.Int,4),
					new SqlParameter("@PromotionDiscountOn", SqlDbType.Int,4),
					new SqlParameter("@PromotionDiscountType", SqlDbType.Int,4),
					new SqlParameter("@PromotionValue", SqlDbType.Decimal,9),
					new SqlParameter("@PromotionGiftQty", SqlDbType.Int,4),
					new SqlParameter("@PromotionGiftItem", SqlDbType.Int,4),
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@GiftSeq", SqlDbType.Int,4)};
			parameters[0].Value = model.GiftLogicalOpr;
			parameters[1].Value = model.PromotionGiftType;
			parameters[2].Value = model.PromotionDiscountOn;
			parameters[3].Value = model.PromotionDiscountType;
			parameters[4].Value = model.PromotionValue;
			parameters[5].Value = model.PromotionGiftQty;
			parameters[6].Value = model.PromotionGiftItem;
			parameters[7].Value = model.PromotionCode;
			parameters[8].Value = model.GiftSeq;

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
		public bool Delete(string PromotionCode,int GiftSeq)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Promotion_Gift ");
			strSql.Append(" where PromotionCode=@PromotionCode and GiftSeq=@GiftSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@GiftSeq", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionCode;
			parameters[1].Value = GiftSeq;

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
		public Edge.SVA.Model.Promotion_Gift GetModel(string PromotionCode,int GiftSeq)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PromotionCode,GiftSeq,GiftLogicalOpr,PromotionGiftType,PromotionDiscountOn,PromotionDiscountType,PromotionValue,PromotionGiftQty,PromotionGiftItem from Promotion_Gift ");
			strSql.Append(" where PromotionCode=@PromotionCode and GiftSeq=@GiftSeq ");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@GiftSeq", SqlDbType.Int,4)			};
			parameters[0].Value = PromotionCode;
			parameters[1].Value = GiftSeq;

			Edge.SVA.Model.Promotion_Gift model=new Edge.SVA.Model.Promotion_Gift();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PromotionCode"]!=null && ds.Tables[0].Rows[0]["PromotionCode"].ToString()!="")
				{
					model.PromotionCode=ds.Tables[0].Rows[0]["PromotionCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["GiftSeq"]!=null && ds.Tables[0].Rows[0]["GiftSeq"].ToString()!="")
				{
					model.GiftSeq=int.Parse(ds.Tables[0].Rows[0]["GiftSeq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GiftLogicalOpr"]!=null && ds.Tables[0].Rows[0]["GiftLogicalOpr"].ToString()!="")
				{
					model.GiftLogicalOpr=int.Parse(ds.Tables[0].Rows[0]["GiftLogicalOpr"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionGiftType"]!=null && ds.Tables[0].Rows[0]["PromotionGiftType"].ToString()!="")
				{
					model.PromotionGiftType=int.Parse(ds.Tables[0].Rows[0]["PromotionGiftType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionDiscountOn"]!=null && ds.Tables[0].Rows[0]["PromotionDiscountOn"].ToString()!="")
				{
					model.PromotionDiscountOn=int.Parse(ds.Tables[0].Rows[0]["PromotionDiscountOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionDiscountType"]!=null && ds.Tables[0].Rows[0]["PromotionDiscountType"].ToString()!="")
				{
					model.PromotionDiscountType=int.Parse(ds.Tables[0].Rows[0]["PromotionDiscountType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionValue"]!=null && ds.Tables[0].Rows[0]["PromotionValue"].ToString()!="")
				{
					model.PromotionValue=decimal.Parse(ds.Tables[0].Rows[0]["PromotionValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionGiftQty"]!=null && ds.Tables[0].Rows[0]["PromotionGiftQty"].ToString()!="")
				{
					model.PromotionGiftQty=int.Parse(ds.Tables[0].Rows[0]["PromotionGiftQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionGiftItem"]!=null && ds.Tables[0].Rows[0]["PromotionGiftItem"].ToString()!="")
				{
					model.PromotionGiftItem=int.Parse(ds.Tables[0].Rows[0]["PromotionGiftItem"].ToString());
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
			strSql.Append("select PromotionCode,GiftSeq,GiftLogicalOpr,PromotionGiftType,PromotionDiscountOn,PromotionDiscountType,PromotionValue,PromotionGiftQty,PromotionGiftItem ");
			strSql.Append(" FROM Promotion_Gift ");
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
			strSql.Append(" PromotionCode,GiftSeq,GiftLogicalOpr,PromotionGiftType,PromotionDiscountOn,PromotionDiscountType,PromotionValue,PromotionGiftQty,PromotionGiftItem ");
			strSql.Append(" FROM Promotion_Gift ");
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
			strSql.Append("select count(1) FROM Promotion_Gift ");
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
				strSql.Append("order by T.GiftSeq desc");
			}
			strSql.Append(")AS Row, T.*  from Promotion_Gift T ");
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
			parameters[0].Value = "Promotion_Gift";
			parameters[1].Value = "GiftSeq";
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

