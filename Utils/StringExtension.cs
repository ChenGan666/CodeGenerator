using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNS.CodeGenerator.Utils
{
    public static class StringExtension
    {
        public static string ToFirstUpper(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }

        public static string ToFirstLower(this string s)
        {
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }

        public static string ToCSharpName(this string s)
        {
            if (ConfigHelper.GetInt("IsUpperName") != 1)
                return s;
            if (string.IsNullOrWhiteSpace(s))
                return "";
            return string.Join("",s.Split('_').Select(t=>t.ToFirstUpper()));
        }
    }
}
