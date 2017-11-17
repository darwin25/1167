using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

namespace Edge.Web.Accounts.LanAdmin
{
    public class LanTools
    {
        /// <summary>
        /// 绑定语言列表
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindLanList(DropDownList ddl)
        {
            ddl.Items.Clear();
            Edge.Security.Manager.Lan_List lanBll = new Edge.Security.Manager.Lan_List();
            DataSet LanList = lanBll.GetAllList();
            ddl.DataSource = LanList;
            ddl.DataValueField = "Lan";
            ddl.DataTextField = "LanDesc";
            ddl.DataBind();
        }

        /// <summary>
        /// 绑定语言列表
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindLanList(FineUI.DropDownList ddl)
        {
            ddl.Items.Clear();
            Edge.Security.Manager.Lan_List lanBll = new Edge.Security.Manager.Lan_List();
            DataSet LanList = lanBll.GetAllList();
            ddl.DataSource = LanList;
            ddl.DataValueField = "Lan";
            ddl.DataTextField = "LanDesc";
            ddl.DataBind();
        }

        internal static void AddLanDesc(DataSet ds, string name, string refKey)
        {
            ds.Tables[0].Columns.Add(new DataColumn(name, typeof(string)));
            Dictionary<string, string> cache = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row[name] = GetLanName(row[refKey].ToString(), cache);
            }
        }

        internal static string GetLanName(string lan, Dictionary<string, string> cache)
        {
            if (string.IsNullOrEmpty(lan)) return "";

            if (cache != null && cache.ContainsKey(lan)) return cache[lan];

            Edge.Security.Manager.Lan_List bll = new Edge.Security.Manager.Lan_List();
            Edge.Security.Model.Lan_List model = bll.GetModelList("Lan='" + lan + "'")[0];

            string result = model == null ? "" : model.LanDesc;

            if (cache != null) cache.Add(lan, result);

            return result;
        }



    }
}
