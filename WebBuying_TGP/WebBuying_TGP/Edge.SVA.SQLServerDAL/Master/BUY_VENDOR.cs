using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_VENDOR
	/// </summary>
	public partial class BUY_VENDOR:IBUY_VENDOR
	{
		public BUY_VENDOR()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("VendorID", "BUY_VENDOR"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string VendorCode,int VendorID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_VENDOR");
			strSql.Append(" where VendorCode=@VendorCode and VendorID=@VendorID ");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@VendorID", SqlDbType.Int,4)			};
			parameters[0].Value = VendorCode;
			parameters[1].Value = VendorID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_VENDOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_VENDOR(");
			strSql.Append("VendorCode,VendorName1,VendorName2,VendorName3,VendorAddress1,VendorAddress2,VendorAddress3,VendorNote,PreferFlag,Contact,ContactPosition,ContactTel,ContactFax,ContactMobile,ContactEmail,Terms,Limit,Shipment,PayTerm,AccountCode,Oversea,InTax,NonOrder,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@VendorCode,@VendorName1,@VendorName2,@VendorName3,@VendorAddress1,@VendorAddress2,@VendorAddress3,@VendorNote,@PreferFlag,@Contact,@ContactPosition,@ContactTel,@ContactFax,@ContactMobile,@ContactEmail,@Terms,@Limit,@Shipment,@PayTerm,@AccountCode,@Oversea,@InTax,@NonOrder,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@VendorName1", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorName2", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorName3", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorAddress1", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorAddress2", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorAddress3", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorNote", SqlDbType.NVarChar,512),
					new SqlParameter("@PreferFlag", SqlDbType.Int,4),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPosition", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactTel", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactFax", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactMobile", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@Terms", SqlDbType.Int,4),
					new SqlParameter("@Limit", SqlDbType.Decimal,9),
					new SqlParameter("@Shipment", SqlDbType.NVarChar,512),
					new SqlParameter("@PayTerm", SqlDbType.NVarChar,512),
					new SqlParameter("@AccountCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Oversea", SqlDbType.Int,4),
					new SqlParameter("@InTax", SqlDbType.Decimal,9),
					new SqlParameter("@NonOrder", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.VendorCode;
			parameters[1].Value = model.VendorName1;
			parameters[2].Value = model.VendorName2;
			parameters[3].Value = model.VendorName3;
			parameters[4].Value = model.VendorAddress1;
			parameters[5].Value = model.VendorAddress2;
			parameters[6].Value = model.VendorAddress3;
			parameters[7].Value = model.VendorNote;
			parameters[8].Value = model.PreferFlag;
			parameters[9].Value = model.Contact;
			parameters[10].Value = model.ContactPosition;
			parameters[11].Value = model.ContactTel;
			parameters[12].Value = model.ContactFax;
			parameters[13].Value = model.ContactMobile;
			parameters[14].Value = model.ContactEmail;
			parameters[15].Value = model.Terms;
			parameters[16].Value = model.Limit;
			parameters[17].Value = model.Shipment;
			parameters[18].Value = model.PayTerm;
			parameters[19].Value = model.AccountCode;
			parameters[20].Value = model.Oversea;
			parameters[21].Value = model.InTax;
			parameters[22].Value = model.NonOrder;
			parameters[23].Value = model.CreatedOn;
			parameters[24].Value = model.CreatedBy;
			parameters[25].Value = model.UpdatedOn;
			parameters[26].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_VENDOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_VENDOR set ");
			strSql.Append("VendorName1=@VendorName1,");
			strSql.Append("VendorName2=@VendorName2,");
			strSql.Append("VendorName3=@VendorName3,");
			strSql.Append("VendorAddress1=@VendorAddress1,");
			strSql.Append("VendorAddress2=@VendorAddress2,");
			strSql.Append("VendorAddress3=@VendorAddress3,");
			strSql.Append("VendorNote=@VendorNote,");
			strSql.Append("PreferFlag=@PreferFlag,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("ContactPosition=@ContactPosition,");
			strSql.Append("ContactTel=@ContactTel,");
			strSql.Append("ContactFax=@ContactFax,");
			strSql.Append("ContactMobile=@ContactMobile,");
			strSql.Append("ContactEmail=@ContactEmail,");
			strSql.Append("Terms=@Terms,");
			strSql.Append("Limit=@Limit,");
			strSql.Append("Shipment=@Shipment,");
			strSql.Append("PayTerm=@PayTerm,");
			strSql.Append("AccountCode=@AccountCode,");
			strSql.Append("Oversea=@Oversea,");
			strSql.Append("InTax=@InTax,");
			strSql.Append("NonOrder=@NonOrder,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where VendorID=@VendorID");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorName1", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorName2", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorName3", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorAddress1", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorAddress2", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorAddress3", SqlDbType.NVarChar,512),
					new SqlParameter("@VendorNote", SqlDbType.NVarChar,512),
					new SqlParameter("@PreferFlag", SqlDbType.Int,4),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPosition", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactTel", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactFax", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactMobile", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactEmail", SqlDbType.NVarChar,512),
					new SqlParameter("@Terms", SqlDbType.Int,4),
					new SqlParameter("@Limit", SqlDbType.Decimal,9),
					new SqlParameter("@Shipment", SqlDbType.NVarChar,512),
					new SqlParameter("@PayTerm", SqlDbType.NVarChar,512),
					new SqlParameter("@AccountCode", SqlDbType.NVarChar,512),
					new SqlParameter("@Oversea", SqlDbType.Int,4),
					new SqlParameter("@InTax", SqlDbType.Decimal,9),
					new SqlParameter("@NonOrder", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@VendorID", SqlDbType.Int,4),
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.VendorName1;
			parameters[1].Value = model.VendorName2;
			parameters[2].Value = model.VendorName3;
			parameters[3].Value = model.VendorAddress1;
			parameters[4].Value = model.VendorAddress2;
			parameters[5].Value = model.VendorAddress3;
			parameters[6].Value = model.VendorNote;
			parameters[7].Value = model.PreferFlag;
			parameters[8].Value = model.Contact;
			parameters[9].Value = model.ContactPosition;
			parameters[10].Value = model.ContactTel;
			parameters[11].Value = model.ContactFax;
			parameters[12].Value = model.ContactMobile;
			parameters[13].Value = model.ContactEmail;
			parameters[14].Value = model.Terms;
			parameters[15].Value = model.Limit;
			parameters[16].Value = model.Shipment;
			parameters[17].Value = model.PayTerm;
			parameters[18].Value = model.AccountCode;
			parameters[19].Value = model.Oversea;
			parameters[20].Value = model.InTax;
			parameters[21].Value = model.NonOrder;
			parameters[22].Value = model.CreatedOn;
			parameters[23].Value = model.CreatedBy;
			parameters[24].Value = model.UpdatedOn;
			parameters[25].Value = model.UpdatedBy;
			parameters[26].Value = model.VendorID;
			parameters[27].Value = model.VendorCode;

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
		public bool Delete(int VendorID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_VENDOR ");
			strSql.Append(" where VendorID=@VendorID");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorID", SqlDbType.Int,4)
			};
			parameters[0].Value = VendorID;

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
		public bool Delete(string VendorCode,int VendorID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_VENDOR ");
			strSql.Append(" where VendorCode=@VendorCode and VendorID=@VendorID ");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.VarChar,64),
					new SqlParameter("@VendorID", SqlDbType.Int,4)			};
			parameters[0].Value = VendorCode;
			parameters[1].Value = VendorID;

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
		public bool DeleteList(string VendorIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_VENDOR ");
			strSql.Append(" where VendorID in ("+VendorIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_VENDOR GetModel(int VendorID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VendorID,VendorCode,VendorName1,VendorName2,VendorName3,VendorAddress1,VendorAddress2,VendorAddress3,VendorNote,PreferFlag,Contact,ContactPosition,ContactTel,ContactFax,ContactMobile,ContactEmail,Terms,Limit,Shipment,PayTerm,AccountCode,Oversea,InTax,NonOrder,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_VENDOR ");
			strSql.Append(" where VendorID=@VendorID");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorID", SqlDbType.Int,4)
			};
			parameters[0].Value = VendorID;

			Edge.SVA.Model.BUY_VENDOR model=new Edge.SVA.Model.BUY_VENDOR();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["VendorID"]!=null && ds.Tables[0].Rows[0]["VendorID"].ToString()!="")
				{
					model.VendorID=int.Parse(ds.Tables[0].Rows[0]["VendorID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["VendorCode"]!=null && ds.Tables[0].Rows[0]["VendorCode"].ToString()!="")
				{
					model.VendorCode=ds.Tables[0].Rows[0]["VendorCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorName1"]!=null && ds.Tables[0].Rows[0]["VendorName1"].ToString()!="")
				{
					model.VendorName1=ds.Tables[0].Rows[0]["VendorName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorName2"]!=null && ds.Tables[0].Rows[0]["VendorName2"].ToString()!="")
				{
					model.VendorName2=ds.Tables[0].Rows[0]["VendorName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorName3"]!=null && ds.Tables[0].Rows[0]["VendorName3"].ToString()!="")
				{
					model.VendorName3=ds.Tables[0].Rows[0]["VendorName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorAddress1"]!=null && ds.Tables[0].Rows[0]["VendorAddress1"].ToString()!="")
				{
					model.VendorAddress1=ds.Tables[0].Rows[0]["VendorAddress1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorAddress2"]!=null && ds.Tables[0].Rows[0]["VendorAddress2"].ToString()!="")
				{
					model.VendorAddress2=ds.Tables[0].Rows[0]["VendorAddress2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorAddress3"]!=null && ds.Tables[0].Rows[0]["VendorAddress3"].ToString()!="")
				{
					model.VendorAddress3=ds.Tables[0].Rows[0]["VendorAddress3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["VendorNote"]!=null && ds.Tables[0].Rows[0]["VendorNote"].ToString()!="")
				{
					model.VendorNote=ds.Tables[0].Rows[0]["VendorNote"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PreferFlag"]!=null && ds.Tables[0].Rows[0]["PreferFlag"].ToString()!="")
				{
					model.PreferFlag=int.Parse(ds.Tables[0].Rows[0]["PreferFlag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Contact"]!=null && ds.Tables[0].Rows[0]["Contact"].ToString()!="")
				{
					model.Contact=ds.Tables[0].Rows[0]["Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactPosition"]!=null && ds.Tables[0].Rows[0]["ContactPosition"].ToString()!="")
				{
					model.ContactPosition=ds.Tables[0].Rows[0]["ContactPosition"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactTel"]!=null && ds.Tables[0].Rows[0]["ContactTel"].ToString()!="")
				{
					model.ContactTel=ds.Tables[0].Rows[0]["ContactTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactFax"]!=null && ds.Tables[0].Rows[0]["ContactFax"].ToString()!="")
				{
					model.ContactFax=ds.Tables[0].Rows[0]["ContactFax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactMobile"]!=null && ds.Tables[0].Rows[0]["ContactMobile"].ToString()!="")
				{
					model.ContactMobile=ds.Tables[0].Rows[0]["ContactMobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactEmail"]!=null && ds.Tables[0].Rows[0]["ContactEmail"].ToString()!="")
				{
					model.ContactEmail=ds.Tables[0].Rows[0]["ContactEmail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Terms"]!=null && ds.Tables[0].Rows[0]["Terms"].ToString()!="")
				{
					model.Terms=int.Parse(ds.Tables[0].Rows[0]["Terms"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Limit"]!=null && ds.Tables[0].Rows[0]["Limit"].ToString()!="")
				{
					model.Limit=decimal.Parse(ds.Tables[0].Rows[0]["Limit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Shipment"]!=null && ds.Tables[0].Rows[0]["Shipment"].ToString()!="")
				{
					model.Shipment=ds.Tables[0].Rows[0]["Shipment"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PayTerm"]!=null && ds.Tables[0].Rows[0]["PayTerm"].ToString()!="")
				{
					model.PayTerm=ds.Tables[0].Rows[0]["PayTerm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AccountCode"]!=null && ds.Tables[0].Rows[0]["AccountCode"].ToString()!="")
				{
					model.AccountCode=ds.Tables[0].Rows[0]["AccountCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Oversea"]!=null && ds.Tables[0].Rows[0]["Oversea"].ToString()!="")
				{
					model.Oversea=int.Parse(ds.Tables[0].Rows[0]["Oversea"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InTax"]!=null && ds.Tables[0].Rows[0]["InTax"].ToString()!="")
				{
					model.InTax=decimal.Parse(ds.Tables[0].Rows[0]["InTax"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NonOrder"]!=null && ds.Tables[0].Rows[0]["NonOrder"].ToString()!="")
				{
					model.NonOrder=int.Parse(ds.Tables[0].Rows[0]["NonOrder"].ToString());
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
			strSql.Append("select VendorID,VendorCode,VendorName1,VendorName2,VendorName3,VendorAddress1,VendorAddress2,VendorAddress3,VendorNote,PreferFlag,Contact,ContactPosition,ContactTel,ContactFax,ContactMobile,ContactEmail,Terms,Limit,Shipment,PayTerm,AccountCode,Oversea,InTax,NonOrder,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_VENDOR ");
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
			strSql.Append(" VendorID,VendorCode,VendorName1,VendorName2,VendorName3,VendorAddress1,VendorAddress2,VendorAddress3,VendorNote,PreferFlag,Contact,ContactPosition,ContactTel,ContactFax,ContactMobile,ContactEmail,Terms,Limit,Shipment,PayTerm,AccountCode,Oversea,InTax,NonOrder,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_VENDOR ");
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
			strSql.Append("select count(1) FROM BUY_VENDOR ");
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
				strSql.Append("order by T.VendorID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_VENDOR T ");
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
			parameters[0].Value = "BUY_VENDOR";
			parameters[1].Value = "VendorID";
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

