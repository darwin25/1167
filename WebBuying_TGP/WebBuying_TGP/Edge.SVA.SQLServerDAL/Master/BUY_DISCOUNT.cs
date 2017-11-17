using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_DISCOUNT
	/// </summary>
	public partial class BUY_DISCOUNT:IBUY_DISCOUNT
	{
		public BUY_DISCOUNT()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("KeyID", "BUY_DISCOUNT"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DiscountCode,int KeyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_DISCOUNT");
			strSql.Append(" where DiscountCode=@DiscountCode and KeyID=@KeyID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DiscountCode", SqlDbType.VarChar,64),
					new SqlParameter("@KeyID", SqlDbType.Int,4)			};
			parameters[0].Value = DiscountCode;
			parameters[1].Value = KeyID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_DISCOUNT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_DISCOUNT(");
			strSql.Append("DiscountCode,ReasonCode,Description1,Description2,Description3,DiscType,SalesDiscLevel,DiscPrice,AuthLevel,AllowDiscOnDisc,AllowChgDisc,TransDiscControl,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy)");
			strSql.Append(" values (");
			strSql.Append("@DiscountCode,@ReasonCode,@Description1,@Description2,@Description3,@DiscType,@SalesDiscLevel,@DiscPrice,@AuthLevel,@AllowDiscOnDisc,@AllowChgDisc,@TransDiscControl,@Status,@Note,@CreatedOn,@CreatedBy,@UpdatedOn,@UpdatedBy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DiscountCode", SqlDbType.VarChar,64),
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,64),
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@DiscType", SqlDbType.Int,4),
					new SqlParameter("@SalesDiscLevel", SqlDbType.Int,4),
					new SqlParameter("@DiscPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AuthLevel", SqlDbType.Int,4),
					new SqlParameter("@AllowDiscOnDisc", SqlDbType.Int,4),
					new SqlParameter("@AllowChgDisc", SqlDbType.Int,4),
					new SqlParameter("@TransDiscControl", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4)};
			parameters[0].Value = model.DiscountCode;
			parameters[1].Value = model.ReasonCode;
			parameters[2].Value = model.Description1;
			parameters[3].Value = model.Description2;
			parameters[4].Value = model.Description3;
			parameters[5].Value = model.DiscType;
			parameters[6].Value = model.SalesDiscLevel;
			parameters[7].Value = model.DiscPrice;
			parameters[8].Value = model.AuthLevel;
			parameters[9].Value = model.AllowDiscOnDisc;
			parameters[10].Value = model.AllowChgDisc;
			parameters[11].Value = model.TransDiscControl;
			parameters[12].Value = model.Status;
			parameters[13].Value = model.Note;
			parameters[14].Value = model.CreatedOn;
			parameters[15].Value = model.CreatedBy;
			parameters[16].Value = model.UpdatedOn;
			parameters[17].Value = model.UpdatedBy;

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
		public bool Update(Edge.SVA.Model.BUY_DISCOUNT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_DISCOUNT set ");
			strSql.Append("ReasonCode=@ReasonCode,");
			strSql.Append("Description1=@Description1,");
			strSql.Append("Description2=@Description2,");
			strSql.Append("Description3=@Description3,");
			strSql.Append("DiscType=@DiscType,");
			strSql.Append("SalesDiscLevel=@SalesDiscLevel,");
			strSql.Append("DiscPrice=@DiscPrice,");
			strSql.Append("AuthLevel=@AuthLevel,");
			strSql.Append("AllowDiscOnDisc=@AllowDiscOnDisc,");
			strSql.Append("AllowChgDisc=@AllowChgDisc,");
			strSql.Append("TransDiscControl=@TransDiscControl,");
			strSql.Append("Status=@Status,");
			strSql.Append("Note=@Note,");
			strSql.Append("CreatedOn=@CreatedOn,");
			strSql.Append("CreatedBy=@CreatedBy,");
			strSql.Append("UpdatedOn=@UpdatedOn,");
			strSql.Append("UpdatedBy=@UpdatedBy");
            strSql.Append(" where DiscountID=@DiscountID");
			SqlParameter[] parameters = {
					new SqlParameter("@ReasonCode", SqlDbType.VarChar,64),
					new SqlParameter("@Description1", SqlDbType.NVarChar,512),
					new SqlParameter("@Description2", SqlDbType.NVarChar,512),
					new SqlParameter("@Description3", SqlDbType.NVarChar,512),
					new SqlParameter("@DiscType", SqlDbType.Int,4),
					new SqlParameter("@SalesDiscLevel", SqlDbType.Int,4),
					new SqlParameter("@DiscPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AuthLevel", SqlDbType.Int,4),
					new SqlParameter("@AllowDiscOnDisc", SqlDbType.Int,4),
					new SqlParameter("@AllowChgDisc", SqlDbType.Int,4),
					new SqlParameter("@TransDiscControl", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@CreatedOn", SqlDbType.DateTime),
					new SqlParameter("@CreatedBy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedOn", SqlDbType.DateTime),
					new SqlParameter("@UpdatedBy", SqlDbType.Int,4),
					new SqlParameter("@DiscountID", SqlDbType.Int,4),
					new SqlParameter("@DiscountCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ReasonCode;
			parameters[1].Value = model.Description1;
			parameters[2].Value = model.Description2;
			parameters[3].Value = model.Description3;
			parameters[4].Value = model.DiscType;
			parameters[5].Value = model.SalesDiscLevel;
			parameters[6].Value = model.DiscPrice;
			parameters[7].Value = model.AuthLevel;
			parameters[8].Value = model.AllowDiscOnDisc;
			parameters[9].Value = model.AllowChgDisc;
			parameters[10].Value = model.TransDiscControl;
			parameters[11].Value = model.Status;
			parameters[12].Value = model.Note;
			parameters[13].Value = model.CreatedOn;
			parameters[14].Value = model.CreatedBy;
			parameters[15].Value = model.UpdatedOn;
			parameters[16].Value = model.UpdatedBy;
			parameters[17].Value = model.DiscountId;
			parameters[18].Value = model.DiscountCode;

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
			strSql.Append("delete from BUY_DISCOUNT ");
            strSql.Append(" where DiscountID=@DiscountID");
			SqlParameter[] parameters = {
					new SqlParameter("@DiscountID", SqlDbType.Int,4)
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DiscountCode,int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_DISCOUNT ");
            strSql.Append(" where DiscountCode=@DiscountCode and DiscountID=@DiscountID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DiscountCode", SqlDbType.VarChar,64),
					new SqlParameter("@DiscountID", SqlDbType.Int,4)			};
			parameters[0].Value = DiscountCode;
			parameters[1].Value = KeyID;

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
        public bool DeleteList(string DiscountIDlist)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_DISCOUNT ");
            strSql.Append(" where DiscountID in (" + DiscountIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_DISCOUNT GetModel(int KeyID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 DiscountID,DiscountCode,ReasonCode,Description1,Description2,Description3,DiscType,SalesDiscLevel,DiscPrice,AuthLevel,AllowDiscOnDisc,AllowChgDisc,TransDiscControl,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy from BUY_DISCOUNT ");
            strSql.Append(" where DiscountID=@DiscountID");
			SqlParameter[] parameters = {
					new SqlParameter("@DiscountID", SqlDbType.Int,4)
			};
			parameters[0].Value = KeyID;

			Edge.SVA.Model.BUY_DISCOUNT model=new Edge.SVA.Model.BUY_DISCOUNT();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
                if (ds.Tables[0].Rows[0]["DiscountID"] != null && ds.Tables[0].Rows[0]["DiscountID"].ToString() != "")
				{
                    model.DiscountId = int.Parse(ds.Tables[0].Rows[0]["DiscountID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiscountCode"]!=null && ds.Tables[0].Rows[0]["DiscountCode"].ToString()!="")
				{
					model.DiscountCode=ds.Tables[0].Rows[0]["DiscountCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReasonCode"]!=null && ds.Tables[0].Rows[0]["ReasonCode"].ToString()!="")
				{
					model.ReasonCode=ds.Tables[0].Rows[0]["ReasonCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description1"]!=null && ds.Tables[0].Rows[0]["Description1"].ToString()!="")
				{
					model.Description1=ds.Tables[0].Rows[0]["Description1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description2"]!=null && ds.Tables[0].Rows[0]["Description2"].ToString()!="")
				{
					model.Description2=ds.Tables[0].Rows[0]["Description2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description3"]!=null && ds.Tables[0].Rows[0]["Description3"].ToString()!="")
				{
					model.Description3=ds.Tables[0].Rows[0]["Description3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DiscType"]!=null && ds.Tables[0].Rows[0]["DiscType"].ToString()!="")
				{
					model.DiscType=int.Parse(ds.Tables[0].Rows[0]["DiscType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SalesDiscLevel"]!=null && ds.Tables[0].Rows[0]["SalesDiscLevel"].ToString()!="")
				{
					model.SalesDiscLevel=int.Parse(ds.Tables[0].Rows[0]["SalesDiscLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DiscPrice"]!=null && ds.Tables[0].Rows[0]["DiscPrice"].ToString()!="")
				{
					model.DiscPrice=decimal.Parse(ds.Tables[0].Rows[0]["DiscPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AuthLevel"]!=null && ds.Tables[0].Rows[0]["AuthLevel"].ToString()!="")
				{
					model.AuthLevel=int.Parse(ds.Tables[0].Rows[0]["AuthLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AllowDiscOnDisc"]!=null && ds.Tables[0].Rows[0]["AllowDiscOnDisc"].ToString()!="")
				{
					model.AllowDiscOnDisc=int.Parse(ds.Tables[0].Rows[0]["AllowDiscOnDisc"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AllowChgDisc"]!=null && ds.Tables[0].Rows[0]["AllowChgDisc"].ToString()!="")
				{
					model.AllowChgDisc=int.Parse(ds.Tables[0].Rows[0]["AllowChgDisc"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TransDiscControl"]!=null && ds.Tables[0].Rows[0]["TransDiscControl"].ToString()!="")
				{
					model.TransDiscControl=int.Parse(ds.Tables[0].Rows[0]["TransDiscControl"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
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
            strSql.Append("select DiscountID,DiscountCode,ReasonCode,Description1,Description2,Description3,DiscType,SalesDiscLevel,DiscPrice,AuthLevel,AllowDiscOnDisc,AllowChgDisc,TransDiscControl,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_DISCOUNT ");
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
            strSql.Append(" DiscountID,DiscountCode,ReasonCode,Description1,Description2,Description3,DiscType,SalesDiscLevel,DiscPrice,AuthLevel,AllowDiscOnDisc,AllowChgDisc,TransDiscControl,Status,Note,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy ");
			strSql.Append(" FROM BUY_DISCOUNT ");
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
			strSql.Append("select count(1) FROM BUY_DISCOUNT ");
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
			strSql.Append(")AS Row, T.*  from BUY_DISCOUNT T ");
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
			parameters[0].Value = "BUY_DISCOUNT";
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

