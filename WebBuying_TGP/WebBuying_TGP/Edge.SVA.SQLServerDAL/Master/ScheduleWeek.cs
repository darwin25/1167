using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:ScheduleWeek
	/// </summary>
	public partial class ScheduleWeek:IScheduleWeek
	{
		public ScheduleWeek()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Seq", "ScheduleWeek"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Seq)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ScheduleWeek");
			strSql.Append(" where Seq=@Seq");
			SqlParameter[] parameters = {
					new SqlParameter("@Seq", SqlDbType.Int,4)
};
			parameters[0].Value = Seq;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.ScheduleWeek model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ScheduleWeek(");
			strSql.Append("Mon,Tue,wed,thu,Fri,Sat,Sun)");
			strSql.Append(" values (");
			strSql.Append("@Mon,@Tue,@wed,@thu,@Fri,@Sat,@Sun)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Mon", SqlDbType.Bit,1),
					new SqlParameter("@Tue", SqlDbType.Bit,1),
					new SqlParameter("@wed", SqlDbType.Bit,1),
					new SqlParameter("@thu", SqlDbType.Bit,1),
					new SqlParameter("@Fri", SqlDbType.Bit,1),
					new SqlParameter("@Sat", SqlDbType.Bit,1),
					new SqlParameter("@Sun", SqlDbType.Bit,1)};
			parameters[0].Value = model.Mon;
			parameters[1].Value = model.Tue;
			parameters[2].Value = model.wed;
			parameters[3].Value = model.thu;
			parameters[4].Value = model.Fri;
			parameters[5].Value = model.Sat;
			parameters[6].Value = model.Sun;

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
		public bool Update(Edge.SVA.Model.ScheduleWeek model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ScheduleWeek set ");
			strSql.Append("Mon=@Mon,");
			strSql.Append("Tue=@Tue,");
			strSql.Append("wed=@wed,");
			strSql.Append("thu=@thu,");
			strSql.Append("Fri=@Fri,");
			strSql.Append("Sat=@Sat,");
			strSql.Append("Sun=@Sun");
			strSql.Append(" where Seq=@Seq");
			SqlParameter[] parameters = {
					new SqlParameter("@Mon", SqlDbType.Bit,1),
					new SqlParameter("@Tue", SqlDbType.Bit,1),
					new SqlParameter("@wed", SqlDbType.Bit,1),
					new SqlParameter("@thu", SqlDbType.Bit,1),
					new SqlParameter("@Fri", SqlDbType.Bit,1),
					new SqlParameter("@Sat", SqlDbType.Bit,1),
					new SqlParameter("@Sun", SqlDbType.Bit,1),
					new SqlParameter("@Seq", SqlDbType.Int,4)};
			parameters[0].Value = model.Mon;
			parameters[1].Value = model.Tue;
			parameters[2].Value = model.wed;
			parameters[3].Value = model.thu;
			parameters[4].Value = model.Fri;
			parameters[5].Value = model.Sat;
			parameters[6].Value = model.Sun;
			parameters[7].Value = model.Seq;

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
		public bool Delete(int Seq)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScheduleWeek ");
			strSql.Append(" where Seq=@Seq");
			SqlParameter[] parameters = {
					new SqlParameter("@Seq", SqlDbType.Int,4)
};
			parameters[0].Value = Seq;

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
		public bool DeleteList(string Seqlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScheduleWeek ");
			strSql.Append(" where Seq in ("+Seqlist + ")  ");
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
		public Edge.SVA.Model.ScheduleWeek GetModel(int Seq)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Seq,Mon,Tue,wed,thu,Fri,Sat,Sun from ScheduleWeek ");
			strSql.Append(" where Seq=@Seq");
			SqlParameter[] parameters = {
					new SqlParameter("@Seq", SqlDbType.Int,4)
};
			parameters[0].Value = Seq;

			Edge.SVA.Model.ScheduleWeek model=new Edge.SVA.Model.ScheduleWeek();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Seq"]!=null && ds.Tables[0].Rows[0]["Seq"].ToString()!="")
				{
					model.Seq=int.Parse(ds.Tables[0].Rows[0]["Seq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Mon"]!=null && ds.Tables[0].Rows[0]["Mon"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Mon"].ToString()=="1")||(ds.Tables[0].Rows[0]["Mon"].ToString().ToLower()=="true"))
					{
						model.Mon=true;
					}
					else
					{
						model.Mon=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Tue"]!=null && ds.Tables[0].Rows[0]["Tue"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Tue"].ToString()=="1")||(ds.Tables[0].Rows[0]["Tue"].ToString().ToLower()=="true"))
					{
						model.Tue=true;
					}
					else
					{
						model.Tue=false;
					}
				}
				if(ds.Tables[0].Rows[0]["wed"]!=null && ds.Tables[0].Rows[0]["wed"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["wed"].ToString()=="1")||(ds.Tables[0].Rows[0]["wed"].ToString().ToLower()=="true"))
					{
						model.wed=true;
					}
					else
					{
						model.wed=false;
					}
				}
				if(ds.Tables[0].Rows[0]["thu"]!=null && ds.Tables[0].Rows[0]["thu"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["thu"].ToString()=="1")||(ds.Tables[0].Rows[0]["thu"].ToString().ToLower()=="true"))
					{
						model.thu=true;
					}
					else
					{
						model.thu=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Fri"]!=null && ds.Tables[0].Rows[0]["Fri"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Fri"].ToString()=="1")||(ds.Tables[0].Rows[0]["Fri"].ToString().ToLower()=="true"))
					{
						model.Fri=true;
					}
					else
					{
						model.Fri=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Sat"]!=null && ds.Tables[0].Rows[0]["Sat"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Sat"].ToString()=="1")||(ds.Tables[0].Rows[0]["Sat"].ToString().ToLower()=="true"))
					{
						model.Sat=true;
					}
					else
					{
						model.Sat=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Sun"]!=null && ds.Tables[0].Rows[0]["Sun"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Sun"].ToString()=="1")||(ds.Tables[0].Rows[0]["Sun"].ToString().ToLower()=="true"))
					{
						model.Sun=true;
					}
					else
					{
						model.Sun=false;
					}
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
			strSql.Append("select Seq,Mon,Tue,wed,thu,Fri,Sat,Sun ");
			strSql.Append(" FROM ScheduleWeek ");
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
			strSql.Append(" Seq,Mon,Tue,wed,thu,Fri,Sat,Sun ");
			strSql.Append(" FROM ScheduleWeek ");
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
			parameters[0].Value = "ScheduleWeek";
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
            sql.Append("select count(*) from ScheduleWeek ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

