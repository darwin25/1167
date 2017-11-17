using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:SVA_ValueAdjust_D
	/// </summary>
	public partial class SVA_ValueAdjust_D:ISVA_ValueAdjust_D
	{
		public SVA_ValueAdjust_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SeqNo", "SVA_ValueAdjust_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Number,int SeqNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SVA_ValueAdjust_D");
			strSql.Append(" where Number=@Number and SeqNo=@SeqNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4)};
			parameters[0].Value = Number;
			parameters[1].Value = SeqNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.SVA_ValueAdjust_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SVA_ValueAdjust_D(");
			strSql.Append("Number,SeqNo,UID,CardNo,CardTypeID,CardGradID,OrderAmount,ActAmount,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Number,@SeqNo,@UID,@CardNo,@CardTypeID,@CardGradID,@OrderAmount,@ActAmount,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.VarChar,60),
					new SqlParameter("@CardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@CardTypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@CardGradID", SqlDbType.NVarChar,10),
					new SqlParameter("@OrderAmount", SqlDbType.Money,8),
					new SqlParameter("@ActAmount", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
			parameters[0].Value = model.Number;
			parameters[1].Value = model.SeqNo;
			parameters[2].Value = model.UID;
			parameters[3].Value = model.CardNo;
			parameters[4].Value = model.CardTypeID;
			parameters[5].Value = model.CardGradID;
			parameters[6].Value = model.OrderAmount;
			parameters[7].Value = model.ActAmount;
			parameters[8].Value = model.Remark;

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
		public bool Update(Edge.SVA.Model.SVA_ValueAdjust_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SVA_ValueAdjust_D set ");
			strSql.Append("UID=@UID,");
			strSql.Append("CardNo=@CardNo,");
			strSql.Append("CardTypeID=@CardTypeID,");
			strSql.Append("CardGradID=@CardGradID,");
			strSql.Append("OrderAmount=@OrderAmount,");
			strSql.Append("ActAmount=@ActAmount,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Number=@Number and SeqNo=@SeqNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.VarChar,60),
					new SqlParameter("@CardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@CardTypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@CardGradID", SqlDbType.NVarChar,10),
					new SqlParameter("@OrderAmount", SqlDbType.Money,8),
					new SqlParameter("@ActAmount", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4)};
			parameters[0].Value = model.UID;
			parameters[1].Value = model.CardNo;
			parameters[2].Value = model.CardTypeID;
			parameters[3].Value = model.CardGradID;
			parameters[4].Value = model.OrderAmount;
			parameters[5].Value = model.ActAmount;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Number;
			parameters[8].Value = model.SeqNo;

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
		public bool Delete(string Number,int SeqNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SVA_ValueAdjust_D ");
			strSql.Append(" where Number=@Number and SeqNo=@SeqNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4)};
			parameters[0].Value = Number;
			parameters[1].Value = SeqNo;

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
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.SVA_ValueAdjust_D GetModel(string Number,int SeqNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Number,SeqNo,UID,CardNo,CardTypeID,CardGradID,OrderAmount,ActAmount,Remark from SVA_ValueAdjust_D ");
			strSql.Append(" where Number=@Number and SeqNo=@SeqNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4)};
			parameters[0].Value = Number;
			parameters[1].Value = SeqNo;

			Edge.SVA.Model.SVA_ValueAdjust_D model=new Edge.SVA.Model.SVA_ValueAdjust_D();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Number"]!=null && ds.Tables[0].Rows[0]["Number"].ToString()!="")
				{
					model.Number=ds.Tables[0].Rows[0]["Number"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SeqNo"]!=null && ds.Tables[0].Rows[0]["SeqNo"].ToString()!="")
				{
					model.SeqNo=int.Parse(ds.Tables[0].Rows[0]["SeqNo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UID"]!=null && ds.Tables[0].Rows[0]["UID"].ToString()!="")
				{
					model.UID=ds.Tables[0].Rows[0]["UID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardNo"]!=null && ds.Tables[0].Rows[0]["CardNo"].ToString()!="")
				{
					model.CardNo=ds.Tables[0].Rows[0]["CardNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardTypeID"]!=null && ds.Tables[0].Rows[0]["CardTypeID"].ToString()!="")
				{
					model.CardTypeID=ds.Tables[0].Rows[0]["CardTypeID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CardGradID"]!=null && ds.Tables[0].Rows[0]["CardGradID"].ToString()!="")
				{
					model.CardGradID=ds.Tables[0].Rows[0]["CardGradID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrderAmount"]!=null && ds.Tables[0].Rows[0]["OrderAmount"].ToString()!="")
				{
					model.OrderAmount=decimal.Parse(ds.Tables[0].Rows[0]["OrderAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ActAmount"]!=null && ds.Tables[0].Rows[0]["ActAmount"].ToString()!="")
				{
					model.ActAmount=decimal.Parse(ds.Tables[0].Rows[0]["ActAmount"].ToString());
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
			strSql.Append("select Number,SeqNo,UID,CardNo,CardTypeID,CardGradID,OrderAmount,ActAmount,Remark ");
			strSql.Append(" FROM SVA_ValueAdjust_D ");
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
			strSql.Append(" Number,SeqNo,UID,CardNo,CardTypeID,CardGradID,OrderAmount,ActAmount,Remark ");
			strSql.Append(" FROM SVA_ValueAdjust_D ");
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
			parameters[0].Value = "SVA_ValueAdjust_D";
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
            sql.Append("select count(*) from SVA_ValueAdjust_D ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

