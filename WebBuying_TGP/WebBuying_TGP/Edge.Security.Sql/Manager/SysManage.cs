using System.Data;
using Edge.Security.Model;
using Edge.Security.Data;
namespace Edge.Security.Manager
{
	/// <summary>
	/// SysManage 的摘要说明。
	/// </summary>
	public class SysManage
	{
        //从工厂里面创建产品类的数据访问对象
        Edge.Security.Data.SysManage dal = new Edge.Security.Data.SysManage();

		public SysManage()
		{
        }

        #region 基本方法
        public int AddTreeNode(SysNode node)
		{			
			return dal.AddTreeNode(node);
		}
		public void UpdateNode(SysNode node)
		{			
			dal.UpdateNode(node);
		}
		public void DelTreeNode(int nodeid)
		{			
			dal.DelTreeNode(nodeid);
		}

        public void DelTreeNodes(int nodeId)
        {
            dal.DelTreeNodes(nodeId);
        }


		public DataSet GetTreeList(string strWhere)
		{			
			return dal.GetTreeList(strWhere);
		}

        public DataSet GetTreeListByLan(string strWhere,string lan)
        {
            return dal.GetTreeListByLan(strWhere,lan);
        }
        
		public SysNode GetNode(int NodeID)
		{			
			return dal.GetNode(NodeID);
        }

        public SysNode GetNodeByLan(int NodeID,string lan)
        {
            return dal.GetNodeByLan(NodeID,lan);
        }

        public int GetNoteCount(string strWhere)
        {
            return dal.GetNodeCount(strWhere);
        }

        public SysNode GetNodeByUrl(string url,string lan)
        {
            return dal.GetNodeByUrl(url, lan);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetNotePageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetNodePageList(pageSize,currentPage,strWhere,filedOrder);
        }

        #endregion

        #region 日志管理
        public void AddLog(string time,string loginfo,string Particular)
		{			
			dal.AddLog(time,loginfo,Particular);
		}
		public void DelOverdueLog(int days)
		{						
			dal.DelOverdueLog(days);
		}
		public void DeleteLog(string Idlist)
		{			
			string str="";
			if(Idlist.Trim()!="")
			{
				str=" ID in ("+Idlist+")";
			}
			dal.DeleteLog(str);
		}
		public void DeleteLog(string timestart,string timeend)
		{			
			string str=" datetime>'"+timestart+"' and datetime<'"+timeend+"'";
			dal.DeleteLog(str);
		}
		public DataSet GetLogs(string strWhere)
		{			
			return dal.GetLogs(strWhere);
		}
		public DataRow GetLog(string ID)
		{			
			return dal.GetLog(ID);
        }

        public int GetLogCount(string strWhere)
        {
            return dal.GetLogCount(strWhere);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetLogPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            return dal.GetLogPageList(pageSize, currentPage, strWhere, filedOrder);
        }

        #endregion


    }
}
