using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Edge.Security.Manager
{
    public class PermissionMapper
    {
        private Dictionary<string, int> dic = new Dictionary<string, int>();
        private static PermissionMapper instance = new PermissionMapper();
        private PermissionMapper() { }
        public static PermissionMapper GetSingleton()
        {
            return instance;
        }
        public int GetPermissionIDfromURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return -1;
            }
            string key = url.ToLower();

            if (dic.ContainsKey(key))
            {
                return dic[key];
            }
            return -1;
        }
        private string virtualPath = string.Empty;
        public void SetWebVirtualPath(string path)
        {
            string str = FormatPath(path);
            if (str.EndsWith("/"))
            {
                str = str.Substring(0, str.Length - 1);
            }
            this.virtualPath = str;
        }
        private Dictionary<string, int> publicPageDic = new Dictionary<string, int>();

        public void AddSpecialPage(string pagePath, int flag)
        {
            if (!publicPageDic.ContainsKey(this.virtualPath + FormatPath(pagePath)))
            {
                publicPageDic.Add(this.virtualPath + FormatPath(pagePath), flag);
            }
        }
        public bool Refresh()
        {
            DataSet ds = DbHelperSQL.Query("SELECT [Url],[PermissionID] FROM [S_Tree] ");
            try
            {
                Dictionary<string, int> dicnew = new Dictionary<string, int>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    string key = string.Empty;
                    int val = -1;
                    if (item[0] == null || item[0].ToString().Trim() == string.Empty)
                    {
                        continue;
                    }
                    key = this.virtualPath + FormatPath(item[0].ToString().Trim());
                    if (item[1] == null || item[1].ToString().Trim() == string.Empty)
                    {
                        val = -1;
                    }
                    else
                    {
                        val = (int)item[1];
                    }
                    if (!dicnew.ContainsKey(key))
                    {
                        dicnew.Add(key, val);
                    }
                }
                dic.Clear();
                foreach (string item in publicPageDic.Keys)
                {
                    dic.Add(item, publicPageDic[item]);
                }
                foreach (string item in dicnew.Keys)
                {
                    if (!dic.ContainsKey(item))
                    {
                        dic.Add(item, dicnew[item]);
                    }
                }
                dicnew.Clear();
                dicnew = null;
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }
        private static string FormatPath(string item)
        {
            string key = item.Trim();
            //key = key.Replace("\\","/");
            key = Regex.Replace(key, @"[/\\][/\\    ]*", "/");
            if (!key.Substring(0, 1).Equals("/"))
            {
                key = "/" + key;
            }
            return key.ToLower();
        }

    }
}
