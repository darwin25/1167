using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.DBUtility
{
    public class MyCultureInfo
    {
        public enum CultureType
        {
            English=0,
            SimplifiedChinese=1,
            TraditionalChinese=2
        }

        public static CultureType CurrentCulture()
        {
            string cultureName = System.Globalization.CultureInfo.InstalledUICulture.Name.ToLower();
            switch (cultureName)
            {
                case "zh-cn": return CultureType.SimplifiedChinese;
                case "zh-hk": return CultureType.TraditionalChinese;
                case "zh-tw": return CultureType.TraditionalChinese;
                default: return CultureType.English;
            }
        }

        //
        //static void Main()
        //{
        //    Console.WriteLine(System.Globalization.CultureInfo.InstalledUICulture.Name.ToLower());
        //    Console.Read();
        //}
    }
}
