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
	/// 货品细节描述。（分语
	/// </summary>
	public partial class BUY_ProductParticulars
	{
		private readonly IBUY_ProductParticulars dal=DataAccess.CreateBUY_ProductParticulars();
		public BUY_ProductParticulars()
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
		public bool Exists(string ProdCode,int LanguageID)
		{
			return dal.Exists(ProdCode,LanguageID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_ProductParticulars model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_ProductParticulars model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ProdCode,int LanguageID)
		{
			
			return dal.Delete(ProdCode,LanguageID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_ProductParticulars GetModel(string ProdCode,int LanguageID)
		{
			
			return dal.GetModel(ProdCode,LanguageID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_ProductParticulars GetModelByCache(string ProdCode,int LanguageID)
		{
			
			string CacheKey = "BUY_ProductParticularsModel-" + ProdCode+LanguageID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProdCode,LanguageID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_ProductParticulars)objModel;
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
		public List<Edge.SVA.Model.BUY_ProductParticulars> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_ProductParticulars> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_ProductParticulars> modelList = new List<Edge.SVA.Model.BUY_ProductParticulars>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_ProductParticulars model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_ProductParticulars();
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["LanguageID"]!=null && dt.Rows[n]["LanguageID"].ToString()!="")
					{
						model.LanguageID=int.Parse(dt.Rows[n]["LanguageID"].ToString());
					}
					if(dt.Rows[n]["ProdFunction"]!=null && dt.Rows[n]["ProdFunction"].ToString()!="")
					{
					model.ProdFunction=dt.Rows[n]["ProdFunction"].ToString();
					}
					if(dt.Rows[n]["ProdIngredients"]!=null && dt.Rows[n]["ProdIngredients"].ToString()!="")
					{
					model.ProdIngredients=dt.Rows[n]["ProdIngredients"].ToString();
					}
					if(dt.Rows[n]["ProdInstructions"]!=null && dt.Rows[n]["ProdInstructions"].ToString()!="")
					{
					model.ProdInstructions=dt.Rows[n]["ProdInstructions"].ToString();
					}
					if(dt.Rows[n]["PackDesc"]!=null && dt.Rows[n]["PackDesc"].ToString()!="")
					{
					model.PackDesc=dt.Rows[n]["PackDesc"].ToString();
					}
					if(dt.Rows[n]["PackUnit"]!=null && dt.Rows[n]["PackUnit"].ToString()!="")
					{
					model.PackUnit=dt.Rows[n]["PackUnit"].ToString();
					}
					if(dt.Rows[n]["Memo1"]!=null && dt.Rows[n]["Memo1"].ToString()!="")
					{
					model.Memo1=dt.Rows[n]["Memo1"].ToString();
					}
					if(dt.Rows[n]["Memo2"]!=null && dt.Rows[n]["Memo2"].ToString()!="")
					{
					model.Memo2=dt.Rows[n]["Memo2"].ToString();
					}
					if(dt.Rows[n]["Memo3"]!=null && dt.Rows[n]["Memo3"].ToString()!="")
					{
					model.Memo3=dt.Rows[n]["Memo3"].ToString();
					}
					if(dt.Rows[n]["Memo4"]!=null && dt.Rows[n]["Memo4"].ToString()!="")
					{
					model.Memo4=dt.Rows[n]["Memo4"].ToString();
					}
					if(dt.Rows[n]["Memo5"]!=null && dt.Rows[n]["Memo5"].ToString()!="")
					{
					model.Memo5=dt.Rows[n]["Memo5"].ToString();
					}
					if(dt.Rows[n]["Memo6"]!=null && dt.Rows[n]["Memo6"].ToString()!="")
					{
					model.Memo6=dt.Rows[n]["Memo6"].ToString();
					}
					if(dt.Rows[n]["MemoTitle1"]!=null && dt.Rows[n]["MemoTitle1"].ToString()!="")
					{
					model.MemoTitle1=dt.Rows[n]["MemoTitle1"].ToString();
					}
					if(dt.Rows[n]["MemoTitle2"]!=null && dt.Rows[n]["MemoTitle2"].ToString()!="")
					{
					model.MemoTitle2=dt.Rows[n]["MemoTitle2"].ToString();
					}
					if(dt.Rows[n]["MemoTitle3"]!=null && dt.Rows[n]["MemoTitle3"].ToString()!="")
					{
					model.MemoTitle3=dt.Rows[n]["MemoTitle3"].ToString();
					}
					if(dt.Rows[n]["MemoTitle4"]!=null && dt.Rows[n]["MemoTitle4"].ToString()!="")
					{
					model.MemoTitle4=dt.Rows[n]["MemoTitle4"].ToString();
					}
					if(dt.Rows[n]["MemoTitle5"]!=null && dt.Rows[n]["MemoTitle5"].ToString()!="")
					{
					model.MemoTitle5=dt.Rows[n]["MemoTitle5"].ToString();
					}
					if(dt.Rows[n]["MemoTitle6"]!=null && dt.Rows[n]["MemoTitle6"].ToString()!="")
					{
					model.MemoTitle6=dt.Rows[n]["MemoTitle6"].ToString();
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

