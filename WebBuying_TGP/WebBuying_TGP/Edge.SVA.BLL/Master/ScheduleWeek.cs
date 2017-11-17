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
	/// 销售单主表（字段暂定）
	///表中会员部分
	/// </summary>
	public partial class ScheduleWeek
	{
		private readonly IScheduleWeek dal=DataAccess.CreateScheduleWeek();
		public ScheduleWeek()
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
		public bool Exists(int Seq)
		{
			return dal.Exists(Seq);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.ScheduleWeek model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.ScheduleWeek model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Seq)
		{
			
			return dal.Delete(Seq);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Seqlist )
		{
			return dal.DeleteList(Seqlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.ScheduleWeek GetModel(int Seq)
		{
			
			return dal.GetModel(Seq);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.ScheduleWeek GetModelByCache(int Seq)
		{
			
			string CacheKey = "ScheduleWeekModel-" + Seq;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Seq);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.ScheduleWeek)objModel;
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
		public List<Edge.SVA.Model.ScheduleWeek> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.ScheduleWeek> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.ScheduleWeek> modelList = new List<Edge.SVA.Model.ScheduleWeek>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.ScheduleWeek model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.ScheduleWeek();
					if(dt.Rows[n]["Seq"]!=null && dt.Rows[n]["Seq"].ToString()!="")
					{
						model.Seq=int.Parse(dt.Rows[n]["Seq"].ToString());
					}
					if(dt.Rows[n]["Mon"]!=null && dt.Rows[n]["Mon"].ToString()!="")
					{
						if((dt.Rows[n]["Mon"].ToString()=="1")||(dt.Rows[n]["Mon"].ToString().ToLower()=="true"))
						{
						model.Mon=true;
						}
						else
						{
							model.Mon=false;
						}
					}
					if(dt.Rows[n]["Tue"]!=null && dt.Rows[n]["Tue"].ToString()!="")
					{
						if((dt.Rows[n]["Tue"].ToString()=="1")||(dt.Rows[n]["Tue"].ToString().ToLower()=="true"))
						{
						model.Tue=true;
						}
						else
						{
							model.Tue=false;
						}
					}
					if(dt.Rows[n]["wed"]!=null && dt.Rows[n]["wed"].ToString()!="")
					{
						if((dt.Rows[n]["wed"].ToString()=="1")||(dt.Rows[n]["wed"].ToString().ToLower()=="true"))
						{
						model.wed=true;
						}
						else
						{
							model.wed=false;
						}
					}
					if(dt.Rows[n]["thu"]!=null && dt.Rows[n]["thu"].ToString()!="")
					{
						if((dt.Rows[n]["thu"].ToString()=="1")||(dt.Rows[n]["thu"].ToString().ToLower()=="true"))
						{
						model.thu=true;
						}
						else
						{
							model.thu=false;
						}
					}
					if(dt.Rows[n]["Fri"]!=null && dt.Rows[n]["Fri"].ToString()!="")
					{
						if((dt.Rows[n]["Fri"].ToString()=="1")||(dt.Rows[n]["Fri"].ToString().ToLower()=="true"))
						{
						model.Fri=true;
						}
						else
						{
							model.Fri=false;
						}
					}
					if(dt.Rows[n]["Sat"]!=null && dt.Rows[n]["Sat"].ToString()!="")
					{
						if((dt.Rows[n]["Sat"].ToString()=="1")||(dt.Rows[n]["Sat"].ToString().ToLower()=="true"))
						{
						model.Sat=true;
						}
						else
						{
							model.Sat=false;
						}
					}
					if(dt.Rows[n]["Sun"]!=null && dt.Rows[n]["Sun"].ToString()!="")
					{
						if((dt.Rows[n]["Sun"].ToString()=="1")||(dt.Rows[n]["Sun"].ToString().ToLower()=="true"))
						{
						model.Sun=true;
						}
						else
						{
							model.Sun=false;
						}
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, string filedOrder)
        {
            return dal.GetList(PageSize, PageIndex, strWhere, filedOrder);
        }
        ///<summary>
        ///获取分页总数
        ///</summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

