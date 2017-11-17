using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edge.Web.Tools
{
    public class ExtAspNetTool
    {
        public static void BindDropdownList(FineUI.DropDownList ddl,List<Edge.SVA.Model.Domain.WebControls.LineItem> items)
        {
            ddl.DataSource = items;
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();
            foreach (var item in items)
            {
                if (item.Selected)
                {
                    ddl.SelectedValue = item.Value;
                }
            }
        }
        public static void SetHiden(FineUI.ControlBase con)
        {
            con.HideMode = FineUI.HideMode.Offsets;
            con.Hidden = true;
        }
        public static void SetHidenText(FineUI.RealTextField con,string defaultText)
        {
            con.HideMode = FineUI.HideMode.Offsets;
            con.Hidden = true;
            con.Text = defaultText;
        }
    }
}