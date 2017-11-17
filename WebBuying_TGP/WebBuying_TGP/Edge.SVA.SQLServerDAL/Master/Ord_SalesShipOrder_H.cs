using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_SalesShipOrder_H
    /// 创建者：Lisa
    /// 创建时间：2016-06-01
	/// </summary>
	public partial class Ord_SalesShipOrder_H:IOrd_SalesShipOrder_H
	{
		public Ord_SalesShipOrder_H()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SalesShipOrderNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_SalesShipOrder_H");
			strSql.Append(" where SalesShipOrderNumber=@SalesShipOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesShipOrderNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = SalesShipOrderNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_SalesShipOrder_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_SalesShipOrder_H(");
			strSql.Append("SalesShipOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,TxnNo,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@SalesShipOrderNumber,@OrderType,@MemberID,@CardNumber,@ReferenceNo,@TxnNo,@DeliveryFlag,@DeliveryCountry,@DeliveryProvince,@DeliveryCity,@DeliveryDistrict,@DeliveryAddressDetail,@DeliveryFullAddress,@DeliveryNumber,@LogisticsProviderID,@Contact,@ContactPhone,@RequestDeliveryDate,@DeliveryDate,@DeliveryBy,@Remark,@Status,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesShipOrderNumber", SqlDbType.VarChar,64),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.VarChar,64),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@TxnNo", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryFlag", SqlDbType.Int,4),
					new SqlParameter("@DeliveryCountry", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryProvince", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryCity", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryAddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryFullAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryNumber", SqlDbType.VarChar,64),
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@RequestDeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.SalesShipOrderNumber;
			parameters[1].Value = model.OrderType;
			parameters[2].Value = model.MemberID;
			parameters[3].Value = model.CardNumber;
			parameters[4].Value = model.ReferenceNo;
			parameters[5].Value = model.TxnNo;
			parameters[6].Value = model.DeliveryFlag;
			parameters[7].Value = model.DeliveryCountry;
			parameters[8].Value = model.DeliveryProvince;
			parameters[9].Value = model.DeliveryCity;
			parameters[10].Value = model.DeliveryDistrict;
			parameters[11].Value = model.DeliveryAddressDetail;
			parameters[12].Value = model.DeliveryFullAddress;
			parameters[13].Value = model.DeliveryNumber;
			parameters[14].Value = model.LogisticsProviderID;
			parameters[15].Value = model.Contact;
			parameters[16].Value = model.ContactPhone;
			parameters[17].Value = model.RequestDeliveryDate;
			parameters[18].Value = model.DeliveryDate;
			parameters[19].Value = model.DeliveryBy;
			parameters[20].Value = model.Remark;
			parameters[21].Value = model.Status;
			parameters[22].Value = model.CreatedOn;
			parameters[23].Value = model.CreatedBy;
			parameters[24].Value = model.UpdatedOn;
			parameters[25].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.Ord_SalesShipOrder_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_SalesShipOrder_H set ");
			strSql.Append("OrderType=@OrderType,");
			strSql.Append("MemberID=@MemberID,");
			strSql.Append("CardNumber=@CardNumber,");
			strSql.Append("ReferenceNo=@ReferenceNo,");
			strSql.Append("TxnNo=@TxnNo,");
			strSql.Append("DeliveryFlag=@DeliveryFlag,");
			strSql.Append("DeliveryCountry=@DeliveryCountry,");
			strSql.Append("DeliveryProvince=@DeliveryProvince,");
			strSql.Append("DeliveryCity=@DeliveryCity,");
			strSql.Append("DeliveryDistrict=@DeliveryDistrict,");
			strSql.Append("DeliveryAddressDetail=@DeliveryAddressDetail,");
			strSql.Append("DeliveryFullAddress=@DeliveryFullAddress,");
			strSql.Append("DeliveryNumber=@DeliveryNumber,");
			strSql.Append("LogisticsProviderID=@LogisticsProviderID,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("ContactPhone=@ContactPhone,");
			strSql.Append("RequestDeliveryDate=@RequestDeliveryDate,");
			strSql.Append("DeliveryDate=@DeliveryDate,");
			strSql.Append("DeliveryBy=@DeliveryBy,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where SalesShipOrderNumber=@SalesShipOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.VarChar,64),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@TxnNo", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryFlag", SqlDbType.Int,4),
					new SqlParameter("@DeliveryCountry", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryProvince", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryCity", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@DeliveryAddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryFullAddress", SqlDbType.NVarChar,512),
					new SqlParameter("@DeliveryNumber", SqlDbType.VarChar,64),
					new SqlParameter("@LogisticsProviderID", SqlDbType.Int,4),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@RequestDeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@DeliveryBy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@SalesShipOrderNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = model.OrderType;
			parameters[1].Value = model.MemberID;
			parameters[2].Value = model.CardNumber;
			parameters[3].Value = model.ReferenceNo;
			parameters[4].Value = model.TxnNo;
			parameters[5].Value = model.DeliveryFlag;
			parameters[6].Value = model.DeliveryCountry;
			parameters[7].Value = model.DeliveryProvince;
			parameters[8].Value = model.DeliveryCity;
			parameters[9].Value = model.DeliveryDistrict;
			parameters[10].Value = model.DeliveryAddressDetail;
			parameters[11].Value = model.DeliveryFullAddress;
			parameters[12].Value = model.DeliveryNumber;
			parameters[13].Value = model.LogisticsProviderID;
			parameters[14].Value = model.Contact;
			parameters[15].Value = model.ContactPhone;
			parameters[16].Value = model.RequestDeliveryDate;
			parameters[17].Value = model.DeliveryDate;
			parameters[18].Value = model.DeliveryBy;
			parameters[19].Value = model.Remark;
			parameters[20].Value = model.Status;
			parameters[21].Value = model.CreatedOn;
			parameters[22].Value = model.CreatedBy;
			parameters[23].Value = model.UpdatedOn;
			parameters[24].Value = model.UpdatedBy;
			parameters[25].Value = model.SalesShipOrderNumber;

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
		public bool Delete(string SalesShipOrderNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_SalesShipOrder_H ");
			strSql.Append(" where SalesShipOrderNumber=@SalesShipOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesShipOrderNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = SalesShipOrderNumber;

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
		public bool DeleteList(string SalesShipOrderNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_SalesShipOrder_H ");
			strSql.Append(" where SalesShipOrderNumber in ("+SalesShipOrderNumberlist + ")  ");
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
		public Edge.SVA.Model.Ord_SalesShipOrder_H GetModel(string SalesShipOrderNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SalesShipOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,TxnNo,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Ord_SalesShipOrder_H ");
			strSql.Append(" where SalesShipOrderNumber=@SalesShipOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesShipOrderNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = SalesShipOrderNumber;

			Edge.SVA.Model.Ord_SalesShipOrder_H model=new Edge.SVA.Model.Ord_SalesShipOrder_H();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.Ord_SalesShipOrder_H DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.Ord_SalesShipOrder_H model=new Edge.SVA.Model.Ord_SalesShipOrder_H();
			if (row != null)
			{
				if(row["SalesShipOrderNumber"]!=null)
				{
					model.SalesShipOrderNumber=row["SalesShipOrderNumber"].ToString();
				}
				if(row["OrderType"]!=null && row["OrderType"].ToString()!="")
				{
					model.OrderType=int.Parse(row["OrderType"].ToString());
				}
				if(row["MemberID"]!=null)
				{
					model.MemberID=row["MemberID"].ToString();
				}
				if(row["CardNumber"]!=null)
				{
					model.CardNumber=row["CardNumber"].ToString();
				}
				if(row["ReferenceNo"]!=null)
				{
					model.ReferenceNo=row["ReferenceNo"].ToString();
				}
				if(row["TxnNo"]!=null)
				{
					model.TxnNo=row["TxnNo"].ToString();
				}
				if(row["DeliveryFlag"]!=null && row["DeliveryFlag"].ToString()!="")
				{
					model.DeliveryFlag=int.Parse(row["DeliveryFlag"].ToString());
				}
				if(row["DeliveryCountry"]!=null)
				{
					model.DeliveryCountry=row["DeliveryCountry"].ToString();
				}
				if(row["DeliveryProvince"]!=null)
				{
					model.DeliveryProvince=row["DeliveryProvince"].ToString();
				}
				if(row["DeliveryCity"]!=null)
				{
					model.DeliveryCity=row["DeliveryCity"].ToString();
				}
				if(row["DeliveryDistrict"]!=null)
				{
					model.DeliveryDistrict=row["DeliveryDistrict"].ToString();
				}
				if(row["DeliveryAddressDetail"]!=null)
				{
					model.DeliveryAddressDetail=row["DeliveryAddressDetail"].ToString();
				}
				if(row["DeliveryFullAddress"]!=null)
				{
					model.DeliveryFullAddress=row["DeliveryFullAddress"].ToString();
				}
				if(row["DeliveryNumber"]!=null)
				{
					model.DeliveryNumber=row["DeliveryNumber"].ToString();
				}
				if(row["LogisticsProviderID"]!=null && row["LogisticsProviderID"].ToString()!="")
				{
					model.LogisticsProviderID=int.Parse(row["LogisticsProviderID"].ToString());
				}
				if(row["Contact"]!=null)
				{
					model.Contact=row["Contact"].ToString();
				}
				if(row["ContactPhone"]!=null)
				{
					model.ContactPhone=row["ContactPhone"].ToString();
				}
				if(row["RequestDeliveryDate"]!=null && row["RequestDeliveryDate"].ToString()!="")
				{
					model.RequestDeliveryDate=DateTime.Parse(row["RequestDeliveryDate"].ToString());
				}
				if(row["DeliveryDate"]!=null && row["DeliveryDate"].ToString()!="")
				{
					model.DeliveryDate=DateTime.Parse(row["DeliveryDate"].ToString());
				}
				if(row["DeliveryBy"]!=null && row["DeliveryBy"].ToString()!="")
				{
					model.DeliveryBy=int.Parse(row["DeliveryBy"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreatedOn"]!=null && row["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(row["CreatedOn"].ToString());
				}
				if(row["CreatedBy"]!=null && row["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=int.Parse(row["CreatedBy"].ToString());
				}
				if(row["UpdatedOn"]!=null && row["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(row["UpdatedOn"].ToString());
				}
				if(row["UpdatedBy"]!=null && row["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=int.Parse(row["UpdatedBy"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SalesShipOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,TxnNo,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_SalesShipOrder_H ");
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
			strSql.Append(" SalesShipOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,TxnNo,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_SalesShipOrder_H ");
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
			strSql.Append("select count(1) FROM Ord_SalesShipOrder_H ");
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
				strSql.Append("order by T.SalesShipOrderNumber desc");
			}
			strSql.Append(")AS Row, T.*  from Ord_SalesShipOrder_H T ");
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
			parameters[0].Value = "Ord_SalesShipOrder_H";
			parameters[1].Value = "SalesShipOrderNumber";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
	}
}

