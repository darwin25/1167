using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Utils.Tools
{
    public class LanConvertUtil
    {
        public static string ConvertToOldLanFromNewLan(string newlan)
        {
            string lan = newlan;
            if (string.Equals(lan, "zh_cn"))
            {
                lan = "zh-cn";
            }
            else if (string.Equals(lan, "zh_tw"))
            {
                lan = "zh-hk";
            }
            else
            {
                lan = "en-us";
            }
            return lan;
        }
    }
}
