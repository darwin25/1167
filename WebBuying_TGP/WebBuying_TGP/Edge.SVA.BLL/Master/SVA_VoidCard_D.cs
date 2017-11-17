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
	public partial class SVA_VoidCard_D
	{
		private readonly ISVA_VoidCard_D dal=DataAccess.CreateSVA_VoidCard_D();
		public SVA_VoidCard_D()
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
		public bool Exists(string Number,int SeqNo)
		{
			return dal.Exists(Number,SeqNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.SVA_VoidCard_D model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.SVA_VoidCard_D model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Number,int SeqNo)
		{
			
			return dal.Delete(Number,SeqNo);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.SVA_VoidCard_D GetModel(string Number,int SeqNo)
		{
			
			return dal.GetModel(Number,SeqNo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.SVA_VoidCard_D GetModelByCache(string Number,int SeqNo)
		{
			
			string CacheKey = "SVA_VoidCard_DModel-" + Number+SeqNo;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Number,SeqNo);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.SVA_VoidCard_D)objModel;
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
		public List<Edge.SVA.Model.SVA_VoidCard_D> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.SVA_VoidCard_D> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.SVA_VoidCard_D> modelList = new List<Edge.SVA.Model.SVA_VoidCard_D>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.SVA_VoidCard_D model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.SVA_VoidCard_D();
					if(dt.Rows[n]["Number"]!=null && dt.Rows[n]["Number"].ToString()!="")
					{
					model.Number=dt.Rows[n]["Number"].ToString();
					}
					if(dt.Rows[n]["SeqNo"]!=null && dt.Rows[n]["SeqNo"].ToString()!="")
					{
						model.SeqNo=int.Parse(dt.Rows[n]["SeqNo"].ToString());
					}
					if(dt.Rows[n]["UID"]!=null && dt.Rows[n]["UID"].ToString()!="")
					{
					model.UID=dt.Rows[n]["UID"].ToString();
					}
					if(dt.Rows[n]["CardNo"]!=null && dt.Rows[n]["CardNo"].ToString()!="")
					{
					model.CardNo=dt.Rows[n]["CardNo"].ToString();
					}
					if(dt.Rows[n]["CardTypeID"]!=null && dt.Rows[n]["CardTypeID"].ToString()!="")
					{
					model.CardTypeID=dt.Rows[n]["CardTypeID"].ToString();
					}
					if(dt.Rows[n]["CardGradID"]!=null && dt.Rows[n]["CardGradID"].ToString()!="")
					{
					model.CardGradID=dt.Rows[n]["CardGradID"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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

