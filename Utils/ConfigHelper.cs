using Google.Protobuf.WellKnownTypes;
using System;
using System.Configuration;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace ZNS.CodeGenerator.Utils
{
    /// <summary>
    /// 配置文件读取工具类
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// 获取配置字符串值 
        /// </summary>
        /// <param name="configStr">配置名称</param>
        /// <param name="defaultStr">没有配置项时返回的字符串</param>
        /// <returns>字符串值</returns>
        public static string GetString(string configStr, string defaultStr = "")
        {
            return ConfigurationManager.AppSettings[configStr] ?? defaultStr;
        }

        public static int GetInt(string configStr, int defaultInt = -1)
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings[configStr] ?? defaultInt.ToString());
        }

        public static void SetString(string configStr, string defaultStr = "") {

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[configStr] == null)
            {
                settings.Add(configStr, defaultStr);
            }
            else
            {
                settings[configStr].Value = defaultStr;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
