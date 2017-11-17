using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Edge.SVA.IDAL;
using Edge.DBUtility;//Please add references
namespace Edge.SVA.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:BUY_DAYFLAG
	/// </summary>
	public partial class BUY_DAYFLAG:IBUY_DAYFLAG
	{
		public BUY_DAYFLAG()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DayFlagID", "BUY_DAYFLAG"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DayFlagCode,int DayFlagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BUY_DAYFLAG");
			strSql.Append(" where DayFlagCode=@DayFlagCode and DayFlagID=@DayFlagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@DayFlagID", SqlDbType.Int,4)			};
			parameters[0].Value = DayFlagCode;
			parameters[1].Value = DayFlagID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Edge.SVA.Model.BUY_DAYFLAG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BUY_DAYFLAG(");
			strSql.Append("DayFlagCode,Note,Day1Flag,Day2Flag,Day3Flag,Day4Flag,Day5Flag,Day6Flag,Day7Flag,Day8Flag,Day9Flag,Day10Flag,Day11Flag,Day12Flag,Day13Flag,Day14Flag,Day15Flag,Day16Flag,Day17Flag,Day18Flag,Day19Flag,Day20Flag,Day21Flag,Day22Flag,Day23Flag,Day24Flag,Day25Flag,Day26Flag,Day27Flag,Day28Flag,Day29Flag,Day30Flag,Day31Flag)");
			strSql.Append(" values (");
			strSql.Append("@DayFlagCode,@Note,@Day1Flag,@Day2Flag,@Day3Flag,@Day4Flag,@Day5Flag,@Day6Flag,@Day7Flag,@Day8Flag,@Day9Flag,@Day10Flag,@Day11Flag,@Day12Flag,@Day13Flag,@Day14Flag,@Day15Flag,@Day16Flag,@Day17Flag,@Day18Flag,@Day19Flag,@Day20Flag,@Day21Flag,@Day22Flag,@Day23Flag,@Day24Flag,@Day25Flag,@Day26Flag,@Day27Flag,@Day28Flag,@Day29Flag,@Day30Flag,@Day31Flag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@Day1Flag", SqlDbType.Int,4),
					new SqlParameter("@Day2Flag", SqlDbType.Int,4),
					new SqlParameter("@Day3Flag", SqlDbType.Int,4),
					new SqlParameter("@Day4Flag", SqlDbType.Int,4),
					new SqlParameter("@Day5Flag", SqlDbType.Int,4),
					new SqlParameter("@Day6Flag", SqlDbType.Int,4),
					new SqlParameter("@Day7Flag", SqlDbType.Int,4),
					new SqlParameter("@Day8Flag", SqlDbType.Int,4),
					new SqlParameter("@Day9Flag", SqlDbType.Int,4),
					new SqlParameter("@Day10Flag", SqlDbType.Int,4),
					new SqlParameter("@Day11Flag", SqlDbType.Int,4),
					new SqlParameter("@Day12Flag", SqlDbType.Int,4),
					new SqlParameter("@Day13Flag", SqlDbType.Int,4),
					new SqlParameter("@Day14Flag", SqlDbType.Int,4),
					new SqlParameter("@Day15Flag", SqlDbType.Int,4),
					new SqlParameter("@Day16Flag", SqlDbType.Int,4),
					new SqlParameter("@Day17Flag", SqlDbType.Int,4),
					new SqlParameter("@Day18Flag", SqlDbType.Int,4),
					new SqlParameter("@Day19Flag", SqlDbType.Int,4),
					new SqlParameter("@Day20Flag", SqlDbType.Int,4),
					new SqlParameter("@Day21Flag", SqlDbType.Int,4),
					new SqlParameter("@Day22Flag", SqlDbType.Int,4),
					new SqlParameter("@Day23Flag", SqlDbType.Int,4),
					new SqlParameter("@Day24Flag", SqlDbType.Int,4),
					new SqlParameter("@Day25Flag", SqlDbType.Int,4),
					new SqlParameter("@Day26Flag", SqlDbType.Int,4),
					new SqlParameter("@Day27Flag", SqlDbType.Int,4),
					new SqlParameter("@Day28Flag", SqlDbType.Int,4),
					new SqlParameter("@Day29Flag", SqlDbType.Int,4),
					new SqlParameter("@Day30Flag", SqlDbType.Int,4),
					new SqlParameter("@Day31Flag", SqlDbType.Int,4)};
			parameters[0].Value = model.DayFlagCode;
			parameters[1].Value = model.Note;
			parameters[2].Value = model.Day1Flag;
			parameters[3].Value = model.Day2Flag;
			parameters[4].Value = model.Day3Flag;
			parameters[5].Value = model.Day4Flag;
			parameters[6].Value = model.Day5Flag;
			parameters[7].Value = model.Day6Flag;
			parameters[8].Value = model.Day7Flag;
			parameters[9].Value = model.Day8Flag;
			parameters[10].Value = model.Day9Flag;
			parameters[11].Value = model.Day10Flag;
			parameters[12].Value = model.Day11Flag;
			parameters[13].Value = model.Day12Flag;
			parameters[14].Value = model.Day13Flag;
			parameters[15].Value = model.Day14Flag;
			parameters[16].Value = model.Day15Flag;
			parameters[17].Value = model.Day16Flag;
			parameters[18].Value = model.Day17Flag;
			parameters[19].Value = model.Day18Flag;
			parameters[20].Value = model.Day19Flag;
			parameters[21].Value = model.Day20Flag;
			parameters[22].Value = model.Day21Flag;
			parameters[23].Value = model.Day22Flag;
			parameters[24].Value = model.Day23Flag;
			parameters[25].Value = model.Day24Flag;
			parameters[26].Value = model.Day25Flag;
			parameters[27].Value = model.Day26Flag;
			parameters[28].Value = model.Day27Flag;
			parameters[29].Value = model.Day28Flag;
			parameters[30].Value = model.Day29Flag;
			parameters[31].Value = model.Day30Flag;
			parameters[32].Value = model.Day31Flag;

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
		public bool Update(Edge.SVA.Model.BUY_DAYFLAG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BUY_DAYFLAG set ");
			strSql.Append("Note=@Note,");
			strSql.Append("Day1Flag=@Day1Flag,");
			strSql.Append("Day2Flag=@Day2Flag,");
			strSql.Append("Day3Flag=@Day3Flag,");
			strSql.Append("Day4Flag=@Day4Flag,");
			strSql.Append("Day5Flag=@Day5Flag,");
			strSql.Append("Day6Flag=@Day6Flag,");
			strSql.Append("Day7Flag=@Day7Flag,");
			strSql.Append("Day8Flag=@Day8Flag,");
			strSql.Append("Day9Flag=@Day9Flag,");
			strSql.Append("Day10Flag=@Day10Flag,");
			strSql.Append("Day11Flag=@Day11Flag,");
			strSql.Append("Day12Flag=@Day12Flag,");
			strSql.Append("Day13Flag=@Day13Flag,");
			strSql.Append("Day14Flag=@Day14Flag,");
			strSql.Append("Day15Flag=@Day15Flag,");
			strSql.Append("Day16Flag=@Day16Flag,");
			strSql.Append("Day17Flag=@Day17Flag,");
			strSql.Append("Day18Flag=@Day18Flag,");
			strSql.Append("Day19Flag=@Day19Flag,");
			strSql.Append("Day20Flag=@Day20Flag,");
			strSql.Append("Day21Flag=@Day21Flag,");
			strSql.Append("Day22Flag=@Day22Flag,");
			strSql.Append("Day23Flag=@Day23Flag,");
			strSql.Append("Day24Flag=@Day24Flag,");
			strSql.Append("Day25Flag=@Day25Flag,");
			strSql.Append("Day26Flag=@Day26Flag,");
			strSql.Append("Day27Flag=@Day27Flag,");
			strSql.Append("Day28Flag=@Day28Flag,");
			strSql.Append("Day29Flag=@Day29Flag,");
			strSql.Append("Day30Flag=@Day30Flag,");
			strSql.Append("Day31Flag=@Day31Flag");
			strSql.Append(" where DayFlagID=@DayFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@Note", SqlDbType.NVarChar,512),
					new SqlParameter("@Day1Flag", SqlDbType.Int,4),
					new SqlParameter("@Day2Flag", SqlDbType.Int,4),
					new SqlParameter("@Day3Flag", SqlDbType.Int,4),
					new SqlParameter("@Day4Flag", SqlDbType.Int,4),
					new SqlParameter("@Day5Flag", SqlDbType.Int,4),
					new SqlParameter("@Day6Flag", SqlDbType.Int,4),
					new SqlParameter("@Day7Flag", SqlDbType.Int,4),
					new SqlParameter("@Day8Flag", SqlDbType.Int,4),
					new SqlParameter("@Day9Flag", SqlDbType.Int,4),
					new SqlParameter("@Day10Flag", SqlDbType.Int,4),
					new SqlParameter("@Day11Flag", SqlDbType.Int,4),
					new SqlParameter("@Day12Flag", SqlDbType.Int,4),
					new SqlParameter("@Day13Flag", SqlDbType.Int,4),
					new SqlParameter("@Day14Flag", SqlDbType.Int,4),
					new SqlParameter("@Day15Flag", SqlDbType.Int,4),
					new SqlParameter("@Day16Flag", SqlDbType.Int,4),
					new SqlParameter("@Day17Flag", SqlDbType.Int,4),
					new SqlParameter("@Day18Flag", SqlDbType.Int,4),
					new SqlParameter("@Day19Flag", SqlDbType.Int,4),
					new SqlParameter("@Day20Flag", SqlDbType.Int,4),
					new SqlParameter("@Day21Flag", SqlDbType.Int,4),
					new SqlParameter("@Day22Flag", SqlDbType.Int,4),
					new SqlParameter("@Day23Flag", SqlDbType.Int,4),
					new SqlParameter("@Day24Flag", SqlDbType.Int,4),
					new SqlParameter("@Day25Flag", SqlDbType.Int,4),
					new SqlParameter("@Day26Flag", SqlDbType.Int,4),
					new SqlParameter("@Day27Flag", SqlDbType.Int,4),
					new SqlParameter("@Day28Flag", SqlDbType.Int,4),
					new SqlParameter("@Day29Flag", SqlDbType.Int,4),
					new SqlParameter("@Day30Flag", SqlDbType.Int,4),
					new SqlParameter("@Day31Flag", SqlDbType.Int,4),
					new SqlParameter("@DayFlagID", SqlDbType.Int,4),
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Note;
			parameters[1].Value = model.Day1Flag;
			parameters[2].Value = model.Day2Flag;
			parameters[3].Value = model.Day3Flag;
			parameters[4].Value = model.Day4Flag;
			parameters[5].Value = model.Day5Flag;
			parameters[6].Value = model.Day6Flag;
			parameters[7].Value = model.Day7Flag;
			parameters[8].Value = model.Day8Flag;
			parameters[9].Value = model.Day9Flag;
			parameters[10].Value = model.Day10Flag;
			parameters[11].Value = model.Day11Flag;
			parameters[12].Value = model.Day12Flag;
			parameters[13].Value = model.Day13Flag;
			parameters[14].Value = model.Day14Flag;
			parameters[15].Value = model.Day15Flag;
			parameters[16].Value = model.Day16Flag;
			parameters[17].Value = model.Day17Flag;
			parameters[18].Value = model.Day18Flag;
			parameters[19].Value = model.Day19Flag;
			parameters[20].Value = model.Day20Flag;
			parameters[21].Value = model.Day21Flag;
			parameters[22].Value = model.Day22Flag;
			parameters[23].Value = model.Day23Flag;
			parameters[24].Value = model.Day24Flag;
			parameters[25].Value = model.Day25Flag;
			parameters[26].Value = model.Day26Flag;
			parameters[27].Value = model.Day27Flag;
			parameters[28].Value = model.Day28Flag;
			parameters[29].Value = model.Day29Flag;
			parameters[30].Value = model.Day30Flag;
			parameters[31].Value = model.Day31Flag;
			parameters[32].Value = model.DayFlagID;
			parameters[33].Value = model.DayFlagCode;

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
		public bool Delete(int DayFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_DAYFLAG ");
			strSql.Append(" where DayFlagID=@DayFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@DayFlagID", SqlDbType.Int,4)
			};
			parameters[0].Value = DayFlagID;

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
		public bool Delete(string DayFlagCode,int DayFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_DAYFLAG ");
			strSql.Append(" where DayFlagCode=@DayFlagCode and DayFlagID=@DayFlagID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DayFlagCode", SqlDbType.VarChar,64),
					new SqlParameter("@DayFlagID", SqlDbType.Int,4)			};
			parameters[0].Value = DayFlagCode;
			parameters[1].Value = DayFlagID;

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
		public bool DeleteList(string DayFlagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BUY_DAYFLAG ");
			strSql.Append(" where DayFlagID in ("+DayFlagIDlist + ")  ");
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
		public Edge.SVA.Model.BUY_DAYFLAG GetModel(int DayFlagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DayFlagID,DayFlagCode,Note,Day1Flag,Day2Flag,Day3Flag,Day4Flag,Day5Flag,Day6Flag,Day7Flag,Day8Flag,Day9Flag,Day10Flag,Day11Flag,Day12Flag,Day13Flag,Day14Flag,Day15Flag,Day16Flag,Day17Flag,Day18Flag,Day19Flag,Day20Flag,Day21Flag,Day22Flag,Day23Flag,Day24Flag,Day25Flag,Day26Flag,Day27Flag,Day28Flag,Day29Flag,Day30Flag,Day31Flag from BUY_DAYFLAG ");
			strSql.Append(" where DayFlagID=@DayFlagID");
			SqlParameter[] parameters = {
					new SqlParameter("@DayFlagID", SqlDbType.Int,4)
			};
			parameters[0].Value = DayFlagID;

			Edge.SVA.Model.BUY_DAYFLAG model=new Edge.SVA.Model.BUY_DAYFLAG();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DayFlagID"]!=null && ds.Tables[0].Rows[0]["DayFlagID"].ToString()!="")
				{
					model.DayFlagID=int.Parse(ds.Tables[0].Rows[0]["DayFlagID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DayFlagCode"]!=null && ds.Tables[0].Rows[0]["DayFlagCode"].ToString()!="")
				{
					model.DayFlagCode=ds.Tables[0].Rows[0]["DayFlagCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note"]!=null && ds.Tables[0].Rows[0]["Note"].ToString()!="")
				{
					model.Note=ds.Tables[0].Rows[0]["Note"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Day1Flag"]!=null && ds.Tables[0].Rows[0]["Day1Flag"].ToString()!="")
				{
					model.Day1Flag=int.Parse(ds.Tables[0].Rows[0]["Day1Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day2Flag"]!=null && ds.Tables[0].Rows[0]["Day2Flag"].ToString()!="")
				{
					model.Day2Flag=int.Parse(ds.Tables[0].Rows[0]["Day2Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day3Flag"]!=null && ds.Tables[0].Rows[0]["Day3Flag"].ToString()!="")
				{
					model.Day3Flag=int.Parse(ds.Tables[0].Rows[0]["Day3Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day4Flag"]!=null && ds.Tables[0].Rows[0]["Day4Flag"].ToString()!="")
				{
					model.Day4Flag=int.Parse(ds.Tables[0].Rows[0]["Day4Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day5Flag"]!=null && ds.Tables[0].Rows[0]["Day5Flag"].ToString()!="")
				{
					model.Day5Flag=int.Parse(ds.Tables[0].Rows[0]["Day5Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day6Flag"]!=null && ds.Tables[0].Rows[0]["Day6Flag"].ToString()!="")
				{
					model.Day6Flag=int.Parse(ds.Tables[0].Rows[0]["Day6Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day7Flag"]!=null && ds.Tables[0].Rows[0]["Day7Flag"].ToString()!="")
				{
					model.Day7Flag=int.Parse(ds.Tables[0].Rows[0]["Day7Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day8Flag"]!=null && ds.Tables[0].Rows[0]["Day8Flag"].ToString()!="")
				{
					model.Day8Flag=int.Parse(ds.Tables[0].Rows[0]["Day8Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day9Flag"]!=null && ds.Tables[0].Rows[0]["Day9Flag"].ToString()!="")
				{
					model.Day9Flag=int.Parse(ds.Tables[0].Rows[0]["Day9Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day10Flag"]!=null && ds.Tables[0].Rows[0]["Day10Flag"].ToString()!="")
				{
					model.Day10Flag=int.Parse(ds.Tables[0].Rows[0]["Day10Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day11Flag"]!=null && ds.Tables[0].Rows[0]["Day11Flag"].ToString()!="")
				{
					model.Day11Flag=int.Parse(ds.Tables[0].Rows[0]["Day11Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day12Flag"]!=null && ds.Tables[0].Rows[0]["Day12Flag"].ToString()!="")
				{
					model.Day12Flag=int.Parse(ds.Tables[0].Rows[0]["Day12Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day13Flag"]!=null && ds.Tables[0].Rows[0]["Day13Flag"].ToString()!="")
				{
					model.Day13Flag=int.Parse(ds.Tables[0].Rows[0]["Day13Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day14Flag"]!=null && ds.Tables[0].Rows[0]["Day14Flag"].ToString()!="")
				{
					model.Day14Flag=int.Parse(ds.Tables[0].Rows[0]["Day14Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day15Flag"]!=null && ds.Tables[0].Rows[0]["Day15Flag"].ToString()!="")
				{
					model.Day15Flag=int.Parse(ds.Tables[0].Rows[0]["Day15Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day16Flag"]!=null && ds.Tables[0].Rows[0]["Day16Flag"].ToString()!="")
				{
					model.Day16Flag=int.Parse(ds.Tables[0].Rows[0]["Day16Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day17Flag"]!=null && ds.Tables[0].Rows[0]["Day17Flag"].ToString()!="")
				{
					model.Day17Flag=int.Parse(ds.Tables[0].Rows[0]["Day17Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day18Flag"]!=null && ds.Tables[0].Rows[0]["Day18Flag"].ToString()!="")
				{
					model.Day18Flag=int.Parse(ds.Tables[0].Rows[0]["Day18Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day19Flag"]!=null && ds.Tables[0].Rows[0]["Day19Flag"].ToString()!="")
				{
					model.Day19Flag=int.Parse(ds.Tables[0].Rows[0]["Day19Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day20Flag"]!=null && ds.Tables[0].Rows[0]["Day20Flag"].ToString()!="")
				{
					model.Day20Flag=int.Parse(ds.Tables[0].Rows[0]["Day20Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day21Flag"]!=null && ds.Tables[0].Rows[0]["Day21Flag"].ToString()!="")
				{
					model.Day21Flag=int.Parse(ds.Tables[0].Rows[0]["Day21Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day22Flag"]!=null && ds.Tables[0].Rows[0]["Day22Flag"].ToString()!="")
				{
					model.Day22Flag=int.Parse(ds.Tables[0].Rows[0]["Day22Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day23Flag"]!=null && ds.Tables[0].Rows[0]["Day23Flag"].ToString()!="")
				{
					model.Day23Flag=int.Parse(ds.Tables[0].Rows[0]["Day23Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day24Flag"]!=null && ds.Tables[0].Rows[0]["Day24Flag"].ToString()!="")
				{
					model.Day24Flag=int.Parse(ds.Tables[0].Rows[0]["Day24Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day25Flag"]!=null && ds.Tables[0].Rows[0]["Day25Flag"].ToString()!="")
				{
					model.Day25Flag=int.Parse(ds.Tables[0].Rows[0]["Day25Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day26Flag"]!=null && ds.Tables[0].Rows[0]["Day26Flag"].ToString()!="")
				{
					model.Day26Flag=int.Parse(ds.Tables[0].Rows[0]["Day26Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day27Flag"]!=null && ds.Tables[0].Rows[0]["Day27Flag"].ToString()!="")
				{
					model.Day27Flag=int.Parse(ds.Tables[0].Rows[0]["Day27Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day28Flag"]!=null && ds.Tables[0].Rows[0]["Day28Flag"].ToString()!="")
				{
					model.Day28Flag=int.Parse(ds.Tables[0].Rows[0]["Day28Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day29Flag"]!=null && ds.Tables[0].Rows[0]["Day29Flag"].ToString()!="")
				{
					model.Day29Flag=int.Parse(ds.Tables[0].Rows[0]["Day29Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day30Flag"]!=null && ds.Tables[0].Rows[0]["Day30Flag"].ToString()!="")
				{
					model.Day30Flag=int.Parse(ds.Tables[0].Rows[0]["Day30Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Day31Flag"]!=null && ds.Tables[0].Rows[0]["Day31Flag"].ToString()!="")
				{
					model.Day31Flag=int.Parse(ds.Tables[0].Rows[0]["Day31Flag"].ToString());
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
			strSql.Append("select DayFlagID,DayFlagCode,Note,Day1Flag,Day2Flag,Day3Flag,Day4Flag,Day5Flag,Day6Flag,Day7Flag,Day8Flag,Day9Flag,Day10Flag,Day11Flag,Day12Flag,Day13Flag,Day14Flag,Day15Flag,Day16Flag,Day17Flag,Day18Flag,Day19Flag,Day20Flag,Day21Flag,Day22Flag,Day23Flag,Day24Flag,Day25Flag,Day26Flag,Day27Flag,Day28Flag,Day29Flag,Day30Flag,Day31Flag ");
			strSql.Append(" FROM BUY_DAYFLAG ");
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
			strSql.Append(" DayFlagID,DayFlagCode,Note,Day1Flag,Day2Flag,Day3Flag,Day4Flag,Day5Flag,Day6Flag,Day7Flag,Day8Flag,Day9Flag,Day10Flag,Day11Flag,Day12Flag,Day13Flag,Day14Flag,Day15Flag,Day16Flag,Day17Flag,Day18Flag,Day19Flag,Day20Flag,Day21Flag,Day22Flag,Day23Flag,Day24Flag,Day25Flag,Day26Flag,Day27Flag,Day28Flag,Day29Flag,Day30Flag,Day31Flag ");
			strSql.Append(" FROM BUY_DAYFLAG ");
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
			strSql.Append("select count(1) FROM BUY_DAYFLAG ");
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
				strSql.Append("order by T.DayFlagID desc");
			}
			strSql.Append(")AS Row, T.*  from BUY_DAYFLAG T ");
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
			parameters[0].Value = "BUY_DAYFLAG";
			parameters[1].Value = "DayFlagID";
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

