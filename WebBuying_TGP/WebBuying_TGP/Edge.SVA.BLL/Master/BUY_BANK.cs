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
	/// 银行表
	/// </summary>
	public partial class BUY_BANK
	{
		private readonly IBUY_BANK dal=DataAccess.CreateBUY_BANK();
		public BUY_BANK()
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
		public bool Exists(string BankCode,int BankID)
		{
			return dal.Exists(BankCode,BankID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_BANK model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_BANK model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BankID)
		{
			
			return dal.Delete(BankID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string BankCode,int BankID)
		{
			
			return dal.Delete(BankCode,BankID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BankIDlist )
		{
			return dal.DeleteList(BankIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_BANK GetModel(int BankID)
		{
			
			return dal.GetModel(BankID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_BANK GetModelByCache(int BankID)
		{
			
			string CacheKey = "BUY_BANKModel-" + BankID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BankID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_BANK)objModel;
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
		public List<Edge.SVA.Model.BUY_BANK> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_BANK> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_BANK> modelList = new List<Edge.SVA.Model.BUY_BANK>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_BANK model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_BANK();
					if(dt.Rows[n]["BankID"]!=null && dt.Rows[n]["BankID"].ToString()!="")
					{
						model.BankID=int.Parse(dt.Rows[n]["BankID"].ToString());
					}
					if(dt.Rows[n]["BankCode"]!=null && dt.Rows[n]["BankCode"].ToString()!="")
					{
					model.BankCode=dt.Rows[n]["BankCode"].ToString();
					}
					if(dt.Rows[n]["BankName1"]!=null && dt.Rows[n]["BankName1"].ToString()!="")
					{
					model.BankName1=dt.Rows[n]["BankName1"].ToString();
					}
					if(dt.Rows[n]["BankName2"]!=null && dt.Rows[n]["BankName2"].ToString()!="")
					{
					model.BankName2=dt.Rows[n]["BankName2"].ToString();
					}
					if(dt.Rows[n]["BankName3"]!=null && dt.Rows[n]["BankName3"].ToString()!="")
					{
					model.BankName3=dt.Rows[n]["BankName3"].ToString();
					}
					if(dt.Rows[n]["Commissionrate"]!=null && dt.Rows[n]["Commissionrate"].ToString()!="")
					{
						model.Commissionrate=decimal.Parse(dt.Rows[n]["Commissionrate"].ToString());
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

