using System;
using System.Data;
using System.Collections.Generic;

namespace Edge.Security.Manager
{
	/// <summary>
	/// Lan_List
	/// </summary>
	public partial class Lan_List
	{
        private readonly Edge.Security.Data.Lan_List dal = new Edge.Security.Data.Lan_List();
		public Lan_List()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Edge.Security.Model.Lan_List model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Edge.Security.Model.Lan_List model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Edge.Security.Model.Lan_List GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Edge.Security.Model.Lan_List GetModelByCache(int ID)
		{
			
			string CacheKey = "Lan_ListModel-" + ID;
			object objModel = Edge.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Edge.Common.ConfigHelper.GetConfigInt("ModelCache");
						Edge.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Edge.Security.Model.Lan_List)objModel;
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
		public List<Edge.Security.Model.Lan_List> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Edge.Security.Model.Lan_List> DataTableToList(DataTable dt)
        {
            List<Edge.Security.Model.Lan_List> modelList = new List<Edge.Security.Model.Lan_List>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Edge.Security.Model.Lan_List model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Edge.Security.Model.Lan_List();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Lan"] != null && dt.Rows[n]["Lan"].ToString() != "")
                    {
                        model.Lan = dt.Rows[n]["Lan"].ToString();
                    }
                    if (dt.Rows[n]["LanDesc"] != null && dt.Rows[n]["LanDesc"].ToString() != "")
                    {
                        model.LanDesc = dt.Rows[n]["LanDesc"].ToString();
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
        /// 获取分页总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

		#endregion  Method
	}
}

