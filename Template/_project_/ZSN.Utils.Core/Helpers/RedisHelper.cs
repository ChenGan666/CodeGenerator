using System;
using System.Collections.Generic;
using System.Text;
using ZSN.Utils.Core.DI;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ZSN.Utils.Core.Helpers
{
    /// <summary>
    /// Redis帮助类
    /// </summary>
    public class RedisHelper
    {
        private static readonly IDistributedCache DistributedCache = ServiceLocator.GetInstance<IDistributedCache>();

        public static void Set<T>(string key, T value)
        {
            var data = value == null
                ? ""
                : JsonConvert.SerializeObject(value, Formatting.None,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            DistributedCache.SetString(key, data);
        }

        public static T Get<T>(string key)
        {
            var value = DistributedCache.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
