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
	/// 交易单单号维护表。
	/// </summary>
	public partial class BUY_REFNO
	{
		private readonly IBUY_REFNO dal=DataAccess.CreateBUY_REFNO();
		public BUY_REFNO()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string Code)
		{
			return dal.Exists(Code);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.SVA.Model.BUY_REFNO model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.SVA.Model.BUY_REFNO model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Code)
		{
			
			return dal.Delete(Code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Codelist )
		{
			return dal.DeleteList(Codelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.SVA.Model.BUY_REFNO GetModel(string Code)
		{
			
			return dal.GetModel(Code);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.SVA.Model.BUY_REFNO GetModelByCache(string Code)
		{
			
			string CacheKey = "BUY_REFNOModel-" + Code;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Code);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.SVA.Model.BUY_REFNO)objModel;
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
		public List<Edge.SVA.Model.BUY_REFNO> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.SVA.Model.BUY_REFNO> DataTableToList(DataTable dt)
		{
			List<Edge.SVA.Model.BUY_REFNO> modelList = new List<Edge.SVA.Model.BUY_REFNO>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.SVA.Model.BUY_REFNO model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.SVA.Model.BUY_REFNO();
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
					}
					if(dt.Rows[n]["RefDesc"]!=null && dt.Rows[n]["RefDesc"].ToString()!="")
					{
					model.RefDesc=dt.Rows[n]["RefDesc"].ToString();
					}
					if(dt.Rows[n]["Header"]!=null && dt.Rows[n]["Header"].ToString()!="")
					{
					model.Header=dt.Rows[n]["Header"].ToString();
					}
					if(dt.Rows[n]["Seq"]!=null && dt.Rows[n]["Seq"].ToString()!="")
					{
						model.Seq=int.Parse(dt.Rows[n]["Seq"].ToString());
					}
					if(dt.Rows[n]["Length"]!=null && dt.Rows[n]["Length"].ToString()!="")
					{
						model.Length=int.Parse(dt.Rows[n]["Length"].ToString());
					}
					if(dt.Rows[n]["Auto"]!=null && dt.Rows[n]["Auto"].ToString()!="")
					{
					model.Auto=dt.Rows[n]["Auto"].ToString();
					}
					if(dt.Rows[n]["Active"]!=null && dt.Rows[n]["Active"].ToString()!="")
					{
						model.Active=int.Parse(dt.Rows[n]["Active"].ToString());
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

