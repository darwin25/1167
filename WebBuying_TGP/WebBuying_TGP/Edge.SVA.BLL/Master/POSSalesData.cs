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
	/// 卡消费赚积分规则表
	/// </summary>
	public partial class POSSalesData
	{
		private readonly IPOSSalesData dal=DataAccess.CreatePOSSalesData();
		public POSSalesData()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SN)
		{
			return dal.Exists(SN);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.POSSalesData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.POSSalesData model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SN)
		{
			
			return dal.Delete(SN);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SNlist )
		{
			return dal.DeleteList(SNlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.POSSalesData GetModel(string SN)
		{
			
			return dal.GetModel(SN);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.POSSalesData GetModelByCache(string SN)
		{
			
			string CacheKey = "POSSalesDataModel-" + SN;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SN);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.POSSalesData)objModel;
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
		public List<Edge.SVA.Model.POSSalesData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.POSSalesData> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.POSSalesData> modelList = new List<Edge.SVA.Model.POSSalesData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.POSSalesData model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.POSSalesData();
					if(dt.Rows[n]["SN"]!=null && dt.Rows[n]["SN"].ToString()!="")
					{
					model.SN=dt.Rows[n]["SN"].ToString();
					}
					if(dt.Rows[n]["TxnNo"]!=null && dt.Rows[n]["TxnNo"].ToString()!="")
					{
					model.TxnNo=dt.Rows[n]["TxnNo"].ToString();
					}
					if(dt.Rows[n]["TxnType"]!=null && dt.Rows[n]["TxnType"].ToString()!="")
					{
					model.TxnType=dt.Rows[n]["TxnType"].ToString();
					}
					if(dt.Rows[n]["TxnAmount"]!=null && dt.Rows[n]["TxnAmount"].ToString()!="")
					{
						model.TxnAmount=decimal.Parse(dt.Rows[n]["TxnAmount"].ToString());
					}
					if(dt.Rows[n]["BusDate"]!=null && dt.Rows[n]["BusDate"].ToString()!="")
					{
						model.BusDate=DateTime.Parse(dt.Rows[n]["BusDate"].ToString());
					}
					if(dt.Rows[n]["TxnDate"]!=null && dt.Rows[n]["TxnDate"].ToString()!="")
					{
						model.TxnDate=DateTime.Parse(dt.Rows[n]["TxnDate"].ToString());
					}
					if(dt.Rows[n]["ImportDate"]!=null && dt.Rows[n]["ImportDate"].ToString()!="")
					{
						model.ImportDate=DateTime.Parse(dt.Rows[n]["ImportDate"].ToString());
					}
					if(dt.Rows[n]["OriginalTxnNo"]!=null && dt.Rows[n]["OriginalTxnNo"].ToString()!="")
					{
					model.OriginalTxnNo=dt.Rows[n]["OriginalTxnNo"].ToString();
					}
					if(dt.Rows[n]["CardID"]!=null && dt.Rows[n]["CardID"].ToString()!="")
					{
					model.CardID=dt.Rows[n]["CardID"].ToString();
					}
					if(dt.Rows[n]["StoreId"]!=null && dt.Rows[n]["StoreId"].ToString()!="")
					{
					model.StoreId=dt.Rows[n]["StoreId"].ToString();
					}
					if(dt.Rows[n]["ServerId"]!=null && dt.Rows[n]["ServerId"].ToString()!="")
					{
					model.ServerId=dt.Rows[n]["ServerId"].ToString();
					}
					if(dt.Rows[n]["PosId"]!=null && dt.Rows[n]["PosId"].ToString()!="")
					{
					model.PosId=dt.Rows[n]["PosId"].ToString();
					}
					if(dt.Rows[n]["SVACardNum"]!=null && dt.Rows[n]["SVACardNum"].ToString()!="")
					{
					model.SVACardNum=dt.Rows[n]["SVACardNum"].ToString();
					}
					if(dt.Rows[n]["CardType"]!=null && dt.Rows[n]["CardType"].ToString()!="")
					{
					model.CardType=dt.Rows[n]["CardType"].ToString();
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

