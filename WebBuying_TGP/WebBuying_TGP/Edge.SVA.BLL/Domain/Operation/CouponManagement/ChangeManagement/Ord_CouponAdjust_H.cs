using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Edge.DBUtility;

namespace Edge.SVA.BLL.Domain.Operation.CouponManagement.ChangeManagement
{
    public class Ord_CouponAdjust_H
    {
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Ord_CouponAdjust_H model,SqlTransaction trans)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_CouponAdjust_H(");
			strSql.Append("CouponAdjustNumber,OprID,OriginalTxnNo,TxnDate,StoreCode,ServerCode,RegisterCode,ReasonID,Note,ActExpireDate,CouponCount,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,CreatedBusDate,ApproveBusDate,ApprovalCode,BrandCode,ActAmount)");
			strSql.Append(" values (");
			strSql.Append("@CouponAdjustNumber,@OprID,@OriginalTxnNo,@TxnDate,@StoreCode,@ServerCode,@RegisterCode,@ReasonID,@Note,@ActExpireDate,@CouponCount,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@BrandCode,@ActAmount)");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponAdjustNumber", SqlDbType.VarChar,64),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@OriginalTxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@ServerCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReasonID", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,512),
					new SqlParameter("@ActExpireDate", SqlDbType.DateTime),
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
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@ActAmount", SqlDbType.Money,8)};
			parameters[0].Value = model.CouponAdjustNumber;
			parameters[1].Value = model.OprID;
			parameters[2].Value = model.OriginalTxnNo;
			parameters[3].Value = model.TxnDate;
			parameters[4].Value = model.StoreCode;
			parameters[5].Value = model.ServerCode;
			parameters[6].Value = model.RegisterCode;
			parameters[7].Value = model.ReasonID;
			parameters[8].Value = model.Note;
			parameters[9].Value = model.ActExpireDate;
			parameters[10].Value = model.CouponCount;
			parameters[11].Value = model.ApproveStatus;
			parameters[12].Value = model.ApproveOn;
			parameters[13].Value = model.ApproveBy;
			parameters[14].Value = model.CreatedOn;
			parameters[15].Value = model.CreatedBy;
			parameters[16].Value = model.UpdatedOn;
			parameters[17].Value = model.UpdatedBy;
			parameters[18].Value = model.CreatedBusDate;
			parameters[19].Value = model.ApproveBusDate;
			parameters[20].Value = model.ApprovalCode;
			parameters[21].Value = model.BrandCode;
			parameters[22].Value = model.ActAmount;

			//将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            //添加主表时需要返回主键ID
            object id = SqlHelper.NewExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL

            return Convert.ToInt32(id);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Edge.SVA.Model.Ord_CouponAdjust_H model,SqlTransaction trans)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_CouponAdjust_H set ");
			strSql.Append("OprID=@OprID,");
			strSql.Append("OriginalTxnNo=@OriginalTxnNo,");
			strSql.Append("TxnDate=@TxnDate,");
			strSql.Append("StoreCode=@StoreCode,");
			strSql.Append("ServerCode=@ServerCode,");
			strSql.Append("RegisterCode=@RegisterCode,");
			strSql.Append("ReasonID=@ReasonID,");
			strSql.Append("Note=@Note,");
			strSql.Append("ActExpireDate=@ActExpireDate,");
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
			strSql.Append("ApprovalCode=@ApprovalCode,");
			strSql.Append("BrandCode=@BrandCode,");
			strSql.Append("ActAmount=@ActAmount");
			strSql.Append(" where CouponAdjustNumber=@CouponAdjustNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@OriginalTxnNo", SqlDbType.VarChar,512),
					new SqlParameter("@TxnDate", SqlDbType.DateTime),
					new SqlParameter("@StoreCode", SqlDbType.VarChar,64),
					new SqlParameter("@ServerCode", SqlDbType.VarChar,64),
					new SqlParameter("@RegisterCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReasonID", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,512),
					new SqlParameter("@ActExpireDate", SqlDbType.DateTime),
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
					new SqlParameter("@ApprovalCode", SqlDbType.VarChar,64),
					new SqlParameter("@BrandCode", SqlDbType.VarChar,64),
					new SqlParameter("@ActAmount", SqlDbType.Money,8),
					new SqlParameter("@CouponAdjustNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = model.OprID;
			parameters[1].Value = model.OriginalTxnNo;
			parameters[2].Value = model.TxnDate;
			parameters[3].Value = model.StoreCode;
			parameters[4].Value = model.ServerCode;
			parameters[5].Value = model.RegisterCode;
			parameters[6].Value = model.ReasonID;
			parameters[7].Value = model.Note;
			parameters[8].Value = model.ActExpireDate;
			parameters[9].Value = model.CouponCount;
			parameters[10].Value = model.ApproveStatus;
			parameters[11].Value = model.ApproveOn;
			parameters[12].Value = model.ApproveBy;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;
			parameters[17].Value = model.CreatedBusDate;
			parameters[18].Value = model.ApproveBusDate;
			parameters[19].Value = model.ApprovalCode;
			parameters[20].Value = model.BrandCode;
			parameters[21].Value = model.ActAmount;
			parameters[22].Value = model.CouponAdjustNumber;

			//将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string CouponAdjustNumber,SqlTransaction trans)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_CouponAdjust_H ");
			strSql.Append(" where CouponAdjustNumber=@CouponAdjustNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@CouponAdjustNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = CouponAdjustNumber;

			//将空值赋值为默认值
            foreach (SqlParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            SqlHelper.ExecuteNonQuery(trans, CommandType.Text, strSql.ToString(), parameters);//执行多个不同的DAL
		}
    }
}
