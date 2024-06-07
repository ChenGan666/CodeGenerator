using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FJData.Utils.Core.Extensions;
using FJData.Utils.Core.Helpers;
using Microsoft.Extensions.Configuration;

namespace _company_._project_.CMSWeb.Helpers
{
    public class CMSConfig
    {
        private static IConfigurationSection Section => ConfigHelper.GetSection("CMSConfig");

        public static string GetString(string name, string def="")
        {
            var str = Section[name];
            return string.IsNullOrWhiteSpace(str) ? def : str;
        }

        public static int GetInt(string name, int def = -1)
        {
            var str = Section[name];
            return str.ToInt32(def);
        }
    }
}
