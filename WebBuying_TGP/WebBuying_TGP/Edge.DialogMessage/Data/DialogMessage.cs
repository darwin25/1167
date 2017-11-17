using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Edge.Messages.Data
{
	/// <summary>
	/// 数据访问类:DialogMessage
	/// </summary>
	public partial class DialogMessage
	{
		public DialogMessage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TAPCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from DialogMessage");
			strSql.Append(" where TAPCode=@TAPCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = TAPCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.Messages.Model.DialogMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into DialogMessage(");
			strSql.Append("TAPCode,OriginalCode,Message,Project,Product,ModifiedBy,AddDate,MessageIconDisplay,ButtonDisplay)");
			strSql.Append(" values (");
			strSql.Append("@TAPCode,@OriginalCode,@Message,@Project,@Product,@ModifiedBy,@AddDate,@MessageIconDisplay,@ButtonDisplay)");
			SqlParameter[] parameters = {
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50),
					new SqlParameter("@OriginalCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Message", SqlDbType.NVarChar),
					new SqlParameter("@Project", SqlDbType.NVarChar,512),
					new SqlParameter("@Product", SqlDbType.NVarChar,512),
					new SqlParameter("@ModifiedBy", SqlDbType.NVarChar,512),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MessageIconDisplay", SqlDbType.Bit,1),
					new SqlParameter("@ButtonDisplay", SqlDbType.Bit,1)};
			parameters[0].Value = model.TAPCode;
			parameters[1].Value = model.OriginalCode;
			parameters[2].Value = model.Message;
			parameters[3].Value = model.Project;
			parameters[4].Value = model.Product;
			parameters[5].Value = model.ModifiedBy;
			parameters[6].Value = model.AddDate;
			parameters[7].Value = model.MessageIconDisplay;
			parameters[8].Value = model.ButtonDisplay;

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
		public bool Update(Edge.Messages.Model.DialogMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update DialogMessage set ");
			strSql.Append("OriginalCode=@OriginalCode,");
			strSql.Append("Message=@Message,");
			strSql.Append("Project=@Project,");
			strSql.Append("Product=@Product,");
			strSql.Append("ModifiedBy=@ModifiedBy,");
			strSql.Append("AddDate=@AddDate,");
			strSql.Append("MessageIconDisplay=@MessageIconDisplay,");
			strSql.Append("ButtonDisplay=@ButtonDisplay");
			strSql.Append(" where TAPCode=@TAPCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@OriginalCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Message", SqlDbType.NVarChar),
					new SqlParameter("@Project", SqlDbType.NVarChar,512),
					new SqlParameter("@Product", SqlDbType.NVarChar,512),
					new SqlParameter("@ModifiedBy", SqlDbType.NVarChar,512),
					new SqlParameter("@AddDate", SqlDbType.DateTime),
					new SqlParameter("@MessageIconDisplay", SqlDbType.Bit,1),
					new SqlParameter("@ButtonDisplay", SqlDbType.Bit,1),
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.OriginalCode;
			parameters[1].Value = model.Message;
			parameters[2].Value = model.Project;
			parameters[3].Value = model.Product;
			parameters[4].Value = model.ModifiedBy;
			parameters[5].Value = model.AddDate;
			parameters[6].Value = model.MessageIconDisplay;
			parameters[7].Value = model.ButtonDisplay;
			parameters[8].Value = model.TAPCode;

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
			strSql.Append("delete from DialogMessage ");
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
			strSql.Append("delete from DialogMessage ");
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
		public Edge.Messages.Model.DialogMessage GetModel(string TAPCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TAPCode,OriginalCode,Message,Project,Product,ModifiedBy,AddDate,MessageIconDisplay,ButtonDisplay from DialogMessage ");
			strSql.Append(" where TAPCode=@TAPCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@TAPCode", SqlDbType.NVarChar,50)};
			parameters[0].Value = TAPCode;

			Edge.Messages.Model.DialogMessage model=new Edge.Messages.Model.DialogMessage();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["TAPCode"]!=null && ds.Tables[0].Rows[0]["TAPCode"].ToString()!="")
				{
					model.TAPCode=ds.Tables[0].Rows[0]["TAPCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OriginalCode"]!=null && ds.Tables[0].Rows[0]["OriginalCode"].ToString()!="")
				{
					model.OriginalCode=ds.Tables[0].Rows[0]["OriginalCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Message"]!=null && ds.Tables[0].Rows[0]["Message"].ToString()!="")
				{
					model.Message=ds.Tables[0].Rows[0]["Message"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Project"]!=null && ds.Tables[0].Rows[0]["Project"].ToString()!="")
				{
					model.Project=ds.Tables[0].Rows[0]["Project"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Product"]!=null && ds.Tables[0].Rows[0]["Product"].ToString()!="")
				{
					model.Product=ds.Tables[0].Rows[0]["Product"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ModifiedBy"]!=null && ds.Tables[0].Rows[0]["ModifiedBy"].ToString()!="")
				{
					model.ModifiedBy=ds.Tables[0].Rows[0]["ModifiedBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AddDate"]!=null && ds.Tables[0].Rows[0]["AddDate"].ToString()!="")
				{
					model.AddDate=DateTime.Parse(ds.Tables[0].Rows[0]["AddDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MessageIconDisplay"]!=null && ds.Tables[0].Rows[0]["MessageIconDisplay"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["MessageIconDisplay"].ToString()=="1")||(ds.Tables[0].Rows[0]["MessageIconDisplay"].ToString().ToLower()=="true"))
					{
						model.MessageIconDisplay=true;
					}
					else
					{
						model.MessageIconDisplay=false;
					}
				}
				if(ds.Tables[0].Rows[0]["ButtonDisplay"]!=null && ds.Tables[0].Rows[0]["ButtonDisplay"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ButtonDisplay"].ToString()=="1")||(ds.Tables[0].Rows[0]["ButtonDisplay"].ToString().ToLower()=="true"))
					{
						model.ButtonDisplay=true;
					}
					else
					{
						model.ButtonDisplay=false;
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
			strSql.Append("select TAPCode,OriginalCode,Message,Project,Product,ModifiedBy,AddDate,MessageIconDisplay,ButtonDisplay ");
			strSql.Append(" FROM DialogMessage ");
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
			strSql.Append(" TAPCode,OriginalCode,Message,Project,Product,ModifiedBy,AddDate,MessageIconDisplay,ButtonDisplay ");
			strSql.Append(" FROM DialogMessage ");
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
			parameters[0].Value = "DialogMessage";
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

