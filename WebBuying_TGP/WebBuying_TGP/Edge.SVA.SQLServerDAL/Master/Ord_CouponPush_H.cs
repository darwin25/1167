using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_CouponPush_H
	/// </summary>
	public partial class Ord_CouponPush_H:IOrd_CouponPush_H
	{
		public Ord_CouponPush_H()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CouponPushNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_CouponPush_H");
			strSql.Append(" where CouponPushNumber=@CouponPushNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponPushNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = CouponPushNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_CouponPush_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CouponPush_H(");
			strSql.Append("CouponPushNumber,PushCardBrandID,PushCardTypeID,PushCardGradeID,RepeatPush,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@CouponPushNumber,@PushCardBrandID,@PushCardTypeID,@PushCardGradeID,@RepeatPush,@Remark,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponPushNumber", SqlDbType.VarChar,64),
					new SqlParameter("@PushCardBrandID", SqlDbType.Int,4),
					new SqlParameter("@PushCardTypeID", SqlDbType.Int,4),
					new SqlParameter("@PushCardGradeID", SqlDbType.Int,4),
					new SqlParameter("@RepeatPush", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
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
			parameters[0].Value = model.CouponPushNumber;
			parameters[1].Value = model.PushCardBrandID;
			parameters[2].Value = model.PushCardTypeID;
			parameters[3].Value = model.PushCardGradeID;
			parameters[4].Value = model.RepeatPush;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.CreatedBusDate;
			parameters[7].Value = model.ApproveBusDate;
			parameters[8].Value = model.ApprovalCode;
			parameters[9].Value = model.ApproveStatus;
			parameters[10].Value = model.ApproveOn;
			parameters[11].Value = model.ApproveBy;
			parameters[12].Value = model.CreatedOn;
			parameters[13].Value = model.CreatedBy;
			parameters[14].Value = model.UpdatedOn;
			parameters[15].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.Ord_CouponPush_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CouponPush_H set ");
			strSql.Append("PushCardBrandID=@PushCardBrandID,");
			strSql.Append("PushCardTypeID=@PushCardTypeID,");
			strSql.Append("PushCardGradeID=@PushCardGradeID,");
			strSql.Append("RepeatPush=@RepeatPush,");
			strSql.Append("Remark=@Remark,");
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
			strSql.Append(" where CouponPushNumber=@CouponPushNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@PushCardBrandID", SqlDbType.Int,4),
					new SqlParameter("@PushCardTypeID", SqlDbType.Int,4),
					new SqlParameter("@PushCardGradeID", SqlDbType.Int,4),
					new SqlParameter("@RepeatPush", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
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
					new SqlParameter("@CouponPushNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = model.PushCardBrandID;
			parameters[1].Value = model.PushCardTypeID;
			parameters[2].Value = model.PushCardGradeID;
			parameters[3].Value = model.RepeatPush;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.CreatedBusDate;
			parameters[6].Value = model.ApproveBusDate;
			parameters[7].Value = model.ApprovalCode;
			parameters[8].Value = model.ApproveStatus;
			parameters[9].Value = model.ApproveOn;
			parameters[10].Value = model.ApproveBy;
			parameters[11].Value = model.CreatedOn;
			parameters[12].Value = model.CreatedBy;
			parameters[13].Value = model.UpdatedOn;
			parameters[14].Value = model.UpdatedBy;
			parameters[15].Value = model.CouponPushNumber;

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
		public bool Delete(string CouponPushNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponPush_H ");
			strSql.Append(" where CouponPushNumber=@CouponPushNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponPushNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = CouponPushNumber;

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
		public bool DeleteList(string CouponPushNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponPush_H ");
			strSql.Append(" where CouponPushNumber in ("+CouponPushNumberlist + ")  ");
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
		public Edge.SVA.Model.Ord_CouponPush_H GetModel(string CouponPushNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CouponPushNumber,PushCardBrandID,PushCardTypeID,PushCardGradeID,RepeatPush,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Ord_CouponPush_H ");
			strSql.Append(" where CouponPushNumber=@CouponPushNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponPushNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = CouponPushNumber;

			Edge.SVA.Model.Ord_CouponPush_H model=new Edge.SVA.Model.Ord_CouponPush_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CouponPushNumber"]!=null && ds.Tables[0].Rows[0]["CouponPushNumber"].ToString()!="")
				{
					model.CouponPushNumber=ds.Tables[0].Rows[0]["CouponPushNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PushCardBrandID"]!=null && ds.Tables[0].Rows[0]["PushCardBrandID"].ToString()!="")
				{
					model.PushCardBrandID=int.Parse(ds.Tables[0].Rows[0]["PushCardBrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PushCardTypeID"]!=null && ds.Tables[0].Rows[0]["PushCardTypeID"].ToString()!="")
				{
					model.PushCardTypeID=int.Parse(ds.Tables[0].Rows[0]["PushCardTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PushCardGradeID"]!=null && ds.Tables[0].Rows[0]["PushCardGradeID"].ToString()!="")
				{
					model.PushCardGradeID=int.Parse(ds.Tables[0].Rows[0]["PushCardGradeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RepeatPush"]!=null && ds.Tables[0].Rows[0]["RepeatPush"].ToString()!="")
				{
					model.RepeatPush=int.Parse(ds.Tables[0].Rows[0]["RepeatPush"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append("select CouponPushNumber,PushCardBrandID,PushCardTypeID,PushCardGradeID,RepeatPush,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_CouponPush_H ");
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
			strSql.Append(" CouponPushNumber,PushCardBrandID,PushCardTypeID,PushCardGradeID,RepeatPush,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_CouponPush_H ");
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
			strSql.Append("select count(1) FROM Ord_CouponPush_H ");
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
				strSql.Append("order by T.CouponPushNumber desc");
			}
			strSql.Append(")AS Row, T.*  from Ord_CouponPush_H T ");
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
			parameters[0].Value = "Ord_CouponPush_H";
			parameters[1].Value = "CouponPushNumber";
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

