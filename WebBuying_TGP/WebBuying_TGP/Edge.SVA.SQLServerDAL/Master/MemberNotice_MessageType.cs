using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MemberNotice_MessageType
	/// </summary>
	public partial class MemberNotice_MessageType:IMemberNotice_MessageType
	{
		public MemberNotice_MessageType()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "MemberNotice_MessageType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MemberNotice_MessageType");
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
		public int Add(Edge.SVA.Model.MemberNotice_MessageType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MemberNotice_MessageType(");
			strSql.Append("NoticeNumber,MessageTemplateID,Status,FrequencyUnit,FrequencyValue,SendTime,DesignSendTimes,SendCount)");
			strSql.Append(" values (");
			strSql.Append("@NoticeNumber,@MessageTemplateID,@Status,@FrequencyUnit,@FrequencyValue,@SendTime,@DesignSendTimes,@SendCount)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NoticeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@FrequencyUnit", SqlDbType.Int,4),
					new SqlParameter("@FrequencyValue", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@DesignSendTimes", SqlDbType.Int,4),
					new SqlParameter("@SendCount", SqlDbType.Int,4)};
			parameters[0].Value = model.NoticeNumber;
			parameters[1].Value = model.MessageTemplateID;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.FrequencyUnit;
			parameters[4].Value = model.FrequencyValue;
			parameters[5].Value = model.SendTime;
			parameters[6].Value = model.DesignSendTimes;
			parameters[7].Value = model.SendCount;

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
		public bool Update(Edge.SVA.Model.MemberNotice_MessageType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MemberNotice_MessageType set ");
			strSql.Append("NoticeNumber=@NoticeNumber,");
			strSql.Append("MessageTemplateID=@MessageTemplateID,");
			strSql.Append("Status=@Status,");
			strSql.Append("FrequencyUnit=@FrequencyUnit,");
			strSql.Append("FrequencyValue=@FrequencyValue,");
			strSql.Append("SendTime=@SendTime,");
			strSql.Append("DesignSendTimes=@DesignSendTimes,");
			strSql.Append("SendCount=@SendCount");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@NoticeNumber", SqlDbType.VarChar,64),
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@FrequencyUnit", SqlDbType.Int,4),
					new SqlParameter("@FrequencyValue", SqlDbType.Int,4),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@DesignSendTimes", SqlDbType.Int,4),
					new SqlParameter("@SendCount", SqlDbType.Int,4),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.NoticeNumber;
			parameters[1].Value = model.MessageTemplateID;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.FrequencyUnit;
			parameters[4].Value = model.FrequencyValue;
			parameters[5].Value = model.SendTime;
			parameters[6].Value = model.DesignSendTimes;
			parameters[7].Value = model.SendCount;
			parameters[8].Value = model.KeyID;

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
			strSql.Append("delete from MemberNotice_MessageType ");
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
			strSql.Append("delete from MemberNotice_MessageType ");
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
		public Edge.SVA.Model.MemberNotice_MessageType GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,NoticeNumber,MessageTemplateID,Status,FrequencyUnit,FrequencyValue,SendTime,DesignSendTimes,SendCount from MemberNotice_MessageType ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.MemberNotice_MessageType model=new Edge.SVA.Model.MemberNotice_MessageType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NoticeNumber"]!=null && ds.Tables[0].Rows[0]["NoticeNumber"].ToString()!="")
				{
					model.NoticeNumber=ds.Tables[0].Rows[0]["NoticeNumber"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MessageTemplateID"]!=null && ds.Tables[0].Rows[0]["MessageTemplateID"].ToString()!="")
				{
					model.MessageTemplateID=int.Parse(ds.Tables[0].Rows[0]["MessageTemplateID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FrequencyUnit"]!=null && ds.Tables[0].Rows[0]["FrequencyUnit"].ToString()!="")
				{
					model.FrequencyUnit=int.Parse(ds.Tables[0].Rows[0]["FrequencyUnit"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FrequencyValue"]!=null && ds.Tables[0].Rows[0]["FrequencyValue"].ToString()!="")
				{
					model.FrequencyValue=int.Parse(ds.Tables[0].Rows[0]["FrequencyValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendTime"]!=null && ds.Tables[0].Rows[0]["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(ds.Tables[0].Rows[0]["SendTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DesignSendTimes"]!=null && ds.Tables[0].Rows[0]["DesignSendTimes"].ToString()!="")
				{
					model.DesignSendTimes=int.Parse(ds.Tables[0].Rows[0]["DesignSendTimes"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SendCount"]!=null && ds.Tables[0].Rows[0]["SendCount"].ToString()!="")
				{
					model.SendCount=int.Parse(ds.Tables[0].Rows[0]["SendCount"].ToString());
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
			strSql.Append("select KeyID,NoticeNumber,MessageTemplateID,Status,FrequencyUnit,FrequencyValue,SendTime,DesignSendTimes,SendCount ");
			strSql.Append(" FROM MemberNotice_MessageType ");
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
			strSql.Append(" KeyID,NoticeNumber,MessageTemplateID,Status,FrequencyUnit,FrequencyValue,SendTime,DesignSendTimes,SendCount ");
			strSql.Append(" FROM MemberNotice_MessageType ");
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
			strSql.Append("select count(1) FROM MemberNotice_MessageType ");
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
			strSql.Append(")AS Row, T.*  from MemberNotice_MessageType T ");
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
			parameters[0].Value = "MemberNotice_MessageType";
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

