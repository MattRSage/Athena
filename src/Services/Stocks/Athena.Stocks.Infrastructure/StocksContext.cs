using Athena.BuildingBlocks.Application.Outbox;
using Athena.BuildingBlocks.Infrastructure;
using Athena.BuildingBlocks.Infrastructure.InternalCommands;
using Athena.Stocks.Domain.StockExchanges;
using Athena.Stocks.Domain.Stocks;
using Athena.Stocks.Infrastructure.Domain.StockExchanges;
using Athena.Stocks.Infrastructure.Domain.Stocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Athena.Stocks.Infrastructure
{
    public class StocksContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }

        public DbSet<StockExchange> StockExchanges { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        public StocksContext(DbContextOptions<StocksContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        public class StocksDbContextDesignFactory : IDesignTimeDbContextFactory<StocksContext>
        {
            public StocksContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<StocksContext>()
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>()
                    .UseSqlServer("Server=.;Initial Catalog=Athena;Integrated Security=true");

                return new StocksContext(optionsBuilder.Options);
            }
        }
    }
}