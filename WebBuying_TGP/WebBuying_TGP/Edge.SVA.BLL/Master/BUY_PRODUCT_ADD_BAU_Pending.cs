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
	/// Bauhaus 货品
    /// 创建人：Lisa
    /// 创建时间：2016-08-08
	/// </summary>
	public partial class BUY_PRODUCT_ADD_BAU_Pending
	{
		private readonly IBUY_PRODUCT_ADD_BAU_Pending dal=DataAccess.CreateBUY_PRODUCT_ADD_BAU_Pending();
		public BUY_PRODUCT_ADD_BAU_Pending()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProdCode)
		{
			return dal.Exists(ProdCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending model)
		{
			return dal.Add(model);
		}

        public bool Add(string ProdCode)
        {
            return dal.Add(ProdCode);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdCode)
		{
			
			return dal.Delete(ProdCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProdCodelist )
		{
			return dal.DeleteList(ProdCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending GetModel(string ProdCode)
		{
			
			return dal.GetModel(ProdCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending GetModelByCache(string ProdCode)
		{
			
			string CacheKey = "BUY_PRODUCT_ADD_BAU_PendingModel-" + ProdCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProdCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending)objModel;
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
		public List<Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending> modelList = new List<Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PRODUCT_ADD_BAU_Pending();
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["Standard_Cost"]!=null && dt.Rows[n]["Standard_Cost"].ToString()!="")
					{
						model.Standard_Cost=decimal.Parse(dt.Rows[n]["Standard_Cost"].ToString());
					}
					if(dt.Rows[n]["Export_Cost"]!=null && dt.Rows[n]["Export_Cost"].ToString()!="")
					{
						model.Export_Cost=decimal.Parse(dt.Rows[n]["Export_Cost"].ToString());
					}
					if(dt.Rows[n]["AVG_Cost"]!=null && dt.Rows[n]["AVG_Cost"].ToString()!="")
					{
						model.AVG_Cost=decimal.Parse(dt.Rows[n]["AVG_Cost"].ToString());
					}
					if(dt.Rows[n]["MODEL"]!=null && dt.Rows[n]["MODEL"].ToString()!="")
					{
					model.MODEL=dt.Rows[n]["MODEL"].ToString();
					}
					if(dt.Rows[n]["SKU"]!=null && dt.Rows[n]["SKU"].ToString()!="")
					{
					model.SKU=dt.Rows[n]["SKU"].ToString();
					}
					if(dt.Rows[n]["YEAR"]!=null && dt.Rows[n]["YEAR"].ToString()!="")
					{
						model.YEAR=int.Parse(dt.Rows[n]["YEAR"].ToString());
					}
					if(dt.Rows[n]["REORDER_LEVEL"]!=null && dt.Rows[n]["REORDER_LEVEL"].ToString()!="")
					{
						model.REORDER_LEVEL=int.Parse(dt.Rows[n]["REORDER_LEVEL"].ToString());
					}
					if(dt.Rows[n]["HS_CODE"]!=null && dt.Rows[n]["HS_CODE"].ToString()!="")
					{
					model.HS_CODE=dt.Rows[n]["HS_CODE"].ToString();
					}
					if(dt.Rows[n]["COO"]!=null && dt.Rows[n]["COO"].ToString()!="")
					{
					model.COO=dt.Rows[n]["COO"].ToString();
					}
					if(dt.Rows[n]["SIZE_RANGE"]!=null && dt.Rows[n]["SIZE_RANGE"].ToString()!="")
					{
					model.SIZE_RANGE=dt.Rows[n]["SIZE_RANGE"].ToString();
					}
					if(dt.Rows[n]["DESIGNER"]!=null && dt.Rows[n]["DESIGNER"].ToString()!="")
					{
					model.DESIGNER=dt.Rows[n]["DESIGNER"].ToString();
					}
					if(dt.Rows[n]["BUYER"]!=null && dt.Rows[n]["BUYER"].ToString()!="")
					{
					model.BUYER=dt.Rows[n]["BUYER"].ToString();
					}
					if(dt.Rows[n]["MERCHANDISER"]!=null && dt.Rows[n]["MERCHANDISER"].ToString()!="")
					{
					model.MERCHANDISER=dt.Rows[n]["MERCHANDISER"].ToString();
					}
					if(dt.Rows[n]["RETIRE_DATE"]!=null && dt.Rows[n]["RETIRE_DATE"].ToString()!="")
					{
						model.RETIRE_DATE=DateTime.Parse(dt.Rows[n]["RETIRE_DATE"].ToString());
					}
					if(dt.Rows[n]["CompanyCode"]!=null && dt.Rows[n]["CompanyCode"].ToString()!="")
					{
					model.CompanyCode=dt.Rows[n]["CompanyCode"].ToString();
					}
					if(dt.Rows[n]["Material"]!=null && dt.Rows[n]["Material"].ToString()!="")
					{
					model.Material=dt.Rows[n]["Material"].ToString();
					}
					if(dt.Rows[n]["overview"]!=null && dt.Rows[n]["overview"].ToString()!="")
					{
					model.overview=dt.Rows[n]["overview"].ToString();
					}
					if(dt.Rows[n]["style"]!=null && dt.Rows[n]["style"].ToString()!="")
					{
					model.style=dt.Rows[n]["style"].ToString();
					}
					if(dt.Rows[n]["fabric_care"]!=null && dt.Rows[n]["fabric_care"].ToString()!="")
					{
					model.fabric_care=dt.Rows[n]["fabric_care"].ToString();
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

