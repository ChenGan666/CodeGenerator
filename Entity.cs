using System.Collections.Generic;
using System.Linq;
using ZNS.CodeGenerator.Utils;

namespace ZSN.CodeGenerator
{
    public class Entity
    {
    }

    public class ServerInfo
    {
        public ServerInfo()
        {
            ServerIp = ConfigHelper.GetString("DefaultServerIP");
            ServerUser = ConfigHelper.GetString("DefaultServerUser");
            ServerPwd = ConfigHelper.GetString("DefaultServerPWD");
            ServerType = ConfigHelper.GetString("DefaultServerType");
        }

        public string ServerIp { get; set; }
        public string ServerUser { get; set; }
        public string ServerPwd { get; set; }
        public string ServerDbName { get; set; }
        public string ServerType { get; set; }

        public bool IsSqlServer => ServerType.ToLower() == "sqlserver";
        public bool IsMySql => ServerType.ToLower() == "mysql";
    }

    public class ServerType
    {
        public static object[] ServerTypeList = {
            "SqlServer",
            "MySql",
        };
    }

    public class DBServer
    {
        private static readonly List<ServerInfo> ServerList = new List<ServerInfo> { new ServerInfo() };

        public static ServerInfo Current => ServerList.Last();
    }
}
