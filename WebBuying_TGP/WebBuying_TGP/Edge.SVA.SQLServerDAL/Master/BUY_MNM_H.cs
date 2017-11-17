using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_MNM_H
	/// </summary>
	public partial class BUY_MNM_H:IBUY_MNM_H
	{
		public BUY_MNM_H()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MNMCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_MNM_H");
			strSql.Append(" where MNMCode=@MNMCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@MNMCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = MNMCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_MNM_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_MNM_H(");
			strSql.Append("MNMCode,MNMType,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyOnly,LoyaltyCardTypeCode,LoyaltyCardGradeCode,LoyaltyThreshold,HitType,HitOP,HitAmount,HitQty,GiftType,GiftQty,PromotionType,PromotionOn,AmountType,Amount,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@MNMCode,@MNMType,@Description1,@Description2,@Description3,@StoreCode,@StoreGroupCode,@StartDate,@EndDate,@StartTime,@EndTime,@DayFlagCode,@WeekFlagCode,@MonthFlagCode,@LoyaltyOnly,@LoyaltyCardTypeCode,@LoyaltyCardGradeCode,@LoyaltyThreshold,@HitType,@HitOP,@HitAmount,@HitQty,@GiftType,@GiftQty,@PromotionType,@PromotionOn,@AmountType,@Amount,@Note,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@MNMCode", SqlDbType.VarChar,64),
					new SqlParameter("@MNMType", SqlDbType.Int,4),
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyOnly", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyCardTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyCardGradeCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyThreshold", SqlDbType.VarChar,64),
					new SqlParameter("@HitType", SqlDbType.Int,4),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@HitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@HitQty", SqlDbType.Int,4),
					new SqlParameter("@GiftType", SqlDbType.Int,4),
					new SqlParameter("@GiftQty", SqlDbType.Int,4),
					new SqlParameter("@PromotionType", SqlDbType.Int,4),
					new SqlParameter("@PromotionOn", SqlDbType.Int,4),
					new SqlParameter("@AmountType", SqlDbType.Char,1),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.MNMCode;
			parameters[1].Value = model.MNMType;
			parameters[2].Value = model.Description1;
			parameters[3].Value = model.Description2;
			parameters[4].Value = model.Description3;
			parameters[5].Value = model.StoreCode;
			parameters[6].Value = model.StoreGroupCode;
			parameters[7].Value = model.StartDate;
			parameters[8].Value = model.EndDate;
			parameters[9].Value = model.StartTime;
			parameters[10].Value = model.EndTime;
			parameters[11].Value = model.DayFlagCode;
			parameters[12].Value = model.WeekFlagCode;
			parameters[13].Value = model.MonthFlagCode;
			parameters[14].Value = model.LoyaltyOnly;
			parameters[15].Value = model.LoyaltyCardTypeCode;
			parameters[16].Value = model.LoyaltyCardGradeCode;
			parameters[17].Value = model.LoyaltyThreshold;
			parameters[18].Value = model.HitType;
			parameters[19].Value = model.HitOP;
			parameters[20].Value = model.HitAmount;
			parameters[21].Value = model.HitQty;
			parameters[22].Value = model.GiftType;
			parameters[23].Value = model.GiftQty;
			parameters[24].Value = model.PromotionType;
			parameters[25].Value = model.PromotionOn;
			parameters[26].Value = model.AmountType;
			parameters[27].Value = model.Amount;
			parameters[28].Value = model.Note;
			parameters[29].Value = model.CreatedBusDate;
			parameters[30].Value = model.ApproveBusDate;
			parameters[31].Value = model.ApprovalCode;
			parameters[32].Value = model.ApproveStatus;
			parameters[33].Value = model.ApproveOn;
			parameters[34].Value = model.ApproveBy;
			parameters[35].Value = model.CreatedOn;
			parameters[36].Value = model.CreatedBy;
			parameters[37].Value = model.UpdatedOn;
			parameters[38].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_MNM_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_MNM_H set ");
			strSql.Append("MNMType=@MNMType,");
			strSql.Append("Description1=@Description1,");
			strSql.Append("Description2=@Description2,");
			strSql.Append("Description3=@Description3,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("StoreGroupCode=@StoreGroupCode,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("DayFlagCode=@DayFlagCode,");
			strSql.Append("WeekFlagCode=@WeekFlagCode,");
			strSql.Append("MonthFlagCode=@MonthFlagCode,");
			strSql.Append("LoyaltyOnly=@LoyaltyOnly,");
			strSql.Append("LoyaltyCardTypeCode=@LoyaltyCardTypeCode,");
			strSql.Append("LoyaltyCardGradeCode=@LoyaltyCardGradeCode,");
			strSql.Append("LoyaltyThreshold=@LoyaltyThreshold,");
			strSql.Append("HitType=@HitType,");
			strSql.Append("HitOP=@HitOP,");
			strSql.Append("HitAmount=@HitAmount,");
			strSql.Append("HitQty=@HitQty,");
			strSql.Append("GiftType=@GiftType,");
			strSql.Append("GiftQty=@GiftQty,");
			strSql.Append("PromotionType=@PromotionType,");
			strSql.Append("PromotionOn=@PromotionOn,");
			strSql.Append("AmountType=@AmountType,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("Note=@Note,");
			strSql.Append("CreatedBusDate=@CreatedBusDate,");
			strSql.Append("ApproveBusDate=@ApproveBusDate,");
			strSql.Append("ApprovalCode=@ApprovalCode,");
			strSql.Append("ApproveStatus=@ApproveStatus,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where MNMCode=@MNMCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@MNMType", SqlDbType.Int,4),
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@StoreGroupCode", SqlDbType.VarChar,64),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@WeekFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@MonthFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyOnly", SqlDbType.Int,4),
					new SqlParameter("@LoyaltyCardTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyCardGradeCode", SqlDbType.VarChar,64),
					new SqlParameter("@LoyaltyThreshold", SqlDbType.VarChar,64),
					new SqlParameter("@HitType", SqlDbType.Int,4),
					new SqlParameter("@HitOP", SqlDbType.Int,4),
					new SqlParameter("@HitAmount", SqlDbType.Decimal,9),
					new SqlParameter("@HitQty", SqlDbType.Int,4),
					new SqlParameter("@GiftType", SqlDbType.Int,4),
					new SqlParameter("@GiftQty", SqlDbType.Int,4),
					new SqlParameter("@PromotionType", SqlDbType.Int,4),
					new SqlParameter("@PromotionOn", SqlDbType.Int,4),
					new SqlParameter("@AmountType", SqlDbType.Char,1),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@MNMCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.MNMType;
			parameters[1].Value = model.Description1;
			parameters[2].Value = model.Description2;
			parameters[3].Value = model.Description3;
			parameters[4].Value = model.StoreCode;
			parameters[5].Value = model.StoreGroupCode;
			parameters[6].Value = model.StartDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.StartTime;
			parameters[9].Value = model.EndTime;
			parameters[10].Value = model.DayFlagCode;
			parameters[11].Value = model.WeekFlagCode;
			parameters[12].Value = model.MonthFlagCode;
			parameters[13].Value = model.LoyaltyOnly;
			parameters[14].Value = model.LoyaltyCardTypeCode;
			parameters[15].Value = model.LoyaltyCardGradeCode;
			parameters[16].Value = model.LoyaltyThreshold;
			parameters[17].Value = model.HitType;
			parameters[18].Value = model.HitOP;
			parameters[19].Value = model.HitAmount;
			parameters[20].Value = model.HitQty;
			parameters[21].Value = model.GiftType;
			parameters[22].Value = model.GiftQty;
			parameters[23].Value = model.PromotionType;
			parameters[24].Value = model.PromotionOn;
			parameters[25].Value = model.AmountType;
			parameters[26].Value = model.Amount;
			parameters[27].Value = model.Note;
			parameters[28].Value = model.CreatedBusDate;
			parameters[29].Value = model.ApproveBusDate;
			parameters[30].Value = model.ApprovalCode;
			parameters[31].Value = model.ApproveStatus;
			parameters[32].Value = model.ApproveOn;
			parameters[33].Value = model.ApproveBy;
			parameters[34].Value = model.CreatedOn;
			parameters[35].Value = model.CreatedBy;
			parameters[36].Value = model.UpdatedOn;
			parameters[37].Value = model.UpdatedBy;
			parameters[38].Value = model.MNMCode;

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
		public bool Delete(string MNMCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_MNM_H ");
			strSql.Append(" where MNMCode=@MNMCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@MNMCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = MNMCode;

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
		public bool DeleteList(string MNMCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_MNM_H ");
			strSql.Append(" where MNMCode in ("+MNMCodelist + ")  ");
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
		public Edge.SVA.Model.BUY_MNM_H GetModel(string MNMCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MNMCode,MNMType,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyOnly,LoyaltyCardTypeCode,LoyaltyCardGradeCode,LoyaltyThreshold,HitType,HitOP,HitAmount,HitQty,GiftType,GiftQty,PromotionType,PromotionOn,AmountType,Amount,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_MNM_H ");
			strSql.Append(" where MNMCode=@MNMCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@MNMCode", SqlDbType.VarChar,64)			};
			parameters[0].Value = MNMCode;

			Edge.SVA.Model.BUY_MNM_H model=new Edge.SVA.Model.BUY_MNM_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MNMCode"]!=null && ds.Tables[0].Rows[0]["MNMCode"].ToString()!="")
				{
					model.MNMCode=ds.Tables[0].Rows[0]["MNMCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MNMType"]!=null && ds.Tables[0].Rows[0]["MNMType"].ToString()!="")
				{
					model.MNMType=int.Parse(ds.Tables[0].Rows[0]["MNMType"].ToString());
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
				if(ds.Tables[0].Rows[0]["LoyaltyOnly"]!=null && ds.Tables[0].Rows[0]["LoyaltyOnly"].ToString()!="")
				{
					model.LoyaltyOnly=int.Parse(ds.Tables[0].Rows[0]["LoyaltyOnly"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoyaltyCardTypeCode"]!=null && ds.Tables[0].Rows[0]["LoyaltyCardTypeCode"].ToString()!="")
				{
					model.LoyaltyCardTypeCode=ds.Tables[0].Rows[0]["LoyaltyCardTypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LoyaltyCardGradeCode"]!=null && ds.Tables[0].Rows[0]["LoyaltyCardGradeCode"].ToString()!="")
				{
					model.LoyaltyCardGradeCode=ds.Tables[0].Rows[0]["LoyaltyCardGradeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LoyaltyThreshold"]!=null && ds.Tables[0].Rows[0]["LoyaltyThreshold"].ToString()!="")
				{
					model.LoyaltyThreshold=ds.Tables[0].Rows[0]["LoyaltyThreshold"].ToString();
				}
				if(ds.Tables[0].Rows[0]["HitType"]!=null && ds.Tables[0].Rows[0]["HitType"].ToString()!="")
				{
					model.HitType=int.Parse(ds.Tables[0].Rows[0]["HitType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitOP"]!=null && ds.Tables[0].Rows[0]["HitOP"].ToString()!="")
				{
					model.HitOP=int.Parse(ds.Tables[0].Rows[0]["HitOP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitAmount"]!=null && ds.Tables[0].Rows[0]["HitAmount"].ToString()!="")
				{
					model.HitAmount=decimal.Parse(ds.Tables[0].Rows[0]["HitAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HitQty"]!=null && ds.Tables[0].Rows[0]["HitQty"].ToString()!="")
				{
					model.HitQty=int.Parse(ds.Tables[0].Rows[0]["HitQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GiftType"]!=null && ds.Tables[0].Rows[0]["GiftType"].ToString()!="")
				{
					model.GiftType=int.Parse(ds.Tables[0].Rows[0]["GiftType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GiftQty"]!=null && ds.Tables[0].Rows[0]["GiftQty"].ToString()!="")
				{
					model.GiftQty=int.Parse(ds.Tables[0].Rows[0]["GiftQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionType"]!=null && ds.Tables[0].Rows[0]["PromotionType"].ToString()!="")
				{
					model.PromotionType=int.Parse(ds.Tables[0].Rows[0]["PromotionType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionOn"]!=null && ds.Tables[0].Rows[0]["PromotionOn"].ToString()!="")
				{
					model.PromotionOn=int.Parse(ds.Tables[0].Rows[0]["PromotionOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AmountType"]!=null && ds.Tables[0].Rows[0]["AmountType"].ToString()!="")
				{
					model.AmountType=ds.Tables[0].Rows[0]["AmountType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Amount"]!=null && ds.Tables[0].Rows[0]["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(ds.Tables[0].Rows[0]["Amount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedBusDate"]!=null && ds.Tables[0].Rows[0]["CreatedBusDate"].ToString()!="")
				{
					model.CreatedBusDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedBusDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBusDate"]!=null && ds.Tables[0].Rows[0]["ApproveBusDate"].ToString()!="")
				{
					model.ApproveBusDate=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveBusDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApprovalCode"]!=null && ds.Tables[0].Rows[0]["ApprovalCode"].ToString()!="")
				{
					model.ApprovalCode=ds.Tables[0].Rows[0]["ApprovalCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApproveStatus"]!=null && ds.Tables[0].Rows[0]["ApproveStatus"].ToString()!="")
				{
					model.ApproveStatus=ds.Tables[0].Rows[0]["ApproveStatus"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ApproveOn"]!=null && ds.Tables[0].Rows[0]["ApproveOn"].ToString()!="")
				{
					model.ApproveOn=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveBy"]!=null && ds.Tables[0].Rows[0]["ApproveBy"].ToString()!="")
				{
					model.ApproveBy=int.Parse(ds.Tables[0].Rows[0]["ApproveBy"].ToString());
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
			strSql.Append("select MNMCode,MNMType,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyOnly,LoyaltyCardTypeCode,LoyaltyCardGradeCode,LoyaltyThreshold,HitType,HitOP,HitAmount,HitQty,GiftType,GiftQty,PromotionType,PromotionOn,AmountType,Amount,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_MNM_H ");
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
			strSql.Append(" MNMCode,MNMType,Description1,Description2,Description3,StoreCode,StoreGroupCode,StartDate,EndDate,StartTime,EndTime,DayFlagCode,WeekFlagCode,MonthFlagCode,LoyaltyOnly,LoyaltyCardTypeCode,LoyaltyCardGradeCode,LoyaltyThreshold,HitType,HitOP,HitAmount,HitQty,GiftType,GiftQty,PromotionType,PromotionOn,AmountType,Amount,Note,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_MNM_H ");
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
			strSql.Append("select count(1) FROM BUY_MNM_H ");
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
				strSql.Append("order by T.MNMCode desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_MNM_H T ");
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
			parameters[0].Value = "BUY_MNM_H";
			parameters[1].Value = "MNMCode";
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

