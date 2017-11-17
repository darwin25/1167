using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_PROMO_M
	/// </summary>
	public partial class BUY_PROMO_M:IBUY_PROMO_M
	{
		public BUY_PROMO_M()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_PROMO_M"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_PROMO_M");
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
		public int Add(Edge.SVA.Model.BUY_PROMO_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_PROMO_M(");
			strSql.Append("PromotionCode,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,EntityNum,EntityType,HitAmount,HitOP,DiscPrice,DiscType,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyFlag,LoyaltyCardTypeCode,LoyaltyCardGradeCode,BirthdayFlag,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@PromotionCode,@Description1,@Description2,@Description3,@StoreCode,@StoreGroupCode,@StartDate,@EndDate,@StartTime,@EndTime,@EntityNum,@EntityType,@HitAmount,@HitOP,@DiscPrice,@DiscType,@DayFlagCode,@WeekFlagCode,@MonthFlagCode,@LoyaltyFlag,@LoyaltyCardTypeCode,@LoyaltyCardGradeCode,@BirthdayFlag,@Status,@ApproveOn,@ApproveBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@EntityNum", SqlDbType.VarChar,64),
					new SqlParameter("@EntityType", SqlDbType.Int,4),
					new SqlParameter("@HitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@DiscPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DiscType", SqlDbType.Int,4),
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyFlag", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyCardTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyCardGradeCode", SqlDbType.VarChar,64),
					new SqlParameter("@BirthdayFlag", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.Description1;
			parameters[2].Value = model.Description2;
			parameters[3].Value = model.Description3;
			parameters[4].Value = model.StoreCode;
			parameters[5].Value = model.StoreGroupCode;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.StartTime;
			parameters[9].Value = model.EndTime;
			parameters[10].Value = model.EntityNum;
			parameters[11].Value = model.EntityType;
			parameters[12].Value = model.HitAmount;
			parameters[13].Value = model.HitOP;
			parameters[14].Value = model.DiscPrice;
			parameters[15].Value = model.DiscType;
			parameters[16].Value = model.DayFlagCode;
			parameters[17].Value = model.WeekFlagCode;
			parameters[18].Value = model.MonthFlagCode;
			parameters[19].Value = model.LoyaltyFlag;
			parameters[20].Value = model.LoyaltyCardTypeCode;
			parameters[21].Value = model.LoyaltyCardGradeCode;
			parameters[22].Value = model.BirthdayFlag;
			parameters[23].Value = model.Status;
			parameters[24].Value = model.ApproveOn;
			parameters[25].Value = model.ApproveBy;
			parameters[26].Value = model.UpdatedOn;
			parameters[27].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_PROMO_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_PROMO_M set ");
			strSql.Append("PromotionCode=@PromotionCode,");
			strSql.Append("Description1=@Description1,");
			strSql.Append("Description2=@Description2,");
			strSql.Append("Description3=@Description3,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("StoreGroupCode=@StoreGroupCode,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("EntityNum=@EntityNum,");
			strSql.Append("EntityType=@EntityType,");
			strSql.Append("HitAmount=@HitAmount,");
			strSql.Append("HitOP=@HitOP,");
			strSql.Append("DiscPrice=@DiscPrice,");
			strSql.Append("DiscType=@DiscType,");
			strSql.Append("DayFlagCode=@DayFlagCode,");
			strSql.Append("WeekFlagCode=@WeekFlagCode,");
			strSql.Append("MonthFlagCode=@MonthFlagCode,");
			strSql.Append("LoyaltyFlag=@LoyaltyFlag,");
			strSql.Append("LoyaltyCardTypeCode=@LoyaltyCardTypeCode,");
			strSql.Append("LoyaltyCardGradeCode=@LoyaltyCardGradeCode,");
			strSql.Append("BirthdayFlag=@BirthdayFlag,");
			strSql.Append("Status=@Status,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionCode", SqlDbType.VarChar,64),
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@EntityNum", SqlDbType.VarChar,64),
					new SqlParameter("@EntityType", SqlDbType.Int,4),
					new SqlParameter("@HitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@DiscPrice", SqlDbType.Decimal,9),
					new SqlParameter("@DiscType", SqlDbType.Int,4),
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyFlag", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyCardTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyCardGradeCode", SqlDbType.VarChar,64),
					new SqlParameter("@BirthdayFlag", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionCode;
			parameters[1].Value = model.Description1;
			parameters[2].Value = model.Description2;
			parameters[3].Value = model.Description3;
			parameters[4].Value = model.StoreCode;
			parameters[5].Value = model.StoreGroupCode;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.StartTime;
			parameters[9].Value = model.EndTime;
			parameters[10].Value = model.EntityNum;
			parameters[11].Value = model.EntityType;
			parameters[12].Value = model.HitAmount;
			parameters[13].Value = model.HitOP;
			parameters[14].Value = model.DiscPrice;
			parameters[15].Value = model.DiscType;
			parameters[16].Value = model.DayFlagCode;
			parameters[17].Value = model.WeekFlagCode;
			parameters[18].Value = model.MonthFlagCode;
			parameters[19].Value = model.LoyaltyFlag;
			parameters[20].Value = model.LoyaltyCardTypeCode;
			parameters[21].Value = model.LoyaltyCardGradeCode;
			parameters[22].Value = model.BirthdayFlag;
			parameters[23].Value = model.Status;
			parameters[24].Value = model.ApproveOn;
			parameters[25].Value = model.ApproveBy;
			parameters[26].Value = model.UpdatedOn;
			parameters[27].Value = model.UpdatedBy;
			parameters[28].Value = model.KeyID;

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
			strSql.Append("delete from BUY_PROMO_M ");
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
			strSql.Append("delete from BUY_PROMO_M ");
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
		public Edge.SVA.Model.BUY_PROMO_M GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,PromotionCode,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,EntityNum,EntityType,HitAmount,HitOP,DiscPrice,DiscType,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyFlag,LoyaltyCardTypeCode,LoyaltyCardGradeCode,BirthdayFlag,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy from BUY_PROMO_M ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_PROMO_M model=new Edge.SVA.Model.BUY_PROMO_M();
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
				if(ds.Tables[0].Rows[0]["Description1"]!=null && ds.Tables[0].Rows[0]["Description1"].ToString()!="")
				{
					model.Description1=ds.Tables[0].Rows[0]["Description1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description2"]!=null && ds.Tables[0].Rows[0]["Description2"].ToString()!="")
				{
					model.Description2=ds.Tables[0].Rows[0]["Description2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description3"]!=null && ds.Tables[0].Rows[0]["Description3"].ToString()!="")
				{
					model.Description3=ds.Tables[0].Rows[0]["Description3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreCode"]!=null && ds.Tables[0].Rows[0]["StoreCode"].ToString()!="")
				{
					model.StoreCode=ds.Tables[0].Rows[0]["StoreCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreGroupCode"]!=null && ds.Tables[0].Rows[0]["StoreGroupCode"].ToString()!="")
				{
					model.StoreGroupCode=ds.Tables[0].Rows[0]["StoreGroupCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartTime"]!=null && ds.Tables[0].Rows[0]["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndTime"]!=null && ds.Tables[0].Rows[0]["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EntityNum"]!=null && ds.Tables[0].Rows[0]["EntityNum"].ToString()!="")
				{
					model.EntityNum=ds.Tables[0].Rows[0]["EntityNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EntityType"]!=null && ds.Tables[0].Rows[0]["EntityType"].ToString()!="")
				{
					model.EntityType=int.Parse(ds.Tables[0].Rows[0]["EntityType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitAmount"]!=null && ds.Tables[0].Rows[0]["HitAmount"].ToString()!="")
				{
					model.HitAmount=decimal.Parse(ds.Tables[0].Rows[0]["HitAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitOP"]!=null && ds.Tables[0].Rows[0]["HitOP"].ToString()!="")
				{
					model.HitOP=int.Parse(ds.Tables[0].Rows[0]["HitOP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiscPrice"]!=null && ds.Tables[0].Rows[0]["DiscPrice"].ToString()!="")
				{
					model.DiscPrice=decimal.Parse(ds.Tables[0].Rows[0]["DiscPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiscType"]!=null && ds.Tables[0].Rows[0]["DiscType"].ToString()!="")
				{
					model.DiscType=int.Parse(ds.Tables[0].Rows[0]["DiscType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DayFlagCode"]!=null && ds.Tables[0].Rows[0]["DayFlagCode"].ToString()!="")
				{
					model.DayFlagCode=ds.Tables[0].Rows[0]["DayFlagCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["WeekFlagCode"]!=null && ds.Tables[0].Rows[0]["WeekFlagCode"].ToString()!="")
				{
					model.WeekFlagCode=ds.Tables[0].Rows[0]["WeekFlagCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MonthFlagCode"]!=null && ds.Tables[0].Rows[0]["MonthFlagCode"].ToString()!="")
				{
					model.MonthFlagCode=ds.Tables[0].Rows[0]["MonthFlagCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LoyaltyFlag"]!=null && ds.Tables[0].Rows[0]["LoyaltyFlag"].ToString()!="")
				{
					model.LoyaltyFlag=int.Parse(ds.Tables[0].Rows[0]["LoyaltyFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoyaltyCardTypeCode"]!=null && ds.Tables[0].Rows[0]["LoyaltyCardTypeCode"].ToString()!="")
				{
					model.LoyaltyCardTypeCode=ds.Tables[0].Rows[0]["LoyaltyCardTypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LoyaltyCardGradeCode"]!=null && ds.Tables[0].Rows[0]["LoyaltyCardGradeCode"].ToString()!="")
				{
					model.LoyaltyCardGradeCode=ds.Tables[0].Rows[0]["LoyaltyCardGradeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BirthdayFlag"]!=null && ds.Tables[0].Rows[0]["BirthdayFlag"].ToString()!="")
				{
					model.BirthdayFlag=int.Parse(ds.Tables[0].Rows[0]["BirthdayFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveOn"]!=null && ds.Tables[0].Rows[0]["ApproveOn"].ToString()!="")
				{
					model.ApproveOn=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBy"]!=null && ds.Tables[0].Rows[0]["ApproveBy"].ToString()!="")
				{
					model.ApproveBy=int.Parse(ds.Tables[0].Rows[0]["ApproveBy"].ToString());
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
			strSql.Append("select KeyID,PromotionCode,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,EntityNum,EntityType,HitAmount,HitOP,DiscPrice,DiscType,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyFlag,LoyaltyCardTypeCode,LoyaltyCardGradeCode,BirthdayFlag,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_PROMO_M ");
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
			strSql.Append(" KeyID,PromotionCode,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,EntityNum,EntityType,HitAmount,HitOP,DiscPrice,DiscType,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyFlag,LoyaltyCardTypeCode,LoyaltyCardGradeCode,BirthdayFlag,Status,ApproveOn,ApproveBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_PROMO_M ");
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
			strSql.Append("select count(1) FROM BUY_PROMO_M ");
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
			strSql.Append(")AS Row, T.*  from BUY_PROMO_M T ");
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
			parameters[0].Value = "BUY_PROMO_M";
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

