using System;
using System.Data;
using System.Collections.Generic;
using Edge.Messages.Model;
namespace Edge.Messages.Manager
{
	/// <summary>
	/// DialogMessage_Lan
	/// </summary>
	public partial class DialogMessage_Lan
	{
		private readonly Edge.Messages.Data.DialogMessage_Lan dal=new Edge.Messages.Data.DialogMessage_Lan();
		public DialogMessage_Lan()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TAPCode)
		{
			return dal.Exists(TAPCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Edge.Messages.Model.DialogMessage_Lan model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.Messages.Model.DialogMessage_Lan model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string TAPCode)
		{
			
			return dal.Delete(TAPCode);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TAPCodelist )
		{
			return dal.DeleteList(TAPCodelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.Messages.Model.DialogMessage_Lan GetModel(string TAPCode)
		{
			
			return dal.GetModel(TAPCode);
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
		public List<Edge.Messages.Model.DialogMessage_Lan> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.Messages.Model.DialogMessage_Lan> DataTableToList(DataTable dt)
		{
			List<Edge.Messages.Model.DialogMessage_Lan> modelList = new List<Edge.Messages.Model.DialogMessage_Lan>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.Messages.Model.DialogMessage_Lan model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.Messages.Model.DialogMessage_Lan();
					if(dt.Rows[n]["TAPCode"]!=null && dt.Rows[n]["TAPCode"].ToString()!="")
					{
					model.TAPCode=dt.Rows[n]["TAPCode"].ToString();
					}
					if(dt.Rows[n]["Message"]!=null && dt.Rows[n]["Message"].ToString()!="")
					{
					model.Message=dt.Rows[n]["Message"].ToString();
					}
					if(dt.Rows[n]["Lan"]!=null && dt.Rows[n]["Lan"].ToString()!="")
					{
					model.Lan=dt.Rows[n]["Lan"].ToString();
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

