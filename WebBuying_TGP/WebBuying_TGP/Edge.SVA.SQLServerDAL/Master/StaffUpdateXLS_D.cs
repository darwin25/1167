using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:StaffUpdateXLS_D
	/// </summary>
	public partial class StaffUpdateXLS_D:IStaffUpdateXLS_D
	{
		public StaffUpdateXLS_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "StaffUpdateXLS_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StaffUpdateXLS_D");
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
		public int Add(Edge.SVA.Model.StaffUpdateXLS_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StaffUpdateXLS_D(");
			strSql.Append("MasterKeyID,Action,BIRTHDAYMONTH,CARDID,CARDSTATUS,COMPANYCODE,DEPTCODE,Entitlement,FAMILYNAME,GIVENNAME,POSITIONID,STAFFID,STORECODE,AMOUNT,REMARK,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@MasterKeyID,@Action,@BIRTHDAYMONTH,@CARDID,@CARDSTATUS,@COMPANYCODE,@DEPTCODE,@Entitlement,@FAMILYNAME,@GIVENNAME,@POSITIONID,@STAFFID,@STORECODE,@AMOUNT,@REMARK,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MasterKeyID", SqlDbType.Int,4),
					new SqlParameter("@Action", SqlDbType.NVarChar,20),
					new SqlParameter("@BIRTHDAYMONTH", SqlDbType.NVarChar,10),
					new SqlParameter("@CARDID", SqlDbType.NVarChar,30),
					new SqlParameter("@CARDSTATUS", SqlDbType.NVarChar,30),
					new SqlParameter("@COMPANYCODE", SqlDbType.NVarChar,100),
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,100),
					new SqlParameter("@Entitlement", SqlDbType.NVarChar,10),
					new SqlParameter("@FAMILYNAME", SqlDbType.NVarChar,50),
					new SqlParameter("@GIVENNAME", SqlDbType.NVarChar,50),
					new SqlParameter("@POSITIONID", SqlDbType.NVarChar,30),
					new SqlParameter("@STAFFID", SqlDbType.NVarChar,30),
					new SqlParameter("@STORECODE", SqlDbType.NVarChar,30),
					new SqlParameter("@AMOUNT", SqlDbType.Money,8),
					new SqlParameter("@REMARK", SqlDbType.NVarChar,400),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.MasterKeyID;
			parameters[1].Value = model.Action;
			parameters[2].Value = model.BIRTHDAYMONTH;
			parameters[3].Value = model.CARDID;
			parameters[4].Value = model.CARDSTATUS;
			parameters[5].Value = model.COMPANYCODE;
			parameters[6].Value = model.DEPTCODE;
			parameters[7].Value = model.Entitlement;
			parameters[8].Value = model.FAMILYNAME;
			parameters[9].Value = model.GIVENNAME;
			parameters[10].Value = model.POSITIONID;
			parameters[11].Value = model.STAFFID;
			parameters[12].Value = model.STORECODE;
			parameters[13].Value = model.AMOUNT;
			parameters[14].Value = model.REMARK;
			parameters[15].Value = model.CreatedDate;
			parameters[16].Value = model.UpdatedDate;
			parameters[17].Value = model.CreatedBy;
			parameters[18].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.StaffUpdateXLS_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StaffUpdateXLS_D set ");
			strSql.Append("MasterKeyID=@MasterKeyID,");
			strSql.Append("Action=@Action,");
			strSql.Append("BIRTHDAYMONTH=@BIRTHDAYMONTH,");
			strSql.Append("CARDID=@CARDID,");
			strSql.Append("CARDSTATUS=@CARDSTATUS,");
			strSql.Append("COMPANYCODE=@COMPANYCODE,");
			strSql.Append("DEPTCODE=@DEPTCODE,");
			strSql.Append("Entitlement=@Entitlement,");
			strSql.Append("FAMILYNAME=@FAMILYNAME,");
			strSql.Append("GIVENNAME=@GIVENNAME,");
			strSql.Append("POSITIONID=@POSITIONID,");
			strSql.Append("STAFFID=@STAFFID,");
			strSql.Append("STORECODE=@STORECODE,");
			strSql.Append("AMOUNT=@AMOUNT,");
			strSql.Append("REMARK=@REMARK,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("UpdatedDate=@UpdatedDate,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@MasterKeyID", SqlDbType.Int,4),
					new SqlParameter("@Action", SqlDbType.NVarChar,20),
					new SqlParameter("@BIRTHDAYMONTH", SqlDbType.NVarChar,10),
					new SqlParameter("@CARDID", SqlDbType.NVarChar,30),
					new SqlParameter("@CARDSTATUS", SqlDbType.NVarChar,30),
					new SqlParameter("@COMPANYCODE", SqlDbType.NVarChar,100),
					new SqlParameter("@DEPTCODE", SqlDbType.NVarChar,100),
					new SqlParameter("@Entitlement", SqlDbType.NVarChar,10),
					new SqlParameter("@FAMILYNAME", SqlDbType.NVarChar,50),
					new SqlParameter("@GIVENNAME", SqlDbType.NVarChar,50),
					new SqlParameter("@POSITIONID", SqlDbType.NVarChar,30),
					new SqlParameter("@STAFFID", SqlDbType.NVarChar,30),
					new SqlParameter("@STORECODE", SqlDbType.NVarChar,30),
					new SqlParameter("@AMOUNT", SqlDbType.Money,8),
					new SqlParameter("@REMARK", SqlDbType.NVarChar,400),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.MasterKeyID;
			parameters[1].Value = model.Action;
			parameters[2].Value = model.BIRTHDAYMONTH;
			parameters[3].Value = model.CARDID;
			parameters[4].Value = model.CARDSTATUS;
			parameters[5].Value = model.COMPANYCODE;
			parameters[6].Value = model.DEPTCODE;
			parameters[7].Value = model.Entitlement;
			parameters[8].Value = model.FAMILYNAME;
			parameters[9].Value = model.GIVENNAME;
			parameters[10].Value = model.POSITIONID;
			parameters[11].Value = model.STAFFID;
			parameters[12].Value = model.STORECODE;
			parameters[13].Value = model.AMOUNT;
			parameters[14].Value = model.REMARK;
			parameters[15].Value = model.CreatedDate;
			parameters[16].Value = model.UpdatedDate;
			parameters[17].Value = model.CreatedBy;
			parameters[18].Value = model.UpdatedBy;
			parameters[19].Value = model.KeyID;

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
			strSql.Append("delete from StaffUpdateXLS_D ");
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
			strSql.Append("delete from StaffUpdateXLS_D ");
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
		public Edge.SVA.Model.StaffUpdateXLS_D GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,MasterKeyID,Action,BIRTHDAYMONTH,CARDID,CARDSTATUS,COMPANYCODE,DEPTCODE,Entitlement,FAMILYNAME,GIVENNAME,POSITIONID,STAFFID,STORECODE,AMOUNT,REMARK,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy from StaffUpdateXLS_D ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.StaffUpdateXLS_D model=new Edge.SVA.Model.StaffUpdateXLS_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MasterKeyID"]!=null && ds.Tables[0].Rows[0]["MasterKeyID"].ToString()!="")
				{
					model.MasterKeyID=int.Parse(ds.Tables[0].Rows[0]["MasterKeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Action"]!=null && ds.Tables[0].Rows[0]["Action"].ToString()!="")
				{
					model.Action=ds.Tables[0].Rows[0]["Action"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BIRTHDAYMONTH"]!=null && ds.Tables[0].Rows[0]["BIRTHDAYMONTH"].ToString()!="")
				{
					model.BIRTHDAYMONTH=ds.Tables[0].Rows[0]["BIRTHDAYMONTH"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CARDID"]!=null && ds.Tables[0].Rows[0]["CARDID"].ToString()!="")
				{
					model.CARDID=ds.Tables[0].Rows[0]["CARDID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CARDSTATUS"]!=null && ds.Tables[0].Rows[0]["CARDSTATUS"].ToString()!="")
				{
					model.CARDSTATUS=ds.Tables[0].Rows[0]["CARDSTATUS"].ToString();
				}
				if(ds.Tables[0].Rows[0]["COMPANYCODE"]!=null && ds.Tables[0].Rows[0]["COMPANYCODE"].ToString()!="")
				{
					model.COMPANYCODE=ds.Tables[0].Rows[0]["COMPANYCODE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DEPTCODE"]!=null && ds.Tables[0].Rows[0]["DEPTCODE"].ToString()!="")
				{
					model.DEPTCODE=ds.Tables[0].Rows[0]["DEPTCODE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Entitlement"]!=null && ds.Tables[0].Rows[0]["Entitlement"].ToString()!="")
				{
					model.Entitlement=ds.Tables[0].Rows[0]["Entitlement"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FAMILYNAME"]!=null && ds.Tables[0].Rows[0]["FAMILYNAME"].ToString()!="")
				{
					model.FAMILYNAME=ds.Tables[0].Rows[0]["FAMILYNAME"].ToString();
				}
				if(ds.Tables[0].Rows[0]["GIVENNAME"]!=null && ds.Tables[0].Rows[0]["GIVENNAME"].ToString()!="")
				{
					model.GIVENNAME=ds.Tables[0].Rows[0]["GIVENNAME"].ToString();
				}
				if(ds.Tables[0].Rows[0]["POSITIONID"]!=null && ds.Tables[0].Rows[0]["POSITIONID"].ToString()!="")
				{
					model.POSITIONID=ds.Tables[0].Rows[0]["POSITIONID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["STAFFID"]!=null && ds.Tables[0].Rows[0]["STAFFID"].ToString()!="")
				{
					model.STAFFID=ds.Tables[0].Rows[0]["STAFFID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["STORECODE"]!=null && ds.Tables[0].Rows[0]["STORECODE"].ToString()!="")
				{
					model.STORECODE=ds.Tables[0].Rows[0]["STORECODE"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AMOUNT"]!=null && ds.Tables[0].Rows[0]["AMOUNT"].ToString()!="")
				{
					model.AMOUNT=decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["REMARK"]!=null && ds.Tables[0].Rows[0]["REMARK"].ToString()!="")
				{
					model.REMARK=ds.Tables[0].Rows[0]["REMARK"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedDate"]!=null && ds.Tables[0].Rows[0]["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedDate"]!=null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=ds.Tables[0].Rows[0]["CreatedBy"].ToString();
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
			strSql.Append("select KeyID,MasterKeyID,Action,BIRTHDAYMONTH,CARDID,CARDSTATUS,COMPANYCODE,DEPTCODE,Entitlement,FAMILYNAME,GIVENNAME,POSITIONID,STAFFID,STORECODE,AMOUNT,REMARK,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy ");
			strSql.Append(" FROM StaffUpdateXLS_D ");
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
			strSql.Append(" KeyID,MasterKeyID,Action,BIRTHDAYMONTH,CARDID,CARDSTATUS,COMPANYCODE,DEPTCODE,Entitlement,FAMILYNAME,GIVENNAME,POSITIONID,STAFFID,STORECODE,AMOUNT,REMARK,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy ");
			strSql.Append(" FROM StaffUpdateXLS_D ");
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
			parameters[0].Value = "StaffUpdateXLS_D";
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
            sql.Append("select count(*) from StaffUpdateXLS_D ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

