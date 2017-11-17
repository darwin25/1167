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
	/// 货品包装设置
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCTPACKAGE_Pending
	{
		private readonly IBUY_PRODUCTPACKAGE_Pending dal=DataAccess.CreateBUY_PRODUCTPACKAGE_Pending();
		public BUY_PRODUCTPACKAGE_Pending()
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
		public bool Exists(string PackageSizeCode,int PackageSizeID)
		{
			return dal.Exists(PackageSizeCode,PackageSizeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PackageSizeID)
		{
			
			return dal.Delete(PackageSizeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string PackageSizeCode,int PackageSizeID)
		{
			
			return dal.Delete(PackageSizeCode,PackageSizeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PackageSizeIDlist )
		{
			return dal.DeleteList(PackageSizeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending GetModel(int PackageSizeID)
		{
			
			return dal.GetModel(PackageSizeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending GetModelByCache(int PackageSizeID)
		{
			
			string CacheKey = "BUY_PRODUCTPACKAGE_PendingModel-" + PackageSizeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PackageSizeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending)objModel;
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
		public List<Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending> modelList = new List<Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PRODUCTPACKAGE_Pending();
					if(dt.Rows[n]["PackageSizeID"]!=null && dt.Rows[n]["PackageSizeID"].ToString()!="")
					{
						model.PackageSizeID=int.Parse(dt.Rows[n]["PackageSizeID"].ToString());
					}
					if(dt.Rows[n]["PackageSizeCode"]!=null && dt.Rows[n]["PackageSizeCode"].ToString()!="")
					{
					model.PackageSizeCode=dt.Rows[n]["PackageSizeCode"].ToString();
					}
					if(dt.Rows[n]["PackageSizeDesc1"]!=null && dt.Rows[n]["PackageSizeDesc1"].ToString()!="")
					{
					model.PackageSizeDesc1=dt.Rows[n]["PackageSizeDesc1"].ToString();
					}
					if(dt.Rows[n]["PackageSizeDesc2"]!=null && dt.Rows[n]["PackageSizeDesc2"].ToString()!="")
					{
					model.PackageSizeDesc2=dt.Rows[n]["PackageSizeDesc2"].ToString();
					}
					if(dt.Rows[n]["PackageSizeDesc3"]!=null && dt.Rows[n]["PackageSizeDesc3"].ToString()!="")
					{
					model.PackageSizeDesc3=dt.Rows[n]["PackageSizeDesc3"].ToString();
					}
					if(dt.Rows[n]["PackageSizeType"]!=null && dt.Rows[n]["PackageSizeType"].ToString()!="")
					{
						model.PackageSizeType=int.Parse(dt.Rows[n]["PackageSizeType"].ToString());
					}
					if(dt.Rows[n]["PackageSizeUnit"]!=null && dt.Rows[n]["PackageSizeUnit"].ToString()!="")
					{
					model.PackageSizeUnit=dt.Rows[n]["PackageSizeUnit"].ToString();
					}
					if(dt.Rows[n]["PackageSizeQty"]!=null && dt.Rows[n]["PackageSizeQty"].ToString()!="")
					{
						model.PackageSizeQty=int.Parse(dt.Rows[n]["PackageSizeQty"].ToString());
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

