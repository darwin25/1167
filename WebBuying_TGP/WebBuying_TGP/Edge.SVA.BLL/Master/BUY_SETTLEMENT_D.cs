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
	/// 结算表子表
	/// </summary>
	public partial class BUY_SETTLEMENT_D
	{
		private readonly IBUY_SETTLEMENT_D dal=DataAccess.CreateBUY_SETTLEMENT_D();
		public BUY_SETTLEMENT_D()
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
		public int  Add(Edge.SVA.Model.BUY_SETTLEMENT_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_SETTLEMENT_D model)
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
		public Edge.SVA.Model.BUY_SETTLEMENT_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_SETTLEMENT_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "BUY_SETTLEMENT_DModel-" + KeyID;
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
			return (Edge.SVA.Model.BUY_SETTLEMENT_D)objModel;
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
		public List<Edge.SVA.Model.BUY_SETTLEMENT_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_SETTLEMENT_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_SETTLEMENT_D> modelList = new List<Edge.SVA.Model.BUY_SETTLEMENT_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_SETTLEMENT_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_SETTLEMENT_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["SettlementCode"]!=null && dt.Rows[n]["SettlementCode"].ToString()!="")
					{
					model.SettlementCode=dt.Rows[n]["SettlementCode"].ToString();
					}
					if(dt.Rows[n]["TransNum"]!=null && dt.Rows[n]["TransNum"].ToString()!="")
					{
					model.TransNum=dt.Rows[n]["TransNum"].ToString();
					}
					if(dt.Rows[n]["SeqNum"]!=null && dt.Rows[n]["SeqNum"].ToString()!="")
					{
						model.SeqNum=int.Parse(dt.Rows[n]["SeqNum"].ToString());
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["Amount"]!=null && dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
					}
					if(dt.Rows[n]["NetAmount"]!=null && dt.Rows[n]["NetAmount"].ToString()!="")
					{
						model.NetAmount=decimal.Parse(dt.Rows[n]["NetAmount"].ToString());
					}
					if(dt.Rows[n]["CardNo"]!=null && dt.Rows[n]["CardNo"].ToString()!="")
					{
					model.CardNo=dt.Rows[n]["CardNo"].ToString();
					}
					if(dt.Rows[n]["CardType"]!=null && dt.Rows[n]["CardType"].ToString()!="")
					{
					model.CardType=dt.Rows[n]["CardType"].ToString();
					}
					if(dt.Rows[n]["ApprovalCode"]!=null && dt.Rows[n]["ApprovalCode"].ToString()!="")
					{
					model.ApprovalCode=dt.Rows[n]["ApprovalCode"].ToString();
					}
					if(dt.Rows[n]["BankCode"]!=null && dt.Rows[n]["BankCode"].ToString()!="")
					{
					model.BankCode=dt.Rows[n]["BankCode"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["SettleDate"]!=null && dt.Rows[n]["SettleDate"].ToString()!="")
					{
						model.SettleDate=DateTime.Parse(dt.Rows[n]["SettleDate"].ToString());
					}
					if(dt.Rows[n]["SettleBy"]!=null && dt.Rows[n]["SettleBy"].ToString()!="")
					{
					model.SettleBy=dt.Rows[n]["SettleBy"].ToString();
					}
					if(dt.Rows[n]["Installment"]!=null && dt.Rows[n]["Installment"].ToString()!="")
					{
						model.Installment=int.Parse(dt.Rows[n]["Installment"].ToString());
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

