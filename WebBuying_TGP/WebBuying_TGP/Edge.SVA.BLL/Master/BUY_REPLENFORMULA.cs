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
	/// 自动补货公式信息表
	///（根据销售货品统计每天的销售平均数
    /// 创建人:Lisa
    /// 创建时间：2016-07-13
	/// </summary>
	public partial class BUY_REPLENFORMULA
	{
		private readonly IBUY_REPLENFORMULA dal=DataAccess.CreateBUY_REPLENFORMULA();
		public BUY_REPLENFORMULA()
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
		public bool Exists(string ReplenFormulaCode,int ReplenFormulaID)
		{
			return dal.Exists(ReplenFormulaCode,ReplenFormulaID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.BUY_REPLENFORMULA model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_REPLENFORMULA model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ReplenFormulaID)
		{
			
			return dal.Delete(ReplenFormulaID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ReplenFormulaCode,int ReplenFormulaID)
		{
			
			return dal.Delete(ReplenFormulaCode,ReplenFormulaID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ReplenFormulaIDlist )
		{
			return dal.DeleteList(ReplenFormulaIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_REPLENFORMULA GetModel(int ReplenFormulaID)
		{
			
			return dal.GetModel(ReplenFormulaID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_REPLENFORMULA GetModelByCache(int ReplenFormulaID)
		{
			
			string CacheKey = "BUY_REPLENFORMULAModel-" + ReplenFormulaID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ReplenFormulaID);
					if (objModel != null)
					{
                        int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_REPLENFORMULA)objModel;
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
		public List<Edge.SVA.Model.BUY_REPLENFORMULA> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_REPLENFORMULA> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_REPLENFORMULA> modelList = new List<Edge.SVA.Model.BUY_REPLENFORMULA>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_REPLENFORMULA model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_REPLENFORMULA();
					if(dt.Rows[n]["ReplenFormulaID"]!=null && dt.Rows[n]["ReplenFormulaID"].ToString()!="")
					{
						model.ReplenFormulaID=int.Parse(dt.Rows[n]["ReplenFormulaID"].ToString());
					}
					if(dt.Rows[n]["ReplenFormulaCode"]!=null && dt.Rows[n]["ReplenFormulaCode"].ToString()!="")
					{
					model.ReplenFormulaCode=dt.Rows[n]["ReplenFormulaCode"].ToString();
					}
					if(dt.Rows[n]["Description"]!=null && dt.Rows[n]["Description"].ToString()!="")
					{
					model.Description=dt.Rows[n]["Description"].ToString();
					}
					if(dt.Rows[n]["PreDefineDOC"]!=null && dt.Rows[n]["PreDefineDOC"].ToString()!="")
					{
						model.PreDefineDOC=int.Parse(dt.Rows[n]["PreDefineDOC"].ToString());
					}
					if(dt.Rows[n]["RunningStockDOC"]!=null && dt.Rows[n]["RunningStockDOC"].ToString()!="")
					{
						model.RunningStockDOC=int.Parse(dt.Rows[n]["RunningStockDOC"].ToString());
					}
					if(dt.Rows[n]["OrderRoundUpQty"]!=null && dt.Rows[n]["OrderRoundUpQty"].ToString()!="")
					{
						model.OrderRoundUpQty=int.Parse(dt.Rows[n]["OrderRoundUpQty"].ToString());
					}
					if(dt.Rows[n]["AVGDailySalesPeriod"]!=null && dt.Rows[n]["AVGDailySalesPeriod"].ToString()!="")
					{
						model.AVGDailySalesPeriod=int.Parse(dt.Rows[n]["AVGDailySalesPeriod"].ToString());
					}
					if(dt.Rows[n]["Quotation"]!=null && dt.Rows[n]["Quotation"].ToString()!="")
					{
						model.Quotation=int.Parse(dt.Rows[n]["Quotation"].ToString());
					}
					if(dt.Rows[n]["Deposited"]!=null && dt.Rows[n]["Deposited"].ToString()!="")
					{
						model.Deposited=int.Parse(dt.Rows[n]["Deposited"].ToString());
					}
					if(dt.Rows[n]["AdvSales"]!=null && dt.Rows[n]["AdvSales"].ToString()!="")
					{
						model.AdvSales=int.Parse(dt.Rows[n]["AdvSales"].ToString());
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

