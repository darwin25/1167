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
	/// 产品尺寸属性。
	///P
	/// </summary>
	public partial class BUY_PRODUCTSIZE_Pending
	{
		private readonly IBUY_PRODUCTSIZE_Pending dal=DataAccess.CreateBUY_PRODUCTSIZE_Pending();
		public BUY_PRODUCTSIZE_Pending()
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
		public bool Exists(string ProductSizeCode,int ProductSizeID)
		{
			return dal.Exists(ProductSizeCode,ProductSizeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProductSizeID)
		{
			
			return dal.Delete(ProductSizeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProductSizeCode,int ProductSizeID)
		{
			
			return dal.Delete(ProductSizeCode,ProductSizeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProductSizeIDlist )
		{
			return dal.DeleteList(ProductSizeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCTSIZE_Pending GetModel(int ProductSizeID)
		{
			
			return dal.GetModel(ProductSizeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCTSIZE_Pending GetModelByCache(int ProductSizeID)
		{
			
			string CacheKey = "BUY_PRODUCTSIZE_PendingModel-" + ProductSizeID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductSizeID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_PRODUCTSIZE_Pending)objModel;
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
		public List<Edge.SVA.Model.BUY_PRODUCTSIZE_Pending> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PRODUCTSIZE_Pending> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PRODUCTSIZE_Pending> modelList = new List<Edge.SVA.Model.BUY_PRODUCTSIZE_Pending>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PRODUCTSIZE_Pending model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PRODUCTSIZE_Pending();
					if(dt.Rows[n]["ProductSizeID"]!=null && dt.Rows[n]["ProductSizeID"].ToString()!="")
					{
						model.ProductSizeID=int.Parse(dt.Rows[n]["ProductSizeID"].ToString());
					}
					if(dt.Rows[n]["ProductSizeCode"]!=null && dt.Rows[n]["ProductSizeCode"].ToString()!="")
					{
					model.ProductSizeCode=dt.Rows[n]["ProductSizeCode"].ToString();
					}
					if(dt.Rows[n]["ProductSizeType"]!=null && dt.Rows[n]["ProductSizeType"].ToString()!="")
					{
					model.ProductSizeType=dt.Rows[n]["ProductSizeType"].ToString();
					}
					if(dt.Rows[n]["ProductSizeName1"]!=null && dt.Rows[n]["ProductSizeName1"].ToString()!="")
					{
					model.ProductSizeName1=dt.Rows[n]["ProductSizeName1"].ToString();
					}
					if(dt.Rows[n]["ProductSizeName2"]!=null && dt.Rows[n]["ProductSizeName2"].ToString()!="")
					{
					model.ProductSizeName2=dt.Rows[n]["ProductSizeName2"].ToString();
					}
					if(dt.Rows[n]["ProductSizeName3"]!=null && dt.Rows[n]["ProductSizeName3"].ToString()!="")
					{
					model.ProductSizeName3=dt.Rows[n]["ProductSizeName3"].ToString();
					}
					if(dt.Rows[n]["ProductSizeNote"]!=null && dt.Rows[n]["ProductSizeNote"].ToString()!="")
					{
					model.ProductSizeNote=dt.Rows[n]["ProductSizeNote"].ToString();
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

