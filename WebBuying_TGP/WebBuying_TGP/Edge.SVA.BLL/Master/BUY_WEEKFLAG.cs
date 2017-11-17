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
	/// 周标志表
	/// </summary>
	public partial class BUY_WEEKFLAG
	{
		private readonly IBUY_WEEKFLAG dal=DataAccess.CreateBUY_WEEKFLAG();
		public BUY_WEEKFLAG()
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
		public bool Exists(string WeekFlagCode,int WeekFlagID)
		{
			return dal.Exists(WeekFlagCode,WeekFlagID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_WEEKFLAG model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_WEEKFLAG model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int WeekFlagID)
		{
			
			return dal.Delete(WeekFlagID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string WeekFlagCode,int WeekFlagID)
		{
			
			return dal.Delete(WeekFlagCode,WeekFlagID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string WeekFlagIDlist )
		{
			return dal.DeleteList(WeekFlagIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_WEEKFLAG GetModel(int WeekFlagID)
		{
			
			return dal.GetModel(WeekFlagID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_WEEKFLAG GetModelByCache(int WeekFlagID)
		{
			
			string CacheKey = "BUY_WEEKFLAGModel-" + WeekFlagID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(WeekFlagID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_WEEKFLAG)objModel;
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
		public List<Edge.SVA.Model.BUY_WEEKFLAG> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_WEEKFLAG> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_WEEKFLAG> modelList = new List<Edge.SVA.Model.BUY_WEEKFLAG>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_WEEKFLAG model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_WEEKFLAG();
					if(dt.Rows[n]["WeekFlagID"]!=null && dt.Rows[n]["WeekFlagID"].ToString()!="")
					{
						model.WeekFlagID=int.Parse(dt.Rows[n]["WeekFlagID"].ToString());
					}
					if(dt.Rows[n]["WeekFlagCode"]!=null && dt.Rows[n]["WeekFlagCode"].ToString()!="")
					{
					model.WeekFlagCode=dt.Rows[n]["WeekFlagCode"].ToString();
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["SundayFlag"]!=null && dt.Rows[n]["SundayFlag"].ToString()!="")
					{
						model.SundayFlag=int.Parse(dt.Rows[n]["SundayFlag"].ToString());
					}
					if(dt.Rows[n]["MondayFlag"]!=null && dt.Rows[n]["MondayFlag"].ToString()!="")
					{
						model.MondayFlag=int.Parse(dt.Rows[n]["MondayFlag"].ToString());
					}
					if(dt.Rows[n]["TuesdayFlag"]!=null && dt.Rows[n]["TuesdayFlag"].ToString()!="")
					{
						model.TuesdayFlag=int.Parse(dt.Rows[n]["TuesdayFlag"].ToString());
					}
					if(dt.Rows[n]["WednesdayFlag"]!=null && dt.Rows[n]["WednesdayFlag"].ToString()!="")
					{
						model.WednesdayFlag=int.Parse(dt.Rows[n]["WednesdayFlag"].ToString());
					}
					if(dt.Rows[n]["ThursdayFlag"]!=null && dt.Rows[n]["ThursdayFlag"].ToString()!="")
					{
						model.ThursdayFlag=int.Parse(dt.Rows[n]["ThursdayFlag"].ToString());
					}
					if(dt.Rows[n]["FridayFlag"]!=null && dt.Rows[n]["FridayFlag"].ToString()!="")
					{
						model.FridayFlag=int.Parse(dt.Rows[n]["FridayFlag"].ToString());
					}
					if(dt.Rows[n]["SaturdayFlag"]!=null && dt.Rows[n]["SaturdayFlag"].ToString()!="")
					{
						model.SaturdayFlag=int.Parse(dt.Rows[n]["SaturdayFlag"].ToString());
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

