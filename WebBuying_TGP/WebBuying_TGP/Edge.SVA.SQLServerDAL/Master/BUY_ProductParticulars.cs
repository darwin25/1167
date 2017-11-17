using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_ProductParticulars
	/// </summary>
	public partial class BUY_ProductParticulars:IBUY_ProductParticulars
	{
		public BUY_ProductParticulars()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LanguageID", "BUY_ProductParticulars"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode,int LanguageID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_ProductParticulars");
			strSql.Append(" where ProdCode=@ProdCode and LanguageID=@LanguageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@LanguageID", SqlDbType.Int,4)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = LanguageID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_ProductParticulars model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_ProductParticulars(");
			strSql.Append("ProdCode,LanguageID,ProdFunction,ProdIngredients,ProdInstructions,PackDesc,PackUnit,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,MemoTitle1,MemoTitle2,MemoTitle3,MemoTitle4,MemoTitle5,MemoTitle6)");
			strSql.Append(" values (");
			strSql.Append("@ProdCode,@LanguageID,@ProdFunction,@ProdIngredients,@ProdInstructions,@PackDesc,@PackUnit,@Memo1,@Memo2,@Memo3,@Memo4,@Memo5,@Memo6,@MemoTitle1,@MemoTitle2,@MemoTitle3,@MemoTitle4,@MemoTitle5,@MemoTitle6)");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@LanguageID", SqlDbType.Int,4),
					new SqlParameter("@ProdFunction", SqlDbType.NVarChar),
					new SqlParameter("@ProdIngredients", SqlDbType.NVarChar),
					new SqlParameter("@ProdInstructions", SqlDbType.NVarChar),
					new SqlParameter("@PackDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@PackUnit", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo1", SqlDbType.NVarChar),
					new SqlParameter("@Memo2", SqlDbType.NVarChar),
					new SqlParameter("@Memo3", SqlDbType.NVarChar),
					new SqlParameter("@Memo4", SqlDbType.NVarChar),
					new SqlParameter("@Memo5", SqlDbType.NVarChar),
					new SqlParameter("@Memo6", SqlDbType.NVarChar),
					new SqlParameter("@MemoTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle4", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle5", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle6", SqlDbType.NVarChar,512)};
			parameters[0].Value = model.ProdCode;
			parameters[1].Value = model.LanguageID;
			parameters[2].Value = model.ProdFunction;
			parameters[3].Value = model.ProdIngredients;
			parameters[4].Value = model.ProdInstructions;
			parameters[5].Value = model.PackDesc;
			parameters[6].Value = model.PackUnit;
			parameters[7].Value = model.Memo1;
			parameters[8].Value = model.Memo2;
			parameters[9].Value = model.Memo3;
			parameters[10].Value = model.Memo4;
			parameters[11].Value = model.Memo5;
			parameters[12].Value = model.Memo6;
			parameters[13].Value = model.MemoTitle1;
			parameters[14].Value = model.MemoTitle2;
			parameters[15].Value = model.MemoTitle3;
			parameters[16].Value = model.MemoTitle4;
			parameters[17].Value = model.MemoTitle5;
			parameters[18].Value = model.MemoTitle6;

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
		public bool Update(Edge.SVA.Model.BUY_ProductParticulars model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_ProductParticulars set ");
			strSql.Append("ProdFunction=@ProdFunction,");
			strSql.Append("ProdIngredients=@ProdIngredients,");
			strSql.Append("ProdInstructions=@ProdInstructions,");
			strSql.Append("PackDesc=@PackDesc,");
			strSql.Append("PackUnit=@PackUnit,");
			strSql.Append("Memo1=@Memo1,");
			strSql.Append("Memo2=@Memo2,");
			strSql.Append("Memo3=@Memo3,");
			strSql.Append("Memo4=@Memo4,");
			strSql.Append("Memo5=@Memo5,");
			strSql.Append("Memo6=@Memo6,");
			strSql.Append("MemoTitle1=@MemoTitle1,");
			strSql.Append("MemoTitle2=@MemoTitle2,");
			strSql.Append("MemoTitle3=@MemoTitle3,");
			strSql.Append("MemoTitle4=@MemoTitle4,");
			strSql.Append("MemoTitle5=@MemoTitle5,");
			strSql.Append("MemoTitle6=@MemoTitle6");
			strSql.Append(" where ProdCode=@ProdCode and LanguageID=@LanguageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdFunction", SqlDbType.NVarChar),
					new SqlParameter("@ProdIngredients", SqlDbType.NVarChar),
					new SqlParameter("@ProdInstructions", SqlDbType.NVarChar),
					new SqlParameter("@PackDesc", SqlDbType.NVarChar,512),
					new SqlParameter("@PackUnit", SqlDbType.NVarChar,512),
					new SqlParameter("@Memo1", SqlDbType.NVarChar),
					new SqlParameter("@Memo2", SqlDbType.NVarChar),
					new SqlParameter("@Memo3", SqlDbType.NVarChar),
					new SqlParameter("@Memo4", SqlDbType.NVarChar),
					new SqlParameter("@Memo5", SqlDbType.NVarChar),
					new SqlParameter("@Memo6", SqlDbType.NVarChar),
					new SqlParameter("@MemoTitle1", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle2", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle3", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle4", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle5", SqlDbType.NVarChar,512),
					new SqlParameter("@MemoTitle6", SqlDbType.NVarChar,512),
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@LanguageID", SqlDbType.Int,4)};
			parameters[0].Value = model.ProdFunction;
			parameters[1].Value = model.ProdIngredients;
			parameters[2].Value = model.ProdInstructions;
			parameters[3].Value = model.PackDesc;
			parameters[4].Value = model.PackUnit;
			parameters[5].Value = model.Memo1;
			parameters[6].Value = model.Memo2;
			parameters[7].Value = model.Memo3;
			parameters[8].Value = model.Memo4;
			parameters[9].Value = model.Memo5;
			parameters[10].Value = model.Memo6;
			parameters[11].Value = model.MemoTitle1;
			parameters[12].Value = model.MemoTitle2;
			parameters[13].Value = model.MemoTitle3;
			parameters[14].Value = model.MemoTitle4;
			parameters[15].Value = model.MemoTitle5;
			parameters[16].Value = model.MemoTitle6;
			parameters[17].Value = model.ProdCode;
			parameters[18].Value = model.LanguageID;

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
		public bool Delete(string ProdCode,int LanguageID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_ProductParticulars ");
			strSql.Append(" where ProdCode=@ProdCode and LanguageID=@LanguageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@LanguageID", SqlDbType.Int,4)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = LanguageID;

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
		public Edge.SVA.Model.BUY_ProductParticulars GetModel(string ProdCode,int LanguageID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProdCode,LanguageID,ProdFunction,ProdIngredients,ProdInstructions,PackDesc,PackUnit,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,MemoTitle1,MemoTitle2,MemoTitle3,MemoTitle4,MemoTitle5,MemoTitle6 from BUY_ProductParticulars ");
			strSql.Append(" where ProdCode=@ProdCode and LanguageID=@LanguageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProdCode", SqlDbType.VarChar,64),
					new SqlParameter("@LanguageID", SqlDbType.Int,4)			};
			parameters[0].Value = ProdCode;
			parameters[1].Value = LanguageID;

			Edge.SVA.Model.BUY_ProductParticulars model=new Edge.SVA.Model.BUY_ProductParticulars();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProdCode"]!=null && ds.Tables[0].Rows[0]["ProdCode"].ToString()!="")
				{
					model.ProdCode=ds.Tables[0].Rows[0]["ProdCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LanguageID"]!=null && ds.Tables[0].Rows[0]["LanguageID"].ToString()!="")
				{
					model.LanguageID=int.Parse(ds.Tables[0].Rows[0]["LanguageID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProdFunction"]!=null && ds.Tables[0].Rows[0]["ProdFunction"].ToString()!="")
				{
					model.ProdFunction=ds.Tables[0].Rows[0]["ProdFunction"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdIngredients"]!=null && ds.Tables[0].Rows[0]["ProdIngredients"].ToString()!="")
				{
					model.ProdIngredients=ds.Tables[0].Rows[0]["ProdIngredients"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ProdInstructions"]!=null && ds.Tables[0].Rows[0]["ProdInstructions"].ToString()!="")
				{
					model.ProdInstructions=ds.Tables[0].Rows[0]["ProdInstructions"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackDesc"]!=null && ds.Tables[0].Rows[0]["PackDesc"].ToString()!="")
				{
					model.PackDesc=ds.Tables[0].Rows[0]["PackDesc"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PackUnit"]!=null && ds.Tables[0].Rows[0]["PackUnit"].ToString()!="")
				{
					model.PackUnit=ds.Tables[0].Rows[0]["PackUnit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo1"]!=null && ds.Tables[0].Rows[0]["Memo1"].ToString()!="")
				{
					model.Memo1=ds.Tables[0].Rows[0]["Memo1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo2"]!=null && ds.Tables[0].Rows[0]["Memo2"].ToString()!="")
				{
					model.Memo2=ds.Tables[0].Rows[0]["Memo2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo3"]!=null && ds.Tables[0].Rows[0]["Memo3"].ToString()!="")
				{
					model.Memo3=ds.Tables[0].Rows[0]["Memo3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo4"]!=null && ds.Tables[0].Rows[0]["Memo4"].ToString()!="")
				{
					model.Memo4=ds.Tables[0].Rows[0]["Memo4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo5"]!=null && ds.Tables[0].Rows[0]["Memo5"].ToString()!="")
				{
					model.Memo5=ds.Tables[0].Rows[0]["Memo5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Memo6"]!=null && ds.Tables[0].Rows[0]["Memo6"].ToString()!="")
				{
					model.Memo6=ds.Tables[0].Rows[0]["Memo6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemoTitle1"]!=null && ds.Tables[0].Rows[0]["MemoTitle1"].ToString()!="")
				{
					model.MemoTitle1=ds.Tables[0].Rows[0]["MemoTitle1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemoTitle2"]!=null && ds.Tables[0].Rows[0]["MemoTitle2"].ToString()!="")
				{
					model.MemoTitle2=ds.Tables[0].Rows[0]["MemoTitle2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemoTitle3"]!=null && ds.Tables[0].Rows[0]["MemoTitle3"].ToString()!="")
				{
					model.MemoTitle3=ds.Tables[0].Rows[0]["MemoTitle3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemoTitle4"]!=null && ds.Tables[0].Rows[0]["MemoTitle4"].ToString()!="")
				{
					model.MemoTitle4=ds.Tables[0].Rows[0]["MemoTitle4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemoTitle5"]!=null && ds.Tables[0].Rows[0]["MemoTitle5"].ToString()!="")
				{
					model.MemoTitle5=ds.Tables[0].Rows[0]["MemoTitle5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MemoTitle6"]!=null && ds.Tables[0].Rows[0]["MemoTitle6"].ToString()!="")
				{
					model.MemoTitle6=ds.Tables[0].Rows[0]["MemoTitle6"].ToString();
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
			strSql.Append("select ProdCode,LanguageID,ProdFunction,ProdIngredients,ProdInstructions,PackDesc,PackUnit,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,MemoTitle1,MemoTitle2,MemoTitle3,MemoTitle4,MemoTitle5,MemoTitle6 ");
			strSql.Append(" FROM BUY_ProductParticulars ");
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
			strSql.Append(" ProdCode,LanguageID,ProdFunction,ProdIngredients,ProdInstructions,PackDesc,PackUnit,Memo1,Memo2,Memo3,Memo4,Memo5,Memo6,MemoTitle1,MemoTitle2,MemoTitle3,MemoTitle4,MemoTitle5,MemoTitle6 ");
			strSql.Append(" FROM BUY_ProductParticulars ");
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
			strSql.Append("select count(1) FROM BUY_ProductParticulars ");
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
				strSql.Append("order by T.LanguageID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_ProductParticulars T ");
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
			parameters[0].Value = "BUY_ProductParticulars";
			parameters[1].Value = "LanguageID";
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

