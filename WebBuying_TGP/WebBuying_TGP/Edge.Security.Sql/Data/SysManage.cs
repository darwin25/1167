using System.Text;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Threading;
namespace Edge.Security.Data
{
    /// <summary>
    /// 系统菜单管理类。(普通SQL实现方式)
    /// </summary>
    public class SysManage
    {
        //在这里可以更换数据库,支持多数据库，支持采用加密方式实现
        //DbHelperSQLP DbHelperSQL = new DbHelperSQLP(PubConstant.GetConnectionString("ConnectionString2"));
        public SysManage()
        {
        }

        public int GetMaxId()
        {
            string strsql = "select max(NodeID)+1 from S_Tree";
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public int AddTreeNode(Edge.Security.Model.SysNode node)
        {
            node.NodeID = GetMaxId();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Tree(");
            strSql.Append("NodeID,Text,ParentID,Location,OrderID,comment,Url,PermissionID,ImageUrl,ModuleID,KeShiDM,KeshiPublic)");
            strSql.Append(" values (");
            strSql.Append("'" + node.NodeID + "',");
            strSql.Append("'" + node.Text + "',");
            strSql.Append("" + node.ParentID + ",");
            strSql.Append("'" + node.Location + "',");
            strSql.Append("" + node.OrderID + ",");
            strSql.Append("'" + node.Comment + "',");
            strSql.Append("'" + node.Url + "',");
            strSql.Append("" + node.PermissionID + ",");
            strSql.Append("'" + node.ImageUrl + "',");
            strSql.Append("'" + node.ModuleID + "',");
            strSql.Append("'" + node.KeShiDM + "',");
            strSql.Append("'" + node.KeshiPublic + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return node.NodeID;

        }

        public void UpdateNode(Edge.Security.Model.SysNode node)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update S_Tree set ");
            strSql.Append("Text='" + node.Text + "',");
            strSql.Append("ParentID=" + node.ParentID.ToString() + ",");
            strSql.Append("Location='" + node.Location + "',");
            strSql.Append("OrderID=" + node.OrderID + ",");
            strSql.Append("comment='" + node.Comment + "',");
            strSql.Append("Url='" + node.Url + "',");
            strSql.Append("PermissionID=" + node.PermissionID + ",");
            strSql.Append("ImageUrl='" + node.ImageUrl + "',");
            strSql.Append("ModuleID='" + node.ModuleID + "',");
            strSql.Append("KeShiDM='" + node.KeShiDM + "',");
            strSql.Append("KeshiPublic='" + node.KeshiPublic + "'");
            strSql.Append(" where NodeID=" + node.NodeID);
            DbHelperSQL.ExecuteSql(strSql.ToString());

        }

        public void DelTreeNode(int nodeid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Tree ");
            strSql.Append(" where NodeID=" + nodeid);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void DelTreeNodes(int nodeId)
        {

            string sql = string.Format("select NodeID from S_Tree where ParentID=" + nodeId + "");

            DataTable dt = DbHelperSQL.Query(sql.ToString()).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                DelTreeNodes(int.Parse(dt.Rows[i][0].ToString()));

            }

            string delsql = string.Format("delete from S_Tree where NodeID=" + nodeId + "");

            DbHelperSQL.ExecuteSql(delsql);
        }


        public DataSet GetTreeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Tree ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by parentid,orderid ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetTreeListByLan(string strWhere, string lan)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * from S_Tree ");
            strSql.Append("select t.NodeID,t.ParentID,t.ParentPath,t.Location,t.OrderID,t.comment,t.Url,t.PermissionID,t.imageurl,t.moduleid,t.keshidm,t.keshipublic, ");
            strSql.Append(" case when l.text is not null then l.text else t.text end as Text from S_Tree t left join Lan_S_Tree l on t.NodeID =l.NodeID and l.lan='" + lan + "'");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" order by parentid,orderid ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetNodeCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from S_Tree ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }
            return Convert.ToInt32(DbHelperSQL.GetCount(strSql.ToString()));
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetNodePageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int topNum = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top " + pageSize + " NodeID,Text,ParentID,ParentPath,Location,OrderID,comment,Url,PermissionID,ImageUrl,ModuleID,KeShiDM,KeshiPublic FROM S_Tree ");
            if (currentPage > 0)
            {
                strSql.Append(" where NodeID not in(select top " + topNum + " NodeID from S_Tree");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder + ")");
            }
            if (strWhere.Trim() != "")
            {
                if (currentPage > 0)
                {
                    strSql.Append(" and " + strWhere);
                }
                else
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            strSql.Append(" order by " + filedOrder);

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 得到菜单节点
        /// </summary>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public Edge.Security.Model.SysNode GetNode(int NodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Tree ");
            strSql.Append(" where NodeID=" + NodeID);
            Edge.Security.Model.SysNode node = new Edge.Security.Model.SysNode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                node.NodeID = int.Parse(ds.Tables[0].Rows[0]["NodeID"].ToString());
                node.Text = ds.Tables[0].Rows[0]["text"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    node.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                node.Location = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    node.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                node.Comment = ds.Tables[0].Rows[0]["comment"].ToString();
                node.Url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["PermissionID"].ToString() != "")
                {
                    node.PermissionID = int.Parse(ds.Tables[0].Rows[0]["PermissionID"].ToString());
                }
                node.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    node.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KeShiDM"].ToString() != "")
                {
                    node.KeShiDM = int.Parse(ds.Tables[0].Rows[0]["KeShiDM"].ToString());
                }
                node.KeshiPublic = ds.Tables[0].Rows[0]["KeshiPublic"].ToString();

                return node;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到菜单节点
        /// </summary>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public Edge.Security.Model.SysNode GetNodeByLan(int NodeID, string lan)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * from S_Tree ");
            strSql.Append("select t.NodeID,t.ParentID,t.ParentPath,t.Location,t.OrderID,t.comment,t.Url,t.PermissionID,t.imageurl,t.moduleid,t.keshidm,t.keshipublic, ");
            strSql.Append(" case when l.text is not null then l.text else t.text end as Text from S_Tree t left join Lan_S_Tree l on t.NodeID =l.NodeID and l.lan='" + lan + "'");
            strSql.Append(" where NodeID=" + NodeID);
            Edge.Security.Model.SysNode node = new Edge.Security.Model.SysNode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                node.NodeID = int.Parse(ds.Tables[0].Rows[0]["NodeID"].ToString());
                node.Text = ds.Tables[0].Rows[0]["text"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    node.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                node.Location = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    node.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                node.Comment = ds.Tables[0].Rows[0]["comment"].ToString();
                node.Url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["PermissionID"].ToString() != "")
                {
                    node.PermissionID = int.Parse(ds.Tables[0].Rows[0]["PermissionID"].ToString());
                }
                node.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    node.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["KeShiDM"].ToString() != "")
                {
                    node.KeShiDM = int.Parse(ds.Tables[0].Rows[0]["KeShiDM"].ToString());
                }
                node.KeshiPublic = ds.Tables[0].Rows[0]["KeshiPublic"].ToString();

                return node;
            }
            else
            {
                return null;
            }
        }

