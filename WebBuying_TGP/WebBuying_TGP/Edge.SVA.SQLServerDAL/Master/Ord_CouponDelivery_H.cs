using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_CouponDelivery_H
	/// </summary>
	public partial class Ord_CouponDelivery_H:IOrd_CouponDelivery_H
	{
		public Ord_CouponDelivery_H()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CouponDeliveryNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_CouponDelivery_H");
			strSql.Append(" where CouponDeliveryNumber=@CouponDeliveryNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponDeliveryNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = CouponDeliveryNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_CouponDelivery_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CouponDelivery_H(");
			strSql.Append("CouponDeliveryNumber,ReferenceNo,StoreID,NeedActive,CustomerType,CustomerID,SendMethod,SendAddress,ContactName,ContactNumber,Email,SMSMMS,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@CouponDeliveryNumber,@ReferenceNo,@StoreID,@NeedActive,@CustomerType,@CustomerID,@SendMethod,@SendAddress,@ContactName,@ContactNumber,@Email,@SMSMMS,@Remark,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponDeliveryNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@NeedActive", SqlDbType.Int,4),
					new SqlParameter("@CustomerType", SqlDbType.Int,4),
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@SendMethod", SqlDbType.Int,4),
					new SqlParameter("@SendAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactName", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Email", SqlDbType.NVarChar,512),
					new SqlParameter("@SMSMMS", SqlDbType.NVarChar,512),
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
			parameters[0].Value = model.CouponDeliveryNumber;
			parameters[1].Value = model.ReferenceNo;
			parameters[2].Value = model.StoreID;
			parameters[3].Value = model.NeedActive;
			parameters[4].Value = model.CustomerType;
			parameters[5].Value = model.CustomerID;
			parameters[6].Value = model.SendMethod;
			parameters[7].Value = model.SendAddress;
			parameters[8].Value = model.ContactName;
			parameters[9].Value = model.ContactNumber;
			parameters[10].Value = model.Email;
			parameters[11].Value = model.SMSMMS;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.CreatedBusDate;
			parameters[14].Value = model.ApproveBusDate;
			parameters[15].Value = model.ApprovalCode;
			parameters[16].Value = model.ApproveStatus;
			parameters[17].Value = model.ApproveOn;
			parameters[18].Value = model.ApproveBy;
			parameters[19].Value = model.CreatedOn;
			parameters[20].Value = model.CreatedBy;
			parameters[21].Value = model.UpdatedOn;
			parameters[22].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.Ord_CouponDelivery_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CouponDelivery_H set ");
			strSql.Append("ReferenceNo=@ReferenceNo,");
			strSql.Append("StoreID=@StoreID,");
			strSql.Append("NeedActive=@NeedActive,");
			strSql.Append("CustomerType=@CustomerType,");
			strSql.Append("CustomerID=@CustomerID,");
			strSql.Append("SendMethod=@SendMethod,");
			strSql.Append("SendAddress=@SendAddress,");
			strSql.Append("ContactName=@ContactName,");
			strSql.Append("ContactNumber=@ContactNumber,");
			strSql.Append("Email=@Email,");
			strSql.Append("SMSMMS=@SMSMMS,");
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
			strSql.Append(" where CouponDeliveryNumber=@CouponDeliveryNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@NeedActive", SqlDbType.Int,4),
					new SqlParameter("@CustomerType", SqlDbType.Int,4),
					new SqlParameter("@CustomerID", SqlDbType.Int,4),
					new SqlParameter("@SendMethod", SqlDbType.Int,4),
					new SqlParameter("@SendAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactName", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactNumber", SqlDbType.NVarChar,512),
					new SqlParameter("@Email", SqlDbType.NVarChar,512),
					new SqlParameter("@SMSMMS", SqlDbType.NVarChar,512),
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
					new SqlParameter("@CouponDeliveryNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ReferenceNo;
			parameters[1].Value = model.StoreID;
			parameters[2].Value = model.NeedActive;
			parameters[3].Value = model.CustomerType;
			parameters[4].Value = model.CustomerID;
			parameters[5].Value = model.SendMethod;
			parameters[6].Value = model.SendAddress;
			parameters[7].Value = model.ContactName;
			parameters[8].Value = model.ContactNumber;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.SMSMMS;
			parameters[11].Value = model.Remark;
			parameters[12].Value = model.CreatedBusDate;
			parameters[13].Value = model.ApproveBusDate;
			parameters[14].Value = model.ApprovalCode;
			parameters[15].Value = model.ApproveStatus;
			parameters[16].Value = model.ApproveOn;
			parameters[17].Value = model.ApproveBy;
			parameters[18].Value = model.CreatedOn;
			parameters[19].Value = model.CreatedBy;
			parameters[20].Value = model.UpdatedOn;
			parameters[21].Value = model.UpdatedBy;
			parameters[22].Value = model.CouponDeliveryNumber;

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
		public bool Delete(string CouponDeliveryNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponDelivery_H ");
			strSql.Append(" where CouponDeliveryNumber=@CouponDeliveryNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponDeliveryNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = CouponDeliveryNumber;

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
		public bool DeleteList(string CouponDeliveryNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponDelivery_H ");
			strSql.Append(" where CouponDeliveryNumber in ("+CouponDeliveryNumberlist + ")  ");
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
		public Edge.SVA.Model.Ord_CouponDelivery_H GetModel(string CouponDeliveryNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CouponDeliveryNumber,ReferenceNo,StoreID,NeedActive,CustomerType,CustomerID,SendMethod,SendAddress,ContactName,ContactNumber,Email,SMSMMS,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Ord_CouponDelivery_H ");
			strSql.Append(" where CouponDeliveryNumber=@CouponDeliveryNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponDeliveryNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = CouponDeliveryNumber;

			Edge.SVA.Model.Ord_CouponDelivery_H model=new Edge.SVA.Model.Ord_CouponDelivery_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CouponDeliveryNumber"]!=null && ds.Tables[0].Rows[0]["CouponDeliveryNumber"].ToString()!="")
				{
					model.CouponDeliveryNumber=ds.Tables[0].Rows[0]["CouponDeliveryNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReferenceNo"]!=null && ds.Tables[0].Rows[0]["ReferenceNo"].ToString()!="")
				{
					model.ReferenceNo=ds.Tables[0].Rows[0]["ReferenceNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StoreID"]!=null && ds.Tables[0].Rows[0]["StoreID"].ToString()!="")
				{
					model.StoreID=int.Parse(ds.Tables[0].Rows[0]["StoreID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NeedActive"]!=null && ds.Tables[0].Rows[0]["NeedActive"].ToString()!="")
				{
					model.NeedActive=int.Parse(ds.Tables[0].Rows[0]["NeedActive"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CustomerType"]!=null && ds.Tables[0].Rows[0]["CustomerType"].ToString()!="")
				{
					model.CustomerType=int.Parse(ds.Tables[0].Rows[0]["CustomerType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CustomerID"]!=null && ds.Tables[0].Rows[0]["CustomerID"].ToString()!="")
				{
					model.CustomerID=int.Parse(ds.Tables[0].Rows[0]["CustomerID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendMethod"]!=null && ds.Tables[0].Rows[0]["SendMethod"].ToString()!="")
				{
					model.SendMethod=int.Parse(ds.Tables[0].Rows[0]["SendMethod"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendAddress"]!=null && ds.Tables[0].Rows[0]["SendAddress"].ToString()!="")
				{
					model.SendAddress=ds.Tables[0].Rows[0]["SendAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactName"]!=null && ds.Tables[0].Rows[0]["ContactName"].ToString()!="")
				{
					model.ContactName=ds.Tables[0].Rows[0]["ContactName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactNumber"]!=null && ds.Tables[0].Rows[0]["ContactNumber"].ToString()!="")
				{
					model.ContactNumber=ds.Tables[0].Rows[0]["ContactNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SMSMMS"]!=null && ds.Tables[0].Rows[0]["SMSMMS"].ToString()!="")
				{
					model.SMSMMS=ds.Tables[0].Rows[0]["SMSMMS"].ToString();
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
			strSql.Append("select CouponDeliveryNumber,ReferenceNo,StoreID,NeedActive,CustomerType,CustomerID,SendMethod,SendAddress,ContactName,ContactNumber,Email,SMSMMS,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_CouponDelivery_H ");
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
			strSql.Append(" CouponDeliveryNumber,ReferenceNo,StoreID,NeedActive,CustomerType,CustomerID,SendMethod,SendAddress,ContactName,ContactNumber,Email,SMSMMS,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_CouponDelivery_H ");
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
            parameters[0].Value = "Ord_CouponDelivery_H";
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
            sql.Append("select count(*) from Ord_CouponDelivery_H ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

