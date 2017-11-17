using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Promotion_Hit_PLU
	/// </summary>
	public partial class Promotion_Hit_PLU:IPromotion_Hit_PLU
	{
		public Promotion_Hit_PLU()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "Promotion_Hit_PLU"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Promotion_Hit_PLU");
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
		public int Add(Edge.SVA.Model.Promotion_Hit_PLU model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Promotion_Hit_PLU(");
			strSql.Append("PromotionCode,HitSeq,EntityNum,EntityType)");
			strSql.Append(" values (");
			strSql.Append("@PromotionCode,@HitSeq,@EntityNum,@EntityType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@HitSeq", SqlDbType.Int,4),
					new SqlParameter("@EntityNum", SqlDbType.VarChar,64),
					new SqlParameter("@EntityType", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.HitSeq;
			parameters[2].Value = model.EntityNum;
			parameters[3].Value = model.EntityType;

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
		public bool Update(Edge.SVA.Model.Promotion_Hit_PLU model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Promotion_Hit_PLU set ");
			strSql.Append("PromotionCode=@PromotionCode,");
			strSql.Append("HitSeq=@HitSeq,");
			strSql.Append("EntityNum=@EntityNum,");
			strSql.Append("EntityType=@EntityType");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@HitSeq", SqlDbType.Int,4),
					new SqlParameter("@EntityNum", SqlDbType.VarChar,64),
					new SqlParameter("@EntityType", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.HitSeq;
			parameters[2].Value = model.EntityNum;
			parameters[3].Value = model.EntityType;
			parameters[4].Value = model.KeyID;

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
			strSql.Append("delete from Promotion_Hit_PLU ");
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

        public bool Delete(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Promotion_Hit_PLU ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" where {0}", strWhere);
            }
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string KeyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Promotion_Hit_PLU ");
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
		public Edge.SVA.Model.Promotion_Hit_PLU GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,PromotionCode,HitSeq,EntityNum,EntityType from Promotion_Hit_PLU ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.Promotion_Hit_PLU model=new Edge.SVA.Model.Promotion_Hit_PLU();
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
				if(ds.Tables[0].Rows[0]["HitSeq"]!=null && ds.Tables[0].Rows[0]["HitSeq"].ToString()!="")
				{
					model.HitSeq=int.Parse(ds.Tables[0].Rows[0]["HitSeq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EntityNum"]!=null && ds.Tables[0].Rows[0]["EntityNum"].ToString()!="")
				{
					model.EntityNum=ds.Tables[0].Rows[0]["EntityNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EntityType"]!=null && ds.Tables[0].Rows[0]["EntityType"].ToString()!="")
				{
					model.EntityType=int.Parse(ds.Tables[0].Rows[0]["EntityType"].ToString());
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
			strSql.Append("select KeyID,PromotionCode,HitSeq,EntityNum,EntityType ");
			strSql.Append(" FROM Promotion_Hit_PLU ");
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
			strSql.Append(" KeyID,PromotionCode,HitSeq,EntityNum,EntityType ");
			strSql.Append(" FROM Promotion_Hit_PLU ");
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
			strSql.Append("select count(1) FROM Promotion_Hit_PLU ");
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
			strSql.Append(")AS Row, T.*  from Promotion_Hit_PLU T ");
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
			parameters[0].Value = "Promotion_Hit_PLU";
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

