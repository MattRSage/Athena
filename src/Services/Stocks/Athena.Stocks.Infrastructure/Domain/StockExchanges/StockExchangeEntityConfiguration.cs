using Athena.Stocks.Domain.StockExchanges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Stocks.Infrastructure.Domain.StockExchanges
{
    public class StockExchangeEntityConfiguration : IEntityTypeConfiguration<StockExchange>
    {
        public void Configure(EntityTypeBuilder<StockExchange> builder)
        {
            builder.ToTable("StockExchanges", "stocks");

            builder.HasKey(x => x.Id);
            builder.Property<string>("_name").HasColumnName("Name").HasMaxLength(100);
            builder.Property<string>("_exchangeCode").HasColumnName("ExchangeCode").HasMaxLength(5);
        }
    }
}