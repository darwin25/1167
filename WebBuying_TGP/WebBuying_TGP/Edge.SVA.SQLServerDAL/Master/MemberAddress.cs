using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MemberAddress
	/// </summary>
	public partial class MemberAddress:IMemberAddress
	{
		public MemberAddress()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AddressID", "MemberAddress"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AddressID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberAddress");
			strSql.Append(" where AddressID=@AddressID");
			SqlParameter[] parameters = {
					new SqlParameter("@AddressID", SqlDbType.Int,4)
			};
			parameters[0].Value = AddressID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.MemberAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberAddress(");
			strSql.Append("MemberID,MemberFirstAddr,AddressCountry,AddressProvince,AddressCity,AddressDistrict,AddressDetail,AddressFullDetail,AddressZipCode,Contact,ContactPhone,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@MemberID,@MemberFirstAddr,@AddressCountry,@AddressProvince,@AddressCity,@AddressDistrict,@AddressDetail,@AddressFullDetail,@AddressZipCode,@Contact,@ContactPhone,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MemberFirstAddr", SqlDbType.Int,4),
					new SqlParameter("@AddressCountry", SqlDbType.VarChar,64),
					new SqlParameter("@AddressProvince", SqlDbType.VarChar,64),
					new SqlParameter("@AddressCity", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressFullDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressZipCode", SqlDbType.VarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberID;
			parameters[1].Value = model.MemberFirstAddr;
			parameters[2].Value = model.AddressCountry;
			parameters[3].Value = model.AddressProvince;
			parameters[4].Value = model.AddressCity;
			parameters[5].Value = model.AddressDistrict;
			parameters[6].Value = model.AddressDetail;
			parameters[7].Value = model.AddressFullDetail;
			parameters[8].Value = model.AddressZipCode;
			parameters[9].Value = model.Contact;
			parameters[10].Value = model.ContactPhone;
			parameters[11].Value = model.CreatedOn;
			parameters[12].Value = model.CreatedBy;
			parameters[13].Value = model.UpdatedOn;
			parameters[14].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.MemberAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberAddress set ");
			strSql.Append("MemberID=@MemberID,");
			strSql.Append("MemberFirstAddr=@MemberFirstAddr,");
			strSql.Append("AddressCountry=@AddressCountry,");
			strSql.Append("AddressProvince=@AddressProvince,");
			strSql.Append("AddressCity=@AddressCity,");
			strSql.Append("AddressDistrict=@AddressDistrict,");
			strSql.Append("AddressDetail=@AddressDetail,");
			strSql.Append("AddressFullDetail=@AddressFullDetail,");
			strSql.Append("AddressZipCode=@AddressZipCode,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("ContactPhone=@ContactPhone,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where AddressID=@AddressID");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@MemberFirstAddr", SqlDbType.Int,4),
					new SqlParameter("@AddressCountry", SqlDbType.VarChar,64),
					new SqlParameter("@AddressProvince", SqlDbType.VarChar,64),
					new SqlParameter("@AddressCity", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDistrict", SqlDbType.VarChar,64),
					new SqlParameter("@AddressDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressFullDetail", SqlDbType.NVarChar,512),
					new SqlParameter("@AddressZipCode", SqlDbType.VarChar,512),
					new SqlParameter("@Contact", SqlDbType.NVarChar,512),
					new SqlParameter("@ContactPhone", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@AddressID", SqlDbType.Int,4)};
			parameters[0].Value = model.MemberID;
			parameters[1].Value = model.MemberFirstAddr;
			parameters[2].Value = model.AddressCountry;
			parameters[3].Value = model.AddressProvince;
			parameters[4].Value = model.AddressCity;
			parameters[5].Value = model.AddressDistrict;
			parameters[6].Value = model.AddressDetail;
			parameters[7].Value = model.AddressFullDetail;
			parameters[8].Value = model.AddressZipCode;
			parameters[9].Value = model.Contact;
			parameters[10].Value = model.ContactPhone;
			parameters[11].Value = model.CreatedOn;
			parameters[12].Value = model.CreatedBy;
			parameters[13].Value = model.UpdatedOn;
			parameters[14].Value = model.UpdatedBy;
			parameters[15].Value = model.AddressID;

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
		public bool Delete(int AddressID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberAddress ");
			strSql.Append(" where AddressID=@AddressID");
			SqlParameter[] parameters = {
					new SqlParameter("@AddressID", SqlDbType.Int,4)
			};
			parameters[0].Value = AddressID;

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
		public bool DeleteList(string AddressIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MemberAddress ");
			strSql.Append(" where AddressID in ("+AddressIDlist + ")  ");
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
		public Edge.SVA.Model.MemberAddress GetModel(int AddressID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AddressID,MemberID,MemberFirstAddr,AddressCountry,AddressProvince,AddressCity,AddressDistrict,AddressDetail,AddressFullDetail,AddressZipCode,Contact,ContactPhone,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from MemberAddress ");
			strSql.Append(" where AddressID=@AddressID");
			SqlParameter[] parameters = {
					new SqlParameter("@AddressID", SqlDbType.Int,4)
			};
			parameters[0].Value = AddressID;

			Edge.SVA.Model.MemberAddress model=new Edge.SVA.Model.MemberAddress();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["AddressID"]!=null && ds.Tables[0].Rows[0]["AddressID"].ToString()!="")
				{
					model.AddressID=int.Parse(ds.Tables[0].Rows[0]["AddressID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberID"]!=null && ds.Tables[0].Rows[0]["MemberID"].ToString()!="")
				{
					model.MemberID=int.Parse(ds.Tables[0].Rows[0]["MemberID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberFirstAddr"]!=null && ds.Tables[0].Rows[0]["MemberFirstAddr"].ToString()!="")
				{
					model.MemberFirstAddr=int.Parse(ds.Tables[0].Rows[0]["MemberFirstAddr"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddressCountry"]!=null && ds.Tables[0].Rows[0]["AddressCountry"].ToString()!="")
				{
					model.AddressCountry=ds.Tables[0].Rows[0]["AddressCountry"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddressProvince"]!=null && ds.Tables[0].Rows[0]["AddressProvince"].ToString()!="")
				{
					model.AddressProvince=ds.Tables[0].Rows[0]["AddressProvince"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddressCity"]!=null && ds.Tables[0].Rows[0]["AddressCity"].ToString()!="")
				{
					model.AddressCity=ds.Tables[0].Rows[0]["AddressCity"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddressDistrict"]!=null && ds.Tables[0].Rows[0]["AddressDistrict"].ToString()!="")
				{
					model.AddressDistrict=ds.Tables[0].Rows[0]["AddressDistrict"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddressDetail"]!=null && ds.Tables[0].Rows[0]["AddressDetail"].ToString()!="")
				{
					model.AddressDetail=ds.Tables[0].Rows[0]["AddressDetail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddressFullDetail"]!=null && ds.Tables[0].Rows[0]["AddressFullDetail"].ToString()!="")
				{
					model.AddressFullDetail=ds.Tables[0].Rows[0]["AddressFullDetail"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddressZipCode"]!=null && ds.Tables[0].Rows[0]["AddressZipCode"].ToString()!="")
				{
					model.AddressZipCode=ds.Tables[0].Rows[0]["AddressZipCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Contact"]!=null && ds.Tables[0].Rows[0]["Contact"].ToString()!="")
				{
					model.Contact=ds.Tables[0].Rows[0]["Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContactPhone"]!=null && ds.Tables[0].Rows[0]["ContactPhone"].ToString()!="")
				{
					model.ContactPhone=ds.Tables[0].Rows[0]["ContactPhone"].ToString();
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
			strSql.Append("select AddressID,MemberID,MemberFirstAddr,AddressCountry,AddressProvince,AddressCity,AddressDistrict,AddressDetail,AddressFullDetail,AddressZipCode,Contact,ContactPhone,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM MemberAddress ");
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
			strSql.Append(" AddressID,MemberID,MemberFirstAddr,AddressCountry,AddressProvince,AddressCity,AddressDistrict,AddressDetail,AddressFullDetail,AddressZipCode,Contact,ContactPhone,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM MemberAddress ");
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
			strSql.Append("select count(1) FROM MemberAddress ");
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
				strSql.Append("order by T.AddressID desc");
			}
			strSql.Append(")AS Row, T.*  from MemberAddress T ");
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
			parameters[0].Value = "MemberAddress";
			parameters[1].Value = "AddressID";
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

