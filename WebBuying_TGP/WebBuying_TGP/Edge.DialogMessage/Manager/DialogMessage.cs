using System;
using System.Data;
using System.Collections.Generic;
using Edge.Messages.Model;
namespace Edge.Messages.Manager
{
	/// <summary>
	/// DialogMessage
	/// </summary>
	public partial class DialogMessage
	{
		private readonly Edge.Messages.Data.DialogMessage dal=new Edge.Messages.Data.DialogMessage();
		public DialogMessage()
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
		public bool Add(Edge.Messages.Model.DialogMessage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.Messages.Model.DialogMessage model)
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
		public Edge.Messages.Model.DialogMessage GetModel(string TAPCode)
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
		public List<Edge.Messages.Model.DialogMessage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Edge.Messages.Model.DialogMessage> DataTableToList(DataTable dt)
		{
			List<Edge.Messages.Model.DialogMessage> modelList = new List<Edge.Messages.Model.DialogMessage>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Edge.Messages.Model.DialogMessage model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Edge.Messages.Model.DialogMessage();
					if(dt.Rows[n]["TAPCode"]!=null && dt.Rows[n]["TAPCode"].ToString()!="")
					{
					model.TAPCode=dt.Rows[n]["TAPCode"].ToString();
					}
					if(dt.Rows[n]["OriginalCode"]!=null && dt.Rows[n]["OriginalCode"].ToString()!="")
					{
					model.OriginalCode=dt.Rows[n]["OriginalCode"].ToString();
					}
					if(dt.Rows[n]["Message"]!=null && dt.Rows[n]["Message"].ToString()!="")
					{
					model.Message=dt.Rows[n]["Message"].ToString();
					}
					if(dt.Rows[n]["Project"]!=null && dt.Rows[n]["Project"].ToString()!="")
					{
					model.Project=dt.Rows[n]["Project"].ToString();
					}
					if(dt.Rows[n]["Product"]!=null && dt.Rows[n]["Product"].ToString()!="")
					{
					model.Product=dt.Rows[n]["Product"].ToString();
					}
					if(dt.Rows[n]["ModifiedBy"]!=null && dt.Rows[n]["ModifiedBy"].ToString()!="")
					{
					model.ModifiedBy=dt.Rows[n]["ModifiedBy"].ToString();
					}
					if(dt.Rows[n]["AddDate"]!=null && dt.Rows[n]["AddDate"].ToString()!="")
					{
						model.AddDate=DateTime.Parse(dt.Rows[n]["AddDate"].ToString());
					}
					if(dt.Rows[n]["MessageIconDisplay"]!=null && dt.Rows[n]["MessageIconDisplay"].ToString()!="")
					{
						if((dt.Rows[n]["MessageIconDisplay"].ToString()=="1")||(dt.Rows[n]["MessageIconDisplay"].ToString().ToLower()=="true"))
						{
						model.MessageIconDisplay=true;
						}
						else
						{
							model.MessageIconDisplay=false;
						}
					}
					if(dt.Rows[n]["ButtonDisplay"]!=null && dt.Rows[n]["ButtonDisplay"].ToString()!="")
					{
						if((dt.Rows[n]["ButtonDisplay"].ToString()=="1")||(dt.Rows[n]["ButtonDisplay"].ToString().ToLower()=="true"))
						{
						model.ButtonDisplay=true;
						}
						else
						{
							model.ButtonDisplay=false;
						}
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

