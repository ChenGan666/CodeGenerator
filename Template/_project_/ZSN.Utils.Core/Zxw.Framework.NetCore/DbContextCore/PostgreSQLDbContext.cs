﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Zxw.Framework.NetCore.IDbContext;
using Zxw.Framework.NetCore.Options;

namespace Zxw.Framework.NetCore.DbContextCore
{
    public class PostgreSQLDbContext:BaseDbContext, IPostgreSQLDbContext
    {
        public PostgreSQLDbContext(DbContextOption option) : base(option)
        {

        }
        public PostgreSQLDbContext(IOptions<DbContextOption> option) : base(option)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(Option.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
