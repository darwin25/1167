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
	/// 卡订货单明细。
	///表中brandID
	/// </summary>
	public partial class Ord_CardOrderForm_D
	{
		private readonly IOrd_CardOrderForm_D dal=DataAccess.CreateOrd_CardOrderForm_D();
		public Ord_CardOrderForm_D()
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
		public bool Exists(int CardGradeID,int KeyID)
		{
			return dal.Exists(CardGradeID,KeyID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.SVA.Model.Ord_CardOrderForm_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.Ord_CardOrderForm_D model)
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
		public bool Delete(int CardGradeID,int KeyID)
		{
			
			return dal.Delete(CardGradeID,KeyID);
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
		public Edge.SVA.Model.Ord_CardOrderForm_D GetModel(int KeyID)
		{
			
			return dal.GetModel(KeyID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.Ord_CardOrderForm_D GetModelByCache(int KeyID)
		{
			
			string CacheKey = "Ord_CardOrderForm_DModel-" + KeyID;
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
			return (Edge.SVA.Model.Ord_CardOrderForm_D)objModel;
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
		public List<Edge.SVA.Model.Ord_CardOrderForm_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.Ord_CardOrderForm_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.Ord_CardOrderForm_D> modelList = new List<Edge.SVA.Model.Ord_CardOrderForm_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.Ord_CardOrderForm_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.Ord_CardOrderForm_D();
					if(dt.Rows[n]["KeyID"]!=null && dt.Rows[n]["KeyID"].ToString()!="")
					{
						model.KeyID=int.Parse(dt.Rows[n]["KeyID"].ToString());
					}
					if(dt.Rows[n]["CardOrderFormNumber"]!=null && dt.Rows[n]["CardOrderFormNumber"].ToString()!="")
					{
					model.CardOrderFormNumber=dt.Rows[n]["CardOrderFormNumber"].ToString();
					}
					if(dt.Rows[n]["BrandID"]!=null && dt.Rows[n]["BrandID"].ToString()!="")
					{
						model.BrandID=int.Parse(dt.Rows[n]["BrandID"].ToString());
					}
					if(dt.Rows[n]["CardTypeID"]!=null && dt.Rows[n]["CardTypeID"].ToString()!="")
					{
						model.CardTypeID=int.Parse(dt.Rows[n]["CardTypeID"].ToString());
					}
					if(dt.Rows[n]["CardGradeID"]!=null && dt.Rows[n]["CardGradeID"].ToString()!="")
					{
						model.CardGradeID=int.Parse(dt.Rows[n]["CardGradeID"].ToString());
					}
					if(dt.Rows[n]["CardQty"]!=null && dt.Rows[n]["CardQty"].ToString()!="")
					{
						model.CardQty=int.Parse(dt.Rows[n]["CardQty"].ToString());
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

