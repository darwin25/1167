using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:VENDOR
	/// </summary>
	public partial class VENDOR:IVENDOR
	{
		public VENDOR()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.VENDOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VENDOR(");
			strSql.Append("VendorCode,Area,Name,L_name,Address1,Address2,Address3,Contact,Position,Tel,Fax,Telex,Cable,Terms,Limit,Shipment,Payterm,Account_code,Oversea,In_tax,CreatedOn,Nonorder,Prepareby,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@VendorCode,@Area,@Name,@L_name,@Address1,@Address2,@Address3,@Contact,@Position,@Tel,@Fax,@Telex,@Cable,@Terms,@Limit,@Shipment,@Payterm,@Account_code,@Oversea,@In_tax,@CreatedOn,@Nonorder,@Prepareby,@UpdatedOn,@UpdatedBy)");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.Char,12),
					new SqlParameter("@Area", SqlDbType.Char,6),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@L_name", SqlDbType.VarChar,50),
					new SqlParameter("@Address1", SqlDbType.VarChar,50),
					new SqlParameter("@Address2", SqlDbType.VarChar,50),
					new SqlParameter("@Address3", SqlDbType.VarChar,50),
					new SqlParameter("@Contact", SqlDbType.VarChar,28),
					new SqlParameter("@Position", SqlDbType.VarChar,28),
					new SqlParameter("@Tel", SqlDbType.VarChar,28),
					new SqlParameter("@Fax", SqlDbType.VarChar,28),
					new SqlParameter("@Telex", SqlDbType.VarChar,28),
					new SqlParameter("@Cable", SqlDbType.VarChar,28),
					new SqlParameter("@Terms", SqlDbType.Int,4),
					new SqlParameter("@Limit", SqlDbType.Float,8),
					new SqlParameter("@Shipment", SqlDbType.VarChar,20),
					new SqlParameter("@Payterm", SqlDbType.VarChar,20),
					new SqlParameter("@Account_code", SqlDbType.VarChar,10),
					new SqlParameter("@Oversea", SqlDbType.Char,1),
					new SqlParameter("@In_tax", SqlDbType.Float,8),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@Nonorder", SqlDbType.Char,1),
					new SqlParameter("@Prepareby", SqlDbType.Char,8),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,30)};
			parameters[0].Value = model.VendorCode;
			parameters[1].Value = model.Area;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.L_name;
			parameters[4].Value = model.Address1;
			parameters[5].Value = model.Address2;
			parameters[6].Value = model.Address3;
			parameters[7].Value = model.Contact;
			parameters[8].Value = model.Position;
			parameters[9].Value = model.Tel;
			parameters[10].Value = model.Fax;
			parameters[11].Value = model.Telex;
			parameters[12].Value = model.Cable;
			parameters[13].Value = model.Terms;
			parameters[14].Value = model.Limit;
			parameters[15].Value = model.Shipment;
			parameters[16].Value = model.Payterm;
			parameters[17].Value = model.Account_code;
			parameters[18].Value = model.Oversea;
			parameters[19].Value = model.In_tax;
			parameters[20].Value = model.CreatedOn;
			parameters[21].Value = model.Nonorder;
			parameters[22].Value = model.Prepareby;
			parameters[23].Value = model.UpdatedOn;
			parameters[24].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.VENDOR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VENDOR set ");
			strSql.Append("VendorCode=@VendorCode,");
			strSql.Append("Area=@Area,");
			strSql.Append("Name=@Name,");
			strSql.Append("L_name=@L_name,");
			strSql.Append("Address1=@Address1,");
			strSql.Append("Address2=@Address2,");
			strSql.Append("Address3=@Address3,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("Position=@Position,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("Telex=@Telex,");
			strSql.Append("Cable=@Cable,");
			strSql.Append("Terms=@Terms,");
			strSql.Append("Limit=@Limit,");
			strSql.Append("Shipment=@Shipment,");
			strSql.Append("Payterm=@Payterm,");
			strSql.Append("Account_code=@Account_code,");
			strSql.Append("Oversea=@Oversea,");
			strSql.Append("In_tax=@In_tax,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("Nonorder=@Nonorder,");
			strSql.Append("Prepareby=@Prepareby,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@VendorCode", SqlDbType.Char,12),
					new SqlParameter("@Area", SqlDbType.Char,6),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@L_name", SqlDbType.VarChar,50),
					new SqlParameter("@Address1", SqlDbType.VarChar,50),
					new SqlParameter("@Address2", SqlDbType.VarChar,50),
					new SqlParameter("@Address3", SqlDbType.VarChar,50),
					new SqlParameter("@Contact", SqlDbType.VarChar,28),
					new SqlParameter("@Position", SqlDbType.VarChar,28),
					new SqlParameter("@Tel", SqlDbType.VarChar,28),
					new SqlParameter("@Fax", SqlDbType.VarChar,28),
					new SqlParameter("@Telex", SqlDbType.VarChar,28),
					new SqlParameter("@Cable", SqlDbType.VarChar,28),
					new SqlParameter("@Terms", SqlDbType.Int,4),
					new SqlParameter("@Limit", SqlDbType.Float,8),
					new SqlParameter("@Shipment", SqlDbType.VarChar,20),
					new SqlParameter("@Payterm", SqlDbType.VarChar,20),
					new SqlParameter("@Account_code", SqlDbType.VarChar,10),
					new SqlParameter("@Oversea", SqlDbType.Char,1),
					new SqlParameter("@In_tax", SqlDbType.Float,8),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@Nonorder", SqlDbType.Char,1),
					new SqlParameter("@Prepareby", SqlDbType.Char,8),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,30)};
			parameters[0].Value = model.VendorCode;
			parameters[1].Value = model.Area;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.L_name;
			parameters[4].Value = model.Address1;
			parameters[5].Value = model.Address2;
			parameters[6].Value = model.Address3;
			parameters[7].Value = model.Contact;
			parameters[8].Value = model.Position;
			parameters[9].Value = model.Tel;
			parameters[10].Value = model.Fax;
			parameters[11].Value = model.Telex;
			parameters[12].Value = model.Cable;
			parameters[13].Value = model.Terms;
			parameters[14].Value = model.Limit;
			parameters[15].Value = model.Shipment;
			parameters[16].Value = model.Payterm;
			parameters[17].Value = model.Account_code;
			parameters[18].Value = model.Oversea;
			parameters[19].Value = model.In_tax;
			parameters[20].Value = model.CreatedOn;
			parameters[21].Value = model.Nonorder;
			parameters[22].Value = model.Prepareby;
			parameters[23].Value = model.UpdatedOn;
			parameters[24].Value = model.UpdatedBy;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VENDOR ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.VENDOR GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 VendorCode,Area,Name,L_name,Address1,Address2,Address3,Contact,Position,Tel,Fax,Telex,Cable,Terms,Limit,Shipment,Payterm,Account_code,Oversea,In_tax,CreatedOn,Nonorder,Prepareby,UpdatedOn,UpdatedBy from VENDOR ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
};

			Edge.SVA.Model.VENDOR model=new Edge.SVA.Model.VENDOR();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["VendorCode"]!=null && ds.Tables[0].Rows[0]["VendorCode"].ToString()!="")
				{
					model.VendorCode=ds.Tables[0].Rows[0]["VendorCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Area"]!=null && ds.Tables[0].Rows[0]["Area"].ToString()!="")
				{
					model.Area=ds.Tables[0].Rows[0]["Area"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["L_name"]!=null && ds.Tables[0].Rows[0]["L_name"].ToString()!="")
				{
					model.L_name=ds.Tables[0].Rows[0]["L_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address1"]!=null && ds.Tables[0].Rows[0]["Address1"].ToString()!="")
				{
					model.Address1=ds.Tables[0].Rows[0]["Address1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address2"]!=null && ds.Tables[0].Rows[0]["Address2"].ToString()!="")
				{
					model.Address2=ds.Tables[0].Rows[0]["Address2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address3"]!=null && ds.Tables[0].Rows[0]["Address3"].ToString()!="")
				{
					model.Address3=ds.Tables[0].Rows[0]["Address3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Contact"]!=null && ds.Tables[0].Rows[0]["Contact"].ToString()!="")
				{
					model.Contact=ds.Tables[0].Rows[0]["Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Position"]!=null && ds.Tables[0].Rows[0]["Position"].ToString()!="")
				{
					model.Position=ds.Tables[0].Rows[0]["Position"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Tel"]!=null && ds.Tables[0].Rows[0]["Tel"].ToString()!="")
				{
					model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Fax"]!=null && ds.Tables[0].Rows[0]["Fax"].ToString()!="")
				{
					model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Telex"]!=null && ds.Tables[0].Rows[0]["Telex"].ToString()!="")
				{
					model.Telex=ds.Tables[0].Rows[0]["Telex"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Cable"]!=null && ds.Tables[0].Rows[0]["Cable"].ToString()!="")
				{
					model.Cable=ds.Tables[0].Rows[0]["Cable"].ToString();
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
				if(ds.Tables[0].Rows[0]["Payterm"]!=null && ds.Tables[0].Rows[0]["Payterm"].ToString()!="")
				{
					model.Payterm=ds.Tables[0].Rows[0]["Payterm"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Account_code"]!=null && ds.Tables[0].Rows[0]["Account_code"].ToString()!="")
				{
					model.Account_code=ds.Tables[0].Rows[0]["Account_code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Oversea"]!=null && ds.Tables[0].Rows[0]["Oversea"].ToString()!="")
				{
					model.Oversea=ds.Tables[0].Rows[0]["Oversea"].ToString();
				}
				if(ds.Tables[0].Rows[0]["In_tax"]!=null && ds.Tables[0].Rows[0]["In_tax"].ToString()!="")
				{
					model.In_tax=decimal.Parse(ds.Tables[0].Rows[0]["In_tax"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedOn"]!=null && ds.Tables[0].Rows[0]["CreatedOn"].ToString()!="")
				{
					model.CreatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Nonorder"]!=null && ds.Tables[0].Rows[0]["Nonorder"].ToString()!="")
				{
					model.Nonorder=ds.Tables[0].Rows[0]["Nonorder"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Prepareby"]!=null && ds.Tables[0].Rows[0]["Prepareby"].ToString()!="")
				{
					model.Prepareby=ds.Tables[0].Rows[0]["Prepareby"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdatedOn"]!=null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString()!="")
				{
					model.UpdatedOn=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
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
			strSql.Append("select VendorCode,Area,Name,L_name,Address1,Address2,Address3,Contact,Position,Tel,Fax,Telex,Cable,Terms,Limit,Shipment,Payterm,Account_code,Oversea,In_tax,CreatedOn,Nonorder,Prepareby,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM VENDOR ");
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
			strSql.Append(" VendorCode,Area,Name,L_name,Address1,Address2,Address3,Contact,Position,Tel,Fax,Telex,Cable,Terms,Limit,Shipment,Payterm,Account_code,Oversea,In_tax,CreatedOn,Nonorder,Prepareby,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM VENDOR ");
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
			parameters[0].Value = "VENDOR";
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
            sql.Append("select count(*) from VENDOR ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

