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
	/// 交易的结算信息表
	/// </summary>
	public partial class BUY_SETTLEMENT
	{
		private readonly IBUY_SETTLEMENT dal=DataAccess.CreateBUY_SETTLEMENT();
		public BUY_SETTLEMENT()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SettlementCode)
		{
			return dal.Exists(SettlementCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_SETTLEMENT model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_SETTLEMENT model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SettlementCode)
		{
			
			return dal.Delete(SettlementCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SettlementCodelist )
		{
			return dal.DeleteList(SettlementCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_SETTLEMENT GetModel(string SettlementCode)
		{
			
			return dal.GetModel(SettlementCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_SETTLEMENT GetModelByCache(string SettlementCode)
		{
			
			string CacheKey = "BUY_SETTLEMENTModel-" + SettlementCode;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SettlementCode);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_SETTLEMENT)objModel;
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
		public List<Edge.SVA.Model.BUY_SETTLEMENT> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_SETTLEMENT> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_SETTLEMENT> modelList = new List<Edge.SVA.Model.BUY_SETTLEMENT>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_SETTLEMENT model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_SETTLEMENT();
					if(dt.Rows[n]["SettlementCode"]!=null && dt.Rows[n]["SettlementCode"].ToString()!="")
					{
					model.SettlementCode=dt.Rows[n]["SettlementCode"].ToString();
					}
					if(dt.Rows[n]["SettlementDate"]!=null && dt.Rows[n]["SettlementDate"].ToString()!="")
					{
						model.SettlementDate=DateTime.Parse(dt.Rows[n]["SettlementDate"].ToString());
					}
					if(dt.Rows[n]["SettlementTotal"]!=null && dt.Rows[n]["SettlementTotal"].ToString()!="")
					{
						model.SettlementTotal=decimal.Parse(dt.Rows[n]["SettlementTotal"].ToString());
					}
					if(dt.Rows[n]["SettlementNetTotal"]!=null && dt.Rows[n]["SettlementNetTotal"].ToString()!="")
					{
						model.SettlementNetTotal=decimal.Parse(dt.Rows[n]["SettlementNetTotal"].ToString());
					}
					if(dt.Rows[n]["NoOfTxn"]!=null && dt.Rows[n]["NoOfTxn"].ToString()!="")
					{
						model.NoOfTxn=int.Parse(dt.Rows[n]["NoOfTxn"].ToString());
					}
					if(dt.Rows[n]["BankInDate"]!=null && dt.Rows[n]["BankInDate"].ToString()!="")
					{
						model.BankInDate=DateTime.Parse(dt.Rows[n]["BankInDate"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
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

