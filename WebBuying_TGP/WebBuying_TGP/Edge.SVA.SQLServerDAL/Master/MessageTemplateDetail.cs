using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MessageTemplateDetail
	/// </summary>
	public partial class MessageTemplateDetail:IMessageTemplateDetail
	{
		public MessageTemplateDetail()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "MessageTemplateDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MessageTemplateDetail");
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
		public int Add(Edge.SVA.Model.MessageTemplateDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MessageTemplateDetail(");
			strSql.Append("MessageTemplateID,MessageServiceTypeID,status,MessageTitle1,MessageTitle3,MessageTitle2,TemplateContent1,TemplateContent2,TemplateContent3)");
			strSql.Append(" values (");
			strSql.Append("@MessageTemplateID,@MessageServiceTypeID,@status,@MessageTitle1,@MessageTitle3,@MessageTitle2,@TemplateContent1,@TemplateContent2,@TemplateContent3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@MessageTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@TemplateContent1", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent2", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent3", SqlDbType.NVarChar)};
			parameters[0].Value = model.MessageTemplateID;
			parameters[1].Value = model.MessageServiceTypeID;
			parameters[2].Value = model.status;
			parameters[3].Value = model.MessageTitle1;
			parameters[4].Value = model.MessageTitle3;
			parameters[5].Value = model.MessageTitle2;
			parameters[6].Value = model.TemplateContent1;
			parameters[7].Value = model.TemplateContent2;
			parameters[8].Value = model.TemplateContent3;

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
		public bool Update(Edge.SVA.Model.MessageTemplateDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MessageTemplateDetail set ");
			strSql.Append("MessageTemplateID=@MessageTemplateID,");
			strSql.Append("MessageServiceTypeID=@MessageServiceTypeID,");
			strSql.Append("status=@status,");
			strSql.Append("MessageTitle1=@MessageTitle1,");
			strSql.Append("MessageTitle3=@MessageTitle3,");
			strSql.Append("MessageTitle2=@MessageTitle2,");
			strSql.Append("TemplateContent1=@TemplateContent1,");
			strSql.Append("TemplateContent2=@TemplateContent2,");
			strSql.Append("TemplateContent3=@TemplateContent3");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4),
					new SqlParameter("@MessageServiceTypeID", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@MessageTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@TemplateContent1", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent2", SqlDbType.NVarChar),
					new SqlParameter("@TemplateContent3", SqlDbType.NVarChar),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.MessageTemplateID;
			parameters[1].Value = model.MessageServiceTypeID;
			parameters[2].Value = model.status;
			parameters[3].Value = model.MessageTitle1;
			parameters[4].Value = model.MessageTitle3;
			parameters[5].Value = model.MessageTitle2;
			parameters[6].Value = model.TemplateContent1;
			parameters[7].Value = model.TemplateContent2;
			parameters[8].Value = model.TemplateContent3;
			parameters[9].Value = model.KeyID;

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
			strSql.Append("delete from MessageTemplateDetail ");
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
			strSql.Append("delete from MessageTemplateDetail ");
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
		public Edge.SVA.Model.MessageTemplateDetail GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,MessageTemplateID,MessageServiceTypeID,status,MessageTitle1,MessageTitle3,MessageTitle2,TemplateContent1,TemplateContent2,TemplateContent3 from MessageTemplateDetail ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.MessageTemplateDetail model=new Edge.SVA.Model.MessageTemplateDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MessageTemplateID"]!=null && ds.Tables[0].Rows[0]["MessageTemplateID"].ToString()!="")
				{
					model.MessageTemplateID=int.Parse(ds.Tables[0].Rows[0]["MessageTemplateID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MessageServiceTypeID"]!=null && ds.Tables[0].Rows[0]["MessageServiceTypeID"].ToString()!="")
				{
					model.MessageServiceTypeID=int.Parse(ds.Tables[0].Rows[0]["MessageServiceTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"]!=null && ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MessageTitle1"]!=null && ds.Tables[0].Rows[0]["MessageTitle1"].ToString()!="")
				{
					model.MessageTitle1=ds.Tables[0].Rows[0]["MessageTitle1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MessageTitle3"]!=null && ds.Tables[0].Rows[0]["MessageTitle3"].ToString()!="")
				{
					model.MessageTitle3=ds.Tables[0].Rows[0]["MessageTitle3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MessageTitle2"]!=null && ds.Tables[0].Rows[0]["MessageTitle2"].ToString()!="")
				{
					model.MessageTitle2=ds.Tables[0].Rows[0]["MessageTitle2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TemplateContent1"]!=null && ds.Tables[0].Rows[0]["TemplateContent1"].ToString()!="")
				{
					model.TemplateContent1=ds.Tables[0].Rows[0]["TemplateContent1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TemplateContent2"]!=null && ds.Tables[0].Rows[0]["TemplateContent2"].ToString()!="")
				{
					model.TemplateContent2=ds.Tables[0].Rows[0]["TemplateContent2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TemplateContent3"]!=null && ds.Tables[0].Rows[0]["TemplateContent3"].ToString()!="")
				{
					model.TemplateContent3=ds.Tables[0].Rows[0]["TemplateContent3"].ToString();
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
			strSql.Append("select KeyID,MessageTemplateID,MessageServiceTypeID,status,MessageTitle1,MessageTitle3,MessageTitle2,TemplateContent1,TemplateContent2,TemplateContent3 ");
			strSql.Append(" FROM MessageTemplateDetail ");
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
			strSql.Append(" KeyID,MessageTemplateID,MessageServiceTypeID,status,MessageTitle1,MessageTitle3,MessageTitle2,TemplateContent1,TemplateContent2,TemplateContent3 ");
			strSql.Append(" FROM MessageTemplateDetail ");
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
			strSql.Append("select count(1) FROM MessageTemplateDetail ");
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
				strSql.Append("order by T.KeyID desc");
			}
			strSql.Append(")AS Row, T.*  from MessageTemplateDetail T ");
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
			parameters[0].Value = "MessageTemplateDetail";
			parameters[1].Value = "KeyID";
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

