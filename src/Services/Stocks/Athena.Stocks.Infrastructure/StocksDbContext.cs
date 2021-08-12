using Athena.BuildingBlocks.Infrastructure.EntityFramework;
using Athena.Stocks.Domain.StockExchanges;
using Athena.Stocks.Domain.Stocks;
using Athena.Stocks.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Athena.Stocks.Infrastructure
{
    public class StocksDbContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockExchange> StockExchanges { get; set; }

        public StocksDbContext(DbContextOptions<StocksDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Athena.Stocks");
            modelBuilder.ApplyConfiguration(new StockEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StockEntityConfiguration());
        }

        public class StocksDbContextDesignFactory : IDesignTimeDbContextFactory<StocksDbContext>
        {
            public StocksDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<StocksDbContext>()
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                    .UseSqlServer("Server=.;Initial Catalog=TemplateDb;Integrated Security=true");

                return new StocksDbContext(optionsBuilder.Options);
            }
        }
    }
}