using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Schedule
	/// </summary>
	public partial class Schedule:ISchedule
	{
		public Schedule()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Seq", "Schedule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Seq)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Schedule");
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
		public int Add(Edge.SVA.Model.Schedule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Schedule(");
			strSql.Append("Name,FreqType,FreqValue,FreqAt,WeekSeq,HappenTime,BeginDate,EndDate,Valid,LastCheckDate,Message,MsgType,QueryID)");
			strSql.Append(" values (");
			strSql.Append("@Name,@FreqType,@FreqValue,@FreqAt,@WeekSeq,@HappenTime,@BeginDate,@EndDate,@Valid,@LastCheckDate,@Message,@MsgType,@QueryID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.Char,10),
					new SqlParameter("@FreqType", SqlDbType.Int,4),
					new SqlParameter("@FreqValue", SqlDbType.Decimal,9),
					new SqlParameter("@FreqAt", SqlDbType.Int,4),
					new SqlParameter("@WeekSeq", SqlDbType.Int,4),
					new SqlParameter("@HappenTime", SqlDbType.DateTime),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Bit,1),
					new SqlParameter("@LastCheckDate", SqlDbType.DateTime),
					new SqlParameter("@Message", SqlDbType.VarChar,200),
					new SqlParameter("@MsgType", SqlDbType.Int,4),
					new SqlParameter("@QueryID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.FreqType;
			parameters[2].Value = model.FreqValue;
			parameters[3].Value = model.FreqAt;
			parameters[4].Value = model.WeekSeq;
			parameters[5].Value = model.HappenTime;
			parameters[6].Value = model.BeginDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.Valid;
			parameters[9].Value = model.LastCheckDate;
			parameters[10].Value = model.Message;
			parameters[11].Value = model.MsgType;
			parameters[12].Value = model.QueryID;

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
		public bool Update(Edge.SVA.Model.Schedule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Schedule set ");
			strSql.Append("Name=@Name,");
			strSql.Append("FreqType=@FreqType,");
			strSql.Append("FreqValue=@FreqValue,");
			strSql.Append("FreqAt=@FreqAt,");
			strSql.Append("WeekSeq=@WeekSeq,");
			strSql.Append("HappenTime=@HappenTime,");
			strSql.Append("BeginDate=@BeginDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Valid=@Valid,");
			strSql.Append("LastCheckDate=@LastCheckDate,");
			strSql.Append("Message=@Message,");
			strSql.Append("MsgType=@MsgType,");
			strSql.Append("QueryID=@QueryID");
			strSql.Append(" where Seq=@Seq");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.Char,10),
					new SqlParameter("@FreqType", SqlDbType.Int,4),
					new SqlParameter("@FreqValue", SqlDbType.Decimal,9),
					new SqlParameter("@FreqAt", SqlDbType.Int,4),
					new SqlParameter("@WeekSeq", SqlDbType.Int,4),
					new SqlParameter("@HappenTime", SqlDbType.DateTime),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Bit,1),
					new SqlParameter("@LastCheckDate", SqlDbType.DateTime),
					new SqlParameter("@Message", SqlDbType.VarChar,200),
					new SqlParameter("@MsgType", SqlDbType.Int,4),
					new SqlParameter("@QueryID", SqlDbType.Int,4),
					new SqlParameter("@Seq", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.FreqType;
			parameters[2].Value = model.FreqValue;
			parameters[3].Value = model.FreqAt;
			parameters[4].Value = model.WeekSeq;
			parameters[5].Value = model.HappenTime;
			parameters[6].Value = model.BeginDate;
			parameters[7].Value = model.EndDate;
			parameters[8].Value = model.Valid;
			parameters[9].Value = model.LastCheckDate;
			parameters[10].Value = model.Message;
			parameters[11].Value = model.MsgType;
			parameters[12].Value = model.QueryID;
			parameters[13].Value = model.Seq;

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
			strSql.Append("delete from Schedule ");
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
			strSql.Append("delete from Schedule ");
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
		public Edge.SVA.Model.Schedule GetModel(int Seq)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Seq,Name,FreqType,FreqValue,FreqAt,WeekSeq,HappenTime,BeginDate,EndDate,Valid,LastCheckDate,Message,MsgType,QueryID from Schedule ");
			strSql.Append(" where Seq=@Seq");
			SqlParameter[] parameters = {
					new SqlParameter("@Seq", SqlDbType.Int,4)
};
			parameters[0].Value = Seq;

			Edge.SVA.Model.Schedule model=new Edge.SVA.Model.Schedule();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Seq"]!=null && ds.Tables[0].Rows[0]["Seq"].ToString()!="")
				{
					model.Seq=int.Parse(ds.Tables[0].Rows[0]["Seq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FreqType"]!=null && ds.Tables[0].Rows[0]["FreqType"].ToString()!="")
				{
					model.FreqType=int.Parse(ds.Tables[0].Rows[0]["FreqType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FreqValue"]!=null && ds.Tables[0].Rows[0]["FreqValue"].ToString()!="")
				{
					model.FreqValue=decimal.Parse(ds.Tables[0].Rows[0]["FreqValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FreqAt"]!=null && ds.Tables[0].Rows[0]["FreqAt"].ToString()!="")
				{
					model.FreqAt=int.Parse(ds.Tables[0].Rows[0]["FreqAt"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WeekSeq"]!=null && ds.Tables[0].Rows[0]["WeekSeq"].ToString()!="")
				{
					model.WeekSeq=int.Parse(ds.Tables[0].Rows[0]["WeekSeq"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HappenTime"]!=null && ds.Tables[0].Rows[0]["HappenTime"].ToString()!="")
				{
					model.HappenTime=DateTime.Parse(ds.Tables[0].Rows[0]["HappenTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BeginDate"]!=null && ds.Tables[0].Rows[0]["BeginDate"].ToString()!="")
				{
					model.BeginDate=DateTime.Parse(ds.Tables[0].Rows[0]["BeginDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Valid"]!=null && ds.Tables[0].Rows[0]["Valid"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Valid"].ToString()=="1")||(ds.Tables[0].Rows[0]["Valid"].ToString().ToLower()=="true"))
					{
						model.Valid=true;
					}
					else
					{
						model.Valid=false;
					}
				}
				if(ds.Tables[0].Rows[0]["LastCheckDate"]!=null && ds.Tables[0].Rows[0]["LastCheckDate"].ToString()!="")
				{
					model.LastCheckDate=DateTime.Parse(ds.Tables[0].Rows[0]["LastCheckDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Message"]!=null && ds.Tables[0].Rows[0]["Message"].ToString()!="")
				{
					model.Message=ds.Tables[0].Rows[0]["Message"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MsgType"]!=null && ds.Tables[0].Rows[0]["MsgType"].ToString()!="")
				{
					model.MsgType=int.Parse(ds.Tables[0].Rows[0]["MsgType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QueryID"]!=null && ds.Tables[0].Rows[0]["QueryID"].ToString()!="")
				{
					model.QueryID=int.Parse(ds.Tables[0].Rows[0]["QueryID"].ToString());
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
			strSql.Append("select Seq,Name,FreqType,FreqValue,FreqAt,WeekSeq,HappenTime,BeginDate,EndDate,Valid,LastCheckDate,Message,MsgType,QueryID ");
			strSql.Append(" FROM Schedule ");
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
			strSql.Append(" Seq,Name,FreqType,FreqValue,FreqAt,WeekSeq,HappenTime,BeginDate,EndDate,Valid,LastCheckDate,Message,MsgType,QueryID ");
			strSql.Append(" FROM Schedule ");
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
			parameters[0].Value = "Schedule";
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
            sql.Append("select count(*) from Schedule ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }

		#endregion  Method
	}
}

