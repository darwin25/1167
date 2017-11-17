using System;
using System.Data;
using System.Collections.Generic;
using Edge.Common;
using Edge.SVA.Model;
using Edge.SVA.DALFactory;
using Edge.SVA.IDAL;
namespace Edge.SVA.BLL
{
	/// <summary>
	/// 天标志表
	/// </summary>
	public partial class BUY_DAYFLAG
	{
		private readonly IBUY_DAYFLAG dal=DataAccess.CreateBUY_DAYFLAG();
		public BUY_DAYFLAG()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DayFlagCode,int DayFlagID)
		{
			return dal.Exists(DayFlagCode,DayFlagID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_DAYFLAG model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_DAYFLAG model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DayFlagID)
		{
			
			return dal.Delete(DayFlagID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DayFlagCode,int DayFlagID)
		{
			
			return dal.Delete(DayFlagCode,DayFlagID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DayFlagIDlist )
		{
			return dal.DeleteList(DayFlagIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_DAYFLAG GetModel(int DayFlagID)
		{
			
			return dal.GetModel(DayFlagID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_DAYFLAG GetModelByCache(int DayFlagID)
		{
			
			string CacheKey = "BUY_DAYFLAGModel-" + DayFlagID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DayFlagID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_DAYFLAG)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_DAYFLAG> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_DAYFLAG> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_DAYFLAG> modelList = new List<Edge.SVA.Model.BUY_DAYFLAG>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_DAYFLAG model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_DAYFLAG();
					if(dt.Rows[n]["DayFlagID"]!=null && dt.Rows[n]["DayFlagID"].ToString()!="")
					{
						model.DayFlagID=int.Parse(dt.Rows[n]["DayFlagID"].ToString());
					}
					if(dt.Rows[n]["DayFlagCode"]!=null && dt.Rows[n]["DayFlagCode"].ToString()!="")
					{
					model.DayFlagCode=dt.Rows[n]["DayFlagCode"].ToString();
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["Day1Flag"]!=null && dt.Rows[n]["Day1Flag"].ToString()!="")
					{
						model.Day1Flag=int.Parse(dt.Rows[n]["Day1Flag"].ToString());
					}
					if(dt.Rows[n]["Day2Flag"]!=null && dt.Rows[n]["Day2Flag"].ToString()!="")
					{
						model.Day2Flag=int.Parse(dt.Rows[n]["Day2Flag"].ToString());
					}
					if(dt.Rows[n]["Day3Flag"]!=null && dt.Rows[n]["Day3Flag"].ToString()!="")
					{
						model.Day3Flag=int.Parse(dt.Rows[n]["Day3Flag"].ToString());
					}
					if(dt.Rows[n]["Day4Flag"]!=null && dt.Rows[n]["Day4Flag"].ToString()!="")
					{
						model.Day4Flag=int.Parse(dt.Rows[n]["Day4Flag"].ToString());
					}
					if(dt.Rows[n]["Day5Flag"]!=null && dt.Rows[n]["Day5Flag"].ToString()!="")
					{
						model.Day5Flag=int.Parse(dt.Rows[n]["Day5Flag"].ToString());
					}
					if(dt.Rows[n]["Day6Flag"]!=null && dt.Rows[n]["Day6Flag"].ToString()!="")
					{
						model.Day6Flag=int.Parse(dt.Rows[n]["Day6Flag"].ToString());
					}
					if(dt.Rows[n]["Day7Flag"]!=null && dt.Rows[n]["Day7Flag"].ToString()!="")
					{
						model.Day7Flag=int.Parse(dt.Rows[n]["Day7Flag"].ToString());
					}
					if(dt.Rows[n]["Day8Flag"]!=null && dt.Rows[n]["Day8Flag"].ToString()!="")
					{
						model.Day8Flag=int.Parse(dt.Rows[n]["Day8Flag"].ToString());
					}
					if(dt.Rows[n]["Day9Flag"]!=null && dt.Rows[n]["Day9Flag"].ToString()!="")
					{
						model.Day9Flag=int.Parse(dt.Rows[n]["Day9Flag"].ToString());
					}
					if(dt.Rows[n]["Day10Flag"]!=null && dt.Rows[n]["Day10Flag"].ToString()!="")
					{
						model.Day10Flag=int.Parse(dt.Rows[n]["Day10Flag"].ToString());
					}
					if(dt.Rows[n]["Day11Flag"]!=null && dt.Rows[n]["Day11Flag"].ToString()!="")
					{
						model.Day11Flag=int.Parse(dt.Rows[n]["Day11Flag"].ToString());
					}
					if(dt.Rows[n]["Day12Flag"]!=null && dt.Rows[n]["Day12Flag"].ToString()!="")
					{
						model.Day12Flag=int.Parse(dt.Rows[n]["Day12Flag"].ToString());
					}
					if(dt.Rows[n]["Day13Flag"]!=null && dt.Rows[n]["Day13Flag"].ToString()!="")
					{
						model.Day13Flag=int.Parse(dt.Rows[n]["Day13Flag"].ToString());
					}
					if(dt.Rows[n]["Day14Flag"]!=null && dt.Rows[n]["Day14Flag"].ToString()!="")
					{
						model.Day14Flag=int.Parse(dt.Rows[n]["Day14Flag"].ToString());
					}
					if(dt.Rows[n]["Day15Flag"]!=null && dt.Rows[n]["Day15Flag"].ToString()!="")
					{
						model.Day15Flag=int.Parse(dt.Rows[n]["Day15Flag"].ToString());
					}
					if(dt.Rows[n]["Day16Flag"]!=null && dt.Rows[n]["Day16Flag"].ToString()!="")
					{
						model.Day16Flag=int.Parse(dt.Rows[n]["Day16Flag"].ToString());
					}
					if(dt.Rows[n]["Day17Flag"]!=null && dt.Rows[n]["Day17Flag"].ToString()!="")
					{
						model.Day17Flag=int.Parse(dt.Rows[n]["Day17Flag"].ToString());
					}
					if(dt.Rows[n]["Day18Flag"]!=null && dt.Rows[n]["Day18Flag"].ToString()!="")
					{
						model.Day18Flag=int.Parse(dt.Rows[n]["Day18Flag"].ToString());
					}
					if(dt.Rows[n]["Day19Flag"]!=null && dt.Rows[n]["Day19Flag"].ToString()!="")
					{
						model.Day19Flag=int.Parse(dt.Rows[n]["Day19Flag"].ToString());
					}
					if(dt.Rows[n]["Day20Flag"]!=null && dt.Rows[n]["Day20Flag"].ToString()!="")
					{
						model.Day20Flag=int.Parse(dt.Rows[n]["Day20Flag"].ToString());
					}
					if(dt.Rows[n]["Day21Flag"]!=null && dt.Rows[n]["Day21Flag"].ToString()!="")
					{
						model.Day21Flag=int.Parse(dt.Rows[n]["Day21Flag"].ToString());
					}
					if(dt.Rows[n]["Day22Flag"]!=null && dt.Rows[n]["Day22Flag"].ToString()!="")
					{
						model.Day22Flag=int.Parse(dt.Rows[n]["Day22Flag"].ToString());
					}
					if(dt.Rows[n]["Day23Flag"]!=null && dt.Rows[n]["Day23Flag"].ToString()!="")
					{
						model.Day23Flag=int.Parse(dt.Rows[n]["Day23Flag"].ToString());
					}
					if(dt.Rows[n]["Day24Flag"]!=null && dt.Rows[n]["Day24Flag"].ToString()!="")
					{
						model.Day24Flag=int.Parse(dt.Rows[n]["Day24Flag"].ToString());
					}
					if(dt.Rows[n]["Day25Flag"]!=null && dt.Rows[n]["Day25Flag"].ToString()!="")
					{
						model.Day25Flag=int.Parse(dt.Rows[n]["Day25Flag"].ToString());
					}
					if(dt.Rows[n]["Day26Flag"]!=null && dt.Rows[n]["Day26Flag"].ToString()!="")
					{
						model.Day26Flag=int.Parse(dt.Rows[n]["Day26Flag"].ToString());
					}
					if(dt.Rows[n]["Day27Flag"]!=null && dt.Rows[n]["Day27Flag"].ToString()!="")
					{
						model.Day27Flag=int.Parse(dt.Rows[n]["Day27Flag"].ToString());
					}
					if(dt.Rows[n]["Day28Flag"]!=null && dt.Rows[n]["Day28Flag"].ToString()!="")
					{
						model.Day28Flag=int.Parse(dt.Rows[n]["Day28Flag"].ToString());
					}
					if(dt.Rows[n]["Day29Flag"]!=null && dt.Rows[n]["Day29Flag"].ToString()!="")
					{
						model.Day29Flag=int.Parse(dt.Rows[n]["Day29Flag"].ToString());
					}
					if(dt.Rows[n]["Day30Flag"]!=null && dt.Rows[n]["Day30Flag"].ToString()!="")
					{
						model.Day30Flag=int.Parse(dt.Rows[n]["Day30Flag"].ToString());
					}
					if(dt.Rows[n]["Day31Flag"]!=null && dt.Rows[n]["Day31Flag"].ToString()!="")
					{
						model.Day31Flag=int.Parse(dt.Rows[n]["Day31Flag"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

