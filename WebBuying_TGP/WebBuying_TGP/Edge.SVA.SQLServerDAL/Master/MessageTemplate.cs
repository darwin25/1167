using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:MessageTemplate
	/// </summary>
	public partial class MessageTemplate:IMessageTemplate
	{
		public MessageTemplate()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MessageTemplateID", "MessageTemplate"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MessageTemplateID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from MessageTemplate");
			strSql.Append(" where MessageTemplateID=@MessageTemplateID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4)
			};
			parameters[0].Value = MessageTemplateID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.MessageTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MessageTemplate(");
			strSql.Append("MessageTemplateCode,MessageTemplateDesc,BrandID,OprID,Remark)");
			strSql.Append(" values (");
			strSql.Append("@MessageTemplateCode,@MessageTemplateDesc,@BrandID,@OprID,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateCode", SqlDbType.VarChar,64),
					new SqlParameter("@MessageTemplateDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.MessageTemplateCode;
			parameters[1].Value = model.MessageTemplateDesc;
			parameters[2].Value = model.BrandID;
			parameters[3].Value = model.OprID;
			parameters[4].Value = model.Remark;

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
		public bool Update(Edge.SVA.Model.MessageTemplate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MessageTemplate set ");
			strSql.Append("MessageTemplateCode=@MessageTemplateCode,");
			strSql.Append("MessageTemplateDesc=@MessageTemplateDesc,");
			strSql.Append("BrandID=@BrandID,");
			strSql.Append("OprID=@OprID,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where MessageTemplateID=@MessageTemplateID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateCode", SqlDbType.VarChar,64),
					new SqlParameter("@MessageTemplateDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@BrandID", SqlDbType.Int,4),
					new SqlParameter("@OprID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,512),
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4)};
			parameters[0].Value = model.MessageTemplateCode;
			parameters[1].Value = model.MessageTemplateDesc;
			parameters[2].Value = model.BrandID;
			parameters[3].Value = model.OprID;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.MessageTemplateID;

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
		public bool Delete(int MessageTemplateID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MessageTemplate ");
			strSql.Append(" where MessageTemplateID=@MessageTemplateID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4)
			};
			parameters[0].Value = MessageTemplateID;

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
		public bool DeleteList(string MessageTemplateIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MessageTemplate ");
			strSql.Append(" where MessageTemplateID in ("+MessageTemplateIDlist + ")  ");
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
		public Edge.SVA.Model.MessageTemplate GetModel(int MessageTemplateID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MessageTemplateID,MessageTemplateCode,MessageTemplateDesc,BrandID,OprID,Remark from MessageTemplate ");
			strSql.Append(" where MessageTemplateID=@MessageTemplateID");
			SqlParameter[] parameters = {
					new SqlParameter("@MessageTemplateID", SqlDbType.Int,4)
			};
			parameters[0].Value = MessageTemplateID;

			Edge.SVA.Model.MessageTemplate model=new Edge.SVA.Model.MessageTemplate();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MessageTemplateID"]!=null && ds.Tables[0].Rows[0]["MessageTemplateID"].ToString()!="")
				{
					model.MessageTemplateID=int.Parse(ds.Tables[0].Rows[0]["MessageTemplateID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MessageTemplateCode"]!=null && ds.Tables[0].Rows[0]["MessageTemplateCode"].ToString()!="")
				{
					model.MessageTemplateCode=ds.Tables[0].Rows[0]["MessageTemplateCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MessageTemplateDesc"]!=null && ds.Tables[0].Rows[0]["MessageTemplateDesc"].ToString()!="")
				{
					model.MessageTemplateDesc=ds.Tables[0].Rows[0]["MessageTemplateDesc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BrandID"]!=null && ds.Tables[0].Rows[0]["BrandID"].ToString()!="")
				{
					model.BrandID=int.Parse(ds.Tables[0].Rows[0]["BrandID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OprID"]!=null && ds.Tables[0].Rows[0]["OprID"].ToString()!="")
				{
					model.OprID=int.Parse(ds.Tables[0].Rows[0]["OprID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append("select MessageTemplateID,MessageTemplateCode,MessageTemplateDesc,BrandID,OprID,Remark ");
			strSql.Append(" FROM MessageTemplate ");
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
			strSql.Append(" MessageTemplateID,MessageTemplateCode,MessageTemplateDesc,BrandID,OprID,Remark ");
			strSql.Append(" FROM MessageTemplate ");
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
			strSql.Append("select count(1) FROM MessageTemplate ");
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
				strSql.Append("order by T.MessageTemplateID desc");
			}
			strSql.Append(")AS Row, T.*  from MessageTemplate T ");
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
			parameters[0].Value = "MessageTemplate";
			parameters[1].Value = "MessageTemplateID";
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

