﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            //SetExecutionStrategy("System.Data.SqlClient", () => new System.Data.Entity.SqlServer.SqlAzureExecutionStrategy());
            //SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.LocalDbConnectionFactory("mssqllocaldb"));

            //通过代码配置Sqlite，否则要在app.config里写一堆东西
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }
}
