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
	/// store 和 st
	/// </summary>
	public partial class STAFFSTOREMAP
	{
		private readonly ISTAFFSTOREMAP dal=DataAccess.CreateSTAFFSTOREMAP();
		public STAFFSTOREMAP()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StaffID,int StoreID)
		{
			return dal.Exists(StaffID,StoreID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.STAFFSTOREMAP model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.STAFFSTOREMAP model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(int StaffID, int StoreID)
		{
			
			return dal.Delete(StaffID,StoreID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Edge.SVA.Model.STAFFSTOREMAP GetModel(int StaffID, int StoreID)
		{
			
			return dal.GetModel(StaffID,StoreID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Edge.SVA.Model.STAFFSTOREMAP GetModelByCache(int StaffID, int StoreID)
		{
			
			string CacheKey = "STAFFSTOREMAPModel-" + StaffID+StoreID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
                    objModel = dal.GetModel(StaffID, StoreID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.STAFFSTOREMAP)objModel;
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
		public List<Edge.SVA.Model.STAFFSTOREMAP> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.STAFFSTOREMAP> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.STAFFSTOREMAP> modelList = new List<Edge.SVA.Model.STAFFSTOREMAP>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.STAFFSTOREMAP model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.STAFFSTOREMAP();
                    if (dt.Rows[n]["StaffID"] != null && dt.Rows[n]["StaffID"].ToString() != "")
                    {
                        model.StaffID = int.Parse(dt.Rows[n]["StaffID"].ToString());
                    }
                    if (dt.Rows[n]["StoreID"] != null && dt.Rows[n]["StoreID"].ToString() != "")
                    {
                        model.StoreID = int.Parse(dt.Rows[n]["StoreID"].ToString());
                    }
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
						model.CreatedBy=int.Parse(dt.Rows[n]["CreatedBy"].ToString());
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
						model.UpdatedBy=int.Parse(dt.Rows[n]["UpdatedBy"].ToString());
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

