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
	/// 货品表
	/// </summary>
	public partial class Product
	{
		private readonly IProduct dal=DataAccess.CreateProduct();
		public Product()
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
		public bool Add(Edge.SVA.Model.Product model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Product model)
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
		public Edge.SVA.Model.Product GetModel(string ProdCode)
		{
			
			return dal.GetModel(ProdCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Product GetModelByCache(string ProdCode)
		{
			
			string CacheKey = "ProductModel-" + ProdCode;
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
			return (Edge.SVA.Model.Product)objModel;
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
		public List<Edge.SVA.Model.Product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Product> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Product> modelList = new List<Edge.SVA.Model.Product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Product model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Product();
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["ProdName1"]!=null && dt.Rows[n]["ProdName1"].ToString()!="")
					{
					model.ProdName1=dt.Rows[n]["ProdName1"].ToString();
					}
					if(dt.Rows[n]["ProdName2"]!=null && dt.Rows[n]["ProdName2"].ToString()!="")
					{
					model.ProdName2=dt.Rows[n]["ProdName2"].ToString();
					}
					if(dt.Rows[n]["ProdName3"]!=null && dt.Rows[n]["ProdName3"].ToString()!="")
					{
					model.ProdName3=dt.Rows[n]["ProdName3"].ToString();
					}
					if(dt.Rows[n]["DepartCode"]!=null && dt.Rows[n]["DepartCode"].ToString()!="")
					{
					model.DepartCode=dt.Rows[n]["DepartCode"].ToString();
					}
					if(dt.Rows[n]["NonSale"]!=null && dt.Rows[n]["NonSale"].ToString()!="")
					{
						model.NonSale=int.Parse(dt.Rows[n]["NonSale"].ToString());
					}
					if(dt.Rows[n]["ProdPicFile"]!=null && dt.Rows[n]["ProdPicFile"].ToString()!="")
					{
					model.ProdPicFile=dt.Rows[n]["ProdPicFile"].ToString();
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["ProdType"]!=null && dt.Rows[n]["ProdType"].ToString()!="")
					{
						model.ProdType=int.Parse(dt.Rows[n]["ProdType"].ToString());
					}
					if(dt.Rows[n]["ProdNote"]!=null && dt.Rows[n]["ProdNote"].ToString()!="")
					{
					model.ProdNote=dt.Rows[n]["ProdNote"].ToString();
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

