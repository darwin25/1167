using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Edge.Web.Controls
{
    public partial class SearchBox : System.Web.UI.UserControl
    {
        protected string getGuid = string.Empty;//作为JS的全局变量名
        protected string selOptions = string.Empty;//搜索字段的OPTIONS
        private string _strMsg = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.InitData();
            }
        }
        protected void InitData()
        {
            this.getGuid = "_" + Guid.NewGuid().ToString().Replace("-", "");
            StringBuilder str = new StringBuilder("<option value=\"\">--Choose--</option>");
            if (null != this.TypeList && this.TypeList.Count > 0)
            {
                string[] strFieldType = { };
                foreach (ListItem m in this.TypeList)
                {
                    strFieldType = m.Value.Split('|');
                    if (strFieldType.Length == 3)
                    {
                        str.AppendFormat("<option value=\"{0}\" type=\"{1}\" inputType=\"{2}\">{3}</option>", strFieldType[0], strFieldType[1], strFieldType[2], m.Text);
                    }
                }
                this.selOptions = str.ToString();
            }
        }
        public List<ListItem> TypeList
        {
            get;
            set;
        }
        public string strMsg
        {
            get
            {
                return this._strMsg;
            }
            set
            {
                this._strMsg = value;
                this.lbMsg.Text = string.Format("<br/><span style='color:#f00'>{0}</span>", this._strMsg);
            }
        }
    }
}