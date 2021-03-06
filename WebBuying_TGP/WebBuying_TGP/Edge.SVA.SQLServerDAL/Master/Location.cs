﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Location
	/// </summary>
	public partial class Location:ILocation
	{
		public Location()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LocationID", "Location"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LocationID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Location");
			strSql.Append(" where LocationID=@LocationID");
			SqlParameter[] parameters = {
					new SqlParameter("@LocationID", SqlDbType.Int,4)
};
			parameters[0].Value = LocationID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.Location model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Location(");
			strSql.Append("ParentLoactionID,LocationName1,LocationName2,LocationName3,LocationType,Lotitude,Longitude,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LocationFullPath)");
			strSql.Append(" values (");
			strSql.Append("@ParentLoactionID,@LocationName1,@LocationName2,@LocationName3,@LocationType,@Lotitude,@Longitude,@Status,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy,@LocationFullPath)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentLoactionID", SqlDbType.Int,4),
					new SqlParameter("@LocationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationType", SqlDbType.Int,4),
					new SqlParameter("@Lotitude", SqlDbType.VarChar,512),
					new SqlParameter("@Longitude", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@LocationFullPath", SqlDbType.VarChar,512)};
			parameters[0].Value = model.ParentLoactionID;
			parameters[1].Value = model.LocationName1;
			parameters[2].Value = model.LocationName2;
			parameters[3].Value = model.LocationName3;
			parameters[4].Value = model.LocationType;
			parameters[5].Value = model.Lotitude;
			parameters[6].Value = model.Longitude;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.CreatedOn;
			parameters[9].Value = model.CreatedBy;
			parameters[10].Value = model.UpdatedOn;
			parameters[11].Value = model.UpdatedBy;
			parameters[12].Value = model.LocationFullPath;

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
		public bool Update(Edge.SVA.Model.Location model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Location set ");
			strSql.Append("ParentLoactionID=@ParentLoactionID,");
			strSql.Append("LocationName1=@LocationName1,");
			strSql.Append("LocationName2=@LocationName2,");
			strSql.Append("LocationName3=@LocationName3,");
			strSql.Append("LocationType=@LocationType,");
			strSql.Append("Lotitude=@Lotitude,");
			strSql.Append("Longitude=@Longitude,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy,");
			strSql.Append("LocationFullPath=@LocationFullPath");
			strSql.Append(" where LocationID=@LocationID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentLoactionID", SqlDbType.Int,4),
					new SqlParameter("@LocationName1", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationName2", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationName3", SqlDbType.NVarChar,512),
					new SqlParameter("@LocationType", SqlDbType.Int,4),
					new SqlParameter("@Lotitude", SqlDbType.VarChar,512),
					new SqlParameter("@Longitude", SqlDbType.VarChar,512),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@LocationFullPath", SqlDbType.VarChar,512),
					new SqlParameter("@LocationID", SqlDbType.Int,4)};
			parameters[0].Value = model.ParentLoactionID;
			parameters[1].Value = model.LocationName1;
			parameters[2].Value = model.LocationName2;
			parameters[3].Value = model.LocationName3;
			parameters[4].Value = model.LocationType;
			parameters[5].Value = model.Lotitude;
			parameters[6].Value = model.Longitude;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.CreatedOn;
			parameters[9].Value = model.CreatedBy;
			parameters[10].Value = model.UpdatedOn;
			parameters[11].Value = model.UpdatedBy;
			parameters[12].Value = model.LocationFullPath;
			parameters[13].Value = model.LocationID;

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
		public bool Delete(int LocationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Location ");
			strSql.Append(" where LocationID=@LocationID");
			SqlParameter[] parameters = {
					new SqlParameter("@LocationID", SqlDbType.Int,4)
};
			parameters[0].Value = LocationID;

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
		public bool DeleteList(string LocationIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Location ");
			strSql.Append(" where LocationID in ("+LocationIDlist + ")  ");
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
		public Edge.SVA.Model.Location GetModel(int LocationID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LocationID,ParentLoactionID,LocationName1,LocationName2,LocationName3,LocationType,Lotitude,Longitude,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LocationFullPath from Location ");
			strSql.Append(" where LocationID=@LocationID");
			SqlParameter[] parameters = {
					new SqlParameter("@LocationID", SqlDbType.Int,4)
};
			parameters[0].Value = LocationID;

			Edge.SVA.Model.Location model=new Edge.SVA.Model.Location();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["LocationID"]!=null && ds.Tables[0].Rows[0]["LocationID"].ToString()!="")
				{
					model.LocationID=int.Parse(ds.Tables[0].Rows[0]["LocationID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentLoactionID"]!=null && ds.Tables[0].Rows[0]["ParentLoactionID"].ToString()!="")
				{
					model.ParentLoactionID=int.Parse(ds.Tables[0].Rows[0]["ParentLoactionID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LocationName1"]!=null && ds.Tables[0].Rows[0]["LocationName1"].ToString()!="")
				{
					model.LocationName1=ds.Tables[0].Rows[0]["LocationName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LocationName2"]!=null && ds.Tables[0].Rows[0]["LocationName2"].ToString()!="")
				{
					model.LocationName2=ds.Tables[0].Rows[0]["LocationName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LocationName3"]!=null && ds.Tables[0].Rows[0]["LocationName3"].ToString()!="")
				{
					model.LocationName3=ds.Tables[0].Rows[0]["LocationName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LocationType"]!=null && ds.Tables[0].Rows[0]["LocationType"].ToString()!="")
				{
					model.LocationType=int.Parse(ds.Tables[0].Rows[0]["LocationType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Lotitude"]!=null && ds.Tables[0].Rows[0]["Lotitude"].ToString()!="")
				{
					model.Lotitude=ds.Tables[0].Rows[0]["Lotitude"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Longitude"]!=null && ds.Tables[0].Rows[0]["Longitude"].ToString()!="")
				{
					model.Longitude=ds.Tables[0].Rows[0]["Longitude"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
				if(ds.Tables[0].Rows[0]["LocationFullPath"]!=null && ds.Tables[0].Rows[0]["LocationFullPath"].ToString()!="")
				{
					model.LocationFullPath=ds.Tables[0].Rows[0]["LocationFullPath"].ToString();
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
			strSql.Append("select LocationID,ParentLoactionID,LocationName1,LocationName2,LocationName3,LocationType,Lotitude,Longitude,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LocationFullPath ");
			strSql.Append(" FROM Location ");
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
			strSql.Append(" LocationID,ParentLoactionID,LocationName1,LocationName2,LocationName3,LocationType,Lotitude,Longitude,Status,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,LocationFullPath ");
			strSql.Append(" FROM Location ");
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
            parameters[0].Value = "Location";
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
            sql.Append("select count(*) from Location ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

