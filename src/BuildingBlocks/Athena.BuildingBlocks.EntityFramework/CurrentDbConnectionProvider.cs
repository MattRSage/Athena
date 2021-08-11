using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Athena.BuildingBlocks.EntityFramework
{
    public class CurrentDbConnectionProvider<TDbContext> : ICurrentDbConnectionProvider
        where TDbContext : DbContext
    {
        private readonly TDbContext dbContext;

        public CurrentDbConnectionProvider(TDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public DbConnection DbConnection => dbContext.Database.GetDbConnection();
    }
}
