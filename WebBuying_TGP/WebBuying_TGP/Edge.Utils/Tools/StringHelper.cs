using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Utils.Tools
{
    public class StringHelper
    {
       
        public static List<string> SplitString(string input, string splitString)
        {
            List<string> list = new List<string>();

            string[] strs = input.Split(splitString.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strs.Length; i++)
            {
                list.Add(strs[i].Trim());
            }
            return list;
        }

        public static int[] StringToInt(string[] list)
        {
            if (list == null || list.Length <= 0) return new int[0];
            int[] nums = new int[list.Length];

            for (int i = 0; i < list.Length; i++)
            {
                nums[i] = Edge.Utils.Tools.ConvertTool.GetInstance().ConverToType<int>(list[i]);
            }

            return nums;
        }

        public static string GetDateTimeString(DateTime? datetime)
        {
            return datetime.HasValue ? datetime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
        }

        public static string GetDateString(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy-MM-dd") : "";
        }
        public static int ConvertToInt(string str)
        {
            int i = 0;
            if (int.TryParse(str,out i))
            {
                return i;
            }
            else
            {
                return i;
            }
        }
    }
}
