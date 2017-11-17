using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Ord_SalesPickOrder_H
    /// 创建者：Lisa
    /// 创建时间：2016-06-01
	/// </summary>
	public partial class Ord_SalesPickOrder_H:IOrd_SalesPickOrder_H
	{
		public Ord_SalesPickOrder_H()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SalesPickOrderNumber)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ord_SalesPickOrder_H");
			strSql.Append(" where SalesPickOrderNumber=@SalesPickOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = SalesPickOrderNumber;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.Ord_SalesPickOrder_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ord_SalesPickOrder_H(");
			strSql.Append("SalesPickOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,PickupLocation,PickupStaff,PickupDate,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@SalesPickOrderNumber,@OrderType,@MemberID,@CardNumber,@ReferenceNo,@PickupLocation,@PickupStaff,@PickupDate,@DeliveryFlag,@DeliveryCountry,@DeliveryProvince,@DeliveryCity,@DeliveryDistrict,@DeliveryAddressDetail,@DeliveryFullAddress,@DeliveryNumber,@LogisticsProviderID,@Contact,@ContactPhone,@RequestDeliveryDate,@DeliveryDate,@DeliveryBy,@Remark,@CreatedBusDate,@ApproveBusDate,@ApprovalCode,@ApproveStatus,@ApproveOn,@ApproveBy,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64),
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.VarChar,64),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@PickupLocation", SqlDbType.VarChar,64),
					new SqlParameter("@PickupStaff", SqlDbType.VarChar,64),
					new SqlParameter("@PickupDate", SqlDbType.DateTime),
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
			parameters[0].Value = model.SalesPickOrderNumber;
			parameters[1].Value = model.OrderType;
			parameters[2].Value = model.MemberID;
			parameters[3].Value = model.CardNumber;
			parameters[4].Value = model.ReferenceNo;
			parameters[5].Value = model.PickupLocation;
			parameters[6].Value = model.PickupStaff;
			parameters[7].Value = model.PickupDate;
			parameters[8].Value = model.DeliveryFlag;
			parameters[9].Value = model.DeliveryCountry;
			parameters[10].Value = model.DeliveryProvince;
			parameters[11].Value = model.DeliveryCity;
			parameters[12].Value = model.DeliveryDistrict;
			parameters[13].Value = model.DeliveryAddressDetail;
			parameters[14].Value = model.DeliveryFullAddress;
			parameters[15].Value = model.DeliveryNumber;
			parameters[16].Value = model.LogisticsProviderID;
			parameters[17].Value = model.Contact;
			parameters[18].Value = model.ContactPhone;
			parameters[19].Value = model.RequestDeliveryDate;
			parameters[20].Value = model.DeliveryDate;
			parameters[21].Value = model.DeliveryBy;
			parameters[22].Value = model.Remark;
			parameters[23].Value = model.CreatedBusDate;
			parameters[24].Value = model.ApproveBusDate;
			parameters[25].Value = model.ApprovalCode;
			parameters[26].Value = model.ApproveStatus;
			parameters[27].Value = model.ApproveOn;
			parameters[28].Value = model.ApproveBy;
			parameters[29].Value = model.CreatedOn;
			parameters[30].Value = model.CreatedBy;
			parameters[31].Value = model.UpdatedOn;
			parameters[32].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.Ord_SalesPickOrder_H model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ord_SalesPickOrder_H set ");
			strSql.Append("OrderType=@OrderType,");
			strSql.Append("MemberID=@MemberID,");
			strSql.Append("CardNumber=@CardNumber,");
			strSql.Append("ReferenceNo=@ReferenceNo,");
			strSql.Append("PickupLocation=@PickupLocation,");
			strSql.Append("PickupStaff=@PickupStaff,");
			strSql.Append("PickupDate=@PickupDate,");
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
			strSql.Append(" where SalesPickOrderNumber=@SalesPickOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderType", SqlDbType.Int,4),
					new SqlParameter("@MemberID", SqlDbType.VarChar,64),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,64),
					new SqlParameter("@ReferenceNo", SqlDbType.VarChar,64),
					new SqlParameter("@PickupLocation", SqlDbType.VarChar,64),
					new SqlParameter("@PickupStaff", SqlDbType.VarChar,64),
					new SqlParameter("@PickupDate", SqlDbType.DateTime),
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
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64)};
			parameters[0].Value = model.OrderType;
			parameters[1].Value = model.MemberID;
			parameters[2].Value = model.CardNumber;
			parameters[3].Value = model.ReferenceNo;
			parameters[4].Value = model.PickupLocation;
			parameters[5].Value = model.PickupStaff;
			parameters[6].Value = model.PickupDate;
			parameters[7].Value = model.DeliveryFlag;
			parameters[8].Value = model.DeliveryCountry;
			parameters[9].Value = model.DeliveryProvince;
			parameters[10].Value = model.DeliveryCity;
			parameters[11].Value = model.DeliveryDistrict;
			parameters[12].Value = model.DeliveryAddressDetail;
			parameters[13].Value = model.DeliveryFullAddress;
			parameters[14].Value = model.DeliveryNumber;
			parameters[15].Value = model.LogisticsProviderID;
			parameters[16].Value = model.Contact;
			parameters[17].Value = model.ContactPhone;
			parameters[18].Value = model.RequestDeliveryDate;
			parameters[19].Value = model.DeliveryDate;
			parameters[20].Value = model.DeliveryBy;
			parameters[21].Value = model.Remark;
			parameters[22].Value = model.CreatedBusDate;
			parameters[23].Value = model.ApproveBusDate;
			parameters[24].Value = model.ApprovalCode;
			parameters[25].Value = model.ApproveStatus;
			parameters[26].Value = model.ApproveOn;
			parameters[27].Value = model.ApproveBy;
			parameters[28].Value = model.CreatedOn;
			parameters[29].Value = model.CreatedBy;
			parameters[30].Value = model.UpdatedOn;
			parameters[31].Value = model.UpdatedBy;
			parameters[32].Value = model.SalesPickOrderNumber;

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
		public bool Delete(string SalesPickOrderNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_SalesPickOrder_H ");
			strSql.Append(" where SalesPickOrderNumber=@SalesPickOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = SalesPickOrderNumber;

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
		public bool DeleteList(string SalesPickOrderNumberlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ord_SalesPickOrder_H ");
			strSql.Append(" where SalesPickOrderNumber in ("+SalesPickOrderNumberlist + ")  ");
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
		public Edge.SVA.Model.Ord_SalesPickOrder_H GetModel(string SalesPickOrderNumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SalesPickOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,PickupLocation,PickupStaff,PickupDate,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from Ord_SalesPickOrder_H ");
			strSql.Append(" where SalesPickOrderNumber=@SalesPickOrderNumber ");
			SqlParameter[] parameters = {
					new SqlParameter("@SalesPickOrderNumber", SqlDbType.VarChar,64)			};
			parameters[0].Value = SalesPickOrderNumber;

			Edge.SVA.Model.Ord_SalesPickOrder_H model=new Edge.SVA.Model.Ord_SalesPickOrder_H();
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
		public Edge.SVA.Model.Ord_SalesPickOrder_H DataRowToModel(DataRow row)
		{
			Edge.SVA.Model.Ord_SalesPickOrder_H model=new Edge.SVA.Model.Ord_SalesPickOrder_H();
			if (row != null)
			{
				if(row["SalesPickOrderNumber"]!=null)
				{
					model.SalesPickOrderNumber=row["SalesPickOrderNumber"].ToString();
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
				if(row["PickupLocation"]!=null)
				{
					model.PickupLocation=row["PickupLocation"].ToString();
				}
				if(row["PickupStaff"]!=null)
				{
					model.PickupStaff=row["PickupStaff"].ToString();
				}
				if(row["PickupDate"]!=null && row["PickupDate"].ToString()!="")
				{
					model.PickupDate=DateTime.Parse(row["PickupDate"].ToString());
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
				if(row["CreatedBusDate"]!=null && row["CreatedBusDate"].ToString()!="")
				{
					model.CreatedBusDate=DateTime.Parse(row["CreatedBusDate"].ToString());
				}
				if(row["ApproveBusDate"]!=null && row["ApproveBusDate"].ToString()!="")
				{
					model.ApproveBusDate=DateTime.Parse(row["ApproveBusDate"].ToString());
				}
				if(row["ApprovalCode"]!=null)
				{
					model.ApprovalCode=row["ApprovalCode"].ToString();
				}
				if(row["ApproveStatus"]!=null)
				{
					model.ApproveStatus=row["ApproveStatus"].ToString();
				}
				if(row["ApproveOn"]!=null && row["ApproveOn"].ToString()!="")
				{
					model.ApproveOn=DateTime.Parse(row["ApproveOn"].ToString());
				}
				if(row["ApproveBy"]!=null && row["ApproveBy"].ToString()!="")
				{
					model.ApproveBy=int.Parse(row["ApproveBy"].ToString());
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
			strSql.Append("select SalesPickOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,PickupLocation,PickupStaff,PickupDate,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_SalesPickOrder_H ");
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
			strSql.Append(" SalesPickOrderNumber,OrderType,MemberID,CardNumber,ReferenceNo,PickupLocation,PickupStaff,PickupDate,DeliveryFlag,DeliveryCountry,DeliveryProvince,DeliveryCity,DeliveryDistrict,DeliveryAddressDetail,DeliveryFullAddress,DeliveryNumber,LogisticsProviderID,Contact,ContactPhone,RequestDeliveryDate,DeliveryDate,DeliveryBy,Remark,CreatedBusDate,ApproveBusDate,ApprovalCode,ApproveStatus,ApproveOn,ApproveBy,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM Ord_SalesPickOrder_H ");
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
			strSql.Append("select count(1) FROM Ord_SalesPickOrder_H ");
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
				strSql.Append("order by T.SalesPickOrderNumber desc");
			}
			strSql.Append(")AS Row, T.*  from Ord_SalesPickOrder_H T ");
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
			parameters[0].Value = "Ord_SalesPickOrder_H";
			parameters[1].Value = "SalesPickOrderNumber";
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

