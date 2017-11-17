using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Edge.Messages
{
    public class PubConstant
    {
        // Properties
        public static string ConnectionString
        {
            get
            {
                string text = ConfigurationManager.AppSettings["ConnectionString"];
                string str2 = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (str2 == "true")
                {
                    text = DESEncrypt.Decrypt(text);
                }
                return text;
            }
        }

        //public static string GetResourceString(string key)
        //{
        //    return Resource.SecurityMsg.ResourceManager.GetString(key);
        //}
    }
}
