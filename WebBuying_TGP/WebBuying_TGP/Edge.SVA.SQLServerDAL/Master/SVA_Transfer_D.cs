using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:SVA_Transfer_D
	/// </summary>
	public partial class SVA_Transfer_D:ISVA_Transfer_D
	{
		public SVA_Transfer_D()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SeqNo", "SVA_Transfer_D"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Number,int SeqNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SVA_Transfer_D");
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
		public bool Add(Edge.SVA.Model.SVA_Transfer_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SVA_Transfer_D(");
			strSql.Append("Number,SeqNo,OutUID,OutCardNo,OutCardTypeID,OutCardGradID,InUID,InCardNo,InCardTypeID,InCardGradID,OutAmount,InAmount,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Number,@SeqNo,@OutUID,@OutCardNo,@OutCardTypeID,@OutCardGradID,@InUID,@InCardNo,@InCardTypeID,@InCardGradID,@OutAmount,@InAmount,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4),
					new SqlParameter("@OutUID", SqlDbType.VarChar,60),
					new SqlParameter("@OutCardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@OutCardTypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@OutCardGradID", SqlDbType.NVarChar,10),
					new SqlParameter("@InUID", SqlDbType.VarChar,60),
					new SqlParameter("@InCardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@InCardTypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@InCardGradID", SqlDbType.NVarChar,10),
					new SqlParameter("@OutAmount", SqlDbType.Money,8),
					new SqlParameter("@InAmount", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
			parameters[0].Value = model.Number;
			parameters[1].Value = model.SeqNo;
			parameters[2].Value = model.OutUID;
			parameters[3].Value = model.OutCardNo;
			parameters[4].Value = model.OutCardTypeID;
			parameters[5].Value = model.OutCardGradID;
			parameters[6].Value = model.InUID;
			parameters[7].Value = model.InCardNo;
			parameters[8].Value = model.InCardTypeID;
			parameters[9].Value = model.InCardGradID;
			parameters[10].Value = model.OutAmount;
			parameters[11].Value = model.InAmount;
			parameters[12].Value = model.Remark;

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
		public bool Update(Edge.SVA.Model.SVA_Transfer_D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SVA_Transfer_D set ");
			strSql.Append("OutUID=@OutUID,");
			strSql.Append("OutCardNo=@OutCardNo,");
			strSql.Append("OutCardTypeID=@OutCardTypeID,");
			strSql.Append("OutCardGradID=@OutCardGradID,");
			strSql.Append("InUID=@InUID,");
			strSql.Append("InCardNo=@InCardNo,");
			strSql.Append("InCardTypeID=@InCardTypeID,");
			strSql.Append("InCardGradID=@InCardGradID,");
			strSql.Append("OutAmount=@OutAmount,");
			strSql.Append("InAmount=@InAmount,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where Number=@Number and SeqNo=@SeqNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@OutUID", SqlDbType.VarChar,60),
					new SqlParameter("@OutCardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@OutCardTypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@OutCardGradID", SqlDbType.NVarChar,10),
					new SqlParameter("@InUID", SqlDbType.VarChar,60),
					new SqlParameter("@InCardNo", SqlDbType.NVarChar,30),
					new SqlParameter("@InCardTypeID", SqlDbType.NVarChar,20),
					new SqlParameter("@InCardGradID", SqlDbType.NVarChar,10),
					new SqlParameter("@OutAmount", SqlDbType.Money,8),
					new SqlParameter("@InAmount", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.VarChar,100),
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4)};
			parameters[0].Value = model.OutUID;
			parameters[1].Value = model.OutCardNo;
			parameters[2].Value = model.OutCardTypeID;
			parameters[3].Value = model.OutCardGradID;
			parameters[4].Value = model.InUID;
			parameters[5].Value = model.InCardNo;
			parameters[6].Value = model.InCardTypeID;
			parameters[7].Value = model.InCardGradID;
			parameters[8].Value = model.OutAmount;
			parameters[9].Value = model.InAmount;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.Number;
			parameters[12].Value = model.SeqNo;

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
			strSql.Append("delete from SVA_Transfer_D ");
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
		public Edge.SVA.Model.SVA_Transfer_D GetModel(string Number,int SeqNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Number,SeqNo,OutUID,OutCardNo,OutCardTypeID,OutCardGradID,InUID,InCardNo,InCardTypeID,InCardGradID,OutAmount,InAmount,Remark from SVA_Transfer_D ");
			strSql.Append(" where Number=@Number and SeqNo=@SeqNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.VarChar,20),
					new SqlParameter("@SeqNo", SqlDbType.Int,4)};
			parameters[0].Value = Number;
			parameters[1].Value = SeqNo;

			Edge.SVA.Model.SVA_Transfer_D model=new Edge.SVA.Model.SVA_Transfer_D();
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
				if(ds.Tables[0].Rows[0]["OutUID"]!=null && ds.Tables[0].Rows[0]["OutUID"].ToString()!="")
				{
					model.OutUID=ds.Tables[0].Rows[0]["OutUID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OutCardNo"]!=null && ds.Tables[0].Rows[0]["OutCardNo"].ToString()!="")
				{
					model.OutCardNo=ds.Tables[0].Rows[0]["OutCardNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OutCardTypeID"]!=null && ds.Tables[0].Rows[0]["OutCardTypeID"].ToString()!="")
				{
					model.OutCardTypeID=ds.Tables[0].Rows[0]["OutCardTypeID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OutCardGradID"]!=null && ds.Tables[0].Rows[0]["OutCardGradID"].ToString()!="")
				{
					model.OutCardGradID=ds.Tables[0].Rows[0]["OutCardGradID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InUID"]!=null && ds.Tables[0].Rows[0]["InUID"].ToString()!="")
				{
					model.InUID=ds.Tables[0].Rows[0]["InUID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InCardNo"]!=null && ds.Tables[0].Rows[0]["InCardNo"].ToString()!="")
				{
					model.InCardNo=ds.Tables[0].Rows[0]["InCardNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InCardTypeID"]!=null && ds.Tables[0].Rows[0]["InCardTypeID"].ToString()!="")
				{
					model.InCardTypeID=ds.Tables[0].Rows[0]["InCardTypeID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InCardGradID"]!=null && ds.Tables[0].Rows[0]["InCardGradID"].ToString()!="")
				{
					model.InCardGradID=ds.Tables[0].Rows[0]["InCardGradID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OutAmount"]!=null && ds.Tables[0].Rows[0]["OutAmount"].ToString()!="")
				{
					model.OutAmount=decimal.Parse(ds.Tables[0].Rows[0]["OutAmount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InAmount"]!=null && ds.Tables[0].Rows[0]["InAmount"].ToString()!="")
				{
					model.InAmount=decimal.Parse(ds.Tables[0].Rows[0]["InAmount"].ToString());
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
			strSql.Append("select Number,SeqNo,OutUID,OutCardNo,OutCardTypeID,OutCardGradID,InUID,InCardNo,InCardTypeID,InCardGradID,OutAmount,InAmount,Remark ");
			strSql.Append(" FROM SVA_Transfer_D ");
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
			strSql.Append(" Number,SeqNo,OutUID,OutCardNo,OutCardTypeID,OutCardGradID,InUID,InCardNo,InCardTypeID,InCardGradID,OutAmount,InAmount,Remark ");
			strSql.Append(" FROM SVA_Transfer_D ");
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
			parameters[0].Value = "SVA_Transfer_D";
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
            sql.Append("select count(*) from SVA_Transfer_D ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sql.AppendFormat("where {0}", strWhere);
            }

            return DbHelperSQL.GetCount(sql.ToString());
        }
		#endregion  Method
	}
}

