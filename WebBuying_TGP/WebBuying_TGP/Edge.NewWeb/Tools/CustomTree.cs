using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edge.Web.Tools
{
    public class CustomTree
    {
        private int id;
        private int parentId;
        private string name;
        private string title;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }


        /// <summary>
        /// 在模拟树的Grid中使用
        /// </summary>
        private int treeLevel = 0;
        /// <summary>
        /// 是Tree中使用
        /// </summary>
        private bool isTreeLeaf = false;
        /// <summary>
        /// 在模拟树的下拉列表中使用
        /// </summary>
        private bool enabled = true;


        /// <summary>
        /// 本菜单在树形结构中层级（从0开始）
        /// </summary>
        public int TreeLevel
        {
            get { return treeLevel; }
            set { treeLevel = value; }
        }

        /// <summary>
        /// 是否可用（默认true）
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        /// 是否叶子节点（默认false）
        /// </summary>
        public bool IsTreeLeaf
        {
            get { return isTreeLeaf; }
            set { isTreeLeaf = value; }
        }
    }
}