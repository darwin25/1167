using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:PromotionMsg
	/// </summary>
	public partial class PromotionMsg:IPromotionMsg
	{
		public PromotionMsg()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "PromotionMsg"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PromotionMsg");
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
		public int Add(Edge.SVA.Model.PromotionMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PromotionMsg(");
			strSql.Append("PromotionTitle1,PromotionTitle2,PromotionTitle3,PromotionMsgStr1,PromotionMsgStr2,PromotionMsgStr3,PromotionPicFile,PromotionRemark,PromptScheduleID,BirthPromotion,DeviceType,StartDate,EndDate,Status,CampaignID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PromotionMsgTypeID,PromotionMsgCode,AttachmentFilePath)");
			strSql.Append(" values (");
			strSql.Append("@PromotionTitle1,@PromotionTitle2,@PromotionTitle3,@PromotionMsgStr1,@PromotionMsgStr2,@PromotionMsgStr3,@PromotionPicFile,@PromotionRemark,@PromptScheduleID,@BirthPromotion,@DeviceType,@StartDate,@EndDate,@Status,@CampaignID,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@PromotionMsgTypeID,@PromotionMsgCode,@AttachmentFilePath)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgStr1", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr2", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr3", SqlDbType.NVarChar),
					new SqlParameter("@PromotionPicFile", SqlDbType.VarChar,512),
					new SqlParameter("@PromotionRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@PromptScheduleID", SqlDbType.Int,4),
					new SqlParameter("@BirthPromotion", SqlDbType.Int,4),
					new SqlParameter("@DeviceType", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CampaignID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AttachmentFilePath", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.PromotionTitle1;
			parameters[1].Value = model.PromotionTitle2;
			parameters[2].Value = model.PromotionTitle3;
			parameters[3].Value = model.PromotionMsgStr1;
			parameters[4].Value = model.PromotionMsgStr2;
			parameters[5].Value = model.PromotionMsgStr3;
			parameters[6].Value = model.PromotionPicFile;
			parameters[7].Value = model.PromotionRemark;
			parameters[8].Value = model.PromptScheduleID;
			parameters[9].Value = model.BirthPromotion;
			parameters[10].Value = model.DeviceType;
			parameters[11].Value = model.StartDate;
			parameters[12].Value = model.EndDate;
			parameters[13].Value = model.Status;
			parameters[14].Value = model.CampaignID;
			parameters[15].Value = model.CreatedOn;
			parameters[16].Value = model.CreatedBy;
			parameters[17].Value = model.UpdatedOn;
			parameters[18].Value = model.UpdatedBy;
			parameters[19].Value = model.PromotionMsgTypeID;
			parameters[20].Value = model.PromotionMsgCode;
			parameters[21].Value = model.AttachmentFilePath;

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
		public bool Update(Edge.SVA.Model.PromotionMsg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PromotionMsg set ");
			strSql.Append("PromotionTitle1=@PromotionTitle1,");
			strSql.Append("PromotionTitle2=@PromotionTitle2,");
			strSql.Append("PromotionTitle3=@PromotionTitle3,");
			strSql.Append("PromotionMsgStr1=@PromotionMsgStr1,");
			strSql.Append("PromotionMsgStr2=@PromotionMsgStr2,");
			strSql.Append("PromotionMsgStr3=@PromotionMsgStr3,");
			strSql.Append("PromotionPicFile=@PromotionPicFile,");
			strSql.Append("PromotionRemark=@PromotionRemark,");
			strSql.Append("PromptScheduleID=@PromptScheduleID,");
			strSql.Append("BirthPromotion=@BirthPromotion,");
			strSql.Append("DeviceType=@DeviceType,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Status=@Status,");
			strSql.Append("CampaignID=@CampaignID,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("PromotionMsgTypeID=@PromotionMsgTypeID,");
			strSql.Append("PromotionMsgCode=@PromotionMsgCode,");
			strSql.Append("AttachmentFilePath=@AttachmentFilePath");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@PromotionTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@PromotionMsgStr1", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr2", SqlDbType.NVarChar),
					new SqlParameter("@PromotionMsgStr3", SqlDbType.NVarChar),
					new SqlParameter("@PromotionPicFile", SqlDbType.VarChar,512),
					new SqlParameter("@PromotionRemark", SqlDbType.NVarChar,2000),
					new SqlParameter("@PromptScheduleID", SqlDbType.Int,4),
					new SqlParameter("@BirthPromotion", SqlDbType.Int,4),
					new SqlParameter("@DeviceType", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CampaignID", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgTypeID", SqlDbType.Int,4),
					new SqlParameter("@PromotionMsgCode", SqlDbType.VarChar,64),
					new SqlParameter("@AttachmentFilePath", SqlDbType.NVarChar,512),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.PromotionTitle1;
			parameters[1].Value = model.PromotionTitle2;
			parameters[2].Value = model.PromotionTitle3;
			parameters[3].Value = model.PromotionMsgStr1;
			parameters[4].Value = model.PromotionMsgStr2;
			parameters[5].Value = model.PromotionMsgStr3;
			parameters[6].Value = model.PromotionPicFile;
			parameters[7].Value = model.PromotionRemark;
			parameters[8].Value = model.PromptScheduleID;
			parameters[9].Value = model.BirthPromotion;
			parameters[10].Value = model.DeviceType;
			parameters[11].Value = model.StartDate;
			parameters[12].Value = model.EndDate;
			parameters[13].Value = model.Status;
			parameters[14].Value = model.CampaignID;
			parameters[15].Value = model.CreatedOn;
			parameters[16].Value = model.CreatedBy;
			parameters[17].Value = model.UpdatedOn;
			parameters[18].Value = model.UpdatedBy;
			parameters[19].Value = model.PromotionMsgTypeID;
			parameters[20].Value = model.PromotionMsgCode;
			parameters[21].Value = model.AttachmentFilePath;
			parameters[22].Value = model.KeyID;

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
			strSql.Append("delete from PromotionMsg ");
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
			strSql.Append("delete from PromotionMsg ");
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
		public Edge.SVA.Model.PromotionMsg GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,PromotionTitle1,PromotionTitle2,PromotionTitle3,PromotionMsgStr1,PromotionMsgStr2,PromotionMsgStr3,PromotionPicFile,PromotionRemark,PromptScheduleID,BirthPromotion,DeviceType,StartDate,EndDate,Status,CampaignID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PromotionMsgTypeID,PromotionMsgCode,AttachmentFilePath from PromotionMsg ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.PromotionMsg model=new Edge.SVA.Model.PromotionMsg();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionTitle1"]!=null && ds.Tables[0].Rows[0]["PromotionTitle1"].ToString()!="")
				{
					model.PromotionTitle1=ds.Tables[0].Rows[0]["PromotionTitle1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionTitle2"]!=null && ds.Tables[0].Rows[0]["PromotionTitle2"].ToString()!="")
				{
					model.PromotionTitle2=ds.Tables[0].Rows[0]["PromotionTitle2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionTitle3"]!=null && ds.Tables[0].Rows[0]["PromotionTitle3"].ToString()!="")
				{
					model.PromotionTitle3=ds.Tables[0].Rows[0]["PromotionTitle3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionMsgStr1"]!=null && ds.Tables[0].Rows[0]["PromotionMsgStr1"].ToString()!="")
				{
					model.PromotionMsgStr1=ds.Tables[0].Rows[0]["PromotionMsgStr1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionMsgStr2"]!=null && ds.Tables[0].Rows[0]["PromotionMsgStr2"].ToString()!="")
				{
					model.PromotionMsgStr2=ds.Tables[0].Rows[0]["PromotionMsgStr2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionMsgStr3"]!=null && ds.Tables[0].Rows[0]["PromotionMsgStr3"].ToString()!="")
				{
					model.PromotionMsgStr3=ds.Tables[0].Rows[0]["PromotionMsgStr3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionPicFile"]!=null && ds.Tables[0].Rows[0]["PromotionPicFile"].ToString()!="")
				{
					model.PromotionPicFile=ds.Tables[0].Rows[0]["PromotionPicFile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromotionRemark"]!=null && ds.Tables[0].Rows[0]["PromotionRemark"].ToString()!="")
				{
					model.PromotionRemark=ds.Tables[0].Rows[0]["PromotionRemark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PromptScheduleID"]!=null && ds.Tables[0].Rows[0]["PromptScheduleID"].ToString()!="")
				{
					model.PromptScheduleID=int.Parse(ds.Tables[0].Rows[0]["PromptScheduleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BirthPromotion"]!=null && ds.Tables[0].Rows[0]["BirthPromotion"].ToString()!="")
				{
					model.BirthPromotion=int.Parse(ds.Tables[0].Rows[0]["BirthPromotion"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DeviceType"]!=null && ds.Tables[0].Rows[0]["DeviceType"].ToString()!="")
				{
					model.DeviceType=int.Parse(ds.Tables[0].Rows[0]["DeviceType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StartDate"]!=null && ds.Tables[0].Rows[0]["StartDate"].ToString()!="")
				{
					model.StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CampaignID"]!=null && ds.Tables[0].Rows[0]["CampaignID"].ToString()!="")
				{
					model.CampaignID=int.Parse(ds.Tables[0].Rows[0]["CampaignID"].ToString());
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
				if(ds.Tables[0].Rows[0]["PromotionMsgTypeID"]!=null && ds.Tables[0].Rows[0]["PromotionMsgTypeID"].ToString()!="")
				{
					model.PromotionMsgTypeID=int.Parse(ds.Tables[0].Rows[0]["PromotionMsgTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PromotionMsgCode"]!=null && ds.Tables[0].Rows[0]["PromotionMsgCode"].ToString()!="")
				{
					model.PromotionMsgCode=ds.Tables[0].Rows[0]["PromotionMsgCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AttachmentFilePath"]!=null && ds.Tables[0].Rows[0]["AttachmentFilePath"].ToString()!="")
				{
					model.AttachmentFilePath=ds.Tables[0].Rows[0]["AttachmentFilePath"].ToString();
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
			strSql.Append("select KeyID,PromotionTitle1,PromotionTitle2,PromotionTitle3,PromotionMsgStr1,PromotionMsgStr2,PromotionMsgStr3,PromotionPicFile,PromotionRemark,PromptScheduleID,BirthPromotion,DeviceType,StartDate,EndDate,Status,CampaignID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PromotionMsgTypeID,PromotionMsgCode,AttachmentFilePath ");
			strSql.Append(" FROM PromotionMsg ");
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
			strSql.Append(" KeyID,PromotionTitle1,PromotionTitle2,PromotionTitle3,PromotionMsgStr1,PromotionMsgStr2,PromotionMsgStr3,PromotionPicFile,PromotionRemark,PromptScheduleID,BirthPromotion,DeviceType,StartDate,EndDate,Status,CampaignID,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,PromotionMsgTypeID,PromotionMsgCode,AttachmentFilePath ");
			strSql.Append(" FROM PromotionMsg ");
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
			strSql.Append("select count(1) FROM PromotionMsg ");
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
                strSql.Append("order by T.PromotionMsgCode desc");//按Code倒序排列(Len)---Candy需求
			}
			strSql.Append(")AS Row, T.*  from PromotionMsg T ");
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
			parameters[0].Value = "PromotionMsg";
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

