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
	/// OprID表。
	/// </summary>
	public partial class OperationTable
	{
		private readonly IOperationTable dal=DataAccess.CreateOperationTable();
		public OperationTable()
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
		public bool Exists(int OprID)
		{
			return dal.Exists(OprID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.OperationTable model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.OperationTable model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int OprID)
		{
			
			return dal.Delete(OprID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string OprIDlist )
		{
			return dal.DeleteList(OprIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.OperationTable GetModel(int OprID)
		{
			
			return dal.GetModel(OprID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.OperationTable GetModelByCache(int OprID)
		{
			
			string CacheKey = "OperationTableModel-" + OprID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(OprID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.OperationTable)objModel;
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
		public List<Edge.SVA.Model.OperationTable> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.OperationTable> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.OperationTable> modelList = new List<Edge.SVA.Model.OperationTable>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.OperationTable model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.OperationTable();
					if(dt.Rows[n]["OprID"]!=null && dt.Rows[n]["OprID"].ToString()!="")
					{
						model.OprID=int.Parse(dt.Rows[n]["OprID"].ToString());
					}
					if(dt.Rows[n]["OprIDDesc1"]!=null && dt.Rows[n]["OprIDDesc1"].ToString()!="")
					{
					model.OprIDDesc1=dt.Rows[n]["OprIDDesc1"].ToString();
					}
					if(dt.Rows[n]["OprIDDesc2"]!=null && dt.Rows[n]["OprIDDesc2"].ToString()!="")
					{
					model.OprIDDesc2=dt.Rows[n]["OprIDDesc2"].ToString();
					}
					if(dt.Rows[n]["OprIDDesc3"]!=null && dt.Rows[n]["OprIDDesc3"].ToString()!="")
					{
					model.OprIDDesc3=dt.Rows[n]["OprIDDesc3"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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

