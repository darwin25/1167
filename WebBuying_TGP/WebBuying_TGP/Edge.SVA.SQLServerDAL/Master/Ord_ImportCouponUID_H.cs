using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_ImportCouponUID_H
	/// </summary>
	public partial class Ord_ImportCouponUID_H:IOrd_ImportCouponUID_H
	{
		public Ord_ImportCouponUID_H()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ImportCouponNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_ImportCouponUID_H");
			strSql.Append(" where ImportCouponNumber=@ImportCouponNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = ImportCouponNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_ImportCouponUID_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_ImportCouponUID_H(");
			strSql.Append("ImportCouponNumber,ImportCouponDesc1,ImportCouponDesc2,ImportCouponDesc3,NeedActive,NeedNewBatch,CouponCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode)");
			strSql.Append(" values (");
			strSql.Append("@ImportCouponNumber,@ImportCouponDesc1,@ImportCouponDesc2,@ImportCouponDesc3,@NeedActive,@NeedNewBatch,@CouponCount,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@CreatedBusDate,@ApproveBusDate,@ApprovalCode)");
			SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512),
					new SqlParameter("@ImportCouponDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ImportCouponDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ImportCouponDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@NeedActive", SqlDbType.Int,4),
					new SqlParameter("@NeedNewBatch", SqlDbType.Int,4),
					new SqlParameter("@CouponCount", SqlDbType.Int,4),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ImportCouponNumber;
			parameters[1].Value = model.ImportCouponDesc1;
			parameters[2].Value = model.ImportCouponDesc2;
			parameters[3].Value = model.ImportCouponDesc3;
			parameters[4].Value = model.NeedActive;
			parameters[5].Value = model.NeedNewBatch;
			parameters[6].Value = model.CouponCount;
			parameters[7].Value = model.ApproveStatus;
			parameters[8].Value = model.ApproveOn;
			parameters[9].Value = model.ApproveBy;
			parameters[10].Value = model.CreatedOn;
			parameters[11].Value = model.CreatedBy;
			parameters[12].Value = model.UpdatedOn;
			parameters[13].Value = model.UpdatedBy;
			parameters[14].Value = model.CreatedBusDate;
			parameters[15].Value = model.ApproveBusDate;
			parameters[16].Value = model.ApprovalCode;

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
		public bool Update(Edge.SVA.Model.Ord_ImportCouponUID_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_ImportCouponUID_H set ");
			strSql.Append("ImportCouponDesc1=@ImportCouponDesc1,");
			strSql.Append("ImportCouponDesc2=@ImportCouponDesc2,");
			strSql.Append("ImportCouponDesc3=@ImportCouponDesc3,");
			strSql.Append("NeedActive=@NeedActive,");
			strSql.Append("NeedNewBatch=@NeedNewBatch,");
			strSql.Append("CouponCount=@CouponCount,");
			strSql.Append("ApproveStatus=@ApproveStatus,");
			strSql.Append("ApproveOn=@ApproveOn,");
			strSql.Append("ApproveBy=@ApproveBy,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("CreatedBusDate=@CreatedBusDate,");
			strSql.Append("ApproveBusDate=@ApproveBusDate,");
			strSql.Append("ApprovalCode=@ApprovalCode");
			strSql.Append(" where ImportCouponNumber=@ImportCouponNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponDesc1", SqlDbType.NVarChar,512),
					new SqlParameter("@ImportCouponDesc2", SqlDbType.NVarChar,512),
					new SqlParameter("@ImportCouponDesc3", SqlDbType.NVarChar,512),
					new SqlParameter("@NeedActive", SqlDbType.Int,4),
					new SqlParameter("@NeedNewBatch", SqlDbType.Int,4),
					new SqlParameter("@CouponCount", SqlDbType.Int,4),
					new SqlParameter("@ApproveStatus", SqlDbType.Char,1),
					new SqlParameter("@ApproveOn", SqlDbType.DateTime),
					new SqlParameter("@ApproveBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@CreatedBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApproveBusDate", SqlDbType.DateTime),
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,512),
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ImportCouponDesc1;
			parameters[1].Value = model.ImportCouponDesc2;
			parameters[2].Value = model.ImportCouponDesc3;
			parameters[3].Value = model.NeedActive;
			parameters[4].Value = model.NeedNewBatch;
			parameters[5].Value = model.CouponCount;
			parameters[6].Value = model.ApproveStatus;
			parameters[7].Value = model.ApproveOn;
			parameters[8].Value = model.ApproveBy;
			parameters[9].Value = model.CreatedOn;
			parameters[10].Value = model.CreatedBy;
			parameters[11].Value = model.UpdatedOn;
			parameters[12].Value = model.UpdatedBy;
			parameters[13].Value = model.CreatedBusDate;
			parameters[14].Value = model.ApproveBusDate;
			parameters[15].Value = model.ApprovalCode;
			parameters[16].Value = model.ImportCouponNumber;

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
		public bool Delete(string ImportCouponNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_ImportCouponUID_H ");
			strSql.Append(" where ImportCouponNumber=@ImportCouponNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = ImportCouponNumber;

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
		public bool DeleteList(string ImportCouponNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_ImportCouponUID_H ");
			strSql.Append(" where ImportCouponNumber in ("+ImportCouponNumberlist + ")  ");
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
		public Edge.SVA.Model.Ord_ImportCouponUID_H GetModel(string ImportCouponNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ImportCouponNumber,ImportCouponDesc1,ImportCouponDesc2,ImportCouponDesc3,NeedActive,NeedNewBatch,CouponCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode from Ord_ImportCouponUID_H ");
			strSql.Append(" where ImportCouponNumber=@ImportCouponNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@ImportCouponNumber", SqlDbType.VarChar,512)};
			parameters[0].Value = ImportCouponNumber;

			Edge.SVA.Model.Ord_ImportCouponUID_H model=new Edge.SVA.Model.Ord_ImportCouponUID_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ImportCouponNumber"]!=null && ds.Tables[0].Rows[0]["ImportCouponNumber"].ToString()!="")
				{
					model.ImportCouponNumber=ds.Tables[0].Rows[0]["ImportCouponNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ImportCouponDesc1"]!=null && ds.Tables[0].Rows[0]["ImportCouponDesc1"].ToString()!="")
				{
					model.ImportCouponDesc1=ds.Tables[0].Rows[0]["ImportCouponDesc1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ImportCouponDesc2"]!=null && ds.Tables[0].Rows[0]["ImportCouponDesc2"].ToString()!="")
				{
					model.ImportCouponDesc2=ds.Tables[0].Rows[0]["ImportCouponDesc2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ImportCouponDesc3"]!=null && ds.Tables[0].Rows[0]["ImportCouponDesc3"].ToString()!="")
				{
					model.ImportCouponDesc3=ds.Tables[0].Rows[0]["ImportCouponDesc3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NeedActive"]!=null && ds.Tables[0].Rows[0]["NeedActive"].ToString()!="")
				{
					model.NeedActive=int.Parse(ds.Tables[0].Rows[0]["NeedActive"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NeedNewBatch"]!=null && ds.Tables[0].Rows[0]["NeedNewBatch"].ToString()!="")
				{
					model.NeedNewBatch=int.Parse(ds.Tables[0].Rows[0]["NeedNewBatch"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CouponCount"]!=null && ds.Tables[0].Rows[0]["CouponCount"].ToString()!="")
				{
					model.CouponCount=int.Parse(ds.Tables[0].Rows[0]["CouponCount"].ToString());
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
			strSql.Append("select ImportCouponNumber,ImportCouponDesc1,ImportCouponDesc2,ImportCouponDesc3,NeedActive,NeedNewBatch,CouponCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode ");
			strSql.Append(" FROM Ord_ImportCouponUID_H ");
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
			strSql.Append(" ImportCouponNumber,ImportCouponDesc1,ImportCouponDesc2,ImportCouponDesc3,NeedActive,NeedNewBatch,CouponCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode ");
			strSql.Append(" FROM Ord_ImportCouponUID_H ");
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
            parameters[0].Value = "Ord_ImportCouponUID_H";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 1;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from Ord_ImportCouponUID_H ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

