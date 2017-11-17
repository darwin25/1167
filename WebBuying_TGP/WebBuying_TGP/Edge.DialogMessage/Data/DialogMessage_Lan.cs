using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Edge.Messages.Data
{
	/// <summary>
	/// 数据访问类:DialogMessage_Lan
	/// </summary>
	public partial class DialogMessage_Lan
	{
		public DialogMessage_Lan()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TAPCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DialogMessage_Lan");
			strSql.Append(" where TAPCode=@TAPCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = TAPCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.Messages.Model.DialogMessage_Lan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DialogMessage_Lan(");
			strSql.Append("TAPCode,Message,Lan)");
			strSql.Append(" values (");
			strSql.Append("@TAPCode,@Message,@Lan)");
			SqlParameter[] parameters = {
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Message", SqlDbType.NVarChar),
					new SqlParameter("@Lan", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.TAPCode;
			parameters[1].Value = model.Message;
			parameters[2].Value = model.Lan;

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
		public bool Update(Edge.Messages.Model.DialogMessage_Lan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DialogMessage_Lan set ");
			strSql.Append("Message=@Message,");
			strSql.Append("Lan=@Lan");
			strSql.Append(" where TAPCode=@TAPCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@Message", SqlDbType.NVarChar),
					new SqlParameter("@Lan", SqlDbType.NVarChar,512),
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Message;
			parameters[1].Value = model.Lan;
			parameters[2].Value = model.TAPCode;

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
		public bool Delete(string TAPCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DialogMessage_Lan ");
			strSql.Append(" where TAPCode=@TAPCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = TAPCode;

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
		public bool DeleteList(string TAPCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from DialogMessage_Lan ");
			strSql.Append(" where TAPCode in ("+TAPCodelist + ")  ");
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
		public Edge.Messages.Model.DialogMessage_Lan GetModel(string TAPCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TAPCode,Message,Lan from DialogMessage_Lan ");
			strSql.Append(" where TAPCode=@TAPCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = TAPCode;

			Edge.Messages.Model.DialogMessage_Lan model=new Edge.Messages.Model.DialogMessage_Lan();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TAPCode"]!=null && ds.Tables[0].Rows[0]["TAPCode"].ToString()!="")
				{
					model.TAPCode=ds.Tables[0].Rows[0]["TAPCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Message"]!=null && ds.Tables[0].Rows[0]["Message"].ToString()!="")
				{
					model.Message=ds.Tables[0].Rows[0]["Message"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Lan"]!=null && ds.Tables[0].Rows[0]["Lan"].ToString()!="")
				{
					model.Lan=ds.Tables[0].Rows[0]["Lan"].ToString();
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
			strSql.Append("select TAPCode,Message,Lan ");
			strSql.Append(" FROM DialogMessage_Lan ");
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
			strSql.Append(" TAPCode,Message,Lan ");
			strSql.Append(" FROM DialogMessage_Lan ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "DialogMessage_Lan";
			parameters[1].Value = "TAPCode";
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

