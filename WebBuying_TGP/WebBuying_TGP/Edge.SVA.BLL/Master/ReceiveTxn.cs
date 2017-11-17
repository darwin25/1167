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
	/// 接收到的操作指令记录
	/// </summary>
	public partial class ReceiveTxn
	{
		private readonly IReceiveTxn dal=DataAccess.CreateReceiveTxn();
		public ReceiveTxn()
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
		public int  Add(Edge.SVA.Model.ReceiveTxn model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.ReceiveTxn model)
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
		public Edge.SVA.Model.ReceiveTxn GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.ReceiveTxn GetModelByCache(int KeyID)
		{
			
			string CacheKey = "ReceiveTxnModel-" + KeyID;
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
			return (Edge.SVA.Model.ReceiveTxn)objModel;
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
		public List<Edge.SVA.Model.ReceiveTxn> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.ReceiveTxn> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.ReceiveTxn> modelList = new List<Edge.SVA.Model.ReceiveTxn>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.ReceiveTxn model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.ReceiveTxn();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["StoreCode"]!=null && dt.Rows[n]["StoreCode"].ToString()!="")
					{
					model.StoreCode=dt.Rows[n]["StoreCode"].ToString();
					}
					if(dt.Rows[n]["ServerCode"]!=null && dt.Rows[n]["ServerCode"].ToString()!="")
					{
					model.ServerCode=dt.Rows[n]["ServerCode"].ToString();
					}
					if(dt.Rows[n]["RegisterCode"]!=null && dt.Rows[n]["RegisterCode"].ToString()!="")
					{
					model.RegisterCode=dt.Rows[n]["RegisterCode"].ToString();
					}
					if(dt.Rows[n]["TxnNoSN"]!=null && dt.Rows[n]["TxnNoSN"].ToString()!="")
					{
					model.TxnNoSN=dt.Rows[n]["TxnNoSN"].ToString();
					}
					if(dt.Rows[n]["TxnNo"]!=null && dt.Rows[n]["TxnNo"].ToString()!="")
					{
					model.TxnNo=dt.Rows[n]["TxnNo"].ToString();
					}
					if(dt.Rows[n]["BusDate"]!=null && dt.Rows[n]["BusDate"].ToString()!="")
					{
						model.BusDate=DateTime.Parse(dt.Rows[n]["BusDate"].ToString());
					}
					if(dt.Rows[n]["TxnDate"]!=null && dt.Rows[n]["TxnDate"].ToString()!="")
					{
						model.TxnDate=DateTime.Parse(dt.Rows[n]["TxnDate"].ToString());
					}
					if(dt.Rows[n]["CardNumber"]!=null && dt.Rows[n]["CardNumber"].ToString()!="")
					{
					model.CardNumber=dt.Rows[n]["CardNumber"].ToString();
					}
					if(dt.Rows[n]["OprID"]!=null && dt.Rows[n]["OprID"].ToString()!="")
					{
						model.OprID=int.Parse(dt.Rows[n]["OprID"].ToString());
					}
					if(dt.Rows[n]["Amount"]!=null && dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
					}
					if(dt.Rows[n]["Points"]!=null && dt.Rows[n]["Points"].ToString()!="")
					{
						model.Points=int.Parse(dt.Rows[n]["Points"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["VoidKeyID"]!=null && dt.Rows[n]["VoidKeyID"].ToString()!="")
					{
						model.VoidKeyID=int.Parse(dt.Rows[n]["VoidKeyID"].ToString());
					}
					if(dt.Rows[n]["VoidTxnNo"]!=null && dt.Rows[n]["VoidTxnNo"].ToString()!="")
					{
					model.VoidTxnNo=dt.Rows[n]["VoidTxnNo"].ToString();
					}
					if(dt.Rows[n]["TenderID"]!=null && dt.Rows[n]["TenderID"].ToString()!="")
					{
						model.TenderID=int.Parse(dt.Rows[n]["TenderID"].ToString());
					}
					if(dt.Rows[n]["Additional"]!=null && dt.Rows[n]["Additional"].ToString()!="")
					{
					model.Additional=dt.Rows[n]["Additional"].ToString();
					}
					if(dt.Rows[n]["ApproveStatus"]!=null && dt.Rows[n]["ApproveStatus"].ToString()!="")
					{
					model.ApproveStatus=dt.Rows[n]["ApproveStatus"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["SecurityCode"]!=null && dt.Rows[n]["SecurityCode"].ToString()!="")
					{
					model.SecurityCode=dt.Rows[n]["SecurityCode"].ToString();
					}
					if(dt.Rows[n]["CreatedDate"]!=null && dt.Rows[n]["CreatedDate"].ToString()!="")
					{
						model.CreatedDate=DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
					}
					if(dt.Rows[n]["UpdatedDate"]!=null && dt.Rows[n]["UpdatedDate"].ToString()!="")
					{
						model.UpdatedDate=DateTime.Parse(dt.Rows[n]["UpdatedDate"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
					model.CreatedBy=dt.Rows[n]["CreatedBy"].ToString();
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
					model.UpdatedBy=dt.Rows[n]["UpdatedBy"].ToString();
					}
					if(dt.Rows[n]["Approvedby"]!=null && dt.Rows[n]["Approvedby"].ToString()!="")
					{
					model.Approvedby=dt.Rows[n]["Approvedby"].ToString();
					}
					if(dt.Rows[n]["ApprovedDate"]!=null && dt.Rows[n]["ApprovedDate"].ToString()!="")
					{
						model.ApprovedDate=DateTime.Parse(dt.Rows[n]["ApprovedDate"].ToString());
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

