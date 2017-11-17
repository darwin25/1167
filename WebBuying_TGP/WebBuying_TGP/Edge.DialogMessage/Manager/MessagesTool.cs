// File:    DialogMessage.cs
// Author:  Fujiu.HUANG
// Created: 2012年6月12日 10:31:22
// Purpose: Definition of Class DialogMessage

using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace Edge.Messages.Manager
{
    public class MessagesTool
    {
        public static readonly MessagesTool instance = new MessagesTool();

        private Dictionary<string, string> dic = new Dictionary<string, string>();

        private Dictionary<string, string> dic_en_us = new Dictionary<string, string>();

        private Dictionary<string, string> dic_zh_cn = new Dictionary<string, string>();

        private Dictionary<string, string> dic_zh_hk = new Dictionary<string, string>();

        public MessagesTool()
        {
        
        }

        public string MessageLan
        {
            get
            {
                if (HttpContext.Current.Session["MessageLan_Session"] != null)
                {
                    return HttpContext.Current.Session["MessageLan_Session"].ToString();
                }
                return string.Empty;
            }
            set { HttpContext.Current.Session["MessageLan_Session"] = value; }
        }

        public string GetMessage(string tapCode)
        {
            string lan = MessageLan.ToLower().Trim();

            if (string.IsNullOrEmpty(lan))
            {
                lan = "en-us";
            }

            if (lan == "en-us")
            {
                if (this.dic_en_us.ContainsKey(tapCode.Trim()))
                {
                    return dic_en_us[tapCode.Trim()];
                }
            
            }
            else if (lan == "zh-cn")
            {
                if (this.dic_zh_cn.ContainsKey(tapCode.Trim()))
                {
                    return dic_zh_cn[tapCode.Trim()];
                }
            }
            else if (lan == "zh-hk")
            {
                if (this.dic_zh_hk.ContainsKey(tapCode.Trim()))
                {
                    return dic_zh_hk[tapCode.Trim()];
                }
            }

            return "";
        }

        private void Refresh(string project, string product, string lan)
        {
            Data.Message dal = new Edge.Messages.Data.Message();
            DataSet set =dal.GetList(project,product,lan);
            dic.Clear();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                dic.Add(row["TAPCode"].ToString(),row["TAPCode"].ToString()+ ":" + row["Message"].ToString());
            }
        }

        private void Refresh(string product, string lan)
        {
            Data.Message dal = new Edge.Messages.Data.Message();
            DataSet set = dal.GetList(product, lan);
            dic.Clear();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                dic.Add(row["TAPCode"].ToString(), row["TAPCode"].ToString() + ":" + row["Message"].ToString());
            }
        }


        public void Refresh(string product)
        {
            Data.Message dal = new Edge.Messages.Data.Message();
            DataSet set = dal.GetList(product, "en-us");
            this.dic_en_us.Clear();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                dic_en_us.Add(row["TAPCode"].ToString(), row["TAPCode"].ToString() + ":" + row["Message"].ToString());
            }


            set = dal.GetList(product, "zh-cn");
            this.dic_zh_cn.Clear();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                dic_zh_cn.Add(row["TAPCode"].ToString(), row["TAPCode"].ToString() + ":" + row["Message"].ToString());
            }

            set = dal.GetList(product, "zh-hk");
            this.dic_zh_hk.Clear();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                dic_zh_hk.Add(row["TAPCode"].ToString(), row["TAPCode"].ToString() + ":" + row["Message"].ToString());
            }
        }
    }
}