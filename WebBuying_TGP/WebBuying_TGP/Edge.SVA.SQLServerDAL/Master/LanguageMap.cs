﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:LanguageMap
	/// </summary>
	public partial class LanguageMap:ILanguageMap
	{
		public LanguageMap()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "LanguageMap"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LanguageMap");
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
		public int Add(Edge.SVA.Model.LanguageMap model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LanguageMap(");
			strSql.Append("LanguageAbbr,DescFieldNo,LanguageDesc)");
			strSql.Append(" values (");
			strSql.Append("@LanguageAbbr,@DescFieldNo,@LanguageDesc)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LanguageAbbr", SqlDbType.VarChar,512),
					new SqlParameter("@DescFieldNo", SqlDbType.Int,4),
					new SqlParameter("@LanguageDesc", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.LanguageAbbr;
			parameters[1].Value = model.DescFieldNo;
			parameters[2].Value = model.LanguageDesc;

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
		public bool Update(Edge.SVA.Model.LanguageMap model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LanguageMap set ");
			strSql.Append("LanguageAbbr=@LanguageAbbr,");
			strSql.Append("DescFieldNo=@DescFieldNo,");
			strSql.Append("LanguageDesc=@LanguageDesc");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@LanguageAbbr", SqlDbType.VarChar,512),
					new SqlParameter("@DescFieldNo", SqlDbType.Int,4),
					new SqlParameter("@LanguageDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.LanguageAbbr;
			parameters[1].Value = model.DescFieldNo;
			parameters[2].Value = model.LanguageDesc;
			parameters[3].Value = model.KeyID;

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
			strSql.Append("delete from LanguageMap ");
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
			strSql.Append("delete from LanguageMap ");
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
		public Edge.SVA.Model.LanguageMap GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,LanguageAbbr,DescFieldNo,LanguageDesc from LanguageMap ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.LanguageMap model=new Edge.SVA.Model.LanguageMap();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LanguageAbbr"]!=null && ds.Tables[0].Rows[0]["LanguageAbbr"].ToString()!="")
				{
					model.LanguageAbbr=ds.Tables[0].Rows[0]["LanguageAbbr"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DescFieldNo"]!=null && ds.Tables[0].Rows[0]["DescFieldNo"].ToString()!="")
				{
					model.DescFieldNo=int.Parse(ds.Tables[0].Rows[0]["DescFieldNo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LanguageDesc"]!=null && ds.Tables[0].Rows[0]["LanguageDesc"].ToString()!="")
				{
					model.LanguageDesc=ds.Tables[0].Rows[0]["LanguageDesc"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 根据语言名称查询
        /// 创建者：Lisa
        /// 创建时间：2016-02-29
        /// </summary>
        /// <param name="LanguageDesc"></param>
        /// <returns></returns>
        public Edge.SVA.Model.LanguageMap GetEntityByLanguageDesc(string LanguageDesc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 KeyID,LanguageAbbr,DescFieldNo,LanguageDesc from LanguageMap ");
            strSql.Append(" where LanguageDesc=@LanguageDesc");
            SqlParameter[] parameters = {
					new SqlParameter("@LanguageDesc", SqlDbType.NVarChar,512)
};
            parameters[0].Value = LanguageDesc;

            Edge.SVA.Model.LanguageMap model = new Edge.SVA.Model.LanguageMap();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["KeyID"] != null && ds.Tables[0].Rows[0]["KeyID"].ToString() != "")
                {
                    model.KeyID = int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LanguageAbbr"] != null && ds.Tables[0].Rows[0]["LanguageAbbr"].ToString() != "")
                {
                    model.LanguageAbbr = ds.Tables[0].Rows[0]["LanguageAbbr"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DescFieldNo"] != null && ds.Tables[0].Rows[0]["DescFieldNo"].ToString() != "")
                {
                    model.DescFieldNo = int.Parse(ds.Tables[0].Rows[0]["DescFieldNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LanguageDesc"] != null && ds.Tables[0].Rows[0]["LanguageDesc"].ToString() != "")
                {
                    model.LanguageDesc = ds.Tables[0].Rows[0]["LanguageDesc"].ToString();
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
			strSql.Append("select KeyID,LanguageAbbr,DescFieldNo,LanguageDesc ");
			strSql.Append(" FROM LanguageMap ");
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
			strSql.Append(" KeyID,LanguageAbbr,DescFieldNo,LanguageDesc ");
			strSql.Append(" FROM LanguageMap ");
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
			parameters[0].Value = "LanguageMap";
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
            sql.Append("select count(*) from LanguageMap ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

