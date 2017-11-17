using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_RPRICETYPE
	/// </summary>
	public partial class BUY_RPRICETYPE:IBUY_RPRICETYPE
	{
		public BUY_RPRICETYPE()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RPriceTypeID", "BUY_RPRICETYPE"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string RPriceTypeCode,int RPriceTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_RPRICETYPE");
			strSql.Append(" where RPriceTypeCode=@RPriceTypeCode and RPriceTypeID=@RPriceTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@RPriceTypeID", SqlDbType.Int,4)			};
			parameters[0].Value = RPriceTypeCode;
			parameters[1].Value = RPriceTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_RPRICETYPE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_RPRICETYPE(");
			strSql.Append("RPriceTypeCode,RPriceTypeName1,RPriceTypeName2,RPriceTypeName3,AdditionalType,Supervisor,SerialNo,Discount,TypeLevel,MemberShip,StockTypeCode,RANOnly,DAMOnly,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@RPriceTypeCode,@RPriceTypeName1,@RPriceTypeName2,@RPriceTypeName3,@AdditionalType,@Supervisor,@SerialNo,@Discount,@TypeLevel,@MemberShip,@StockTypeCode,@RANOnly,@DAMOnly,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@RPriceTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@RPriceTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@RPriceTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@AdditionalType", SqlDbType.Int,4),
					new SqlParameter("@Supervisor", SqlDbType.Int,4),
					new SqlParameter("@SerialNo", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Int,4),
					new SqlParameter("@TypeLevel", SqlDbType.Int,4),
					new SqlParameter("@MemberShip", SqlDbType.Int,4),
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@RANOnly", SqlDbType.Int,4),
					new SqlParameter("@DAMOnly", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.RPriceTypeCode;
			parameters[1].Value = model.RPriceTypeName1;
			parameters[2].Value = model.RPriceTypeName2;
			parameters[3].Value = model.RPriceTypeName3;
			parameters[4].Value = model.AdditionalType;
			parameters[5].Value = model.Supervisor;
			parameters[6].Value = model.SerialNo;
			parameters[7].Value = model.Discount;
			parameters[8].Value = model.TypeLevel;
			parameters[9].Value = model.MemberShip;
			parameters[10].Value = model.StockTypeCode;
			parameters[11].Value = model.RANOnly;
			parameters[12].Value = model.DAMOnly;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_RPRICETYPE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_RPRICETYPE set ");
			strSql.Append("RPriceTypeName1=@RPriceTypeName1,");
			strSql.Append("RPriceTypeName2=@RPriceTypeName2,");
			strSql.Append("RPriceTypeName3=@RPriceTypeName3,");
			strSql.Append("AdditionalType=@AdditionalType,");
			strSql.Append("Supervisor=@Supervisor,");
			strSql.Append("SerialNo=@SerialNo,");
			strSql.Append("Discount=@Discount,");
			strSql.Append("TypeLevel=@TypeLevel,");
			strSql.Append("MemberShip=@MemberShip,");
			strSql.Append("StockTypeCode=@StockTypeCode,");
			strSql.Append("RANOnly=@RANOnly,");
			strSql.Append("DAMOnly=@DAMOnly,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
			strSql.Append(" where RPriceTypeID=@RPriceTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceTypeName1", SqlDbType.NVarChar,512),
					new SqlParameter("@RPriceTypeName2", SqlDbType.NVarChar,512),
					new SqlParameter("@RPriceTypeName3", SqlDbType.NVarChar,512),
					new SqlParameter("@AdditionalType", SqlDbType.Int,4),
					new SqlParameter("@Supervisor", SqlDbType.Int,4),
					new SqlParameter("@SerialNo", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Int,4),
					new SqlParameter("@TypeLevel", SqlDbType.Int,4),
					new SqlParameter("@MemberShip", SqlDbType.Int,4),
					new SqlParameter("@StockTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@RANOnly", SqlDbType.Int,4),
					new SqlParameter("@DAMOnly", SqlDbType.Int,4),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@RPriceTypeID", SqlDbType.Int,4),
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.RPriceTypeName1;
			parameters[1].Value = model.RPriceTypeName2;
			parameters[2].Value = model.RPriceTypeName3;
			parameters[3].Value = model.AdditionalType;
			parameters[4].Value = model.Supervisor;
			parameters[5].Value = model.SerialNo;
			parameters[6].Value = model.Discount;
			parameters[7].Value = model.TypeLevel;
			parameters[8].Value = model.MemberShip;
			parameters[9].Value = model.StockTypeCode;
			parameters[10].Value = model.RANOnly;
			parameters[11].Value = model.DAMOnly;
			parameters[12].Value = model.CreatedOn;
			parameters[13].Value = model.CreatedBy;
			parameters[14].Value = model.UpdatedOn;
			parameters[15].Value = model.UpdatedBy;
			parameters[16].Value = model.RPriceTypeID;
			parameters[17].Value = model.RPriceTypeCode;

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
		public bool Delete(int RPriceTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_RPRICETYPE ");
			strSql.Append(" where RPriceTypeID=@RPriceTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = RPriceTypeID;

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
		public bool Delete(string RPriceTypeCode,int RPriceTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_RPRICETYPE ");
			strSql.Append(" where RPriceTypeCode=@RPriceTypeCode and RPriceTypeID=@RPriceTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceTypeCode", SqlDbType.VarChar,64),
					new SqlParameter("@RPriceTypeID", SqlDbType.Int,4)			};
			parameters[0].Value = RPriceTypeCode;
			parameters[1].Value = RPriceTypeID;

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
		public bool DeleteList(string RPriceTypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_RPRICETYPE ");
			strSql.Append(" where RPriceTypeID in ("+RPriceTypeIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_RPRICETYPE GetModel(int RPriceTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RPriceTypeID,RPriceTypeCode,RPriceTypeName1,RPriceTypeName2,RPriceTypeName3,AdditionalType,Supervisor,SerialNo,Discount,TypeLevel,MemberShip,StockTypeCode,RANOnly,DAMOnly,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_RPRICETYPE ");
			strSql.Append(" where RPriceTypeID=@RPriceTypeID");
			SqlParameter[] parameters = {
					new SqlParameter("@RPriceTypeID", SqlDbType.Int,4)
			};
			parameters[0].Value = RPriceTypeID;

			Edge.SVA.Model.BUY_RPRICETYPE model=new Edge.SVA.Model.BUY_RPRICETYPE();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RPriceTypeID"]!=null && ds.Tables[0].Rows[0]["RPriceTypeID"].ToString()!="")
				{
					model.RPriceTypeID=int.Parse(ds.Tables[0].Rows[0]["RPriceTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RPriceTypeCode"]!=null && ds.Tables[0].Rows[0]["RPriceTypeCode"].ToString()!="")
				{
					model.RPriceTypeCode=ds.Tables[0].Rows[0]["RPriceTypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RPriceTypeName1"]!=null && ds.Tables[0].Rows[0]["RPriceTypeName1"].ToString()!="")
				{
					model.RPriceTypeName1=ds.Tables[0].Rows[0]["RPriceTypeName1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RPriceTypeName2"]!=null && ds.Tables[0].Rows[0]["RPriceTypeName2"].ToString()!="")
				{
					model.RPriceTypeName2=ds.Tables[0].Rows[0]["RPriceTypeName2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RPriceTypeName3"]!=null && ds.Tables[0].Rows[0]["RPriceTypeName3"].ToString()!="")
				{
					model.RPriceTypeName3=ds.Tables[0].Rows[0]["RPriceTypeName3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AdditionalType"]!=null && ds.Tables[0].Rows[0]["AdditionalType"].ToString()!="")
				{
					model.AdditionalType=int.Parse(ds.Tables[0].Rows[0]["AdditionalType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supervisor"]!=null && ds.Tables[0].Rows[0]["Supervisor"].ToString()!="")
				{
					model.Supervisor=int.Parse(ds.Tables[0].Rows[0]["Supervisor"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SerialNo"]!=null && ds.Tables[0].Rows[0]["SerialNo"].ToString()!="")
				{
					model.SerialNo=int.Parse(ds.Tables[0].Rows[0]["SerialNo"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Discount"]!=null && ds.Tables[0].Rows[0]["Discount"].ToString()!="")
				{
					model.Discount=int.Parse(ds.Tables[0].Rows[0]["Discount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TypeLevel"]!=null && ds.Tables[0].Rows[0]["TypeLevel"].ToString()!="")
				{
					model.TypeLevel=int.Parse(ds.Tables[0].Rows[0]["TypeLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MemberShip"]!=null && ds.Tables[0].Rows[0]["MemberShip"].ToString()!="")
				{
					model.MemberShip=int.Parse(ds.Tables[0].Rows[0]["MemberShip"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StockTypeCode"]!=null && ds.Tables[0].Rows[0]["StockTypeCode"].ToString()!="")
				{
					model.StockTypeCode=ds.Tables[0].Rows[0]["StockTypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RANOnly"]!=null && ds.Tables[0].Rows[0]["RANOnly"].ToString()!="")
				{
					model.RANOnly=int.Parse(ds.Tables[0].Rows[0]["RANOnly"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DAMOnly"]!=null && ds.Tables[0].Rows[0]["DAMOnly"].ToString()!="")
				{
					model.DAMOnly=int.Parse(ds.Tables[0].Rows[0]["DAMOnly"].ToString());
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
			strSql.Append("select RPriceTypeID,RPriceTypeCode,RPriceTypeName1,RPriceTypeName2,RPriceTypeName3,AdditionalType,Supervisor,SerialNo,Discount,TypeLevel,MemberShip,StockTypeCode,RANOnly,DAMOnly,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_RPRICETYPE ");
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
			strSql.Append(" RPriceTypeID,RPriceTypeCode,RPriceTypeName1,RPriceTypeName2,RPriceTypeName3,AdditionalType,Supervisor,SerialNo,Discount,TypeLevel,MemberShip,StockTypeCode,RANOnly,DAMOnly,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_RPRICETYPE ");
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
			strSql.Append("select count(1) FROM BUY_RPRICETYPE ");
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
				strSql.Append("order by T.RPriceTypeID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_RPRICETYPE T ");
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
			parameters[0].Value = "BUY_RPRICETYPE";
			parameters[1].Value = "RPriceTypeID";
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

