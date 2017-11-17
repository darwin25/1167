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
	/// 月标志表
	/// </summary>
	public partial class BUY_MONTHFLAG
	{
		private readonly IBUY_MONTHFLAG dal=DataAccess.CreateBUY_MONTHFLAG();
		public BUY_MONTHFLAG()
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
		public bool Exists(string MonthFlagCode,int MonthFlagID)
		{
			return dal.Exists(MonthFlagCode,MonthFlagID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_MONTHFLAG model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_MONTHFLAG model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int MonthFlagID)
		{
			
			return dal.Delete(MonthFlagID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string MonthFlagCode,int MonthFlagID)
		{
			
			return dal.Delete(MonthFlagCode,MonthFlagID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string MonthFlagIDlist )
		{
			return dal.DeleteList(MonthFlagIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_MONTHFLAG GetModel(int MonthFlagID)
		{
			
			return dal.GetModel(MonthFlagID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_MONTHFLAG GetModelByCache(int MonthFlagID)
		{
			
			string CacheKey = "BUY_MONTHFLAGModel-" + MonthFlagID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(MonthFlagID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_MONTHFLAG)objModel;
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
		public List<Edge.SVA.Model.BUY_MONTHFLAG> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_MONTHFLAG> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_MONTHFLAG> modelList = new List<Edge.SVA.Model.BUY_MONTHFLAG>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_MONTHFLAG model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_MONTHFLAG();
					if(dt.Rows[n]["MonthFlagID"]!=null && dt.Rows[n]["MonthFlagID"].ToString()!="")
					{
						model.MonthFlagID=int.Parse(dt.Rows[n]["MonthFlagID"].ToString());
					}
					if(dt.Rows[n]["MonthFlagCode"]!=null && dt.Rows[n]["MonthFlagCode"].ToString()!="")
					{
					model.MonthFlagCode=dt.Rows[n]["MonthFlagCode"].ToString();
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["JanuaryFlag"]!=null && dt.Rows[n]["JanuaryFlag"].ToString()!="")
					{
						model.JanuaryFlag=int.Parse(dt.Rows[n]["JanuaryFlag"].ToString());
					}
					if(dt.Rows[n]["FebruaryFlag"]!=null && dt.Rows[n]["FebruaryFlag"].ToString()!="")
					{
						model.FebruaryFlag=int.Parse(dt.Rows[n]["FebruaryFlag"].ToString());
					}
					if(dt.Rows[n]["MarchFlag"]!=null && dt.Rows[n]["MarchFlag"].ToString()!="")
					{
						model.MarchFlag=int.Parse(dt.Rows[n]["MarchFlag"].ToString());
					}
					if(dt.Rows[n]["AprilFlag"]!=null && dt.Rows[n]["AprilFlag"].ToString()!="")
					{
						model.AprilFlag=int.Parse(dt.Rows[n]["AprilFlag"].ToString());
					}
					if(dt.Rows[n]["MayFlag"]!=null && dt.Rows[n]["MayFlag"].ToString()!="")
					{
						model.MayFlag=int.Parse(dt.Rows[n]["MayFlag"].ToString());
					}
					if(dt.Rows[n]["JuneFlag"]!=null && dt.Rows[n]["JuneFlag"].ToString()!="")
					{
						model.JuneFlag=int.Parse(dt.Rows[n]["JuneFlag"].ToString());
					}
					if(dt.Rows[n]["JulyFlag"]!=null && dt.Rows[n]["JulyFlag"].ToString()!="")
					{
						model.JulyFlag=int.Parse(dt.Rows[n]["JulyFlag"].ToString());
					}
					if(dt.Rows[n]["AugustFlag"]!=null && dt.Rows[n]["AugustFlag"].ToString()!="")
					{
						model.AugustFlag=int.Parse(dt.Rows[n]["AugustFlag"].ToString());
					}
					if(dt.Rows[n]["SeptemberFlag"]!=null && dt.Rows[n]["SeptemberFlag"].ToString()!="")
					{
						model.SeptemberFlag=int.Parse(dt.Rows[n]["SeptemberFlag"].ToString());
					}
					if(dt.Rows[n]["DecemberFlag"]!=null && dt.Rows[n]["DecemberFlag"].ToString()!="")
					{
						model.DecemberFlag=int.Parse(dt.Rows[n]["DecemberFlag"].ToString());
					}
					if(dt.Rows[n]["OctoberFlag"]!=null && dt.Rows[n]["OctoberFlag"].ToString()!="")
					{
						model.OctoberFlag=int.Parse(dt.Rows[n]["OctoberFlag"].ToString());
					}
					if(dt.Rows[n]["NovemberFlag"]!=null && dt.Rows[n]["NovemberFlag"].ToString()!="")
					{
						model.NovemberFlag=int.Parse(dt.Rows[n]["NovemberFlag"].ToString());
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

