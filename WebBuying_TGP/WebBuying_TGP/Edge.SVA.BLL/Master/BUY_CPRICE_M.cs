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
	/// BUY_CPRICE
	/// </summary>
	public partial class BUY_CPRICE_M
	{
		private readonly IBUY_CPRICE_M dal=DataAccess.CreateBUY_CPRICE_M();
		public BUY_CPRICE_M()
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
		public int  Add(Edge.SVA.Model.BUY_CPRICE_M model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_CPRICE_M model)
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
		public Edge.SVA.Model.BUY_CPRICE_M GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_CPRICE_M GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_CPRICE_MModel-" + KeyID;
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
			return (Edge.SVA.Model.BUY_CPRICE_M)objModel;
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
		public List<Edge.SVA.Model.BUY_CPRICE_M> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_CPRICE_M> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_CPRICE_M> modelList = new List<Edge.SVA.Model.BUY_CPRICE_M>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_CPRICE_M model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_CPRICE_M();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["CPriceCode"]!=null && dt.Rows[n]["CPriceCode"].ToString()!="")
					{
					model.CPriceCode=dt.Rows[n]["CPriceCode"].ToString();
					}
					if(dt.Rows[n]["ProdCode"]!=null && dt.Rows[n]["ProdCode"].ToString()!="")
					{
					model.ProdCode=dt.Rows[n]["ProdCode"].ToString();
					}
					if(dt.Rows[n]["VendorCode"]!=null && dt.Rows[n]["VendorCode"].ToString()!="")
					{
					model.VendorCode=dt.Rows[n]["VendorCode"].ToString();
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["StoreGroupCode"]!=null && dt.Rows[n]["StoreGroupCode"].ToString()!="")
					{
					model.StoreGroupCode=dt.Rows[n]["StoreGroupCode"].ToString();
					}
					if(dt.Rows[n]["CurrencyCode"]!=null && dt.Rows[n]["CurrencyCode"].ToString()!="")
					{
					model.CurrencyCode=dt.Rows[n]["CurrencyCode"].ToString();
					}
					if(dt.Rows[n]["StartDate"]!=null && dt.Rows[n]["StartDate"].ToString()!="")
					{
						model.StartDate=DateTime.Parse(dt.Rows[n]["StartDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["CPriceGrossCost"]!=null && dt.Rows[n]["CPriceGrossCost"].ToString()!="")
					{
						model.CPriceGrossCost=decimal.Parse(dt.Rows[n]["CPriceGrossCost"].ToString());
					}
					if(dt.Rows[n]["CPriceNetCost"]!=null && dt.Rows[n]["CPriceNetCost"].ToString()!="")
					{
						model.CPriceNetCost=decimal.Parse(dt.Rows[n]["CPriceNetCost"].ToString());
					}
					if(dt.Rows[n]["CPriceDisc1"]!=null && dt.Rows[n]["CPriceDisc1"].ToString()!="")
					{
						model.CPriceDisc1=decimal.Parse(dt.Rows[n]["CPriceDisc1"].ToString());
					}
					if(dt.Rows[n]["CPriceDisc2"]!=null && dt.Rows[n]["CPriceDisc2"].ToString()!="")
					{
						model.CPriceDisc2=decimal.Parse(dt.Rows[n]["CPriceDisc2"].ToString());
					}
					if(dt.Rows[n]["CPriceDisc3"]!=null && dt.Rows[n]["CPriceDisc3"].ToString()!="")
					{
						model.CPriceDisc3=decimal.Parse(dt.Rows[n]["CPriceDisc3"].ToString());
					}
					if(dt.Rows[n]["CPriceDisc4"]!=null && dt.Rows[n]["CPriceDisc4"].ToString()!="")
					{
						model.CPriceDisc4=decimal.Parse(dt.Rows[n]["CPriceDisc4"].ToString());
					}
					if(dt.Rows[n]["CPriceBuy"]!=null && dt.Rows[n]["CPriceBuy"].ToString()!="")
					{
						model.CPriceBuy=decimal.Parse(dt.Rows[n]["CPriceBuy"].ToString());
					}
					if(dt.Rows[n]["CPriceGet"]!=null && dt.Rows[n]["CPriceGet"].ToString()!="")
					{
						model.CPriceGet=decimal.Parse(dt.Rows[n]["CPriceGet"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["ApproveOn"]!=null && dt.Rows[n]["ApproveOn"].ToString()!="")
					{
						model.ApproveOn=DateTime.Parse(dt.Rows[n]["ApproveOn"].ToString());
					}
					if(dt.Rows[n]["ApproveBy"]!=null && dt.Rows[n]["ApproveBy"].ToString()!="")
					{
						model.ApproveBy=int.Parse(dt.Rows[n]["ApproveBy"].ToString());
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

