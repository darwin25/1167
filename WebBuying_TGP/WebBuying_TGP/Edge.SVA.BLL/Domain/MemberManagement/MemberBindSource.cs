using System;
using System.Collections.Generic;
using System.Text;
using Edge.SVA.Model;
using System.Data;

namespace Edge.SVA.BLL.Domain.MemberManagement
{
   public class MemberBindSource
    {
       //for bind dropdownlist
       public List<Model.Domain.WebControls.LineItem> BindSource(string tblName,string LanType)
       {
           List<Model.Domain.WebControls.LineItem> list = new List<Model.Domain.WebControls.LineItem>();
           DataSet ds;
           switch (tblName.ToLower())
           {
               case "education":
                   BLL.Education blleducation = new Education();
                   ds = blleducation.GetAllList();
                   break;
               case "nation":
                    BLL.Nation bllnation = new Nation();
                    ds = bllnation.GetAllList();
                    break;
               case "profession":
                    BLL.Profession bllprofession = new Profession();
                    ds = bllprofession.GetAllList();
                    break;
               default:
                    ds = null;
                    break;
           }
           if (ds != null)
           {
               for (int i = 0; i < ds.Tables.Count; i++)
               {
                   DataTable dt = ds.Tables[i];
                   for (int j = 0; j < dt.Rows.Count; j++)
                   {
                       Model.Domain.WebControls.LineItem item = new Model.Domain.WebControls.LineItem();
                       switch (LanType.ToLower())
                       {
                           case "en-us":
                               item.Text = dt.Rows[j][tblName + "Name1"].ToString();
                               break;
                           case "zh-cn":
                               item.Text = dt.Rows[j][tblName + "Name2"].ToString();
                               break;
                           case "zh-hk":
                               item.Text = dt.Rows[j][tblName + "Name3"].ToString();
                               break;
                       }
                       item.Value = dt.Rows[i][tblName + "ID"].ToString();

                       list.Add(item);
                   }
               }
           }
           return list;           
       }
    }
}
