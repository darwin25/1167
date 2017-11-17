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
	/// 店铺类型表
	/// </summary>
	public partial class SVA_ValueAdjust_H
	{
		private readonly ISVA_ValueAdjust_H dal=DataAccess.CreateSVA_ValueAdjust_H();
		public SVA_ValueAdjust_H()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Number)
		{
			return dal.Exists(Number);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.SVA_ValueAdjust_H model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.SVA_ValueAdjust_H model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Number)
		{
			
			return dal.Delete(Number);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Numberlist )
		{
			return dal.DeleteList(Numberlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.SVA_ValueAdjust_H GetModel(string Number)
		{
			
			return dal.GetModel(Number);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.SVA_ValueAdjust_H GetModelByCache(string Number)
		{
			
			string CacheKey = "SVA_ValueAdjust_HModel-" + Number;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Number);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.SVA_ValueAdjust_H)objModel;
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
		public List<Edge.SVA.Model.SVA_ValueAdjust_H> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.SVA_ValueAdjust_H> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.SVA_ValueAdjust_H> modelList = new List<Edge.SVA.Model.SVA_ValueAdjust_H>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.SVA_ValueAdjust_H model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.SVA_ValueAdjust_H();
					if(dt.Rows[n]["Number"]!=null && dt.Rows[n]["Number"].ToString()!="")
					{
					model.Number=dt.Rows[n]["Number"].ToString();
					}
					if(dt.Rows[n]["RefTxnNo"]!=null && dt.Rows[n]["RefTxnNo"].ToString()!="")
					{
					model.RefTxnNo=dt.Rows[n]["RefTxnNo"].ToString();
					}
					if(dt.Rows[n]["TxnDate"]!=null && dt.Rows[n]["TxnDate"].ToString()!="")
					{
						model.TxnDate=DateTime.Parse(dt.Rows[n]["TxnDate"].ToString());
					}
					if(dt.Rows[n]["ShopID"]!=null && dt.Rows[n]["ShopID"].ToString()!="")
					{
					model.ShopID=dt.Rows[n]["ShopID"].ToString();
					}
					if(dt.Rows[n]["ServerID"]!=null && dt.Rows[n]["ServerID"].ToString()!="")
					{
					model.ServerID=dt.Rows[n]["ServerID"].ToString();
					}
					if(dt.Rows[n]["POSID"]!=null && dt.Rows[n]["POSID"].ToString()!="")
					{
					model.POSID=dt.Rows[n]["POSID"].ToString();
					}
					if(dt.Rows[n]["Note"]!=null && dt.Rows[n]["Note"].ToString()!="")
					{
					model.Note=dt.Rows[n]["Note"].ToString();
					}
					if(dt.Rows[n]["Amount"]!=null && dt.Rows[n]["Amount"].ToString()!="")
					{
						model.Amount=decimal.Parse(dt.Rows[n]["Amount"].ToString());
					}
					if(dt.Rows[n]["TotalAmt"]!=null && dt.Rows[n]["TotalAmt"].ToString()!="")
					{
						model.TotalAmt=decimal.Parse(dt.Rows[n]["TotalAmt"].ToString());
					}
					if(dt.Rows[n]["CardCount"]!=null && dt.Rows[n]["CardCount"].ToString()!="")
					{
						model.CardCount=int.Parse(dt.Rows[n]["CardCount"].ToString());
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
					model.Status=dt.Rows[n]["Status"].ToString();
					}
					if(dt.Rows[n]["ApproveOn"]!=null && dt.Rows[n]["ApproveOn"].ToString()!="")
					{
						model.ApproveOn=DateTime.Parse(dt.Rows[n]["ApproveOn"].ToString());
					}
					if(dt.Rows[n]["ApproveBy"]!=null && dt.Rows[n]["ApproveBy"].ToString()!="")
					{
					model.ApproveBy=dt.Rows[n]["ApproveBy"].ToString();
					}
					if(dt.Rows[n]["CreatedOn"]!=null && dt.Rows[n]["CreatedOn"].ToString()!="")
					{
						model.CreatedOn=DateTime.Parse(dt.Rows[n]["CreatedOn"].ToString());
					}
					if(dt.Rows[n]["CreatedBy"]!=null && dt.Rows[n]["CreatedBy"].ToString()!="")
					{
					model.CreatedBy=dt.Rows[n]["CreatedBy"].ToString();
					}
					if(dt.Rows[n]["UpdatedOn"]!=null && dt.Rows[n]["UpdatedOn"].ToString()!="")
					{
						model.UpdatedOn=DateTime.Parse(dt.Rows[n]["UpdatedOn"].ToString());
					}
					if(dt.Rows[n]["UpdatedBy"]!=null && dt.Rows[n]["UpdatedBy"].ToString()!="")
					{
					model.UpdatedBy=dt.Rows[n]["UpdatedBy"].ToString();
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