        public Edge.Security.Model.SysNode GetNodeByUrl(string url, string lan)
        {
            StringBuilder sql = new StringBuilder(300);
            sql.Append("select s.NodeID,case when l.text is not null then l.text ");
            sql.Append("else s.text end as [Text],s.ParentID from S_Tree as s ");
            sql.Append("inner join Lan_S_Tree as l on s.NodeID = l.NodeID ");
            sql.Append("where url = @Url and Lan = @Lan");

            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@Url",url),
                new SqlParameter("@Lan",lan)
            };
            Edge.Security.Model.SysNode node = null;
            using (IDataReader reader = DbHelperSQL.ExecuteReader(sql.ToString(), parameters))
            {
                int i = 0;
                if (reader != null && reader.Read())
                {
                    node = new Edge.Security.Model.SysNode();
                    node.NodeID = int.TryParse(reader["NodeID"].ToString(), out i) ? i : 0;
                    node.Text = reader["Text"].ToString();
                    node.ParentID = int.TryParse(reader["ParentID"].ToString(), out i) ? i : 0;
                }
            }
            return node;

        }

        #region 日志
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="time"></param>
        /// <param name="loginfo"></param>
        public void AddLog(string time, string loginfo, string Particular)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Log(");
            strSql.Append("datetime,loginfo,Particular)");
            strSql.Append(" values (");
            strSql.Append("'" + time + "',");
            strSql.Append("'" + loginfo + "',");
            strSql.Append("'" + Particular + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void DeleteLog(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            strSql.Append(" where ID= " + ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void DelOverdueLog(int days)
        {
            string str = " DATEDIFF(day,[datetime],getdate())>" + days;
            DeleteLog(str);
        }
        public void DeleteLog(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public DataSet GetLogs(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataRow GetLog(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            strSql.Append(" where ID= " + ID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0];
        }

        /// <summary>
        /// 返回数据总数(分页用到)
        /// </summary>
        public int GetLogCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from S_Log ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }
            return Convert.ToInt32(DbHelperSQL.GetCount(strSql.ToString()));
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetLogPageList(int pageSize, int currentPage, string strWhere, string filedOrder)
        {
            int topNum = pageSize * currentPage;
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top " + pageSize + " ID,datetime,loginfo,Particular FROM S_Log ");
            if (currentPage > 0)
            {
                strSql.Append(" where ID not in(select top " + topNum + " ID from S_Log");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" order by " + filedOrder + ")");
            }
            if (strWhere.Trim() != "")
            {
                if (currentPage > 0)
                {
                    strSql.Append(" and " + strWhere);
                }
                else
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            strSql.Append(" order by " + filedOrder);

            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

    }
}
