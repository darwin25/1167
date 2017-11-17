using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:POSSTAFF
	/// </summary>
	public partial class POSSTAFF:IPOSSTAFF
	{
		public POSSTAFF()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StaffID", "POSSTAFF"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StaffCode,int StaffID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from POSSTAFF");
			strSql.Append(" where StaffCode=@StaffCode and StaffID=@StaffID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffCode", SqlDbType.VarChar,64),
					new SqlParameter("@StaffID", SqlDbType.Int,4)			};
			parameters[0].Value = StaffCode;
			parameters[1].Value = StaffID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StaffCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from POSSTAFF");
            strSql.Append(" where StaffCode=@StaffCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffCode", SqlDbType.VarChar,64)	};
            parameters[0].Value = StaffCode;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StaffID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from POSSTAFF");
            strSql.Append(" where StaffID=@StaffID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)			};
            parameters[0].Value = StaffID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.POSSTAFF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into POSSTAFF(");
			strSql.Append("StaffCode,StaffName,StaffPWD,StaffLevel,Status,LanguageID,Def_Reset_PWD_DAYS,Grace_Login_Count,PWD_Valid_Days,Last_Reset_PWD,LastLoginTime,LastLoginStore,LastLoginRegister,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@StaffCode,@StaffName,@StaffPWD,@StaffLevel,@Status,@LanguageID,@Def_Reset_PWD_DAYS,@Grace_Login_Count,@PWD_Valid_Days,@Last_Reset_PWD,@LastLoginTime,@LastLoginStore,@LastLoginRegister,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffCode", SqlDbType.VarChar,64),
					new SqlParameter("@StaffName", SqlDbType.NVarChar,64),
					new SqlParameter("@StaffPWD", SqlDbType.NVarChar,64),
					new SqlParameter("@StaffLevel", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@LanguageID", SqlDbType.Int,4),
					new SqlParameter("@Def_Reset_PWD_DAYS", SqlDbType.Int,4),
					new SqlParameter("@Grace_Login_Count", SqlDbType.Int,4),
					new SqlParameter("@PWD_Valid_Days", SqlDbType.Int,4),
					new SqlParameter("@Last_Reset_PWD", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginStore", SqlDbType.NVarChar,64),
					new SqlParameter("@LastLoginRegister", SqlDbType.NVarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.StaffCode;
			parameters[1].Value = model.StaffName;
			parameters[2].Value = model.StaffPWD;
			parameters[3].Value = model.StaffLevel;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.LanguageID;
			parameters[6].Value = model.Def_Reset_PWD_DAYS;
			parameters[7].Value = model.Grace_Login_Count;
			parameters[8].Value = model.PWD_Valid_Days;
			parameters[9].Value = model.Last_Reset_PWD;
			parameters[10].Value = model.LastLoginTime;
			parameters[11].Value = model.LastLoginStore;
			parameters[12].Value = model.LastLoginRegister;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.POSSTAFF model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update POSSTAFF set ");
			strSql.Append("StaffCode=@StaffCode,");
			strSql.Append("StaffName=@StaffName,");
			strSql.Append("StaffPWD=@StaffPWD,");
			strSql.Append("StaffLevel=@StaffLevel,");
			strSql.Append("Status=@Status,");
			strSql.Append("LanguageID=@LanguageID,");
			strSql.Append("Def_Reset_PWD_DAYS=@Def_Reset_PWD_DAYS,");
			strSql.Append("Grace_Login_Count=@Grace_Login_Count,");
			strSql.Append("PWD_Valid_Days=@PWD_Valid_Days,");
			strSql.Append("Last_Reset_PWD=@Last_Reset_PWD,");
			strSql.Append("LastLoginTime=@LastLoginTime,");
			strSql.Append("LastLoginStore=@LastLoginStore,");
			strSql.Append("LastLoginRegister=@LastLoginRegister,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where StaffID=@StaffID");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffCode", SqlDbType.VarChar,64),
					new SqlParameter("@StaffName", SqlDbType.NVarChar,64),
					new SqlParameter("@StaffPWD", SqlDbType.NVarChar,64),
					new SqlParameter("@StaffLevel", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@LanguageID", SqlDbType.Int,4),
					new SqlParameter("@Def_Reset_PWD_DAYS", SqlDbType.Int,4),
					new SqlParameter("@Grace_Login_Count", SqlDbType.Int,4),
					new SqlParameter("@PWD_Valid_Days", SqlDbType.Int,4),
					new SqlParameter("@Last_Reset_PWD", SqlDbType.DateTime),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginStore", SqlDbType.NVarChar,64),
					new SqlParameter("@LastLoginRegister", SqlDbType.NVarChar,64),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@StaffID", SqlDbType.Int,4)};
			parameters[0].Value = model.StaffCode;
			parameters[1].Value = model.StaffName;
			parameters[2].Value = model.StaffPWD;
			parameters[3].Value = model.StaffLevel;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.LanguageID;
			parameters[6].Value = model.Def_Reset_PWD_DAYS;
			parameters[7].Value = model.Grace_Login_Count;
			parameters[8].Value = model.PWD_Valid_Days;
			parameters[9].Value = model.Last_Reset_PWD;
			parameters[10].Value = model.LastLoginTime;
			parameters[11].Value = model.LastLoginStore;
			parameters[12].Value = model.LastLoginRegister;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;
			parameters[17].Value = model.StaffID;

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
		public bool Delete(int StaffID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from POSSTAFF ");
			strSql.Append(" where StaffID=@StaffID");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)
			};
			parameters[0].Value = StaffID;

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
		public bool Delete(string StaffCode,int StaffID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from POSSTAFF ");
			strSql.Append(" where StaffCode=@StaffCode and StaffID=@StaffID ");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffCode", SqlDbType.VarChar,64),
					new SqlParameter("@StaffID", SqlDbType.Int,4)			};
			parameters[0].Value = StaffCode;
			parameters[1].Value = StaffID;

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
		public bool DeleteList(string StaffIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from POSSTAFF ");
			strSql.Append(" where StaffID in ("+StaffIDlist + ")  ");
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
		public Edge.SVA.Model.POSSTAFF GetModel(int StaffID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 StaffID,StaffCode,StaffName,StaffPWD,StaffLevel,Status,LanguageID,Def_Reset_PWD_DAYS,Grace_Login_Count,PWD_Valid_Days,Last_Reset_PWD,LastLoginTime,LastLoginStore,LastLoginRegister,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from POSSTAFF ");
			strSql.Append(" where StaffID=@StaffID");
			SqlParameter[] parameters = {
					new SqlParameter("@StaffID", SqlDbType.Int,4)
			};
			parameters[0].Value = StaffID;

			Edge.SVA.Model.POSSTAFF model=new Edge.SVA.Model.POSSTAFF();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["StaffID"]!=null && ds.Tables[0].Rows[0]["StaffID"].ToString()!="")
				{
					model.StaffID=int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StaffCode"]!=null && ds.Tables[0].Rows[0]["StaffCode"].ToString()!="")
				{
					model.StaffCode=ds.Tables[0].Rows[0]["StaffCode"].ToString();
				}
                if (ds.Tables[0].Rows[0]["StaffName"] != null && ds.Tables[0].Rows[0]["StaffName"].ToString() != "")
                {
                    model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffPWD"] != null && ds.Tables[0].Rows[0]["StaffPWD"].ToString() != "")
                {
                    model.StaffPWD = ds.Tables[0].Rows[0]["StaffPWD"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffLevel"] != null && ds.Tables[0].Rows[0]["StaffLevel"].ToString() != "")
                {
                    model.StaffLevel = int.Parse(ds.Tables[0].Rows[0]["StaffLevel"].ToString());
                }
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
                if (ds.Tables[0].Rows[0]["LanguageID"] != null && ds.Tables[0].Rows[0]["LanguageID"].ToString() != "")
                {
                    model.LanguageID = int.Parse(ds.Tables[0].Rows[0]["LanguageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Def_Reset_PWD_DAYS"] != null && ds.Tables[0].Rows[0]["Def_Reset_PWD_DAYS"].ToString() != "")
                {
                    model.Def_Reset_PWD_DAYS = int.Parse(ds.Tables[0].Rows[0]["Def_Reset_PWD_DAYS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Grace_Login_Count"] != null && ds.Tables[0].Rows[0]["Grace_Login_Count"].ToString() != "")
                {
                    model.Grace_Login_Count = int.Parse(ds.Tables[0].Rows[0]["Grace_Login_Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PWD_Valid_Days"] != null && ds.Tables[0].Rows[0]["PWD_Valid_Days"].ToString() != "")
                {
                    model.PWD_Valid_Days = int.Parse(ds.Tables[0].Rows[0]["PWD_Valid_Days"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Last_Reset_PWD"] != null && ds.Tables[0].Rows[0]["Last_Reset_PWD"].ToString() != "")
                {
                    model.Last_Reset_PWD = DateTime.Parse(ds.Tables[0].Rows[0]["Last_Reset_PWD"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"] != null && ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginStore"] != null && ds.Tables[0].Rows[0]["LastLoginStore"].ToString() != "")
                {
                    model.LastLoginStore = ds.Tables[0].Rows[0]["LastLoginStore"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LastLoginRegister"] != null && ds.Tables[0].Rows[0]["LastLoginRegister"].ToString() != "")
                {
                    model.LastLoginRegister = ds.Tables[0].Rows[0]["LastLoginRegister"].ToString();
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
        /// 得到一个对象实体
        /// </summary>
        public Edge.SVA.Model.POSSTAFF GetModel(string StaffCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StaffID,StaffCode,StaffName,StaffPWD,StaffLevel,Status,LanguageID,Def_Reset_PWD_DAYS,Grace_Login_Count,PWD_Valid_Days,Last_Reset_PWD,LastLoginTime,LastLoginStore,LastLoginRegister,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from POSSTAFF ");
            strSql.Append(" where StaffCode=@StaffCode");
            SqlParameter[] parameters = {
					new SqlParameter("@StaffCode", SqlDbType.VarChar,64)
			};
            parameters[0].Value = StaffCode;

            Edge.SVA.Model.POSSTAFF model = new Edge.SVA.Model.POSSTAFF();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["StaffID"] != null && ds.Tables[0].Rows[0]["StaffID"].ToString() != "")
                {
                    model.StaffID = int.Parse(ds.Tables[0].Rows[0]["StaffID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StaffCode"] != null && ds.Tables[0].Rows[0]["StaffCode"].ToString() != "")
                {
                    model.StaffCode = ds.Tables[0].Rows[0]["StaffCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffName"] != null && ds.Tables[0].Rows[0]["StaffName"].ToString() != "")
                {
                    model.StaffName = ds.Tables[0].Rows[0]["StaffName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffPWD"] != null && ds.Tables[0].Rows[0]["StaffPWD"].ToString() != "")
                {
                    model.StaffPWD = ds.Tables[0].Rows[0]["StaffPWD"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StaffLevel"] != null && ds.Tables[0].Rows[0]["StaffLevel"].ToString() != "")
                {
                    model.StaffLevel = int.Parse(ds.Tables[0].Rows[0]["StaffLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LanguageID"] != null && ds.Tables[0].Rows[0]["LanguageID"].ToString() != "")
                {
                    model.LanguageID = int.Parse(ds.Tables[0].Rows[0]["LanguageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Def_Reset_PWD_DAYS"] != null && ds.Tables[0].Rows[0]["Def_Reset_PWD_DAYS"].ToString() != "")
                {
                    model.Def_Reset_PWD_DAYS = int.Parse(ds.Tables[0].Rows[0]["Def_Reset_PWD_DAYS"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Grace_Login_Count"] != null && ds.Tables[0].Rows[0]["Grace_Login_Count"].ToString() != "")
                {
                    model.Grace_Login_Count = int.Parse(ds.Tables[0].Rows[0]["Grace_Login_Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PWD_Valid_Days"] != null && ds.Tables[0].Rows[0]["PWD_Valid_Days"].ToString() != "")
                {
                    model.PWD_Valid_Days = int.Parse(ds.Tables[0].Rows[0]["PWD_Valid_Days"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Last_Reset_PWD"] != null && ds.Tables[0].Rows[0]["Last_Reset_PWD"].ToString() != "")
                {
                    model.Last_Reset_PWD = DateTime.Parse(ds.Tables[0].Rows[0]["Last_Reset_PWD"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"] != null && ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginStore"] != null && ds.Tables[0].Rows[0]["LastLoginStore"].ToString() != "")
                {
                    model.LastLoginStore = ds.Tables[0].Rows[0]["LastLoginStore"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LastLoginRegister"] != null && ds.Tables[0].Rows[0]["LastLoginRegister"].ToString() != "")
                {
                    model.LastLoginRegister = ds.Tables[0].Rows[0]["LastLoginRegister"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedOn"] != null && ds.Tables[0].Rows[0]["CreatedOn"].ToString() != "")
                {
                    model.CreatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatedBy"] != null && ds.Tables[0].Rows[0]["CreatedBy"].ToString() != "")
                {
                    model.CreatedBy = int.Parse(ds.Tables[0].Rows[0]["CreatedBy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedOn"] != null && ds.Tables[0].Rows[0]["UpdatedOn"].ToString() != "")
                {
                    model.UpdatedOn = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedOn"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdatedBy"] != null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString() != "")
                {
                    model.UpdatedBy = int.Parse(ds.Tables[0].Rows[0]["UpdatedBy"].ToString());
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
			strSql.Append("Select StaffID,StaffCode,StaffName,StaffPWD,StaffLevel,Status,LanguageID,Def_Reset_PWD_DAYS,Grace_Login_Count,PWD_Valid_Days,Last_Reset_PWD,LastLoginTime,LastLoginStore,LastLoginRegister,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM POSSTAFF ");
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
			strSql.Append(" StaffID,StaffCode,StaffName,StaffPWD,StaffLevel,Status,LanguageID,Def_Reset_PWD_DAYS,Grace_Login_Count,PWD_Valid_Days,Last_Reset_PWD,LastLoginTime,LastLoginStore,LastLoginRegister,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM POSSTAFF ");
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
			strSql.Append("select count(1) FROM POSSTAFF ");
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
				strSql.Append("order by T.StaffID desc");
			}
			strSql.Append(")AS Row, T.*  from POSSTAFF T ");
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
			parameters[0].Value = "POSSTAFF";
			parameters[1].Value = "StaffID";
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

