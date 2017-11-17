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
	/// 货品图片
	/// </summary>
	public partial class BUY_PRODUCT_PIC
	{
		private readonly IBUY_PRODUCT_PIC dal=DataAccess.CreateBUY_PRODUCT_PIC();
		public BUY_PRODUCT_PIC()
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
		public bool Exists(int KeyID)
		{
			return dal.Exists(KeyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_PRODUCT_PIC model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_PRODUCT_PIC model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int KeyID)
		{
			
			return dal.Delete(KeyID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string KeyIDlist )
		{
			return dal.DeleteList(KeyIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_PIC GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_PRODUCT_PIC GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_PRODUCT_PICModel-" + KeyID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(KeyID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_PRODUCT_PIC)objModel;
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
		public List<Edge.SVA.Model.BUY_PRODUCT_PIC> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_PRODUCT_PIC> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_PRODUCT_PIC> modelList = new List<Edge.SVA.Model.BUY_PRODUCT_PIC>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_PRODUCT_PIC model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_PRODUCT_PIC();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["ProductThumbnailsFile"]!=null && dt.Rows[n]["ProductThumbnailsFile"].ToString()!="")
					{
					model.ProductThumbnailsFile=dt.Rows[n]["ProductThumbnailsFile"].ToString();
					}
					if(dt.Rows[n]["ProductFullPicFile"]!=null && dt.Rows[n]["ProductFullPicFile"].ToString()!="")
					{
					model.ProductFullPicFile=dt.Rows[n]["ProductFullPicFile"].ToString();
					}
					if(dt.Rows[n]["ProductPicNote1"]!=null && dt.Rows[n]["ProductPicNote1"].ToString()!="")
					{
					model.ProductPicNote1=dt.Rows[n]["ProductPicNote1"].ToString();
					}
					if(dt.Rows[n]["ProductPicNote2"]!=null && dt.Rows[n]["ProductPicNote2"].ToString()!="")
					{
					model.ProductPicNote2=dt.Rows[n]["ProductPicNote2"].ToString();
					}
					if(dt.Rows[n]["ProductPicNote3"]!=null && dt.Rows[n]["ProductPicNote3"].ToString()!="")
					{
					model.ProductPicNote3=dt.Rows[n]["ProductPicNote3"].ToString();
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

