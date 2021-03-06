﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_PROMO_D
	/// </summary>
	public partial class BUY_PROMO_D:IBUY_PROMO_D
	{
		public BUY_PROMO_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_PROMO_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_PROMO_D");
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
		public int Add(Edge.SVA.Model.BUY_PROMO_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_PROMO_D(");
			strSql.Append("PromotionCode,EntityNum,EntityType,HitOP,HitAmount,DiscPrice,DiscType,HitType)");
			strSql.Append(" values (");
			strSql.Append("@PromotionCode,@EntityNum,@EntityType,@HitOP,@HitAmount,@DiscPrice,@DiscType,@HitType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@EntityNum", SqlDbType.VarChar,64),
					new SqlParameter("@EntityType", SqlDbType.Int,4),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@HitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@DiscPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DiscType", SqlDbType.Int,4),
					new SqlParameter("@HitType", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.EntityNum;
			parameters[2].Value = model.EntityType;
			parameters[3].Value = model.HitOP;
			parameters[4].Value = model.HitAmount;
			parameters[5].Value = model.DiscPrice;
			parameters[6].Value = model.DiscType;
			parameters[7].Value = model.HitType;

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
		public bool Update(Edge.SVA.Model.BUY_PROMO_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_PROMO_D set ");
			strSql.Append("PromotionCode=@PromotionCode,");
			strSql.Append("EntityNum=@EntityNum,");
			strSql.Append("EntityType=@EntityType,");
			strSql.Append("HitOP=@HitOP,");
			strSql.Append("HitAmount=@HitAmount,");
			strSql.Append("DiscPrice=@DiscPrice,");
			strSql.Append("DiscType=@DiscType,");
			strSql.Append("HitType=@HitType");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@EntityNum", SqlDbType.VarChar,64),
					new SqlParameter("@EntityType", SqlDbType.Int,4),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@HitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@DiscPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DiscType", SqlDbType.Int,4),
					new SqlParameter("@HitType", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.EntityNum;
			parameters[2].Value = model.EntityType;
			parameters[3].Value = model.HitOP;
			parameters[4].Value = model.HitAmount;
			parameters[5].Value = model.DiscPrice;
			parameters[6].Value = model.DiscType;
			parameters[7].Value = model.HitType;
			parameters[8].Value = model.KeyID;

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
			strSql.Append("delete from BUY_PROMO_D ");
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
			strSql.Append("delete from BUY_PROMO_D ");
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
		public Edge.SVA.Model.BUY_PROMO_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,PromotionCode,EntityNum,EntityType,HitOP,HitAmount,DiscPrice,DiscType,HitType from BUY_PROMO_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_PROMO_D model=new Edge.SVA.Model.BUY_PROMO_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionCode"]!=null && ds.Tables[0].Rows[0]["PromotionCode"].ToString()!="")
				{
					model.PromotionCode=ds.Tables[0].Rows[0]["PromotionCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EntityNum"]!=null && ds.Tables[0].Rows[0]["EntityNum"].ToString()!="")
				{
					model.EntityNum=ds.Tables[0].Rows[0]["EntityNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EntityType"]!=null && ds.Tables[0].Rows[0]["EntityType"].ToString()!="")
				{
					model.EntityType=int.Parse(ds.Tables[0].Rows[0]["EntityType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitOP"]!=null && ds.Tables[0].Rows[0]["HitOP"].ToString()!="")
				{
					model.HitOP=int.Parse(ds.Tables[0].Rows[0]["HitOP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitAmount"]!=null && ds.Tables[0].Rows[0]["HitAmount"].ToString()!="")
				{
					model.HitAmount=decimal.Parse(ds.Tables[0].Rows[0]["HitAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiscPrice"]!=null && ds.Tables[0].Rows[0]["DiscPrice"].ToString()!="")
				{
					model.DiscPrice=decimal.Parse(ds.Tables[0].Rows[0]["DiscPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiscType"]!=null && ds.Tables[0].Rows[0]["DiscType"].ToString()!="")
				{
					model.DiscType=int.Parse(ds.Tables[0].Rows[0]["DiscType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitType"]!=null && ds.Tables[0].Rows[0]["HitType"].ToString()!="")
				{
					model.HitType=int.Parse(ds.Tables[0].Rows[0]["HitType"].ToString());
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
			strSql.Append("select KeyID,PromotionCode,EntityNum,EntityType,HitOP,HitAmount,DiscPrice,DiscType,HitType ");
			strSql.Append(" FROM BUY_PROMO_D ");
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
			strSql.Append(" KeyID,PromotionCode,EntityNum,EntityType,HitOP,HitAmount,DiscPrice,DiscType,HitType ");
			strSql.Append(" FROM BUY_PROMO_D ");
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
			strSql.Append("select count(1) FROM BUY_PROMO_D ");
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
			strSql.Append(")AS Row, T.*  from BUY_PROMO_D T ");
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
			parameters[0].Value = "BUY_PROMO_D";
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

