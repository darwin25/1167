﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:OtherExchangeRate
	/// </summary>
	public partial class OtherExchangeRate:IOtherExchangeRate
	{
		public OtherExchangeRate()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "OtherExchangeRate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OtherExchangeRate");
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
		public int Add(Edge.SVA.Model.OtherExchangeRate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OtherExchangeRate(");
			strSql.Append("BankID,AccountCode,InputValueType,OutputValueType,ExchangeRate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@BankID,@AccountCode,@InputValueType,@OutputValueType,@ExchangeRate,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@AccountCode", SqlDbType.VarChar,512),
					new SqlParameter("@InputValueType", SqlDbType.Int,4),
					new SqlParameter("@OutputValueType", SqlDbType.Int,4),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.BankID;
			parameters[1].Value = model.AccountCode;
			parameters[2].Value = model.InputValueType;
			parameters[3].Value = model.OutputValueType;
			parameters[4].Value = model.ExchangeRate;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.OtherExchangeRate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OtherExchangeRate set ");
			strSql.Append("BankID=@BankID,");
			strSql.Append("AccountCode=@AccountCode,");
			strSql.Append("InputValueType=@InputValueType,");
			strSql.Append("OutputValueType=@OutputValueType,");
			strSql.Append("ExchangeRate=@ExchangeRate,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@BankID", SqlDbType.Int,4),
					new SqlParameter("@AccountCode", SqlDbType.VarChar,512),
					new SqlParameter("@InputValueType", SqlDbType.Int,4),
					new SqlParameter("@OutputValueType", SqlDbType.Int,4),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.BankID;
			parameters[1].Value = model.AccountCode;
			parameters[2].Value = model.InputValueType;
			parameters[3].Value = model.OutputValueType;
			parameters[4].Value = model.ExchangeRate;
			parameters[5].Value = model.CreatedOn;
			parameters[6].Value = model.CreatedBy;
			parameters[7].Value = model.UpdatedOn;
			parameters[8].Value = model.UpdatedBy;
			parameters[9].Value = model.KeyID;

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
			strSql.Append("delete from OtherExchangeRate ");
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
			strSql.Append("delete from OtherExchangeRate ");
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
		public Edge.SVA.Model.OtherExchangeRate GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,BankID,AccountCode,InputValueType,OutputValueType,ExchangeRate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from OtherExchangeRate ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.OtherExchangeRate model=new Edge.SVA.Model.OtherExchangeRate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BankID"]!=null && ds.Tables[0].Rows[0]["BankID"].ToString()!="")
				{
					model.BankID=int.Parse(ds.Tables[0].Rows[0]["BankID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AccountCode"]!=null && ds.Tables[0].Rows[0]["AccountCode"].ToString()!="")
				{
					model.AccountCode=ds.Tables[0].Rows[0]["AccountCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InputValueType"]!=null && ds.Tables[0].Rows[0]["InputValueType"].ToString()!="")
				{
					model.InputValueType=int.Parse(ds.Tables[0].Rows[0]["InputValueType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OutputValueType"]!=null && ds.Tables[0].Rows[0]["OutputValueType"].ToString()!="")
				{
					model.OutputValueType=int.Parse(ds.Tables[0].Rows[0]["OutputValueType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExchangeRate"]!=null && ds.Tables[0].Rows[0]["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
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
			strSql.Append("select KeyID,BankID,AccountCode,InputValueType,OutputValueType,ExchangeRate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM OtherExchangeRate ");
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
			strSql.Append(" KeyID,BankID,AccountCode,InputValueType,OutputValueType,ExchangeRate,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM OtherExchangeRate ");
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
			parameters[0].Value = "OtherExchangeRate";
            parameters[1].Value = "*";
            parameters[2].Value = filedOrder;
            parameters[3].Value = "";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("sp_GetRecordByPageOrder", parameters, "ds");
        }

        /// <summary>
        /// 获取行总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder sql = new StringBuilder(200);
            sql.Append("select count(*) from OtherExchangeRate ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}