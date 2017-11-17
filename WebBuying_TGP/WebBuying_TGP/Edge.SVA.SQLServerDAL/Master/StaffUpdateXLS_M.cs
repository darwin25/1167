using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:StaffUpdateXLS_M
	/// </summary>
	public partial class StaffUpdateXLS_M:IStaffUpdateXLS_M
	{
		public StaffUpdateXLS_M()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "StaffUpdateXLS_M"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StaffUpdateXLS_M");
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
		public int Add(Edge.SVA.Model.StaffUpdateXLS_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StaffUpdateXLS_M(");
			strSql.Append("Operation,ExcelFileName,SheetName,ActionResult,ResultRemark,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@Operation,@ExcelFileName,@SheetName,@ActionResult,@ResultRemark,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Operation", SqlDbType.Int,4),
					new SqlParameter("@ExcelFileName", SqlDbType.NVarChar,300),
					new SqlParameter("@SheetName", SqlDbType.VarChar,20),
					new SqlParameter("@ActionResult", SqlDbType.Int,4),
					new SqlParameter("@ResultRemark", SqlDbType.NVarChar,400),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10)};
			parameters[0].Value = model.Operation;
			parameters[1].Value = model.ExcelFileName;
			parameters[2].Value = model.SheetName;
			parameters[3].Value = model.ActionResult;
			parameters[4].Value = model.ResultRemark;
			parameters[5].Value = model.CreatedDate;
			parameters[6].Value = model.UpdatedDate;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.StaffUpdateXLS_M model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StaffUpdateXLS_M set ");
			strSql.Append("Operation=@Operation,");
			strSql.Append("ExcelFileName=@ExcelFileName,");
			strSql.Append("SheetName=@SheetName,");
			strSql.Append("ActionResult=@ActionResult,");
			strSql.Append("ResultRemark=@ResultRemark,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("UpdatedDate=@UpdatedDate,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@Operation", SqlDbType.Int,4),
					new SqlParameter("@ExcelFileName", SqlDbType.NVarChar,300),
					new SqlParameter("@SheetName", SqlDbType.VarChar,20),
					new SqlParameter("@ActionResult", SqlDbType.Int,4),
					new SqlParameter("@ResultRemark", SqlDbType.NVarChar,400),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@UpdatedBy", SqlDbType.VarChar,10),
					new SqlParameter("@KeyID", SqlDbType.Int,4)};
			parameters[0].Value = model.Operation;
			parameters[1].Value = model.ExcelFileName;
			parameters[2].Value = model.SheetName;
			parameters[3].Value = model.ActionResult;
			parameters[4].Value = model.ResultRemark;
			parameters[5].Value = model.CreatedDate;
			parameters[6].Value = model.UpdatedDate;
			parameters[7].Value = model.CreatedBy;
			parameters[8].Value = model.UpdatedBy;
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
			strSql.Append("delete from StaffUpdateXLS_M ");
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
			strSql.Append("delete from StaffUpdateXLS_M ");
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
		public Edge.SVA.Model.StaffUpdateXLS_M GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 KeyID,Operation,ExcelFileName,SheetName,ActionResult,ResultRemark,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy from StaffUpdateXLS_M ");
			strSql.Append(" where KeyID=@KeyID");
			SqlParameter[] parameters = {
					new SqlParameter("@KeyID", SqlDbType.Int,4)
};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.StaffUpdateXLS_M model=new Edge.SVA.Model.StaffUpdateXLS_M();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["KeyID"]!=null && ds.Tables[0].Rows[0]["KeyID"].ToString()!="")
				{
					model.KeyID=int.Parse(ds.Tables[0].Rows[0]["KeyID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Operation"]!=null && ds.Tables[0].Rows[0]["Operation"].ToString()!="")
				{
					model.Operation=int.Parse(ds.Tables[0].Rows[0]["Operation"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ExcelFileName"]!=null && ds.Tables[0].Rows[0]["ExcelFileName"].ToString()!="")
				{
					model.ExcelFileName=ds.Tables[0].Rows[0]["ExcelFileName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SheetName"]!=null && ds.Tables[0].Rows[0]["SheetName"].ToString()!="")
				{
					model.SheetName=ds.Tables[0].Rows[0]["SheetName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ActionResult"]!=null && ds.Tables[0].Rows[0]["ActionResult"].ToString()!="")
				{
					model.ActionResult=int.Parse(ds.Tables[0].Rows[0]["ActionResult"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ResultRemark"]!=null && ds.Tables[0].Rows[0]["ResultRemark"].ToString()!="")
				{
					model.ResultRemark=ds.Tables[0].Rows[0]["ResultRemark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedDate"]!=null && ds.Tables[0].Rows[0]["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedDate"]!=null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedBy"]!=null && ds.Tables[0].Rows[0]["CreatedBy"].ToString()!="")
				{
					model.CreatedBy=ds.Tables[0].Rows[0]["CreatedBy"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdatedBy"]!=null && ds.Tables[0].Rows[0]["UpdatedBy"].ToString()!="")
				{
					model.UpdatedBy=ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
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
			strSql.Append("select KeyID,Operation,ExcelFileName,SheetName,ActionResult,ResultRemark,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy ");
			strSql.Append(" FROM StaffUpdateXLS_M ");
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
			strSql.Append(" KeyID,Operation,ExcelFileName,SheetName,ActionResult,ResultRemark,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy ");
			strSql.Append(" FROM StaffUpdateXLS_M ");
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
			parameters[0].Value = "StaffUpdateXLS_M";
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
            sql.Append("select count(*) from StaffUpdateXLS_M ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

