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
	public partial class Schedule
	{
		private readonly ISchedule dal=DataAccess.CreateSchedule();
		public Schedule()
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
		public int  Add(Edge.SVA.Model.Schedule model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Schedule model)
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
		public Edge.SVA.Model.Schedule GetModel(int Seq)
		{
			
			return dal.GetModel(Seq);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Schedule GetModelByCache(int Seq)
		{
			
			string CacheKey = "ScheduleModel-" + Seq;
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
			return (Edge.SVA.Model.Schedule)objModel;
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
		public List<Edge.SVA.Model.Schedule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Schedule> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Schedule> modelList = new List<Edge.SVA.Model.Schedule>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Schedule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Schedule();
					if(dt.Rows[n]["Seq"]!=null && dt.Rows[n]["Seq"].ToString()!="")
					{
						model.Seq=int.Parse(dt.Rows[n]["Seq"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["FreqType"]!=null && dt.Rows[n]["FreqType"].ToString()!="")
					{
						model.FreqType=int.Parse(dt.Rows[n]["FreqType"].ToString());
					}
					if(dt.Rows[n]["FreqValue"]!=null && dt.Rows[n]["FreqValue"].ToString()!="")
					{
						model.FreqValue=decimal.Parse(dt.Rows[n]["FreqValue"].ToString());
					}
					if(dt.Rows[n]["FreqAt"]!=null && dt.Rows[n]["FreqAt"].ToString()!="")
					{
						model.FreqAt=int.Parse(dt.Rows[n]["FreqAt"].ToString());
					}
					if(dt.Rows[n]["WeekSeq"]!=null && dt.Rows[n]["WeekSeq"].ToString()!="")
					{
						model.WeekSeq=int.Parse(dt.Rows[n]["WeekSeq"].ToString());
					}
					if(dt.Rows[n]["HappenTime"]!=null && dt.Rows[n]["HappenTime"].ToString()!="")
					{
						model.HappenTime=DateTime.Parse(dt.Rows[n]["HappenTime"].ToString());
					}
					if(dt.Rows[n]["BeginDate"]!=null && dt.Rows[n]["BeginDate"].ToString()!="")
					{
						model.BeginDate=DateTime.Parse(dt.Rows[n]["BeginDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["Valid"]!=null && dt.Rows[n]["Valid"].ToString()!="")
					{
						if((dt.Rows[n]["Valid"].ToString()=="1")||(dt.Rows[n]["Valid"].ToString().ToLower()=="true"))
						{
						model.Valid=true;
						}
						else
						{
							model.Valid=false;
						}
					}
					if(dt.Rows[n]["LastCheckDate"]!=null && dt.Rows[n]["LastCheckDate"].ToString()!="")
					{
						model.LastCheckDate=DateTime.Parse(dt.Rows[n]["LastCheckDate"].ToString());
					}
					if(dt.Rows[n]["Message"]!=null && dt.Rows[n]["Message"].ToString()!="")
					{
					model.Message=dt.Rows[n]["Message"].ToString();
					}
					if(dt.Rows[n]["MsgType"]!=null && dt.Rows[n]["MsgType"].ToString()!="")
					{
						model.MsgType=int.Parse(dt.Rows[n]["MsgType"].ToString());
					}
					if(dt.Rows[n]["QueryID"]!=null && dt.Rows[n]["QueryID"].ToString()!="")
					{
						model.QueryID=int.Parse(dt.Rows[n]["QueryID"].ToString());
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

